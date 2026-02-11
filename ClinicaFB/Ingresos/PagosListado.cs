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

namespace ClinicaFB.Ingresos
{
    public partial class PagosListado : Form
    {

        private BindingList<Emisor> _emisores = new BindingList<Emisor>();
        private BindingList<ComplementoPago> _complementos = new BindingList<ComplementoPago>();
        private bool _esPDV = false;

        public PagosListado(bool esPDV)
        {
            InitializeComponent();
            _esPDV = esPDV;
        }

        private void PagosListado_Load(object sender, EventArgs e)
        {
            CargaEmisores();
            CargaComplementos();
            SetGrid();
        }

        private void CargaEmisores()
        {

            using (FbConnection db = General.GetDB())
            {
                string sql = _esPDV ? Queries.EmisoresPDVSelect : Queries.EmisoresNoPDVSelect;
                var res = db.Query<Emisor>(sql).ToList();
                _emisores = new BindingList<Emisor>(res);

            }

            cboEmisores.DataSource = null;
            cboEmisores.DataSource = _emisores;
            cboEmisores.ValueMember = "EmisorId";
            cboEmisores.DisplayMember = "Nombre";
            cboEmisores.SelectedValue = _emisores[0].EmisorId;

        }


        private void CargaComplementos()
        {
            _complementos.Clear();
            _complementos = new BindingList<ComplementoPago>();

            using (FbConnection db = General.GetDB())
            {
                long emisorId = cboEmisores.SelectedValue != null ? (long)cboEmisores.SelectedValue : 0;


                string sql = Queries.ComplementosDePagoSelect;

                DateTime fechaIni = dtpFechaInicial.Value;
                DateTime fechaFin = dtpFechaFinal.Value;

                var res = db.Query<ComplementoPago>(sql, new { EmisorId = emisorId, FechaIni = fechaIni, FechaFin = fechaFin }).ToList();
                _complementos = new BindingList<ComplementoPago>(res);
                _complementos.ResetBindings();




            }
        }


        private void SetGrid()
        {
            grdPagos.DataSource = null;

            grdPagos.AllowUserToAddRows = false;
            grdPagos.AllowUserToDeleteRows = false;


            grdPagos.AutoGenerateColumns = false;
            grdPagos.ReadOnly = true;
            grdPagos.AllowUserToResizeColumns = false;
            grdPagos.AllowUserToResizeRows = false;


            grdPagos.RowHeadersVisible = true;


            grdPagos.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(grdPagos.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            grdPagos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            _complementos.ResetBindings();
            grdPagos.DataSource = typeof(BindingList<Venta>);
            grdPagos.DataSource = _complementos;
            grdPagos.Refresh();


            Refresh();

        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            CargaComplementos();
            SetGrid();
        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            AltasCambios(true);
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            if (grdPagos.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un complemento para modificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            AltasCambios(false);

        }

        private void AltasCambios(bool esAlta)
        {

            if (cboEmisores.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un emisor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            long emisorId = (long)cboEmisores.SelectedValue;
            long complementoId = 0;

            if (esAlta == false )
            {
                complementoId = _complementos[grdPagos.CurrentRow.Index].ComPagId;

            }
            PagoAltaCambio pago = new PagoAltaCambio(_esPDV,esAlta, complementoId,emisorId);
            pago.ShowDialog();

            CargaComplementos();
            SetGrid();
        }

        private void cmdEliminar_Click(object sender, EventArgs e)
        {
            if (grdPagos.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un complemento para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            if (_complementos[grdPagos.CurrentRow.Index].Timbrado)
            {
                MessageBox.Show("No se puede eliminar un complemento que ya ha sido timbrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_complementos[grdPagos.CurrentRow.Index].Cancelado)
            {
                MessageBox.Show("No se puede eliminar un complemento que ya ha sido cancelado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (MessageBox.Show("¿Está seguro de eliminar el complemento de pago?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            long complementoId = _complementos[grdPagos.CurrentRow.Index].ComPagId;

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.ComplementoDePagoDelete;
                db.Execute(sql, new { ComPagId = complementoId });
                sql = Queries.ComPagRelsDelete;
                db.Execute(sql, new { ComPagoId = complementoId });
            }
            CargaComplementos();
            SetGrid();

        }

        private void cmdTimbrar_Click(object sender, EventArgs e)
        {
            if (!HayRenglonSeleccionado())
            {
                return;
            }

            if (ComplementoTimbrado())
            {
                return;
            }

            if (MessageBox.Show("¿Está seguro de timbrar el complemento de pago?", "Timbrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            long complementoId = _complementos[grdPagos.CurrentRow.Index].ComPagId;
            string res = ManejaCFDIs.GeneraComplementoDePago(complementoId, true, false);

            if (res == "000")
            {
                MessageBox.Show("El complemento de pago ha sido timbrado correctamente.", "Timbrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargaComplementos();
                SetGrid();
            }
            else
            {
                MessageBox.Show("Error al timbrar el complemento de pago. Código de error: " + res, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private bool ComplementoTimbrado()
        {
            if (_complementos[grdPagos.CurrentRow.Index].Timbrado)
            {
                MessageBox.Show("El complemento ya ha sido timbrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            return false;
        }

        private bool HayRenglonSeleccionado()
        {
            if (grdPagos.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un complemento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void cmdArchivos_Click(object sender, EventArgs e)
        {
            if (!HayRenglonSeleccionado())
            {
                return;
            }

            UtilsPDV.MuestraArchivosCFDi(_complementos[grdPagos.CurrentRow.Index].ComPagId, "CPG");
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            if (grdPagos.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un complemento para cancelar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (_complementos[grdPagos.CurrentRow.Index].Timbrado == false)
            {
                MessageBox.Show("No se puede eliminar un complemento que no ha sido timbrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_complementos[grdPagos.CurrentRow.Index].Cancelado)
            {
                MessageBox.Show("No se puede cancelar un complemento que ya ha sido cancelado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            long complementoId = _complementos[grdPagos.CurrentRow.Index].ComPagId;

            CfdiCancelar cfdiCancelar = new CfdiCancelar(complementoId, false, "CPG");
            cfdiCancelar.ShowDialog();
            if (cfdiCancelar.Cancelada)
            {
                CargaComplementos();
                SetGrid();
            }
        }
    }
}
