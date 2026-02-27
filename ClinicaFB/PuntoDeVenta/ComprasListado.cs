using ClinicaFB.Helpers;
using ClinicaFB.Modelo;
using Dapper;
using FirebirdSql.Data.FirebirdClient;
using Org.BouncyCastle.Asn1.Cmp;
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
using System.Transactions;
using System.Windows.Forms;

using Excel = Microsoft.Office.Interop.Excel;

namespace ClinicaFB.PuntoDeVenta
{
    public partial class ComprasListado : Form
    {
        private BindingList<Documento> _compras = new BindingList<Documento>();
        private BindingList<Almacen> _almacenes = new BindingList<Almacen>();
        private int _proveedorId;

        public ComprasListado()
        {
            InitializeComponent();
        }

        private void ComprasListado_Load(object sender, EventArgs e)
        {
            dtpFechaInicial.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpFechaFinal.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            CargaAlmacenes();
            CargaCompras(); 
            SetGrid();
        }


        private void CargaAlmacenes()
        {

            long almacenIdDefa = 0;
            _almacenes = UtilsPDV.GetAlmacenes();


            foreach (var alma in _almacenes)
            {
                if (alma.Defa)
                {
                    almacenIdDefa = alma.AlmacenId;
                    break;
                }
            }

            cboAlmacenes.DataSource = null;
            cboAlmacenes.DataSource = _almacenes;
            cboAlmacenes.ValueMember = "AlmacenId";
            cboAlmacenes.DisplayMember = "Nombre";
            cboAlmacenes.SelectedValue = almacenIdDefa;




        }


        private void CargaProveedor()
        {
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.ProveedorSelect;
                Proveedor proveedor = db.Query<Proveedor>(sql, new { ProveedorId = _proveedorId }).FirstOrDefault();
                if (proveedor != null)
                {
                    txtProveedorRFC.Text = proveedor.RFC;
                    txtProveedorNombre.Text = proveedor.Nombre;
                }
            }
        }

        private void BuscaProveedor()
        {
            ProveedoresBuscar proveedoresBuscar = new ProveedoresBuscar();
            proveedoresBuscar.ShowDialog();
            if (proveedoresBuscar.ProveedorId > 0)
            {
                _proveedorId = proveedoresBuscar.ProveedorId;
                CargaProveedor();

            }
        }
    


        private void CargaCompras()
        {
            using (FbConnection db = General.GetDB())
            {
                string sql = _proveedorId==0?Queries.ComprasSelect:Queries.ComprasSelectXProveedor;
                long almacenId = (long)cboAlmacenes.SelectedValue;
                var res = db.Query<Documento>(sql, new {Tipo="COM", 
                                                    FechaIni = dtpFechaInicial.Value, FechaFin = dtpFechaFinal.Value, 
                                                    AlmacenId = almacenId,
                                                    ProveedorId = _proveedorId}).ToList();
                _compras = new BindingList<Documento>(res);
            }
        }

        private void SetGrid()
        {
            grdCompras.DataSource = null;



            grdCompras.AllowUserToAddRows = false;
            grdCompras.AllowUserToDeleteRows = false;


            grdCompras.AutoGenerateColumns = false;
            grdCompras.ReadOnly = true;
            grdCompras.AllowUserToResizeColumns = false;
            grdCompras.AllowUserToResizeRows = false;



            grdCompras.ColumnHeadersDefaultCellStyle.Font = new Font(grdCompras.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            grdCompras.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;



            grdCompras.DataSource = _compras;

        }

        private void AltasCambios(bool esAlta) {

            long compraId = 0;

            if (!esAlta)
                compraId = _compras[grdCompras.CurrentRow.Index].DocumentoId;

            long almacenId = (long) cboAlmacenes.SelectedValue;
            ComprasAltasCambios comprasAltasCambios = new ComprasAltasCambios(esAlta,compraId,almacenId);
            comprasAltasCambios.ShowDialog();

            CargaCompras();
            SetGrid();

        }



        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            CargaCompras();
            SetGrid();
        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            AltasCambios(true);
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            if (grdCompras.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una compra para modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            AltasCambios(false);
        }

        private void grdCompras_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cmdModificar_Click(sender, e);
        }

        private async void cmdCancelar_Click(object sender, EventArgs e)
        {
            if (grdCompras.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una compra para cancelar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            long conceptoCompraId = UtilsInv.GetConceptoInternoId("E", "COMPRA");


            long compraId = _compras[grdCompras.CurrentRow.Index].DocumentoId;
            bool capasUtilizadas = await UtilsInv.DocumentoCapasUtilizadas(conceptoCompraId, compraId);

            if (capasUtilizadas)
            {
              //  MessageBox.Show("No se puede cancelar la compra porque ya se han utilizado capas de costos generadas por la misma.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return;
            }

            if (_compras[grdCompras.CurrentRow.Index].Cancelado)
            {
                MessageBox.Show("La compra ya está cancelada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (MessageBox.Show("¿Está seguro de cancelar la compra?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }


            Almacen almacen = new Almacen();
            almacen = General.GetAlmacenDefault();

            long _conceptoCompraId = UtilsInv.GetConceptoInternoId("E", "COMPRA");
            long almacenId = cboAlmacenes.SelectedValue==null?almacen.AlmacenId:(long)cboAlmacenes.SelectedValue;

            using (FbConnection db = General.GetDB())
            {

                await db.OpenAsync();

                using (var transaction = db.BeginTransaction())
                {
                    try
                    {
                        string sql = "";

                        sql = Queries.DocumentoSetCancelado;
                        await db.ExecuteAsync(sql, new { DocumentoId = compraId },transaction);

                        sql = Queries.DocumentoDetalleSelect;
                        var res = db.Query<DocumentoDetalle>(sql, new { DocumentoId = compraId },transaction).ToList();


                        ArticuloExistencia articuloExistencia = new ArticuloExistencia();

                        foreach (var cancelado in res)
                        {
                            sql = Queries.ArticuloExistenciaSelect;
                            articuloExistencia = db.Query<ArticuloExistencia>(sql, new { cancelado.ArticuloId, almacen.AlmacenId },transaction).FirstOrDefault();

                            if (articuloExistencia == null)
                                continue;

                            articuloExistencia.Entradas -= cancelado.Cantidad;
                            sql = Queries.ArticuloExistenciaUpdate;
                            await db.ExecuteAsync(sql, articuloExistencia, transaction);

                        }

                        sql = Queries.DocumentoMovimientosDelete;

                        await db.ExecuteAsync(sql, new { EsVenta = false, DocumentoId = compraId }, transaction);
                        await UtilsInv.DocumentoReconstruyeCapasDeCostos(almacenId, res, db, transaction);

                        transaction.Commit();

                        MessageBox.Show("Compra cancelada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception err)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error al cancelar la compra: " + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }
            }

            CargaCompras();
            SetGrid();







        }


        private void cmdProveedorBuscar_Click(object sender, EventArgs e)
        {
            BuscaProveedor();
            CargaCompras();
            SetGrid();
        }

        private void cmdBorrarProveedor_Click(object sender, EventArgs e)
        {
            _proveedorId = 0;
            txtProveedorRFC.Text = "";
            txtProveedorNombre.Text = "";
            CargaCompras();
            SetGrid();
        }

        private async void cmdImprimir_Click(object sender, EventArgs e)
        {
            if (grdCompras.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una compra para imprimir", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            await ImprimeCompra();
            //await LimpiaCompra();


        }


        public async Task LimpiaCompra()
        {
            long compraId = _compras[grdCompras.CurrentRow.Index].DocumentoId;

            // Obtener los datos de la compra
            Documento compra = new Documento();

            using (FbConnection db = General.GetDB())
            {
                compra = await db.QuerySingleOrDefaultAsync<Documento>(Queries.DocumentoSelect, new { DocumentoId = compraId });
                if (compra == null)
                {
                    MessageBox.Show(this, "Compra no encontrada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }


            long _compraId = compraId;
            List<DocumentoDetalle> detalle = await UtilsInv.GetDocumentoDetalle(compraId);

            detalle = detalle
                    .GroupBy(x => x.ArticuloId)
                    .Select(g => g.First())
                    .OrderBy(x => x.ArticuloDescripcion)
                    .ToList();

            using (FbConnection db = General.GetDB())
            {
                await db.OpenAsync();
                using (var transaction = db.BeginTransaction())
                {
                    try
                    {


                        await UtilsInv.DocumentoBorraDetalle(_compraId, db, transaction);
                        await UtilsInv.DocumentoBorraMovimientosXId(_compraId, db, transaction);


                        foreach (DocumentoDetalle art in detalle)
                        {
                            string sql = Queries.DocumentoDetalleInsert;

                            art.DocumentoId = _compraId;
                            await db.ExecuteAsync(sql, art, transaction);
                        }
                        transaction.Commit();
                        MessageBox.Show("Compra limpiada correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception err)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error al limpiar la compra: " + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }



                }
            }
        }


        public async Task ImprimeCompra()
        {
            long compraId = _compras[grdCompras.CurrentRow.Index].DocumentoId;

            // Obtener los datos de la compra
            Documento compra = new Documento();

            using (FbConnection db = General.GetDB())
            {
                compra = await db.QuerySingleOrDefaultAsync<Documento>(Queries.DocumentoSelect, new { DocumentoId = compraId });
                if (compra == null)
                {
                    MessageBox.Show(this, "Compra no encontrada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            List<DocumentoDetalle> detalle = await UtilsInv.GetDocumentoDetalle(compraId);
            detalle = detalle.OrderBy(x => x.ArticuloDescripcion).ToList();

            Excel.Application xlApp = new Excel.Application();
            xlApp.ScreenUpdating = false;
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Add(Type.Missing);
            Excel.Worksheet xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            try
            {
                // Colores corporativos
                int colorEncabezado = ColorTranslator.ToOle(Color.FromArgb(44, 62, 80)); // Azul oscuro
                int colorTextoBlanco = ColorTranslator.ToOle(Color.White);
                int colorTitulosDetalle = ColorTranslator.ToOle(Color.FromArgb(52, 152, 219)); // Azul claro
                int colorTotal = ColorTranslator.ToOle(Color.FromArgb(241, 196, 15)); // Amarillo/dorado
                int colorTextoOscuro = ColorTranslator.ToOle(Color.Black);

                int ren = 1;

                // Título principal
                Excel.Range tituloRange = xlWorkSheet.Range[xlWorkSheet.Cells[ren, 1], xlWorkSheet.Cells[ren, 5]];
                tituloRange.Merge();
                tituloRange.Value = "REPORTE DE COMPRA";
                tituloRange.Font.Bold = true;
                tituloRange.Font.Size = 16;
                tituloRange.Interior.Color = colorEncabezado;
                tituloRange.Font.Color = colorTextoBlanco;
                tituloRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                tituloRange.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                tituloRange.RowHeight = 30;

                ren++;
                ren++; // Línea en blanco

                // Información de la compra
                xlWorkSheet.Cells[ren, 1] = "COMPRA:";
                xlWorkSheet.Cells[ren, 1].Font.Bold = true;
                xlWorkSheet.Cells[ren, 2] = compra.Folio.ToString("D6");
                
                ren++;
                xlWorkSheet.Cells[ren, 1] = "FECHA:";
                xlWorkSheet.Cells[ren, 1].Font.Bold = true;
                xlWorkSheet.Cells[ren, 2] = compra.Fecha.ToString("dd/MM/yyyy");
                xlWorkSheet.Cells[ren, 2].NumberFormat = "dd/mm/yyyy";
                
                ren++;
                xlWorkSheet.Cells[ren, 1] = "PROVEEDOR:";
                xlWorkSheet.Cells[ren, 1].Font.Bold = true;
                xlWorkSheet.Cells[ren, 2] = compra.ProveedorNombre;
                Excel.Range proveedorRange = xlWorkSheet.Range[xlWorkSheet.Cells[ren, 2], xlWorkSheet.Cells[ren, 5]];
                proveedorRange.Merge();

                ren++;
                ren++; // Línea en blanco

                // Encabezados del detalle
                string[] headers = { "CÓDIGO", "ARTÍCULO", "CANTIDAD", "PRECIO", "IMPORTE" };
                for (int i = 0; i < headers.Length; i++)
                {
                    Excel.Range cell = xlWorkSheet.Cells[ren, i + 1];
                    cell.Value = headers[i];
                    cell.Font.Bold = true;
                    cell.Font.Size = 11;
                    cell.Interior.Color = colorTitulosDetalle;
                    cell.Font.Color = colorTextoBlanco;
                    cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    cell.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
                    cell.Borders.Weight = Excel.XlBorderWeight.xlThin;
                }

                int renInicioDetalle = ren + 1;

                // Detalle de artículos
                /*detalle = detalle
                .GroupBy(x => x.ArticuloId)
                .Select(g => g.First())
                .OrderBy(x => x.ArticuloDescripcion)
                .ToList();*/

                foreach (var art in detalle)
                {
                    ren++;
                    xlWorkSheet.Cells[ren, 1] = $"'{art.Clave}";
                    xlWorkSheet.Cells[ren, 2] = art.ArticuloDescripcion;
                    
                    xlWorkSheet.Cells[ren, 3] = art.Cantidad;
                    xlWorkSheet.Cells[ren, 3].NumberFormat = "#,##0.00";
                    xlWorkSheet.Cells[ren, 3].HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    
                    xlWorkSheet.Cells[ren, 4] = art.Precio;
                    xlWorkSheet.Cells[ren, 4].NumberFormat = "$#,##0.00";
                    xlWorkSheet.Cells[ren, 4].HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                    
                    xlWorkSheet.Cells[ren, 5] = art.Importe;
                    xlWorkSheet.Cells[ren, 5].NumberFormat = "$#,##0.00";
                    xlWorkSheet.Cells[ren, 5].HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;

                    // Bordes para el detalle
                    Excel.Range rowRange = xlWorkSheet.Range[xlWorkSheet.Cells[ren, 1], xlWorkSheet.Cells[ren, 5]];
                    rowRange.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous;
                    rowRange.Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlHairline;
                    rowRange.Borders[Excel.XlBordersIndex.xlEdgeBottom].Color = ColorTranslator.ToOle(Color.LightGray);
                }

                ren++;
                ren++; // Línea en blanco

                // Total
                Excel.Range totalLabelCell = xlWorkSheet.Cells[ren, 4];
                totalLabelCell.Value = "TOTAL:";
                totalLabelCell.Font.Bold = true;
                totalLabelCell.Font.Size = 12;
                totalLabelCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                
                Excel.Range totalValueCell = xlWorkSheet.Cells[ren, 5];
                totalValueCell.Value = compra.Total;
                totalValueCell.NumberFormat = "$#,##0.00";
                totalValueCell.Font.Bold = true;
                totalValueCell.Font.Size = 12;
                totalValueCell.Interior.Color = colorTotal;
                totalValueCell.Font.Color = colorTextoOscuro;
                totalValueCell.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                totalValueCell.Borders.Weight = Excel.XlBorderWeight.xlMedium;

                // Ajustar ancho de columnas
                xlWorkSheet.Columns[1].ColumnWidth = 15;  // Código
                xlWorkSheet.Columns[2].ColumnWidth = 50;  // Artículo
                xlWorkSheet.Columns[3].ColumnWidth = 12;  // Cantidad
                xlWorkSheet.Columns[4].ColumnWidth = 15;  // Precio
                xlWorkSheet.Columns[5].ColumnWidth = 15;  // Importe

                xlApp.ScreenUpdating = true;
                xlApp.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"Error al generar el reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                xlWorkBook.Close(false);
                xlApp.Quit();
                
                if (xlWorkSheet != null) Marshal.ReleaseComObject(xlWorkSheet);
                if (xlWorkBook != null) Marshal.ReleaseComObject(xlWorkBook);
                if (xlApp != null) Marshal.ReleaseComObject(xlApp);
            }
        }
    }
}

    

