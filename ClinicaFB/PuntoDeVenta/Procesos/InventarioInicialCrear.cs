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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFB.PuntoDeVenta.Procesos
{
    public partial class InventarioInicialCrear: Form
    {
        public InventarioInicialCrear()
        {
            InitializeComponent();
        }

        private void InventarioInicialCrear_Load(object sender, EventArgs e)
        {

        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }


        private async void CrearInventarioInicial()
        {

            Microsoft.Office.Interop.Excel.Application oExcel;

            oExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Range oRango;


            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.ArticulosSelect();
                List<Articulo> articulos = db.Query<Articulo>(sql).ToList();

                sql = Queries.InventarioInicialInsert;
                if (string.IsNullOrEmpty(txtExistenciasFD.Text) == false)
                {
                    oExcel.Workbooks.Open(txtExistenciasFD.Text);
                    oRango = oExcel.ActiveSheet.Range("A5:A10000").CurrentRegion;

                    foreach (Articulo art in articulos)
                    {

                        var celda = oRango.Find(art.Descripcion);
                        if (celda == null)
                            continue;

                        int ren = celda.Row;

                        decimal existencia = (decimal)oExcel.Cells[ren, 7].Value;

                        InventarioInicial inv = new InventarioInicial();
                        inv.ArticuloId = (int)art.ArticuloId;
                        inv.AlmacenId = 1;
                        inv.Cantidad = existencia;
                        inv.Fecha = new DateTime(2025, 2, 1);


                        await db.ExecuteAsync(sql, inv);




                    }

                    oExcel.ActiveWorkbook.Close(false);
                }


                if (string.IsNullOrEmpty(txtExistenciasAM.Text) == false)
                {

                    oExcel.Workbooks.Open(txtExistenciasAM.Text);
                    oRango = oExcel.ActiveSheet.Range("A6:A10000").CurrentRegion;

                    foreach (Articulo art in articulos)
                    {
                        var celda = oRango.Find(art.Descripcion);
                        if (celda == null)
                            continue;


                        int ren = celda.Row;

                        decimal existencia = (decimal)oExcel.Cells[ren, 7].Value;

                        InventarioInicial inv = new InventarioInicial();
                        inv.ArticuloId = (int)art.ArticuloId;
                        inv.AlmacenId = 2;
                        inv.Cantidad = existencia;
                        inv.Fecha = new DateTime(2025, 2, 1);


                        await db.ExecuteAsync(sql, inv);


                    }
                    oExcel.ActiveWorkbook.Close(false);
                }




            }


            oExcel.Quit();
            oExcel = null;

        }


        private void cmdAjustar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtExistenciasFD.Text) && string.IsNullOrEmpty(txtExistenciasAM.Text))
            {
                MessageBox.Show("Debe seleccionar al menos un archivo de existencias", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtExistenciasFD.Text) == false && File.Exists(txtExistenciasFD.Text) == false)
            {
                MessageBox.Show("No existe el archivo de existencias de Farmaderma", "Confirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(txtExistenciasAM.Text) == false && File.Exists(txtExistenciasAM.Text) == false)
            {
                MessageBox.Show("No existe el archivo de existencias de Amazon", "Confirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Splasher splasher = new Splasher("Ajustando existencias");
            CrearInventarioInicial();
            splasher.Close();
            MessageBox.Show("Existencias ajustadas", "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void cmdBuscarExistenciasFD_Click(object sender, EventArgs e)
        {
            SeleccionarArchivo(ref txtExistenciasFD);

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

        private void cmdBuscarExistenciasAM_Click(object sender, EventArgs e)
        {
            SeleccionarArchivo(ref txtExistenciasAM);
        }
    }
}
