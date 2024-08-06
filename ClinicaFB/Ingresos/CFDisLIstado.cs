using CFDiLib;
using ClinicaFB.Helpers;
using ClinicaFB.Modelo;
using Dapper;
using FirebirdSql.Data.FirebirdClient;
using Syncfusion.Windows.Forms.Grid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using Syncfusion.XlsIO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SplashScreen.WindowsForms;

namespace ClinicaFB.Ingresos
{
    public partial class CFDisLIstado : Form
    {
        private BindingList<Emisor> _emisores = new BindingList<Emisor>();
        private BindingList<CFDI> _cfdis = new BindingList<CFDI>();

        public CFDisLIstado()
        {
            InitializeComponent();
        }

        private void cmdCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CFDisLIstado_Load(object sender, EventArgs e)
        {
            CargaEmisores();

        }


        private void CargaFacturas()
        {
            int emisorId =(int) cboEmisores.SelectedValue;
            DateTime fechaIni = dtpFechaInicial.Value;
            DateTime fechaFin = dtpFechaFinal.Value;


            using (FbConnection db = General.GetDB())
            {
                string sql = (emisorId==0)?Queries.FacturasSelectxFechas(): Queries.FacturasSelect();
                var res = db.Query<CFDI>(sql, new {EmisorId = emisorId, FechaIni = fechaIni, FechaFin = fechaFin }).ToList();
                _cfdis = new BindingList<CFDI>(res);
            }

        }

        private void SetGrid()
        {
            grdCfdis.DataSource = null;

            grdCfdis.AllowUserToAddRows = false;
            grdCfdis.AllowUserToDeleteRows = false;


            grdCfdis.AutoGenerateColumns = false;
            grdCfdis.ReadOnly = true;
            grdCfdis.AllowUserToResizeColumns = false;
            grdCfdis.AllowUserToResizeRows = false;

            grdCfdis.ColumnCount = 7;

            grdCfdis.RowHeadersVisible = true;


            grdCfdis.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(grdCfdis.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            grdCfdis.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grdCfdis.Columns[0].HeaderText = "Emisor";

            grdCfdis.Columns[0].DataPropertyName = "EmisorNombre";
            grdCfdis.Columns[0].Width = 180;

            grdCfdis.Columns[1].HeaderText = "Fecha";
            grdCfdis.Columns[1].DataPropertyName = "Fecha";
            grdCfdis.Columns[1].Width = 90;

            grdCfdis.Columns[2].HeaderText = "Serie";
            grdCfdis.Columns[2].DataPropertyName = "Serie";
            grdCfdis.Columns[2].Width = 40;
            grdCfdis.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            grdCfdis.Columns[3].HeaderText = "Folio";
            grdCfdis.Columns[3].DataPropertyName = "Folio";
            grdCfdis.Columns[3].Width = 50;
            grdCfdis.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            grdCfdis.Columns[4].HeaderText = "Paciente";
            grdCfdis.Columns[4].DataPropertyName = "NomPac";
            grdCfdis.Columns[4].Width = 200;
            //grdCfdis.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            grdCfdis.Columns[5].HeaderText = "Razon Social";
            grdCfdis.Columns[5].DataPropertyName = "NomRec";
            grdCfdis.Columns[5].Width = 200;
            //grdCfdis.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;



            grdCfdis.Columns[6].HeaderText = "Importe";
            grdCfdis.Columns[6].DataPropertyName = "Total";
            grdCfdis.Columns[6].Width = 80;
            grdCfdis.Columns[6].DefaultCellStyle.Format = "c2";
            grdCfdis.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            DataGridViewCheckBoxColumn colCancelada = new DataGridViewCheckBoxColumn();
            colCancelada.HeaderText = "Cancelada";
            colCancelada.DataPropertyName = "Cancelado";

            grdCfdis.Columns.Add(colCancelada);







            grdCfdis.DataSource = _cfdis;


        }


        private void CargaEmisores()
        {
            cboEmisores.DataSource = null;

            _emisores.Clear();
            _emisores.Add(new Emisor
            {
                EmisorId = 0,
                Nombre = "Todos"
            });

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.EmisoresSelect();
                var res = db.Query<Emisor>(sql).ToList();

                foreach (var emi in res)
                {
                    _emisores.Add(emi);

                }
            }

            cboEmisores.DataSource = _emisores;
            cboEmisores.DisplayMember = "Nombre";
            cboEmisores.ValueMember= "EmisorId";

            foreach (var emi in _emisores)
            {
                if (emi.Defa)
                {
                    cboEmisores.SelectedValue = emi.EmisorId;
                    break;
                }

            }
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            CargaFacturas();
            SetGrid();
        }



        private bool CfdiSeleccionado()
        {
            bool sel = true;
            if (grdCfdis.CurrentRow == null)
            {
                MessageBox.Show("Seleccione la factura", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sel=false;
            }


            return sel;
        }

        private void cmdArchivos_Click(object sender, EventArgs e)
        {

            if (CfdiSeleccionado() == false)
            {
                return;
            }

            int cfdiId = _cfdis[grdCfdis.CurrentRow.Index].CfdiId;
            CFDI cfdi= new CFDI();
            List<CFDIDetalle> detalle = new List<CFDIDetalle>();

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.CfdiSelect();
                cfdi = db.Query<CFDI>(sql, new {Id=cfdiId}).FirstOrDefault();

                if (cfdi == null)
                {
                    return;
                }

                sql = Queries.CfdiDetallesSelect();
                var res = db.Query<CFDIDetalle>(sql, new { Id = cfdiId }).ToList();
                detalle = new List<CFDIDetalle>(res);

            }

            string carpetaCfdi = General.CarpetaCfdi(cfdi.EmisorRFC, cfdi.Fecha);
            string archivoCfdi = carpetaCfdi +@"\"+ General.NombreArchivoCfdi("FAC", cfdi.Serie, cfdi.Folio);



            string xml = File.Exists(archivoCfdi) ? File.ReadAllText(archivoCfdi) : "";
            ComprobanteCFDI comprobante = new ComprobanteCFDI();

            cfdi.uid = comprobante.GetFolioFiscal(xml);
            cfdi.EmisorCSD= comprobante.GetEmisorCSDFromXML(xml);   

            ManejaCFDIs.GeneraPDFFactura(cfdi, detalle,xml);

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
            {
                FileName = carpetaCfdi,
                UseShellExecute = true,
                Verb = "open"
            });
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {

            if (CfdiSeleccionado() == false)
            {
                return;
            }

            if (_cfdis[grdCfdis.CurrentRow.Index].Cancelado )
            {
                MessageBox.Show("La factura ya está cancelada", "Confirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int cfdId = _cfdis[grdCfdis.CurrentRow.Index].CfdiId;

            CfdiCancelar cfdiCancelar = new CfdiCancelar(cfdId);
            cfdiCancelar.ShowDialog();
            CargaFacturas();
            SetGrid();

        }

        private void cmdVer_Click(object sender, EventArgs e)
        {
            if (CfdiSeleccionado() == false)
            {
                return;
            }

            int id = _cfdis[grdCfdis.CurrentRow.Index].CfdiId;
            CfdiVisor cfdiVisor = new CfdiVisor(id);
            cfdiVisor.ShowDialog();

        }

        private void Splash()
        {
            SplashScreen.WindowsForms.Splasher splasher = new SplashScreen.WindowsForms.Splasher("Generando reporte...");
            splasher.Show();

        }

        private void GeneraExcel(int emisorId, DateTime fechaIni, DateTime fechaFin)
        {
            SplashScreen.WindowsForms.Splasher splasher = new SplashScreen.WindowsForms.Splasher("Generando reporte...");
            splasher.Show();


            List<CFDI> facturas = new List<CFDI>();


            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.FacturasReporte();
                facturas = 
                    db.Query<CFDI>(sql, 
                    new {EmisorId = emisorId, FechaIni = fechaIni, FechaFin= fechaFin}).ToList();
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
            double subTotalSinCancelar = 0,subTotalCancelado = 0;
            double ivaSinCancelar = 0,ivaCancelado = 0;
            foreach (var factura in facturas)
            {
                worksheet.Range[ren, 1].DateTime = factura.Fecha;
                worksheet.Range[ren, 2].Text = factura.Serie.Trim() +" "+ factura.Folio.ToString();
                worksheet.Range[ren, 3].Text = string.IsNullOrEmpty(factura.ReceptorNombre)?"PUBLICO EN GENERAL":factura.ReceptorNombre;
                worksheet.Range[ren, 4].Number = (double)factura.SubTotal;
                worksheet.Range[ren, 4].NumberFormat = "$###,###,##0.00";
                worksheet.Range[ren, 5].Number = (double)factura.IVA;
                worksheet.Range[ren, 5].NumberFormat = "$###,###,##0.00";
                worksheet.Range[ren, 6].Number = (double)factura.Total;
                worksheet.Range[ren, 6].NumberFormat = "$###,###,##0.00";
                worksheet.Range[ren, 7].Text = factura.Cancelado ? "*" : "";

                if (factura.Cancelado)
                {
                    facturasCanceladas++;
                    subTotalCancelado += (double) factura.SubTotal;
                    ivaCancelado += (double)factura.IVA;
                }
                else
                {
                    facturasSinCancelar++;
                    subTotalSinCancelar += (double)factura.SubTotal;
                    ivaSinCancelar += (double)factura.IVA;  

                }


                ren++;



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
            worksheet.Range[ren, 3].Text = $"Total facturas ({facturasSinCancelar+ facturasCanceladas})";

            worksheet.Range[ren, 4].Number = (double)subTotalCancelado + subTotalSinCancelar;
            worksheet.Range[ren, 4].NumberFormat = "$###,###,##0.00";
            worksheet.Range[ren, 5].Number = (double)ivaCancelado + ivaSinCancelar;
            worksheet.Range[ren, 5].NumberFormat = "$###,###,##0.00";
            worksheet.Range[ren, 6].Number = (double)totalCancelado+ totalSinCancelar;
            worksheet.Range[ren, 6].NumberFormat = "$###,###,##0.00";




            string tempfile = "rptFac"+ Path.GetFileNameWithoutExtension(Path.GetRandomFileName())+".xlsx";
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

        private void BorraTemporales() {
            foreach (string Libro in Directory.EnumerateFiles(Path.GetTempPath(),"rptFac*.xlsx"))
            {
                try
                {
                    File.Delete(Libro);
                }
                catch (Exception)
                {

                    
                }

            }

        }

        private async Task GeneraReporte(int emisorId, DateTime fechaIni, DateTime fechaFin)
        {
            await Task.Run(()=> GeneraExcel(emisorId,fechaIni,fechaFin));

        }

        private async void cmdimprimir_Click(object sender, EventArgs e)
        {
            int emisorId = (int)cboEmisores.SelectedValue;
            if (emisorId == 0)
            {
                MessageBox.Show("Indique el emisor","Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            await GeneraReporte(emisorId, dtpFechaInicial.Value, dtpFechaFinal.Value);
        }

        private void CFDisLIstado_FormClosing(object sender, FormClosingEventArgs e)
        {
           BorraTemporales();
        }

        private void cmdMandarCorreo_Click(object sender, EventArgs e)
        {
            if (CfdiSeleccionado() == false)
            {
                return;
            }

            int razonSocialId = _cfdis[grdCfdis.CurrentRow.Index].RazonSocialId;
            CorreosDirecciones correosDirecciones = new CorreosDirecciones(razonSocialId);
            correosDirecciones.ShowDialog();

            if (correosDirecciones.Aceptar == false)
            {
                return;
            }

            CFDI cfdi = _cfdis[grdCfdis.CurrentRow.Index];

            string carpetaCfdi = General.CarpetaCfdi(cfdi.EmisorRFC, cfdi.Fecha);
            string archivoCfdi = carpetaCfdi + @"\" + General.NombreArchivoCfdi("FAC", cfdi.Serie, cfdi.Folio);
            string archivoPDF = carpetaCfdi + @"\" + General.NombreArchivoPDF("FAC", cfdi.Serie, cfdi.Folio);

            string[] dirs = correosDirecciones.txtDirecciones.Text.Split(new string[] { Environment.NewLine },StringSplitOptions.None);

            string direcciones = dirs[0];

            if (dirs.Length > 1) { 
                foreach (var d in dirs)
                {
                    direcciones = "," + direcciones + d;
                }

            }

            ManejaCFDIs.MandaCorreo(direcciones,archivoCfdi,archivoPDF);
            MessageBox.Show("Se envío el correo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);



        }
    }
}
