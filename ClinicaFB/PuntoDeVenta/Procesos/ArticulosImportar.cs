using ClinicaFB.Helpers;
using ClinicaFB.Modelo;
using Dapper;
using FirebirdSql.Data.FirebirdClient;
using SplashScreen.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFB.PuntoDeVenta.Procesos
{
    public partial class ArticulosImportar : Form
    {
        public ArticulosImportar()
        {
            InitializeComponent();
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ArticulosImportar_Load(object sender, EventArgs e)
        {
            string escritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            txtCatalogo.Text = escritorio + @"\Lista de precios FARMADERMA.xls";
            txtClavesEImpuestos.Text = escritorio + @"\ArticulosFM.xls";
            txtExistenciasFD.Text = escritorio + @"\INVENTARIO FARMADERMA.xls";
            txtExistenciasAM.Text = escritorio + @"\INVENTARIO AMAZON.xls";
        }

        private void cmdBuscarCatalogo_Click(object sender, EventArgs e)
        {

            SeleccionarArchivo(ref txtCatalogo);
        }

        private void cmdBuscarClavesEImpuestos_Click(object sender, EventArgs e)
        {
            SeleccionarArchivo(ref txtClavesEImpuestos);
        }

        private void SeleccionarArchivo(ref TextBox txtControl)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de Excel|*.xls;*.xlsx";
            openFileDialog.Title = "Seleccione el archivo de Excel";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtControl.Text = openFileDialog.FileName;
            }
        }

        private void cmdProcesos_Click(object sender, EventArgs e)
        {
            

            if (MessageBox.Show("¿Desea importar los artículos?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            Splasher splashScreen = new Splasher("Importando artículos");
            splashScreen.Show();
            ImportArticulos();
            splashScreen.Close();
            MessageBox.Show("Proceso terminado", "Importación de artículos", MessageBoxButtons.OK, MessageBoxIcon.Information); 
        }

       private async void ImportArticulos()
        {
            string sql = "";
            Microsoft.Office.Interop.Excel.Application oExcel;

            oExcel = new Microsoft.Office.Interop.Excel.Application();

            Microsoft.Office.Interop.Excel.Range oRango;
            oExcel.Workbooks.Open(txtExistenciasFD.Text);
            oRango = oExcel.ActiveSheet.Range("A5:A10000").CurrentRegion;


            using (FbConnection db = General.GetDB())
            {
                await db.OpenAsync();
                using(var transaction = db.BeginTransaction())
                {
                    try
                    {
                        sql = Queries.ArticulosSelect();
                        List<Articulo> articulos = db.Query<Articulo>(sql).ToList();


                        foreach (Articulo art in articulos)
                        {

                            var celda = oRango.Find(art.Descripcion);
                            if (celda == null)
                                continue;

                            int ren = celda.Row;

                            decimal existencia = (decimal)oExcel.Cells[ren, 7].Value;

                            await UtilsInv.ActualizaExistencia((int)art.ArticuloId, 1, db, transaction, existencia);

                        }
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                    transaction.Commit();
                }



                }

                oExcel.ActiveWorkbook.Close(false);           


            oExcel.Quit();
            oExcel = null;

        }

        private void cmdBuscarExistenciasFD_Click(object sender, EventArgs e)
        {

        }
    }
}
