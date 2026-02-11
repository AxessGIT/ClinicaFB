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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFB.PuntoDeVenta.Reportes
{
    public partial class rptExistencias : Form
    {
        private BindingList<Almacen> _almacenes;
        public rptExistencias()
        {
            InitializeComponent();
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void rptExistencias_Load(object sender, EventArgs e)
        {
            CargaAlmacenes();
        }

        private void CargaAlmacenes()
        {

            long almacenIdDefa = 0;

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.AlmacenesSelect();

                var res = db.Query<Almacen>(sql).ToList();
                _almacenes = new BindingList<Almacen>(res);

                foreach (var alma in res)
                {
                    if (alma.Defa)
                        almacenIdDefa = alma.AlmacenId;
                    
                }

                cboAlmacenes.DataSource = null;
                cboAlmacenes.DataSource = _almacenes;
                cboAlmacenes.ValueMember = "AlmacenId";
                cboAlmacenes.DisplayMember = "Nombre";
                cboAlmacenes.SelectedValue = almacenIdDefa;

            }


        }

        private async void cmdGenerar_Click(object sender, EventArgs e)
        {

            Splasher splasher = new Splasher("Generando reporte existencias");
            splasher.Show();

            long almacenId = (long)cboAlmacenes.SelectedValue;
            string almacenNombre = cboAlmacenes.Text;

            await Task.Run(() => GeneraReporte(almacenId, almacenNombre));

            splasher.Close();

        }

        private  async Task GeneraReporte(long almacenId, string almacenNombre)
        {
            Microsoft.Office.Interop.Excel.Application oExcel;

            oExcel = new Microsoft.Office.Interop.Excel.Application();
            oExcel.Workbooks.Add();


            int ren = 1;
            oExcel.Cells[ren, 1] = "Existencia de artículos";
            oExcel.Cells[ren, 1].Font.Bold = true;

            ren++;
            oExcel.Cells[ren, 1] = "Almacen";
            oExcel.Cells[ren, 2] = $"{almacenId} {almacenNombre}";

            ren++;
            oExcel.Cells[ren, 1] = "Fecha reporte";
            oExcel.Cells[ren, 2] = $"'{DateTime.Now.ToShortDateString()}";
            ren += 2;
            oExcel.Cells[ren, 1] = "Fecha inicial";
            oExcel.Cells[ren, 2] = $"'{dtpFechaInicial.Value.ToShortDateString()}";
            ren++;
            oExcel.Cells[ren, 1] = "Fecha final";
            oExcel.Cells[ren, 2] = $"'{dtpFechaFinal.Value.ToShortDateString()}";

            ren += 3;
            oExcel.Cells[ren, 1] = "Clave";
            oExcel.Cells[ren, 2] = "Descripción";
            oExcel.Cells[ren, 3] = "Inventario inicial";
            oExcel.Cells[ren, 4] = "Entradas";
            oExcel.Cells[ren, 5] = "Salidas";
            oExcel.Cells[ren, 6] = "Existencia final";
            oExcel.Cells[ren, 7] = "Ultimo Costo";
            oExcel.Cells[ren, 8] = "Valor Total";

            oExcel.Cells[ren, 1].Font.Bold = true;
            oExcel.Cells[ren, 2].Font.Bold = true;
            oExcel.Cells[ren, 3].Font.Bold = true;
            oExcel.Cells[ren, 4].Font.Bold = true;
            oExcel.Cells[ren, 5].Font.Bold = true;
            oExcel.Cells[ren, 6].Font.Bold = true;
            oExcel.Cells[ren, 7].Font.Bold = true;
            oExcel.Cells[ren, 8].Font.Bold = true;



            DateTime FechaIni = new DateTime(2020, 1, 1);
            DateTime FechaFin = dtpFechaFinal.Value;


            List<Articulo> articulos = new List<Articulo>();

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.ArticulosSelect();
                articulos = db.Query<Articulo>(sql).ToList();
                DateTime fechaFija = new DateTime(2000, 1, 1);

                foreach (var art in articulos)
                {

                    decimal costo = 0;
                    sql = Queries.ArticuloSelect();
                    Articulo articulo = db.Query<Articulo>(sql, new { art.ArticuloId }).FirstOrDefault();

                    if (articulo != null)
                        costo = articulo.Costo;


                    List<ArticuloMovimiento> movimientos = new List<ArticuloMovimiento>();
                    movimientos = await UtilsInv.GetArticuloMovimientos(art.ArticuloId, almacenId, FechaIni, FechaFin);

                    sql = Queries.InventarioInicialSelect;
                    InventarioInicial invIni = db.Query<InventarioInicial>(sql, new { art.ArticuloId, AlmacenId = almacenId }).FirstOrDefault();

                    decimal inventarioInicial = 0, entradas = 0, salidas = 0, existenciaInicial = 0, existenciaFinal = 0;

                    if (invIni != null)
                    {
                        movimientos.Add(new ArticuloMovimiento
                        {
                            ArtMovId = 0,
                            ArticuloId = art.ArticuloId,
                            AlmacenId = almacenId,
                            Tipo = "INI",
                            Fecha = invIni.Fecha,
                            DocumentoId = 0,
                            Cantidad = invIni.Cantidad
                        });


                    }


                    movimientos = movimientos.OrderBy(x => x.Fecha).ToList();

                    int i = 0;

                    while (i < movimientos.Count && movimientos[i].Fecha < dtpFechaInicial.Value)
                    {
                        if (movimientos[i].ConceptoTipo == "E" || movimientos[i].Tipo=="INI" )
                            inventarioInicial += movimientos[i].Cantidad;
                        else
                            inventarioInicial -= movimientos[i].Cantidad;
                        i++;
                    }

                    while (i < movimientos.Count && movimientos[i].Fecha < dtpFechaFinal.Value)
                    {
                        if (movimientos[i].ConceptoTipo == "E" || movimientos[i].Tipo == "INI")
                            entradas += movimientos[i].Cantidad;
                        else
                            salidas += movimientos[i].Cantidad;
                        i++;
                    }



                    existenciaInicial = inventarioInicial;

                    existenciaFinal = existenciaInicial + entradas - salidas;


                    if (chkSoloConExistencia.Checked && existenciaFinal==0)
                        continue;

                    ren++;
                    
                    oExcel.Cells[ren, 1] = $"'{art.Clave}";
                    oExcel.Cells[ren, 2] = art.Descripcion;
                    oExcel.Cells[ren, 3] = existenciaInicial;
                    oExcel.Cells[ren, 4] = entradas;
                    oExcel.Cells[ren, 5] = salidas;
                    oExcel.Cells[ren, 6] = existenciaFinal;
                    oExcel.Cells[ren, 7] = costo;
                    oExcel.Cells[ren, 8] = existenciaFinal * costo;
                }   
            }

            ren += 2;
            oExcel.Cells[ren, 1] = "Artículos totales";
            oExcel.Cells[ren, 2] = articulos.Count;

            oExcel.Range["A1", "H1"].EntireColumn.AutoFit();

            oExcel.Visible = true;



        }

    }
}
