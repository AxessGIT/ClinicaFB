using CFDiLib;
using ClinicaFB.Helpers;
using ClinicaFB.Ingresos;
using ClinicaFB.Modelo;
using Dapper;
using FirebirdSql.Data.FirebirdClient;
using SplashScreen.WindowsForms;
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
    public partial class NotasDeCreditoListado : Form
    {
        private BindingList<Venta> _notas = new BindingList<Venta>();
        private BindingList<Emisor> _emisores = new BindingList<Emisor>();
        private BindingList<Almacen> _almacenes = new BindingList<Almacen>();
        private bool _esPDV = false;

        public NotasDeCreditoListado(bool esPDV)
        {
            InitializeComponent();
            _esPDV = esPDV;
        }

        private void AltasCambios(bool esAlta)
        {
            long notaId = 0;
            if (!esAlta)
            {
                if (grdNotas.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione una nota");
                    return;
                }
                notaId = _notas[grdNotas.CurrentRow.Index].VentaId;
            }


            long almacenId = cboAlmacenes.SelectedValue != null ? (long)cboAlmacenes.SelectedValue : 0;
            long emisorId = cboEmisores.SelectedValue != null ? (long)cboEmisores.SelectedValue : 0;

            NotasAltasCambios notasDeCredito = new NotasAltasCambios(_esPDV, esAlta,emisorId,almacenId,notaId);
            notasDeCredito.ShowDialog();
            CargaNotas();
            SetGrid();

        }
        private void NotasDeCreditoListado_Load(object sender, EventArgs e)
        {
            CargaEmisores();
            CargaAlmacenes();
            CargaNotas();
            SetGrid();

            if (_esPDV == false)
            {
                lblAlmacen.Visible = false;
                cboAlmacenes.Visible = false;
            }

        }
        private void SetGrid()
        {
            grdNotas.DataSource = null;

            grdNotas.AllowUserToAddRows = false;
            grdNotas.AllowUserToDeleteRows = false;


            grdNotas.AutoGenerateColumns = false;
            grdNotas.ReadOnly = true;
            grdNotas.AllowUserToResizeColumns = false;
            grdNotas.AllowUserToResizeRows = false;


            grdNotas.RowHeadersVisible = true;


            grdNotas.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(grdNotas.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            grdNotas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            _notas.ResetBindings();
            grdNotas.DataSource = typeof(BindingList<Venta>);
            grdNotas.DataSource = _notas;
            grdNotas.Refresh();
            

            Refresh();

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
        private void CargaEmisores()
        {
            _emisores = UtilsPDV.GetEmisores();

            cboEmisores.DataSource = null;
            cboEmisores.DataSource = _emisores;
            cboEmisores.ValueMember = "EmisorId";
            cboEmisores.DisplayMember = "Nombre";
            cboEmisores.SelectedValue = _emisores[0].EmisorId;

        }


        private void CargaNotas()
        {
            _notas.Clear();
            _notas = new BindingList<Venta>();

            using (FbConnection db = General.GetDB())
            {
                long emisorId = cboEmisores.SelectedValue != null ? (long)cboEmisores.SelectedValue : 0;    
                long almacenId = cboAlmacenes.SelectedValue != null ? (long)cboAlmacenes.SelectedValue : 0;

                if (_esPDV == false)
                {
                    almacenId = 0; // Si no es PDV, no se filtra por almacén
                }

                string sql = _esPDV?Queries.NotasSelect:Queries.NotasEmisorSelect;

                DateTime fechaIni = dtpFechaInicial.Value;
                DateTime fechaFin = dtpFechaFinal.Value;

                var res = db.Query<Venta>(sql, new {EmisorId =emisorId,AlmacenId = almacenId, FechaIni = fechaIni, FechaFin = fechaFin }).ToList();
                _notas = new BindingList<Venta>(res);
                _notas.ResetBindings();
                



            }
        }





        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            AltasCambios(true);
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            if (grdNotas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una nota");
                return;
            }

            AltasCambios(false);
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            CargaNotas();
            SetGrid();
        }

        private void cmdEliminar_Click(object sender, EventArgs e)
        {
            if (!RenglonSeleccionado())
                return;
            Venta nota = _notas[grdNotas.CurrentRow.Index];

            if (nota.Timbrada)
            {
                MessageBox.Show("No se puede eliminar una nota timbrada");
                return;
            }
            if (nota.Cancelada)
            {
                MessageBox.Show("No se puede eliminar una nota cancelada");
                return;
            }
            if (MessageBox.Show("¿Está seguro de eliminar la nota seleccionada?", "Eliminar Nota", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (FbConnection db = General.GetDB())
                {

                    string sql = Queries.VentaDelete;
                    long notaId = _notas[grdNotas.CurrentRow.Index].VentaId;
                    db.Execute(sql, new { VentaId = notaId });

                    sql = Queries.VentaDetallesDelete;
                    db.Execute(sql, new { VentaId = notaId });
                }

                if (_esPDV) {
                    UtilsInv.ActualizaExistenciasYMovimientosNotaCancelada(nota.VentaId);
                }
                CargaNotas();
            }

        }

        private bool RenglonSeleccionado()
        {
            if (grdNotas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una nota");
                return false;
            }
            return true;
        }


        private bool CancelarCFDi(long notaId)
        {

            SplashScreen.WindowsForms.Splasher splasher = new SplashScreen.WindowsForms.Splasher("Cancelando nota...");
            splasher.Show();
            bool cancelada = false;


            string uid = "";
            string rfc = "";
            string pas = "";
            long emisorId = 0;
            string sql = "";
            Emisor emi = new Emisor();

            using (FbConnection db = General.GetDB())
            {

                Venta nota = new Venta();
                sql = Queries.VentaSelect;
                nota = db.Query<Venta>(sql, new { VentaId = notaId }).FirstOrDefault();
                uid = nota.UID;
                emisorId = nota.EmisorId;

                sql = Queries.EmisorSelect();
                emi = db.Query<Emisor>(sql, new { EmisorId = emisorId }).FirstOrDefault();

                if (emi == null)
                {
                    return cancelada;
                }

                rfc = emi.RFC;
                pas = emi.PassWord;
            }
            string cerTmp = Path.GetTempFileName() + ".cer";
            string llaveTmp = Path.GetTempFileName() + ".key";


            if (emi.Cer.Length > 0 && emi.Llave.Length > 0)
            {
                File.WriteAllBytes(cerTmp, emi.Cer);
                File.WriteAllBytes(llaveTmp, emi.Llave);
            }


            ComprobanteCFDI comprobante = new ComprobanteCFDI();

            string motivo = "02";
            string res =  comprobante.CancelaSW(rfc, cerTmp, llaveTmp, pas, uid, motivo);



            if (File.Exists(cerTmp))
                File.Delete(cerTmp);

            if (File.Exists(llaveTmp))
                File.Delete(llaveTmp);

            if (res.Substring(0, 3) == "999")
            {
                MessageBox.Show("No fue posible cancelar la nota " + res, "Confirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                splasher.Close();

                return cancelada;

            }


            using (FbConnection db = General.GetDB())
            {
                sql = Queries.VentaSetDatosCancelacion;
                db.Execute(sql, new { VentaId = notaId, Acuse = res });
            }
            splasher.Close();

            MessageBox.Show($"Nota cancelada\nAcuse: {res} ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cancelada = true;
            return cancelada;



        }


        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            if (!RenglonSeleccionado()) 
                return;


            bool notaCancelada = _notas[grdNotas.CurrentRow.Index].Cancelada;

            if (notaCancelada)
            {
                MessageBox.Show("La nota ya está cancelada");
                return;
            }

            bool notaTimbrada = _notas[grdNotas.CurrentRow.Index].Timbrada;

            
            if (MessageBox.Show("¿Está seguro de cancelar la nota?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            long notaId = _notas[grdNotas.CurrentRow.Index].VentaId;


            if (notaTimbrada)
            {
                if (!CancelarCFDi(notaId))
                    return;
            }
            else
            {
                using (FbConnection db = General.GetDB())
                {
                    string sql = Queries.VentaSetDatosCancelacion;
                    db.Execute(sql, new { VentaId = notaId, Acuse = "" });
                }

            }


            if (_esPDV)
                UtilsInv.ActualizaExistenciasYMovimientosNotaCancelada(notaId);
            
            CargaNotas();
            SetGrid();


        }

        private void cmdArchivos_Click(object sender, EventArgs e)
        {



            if (!RenglonSeleccionado())
                return;

            UtilsPDV.MuestraArchivosCFDi(_notas[grdNotas.CurrentRow.Index].VentaId, "NDC");


        }
    }
}
