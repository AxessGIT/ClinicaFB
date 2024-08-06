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
    public partial class ProveedoresListado : Form
    {
        private BindingList<Proveedor> _proveedores = new BindingList<Proveedor>();

        public ProveedoresListado()
        {
            InitializeComponent();
        }

        private void ProveedoresListado_Load(object sender, EventArgs e)
        {
            CargaProveedores();
            SetGrid();
        }

        private void CargaProveedores()
        {
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.ProveedoresSelect;
                var res = db.Query<Proveedor>(sql).ToList();

                _proveedores = new BindingList<Proveedor>(res);
            }
        }

        private void SetGrid()
        {
            grdProveedores.DataSource = null;



            grdProveedores.AllowUserToAddRows = false;
            grdProveedores.AllowUserToDeleteRows = false;


            grdProveedores.AutoGenerateColumns = false;
            grdProveedores.ReadOnly = true;
            grdProveedores.AllowUserToResizeColumns = false;
            grdProveedores.AllowUserToResizeRows = false;



            grdProveedores.ColumnHeadersDefaultCellStyle.Font = new Font(grdProveedores.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            grdProveedores.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;



            grdProveedores.DataSource = _proveedores;

        }

        private void AltasCambios(bool esAlta)
        {
            int proveedorId = 0;
            if (!esAlta)
            {
                proveedorId = _proveedores[grdProveedores.CurrentRow.Index].ProveedorId;
            }
            ProveedorAltasCambios frm = new ProveedorAltasCambios(esAlta, proveedorId);
            frm.ShowDialog();
            CargaProveedores();
            SetGrid();
        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            AltasCambios(true);
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            if (grdProveedores.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un proveedor", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            AltasCambios(false);
        }

        private void grdProveedores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cmdModificar_Click(sender, e);
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
