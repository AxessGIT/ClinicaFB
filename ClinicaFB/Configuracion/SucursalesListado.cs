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

namespace ClinicaFB.Configuracion
{
    public partial class SucursalesListado : Form
    {
        private BindingList<Sucursal> _sucursales = new BindingList<Sucursal>();
        public SucursalesListado()
        {
            InitializeComponent();
        }

        private void SucursalesListado_Load(object sender, EventArgs e)
        {

            CargaSucursales();
            SetGrid();
        }



        private void AltasCambios(bool esAlta)
        {

            int id = 0;

            if (esAlta == false)
            {
                id = (int)_sucursales[grdSucursales.CurrentRow.Index].SucursalId;
            }

            SucursalesAltasCambios sucursalesAltasCambios = new SucursalesAltasCambios(esAlta,id);
            sucursalesAltasCambios.ShowDialog();
            

            CargaSucursales();
            SetGrid();


        }



        private void CargaSucursales()
        {

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.SucursalesSelect();
                var res = db.Query<Sucursal>(sql).ToList();
                _sucursales = new BindingList<Sucursal>(res);

            }


        }



        private void SetGrid()
        {
            grdSucursales.DataSource = null;



            grdSucursales.AllowUserToAddRows = false;
            grdSucursales.AllowUserToDeleteRows = false;


            grdSucursales.AutoGenerateColumns = false;
            grdSucursales.ReadOnly = true;
            grdSucursales.AllowUserToResizeColumns = false;
            grdSucursales.AllowUserToResizeRows = false;

            grdSucursales.ColumnCount = 1;

            grdSucursales.RowHeadersVisible = true;


            grdSucursales.ColumnHeadersDefaultCellStyle.Font = new Font(grdSucursales.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            grdSucursales.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grdSucursales.Columns[0].HeaderText = "Sucursal";

            grdSucursales.Columns[0].DataPropertyName = "Nombre";
            grdSucursales.Columns[0].Width = 200;
            grdSucursales.DataSource = _sucursales;

        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            AltasCambios(true);
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            if (grdSucursales.CurrentRow == null)
            {
                MessageBox.Show("Seleccione la sucursal a modificar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            AltasCambios(false);
        }

        private void grdSucursales_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cmdModificar_Click(sender, e);
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
