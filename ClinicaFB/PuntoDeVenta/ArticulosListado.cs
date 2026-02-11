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

        private void FiltraArticulos()
        {
            string filtro = $"%{txtBuscar.Text.Trim().ToUpper()}%";
            if (string.IsNullOrEmpty(filtro))
            {
                CargaArticulos();
                return;
            }
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.ArticulosSelectxClaveDescripcionCodigo;
                var res = db.Query<Articulo>(sql, new { Filtro= filtro }).ToList();
                _articulos = new BindingList<Articulo>(res);
                SetGrid();
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

        private void cmdImportar_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show(
                "¿Desea sustituir el catálogo actual con los artículos importados \n (si presiona NO, se agregarán a los existentes)?",
                "Confirme",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);
            if (res == DialogResult.Cancel)
            {
                return;
            }
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos CSV|*.csv";
            openFileDialog.Title = "Seleccione el archivo a importar";
            openFileDialog.ShowDialog();
            if (string.IsNullOrEmpty(openFileDialog.FileName))
            {
                return;
            }
            string fileName = openFileDialog.FileName;
            List<Articulo> articulos = General.GetArticulosFromCSV(fileName);
            if (res == DialogResult.Yes)
            {
                using (FbConnection db = General.GetDB())
                {
                    string sql = Queries.ArticulosInit;
                    db.Execute(sql);
                }
            }
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.ArticuloInsert();
                foreach (Articulo articulo in articulos)
                {
                    articulo.CveProSer = "51241200";
                    articulo.CveUni = "H87";
                    articulo.UDM = "PIEZA";
                    articulo.Moneda = "MXN";

                    articulo.Precio2 = 0;
                    articulo.Precio3 = 0;
                    articulo.Precio4 = 0;
                    articulo.Precio5 = 0;


                    articulo.Clave = string.IsNullOrEmpty(articulo.Clave) ? articulo.CodigoBarras : articulo.Clave;
                    db.Execute(sql, articulo);
                }
            }
            MessageBox.Show("Artículos importados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargaArticulos();
            SetGrid();

        }

        private void cmdKardex_Click(object sender, EventArgs e)
        {

        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {

        }

        
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            FiltraArticulos();
        }

        private void cmdExistencias_Click(object sender, EventArgs e)
        {
            if (grdArticulos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un artículo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ArticuloExistencias kardex = new ArticuloExistencias((int)_articulos[grdArticulos.CurrentRow.Index].ArticuloId);
            kardex.ShowDialog();

        }
    }
}
