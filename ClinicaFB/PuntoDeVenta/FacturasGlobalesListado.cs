using CFDiLib;
using ClinicaFB.Helpers;
using ClinicaFB.Ingresos;
using ClinicaFB.Modelo;
using Dapper;
using FirebirdSql.Data.FirebirdClient;
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
    public partial class FacturasGlobalesListado: Form
    {
        private BindingList<Venta> _ventas = new BindingList<Venta>();
        private BindingList<Emisor> _emisores = new BindingList<Emisor>();
        private BindingList<Almacen> _almacenes = new BindingList<Almacen>();

        public FacturasGlobalesListado()
        {
            InitializeComponent();
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FacturasGlobalesListado_Load(object sender, EventArgs e)
        {
            CargaEmisores();
            CargaAlmacenes();
            CargaFacturas();
            SetGrid();

        }
        private long RenglonSeleccionado()
        {
            long ventaId = 0;
            if (grdVentas.CurrentRow != null)
                ventaId = _ventas[grdVentas.CurrentRow.Index].VentaId;
            return ventaId;


        }

        private void CargaFacturas()
        {
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.FacturasGlobalesSelect;
                int sucursalId = Properties.Settings.Default.SucursalId;
                DateTime fechaIni = dtpFechaInicial.Value;
                DateTime fechaFin = dtpFechaFinal.Value;

                var res = db.Query<Venta>(sql, new { SucursalId = sucursalId, FechaIni = fechaIni, FechaFin = fechaFin }).ToList();
                _ventas = new BindingList<Venta>(res);
            }
        }


        private void CargaEmisores()
        {
            _emisores = UtilsPDV.GetEmisores();

              cboEmisores.DataSource = null;
            cboEmisores.DataSource = _emisores;
            cboEmisores.ValueMember = "EmisorId";
            cboEmisores.DisplayMember = "Nombre";
            cboEmisores.SelectedValue = _emisores[0].EmisorId;

        }


        private void CargaEmisores2()
        {

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.EmisoresPDVSelect;
                var res = db.Query<ClinicaFB.Modelo.Emisor>(sql).ToList();
                _emisores = new BindingList<ClinicaFB.Modelo.Emisor>(res);

            }
            cboEmisores.DataSource = null;
            cboEmisores.DataSource = _emisores;
            cboEmisores.ValueMember = "EmisorId";
            cboEmisores.DisplayMember = "Nombre";
            cboEmisores.SelectedValue = _emisores[0].EmisorId;

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


        private void CargaAlmacenes2()
        {

            long almacenIdDefa = 0;
            string nombreAlmacenDefa = "";

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.AlmacenesSelect();

                var res = db.Query<Almacen>(sql).ToList();

                foreach (var alma in res)
                {
                    if (alma.Defa)
                    {
                        almacenIdDefa = alma.AlmacenId;
                        nombreAlmacenDefa = alma.Nombre;
                        break;
                    }

                }
                _almacenes = new BindingList<Almacen>(res);



            }
            cboAlmacenes.DataSource = null;
            cboAlmacenes.DataSource = _almacenes;
            cboAlmacenes.ValueMember = "AlmacenId";
            cboAlmacenes.DisplayMember = "Nombre";
            cboAlmacenes.SelectedValue = almacenIdDefa;


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
            CargaFacturas();
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

        private void cmdArchivos_Click(object sender, EventArgs e)
        {
            long ventaId = RenglonSeleccionado();

            if (ventaId == 0)
            {
                MessageBox.Show("No hay venta seleccionada");
                return;
            }

            if (!_ventas[grdVentas.CurrentRow.Index].Timbrada)
            {
                MessageBox.Show("La venta no está timbrada");
                return;

            }

            UtilsPDV.MuestraArchivosCFDi(ventaId);

            /*Venta venta = new Venta();
            List<VentaDetalle> detalle = new List<VentaDetalle>();
            Emisor emisor = new Emisor();

            using (FbConnection db = General.GetDB())
            {
                string sql = "";
                sql = Queries.VentaSelect;
                venta = db.Query<Venta>(sql, new { VentaId = ventaId }).FirstOrDefault();
                sql = Queries.VentaDetallesSelect;
                detalle = db.Query<VentaDetalle>(sql, new { VentaId = ventaId }).ToList();

                sql = Queries.EmisorSelect();
                emisor = db.Query<Emisor>(sql, new { EmisorId = venta.EmisorId }).FirstOrDefault();


            }

            string carpetaCfdi = General.CarpetaFacturaPDV(emisor.RFC, venta.FechaFac);
            string archivoCfdi = carpetaCfdi + @"\" + General.NombreArchivoCfdi("FAC", venta.SerieFac, venta.FolioFac);

            if (string.IsNullOrEmpty(venta.xml))
                venta.xml = File.Exists(archivoCfdi) ? File.ReadAllText(archivoCfdi) : "";

            ComprobanteCFDI comprobante = new ComprobanteCFDI();


            ManejaCFDIs.GeneraPDFFacturaPDV(venta, detalle);

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
            {
                FileName = carpetaCfdi,
                UseShellExecute = true,
                Verb = "open"
            });*/

        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            long ventaId = RenglonSeleccionado();
            if (ventaId == 0)
            {
                MessageBox.Show("No hay venta seleccionada");
                return;
            }
            CfdiCancelar cfdiCancelar = new CfdiCancelar(ventaId, true);
            cfdiCancelar.ShowDialog();
            if (cfdiCancelar.Cancelada)
            {
                using (FbConnection db = General.GetDB())
                {
                    string sql = Queries.FacturaGlobalIdReset;
                    db.Execute(sql, new { VentaId = ventaId });
                }
                CargaFacturas();
                SetGrid();
            }

        }

        private async Task cmdTimbrar_Click(object sender, EventArgs e)
        {
            if (grdVentas.CurrentRow == null)
            {
                MessageBox.Show("No hay venta seleccionada");
                return;
            }
            if (_ventas[grdVentas.CurrentRow.Index].Timbrada)
            {
                MessageBox.Show("La venta ya está timbrada");
                return;
            }

            if (_ventas[grdVentas.CurrentRow.Index].Cancelada)
            {
                MessageBox.Show("La venta está cancelada");
                return;
            }


            if (MessageBox.Show("¿Desea timbrar la factura?", "Factura Global", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            int sucursalId = Properties.Settings.Default.SucursalId;
            long almacenId = (long)cboAlmacenes.SelectedValue;
            int emisorId = (int)cboEmisores.SelectedValue;
            Emisor emisor = new Emisor();



            using (FbConnection db = General.GetDB())
            {
                await db.OpenAsync();
                using (FbTransaction fbTransaction = db.BeginTransaction())
                {

                    try
                    {
                        string sql = Queries.EmisorSelect();
                        emisor = db.Query<Emisor>(sql, new { EmisorId = emisorId }).FirstOrDefault();

                        long ventaId = RenglonSeleccionado();
                        Venta venta = new Venta();


                        sql = Queries.VentaSelect;
                        venta = db.Query<Venta>(sql, new { VentaId = ventaId }, fbTransaction).FirstOrDefault();

                        venta.FechaFac = DateTime.Now;

                        SplashScreen.WindowsForms.Splasher splasher = new SplashScreen.WindowsForms.Splasher("Timbrando factura...");
                        splasher.Show();

                        int res = await ManejaCFDIs.GeneraFactura(vta: venta, db,  fbTransaction, incrementaFolioFactura: false);
                        splasher.Close();
                        if (res == 0)
                        {
                            MessageBox.Show("Factura global generada correctamente", "Factura Global", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargaFacturas();
                            SetGrid();

                        }

                        fbTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        fbTransaction.Rollback();
                        MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

            }



        }

    }
}
