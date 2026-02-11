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

namespace ClinicaFB.PuntoDeVenta
{
    public partial class ConceptosListado : Form
    {

        private BindingList<ConceptoMovInv> _conceptos = null;

        public ConceptosListado()
        {
            InitializeComponent();
        }




        private void SetGrid()
        {
            grdConceptos.DataSource = null;

            grdConceptos.AllowUserToAddRows = false;
            grdConceptos.AllowUserToDeleteRows = false;

            grdConceptos.AutoGenerateColumns = false;
            grdConceptos.ReadOnly = true;
            grdConceptos.AllowUserToResizeColumns = false;
            grdConceptos.AllowUserToResizeRows = false;


            grdConceptos.ColumnHeadersDefaultCellStyle.Font = new Font(grdConceptos.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            grdConceptos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;



            grdConceptos.DataSource = _conceptos;

        }


        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ConceptosListado_Load(object sender, EventArgs e)
        {
            cboTipos.SelectedIndex = 0;
            CargaConceptos();
            SetGrid();
        }

        private void CargaConceptos()
        {

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.ConceptosSelect;
                string tipo = cboTipos.SelectedIndex == 0 ? "E" : "S";
                var res = db.Query<ConceptoMovInv>(sql, new {Tipo = tipo }).ToList();
                _conceptos = new BindingList<ConceptoMovInv>(res);

            }
        }

        private void AltasCambios(bool esAlta)
        {
            long conceptoId = 0;
            if (!esAlta)
            {
                if (grdConceptos.CurrentRow == null)
                {
                    MessageBox.Show("Debe seleccionar un concepto");
                    return;
                }
                conceptoId = _conceptos[grdConceptos.CurrentRow.Index].ConMovInvId;
            }
            string tipo = cboTipos.SelectedIndex == 0 ? "E" : "S";
            ConceptosAltasCambios conceptosAltasCambios = new ConceptosAltasCambios(esAlta,tipo, conceptoId);
            conceptosAltasCambios.ShowDialog();
            CargaConceptos();
            SetGrid();
        }

        private void cboTipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaConceptos();
        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            AltasCambios(true);
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            AltasCambios(false);
        }

        private void cboTipos_Validated(object sender, EventArgs e)
        {
            
        }

        private void cboTipos_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            CargaConceptos();
            SetGrid();
        }
    }
}
