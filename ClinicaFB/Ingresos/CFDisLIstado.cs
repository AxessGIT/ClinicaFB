using CFDiLib;
using ClinicaFB.Facturacion;
using ClinicaFB.Helpers;
using ClinicaFB.Modelo;
using Dapper;
using FirebirdSql.Data.FirebirdClient;
using SplashScreen.WindowsForms;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.XlsIO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFB.Ingresos
{
    public partial class CFDisLIstado : Form
    {
        private BindingList<Emisor> _emisores = new BindingList<Emisor>();
        private BindingList<CFDI> _cfdis = new BindingList<CFDI>();
        long _razonSocialId = 0;

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
            long emisorId =(long) cboEmisores.SelectedValue;
            DateTime fechaIni = dtpFechaInicial.Value;
            DateTime fechaFin = dtpFechaFinal.Value;


            using (FbConnection db = General.GetDB())
            {
                string sql = string.Empty;

                if (emisorId == 0)
                    sql = _razonSocialId ==0?Queries.FacturasSelectxFechas(): Queries.FacturasSelectxFechasYRazonSocial;
                else
                    sql = _razonSocialId == 0 ? Queries.FacturasSelect(): Queries.FacturasSelectXRazonSocial;


                var res = db.Query<CFDI>(sql, new {EmisorId = emisorId, FechaIni = fechaIni, FechaFin = fechaFin, RazonSocialId = _razonSocialId}).ToList();
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

            long cfdiId = _cfdis[grdCfdis.CurrentRow.Index].CfdiId;
            CFDI cfdi= new CFDI();
            List<CfdiDetalle> detalle = new List<CfdiDetalle>();

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.CfdiSelect();
                cfdi = db.Query<CFDI>(sql, new {Id=cfdiId}).FirstOrDefault();

                if (cfdi == null)
                {
                    return;
                }

                sql = Queries.CfdiDetallesSelect();
                var res = db.Query<CfdiDetalle>(sql, new { Id = cfdiId }).ToList();
                detalle = new List<CfdiDetalle>(res);

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

            long cfdId = _cfdis[grdCfdis.CurrentRow.Index].CfdiId;

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

            long id = _cfdis[grdCfdis.CurrentRow.Index].CfdiId;
            CfdiVisor cfdiVisor = new CfdiVisor(id);
            cfdiVisor.ShowDialog();

        }

   
        private void GeneraExcel(long emisorId, DateTime fechaIni, DateTime fechaFin)
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

        private async Task GeneraReporte(long emisorId, DateTime fechaIni, DateTime fechaFin)
        {
            await Task.Run(()=> GeneraExcel(emisorId,fechaIni,fechaFin));

        }

        private async void cmdReeporte_Click(object sender, EventArgs e)
        {
            long emisorId = (long)cboEmisores.SelectedValue;
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

        private async void cmdMandarCorreo_Click(object sender, EventArgs e)
        {
            if (CfdiSeleccionado() == false)
            {
                return;
            }

            long razonSocialId = _cfdis[grdCfdis.CurrentRow.Index].RazonSocialId;
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

            await ManejaCFDIs.MandaCorreo(direcciones,archivoCfdi,archivoPDF);
            MessageBox.Show("Se envío el correo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);



        }

        private void cmdChecarCancelacion_Click(object sender, EventArgs e)
        {
            Splasher splasher = new Splasher("Checando cancelación de CFDIs...");
            splasher.Show();

            long emisorId = (long)cboEmisores.SelectedValue;    
            if (emisorId == 0)
            {
                splasher.Close();
                MessageBox.Show("Indique el emisor", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            DateTime fechaIni = dtpFechaInicial.Value;
            DateTime fechaFin = dtpFechaFinal.Value;


            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.CFDisCanceladosSinCancelarSelect();
                List<CFDI> cfdis = db.Query<CFDI>(sql, new {EmisorId = emisorId, FechaIni = fechaIni, FechaFin = fechaFin }).ToList();

                if (cfdis.Count == 0)
                {
                    splasher.Close(); 
                    MessageBox.Show("No hay CFDIs sin cancelar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    return;
                }

                Microsoft.Office.Interop.Excel.Application oExcel;

                oExcel = new Microsoft.Office.Interop.Excel.Application();
                oExcel.Workbooks.Add();



                int ren = 1;

                oExcel.Cells[ren, 3].Value = "REPORTE DE FACTURAS";
                

                ren += 4;

                oExcel.Cells[ren, 1].Value = "Fecha";
                oExcel.Cells[ren, 2].Value = "Folio";
                oExcel.Cells[ren, 3].Value = "Cliente";
                oExcel.Cells[ren, 4].Value   = "UID";
                oExcel.Cells[ren, 5].Value = "Acuse";

          

                ren += 2;



                foreach (var cfdi in cfdis)
                {
                    oExcel.Cells[ren, 1].Value = cfdi.Fecha;
                    oExcel.Cells[ren, 2].Value = cfdi.Serie.Trim() + " " + cfdi.Folio.ToString();
                    oExcel.Cells[ren, 3].Value = string.IsNullOrEmpty(cfdi.ReceptorNombre) ? "PUBLICO EN GENERAL" : cfdi.ReceptorNombre;
                    oExcel.Cells[ren, 4].Value = cfdi.uid;
                    oExcel.Cells[ren, 5].Value = cfdi.AcuseCan;
                    ren++;





                }
                oExcel.Visible = true;
                
            }
            splasher.Close();

        }

        private void cmdCancelacionGlobal_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea iniciar?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            Splasher splasher = new Splasher("Iniciando cancelación de CFDIs...");
            splasher.Show();
            DateTime fechaIni = dtpFechaInicial.Value;
            DateTime fechaFin = dtpFechaFinal.Value;


            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.CFDisCanceladosSinCancelarSelect();
                List<CFDI> cfdis = db.Query<CFDI>(sql, new { FechaIni = fechaIni, FechaFin = fechaFin }).ToList();

                if (cfdis.Count == 0)
                {
                    splasher.Close(); 
                    MessageBox.Show("No hay CFDIs sin cancelar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    return;
                }

                foreach (var cfdi in cfdis)
                {
                    Cancelar(cfdi.CfdiId);
                }
            }

            splasher.Close();
            MessageBox.Show("Termino la cancelacion global", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }



        private void Cancelar(long cfdiId)
        {

            


            string uid = "";
            string rfc = "";
            string cer = "";
            string key = "";
            string pas = "";
            long emisorId;
            string sql;

            using (FbConnection db = General.GetDB())
            {


                CFDI cfdi = new CFDI();

                sql = Queries.CfdiSelect();
                cfdi = db.Query<CFDI>(sql, new { Id = cfdiId }).FirstOrDefault();

                uid = cfdi.uid;
                emisorId = cfdi.EmisorId;
                

                sql = Queries.EmisorSelect();
                Emisor emi = db.Query<Emisor>(sql, new { EmisorId = emisorId }).FirstOrDefault();

                if (emi == null)
                {
                    return;
                }

                rfc = emi.RFC;
                cer = emi.Certificado;
                key = emi.LlavePrivada;
                pas = emi.PassWord;
            }

            ComprobanteCFDI comprobante = new ComprobanteCFDI();

            string motivo = "02";
            string res = comprobante.CancelaSW(rfc, cer, key, pas, uid, motivo);


            if (res.Substring(0, 3) == "999" || (res.Contains("Status:201") == false && res.Contains("Status:202") == false))
            {

                return;

            }


            using (FbConnection db = General.GetDB())
            {
                sql = Queries.CfdiCancela();
                db.Execute(sql, new { Id = cfdiId, Acuse = res });
                
            }
            




        }

        private void cmdImprimir_Click(object sender, EventArgs e)
        {
            if (CfdiSeleccionado() == false)
            {
                return;
            }

            long cfdiId = _cfdis[grdCfdis.CurrentRow.Index].CfdiId;
            CFDI cfdi = new CFDI();
            List<CfdiDetalle> detalle = new List<CfdiDetalle>();

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.CfdiSelect();
                cfdi = db.Query<CFDI>(sql, new { Id = cfdiId }).FirstOrDefault();

                if (cfdi == null)
                {
                    return;
                }

                sql = Queries.CfdiDetallesSelect();
                var res = db.Query<CfdiDetalle>(sql, new { Id = cfdiId }).ToList();
                detalle = new List<CfdiDetalle>(res);

            }

            string carpetaCfdi = General.CarpetaCfdi(cfdi.EmisorRFC, cfdi.Fecha);
            string archivoCfdi = carpetaCfdi + @"\" + General.NombreArchivoCfdi("FAC", cfdi.Serie, cfdi.Folio);



            string xml = File.Exists(archivoCfdi) ? File.ReadAllText(archivoCfdi) : "";
            ComprobanteCFDI comprobante = new ComprobanteCFDI();

            cfdi.uid = comprobante.GetFolioFiscal(xml);
            cfdi.EmisorCSD = comprobante.GetEmisorCSDFromXML(xml);

            string archivoPDF = ManejaCFDIs.GeneraPDFFactura(cfdi, detalle, xml);

            General.ImprimePDF(archivoPDF);
            

        }

        private void cmdBuscaRazonSocial_Click(object sender, EventArgs e)
        {
            RazonesSocialesListado razonesSocialesListado = new RazonesSocialesListado(true);
            razonesSocialesListado.ShowDialog();
            if (razonesSocialesListado.RazonId != 0)
            {
                _razonSocialId = razonesSocialesListado.RazonId;
                CargaDatosRazonSocial();
            }

        }


        private void CargaDatosRazonSocial()
        {
            if (_razonSocialId == 0)
            {
                return;
            }

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.RazonSocialSelect();
                RazonSocial raz = db.Query<RazonSocial>(sql, new { RazonSocialId = _razonSocialId }).FirstOrDefault();

                if (raz != null)
                {
                    txtRFC.Text = raz.RFC;
                    txtRazonSocial.Text = raz.RazonSoc;

                }
            }


        }
    }
}
