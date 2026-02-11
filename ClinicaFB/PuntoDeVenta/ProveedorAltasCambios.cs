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
    public partial class ProveedorAltasCambios : Form
    {
        public int ProveedorId = 0;
        private bool _esAlta;
        public ProveedorAltasCambios(bool esAlta,int proveedorId)
        {
            InitializeComponent();
            _esAlta = esAlta;
            ProveedorId = proveedorId;
        }

        private void ProveedorAltasCambios_Load(object sender, EventArgs e)
        {
            if (_esAlta)
            {
                this.Text = "Alta de Proveedor";
            }
            else
            {
                this.Text = "Cambios de Proveedor";
                CargaProveedor();
            }
            

        }

        private void CargaProveedor()
        {
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.ProveedorSelect;
                Proveedor proveedor = db.Query<Proveedor>(sql, new { ProveedorId = ProveedorId }).FirstOrDefault();
                if (proveedor != null)
                {
                    txtRFC.Text = proveedor.RFC;
                    txtNombre.Text = proveedor.Nombre;
                }
            }


        }

        private bool GuardaProveedor()
        {
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Indique el nombre del proveedor");
                return false;
            }
            using (FbConnection db = General.GetDB())
            {
                string sql = "";
                if (_esAlta)
                {
                    sql = Queries.ProveedorInsert;
                }
                else
                {
                    sql = Queries.ProveedorUpdate;
                }
                Proveedor proveedor = new Proveedor();
                proveedor.ProveedorId = ProveedorId;
                proveedor.RFC = txtRFC.Text;
                proveedor.Nombre = txtNombre.Text;
                if (_esAlta)
                {
                    ProveedorId = db.ExecuteScalar<int>(sql, proveedor);
                }
                else
                {
                    db.Execute(sql, proveedor);
                }
            }
            return true;
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            if (GuardaProveedor())
                Close();

        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

