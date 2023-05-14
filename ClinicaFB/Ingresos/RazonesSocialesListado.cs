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

namespace ClinicaFB.Facturacion
{
    public partial class RazonesSocialesListado : Form
    {
        public int RazonId { get; set; }
        BindingList<RazonSocial> _razonesSociales = new BindingList<RazonSocial>();
        private bool _mostrarSeleccionar=false;

        public RazonesSocialesListado(bool mostrarSeleccionar=false)
        {
            _mostrarSeleccionar = mostrarSeleccionar;
            InitializeComponent();
        }

        private void RazonesSocialesListado_Load(object sender, EventArgs e)
        {
            if (_mostrarSeleccionar == false)
                cmdSeleccionar.Visible = false;

            CargaRazones();
            SetGrid();
        }


        private void CargaRazones()
        {

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.RazonesSocialesSelect();
                var res = db.Query<RazonSocial>(sql).ToList();
                _razonesSociales = new BindingList<RazonSocial>(res);

            }
        }



        private void SetGrid()
        {
            grdRazones.DataSource = null;



            grdRazones.AllowUserToAddRows = false;
            grdRazones.AllowUserToDeleteRows = false;


            grdRazones.AutoGenerateColumns = false;
            grdRazones.ReadOnly = true;
            grdRazones.AllowUserToResizeColumns = false;
            grdRazones.AllowUserToResizeRows = false;

            grdRazones.ColumnCount = 2;

            grdRazones.RowHeadersVisible = true;


            grdRazones.ColumnHeadersDefaultCellStyle.Font = new Font(grdRazones.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            grdRazones.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grdRazones.Columns[0].HeaderText = "RFC";

            grdRazones.Columns[0].DataPropertyName = "RFC";
            grdRazones.Columns[0].Width = 150;

            grdRazones.Columns[1].HeaderText = "Razon Social";
            grdRazones.Columns[1].DataPropertyName = "RazonSoc";
            grdRazones.Columns[1].Width = 300;

            grdRazones.DataSource = _razonesSociales;

        }



        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AltasCambios(bool esAlta)
        {
            int razonId = 0;
            if (!esAlta)
            {
                razonId = _razonesSociales[grdRazones.CurrentRow.Index].RazonSocialId;

            }

            RazSocAltasCambios razSocAltasCambios = new RazSocAltasCambios(esAlta, razonId);
            razSocAltasCambios.ShowDialog();

            CargaRazones();
            SetGrid();
                

        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            AltasCambios(true);
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            if (grdRazones.CurrentRow == null)
            {
                MessageBox.Show("Indique la razón social","Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            AltasCambios(false);
        }

        private void grdRazones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cmdModificar_Click(sender, e);
        }

        private void cmdSeleccionar_Click(object sender, EventArgs e)
        {
            if (grdRazones.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una razón social", "Confirme",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            RazonId = _razonesSociales[grdRazones.CurrentRow.Index].RazonSocialId;
            Close();
        }
    }
}
