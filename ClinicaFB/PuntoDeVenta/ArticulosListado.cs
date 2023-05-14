using ClinicaFB.Helpers;
using ClinicaFB.Modelo;
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
using Dapper;

namespace ClinicaFB.PuntoDeVenta
{
    public partial class ArticulosListado : Form
    {
        private BindingList<Articulo> _articulos = null;

        public ArticulosListado()
        {
            InitializeComponent();
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CargaArticulos()
        {

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.ArticulosSelect();
                var res = db.Query<Articulo>(sql).ToList();

                _articulos = new BindingList<Articulo>(res);

            }
        }

        private void SetGrid()
        {
            grdArticulos.DataSource = null;



            grdArticulos.AllowUserToAddRows = false;
            grdArticulos.AllowUserToDeleteRows = false;


            grdArticulos.AutoGenerateColumns = false;
            grdArticulos.ReadOnly = true;
            grdArticulos.AllowUserToResizeColumns = false;
            grdArticulos.AllowUserToResizeRows = false;

            grdArticulos.ColumnCount = 3;

            grdArticulos.RowHeadersVisible = true;


            grdArticulos.ColumnHeadersDefaultCellStyle.Font = new Font(grdArticulos.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            grdArticulos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grdArticulos.Columns[0].HeaderText = "Clave";

            grdArticulos.Columns[0].DataPropertyName = "Clave";
            grdArticulos.Columns[0].Width = 200;

            grdArticulos.Columns[1].HeaderText = "Descripción";
            grdArticulos.Columns[1].DataPropertyName = "Descripcion";
            grdArticulos.Columns[1].Width = 200;

            grdArticulos.Columns[2].HeaderText = "Precio";
            grdArticulos.Columns[2].DataPropertyName = "Precio1";
            grdArticulos.Columns[2].Width = 100;
            grdArticulos.Columns[2].DefaultCellStyle.Format = "c";

            grdArticulos.DataSource = _articulos;

        }

        

        private void ArticulosListado_Load(object sender, EventArgs e)
        {
            CargaArticulos();
            SetGrid();
        }

        private void AltasCambios(bool esAlta)
        {
            int articuloId = 0;
            if (esAlta==false)
            {
                if (grdArticulos.CurrentRow == null)
                {
                    MessageBox.Show(
                        "Indique el artículo a modificar",
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }
                articuloId = (int)_articulos[grdArticulos.CurrentRow.Index].ArticuloId;

            }
            ArticuloAltaCambio articuloAltaCambio = new  ArticuloAltaCambio(esAlta, articuloId);
            articuloAltaCambio.ShowDialog();
            CargaArticulos();
            SetGrid();
        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            AltasCambios(true);
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            if (grdArticulos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un artículo","Aviso",MessageBoxButtons.OK, MessageBoxIcon.Information);
                return ;
            }
            AltasCambios(false);
        }

        private void grdArticulos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cmdModificar_Click(sender, e);
        }
    }
}
