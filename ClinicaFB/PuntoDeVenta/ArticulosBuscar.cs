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
    public partial class ArticulosBuscar : Form
    {
        public int ArticuloId { get; set; }
        private BindingList<Articulo> _articulos = null;
        private string _inicial = "";

        public ArticulosBuscar()
        {
            InitializeComponent();
        }

        public ArticulosBuscar(string inicial)
        {
            InitializeComponent();
            _inicial= inicial;
        }


        private void cmdCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ArticulosBuscar_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_inicial))
            {
                txtBuscar.Text = _inicial;
                CargaArticulos();
                SetGrid();
            }

        }


        private void CargaArticulos()
        {
            string buscar = "%"+ txtBuscar.Text.Trim()+"%";
            buscar = buscar.ToUpper();



            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.ArticulosSelectBuscar();
                var res = db.Query<Articulo>(sql, new {Buscar=buscar}).ToList();

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
            grdArticulos.Columns[0].Width = 120;

            grdArticulos.Columns[1].HeaderText = "Descripción";
            grdArticulos.Columns[1].DataPropertyName = "Descripcion";
            grdArticulos.Columns[1].Width = 200;

            grdArticulos.Columns[2].HeaderText = "Precio";
            grdArticulos.Columns[2].DataPropertyName = "Precio1";
            grdArticulos.Columns[2].Width = 100;
            grdArticulos.Columns[2].DefaultCellStyle.Format = "c";

            grdArticulos.DataSource = _articulos;

        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBuscar.Text))
            {
                MessageBox.Show("Indique el artículo a buscar","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            CargaArticulos();
            SetGrid();

        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            if (grdArticulos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione el artículo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ArticuloId =(int) _articulos[grdArticulos.CurrentRow.Index].ArticuloId;
            Close();
        }

        private void grdArticulos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cmdAceptar_Click(sender, e);
        }
    }
}
