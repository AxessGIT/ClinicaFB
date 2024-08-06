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
    public partial class ComprasListado : Form
    {
        BindingList<Documento> _compras = new BindingList<Documento>();
        public ComprasListado()
        {
            InitializeComponent();
        }

        private void ComprasListado_Load(object sender, EventArgs e)
        {
            dtpFechaInicial.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpFechaFinal.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            CargaCompras();
            SetGrid();
        }

        private void CargaCompras()
        {
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.ComprasSelect;
                var res = db.Query<Documento>(sql, new { FechaIni = dtpFechaInicial.Value, FechaFin = dtpFechaFinal.Value }).ToList();
                _compras = new BindingList<Documento>(res);
            }
        }

        private void SetGrid()
        {
            grdCompras.DataSource = null;



            grdCompras.AllowUserToAddRows = false;
            grdCompras.AllowUserToDeleteRows = false;


            grdCompras.AutoGenerateColumns = false;
            grdCompras.ReadOnly = true;
            grdCompras.AllowUserToResizeColumns = false;
            grdCompras.AllowUserToResizeRows = false;



            grdCompras.ColumnHeadersDefaultCellStyle.Font = new Font(grdCompras.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            grdCompras.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;



            grdCompras.DataSource = _compras;

        }

        private void AltasCambios(bool esAlta) {

            int compraId = 0;

            if (!esAlta)
                compraId = _compras[grdCompras.CurrentRow.Index].DocumentoId;

            
            ComprasAltasCambios comprasAltasCambios = new ComprasAltasCambios(esAlta,compraId);
            comprasAltasCambios.ShowDialog();
        
        }



        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            CargaCompras();
            SetGrid();
        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            AltasCambios(true);
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            if (grdCompras.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una compra para modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            AltasCambios(false);
        }

        private void grdCompras_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cmdModificar_Click(sender, e);
        }
    }
}
