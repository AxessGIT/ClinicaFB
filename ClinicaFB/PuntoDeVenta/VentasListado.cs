using CFDiLib;
using ClinicaFB.Helpers;
using ClinicaFB.Ingresos;
using ClinicaFB.Modelo;
using Dapper;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFB.PuntoDeVenta
{
    public partial class VentasListado : Form
    {
        private BindingList<Almacen> _almacenes = new BindingList<Almacen>();
        private BindingList<Venta> _ventas = new BindingList<Venta>();

        public VentasListado()
        {
            InitializeComponent();
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void VentasListado_Load(object sender, EventArgs e)
        {
            CargaAlmacenes();
            CargaVentas();
            SetGrid();
        }


        private void CargaAlmacenes()
        {

            long almacenIdDefa = 0;
            _almacenes = UtilsPDV.GetAlmacenes();

         
            foreach (var alma in _almacenes)
            {
                if (alma.Defa)
                {
                    almacenIdDefa = alma.AlmacenId;
                    break;
                }
            }

            cboAlmacenes.DataSource = null;
            cboAlmacenes.DataSource = _almacenes;
            cboAlmacenes.ValueMember = "AlmacenId";
            cboAlmacenes.DisplayMember = "Nombre";
            cboAlmacenes.SelectedValue = almacenIdDefa;

            


        }

        private void CargaVentas()
        {
            using (FbConnection db = General.GetDB())
            {
                string sql = ClinicaFB.Helpers.Queries.VentasSelectxSucursalYFechas;
                int sucursalId = Properties.Settings.Default.SucursalId;
                long almacenId = (long)cboAlmacenes.SelectedValue;
                DateTime fechaIni = dtpFechaInicial.Value;
                DateTime fechaFin = dtpFechaFinal.Value;

                var res = db.Query<Venta>(sql, new { SucursalId = sucursalId,AlmacenId=almacenId, FechaIni = fechaIni, FechaFin = fechaFin }).ToList();
                _ventas = new BindingList<Venta>(res);
            }
        }

        private void SetGrid()
        {
            grdVentas.DataSource = null;

            grdVentas.AllowUserToAddRows = false;
            grdVentas.AllowUserToDeleteRows = false;


            grdVentas.AutoGenerateColumns = false;
            grdVentas.ReadOnly = true;
            grdVentas.AllowUserToResizeColumns = false;
            grdVentas.AllowUserToResizeRows = false;


            grdVentas.RowHeadersVisible = true;


            grdVentas.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(grdVentas.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            grdVentas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            grdVentas.DataSource = _ventas;

        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            CargaVentas();
            SetGrid();
        }

        private void cmdVer_Click(object sender, EventArgs e)
        {
            long ventaId = RenglonSeleccionado();
            if (ventaId == 0)
            {
                MessageBox.Show("No hay venta seleccionada");
                return;
            }
            VentaVisor ventaVisor = new VentaVisor(ventaId);
            ventaVisor.ShowDialog();




        }

        private long RenglonSeleccionado()
        {
            long ventaId = 0;
            if (grdVentas.CurrentRow != null)
                ventaId = _ventas[grdVentas.CurrentRow.Index].VentaId;
            return ventaId;


        }

        private void grdVentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cmdVer_Click(sender, e);
        }

        private async void cmdCancelar_Click(object sender, EventArgs e)
        {
            long conceptoVentaId = UtilsInv.GetConceptoInternoId("S", "VENTA");


            long ventaId = RenglonSeleccionado();
            if (ventaId == 0)
            {
                MessageBox.Show("No hay venta seleccionada");
                return;
            }

            bool ventaCancelada = _ventas[grdVentas.CurrentRow.Index].Cancelada;

            if (ventaCancelada)
            {
                MessageBox.Show("La venta ya está cancelada");
                return;
            }

            Venta venta = _ventas[grdVentas.CurrentRow.Index];
            string tipo = venta.Tipo;
            if (tipo == "FAC" && venta.Timbrada)
            {
                CfdiCancelar cfdiCancelar = new CfdiCancelar(ventaId, true);
                cfdiCancelar.ShowDialog();
                ventaCancelada = cfdiCancelar.Cancelada;
            }
            else
            {
                if (MessageBox.Show("¿Está seguro de cancelar la venta?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                using (FbConnection db = General.GetDB())
                {

                    await db.OpenAsync();
                    using (var transaction = db.BeginTransaction())
                    {
                        try
                        {
                            string sql = ClinicaFB.Helpers.Queries.VentaSetDatosCancelacion;
                            db.Execute(sql, new { VentaId = ventaId, Acuse = "" },transaction);
                            ventaCancelada = true;
                            transaction.Commit();
                            ventaCancelada = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al cancelar la venta: " + ex.Message);
                            transaction.Rollback();
                            return;
                        }
                    }

                }
            }
            if (ventaCancelada)
            {

                using (FbConnection db = General.GetDB())
                {

                    await db.OpenAsync();
                    using (var transaction = db.BeginTransaction())
                    {
                        try
                        {
                            await UtilsInv.ActualizaExistenciasYMovimientosVentaCancelada(ventaId, db, transaction);
                            List<VentaDetalle> detalles = UtilsInv.GetVentaDetalle(ventaId);

                            long almacenId = cboAlmacenes.SelectedValue != null ? (long)cboAlmacenes.SelectedValue : 0;
                            await UtilsInv.VentaReconstruyeCapasDeCostos(almacenId, detalles, db, transaction);



                            transaction.Commit();

                            CargaVentas();
                            SetGrid();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al cancelar la venta: " + ex.Message);
                            transaction.Rollback();
                            return;
                        }
                    }

                }


            }



        }

        private async void cmdArchivos_Click(object sender, EventArgs e)
        {
            long ventaId = RenglonSeleccionado();

            if (ventaId==0)
            {
                MessageBox.Show("No hay venta seleccionada");
                return;
            }

            if (!_ventas[grdVentas.CurrentRow.Index].Timbrada)
            {
                MessageBox.Show("La venta no está timbrada");
                return;

            }

            await UtilsPDV.MuestraArchivosCFDi(ventaId);

        }

        private async void cmdMandarCorreo_Click(object sender, EventArgs e)
        {
            long ventaId = RenglonSeleccionado();
            if (ventaId == 0)
            {
                MessageBox.Show("No hay venta seleccionada");
                return;
            }
            Venta venta = _ventas[grdVentas.CurrentRow.Index];
            if (!venta.Timbrada)
            {
                MessageBox.Show("La venta no está facturada");
                return;
            }

            long razonSocialId = venta.ClienteId;
            CorreosDirecciones correosDirecciones = new CorreosDirecciones(razonSocialId);
            correosDirecciones.ShowDialog();

            if (correosDirecciones.Aceptar == false)
            {
                return;
            }

            Emisor emisor = new Emisor();
            using (FbConnection db = General.GetDB())
            {
                string sql = ClinicaFB.Helpers.Queries.EmisorSelect();
                emisor = db.Query<Emisor>(sql, new { EmisorId = venta.EmisorId }).FirstOrDefault();
                if (emisor == null)
                {
                    MessageBox.Show("No se encontró el emisor");
                    return;
                }
            }


            string carpetaCfdi = General.CarpetaFacturaPDV(emisor.RFC, venta.Fecha);
            string archivoCfdi = carpetaCfdi + @"\" + General.NombreArchivoCfdi("FAC", venta.SerieFac, venta.FolioFac);
            string archivoPDF = carpetaCfdi + @"\" + General.NombreArchivoPDF("FAC", venta.SerieFac, venta.FolioFac);

            string[] dirs = correosDirecciones.txtDirecciones.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            string direcciones = dirs[0];

            if (dirs.Length > 1)
            {
                foreach (var d in dirs)
                {
                    direcciones = "," + direcciones + d;
                }

            }

            await ManejaCFDIs.MandaCorreo(direcciones, archivoCfdi, archivoPDF);
            MessageBox.Show("Se envío el correo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private async void cmdTicket_Click(object sender, EventArgs e)
        {
            long ventaId = RenglonSeleccionado();
            if (ventaId == 0)
            {
                MessageBox.Show("No hay venta seleccionada");
                return;
            }
            Venta vta = new Venta();
            BindingList<VentaDetalle> ventaDetalle = new BindingList<VentaDetalle>();
            using (FbConnection db = General.GetDB())
            {
                string sql = ClinicaFB.Helpers.Queries.VentaSelect;
                vta = db.Query<Venta>(sql, new { VentaId = ventaId }).FirstOrDefault();
                sql = ClinicaFB.Helpers.Queries.VentaDetallesSelect;
                var res  = db.Query<VentaDetalle>(sql, new { VentaId = ventaId }).ToList();
                ventaDetalle = new BindingList<VentaDetalle>(res);
            }

            
            string impTicket = Properties.Settings.Default.ImpresoraTicket;
            await Task.Run(() => ManejaCFDIs.ImprimeTicketPDV(vta, ventaDetalle, imprimir:true, impresora:impTicket));


        }

        private  async Task Facturar()
        {
            long ventaId = RenglonSeleccionado();
            if (ventaId == 0)
            {
                MessageBox.Show("No hay venta seleccionada");
                return;
            }
            Venta venta = _ventas[grdVentas.CurrentRow.Index];

            if (venta.Timbrada)
            {
                MessageBox.Show("La venta ya está facturada");
                return;
            }

            if (venta.Cancelada)
            {
                MessageBox.Show("La venta está cancelada");
                return;
            }

            if (venta.FacturaGlobalId>0)
            {
                MessageBox.Show("La venta ya está facturada en la factura global");
                return;
            }


            FacturarOpciones clavesSATSeleccionar = new FacturarOpciones(venta.ClienteId,selRazon:true);
            clavesSATSeleccionar.ShowDialog();

            if (clavesSATSeleccionar.Aceptar == false)
            {
                return;
            }

            string cvFOP = "";
            string cvMEP = "";
            string cvUSO = "";
            bool imprimir = false;
            string impresora = "";
            bool mandarCorreos = false;
            string correos = "";
            long razSocId = clavesSATSeleccionar.RazonSocialId;
            DateTime fechaFactura = clavesSATSeleccionar.dtpFecha.Value;
            cvFOP = clavesSATSeleccionar.txtCveFOP.Text.Trim();
            cvMEP = clavesSATSeleccionar.txtCveMEP.Text.Trim();
            cvUSO = clavesSATSeleccionar.txtCveUSO.Text.Trim();
            imprimir = clavesSATSeleccionar.chkImprimir.Checked;
            impresora = clavesSATSeleccionar.cboImpresoras.Text.Trim();
            mandarCorreos = clavesSATSeleccionar.chkMandarCorreo.Checked;
            correos = clavesSATSeleccionar.txtCorreos.Text.Trim();

            using (FbConnection db = General.GetDB())
            {

                await db.OpenAsync();
                using (var transaction = db.BeginTransaction())
                {
                    try
                    {

                        string sql = ClinicaFB.Helpers.Queries.VentaSelect;
                        venta = db.Query<Venta>(sql, new { VentaId = ventaId },transaction).FirstOrDefault();
                        long almacenId = venta.AlmacenId;
                        Almacen alma = db.Query<Almacen>(ClinicaFB.Helpers.Queries.AlmacenSelect(), new { AlmacenId = almacenId },transaction).FirstOrDefault();

                        venta.SerieFac = alma.SerieFac;
                        venta.FolioFac = alma.FolioFac;
                        venta.FechaFac = fechaFactura;

                        venta.Tipo = "FAC";


                        venta.Fecha = DateTime.Now;
                        venta.ClienteId = razSocId;
                        venta.FormaPago = cvFOP;
                        venta.MetodoPago = cvMEP;
                        venta.Uso = cvUSO;


                        int res = await ManejaCFDIs.GeneraFactura(venta, db, transaction, imprimir, impresora, mandarCorreos, correos, guardarClienteFactura: true);

                        if (res == 0)
                        {
                            MessageBox.Show("Factura generada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        CargaVentas();
                        SetGrid();



                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error : " + ex.Message);
                        transaction.Rollback();
                        return;
                    }
                }



            }



        }

        private void cmdExportar_Click(object sender, EventArgs e)
        {

        }

        private void cmdReportes_Click(object sender, EventArgs e)
        {
            long almacenId = (long) cboAlmacenes.SelectedValue;
            DateTime fechaIni = dtpFechaInicial.Value;
            DateTime fechaFin = dtpFechaFinal.Value;
            CorteReportes corteReportes = new CorteReportes(almacenId,fechaIni,fechaFin);
            corteReportes.ShowDialog();
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            long ventaId = RenglonSeleccionado();
            if (ventaId == 0)
            {
                MessageBox.Show("No hay venta seleccionada");
                return;
            }
            Venta venta = _ventas[grdVentas.CurrentRow.Index];
            if (venta.Timbrada)
            {
                MessageBox.Show("La venta ya está facturada");
                return;
            }
            if (venta.Cancelada)
            {
                MessageBox.Show("La venta está cancelada");
                return;
            }
            if (venta.FacturaGlobalId > 0)
            {
                MessageBox.Show("La venta ya está facturada en la factura global");
                return;
            }
            PdV pdV = new PdV(esAlta:false, ventaId: ventaId);
            pdV.ShowDialog();
            CargaVentas();
            SetGrid();

        }

        private async void cmdFacturar_Click(object sender, EventArgs e)
        {
            cmdFacturar.Enabled = false;
            await Facturar();
            cmdFacturar.Enabled = true;
        }
    }
}
