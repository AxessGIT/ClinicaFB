using CFDiLib;
using ClinicaFB.Helpers;
using ClinicaFB.Modelo;
using Dapper;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Twilio.Annotations;

namespace ClinicaFB.PuntoDeVenta
{
    public partial class EntradasSalidasListado : Form
    {
        private string _tipo = string.Empty;
        private BindingList<Almacen> _almacenes = new BindingList<Almacen>();
        BindingList<Documento> _documentos = new BindingList<Documento>();

        public EntradasSalidasListado()
        {
            InitializeComponent();
        }
        public EntradasSalidasListado(string tipo)
        {
            InitializeComponent();
            _tipo = tipo;
            Text = _tipo == "E" ? "Entradas" : "Salidas";
        }

        private void EntradasSalidasListado_Load(object sender, EventArgs e)
        {
            dtpFechaInicial.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpFechaFinal.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            CargaAlmacenes();
            CargaDocumentos();
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

   

        private void CargaDocumentos()
        {
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.EntradasSalidasSelect;
                long almacenId = cboAlmacenes.SelectedValue != null ? (long)cboAlmacenes.SelectedValue : 0;
                var res = db.Query<Documento>(sql, new {TipoCon= _tipo, FechaIni = dtpFechaInicial.Value, FechaFin = dtpFechaFinal.Value, AlmacenId = almacenId }).ToList();
                _documentos = new BindingList<Documento>(res);
            }
        }

        private void SetGrid()
        {
            grdDocumentos.DataSource = null;



            grdDocumentos.AllowUserToAddRows = false;
            grdDocumentos.AllowUserToDeleteRows = false;


            grdDocumentos.AutoGenerateColumns = false;
            grdDocumentos.ReadOnly = true;
            grdDocumentos.AllowUserToResizeColumns = false;
            grdDocumentos.AllowUserToResizeRows = false;



            grdDocumentos.ColumnHeadersDefaultCellStyle.Font = new Font(grdDocumentos.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            grdDocumentos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;



            grdDocumentos.DataSource = _documentos;

        }

        private void AltasCambios(bool esAlta)
        {

            long almacenId = cboAlmacenes.SelectedValue != null ? (long)cboAlmacenes.SelectedValue : 0; 
            long docId = 0;

            if (!esAlta)
            {
                docId = _documentos[grdDocumentos.CurrentRow.Index].DocumentoId;
            }

            EntradasSalidasAltasCambios entradaSalidaAC = new EntradasSalidasAltasCambios(_tipo, esAlta,almacenId, docId);
            entradaSalidaAC.ShowDialog();

            CargaDocumentos();
            SetGrid();
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            AltasCambios(true);
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            if (grdDocumentos.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un documento para modificar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            AltasCambios(false);

        }

        private void grdDocumentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cmdModificar_Click(sender, e);
        }

        private async void cmdCancelar_Click(object sender, EventArgs e)
        {
            if (grdDocumentos.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un documento para cancelar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            long conceptoId = _documentos[grdDocumentos.CurrentRow.Index].ConceptoId;
            long entradaSalidaId = _documentos[grdDocumentos.CurrentRow.Index].DocumentoId;


            if (MessageBox.Show("¿Está seguro de cancelar el documento?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }


            bool esEntrada = _tipo == "E";
            long almacenId = _documentos[grdDocumentos.CurrentRow.Index].AlmacenId;

            List<DocumentoDetalle> detalle = new List<DocumentoDetalle>();

            detalle = await UtilsInv.GetDocumentoDetalle(entradaSalidaId);



            using (FbConnection db = General.GetDB())
            {
                await db.OpenAsync();
                using (var transaction = db.BeginTransaction())
                {
                    try
                    {
                        await UtilsInv.DevuelveDetalleOriginal(detalle.ToList(), almacenId: almacenId, esEntrada, db, transaction);
                        await UtilsInv.DocumentoBorraDetalle(entradaSalidaId, db, transaction);
                        await UtilsInv.DocumentoBorraMovimientosXId(entradaSalidaId,db,transaction);
                        await UtilsInv.DocumentoReconstruyeCapasDeCostos(almacenId, detalle.ToList(), db, transaction);


                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error al borrar el documento: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }


            }


            MessageBox.Show("Documento borrado correctamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargaDocumentos();
            SetGrid();


        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            CargaDocumentos();
            SetGrid();
        }

        private void cmdArchivoPDF_Click(object sender, EventArgs e)
        {


            if (grdDocumentos.CurrentRow == null)
            {
                MessageBox.Show("No hay venta seleccionada");
                return;
            }

            long documentoId = _documentos[grdDocumentos.CurrentRow.Index].DocumentoId;


            Documento doc = new Documento();
            List<DocumentoDetalle> detalle = new List<DocumentoDetalle>();

            using (FbConnection db = General.GetDB())
            {
                string sql = "";
                sql = Queries.DocumentoSelect;
                doc = db.Query<Documento>(sql, new { DocumentoId = documentoId }).FirstOrDefault();
                sql = Queries.DocumentoDetalleSelect;
                detalle = db.Query<DocumentoDetalle>(sql, new { DocumentoId = documentoId }).ToList();

            }
            long sucursalid = doc.SucursalId;
        
            UtilsInv.GeneraPDFDocumento(doc, detalle);

            string carpetaDocs = UtilsInv.CarpetaDocumentosPDV(sucursalid, doc.Fecha);

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
            {
                FileName = carpetaDocs,
                UseShellExecute = true,
                Verb = "open"
            });

        }
    }
}
