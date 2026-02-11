using ClinicaFB.Helpers;
using ClinicaFB.Modelo;
using Dapper;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.Office.Interop.Excel;
using Org.BouncyCastle.Asn1.Cmp;
using Org.BouncyCastle.Pqc.Crypto.Lms;
using SplashScreen.WindowsForms;
using Syncfusion.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Excel = Microsoft.Office.Interop.Excel;

namespace ClinicaFB.PuntoDeVenta.Reportes
{
    public partial class Kardex: Form
    {
        private long _articuloId = 0;
        private BindingList<Almacen> _almacenes;
        private CancellationTokenSource _cancellationTokenSource;
        private bool _isProcessing = false; // Flag para prevenir ejecuciones concurrentes
    
        public Kardex()
        {
            InitializeComponent();
        }

        private void rptArticuloKardex_Load(object sender, EventArgs e)
        {
            CargaAlmacenes();
            ActiveControl = txtArticuloDescripcion;

        }
        private void CargaAlmacenes()
        {

            long almacenIdDefa = 0;

            using (FbConnection db = General.GetDB())
            {
                string sql = Helpers.Queries.AlmacenesSelect();

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


        private void txtConcepto_KeyDown(object sender, KeyEventArgs e)
        {

        }


        private void FormaBuscaArticulo(System.Windows.Forms.TextBox textBox, ref long articuloId)
        {
            ArticulosBuscar articulosBuscar = new ArticulosBuscar(textBox.Text.Trim());
            articulosBuscar.ShowDialog();

            if (articulosBuscar.ArticuloId != 0)
            {
                articuloId = articulosBuscar.ArticuloId;
                BuscaArticulo(ref textBox, articuloId);
            }
        }
        private void BuscaArticulo(ref System.Windows.Forms.TextBox textBox, long articuloId )
        {

                using (FbConnection db = General.GetDB())
                {

                    string sql = Helpers.Queries.ArticuloSelect();
                    Articulo art = db.Query<Articulo>(sql, new { ArticuloId = articuloId}).FirstOrDefault();

                    if (art != null)
                    {
                        textBox.Text = art.Descripcion;
                    }
                }

            }

        private void txtArticulo_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtArticuloDescripcion.Text.Trim()))
            {
                _articuloId = 0;
                txtArticuloDescripcion.Text = "TODOS";
                return;
            }
            BuscaArticulo(ref txtArticuloDescripcion, _articuloId);
        }

        /* Created: 2026-01-07 07:58:10 */

        public async Task GeneraReporteKardex()
        {
            // Prevenir ejecuciones concurrentes
            if (_isProcessing)
            {
                MessageBox.Show("Ya hay un reporte en proceso. Por favor espere.", "Kardex", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _isProcessing = true;

            // 1. Preparar Interfaz
            pbAvance.Value = 0;
            pbAvance.Visible = true;
            lblStatus.Visible = true;
            lblStatus.Text = "Consultando datos proceso...";
            cmdGenerar.Enabled = false;
            Stopwatch sw = new Stopwatch();

            // Cancelar cualquier operación anterior (solo si existe)
            if (_cancellationTokenSource != null)
            {
                _cancellationTokenSource.Cancel();
                _cancellationTokenSource.Dispose();
            }
            _cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = _cancellationTokenSource.Token;

            // Timer para actualizar el label de tiempo cada segundo en la UI
            System.Windows.Forms.Timer uiTimer = new System.Windows.Forms.Timer();
            uiTimer.Interval = 1000;
            uiTimer.Tick += (s, e) => {
                if (this.IsHandleCreated && !this.IsDisposed)
                {
                    try
                    {
                        lblStatus.Text = $"Procesando... Tiempo transcurrido: {sw.Elapsed.Minutes:00}:{sw.Elapsed.Seconds:00}s";
                    }
                    catch (ObjectDisposedException)
                    {
                        // El formulario se cerró durante la actualización
                        uiTimer.Stop();
                    }
                }
                else
                {
                    uiTimer.Stop();
                }
            };

            System.Data.DataTable dt = null;

            try
            {
                long articuloId = _articuloId;
                long almacenId = (long)cboAlmacenes.SelectedValue;
                DateTime fechaIni = dtpFechaInicial.Value.Date;
                DateTime fechaFin = dtpFechaFinal.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

                sw.Start();
                uiTimer.Start();

                await Task.Run(() =>
                {
                    dt = new System.Data.DataTable();

                    using (FbConnection db = General.GetDB())
                    {
                        // El orden en el SP es: ARTICULO, ALMACEN, FECHA_INI, FECHA_FIN
                        string sql = "SELECT NOMBRE_ARTICULO, FECHA_MOV, CONCEPTO_DESC, REFERENCIA, " +
                                     "ENTRADA_CANT, SALIDA_CANT, COSTO_UNIT, SALDO_CANT, SALDO_VALOR " +
                                     "FROM SP_REPORTE_KARDEX(@F1, @F2,@A, @L)"; // <-- CAMBIO DE ORDEN AQUÍ

                        FbCommand c = new FbCommand(sql, db);

                        // Agregamos en el mismo orden que el SQL para mayor claridad
                        c.Parameters.Add("@A", FbDbType.BigInt).Value = articuloId;
                        c.Parameters.Add("@L", FbDbType.BigInt).Value = almacenId;
                        c.Parameters.Add("@F1", FbDbType.Date).Value = fechaIni.Date; // Usar .Date para evitar problemas de horas
                        c.Parameters.Add("@F2", FbDbType.Date).Value = fechaFin.Date;

                        FbDataAdapter a = new FbDataAdapter(c);
                        a.Fill(dt);
                    }
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No se encontraron datos para los criterios seleccionados.", "Kardex", MessageBoxButtons.OK, MessageBoxIcon.Information,
                           MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                        return;
                    }



                    // Verificar cancelación antes de iniciar Excel
                    cancellationToken.ThrowIfCancellationRequested();

                    // 3. Iniciar Excel con optimización
                    Excel.Application xlApp = new Excel.Application();
                    xlApp.ScreenUpdating = false;
                    Excel.Workbook xlWorkBook = xlApp.Workbooks.Add(Type.Missing);
                    Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                    try
                    {
                        // Encabezados
                        string[] headers = { "Fecha", "Concepto", "Referencia (S-F)", "Entrada", "Salida", "Costo U.", "Existencia", "Saldo Valor" };
                        for (int i = 0; i < headers.Length; i++)
                        {
                            xlWorkSheet.Cells[1, i + 1] = headers[i];
                            Excel.Range cell = xlWorkSheet.Cells[1, i + 1];
                            cell.Font.Bold = true;
                            cell.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(44, 62, 80));
                            cell.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                        }

                        int rowIdx = 2;
                        string lastArtNombre = "";
                        int totalRows = dt.Rows.Count;
                        int processedRows = 0;

                        foreach (DataRow row in dt.Rows)
                        {
                            // Verificar cancelación periódicamente
                            if (cancellationToken.IsCancellationRequested)
                            {
                                xlWorkBook.Close(false);
                                xlApp.Quit();
                                return;
                            }

                            string currentArtNombre = row["NOMBRE_ARTICULO"].ToString();

                            if (currentArtNombre != lastArtNombre)
                            {
                                Excel.Range titleRange = xlWorkSheet.Range[xlWorkSheet.Cells[rowIdx, 1], xlWorkSheet.Cells[rowIdx, 8]];
                                titleRange.Merge();
                                titleRange.Value = "ARTÍCULO: " + currentArtNombre;
                                titleRange.Font.Bold = true;
                                titleRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(189, 195, 199));
                                rowIdx++;
                            }


                           
                            xlWorkSheet.Cells[rowIdx, 1] = row["FECHA_MOV"];
                            xlWorkSheet.Cells[rowIdx, 2] = row["CONCEPTO_DESC"];
                            xlWorkSheet.Cells[rowIdx, 3] = row["REFERENCIA"];
                            xlWorkSheet.Cells[rowIdx, 4] = row["ENTRADA_CANT"];
                            xlWorkSheet.Cells[rowIdx, 5] = row["SALIDA_CANT"];
                            xlWorkSheet.Cells[rowIdx, 6] = row["COSTO_UNIT"];
                            xlWorkSheet.Cells[rowIdx, 7] = row["SALDO_CANT"];
                            xlWorkSheet.Cells[rowIdx, 8] = row["SALDO_VALOR"];

                            if (row["CONCEPTO_DESC"].ToString().Contains(">"))
                                xlWorkSheet.Range[xlWorkSheet.Cells[rowIdx, 1], xlWorkSheet.Cells[rowIdx, 8]].Font.Bold = true;

                            lastArtNombre = currentArtNombre;
                            rowIdx++;
                            processedRows++;

                            if (processedRows % 20 == 0 || processedRows == totalRows)
                            {
                                int porcentaje = (int)((processedRows / (float)totalRows) * 100);
                                
                                // Verificar que el formulario sigue válido antes de Invoke
                                if (this.IsHandleCreated && !this.IsDisposed)
                                {
                                    try
                                    {
                                        this.Invoke(new System.Action(() => {
                                            if (!pbAvance.IsDisposed)
                                            {
                                                pbAvance.Value = porcentaje;
                                            }
                                        }));
                                    }
                                    catch (ObjectDisposedException)
                                    {
                                        // Formulario cerrado, cancelar operación
                                        xlWorkBook.Close(false);
                                        xlApp.Quit();
                                        return;
                                    }
                                    catch (InvalidOperationException)
                                    {
                                        // Handle no creado o formulario cerrado
                                        xlWorkBook.Close(false);
                                        xlApp.Quit();
                                        return;
                                    }
                                }
                                else
                                {
                                    // Formulario cerrado, cancelar operación
                                    xlWorkBook.Close(false);
                                    xlApp.Quit();
                                    return;
                                }
                            }
                        }

                        // 4. Formatos Finales (Limpieza de Ceros)
                        xlWorkSheet.Range["A2", "A" + rowIdx].NumberFormat = "dd/mm/yyyy hh:mm";

                        // Entradas, Salidas y Costo: Ocultar ceros si el valor es 0
                        // Formato: Positivos ; Negativos ; "En blanco"
                        xlWorkSheet.Range["D2", "F" + rowIdx].NumberFormat = "#,##0.00;-#,##0.00;\"\"";

                        // Existencias y Saldo Valor (Siempre mostrar para ver stocks en 0)
                        xlWorkSheet.Range["G2", "H" + rowIdx].NumberFormat = "#,##0.00";

                        xlWorkSheet.Columns.AutoFit();
                        xlApp.ScreenUpdating = true;
                        xlApp.Visible = true;
                    }
                    finally
                    {
                        if (xlWorkSheet != null) Marshal.ReleaseComObject(xlWorkSheet);
                        if (xlWorkBook != null) Marshal.ReleaseComObject(xlWorkBook);
                        if (xlApp != null) Marshal.ReleaseComObject(xlApp);
                    }
                }, cancellationToken);

                sw.Stop();
                uiTimer.Stop();
                
                if (this.IsHandleCreated && !this.IsDisposed)
                {
                    lblStatus.Text = $"Finalizado en {sw.Elapsed.Minutes:00}:{sw.Elapsed.Seconds:00}s. Filas: {(dt != null ? dt.Rows.Count : 0)}";
                }
            }
            catch (OperationCanceledException)
            {
                // Operación cancelada por el usuario
                sw.Stop();
                uiTimer.Stop();
                
                if (this.IsHandleCreated && !this.IsDisposed)
                {
                    lblStatus.Text = "Operación cancelada.";
                }
            }
            catch (Exception ex)
            {
                sw.Stop();
                uiTimer.Stop();
                
                if (this.IsHandleCreated && !this.IsDisposed)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    lblStatus.Text = "Error en el proceso.";
                }
            }
            finally
            {
                uiTimer.Dispose();
                _isProcessing = false; // Liberar el flag
                
                if (this.IsHandleCreated && !this.IsDisposed)
                {
                    cmdGenerar.Enabled = true;
                    pbAvance.Visible = false;
                    lblStatus.Visible = false;
                }
            }
        }

        private async void cmdGenerar_Click(object sender, EventArgs e)
        {
            // Deshabilitar inmediatamente para prevenir doble clic
            cmdGenerar.Enabled = false;
            
            try
            {
                long almacenId = (long)cboAlmacenes.SelectedValue;  
                if (almacenId == 0)
                {
                    MessageBox.Show("Seleccione un almacén", "Almacén", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dtpFechaInicial.Value.Date > dtpFechaFinal.Value.Date)
                {
                    MessageBox.Show("La fecha inicial no puede ser mayor a la fecha final", "Fechas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                await GeneraReporteKardex();
            }
            finally
            {
                // Asegurar que el botón se habilite si hay error en validación
                if (!_isProcessing)
                {
                    cmdGenerar.Enabled = true;
                }
            }
        }

        private void txtArticuloInicial_KeyDown(object sender, KeyEventArgs e)
        {
            TeclaPresionada(sender, e, txtArticuloDescripcion, ref _articuloId);
        }




        private void TeclaPresionada(object sender, KeyEventArgs e, System.Windows.Forms.TextBox textBox, ref long articuloId)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    FormaBuscaArticulo(textBox,  ref articuloId);
                    break;
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    BuscaArticulo(ref textBox, articuloId);
                    break;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();
        }
    }
}
