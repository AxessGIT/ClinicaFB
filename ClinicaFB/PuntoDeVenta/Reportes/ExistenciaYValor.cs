using ClinicaFB.Helpers;
using ClinicaFB.Modelo;
using Dapper;
using FirebirdSql.Data.FirebirdClient;
using SplashScreen.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
namespace ClinicaFB.PuntoDeVenta.Reportes
{
    public partial class ExistenciaYValor : Form
    {

        private BindingList<Almacen> _almacenes;

        public ExistenciaYValor()
        {
            InitializeComponent();
        }

        private void rptExistenciaYValor_Load(object sender, EventArgs e)
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

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void cmdGenerar_Click(object sender, EventArgs e)
        {
            if (cboAlmacenes.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un almacén.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            long sucursalId = Properties.Settings.Default.SucursalId;
            long almacenId = ((Almacen)cboAlmacenes.SelectedItem).AlmacenId;
            string almacenNombre = ((Almacen)cboAlmacenes.SelectedItem).Nombre;

            await GeneraReporteExistencias();
        }
        public async Task GeneraReporteExistencias()
        {
            // 1. Preparar Interfaz
            pbAvance.Value = 0;
            pbAvance.Visible = true;
            lblStatus.Visible = true;
            lblStatus.Text = "Calculando existencias y valores...";
            cmdGenerar.Enabled = false;
            Stopwatch sw = new Stopwatch();

            // Timer para actualizar el contador de segundos en la UI
            System.Windows.Forms.Timer uiTimer = new System.Windows.Forms.Timer();
            uiTimer.Interval = 1000;
            uiTimer.Tick += (s, e) => {
                lblStatus.Text = $"Procesando... Tiempo: {sw.Elapsed.Minutes:00}:{sw.Elapsed.Seconds:00}s";
            };

            DataTable dt = null;

            try
            {
                // Parámetros de la interfaz
                DateTime fechaCorte = dtpFecha.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
                long almacenId = (long)cboAlmacenes.SelectedValue;

                sw.Start();
                uiTimer.Start();

                await Task.Run(() =>
                {
                    dt = new DataTable();

                    // 2. Consulta a Firebird (SP_REPORTE_EXISTENCIAS)
                    using (FbConnection db = General.GetDB())
                    {
                        string sql = "SELECT CLAVE, NOMBRE_ARTICULO, EXISTENCIA, COSTO_UNIT, VALOR_TOTAL " +
                                     "FROM SP_REPORTE_EXISTENCIAS(@FECHA, @ALM)";

                        FbCommand c = new FbCommand(sql, db);
                        c.Parameters.Add("@FECHA", FbDbType.TimeStamp).Value = fechaCorte;
                        c.Parameters.Add("@ALM", FbDbType.BigInt).Value = almacenId;

                        FbDataAdapter a = new FbDataAdapter(c);
                        a.Fill(dt);
                    }

                    if (dt.Rows.Count == 0) return;

                    // 3. Iniciar Excel con optimización de refresco de pantalla
                    Excel.Application xlApp = new Excel.Application();
                    xlApp.ScreenUpdating = false;
                    Excel.Workbook xlWorkBook = xlApp.Workbooks.Add(Type.Missing);
                    Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                    try
                    {
                        // Título Superior
                        xlWorkSheet.Cells[1, 1] = "REPORTE DE EXISTENCIAS Y VALORIZACIÓN";
                        xlWorkSheet.Cells[2, 1] = $"Fecha de Corte: {fechaCorte.ToShortDateString()} | Almacén: {cboAlmacenes.Text}";

                        Excel.Range titleRange = xlWorkSheet.Range["A1", "E1"];
                        titleRange.Merge();
                        titleRange.Font.Size = 16;
                        titleRange.Font.Bold = true;

                        // Encabezados de Columna
                        string[] headers = { "Clave", "Descripción del Artículo", "Existencia", "Costo Prom.", "Valor Total" };
                        for (int i = 0; i < headers.Length; i++)
                        {
                            xlWorkSheet.Cells[4, i + 1] = headers[i];
                            Excel.Range cell = xlWorkSheet.Cells[4, i + 1];
                            cell.Font.Bold = true;
                            cell.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(44, 62, 80));
                            cell.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                            cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                        }

                        int rowIdx = 5;
                        int totalRows = dt.Rows.Count;
                        int processedRows = 0;
                        double sumaValorTotal = 0;

                        foreach (DataRow row in dt.Rows)
                        {
                            xlWorkSheet.Cells[rowIdx, 1] = $"'{row["CLAVE"]}";
                            xlWorkSheet.Cells[rowIdx, 2] = row["NOMBRE_ARTICULO"];
                            xlWorkSheet.Cells[rowIdx, 3] = row["EXISTENCIA"];
                            xlWorkSheet.Cells[rowIdx, 4] = row["COSTO_UNIT"];
                            xlWorkSheet.Cells[rowIdx, 5] = row["VALOR_TOTAL"];

                            sumaValorTotal += Convert.ToDouble(row["VALOR_TOTAL"]);

                            rowIdx++;
                            processedRows++;

                            // Actualizar Barra de Progreso cada 25 artículos
                            if (processedRows % 25 == 0 || processedRows == totalRows)
                            {
                                int porcentaje = (int)((processedRows / (float)totalRows) * 100);
                                this.Invoke(new Action(() => { pbAvance.Value = porcentaje; }));
                            }
                        }

                        // 4. Fila de Totales Finales
                        rowIdx++;
                        xlWorkSheet.Cells[rowIdx, 4] = "VALOR TOTAL DEL INVENTARIO:";
                        xlWorkSheet.Cells[rowIdx, 4].Font.Bold = true;
                        xlWorkSheet.Cells[rowIdx, 5] = sumaValorTotal;
                        xlWorkSheet.Cells[rowIdx, 5].Font.Bold = true;

                        // Bordes para el total
                        Excel.Range totalCell = xlWorkSheet.Cells[rowIdx, 5];
                        totalCell.Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlContinuous;
                        totalCell.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDouble;

                        // 5. Formatos de Celda
                        // Existencia y Costo: Ocultar si es cero
                        xlWorkSheet.Range["C5", "D" + rowIdx].NumberFormat = "#,##0.00;-#,##0.00;\"\"";

                        // Valor Total: Siempre mostrar (moneda)
                        xlWorkSheet.Range["E5", "E" + rowIdx].NumberFormat = "$#,##0.00";

                        xlWorkSheet.Columns.AutoFit();
                        xlWorkSheet.Columns[2].ColumnWidth = 50; // Ajuste manual para descripción larga

                        xlApp.ScreenUpdating = true;
                        xlApp.Visible = true;
                    }
                    finally
                    {
                        // Liberación de recursos COM
                        if (xlWorkSheet != null) Marshal.ReleaseComObject(xlWorkSheet);
                        if (xlWorkBook != null) Marshal.ReleaseComObject(xlWorkBook);
                        if (xlApp != null) Marshal.ReleaseComObject(xlApp);
                    }
                });

                sw.Stop();
                uiTimer.Stop();
                lblStatus.Text = $"Finalizado en {sw.Elapsed.Minutes:00}:{sw.Elapsed.Seconds:00}s. Items: {dt?.Rows.Count}";
            }
            catch (Exception ex)
            {
                sw.Stop();
                uiTimer.Stop();
                MessageBox.Show("Error al generar reporte: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "Error en el proceso.";
            }
            finally
            {
                cmdGenerar.Enabled = true;
                pbAvance.Visible = false;
                // Mantenemos el label visible un momento para mostrar el tiempo final
                await Task.Delay(3000);
                if (!cmdGenerar.Enabled) lblStatus.Visible = false;
            }
        }

    }
}
