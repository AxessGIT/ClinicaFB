using ClinicaFB.Helpers;
using ClinicaFB.Modelo;
using Dapper;
using FirebirdSql.Data.FirebirdClient;
using Syncfusion.XlsIO;
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

namespace ClinicaFB.PuntoDeVenta.Reportes
{
    public partial class rptFacturas: Form
    {
        private BindingList<Almacen> _almacenes = new BindingList<Almacen>();

        public rptFacturas()
        {
            InitializeComponent();
        }

        private void rptFacturas_Load(object sender, EventArgs e)
        {
            CargaAlmacenes();
            dtpFechaInicial.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpFechaFinal.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
        }





        private void CargaAlmacenes()
        {

            long almacenIdDefa = 0;
            string nombreAlmacenDefa = "";

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.AlmacenesSelect();

                var res = db.Query<Almacen>(sql).ToList();

                foreach (var alma in res)
                {
                    if (alma.Defa)
                    {
                        almacenIdDefa = alma.AlmacenId;
                        nombreAlmacenDefa = alma.Nombre;
                        break;
                    }

                }
                _almacenes = new BindingList<Almacen>(res);



            }
            cboAlmacenes.DataSource = null;
            cboAlmacenes.DataSource = _almacenes;
            cboAlmacenes.ValueMember = "AlmacenId";
            cboAlmacenes.DisplayMember = "Nombre";
            cboAlmacenes.SelectedValue = almacenIdDefa;


        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void cmdGenerar_Click(object sender, EventArgs e)
        {
            long almacenId = (long)cboAlmacenes.SelectedValue;    


            if (almacenId == 0)
            {
                MessageBox.Show("Indique el almacen", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            await GeneraReporte(almacenId, dtpFechaInicial.Value, dtpFechaFinal.Value);


        }

        private async Task GeneraReporte(long almacenId, DateTime fechaIni, DateTime fechaFin)
        {
            await Task.Run(() => GeneraExcel(almacenId,fechaIni, fechaFin));

        }

        private void GeneraExcel(long almacenId, DateTime fechaIni, DateTime fechaFin)
        {
            SplashScreen.WindowsForms.Splasher splasher = new SplashScreen.WindowsForms.Splasher("Generando reporte...");
            splasher.Show();


            List<Venta> facturas = new List<Venta>(); ;


            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.FacturasReporteSelect;
                facturas =
                    db.Query<Venta>(sql,
                    new { AlmacenId= almacenId, FechaIni = fechaIni, FechaFin = fechaFin }).ToList();
            }


            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Xlsx;
            IWorkbook workbook = application.Workbooks.Create(1);
            IWorksheet worksheet = workbook.Worksheets[0];


            int renTitulos = 5;
            int ren = 6;

            worksheet.Range[1, 3].Text = "REPORTE DE FACTURAS";
            worksheet.Range[1, 3].CellStyle.Font.Bold = true;

            worksheet.Range[renTitulos, 1].Text = "Fecha";
            worksheet.Range[renTitulos, 2].Text = "Folio";
            worksheet.Range[renTitulos, 3].Text = "Cliente";
            worksheet.Range[renTitulos, 4].Text = "Subtotal";
            worksheet.Range[renTitulos, 5].Text = "I.V.A.";
            worksheet.Range[renTitulos, 6].Text = "Total";
            worksheet.Range[renTitulos, 7].Text = "Cancelada";

            worksheet.Range[renTitulos, 1, renTitulos, 7].CellStyle.Font.Bold = true;

            worksheet.Columns[0].ColumnWidth = 10;
            worksheet.Columns[1].ColumnWidth = 8;
            worksheet.Columns[2].ColumnWidth = 30;
            worksheet.Columns[3].ColumnWidth = 10;
            worksheet.Columns[4].ColumnWidth = 10;
            worksheet.Columns[5].ColumnWidth = 10;


            int facturasSinCancelar = 0, facturasCanceladas = 0;
            double subTotalSinCancelar = 0, subTotalCancelado = 0;
            double ivaSinCancelar = 0, ivaCancelado = 0;

            int folioConsecutivo =facturas.Count > 0 ? facturas.Min(x => x.FolioFac) : 0;
            int i = 0;

            foreach (var factura in facturas)
            {
                i++;

                if (i > 1 && factura.FolioFac > folioConsecutivo + 1)
                {

                    for (int j = folioConsecutivo + 1; j < factura.FolioFac; j++)
                    {
                        worksheet.Range[ren, 1].DateTime = factura.FechaFac;
                        worksheet.Range[ren, 2].Text = factura.SerieFac.Trim() + " " + j.ToString();
                        worksheet.Range[ren, 3].Text = "PUBLICO EN GENERAL";
                        worksheet.Range[ren, 4].Number = 0;
                        worksheet.Range[ren, 4].NumberFormat = "$###,###,##0.00";
                        worksheet.Range[ren, 5].Number = 0;
                        worksheet.Range[ren, 5].NumberFormat = "$###,###,##0.00";
                        worksheet.Range[ren, 6].Number = 0;
                        worksheet.Range[ren, 6].NumberFormat = "$###,###,##0.00";
                        worksheet.Range[ren, 7].Text = "*";
                        facturasCanceladas++;
                        ren++;
                    }

        
                 }
                worksheet.Range[ren, 1].DateTime = factura.FechaFac;
                worksheet.Range[ren, 2].Text = factura.SerieFac.Trim() + " " + factura.FolioFac.ToString();
                worksheet.Range[ren, 3].Text = factura.ClienteNom;
                worksheet.Range[ren, 4].Number = (double)factura.Subtotal;
                worksheet.Range[ren, 4].NumberFormat = "$###,###,##0.00";
                worksheet.Range[ren, 5].Number = (double)factura.IVA;
                worksheet.Range[ren, 5].NumberFormat = "$###,###,##0.00";
                worksheet.Range[ren, 6].Number = (double)factura.Total;
                worksheet.Range[ren, 6].NumberFormat = "$###,###,##0.00";
                worksheet.Range[ren, 7].Text = factura.Cancelada ? "*" : "";

                

                if (factura.Cancelada)
                {
                    facturasCanceladas++;
                    subTotalCancelado += (double)factura.Subtotal;
                    ivaCancelado += (double)factura.IVA;
                }
                else
                {
                    facturasSinCancelar++;
                    subTotalSinCancelar += (double)factura.Subtotal;
                    ivaSinCancelar += (double)factura.IVA;

                }


                ren++;
                folioConsecutivo = factura.FolioFac;



            }
            ren += 5;
            worksheet.Range[ren, 1].Text = "TOTAL GENERAL";
            worksheet.Range[ren, 1].CellStyle.Font.Bold = true;

            double totalCancelado = subTotalCancelado + ivaCancelado;
            double totalSinCancelar = subTotalSinCancelar + ivaSinCancelar;


            worksheet.Range[ren, 3].Text = $"Facturas sin cancelar ({facturasSinCancelar})";
            worksheet.Range[ren, 4].Number = (double)subTotalSinCancelar;
            worksheet.Range[ren, 4].NumberFormat = "$###,###,##0.00";
            worksheet.Range[ren, 5].Number = (double)ivaSinCancelar;
            worksheet.Range[ren, 5].NumberFormat = "$###,###,##0.00";
            worksheet.Range[ren, 6].Number = (double)totalSinCancelar;
            worksheet.Range[ren, 6].NumberFormat = "$###,###,##0.00";

            ren++;

            worksheet.Range[ren, 3].Text = $"Facturas canceladas ({facturasCanceladas})";
            worksheet.Range[ren, 4].Number = (double)subTotalCancelado;
            worksheet.Range[ren, 4].NumberFormat = "$###,###,##0.00";
            worksheet.Range[ren, 5].Number = (double)ivaCancelado;
            worksheet.Range[ren, 5].NumberFormat = "$###,###,##0.00";
            worksheet.Range[ren, 6].Number = (double)totalCancelado;
            worksheet.Range[ren, 6].NumberFormat = "$###,###,##0.00";


            ren++;
            worksheet.Range[ren, 3].Text = $"Total facturas ({facturasSinCancelar + facturasCanceladas})";

            worksheet.Range[ren, 4].Number = (double)subTotalCancelado + subTotalSinCancelar;
            worksheet.Range[ren, 4].NumberFormat = "$###,###,##0.00";
            worksheet.Range[ren, 5].Number = (double)ivaCancelado + ivaSinCancelar;
            worksheet.Range[ren, 5].NumberFormat = "$###,###,##0.00";
            worksheet.Range[ren, 6].Number = (double)totalCancelado + totalSinCancelar;
            worksheet.Range[ren, 6].NumberFormat = "$###,###,##0.00";




            string tempfile = "rptFac" + Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ".xlsx";
            tempfile = Path.GetTempPath() + "\\" + tempfile;
            workbook.SaveAs(tempfile);

            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo = new System.Diagnostics.ProcessStartInfo(tempfile)
            {
                UseShellExecute = true
            };

            excelEngine.Dispose();
            process.Start();
            splasher.Close();
            splasher = null;

        }

    }
}
