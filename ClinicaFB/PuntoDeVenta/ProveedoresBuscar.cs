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
    public partial class ProveedoresBuscar : Form
    {
        public int ProveedorId { get; set; } = 0;
        private BindingList<Proveedor> _proveedores = new BindingList<Proveedor>();
        public ProveedoresBuscar()
        {
            InitializeComponent();
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            ProveedorId = 0;
            Close();
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

        private void ProveedoresBuscar_Load(object sender, EventArgs e)
        {
            SetGrid();

        }

        private void BuscaProveedores()
        {
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.ProveedorBuscar;
                string buscar = $"%{txtBuscar.Text.Trim().ToUpper()}%";
                var res = db.Query<Proveedor>(sql, new {Buscar = buscar }).ToList();
                _proveedores = new BindingList<Proveedor>(res);
            }
            SetGrid();
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            if (grdProveedores.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un proveedor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ProveedorId = _proveedores[grdProveedores.CurrentRow.Index].ProveedorId;
            Close();
            
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBuscar.Text.Trim()))
            {
                MessageBox.Show("Indique el texto a buscar", "Confirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            BuscaProveedores();
        }
    }
}
