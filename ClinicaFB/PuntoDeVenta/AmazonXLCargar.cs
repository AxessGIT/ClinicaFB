using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFB.Helpers;
using ClinicaFB.Modelo;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.Office.Interop.Excel;
using Queries = ClinicaFB.Helpers.Queries;
using Dapper;


namespace ClinicaFB.PuntoDeVenta
{
    public partial class AmazonXLCargar : Form
    {
        public BindingList<AmazonXLSkus> amazonXLSkus;

        public AmazonXLCargar()
        {
            InitializeComponent();
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AmazonXLCargar_Load(object sender, EventArgs e)
        {
            SetGrid();
        }

        private async void cmdCargar_Click(object sender, EventArgs e)
        {
            int renIni, renFin;
            renIni = (int)spnRenglonInicial.Value;
            renFin = (int)spnRenglonFinal.Value;
            if (renFin < renIni)
            {
                MessageBox.Show("El renglón final no puede ser menor al inicial.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Archivos Excel|*.xls;*.xlsx;*.xlsm";

            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            pbAvance.Value = 0;
            pbAvance.Visible = true;

            txtArchivoXLS.Text = dlg.FileName;

            await Task.Run(() => CargarArchivo(dlg.FileName, renIni, renFin));
            pbAvance.Visible = false;
            SetGrid();




        }


        private async Task CargarArchivo(string archivo, int renIni, int renFin)
        {
            // Simular una operación asincrónica que tarda 2 segundos
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Workbook workbook = excelApp.Workbooks.Open(archivo);
            Worksheet worksheet = workbook.Sheets[1];

            amazonXLSkus = new BindingList<AmazonXLSkus>();
            string sku = "";
            string descripcion = "";

                for (int i = renIni; i <= renFin; i++)
                {


                int porcentaje = (int)((i / (float)renFin) * 100);

                // Verificar que el formulario sigue válido antes de Invoke
                if (this.IsHandleCreated && !this.IsDisposed)
                {
                    try
                    {
                        this.Invoke(new System.Action(() =>
                        {
                            if (!pbAvance.IsDisposed)
                            {
                                pbAvance.Value = porcentaje;
                            }
                        }));
                    }
                    catch (ObjectDisposedException)
                    {
                        // El formulario ya ha sido cerrado, no hacer nada
                    }
                }



                Microsoft.Office.Interop.Excel.Range cellSKU = worksheet.Cells[i, 1];

                if (cellSKU != null && cellSKU.Value2 != null)
                    sku = cellSKU.Value2.ToString().ToUpper().Trim();

                Microsoft.Office.Interop.Excel.Range cellDescripcion = worksheet.Cells[i, 2];

                if (cellDescripcion != null && cellDescripcion.Value2 != null)
                    descripcion = cellDescripcion.Value2.ToString().Trim();

                if (amazonXLSkus.FirstOrDefault(s => s.SKU == sku) == null)
                {
                    amazonXLSkus.Add(new AmazonXLSkus()
                    {
                        SKU = sku,
                        Descripcion = descripcion
                    });
                }

            }

            workbook.Close(false);
            excelApp.Quit();

            using (FbConnection db = General.GetDB())
            {


                string sql = Queries.ArticuloSelectXSKU;
                var itemsAEliminar = new List<AmazonXLSkus>();
    
                foreach (var amazonSKU in amazonXLSkus)
                {
                    Articulo articulo = db.Query<Articulo>(sql, new { amazonSKU.SKU }).FirstOrDefault();
                    if (articulo != null)
                    {
                        itemsAEliminar.Add(amazonSKU);
                    }
                }
    
                // Ahora eliminar los elementos fuera del foreach
                foreach (var item in itemsAEliminar)
                {
                    amazonXLSkus.Remove(item);
                }
            }


        }

        private void SetGrid()
        {
            grdArticulos.DataSource = null;



            grdArticulos.AllowUserToAddRows = false;
            grdArticulos.AllowUserToDeleteRows = false;



            grdArticulos.AutoGenerateColumns = false;
            grdArticulos.ReadOnly = false;
            grdArticulos.AllowUserToResizeColumns = false;
            grdArticulos.AllowUserToResizeRows = false;



            grdArticulos.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(grdArticulos.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            grdArticulos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdArticulos.DataSource = amazonXLSkus;


        }

        private void grdArticulos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string codigoBarras = amazonXLSkus[e.RowIndex].CodigoBarras; //grdArticulos.Rows[e.RowIndex].Cells["colClave"].Value.ToString();
            if (string.IsNullOrEmpty(codigoBarras))
            {
                grdArticulos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
            }

        }

        private void grdArticulos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string codigoBarras = amazonXLSkus[e.RowIndex].CodigoBarras;

            if (string.IsNullOrEmpty(codigoBarras))
            {
                return;
            }

            string sql = Queries.ArticuloSelectxClave();
            using (FbConnection db = General.GetDB())
            {
                Articulo art = db.Query<Articulo>(sql, new { Clave = codigoBarras }).FirstOrDefault();
                if (art == null)
                {
                    MessageBox.Show("Esa clave no existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                amazonXLSkus[e.RowIndex].ArticuloId = (int)art.ArticuloId;
                amazonXLSkus[e.RowIndex].Descripcion = art.Descripcion;
                amazonXLSkus[e.RowIndex].CodigoBarras = codigoBarras;
                SetGrid();
            }

        }

        private void grdArticulos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                string codigoBarras = "";
                string des = "";
                if (grdArticulos.CurrentRow == null)
                    return;
                ArticulosBuscar articulosBuscar = new ArticulosBuscar();
                articulosBuscar.ShowDialog();
                if (articulosBuscar.ArticuloId != 0)
                {
                    using (FbConnection db = General.GetDB())
                    {
                        string sql = Queries.ArticuloSelect();
                        Articulo art = db.Query<Articulo>(sql, new { ArticuloId = articulosBuscar.ArticuloId }).FirstOrDefault();
                        if (art != null)
                        {
                            codigoBarras = art.Clave;
                            des = art.Descripcion;
                        }
                        else {
                            return;
                        }
                    }


                }
                amazonXLSkus[grdArticulos.CurrentRow.Index].ArticuloId = articulosBuscar.ArticuloId;
                amazonXLSkus[grdArticulos.CurrentRow.Index].CodigoBarras = codigoBarras;
                amazonXLSkus[grdArticulos.CurrentRow.Index].Descripcion = des;
                SetGrid();
                int ren = grdArticulos.CurrentRow.Index;
                ren++;
                if (ren >= grdArticulos.RowCount)
                    ren = grdArticulos.RowCount - 1;

                grdArticulos.CurrentCell = grdArticulos.Rows[ren].Cells[1];

            }
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            var articulosSinSKU = amazonXLSkus.Where(a =>  string.IsNullOrEmpty(a.CodigoBarras)).ToList();
            if (articulosSinSKU.Count > 0)
            {
                DialogResult sino = MessageBox.Show("Hay artículos sin código de barras asignado. Solo se agregarán los artículos con códigos registrado en el catálogo ¿Desea continuar?", "Aviso",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (sino == DialogResult.No)
                    return;
            }
            string articulosConCodigoErroneo = string.Empty;
            foreach (var sku in amazonXLSkus)
            {
                if (string.IsNullOrEmpty(sku.CodigoBarras) || sku.ArticuloId == 0)
                {
                    continue;
                }

                string sql = Queries.ArticuloSelectxCodigo;

                using (FbConnection db = General.GetDB())
                {
                    Articulo art = db.Query<Articulo>(sql, new {sku.CodigoBarras}).FirstOrDefault();
                    if (art == null)
                    {
                        articulosConCodigoErroneo += $"SKU: {sku.SKU} Descripción: {sku.Descripcion}\n";
                    }
                }

            }
            if (!string.IsNullOrEmpty(articulosConCodigoErroneo))
            {
                MessageBox.Show("Los siguientes artículos tienen código de barras erróneo o no existen en el catálogo:\n" + articulosConCodigoErroneo,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Guardar los Sku en la base de datos
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.ArticuloSKUUpdate;
                foreach (var sku in amazonXLSkus)
                {
                    if (string.IsNullOrEmpty(sku.SKU) || sku.ArticuloId==0)
                    {
                        continue;
                    }
                    db.Execute(sql, new{sku.ArticuloId,sku.SKU});
                }
            }
        }
    }
}
