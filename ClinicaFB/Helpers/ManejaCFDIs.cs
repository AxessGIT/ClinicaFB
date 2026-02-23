using CFDiLib;
using ClinicaFB.Modelo;
using Dapper;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.Reporting.WinForms;
using MimeKit;
using QRCoder;
using SplashScreen.WindowsForms;
using Syncfusion.Windows.Forms.PdfViewer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Printing;
using System.DrawingCore;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Twilio.Annotations;

namespace ClinicaFB.Helpers
{
    public static class ManejaCFDIs
    {


        public static async Task ConfirmaVentasCanceladas(DateTime fechaIni, DateTime fechaFin)
        {
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.VentasCanceladasSelect;
                List<Venta> ventas = db.Query<Venta>(sql, new { FechaIni = fechaIni, FechaFin = fechaFin }).ToList();
                if (ventas.Count == 0)
                {
                    MessageBox.Show("No hay ventas sin cancelar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                foreach (var venta in ventas)
                {
                    await CancelarVenta(venta.VentaId);
                }
            }
        }

        private static async Task CancelarVenta(long ventaId) { 
        }


        public static async Task ConfirmaCFDiCancelados(DateTime fechaIni, DateTime fechaFin)
        {

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.CFDisCanceladosSinCancelarSelect;
                List<CFDI> cfdis = db.Query<CFDI>(sql, new { FechaIni = fechaIni, FechaFin = fechaFin }).ToList();

                if (cfdis.Count == 0)
                {
                    return;
                }

                foreach (var cfdi in cfdis)
                {
                   await Cancelar(cfdi.CfdiId);
                }
            }
        }


        private static async Task Cancelar(long cfdiId)
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
                cfdi = (await db.QueryAsync<CFDI>(sql, new { Id = cfdiId })).FirstOrDefault();

                uid = cfdi.uid;
                emisorId = cfdi.EmisorId;


                sql = Queries.EmisorSelect();
                Emisor emi = (await db.QueryAsync<Emisor>(sql, new { EmisorId = emisorId })).FirstOrDefault();

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
                await db.ExecuteAsync(sql, new { Id = cfdiId, Acuse = res });

            }

        }

        public static string GeneraComplementoDePago(long pagoId,bool timbrar=true,bool mandarCorreo=true) 
        { 
            string resultado= string.Empty;
            ComplementoPago comp = new ComplementoPago();
            List<ComPagRel> relacionados = new List<ComPagRel>();

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.ComplementoDePagoSelect;
                comp = db.Query<ComplementoPago>(sql, new { ComPagId = pagoId }).FirstOrDefault();
                if (comp == null)
                {
                    return "001";
                }

                sql = Queries.ComPagRelsSelect;
                relacionados = db.Query<ComPagRel>(sql, new { ComPagoId = pagoId }).ToList();

                if (relacionados.Count == 0)
                {
                    return "002";
                }


            }

            if (timbrar)
            {
                resultado = TimbraComplementoDePago(comp, relacionados);
                if (resultado != "000")
                {
                    return resultado;
                }
            }
            return resultado;

        }

        public static string TimbraComplementoDePago(ComplementoPago comp, List<ComPagRel> relacionados)
        {
            string resultado = "000";
            Emisor emisor = new Emisor();
            RazonSocial razon = new RazonSocial();
            bool publico = false;

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.EmisorSelect();
                emisor = db.Query<Emisor>(sql, new { comp.EmisorId }).FirstOrDefault();
                if (emisor == null)
                {
                    return "003";
                }

                if (emisor.Cer == null || emisor.Llave == null)
                {
                    return "004";
                }


                if (comp.RazonSocialId == 0)
                {
                    publico = true;
                }
                else { 
                    sql = Queries.RazonSocialSelect();
                    razon = db.Query<RazonSocial>(sql, new { comp.RazonSocialId }).FirstOrDefault();
                    if (razon == null)
                    {
                        return "005";
                    }
                }
            }

            string cerTmp = Path.GetTempFileName() + ".cer";
            string llaveTmp = Path.GetTempFileName() + ".key";


            if (emisor.Cer.Length > 0 && emisor.Llave.Length > 0)
            {
                File.WriteAllBytes(cerTmp, emisor.Cer);
                File.WriteAllBytes(llaveTmp, emisor.Llave);
            }



            ComprobanteCFDI comprobante = new ComprobanteCFDI();

            comprobante.TipoComprobante = "P";
            comprobante.Certificado = cerTmp;
            comprobante.LlavePrivada = llaveTmp;
            comprobante.PassWord = emisor.PassWord;

            comprobante.Serie = comp.Serie;
            comprobante.Folio = comp.Folio;
            comprobante.Fecha = DateTime.Now;
            comprobante.LugarExpedicion = emisor.CP;


            comprobante.ComprobanteEmisor.RFC = emisor.RFC;
            comprobante.ComprobanteEmisor.Nombre = emisor.Nombre;
            comprobante.ComprobanteEmisor.RegimenFiscal = emisor.CveRef;


            comprobante.ComprobanteReceptor.RFC = publico ? "XAXX010101000" : razon.RFC;
            comprobante.ComprobanteReceptor.Nombre = publico ? "PUBLICO EN GENERAL" : razon.RazonSoc;

            comprobante.ComprobanteReceptor.DomicilioFiscalReceptor = publico ? emisor.CP : razon.CP;
            comprobante.ComprobanteReceptor.RegimenFiscalReceptor = publico ? "616" : razon.CveREF;





            PagoComp pago = new PagoComp();
            pago.MonedaP = comp.CveMON;
            pago.TipoCambioP = comp.TipoDeCambio;
            pago.Monto = comp.Monto;
            pago.FormaDePagoP = comp.CveFOP;
            pago.FechaPago = comp.Fecha;

            foreach (var rel in relacionados)
            {
                PagoDucumentoRelacionado doc = new PagoDucumentoRelacionado();
                doc.IdDocumento = rel.UID;
                doc.Serie = rel.Serie;
                doc.Folio = rel.Folio;
                doc.MonedaDR = rel.CveMON;
                doc.TipoCambioDR = rel.TipoDeCambio;

                doc.ImpSaldoAnt = rel.Pagado;
                doc.ImpPagado = rel.Pagado;
                doc.ImpSaldoInsoluto = rel.SaldoInsoluto;
                doc.ObjetoImpDR = "02";

                if (rel.IVA16 > 0)
                {
                    DatosImpuestoCFDI tras = new DatosImpuestoCFDI();
                    tras.Impuesto = "002";
                    tras.TipoFactor = "Tasa";
                    tras.Base = rel.BaseIVA16;
                    tras.Importe = rel.IVA16;
                    tras.TasaOCuota = (decimal)0.16;
                    doc.TrasladosDR.Add(tras);
                }

                if (rel.BaseIVA0 > 0)
                {
                    DatosImpuestoCFDI tras = new DatosImpuestoCFDI();
                    tras.Impuesto = "002";
                    tras.TipoFactor = "Tasa";
                    tras.Base = rel.BaseIVA0;
                    tras.Importe = 0;
                    tras.TasaOCuota = 0;
                    doc.TrasladosDR.Add(tras);
                }

                pago.DocumentosRelacionados.Add(doc);

            }

            comprobante.ComplementoPago.Pagos.Add(pago);


            string carpetaTemporal = System.IO.Path.GetTempPath();
            string archivoXMLBase = System.IO.Path.GetRandomFileName();
            archivoXMLBase = System.IO.Path.GetFileNameWithoutExtension(archivoXMLBase)+".xml";

            string archivoXMlFirmado= System.IO.Path.GetRandomFileName();
            archivoXMlFirmado = System.IO.Path.GetFileNameWithoutExtension(archivoXMlFirmado) + ".xml";

            string archivoXMLTimbrado= System.IO.Path.GetRandomFileName();
            archivoXMLTimbrado = System.IO.Path.GetFileNameWithoutExtension(archivoXMLTimbrado) + ".xml";

            comprobante.archivoXMLBase = $@"{carpetaTemporal}\{archivoXMLBase}";
            comprobante.archivoXMLFirmado = $@"{carpetaTemporal}\{archivoXMlFirmado}";
            comprobante.archivoXMLTimbrado = $@"{carpetaTemporal}\{archivoXMLTimbrado}";


            comprobante.CreaXML();
            resultado = comprobante.SellaXML();

            if (resultado != "0")
            {
                if (File.Exists(cerTmp))
                {
                    File.Delete(cerTmp);
                }
                if (File.Exists(llaveTmp))
                {
                    File.Delete(llaveTmp);
                }
                return resultado;
            }

            resultado = comprobante.TimbraSW();

            if (File.Exists(cerTmp))
            {
                File.Delete(cerTmp);
            }
            if (File.Exists(llaveTmp))
            {
                File.Delete(llaveTmp);
            }


            if (resultado != "000")
            {
                return resultado;
            }

            string xml = File.ReadAllText(comprobante.archivoXMLTimbrado);
            string uid = comprobante.GetFolioFiscal(xml);
            using (FbConnection db = General.GetDB())
            {

                using (FbCommand cmd = new FbCommand())
                {
                    db.Open();
                    string sql = Queries.ComplementoDePagoUpdateTimbrado;
                    cmd.CommandText = sql;
                    cmd.Connection = db;
                    cmd.Parameters.AddWithValue("xml",xml);
                    cmd.Parameters.AddWithValue("UID",uid);
                    cmd.Parameters.AddWithValue("ComPagId",comp.ComPagId);
                    _ = cmd.ExecuteNonQuery();
                    db.Close();
                }
            }
            return resultado;
        }

        public static string GetEmisorRFC(XmlDocument xml)
        {
            string rfc = "";

            XmlNodeList emisor = xml.GetElementsByTagName("cfdi:Emisor");

            foreach (XmlNode nodo in emisor)
            {
                foreach (XmlAttribute atributo in nodo.Attributes)
                {
                    if (atributo.Name == "Rfc")
                    {
                        rfc = atributo.Value;
                    }
                }
            }

            return rfc;
        }

        public static decimal GetTasaIVA(XmlNode conceptoImpuestos)
        {
            decimal tasa = 0;

            foreach (XmlNode traslado in conceptoImpuestos.ChildNodes)
            {
                if (traslado.Name == "cfdi:Traslados")
                {
                    foreach (XmlNode tras in traslado.ChildNodes)
                    {
                        if (tras.Name == "cfdi:Traslado")
                        {
                            foreach (XmlAttribute atributo in tras.Attributes)
                            {
                                if (atributo.Name == "TasaOCuota")
                                {
                                    tasa = Convert.ToDecimal(atributo.Value);
                                }
                            }
                        }
                    }
                }
            }

            return tasa;
        }
    

        public static async Task MandaCorreo(string correos, string archivoXML = "", string archivoPDF = "")
        {
            await EnviaArchivos(correos, archivoXML, archivoPDF);

        }

        public static async Task EnviaArchivos(string correos, string archivoXML = "", string archivoPDF = "")
        {


            string[] dirs = correos.Split(',');
            MimeMessage mensaje = new MimeMessage();
            foreach (string dir in dirs)
            {
                mensaje.To.Add(MailboxAddress.Parse(dir));
            }

            //mensaje.From.Add(new MailboxAddress("Facturación Medipiel", "novedades@sifiscalapp.com"));
            mensaje.From.Add(new MailboxAddress("Facturación Medipiel", "facturacion@medipielapp.com"));
            mensaje.Subject = "Envío de comprobante medipiel";

            /*mensaje.Body = new TextPart("plain")
            {
               Text= "Favor de no responder a esta dirección. Envío automático. Saludos"

            };

            if (string.IsNullOrEmpty(archivoXML) == false)
            {
                mensaje.Attachments. .Add(new Attachment( archivoXML));
            }

            if (string.IsNullOrEmpty(archivoPDF) == false)
            {
                mensaje.Attachments.Add(new Attachment(archivoPDF));
            }*/


            var builder = new BodyBuilder
            {
                HtmlBody = "Favor de no responder a esta dirección. Envío automático. Saludos"
            };


            if (string.IsNullOrEmpty(archivoXML) == false && File.Exists(archivoXML))
            {
                builder.Attachments.Add(archivoXML);
            }

            if (string.IsNullOrEmpty(archivoPDF) == false && File.Exists(archivoPDF))
            {
                builder.Attachments.Add(archivoPDF);
            }


            mensaje.Body = builder.ToMessageBody();

            MailKit.Net.Smtp.SmtpClient server = new MailKit.Net.Smtp.SmtpClient();

            //server.Connect("smtpout.secureserver.net", 587, MailKit.Security.SecureSocketOptions.StartTls);
           // server.Connect("rs00032.prodns.mx", 465, MailKit.Security.SecureSocketOptions.SslOnConnect);
            server.Connect("mail.medipielapp.com", 587, MailKit.Security.SecureSocketOptions.None);
            //server.Authenticate("novedades@sifiscalapp.com", "Ab369741@");
            server.Authenticate("facturacion@medipielapp.com", "LkM()ui87%$");
            string res = server.Send(mensaje);
            server.Disconnect(true);

            //MessageBox.Show(res);



        }

        private static void ImprimeTicketRaw(
            Venta ticket, BindingList<VentaDetalle> ticketArticulos,string impresora, string datosSucursal,
            decimal pagado=0, decimal cambio = 0
            )
        {



            StringReader strReader = new StringReader(datosSucursal);

            while (strReader.Peek() != -1)
            {
                string linea = strReader.ReadLine();
                RawPrinter.SendStringToPrinter(impresora, $"\n{linea}");
            }

            RawPrinter.SendStringToPrinter(impresora, "\n");
            RawPrinter.SendStringToPrinter(impresora, "\n");
            RawPrinter.SendStringToPrinter(impresora, "\nFARMA DERMA");
            RawPrinter.SendStringToPrinter(impresora, "\nFDE210929KB3");
            RawPrinter.SendStringToPrinter(impresora, "\nJOSE VASCONCELOS 405");
            RawPrinter.SendStringToPrinter(impresora, "\nRES. SAN AGUSTIN");
            RawPrinter.SendStringToPrinter(impresora, "\nSAN PEDRO GARZA GARCIA");
            RawPrinter.SendStringToPrinter(impresora, "\nN.L. C.P. 66260");
            RawPrinter.SendStringToPrinter(impresora, 
                $"{ticket.Fecha.ToShortDateString()} {DateTime.Now.ToShortTimeString()}");
            RawPrinter.SendStringToPrinter(impresora, "\n");

            RawPrinter.SendStringToPrinter(impresora,
                $"{ticket.Serie} Folio: {ticket.Folio}");

            RawPrinter.SendStringToPrinter(impresora, "\n");
            RawPrinter.SendStringToPrinter(impresora, "\n");
            RawPrinter.SendStringToPrinter(impresora, "CANT DESCRIPCION    P.UNIT   IMP");
            RawPrinter.SendStringToPrinter(impresora, "\n");
            RawPrinter.SendStringToPrinter(impresora, "--------------------------------");
            RawPrinter.SendStringToPrinter(impresora, "\n");

            foreach (var item in ticketArticulos)
            {
                RawPrinter.SendStringToPrinter(impresora,
                    $"\n{item.Cantidad,4} {item.Descripcion.PadRight(20).Substring(0, 20)}" +
                    $"{item.Precio,8:C} {item.TotalNeto,8:C}");
            }
            RawPrinter.SendStringToPrinter(impresora, "\n");
            RawPrinter.SendStringToPrinter(impresora, "\n");
            RawPrinter.SendStringToPrinter(impresora, $"TOTAL {ticket.Total:C}");
            if (pagado > 0)
            {
                RawPrinter.SendStringToPrinter(impresora, "\n");
                RawPrinter.SendStringToPrinter(impresora, "\n");
                RawPrinter.SendStringToPrinter(impresora, $"PAGADO {pagado:C}");

            }
            if (cambio > 0)
            {
                RawPrinter.SendStringToPrinter(impresora, "\n");
                RawPrinter.SendStringToPrinter(impresora, $"CAMBIO {cambio:C}");
            }

            List<Pago> pagos = UtilsInv.GetPagosVenta(ticket.VentaId);
            foreach (var pago in pagos)
            {
                string nombrePago = UtilsInv.GetNombreTipoPago(pago.Tipo);
                RawPrinter.SendStringToPrinter(impresora, "\n");
                RawPrinter.SendStringToPrinter(impresora, $"{nombrePago} {pago.Importe:C}");
            }

            for (int i = 0; i < 8; i++)
            {
                RawPrinter.SendStringToPrinter(impresora, "\n");
            }





        }

        public static async void ImprimeTicketPDV(Venta ticket, BindingList<VentaDetalle> ticketArticulos,
            bool imprimir = false, string impresora = "", bool mandarCorreo = false, string correos = "",
            decimal pagado=0,decimal cambio=0)
        {
            string datosSucursal = "";

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.SucursalSelect();
                Sucursal suc = db.Query<Sucursal>(sql, new { SucursalId = ticket.SucursalId }).FirstOrDefault();

                if (suc != null)
                {
                    datosSucursal = suc.DatosAdicionales;
                }
            }

            List<Pago> pagos = UtilsInv.GetPagosVenta(ticket.VentaId);
            decimal totalPagado = pagos.Sum(x => x.Importe);
            decimal cambioDado = totalPagado - ticket.Total;

            ticket.Total = ticket.Subtotal + ticket.IVA - ticket.Descuento; 

            List <Venta> datosTicket = new List<Venta> { ticket };


            List <ReportDataSource> reportDataSources = new List<ReportDataSource>();



            reportDataSources.Add(
                new ReportDataSource { Name = "dsTicket", Value = datosTicket }
            );

            foreach(var ren in ticketArticulos)
            {
                //ren.Total = ren.TotalNeto;
            }

            reportDataSources.Add(
                new ReportDataSource { Name = "dsDetalle", Value = ticketArticulos }
            );

            ReportViewer rptTicket = new ReportViewer();

            rptTicket.ProcessingMode = ProcessingMode.Local;
            rptTicket.LocalReport.ReportPath = General.GetCarpetaReportes() + @"\PDV\Ticket.rdlc";
            rptTicket.LocalReport.DataSources.Clear();

            foreach (var dato in reportDataSources)
            {
                rptTicket.LocalReport.DataSources.Add(dato);
            }

            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;

            string archivoPDF = GetTempPDF();


            ReportParameter datos = new ReportParameter("DatosSucursal", datosSucursal);




            ReportParameter[] parametros =
            {
                datos
            };

            rptTicket.LocalReport.EnableExternalImages = true;

            rptTicket.LocalReport.SetParameters(parametros);




            var deviceInfo = @"<DeviceInfo>
            <EmbedFonts>None</EmbedFonts>
            </DeviceInfo>";

            byte[] bytes = rptTicket.LocalReport.Render(
                 "PDF", deviceInfo, out mimeType, out encoding, out filenameExtension,
                 out streamids, out warnings);

            using (FileStream fs = new FileStream(archivoPDF, FileMode.Create))
            {
                fs.Write(bytes, 0, bytes.Length);
            }

            if (imprimir)
            {
                ImprimeTicketRaw(ticket, ticketArticulos, impresora, datosSucursal,totalPagado,cambioDado);

                //ImprimeArchivo(archivoPDF, impresora);
            }

            if (mandarCorreo)
            {
                await Task.Run(() => MandaCorreo(correos: correos, archivoPDF: archivoPDF));
            }



        }



        public static async void ImprimeTicket
            (Ingreso ing, BindingList<IngresoDetalle> conceptos,
            bool imprimir = false, string impresora = "", bool mandarCorreo = false, string correos = "")
        {

            string datosSucursal = "";

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.SucursalSelect();
                Sucursal suc = db.Query<Sucursal>(sql, new { SucursalId = ing.SucursalId }).FirstOrDefault();

                if (suc != null)
                {
                    datosSucursal = suc.DatosAdicionales;
                }
            }

            List<Ingreso> datosTicket = new List<Ingreso> { ing };


            List<ReportDataSource> reportDataSources = new List<ReportDataSource>();

            reportDataSources.Add(
                new ReportDataSource { Name = "dsIngreso", Value = datosTicket }
            );

            reportDataSources.Add(
                new ReportDataSource { Name = "dsDetalle", Value = conceptos }
            );

            ReportViewer rptTicket = new ReportViewer();

            rptTicket.ProcessingMode = ProcessingMode.Local;
            rptTicket.LocalReport.ReportPath = General.GetCarpetaReportes() + @"\Ingresos\Ticket.rdlc";
            rptTicket.LocalReport.DataSources.Clear();


            foreach (var dato in reportDataSources)
            {
                rptTicket.LocalReport.DataSources.Add(dato);
            }

            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;

            string archivoPDF = GetTempPDF();


            ReportParameter datos = new ReportParameter("DatosSucursal", datosSucursal);




            ReportParameter[] parametros =
            {
                datos
            };

            rptTicket.LocalReport.EnableExternalImages = true;

            rptTicket.LocalReport.SetParameters(parametros);




            var deviceInfo = @"<DeviceInfo>
            <EmbedFonts>None</EmbedFonts>
            </DeviceInfo>";

            byte[] bytes = rptTicket.LocalReport.Render(
                 "PDF", deviceInfo, out mimeType, out encoding, out filenameExtension,
                 out streamids, out warnings);

            using (FileStream fs = new FileStream(archivoPDF, FileMode.Create))
            {
                fs.Write(bytes, 0, bytes.Length);
            }

            if (imprimir)
            {
                ImprimeArchivo(archivoPDF, impresora);
            }

            if (mandarCorreo)
            {
                await Task.Run(() => MandaCorreo(correos: correos, archivoPDF: archivoPDF));
            }



        }

        private static string GetTempPDF()
        {
            string carpetaTemporal = System.IO.Path.GetTempPath();
            string archivoPDF = System.IO.Path.GetRandomFileName();
            archivoPDF = System.IO.Path.GetFileNameWithoutExtension(archivoPDF);
            archivoPDF = carpetaTemporal + archivoPDF + ".pdf";
            return archivoPDF;

        }


        public static async void IngresoFacturar(long ingresoId, bool imprimir = false, string impresora = "", bool mandarCorreos = false, string direcciones = "")
        {
            Ingreso ing = new Ingreso();

            List<IngresoDetalle> detalle = new List<IngresoDetalle>();

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.IngresoSelect();
                ing = db.Query<Ingreso>(sql, new { IngresoId = ingresoId }).FirstOrDefault();
                if (ing == null)
                {
                    return;
                }

                sql = Queries.IngresoDetallesSelect();

                detalle = db.Query<IngresoDetalle>(sql, new { IngresoId = ingresoId }).ToList();

            }


            ing.IngresoId = ingresoId;

            var conceptosOrdenados = new BindingList<IngresoDetalle>(detalle.OrderBy(x => x.EmisorId).ThenBy(x => x.Serie).ToList());

            int emisorId = conceptosOrdenados[0].EmisorId;
            string serie = conceptosOrdenados[0].Serie;

            List<IngresoDetalle> conceptos = new List<IngresoDetalle>();

            int res = 0;
            foreach (var concepto in conceptosOrdenados)
            {
                if (concepto.EmisorId != emisorId || concepto.Serie != serie)
                {

                    res = await Task.Run(() => GeneraFactura(ing, conceptos, imprimir, impresora, mandarCorreos, direcciones));
                    if (res != 0)
                    {
                        return;
                    }
                    emisorId = concepto.EmisorId;
                    serie = concepto.Serie;
                    conceptos = new List<IngresoDetalle>();
                }
                conceptos.Add(concepto);

            }

            res = await Task.Run(() => GeneraFactura(ing, conceptos, imprimir, impresora, mandarCorreos, direcciones));



        }

        public static int GeneraFacturaGlobal(Emisor emisor, List<IngresoNoFacturado> ingresos)
        {
            int res = 0;
            decimal subtotal = 0, iva = 0, total = 0;

            subtotal = ingresos.Sum(x => x.SubTotal);
            iva = ingresos.Sum(x => x.Impuesto);
            total = ingresos.Sum(x => x.Total);

            string sql = "";
            string serie = "";
            int folio = 0;

            using (FbConnection db = General.GetDB())
            {

                sql = Queries.SucursalSelect();

                Sucursal suc = db.Query<Sucursal>(sql, new { SucursalId = Properties.Settings.Default.SucursalId }).FirstOrDefault();

                if (suc == null)
                    return 1;

                serie = suc.SerieFacGlobal;
                folio = suc.FolioFacGlobal;

                if (string.IsNullOrEmpty(serie) || folio == 0)
                    return 1;

                CFDI cfdi = new CFDI();

                cfdi.EmisorId = emisor.EmisorId;
                cfdi.EmisorRFC = emisor.RFC;
                cfdi.EmisorNombre = emisor.Nombre;
                cfdi.EmisorRegimenFiscal = emisor.CveRef;
                cfdi.Serie = serie;
                cfdi.Folio = folio;
                cfdi.Fecha = DateTime.Now;
                cfdi.PacienteId = 0;
                cfdi.RazonSocialId = 0;
                cfdi.ReceptorRFC = "XAXX010101000";
                cfdi.ReceptorNombre = "PUBLICO EN GENERAL";
                cfdi.ReceptorRegimenFiscal = "616";
                cfdi.FormaPago = "01";
                cfdi.MetodoPago = "PUE";
                cfdi.UsoCFdi = "S01";
                cfdi.TipoComprobante = "I";
                cfdi.Moneda = "MXN";
                cfdi.LugarExpedicion = emisor.CP;
                cfdi.SubTotal = subtotal;
                cfdi.IVA = iva;
                cfdi.Total = total;

                ComprobanteCFDI comprobante = new ComprobanteCFDI();

                comprobante.Serie = serie;
                comprobante.Folio = folio;
                comprobante.Fecha = DateTime.Now;
                comprobante.FormaPago = "01";
                comprobante.MetodoPago = "PUE";
                comprobante.LugarExpedicion = emisor.CP;

                comprobante.ComprobanteEmisor.RFC = emisor.RFC;
                comprobante.ComprobanteEmisor.Nombre = emisor.Nombre;
                comprobante.ComprobanteEmisor.RegimenFiscal = emisor.CveRef;


                comprobante.Certificado = emisor.Certificado;
                comprobante.LlavePrivada = emisor.LlavePrivada;
                comprobante.PassWord = emisor.PassWord;

                comprobante.ComprobanteReceptor.RFC = "XAXX010101000";
                comprobante.ComprobanteReceptor.Nombre = "PUBLICO EN GENERAL";
                comprobante.ComprobanteReceptor.DomicilioFiscalReceptor = emisor.CP;
                comprobante.ComprobanteReceptor.RegimenFiscalReceptor = "616";
                comprobante.ComprobanteReceptor.UsoCFDI = "S01";



                List<CfdiDetalle> conceptos = new List<CfdiDetalle>();

                foreach (var ing in ingresos)
                {


                    decimal IVAExento = 0;
                    decimal IVA16 = 0;
                    decimal IVA0 = 0;

                    decimal BaseIVA16 = 0;
                    decimal BaseIVA0 = 0;
                    decimal BaseIVAExento = 0;

                    sql = Queries.IngresoDetallesSelect();
                    var ingresoDetalles = db.Query<IngresoDetalle>(sql, new { IngresoId = ing.IngresoId }).ToList();

                    foreach (var det in ingresoDetalles)
                    {
                        if (det.TipoIVA == 1)
                        {
                            if (det.TasaIVA == 16)
                            {
                                IVA16 = det.IVA;
                                BaseIVA16 = det.BaseIVA;
                            }
                            else
                            {
                                IVA0 = det.IVA;
                                BaseIVA0 = det.BaseIVA;
                            }
                        }
                        else
                        {
                            IVAExento = det.IVA;
                            BaseIVAExento = det.BaseIVA;
                        }

                    }

                    string noIden = "TIC";
                    string descripcion = $"TICKET {folio}";
                    string cveProSer = "01010101";
                    string cveUni = "ACT";

                    if (BaseIVAExento > 0)
                    {
                        CfdiDetalle det = new CfdiDetalle();
                        det.ArticuloId = ing.IngresoId;
                        det.NoIden = noIden;
                        det.Descripcion = descripcion + " IVA Exento";
                        det.Cantidad = 1;
                        det.ValorUnitario = BaseIVAExento;
                        det.CveProSer = cveProSer;
                        det.CveUni = cveUni;
                        det.Descuento = 0;
                        det.TipoIVA = 2;
                        det.TasaIVA = 0;
                        det.IVA = 0;
                        det.RetISR = 0;
                        det.RetIVA = 0;

                        conceptos.Add(det);

                    }


                    if (BaseIVA0 > 0)
                    {
                        CfdiDetalle det = new CfdiDetalle();
                        det.ArticuloId = ing.IngresoId;
                        det.NoIden = noIden;
                        det.Descripcion = descripcion + " IVA 0";
                        det.Cantidad = 1;
                        det.ValorUnitario = BaseIVA0;
                        det.CveProSer = cveProSer;
                        det.CveUni = cveUni;
                        det.Descuento = 0;
                        det.TipoIVA = 1;
                        det.TasaIVA = 0;
                        det.IVA = 0;
                        det.RetISR = 0;
                        det.RetIVA = 0;

                        conceptos.Add(det);
                    }


                    if (BaseIVA16 > 0)
                    {
                        CfdiDetalle det = new CfdiDetalle();
                        det.ArticuloId = ing.IngresoId;
                        det.NoIden = noIden;
                        det.Descripcion = descripcion + " IVA 16";
                        det.Cantidad = 1;
                        det.ValorUnitario = BaseIVA16;
                        det.CveProSer = cveProSer;
                        det.CveUni = cveUni;
                        det.Descuento = 0;
                        det.TipoIVA = 1;
                        det.TasaIVA = 16;
                        det.IVA = IVA16;
                        det.RetISR = 0;
                        det.RetIVA = 0;

                        conceptos.Add(det);

                    }





                    //////////////////

                    ConceptoCFDI conce = new ConceptoCFDI();

                    conce.NoIdentificacion = noIden;
                    conce.Descripcion = descripcion;
                    conce.Unidad = "ACT";
                    conce.Cantidad = 1;
                    conce.ValorUnitario = ing.SubTotal;
                    conce.ClaveProdServ = cveProSer;
                    conce.ClaveUnidad = cveUni;
                    conce.ObjetoImp = "02";



                    if (BaseIVA16 > 0)
                    {
                        DatosImpuestoCFDI tras = new DatosImpuestoCFDI();

                        tras.Impuesto = "002";
                        tras.TipoFactor = "Tasa";
                        tras.Base = BaseIVA16;
                        tras.Importe = IVA16;
                        tras.TasaOCuota = (decimal)0.16;
                        conce.Traslados.Add(tras);
                    }

                    if (BaseIVA0 > 0)
                    {
                        DatosImpuestoCFDI tras = new DatosImpuestoCFDI();

                        tras.Impuesto = "002";
                        tras.TipoFactor = "Tasa";
                        tras.Base = BaseIVA0;
                        tras.Importe = 0;
                        tras.TasaOCuota = 0;
                        conce.Traslados.Add(tras);
                    }

                    if (BaseIVAExento > 0)
                    {
                        DatosImpuestoCFDI tras = new DatosImpuestoCFDI();
                        tras.Base = BaseIVAExento;
                        tras.Impuesto = "002";
                        tras.TipoFactor = "Exento";
                        //tras.TasaOCuota = 0;
                        conce.Traslados.Add(tras);
                    }

                    comprobante.ComprobanteConceptos.Add(conce);



                    /////////////////////


                }

                comprobante.archivoXMLBase = GetTempXML();
                comprobante.archivoXMLFirmado = GetTempXML();
                comprobante.archivoXMLTimbrado = General.CarpetaCfdi(emisor.RFC, cfdi.Fecha) + General.NombreArchivoCfdi("FAG", serie, folio);

                comprobante.CreaXML();
                string resultado = comprobante.SellaXML();
                string xml = "";

                if (resultado != "0")
                {
                    return Convert.ToInt32(resultado);
                }
                else
                {
                    resultado = comprobante.TimbraSW();
                    if (resultado != "000")
                    {
                        return Convert.ToInt32(resultado);


                    }

                    if (File.Exists(comprobante.archivoXMLTimbrado))
                    {
                        xml = File.ReadAllText(comprobante.archivoXMLTimbrado);
                        cfdi.EmisorCSD = comprobante.GetEmisorCSD();


                        sql = Queries.SucursalSetSiguienteFolioGlobal();
                        db.Execute(sql, new { Properties.Settings.Default.SucursalId });

                        cfdi.uid = comprobante.GetFolioFiscal(xml);
                        cfdi.EmisorCSD = comprobante.GetEmisorCSD();

                        //int cfdiId = 0;
                        sql = Queries.CfdiInsert();
                        int cfdiId = db.ExecuteScalar<int>(sql, cfdi);

                        sql = Queries.CfdiDetalleInsert();

                        foreach (var det in conceptos)
                        {
                            det.CFDIId = cfdiId;
                            db.Execute(sql, det);
                        }

                        foreach (var ing in ingresos)
                        {
                            sql = Queries.IngresoSetFacturado;
                            db.Execute(sql, new { CFDiId=cfdiId, ing.IngresoId });
                        }

                        string archivoPDF = GeneraPDFFactura(cfdi, conceptos, xml);

                    }

                }


            }

            //////////

            return res;

        }


        public static async Task<int> GeneraFacturaGlobal(
            int sucursalId,
            long almacenId,
            Emisor emisor,
            List<Venta> ventas,
            bool detallada = false,
            DateTime? fechaFactura = null)
        {
            int res = 0;

            decimal subtotal = 0, iva = 0, total = 0;

            subtotal = ventas.Sum(x => x.Subtotal);
            iva = ventas.Sum(x => x.IVA);
            total = ventas.Sum(x => x.Total);

            string sql = "";

            string serie = "";
            int folio = 0;

            string seriePV = "";
            int folioPV = 0;




            using (FbConnection db = General.GetDB())
            {

                await db.OpenAsync();
                using (FbTransaction transaction = db.BeginTransaction())
                {
                    try
                    {

                        int formaPagoMayor = UtilsInv.GetFormaDePagomayor(ventas);
                        string cveFOP = UtilsInv.GetClaveFOP(formaPagoMayor);

                        sql = Queries.AlmacenSelect();
                        Almacen alma = db.Query<Almacen>(sql, new { AlmacenId = almacenId }, transaction).FirstOrDefault();


                        serie = alma.SerieVen;
                        folio = alma.FolioVen;
                        seriePV = alma.SerieFac;
                        folioPV = alma.FolioFac;

                        UtilsInv.AlmacenIncrementaFolioVenta(almacenId, db, transaction);


                        Venta vta = new Venta
                        {
                            SucursalId = sucursalId,
                            EmisorId = emisor.EmisorId,
                            AlmacenId = almacenId,
                            DoctorId = 0,
                            ClienteId = 0,
                            Tipo = "GLO",
                            Serie = serie,
                            Folio = folio,
                            Fecha = fechaFactura == null ? DateTime.Now : fechaFactura.Value,
                            FormaPago = cveFOP,
                            Moneda = "MXN",
                            TipoCambio = 1,
                            MetodoPago = "PUE",
                            LugarExpedicion = emisor.CP,
                            Uso = "S01",
                            Subtotal = subtotal,
                            Descuento = 0,
                            IVA = iva,
                            RetISR = 0,
                            RetIVA = 0,
                            Total = total,
                            SerieFac = seriePV,
                            FolioFac = folioPV,
                            WebId = "",
                            FechaFac = DateTime.Now
                        };


                        int ventaId = 0;
                        sql = Queries.VentaInsert;
                        ventaId = db.ExecuteScalar<int>(sql, vta, transaction);


                        vta.VentaId = ventaId;


                        foreach (var venta in ventas)
                        {

                            if (detallada)
                            {

                                sql = Queries.VentaDetallesSelect;
                                List<VentaDetalle> articulos = new List<VentaDetalle>();
                                articulos = db.Query<VentaDetalle>(sql, new { venta.VentaId }, transaction).ToList();

                                foreach (var art in articulos)
                                {
                                    sql = Queries.VentaDetalleInsert;
                                    art.VentaId = ventaId;
                                    art.TasaIVA = art.IVA > 0 ? 16 : 0;
                                    db.Execute(sql, art, transaction);
                                }



                            }
                            else
                            {
                                sql = Queries.VentaDetalleInsert;
                                VentaDetalle det = new VentaDetalle
                                {
                                    VentaId = ventaId,
                                    ArticuloId = 0,
                                    NoIden = "TIC",
                                    Descripcion = $"TICKET {venta.Folio}",
                                    CveProSer = "01010101",
                                    CveUni = "ACT",
                                    UDM = "ACT",
                                    Cantidad = 1,
                                    Precio = venta.Subtotal,
                                    IVA = venta.IVA,
                                    TipoIVA = 1
                                };
                                det.TasaIVA = det.IVA > 0 ? 16 : 0;
                                db.Execute(sql, det, transaction);
                            }
                        }

                        res = await GeneraFactura(vta, db, transaction, imprimir: false, impresora: "", mandarCorreos: false, direcciones: "", guardarClienteFactura: false);

                        if (res == 0)
                        {
                            sql = Queries.VentaUpdateFacturaGlobal;
                            foreach (var venta in ventas)
                            {
                                db.Execute(sql, new { FacturaGlobalId = vta.VentaId, venta.VentaId }, transaction);
                            }
                        }




                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        {
                            MessageBox.Show("Error generando factura global: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            transaction.Rollback();
                            return 1;
                        }
                    }
                }
                return res;
            }
        }
        


        public static async Task<int> GeneraNotaDeCredito(Venta nota,FbConnection db, FbTransaction transaction)
        {
            int res = 0;
            string sql = "";

            long emisorId = nota.EmisorId;
            bool publico = nota.ClienteId == 0;

            RazonSocial cliente = new RazonSocial();
            Emisor emi = new Emisor();
            List<VentaDetalle> conceptos = new List<VentaDetalle>();



            sql = Queries.RazonSocialSelect();

            if (publico == false)
            {
                cliente = db.Query<RazonSocial>(sql, new { RazonSocialId = nota.ClienteId },transaction).FirstOrDefault();
                if (cliente == null)
                    return 1;
            }

            sql = Queries.EmisorSelect();

            emi = db.Query<Emisor>(sql, new { EmisorId = emisorId },transaction).FirstOrDefault();

            if (emi == null)
                return 2;

            sql = Queries.VentaDetallesSelect;
            conceptos = db.Query<VentaDetalle>(sql, new { nota.VentaId },transaction).ToList();

            if (conceptos.Count == 0)
                return 3;
            

            decimal subTotal = 0;
            decimal descuento = 0;
            decimal retISR = 0;
            decimal retIVA = 0;
            decimal iva = 0;

            foreach (var conce in conceptos)
            {
                subTotal += Math.Round(conce.Cantidad * conce.Precio, 2);
                descuento += conce.Descuento;
                retISR += conce.RetISR;
                retIVA += conce.RetIVA;
                iva += conce.IVA;
            }




            ComprobanteCFDI comprobante = new ComprobanteCFDI();


            string cerTmp = Path.GetTempFileName() + ".cer";
            string llaveTmp = Path.GetTempFileName() + ".key";


            if (emi.Cer.Length > 0 && emi.Llave.Length > 0)
            {
                File.WriteAllBytes(cerTmp, emi.Cer);
                File.WriteAllBytes(llaveTmp, emi.Llave);
            }


            comprobante.Serie = nota.SerieFac;
            comprobante.Folio = nota.FolioFac;
            comprobante.Fecha = nota.FechaFac;
            comprobante.FormaPago = nota.FormaPago;
            comprobante.MetodoPago = nota.MetodoPago;
            comprobante.LugarExpedicion = nota.LugarExpedicion;
            comprobante.TipoComprobante = "E"; 

            comprobante.ComprobanteEmisor.RFC = emi.RFC;
            comprobante.ComprobanteEmisor.Nombre = emi.Nombre;
            comprobante.ComprobanteEmisor.RegimenFiscal = emi.CveRef;

            comprobante.Certificado = cerTmp;
            comprobante.LlavePrivada = llaveTmp;
            comprobante.PassWord = emi.PassWord;


            comprobante.ComprobanteReceptor.RFC = publico ? "XAXX010101000" : cliente.RFC;
            comprobante.ComprobanteReceptor.Nombre = publico ? "PUBLICO EN GENERAL" : cliente.RazonSoc;

            comprobante.ComprobanteReceptor.DomicilioFiscalReceptor = publico ? emi.CP : cliente.CP;
            comprobante.ComprobanteReceptor.RegimenFiscalReceptor = publico ? "616" : cliente.CveREF;
            comprobante.ComprobanteReceptor.UsoCFDI = publico ? "S01" : nota.Uso;


            if (string.IsNullOrEmpty(nota.UIDRel)==false)
            {
                comprobante.TipoRelacion = nota.CveRel;
                comprobante.CFDIsRelacionados.Add(new CFDiRelacionado
                {
                    UUID = nota.UIDRel.ToUpper().Trim()
                });
            }

            foreach (var concepto in conceptos)
            {
                ConceptoCFDI conce = new ConceptoCFDI
                {
                    NoIdentificacion = concepto.NoIden,
                    Descripcion = concepto.Descripcion,
                    Unidad = concepto.UDM,
                    Cantidad = concepto.Cantidad,
                    ValorUnitario = concepto.PrecioDes,
                    ClaveProdServ = concepto.CveProSer,
                    ClaveUnidad = concepto.CveUni,
                    ObjetoImp = "02"
                };

                DatosImpuestoCFDI tras = new DatosImpuestoCFDI
                {
                    Impuesto = "002"
                };

                if (concepto.TipoIVA == 1)
                {
                    tras.TipoFactor = "Tasa";
                    tras.TasaOCuota = concepto.IVA > 0 ? (decimal)0.16 : (decimal)0.00;
                }
                else
                {
                    tras.TasaOCuota = 0;
                    tras.TipoFactor = "Exento";

                }

                conce.Traslados.Add(tras);
                comprobante.ComprobanteConceptos.Add(conce);
            }

            string carpetaTemporal = Path.GetTempPath();
            string archivoXML = General.NombreArchivoCfdi("NDC", nota.SerieFac, nota.FolioFac);

            comprobante.archivoXMLBase = GetTempXML();
            comprobante.archivoXMLFirmado = GetTempXML();
            comprobante.archivoXMLTimbrado = $@"{carpetaTemporal}\{archivoXML}"; //General.CarpetaFacturaPDV(emi.RFC, nota.FechaFac) + 
            comprobante.CreaXML();

            string resultado = comprobante.SellaXML();

            string xml = "";



            if (resultado != "0")
            {
                MessageBox.Show($"Una nota no se pudo timbrar: {resultado}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 3;
            }
            resultado = comprobante.TimbraSW();
            if (resultado != "000")
            {
                MessageBox.Show($"Una nota no se pudó timbrar {resultado} ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 4;
            }

            if (File.Exists(comprobante.archivoXMLTimbrado))
            {
                xml = File.ReadAllText(comprobante.archivoXMLTimbrado);
                sql = "";

                string uid = comprobante.GetFolioFiscal(xml);
                string csd = comprobante.GetEmisorCSD();

                sql = Queries.VentaUpdateTimbrado;


                using (FbCommand cmd = new FbCommand(sql, db, transaction))
                {
                    cmd.Parameters.AddWithValue("uid", uid);
                    cmd.Parameters.AddWithValue("csd", csd);
                    cmd.Parameters.AddWithValue("xml", xml);
                    cmd.Parameters.AddWithValue("VentaId", nota.VentaId);
                    await cmd.ExecuteNonQueryAsync();
                }


                nota.UID = uid;
                nota.CSD = csd;
                nota.xml = xml;


            }

            if (File.Exists(cerTmp))
            {
                File.Delete(cerTmp);
            }
            if (File.Exists(llaveTmp))
            {
                File.Delete(llaveTmp);
            }

            return res;
        }

        public static async Task<int> GeneraFactura(Venta vta, FbConnection db, FbTransaction fbTransaction,
            bool imprimir = false, string impresora = "",
            bool mandarCorreos = false, string direcciones = "",
            bool guardarClienteFactura=false, bool incrementaFolioFactura = true)
        {
            int res = 0;
            long emisorId = vta.EmisorId;
            bool publico = vta.ClienteId == 0;

            RazonSocial cliente = new RazonSocial();
            Emisor emi = new Emisor();
            List<VentaDetalle> conceptos = new List<VentaDetalle>();

            string sql = Queries.RazonSocialSelect();

            if (publico == false)
            {
                cliente = db.Query<RazonSocial>(sql, new { RazonSocialId = vta.ClienteId }, fbTransaction).FirstOrDefault();
                if (cliente == null)
                    return 1;   
            }

            sql = Queries.EmisorSelect();

            emi = db.Query<Emisor>(sql, new { EmisorId = emisorId },fbTransaction).FirstOrDefault();

            if (emi == null)
                return 2;

            sql = Queries.VentaDetallesSelect;
            conceptos = db.Query<VentaDetalle>(sql, new { vta.VentaId },fbTransaction).ToList();

            if (conceptos.Count == 0)
                return 3;

            decimal subTotal = 0;
            decimal descuento = 0;
            decimal retISR = 0;
            decimal retIVA = 0;
            decimal iva = 0;
            decimal total = 0;

            foreach (var conce in conceptos)
            {
                subTotal += Math.Round(conce.Cantidad * conce.Precio, 2);
                descuento += conce.Descuento;
                retISR += conce.RetISR;
                retIVA += conce.RetIVA;
                iva += conce.IVA;
            }
            


            total = subTotal - descuento + iva - retISR - retIVA;



            ComprobanteCFDI comprobante = new ComprobanteCFDI();

            string cerTmp = Path.GetTempFileName() + ".cer";
            string llaveTmp = Path.GetTempFileName() + ".key";
            bool existsTempFiles = false;


            if (emi.Cer.Length > 0 && emi.Llave.Length > 0)
             {
                 File.WriteAllBytes(cerTmp, emi.Cer);
                 File.WriteAllBytes(llaveTmp, emi.  Llave);
                existsTempFiles = true;
             }




            comprobante.Serie = vta.SerieFac;
            comprobante.Folio = vta.FolioFac;
            comprobante.Fecha = vta.FechaFac;
            comprobante.FormaPago = vta.FormaPago;
            comprobante.MetodoPago = vta.MetodoPago;
            comprobante.LugarExpedicion = vta.LugarExpedicion;

            comprobante.ComprobanteEmisor.RFC = emi.RFC;
            comprobante.ComprobanteEmisor.Nombre = emi.Nombre;
            comprobante.ComprobanteEmisor.RegimenFiscal = emi.CveRef;

            comprobante.Certificado =  existsTempFiles?cerTmp: emi.Certificado;
            comprobante.LlavePrivada = existsTempFiles?llaveTmp: emi.LlavePrivada;

            comprobante.PassWord = emi.PassWord;


            comprobante.ComprobanteReceptor.RFC = publico? "XAXX010101000": cliente.RFC;
            comprobante.ComprobanteReceptor.Nombre =publico? "PUBLICO EN GENERAL": cliente.RazonSoc;

            comprobante.ComprobanteReceptor.DomicilioFiscalReceptor = publico ? emi.CP: cliente.CP;
            comprobante.ComprobanteReceptor.RegimenFiscalReceptor = publico?"616": cliente.CveREF;
            comprobante.ComprobanteReceptor.UsoCFDI = publico?"S01": vta.Uso;

            foreach (var concepto in conceptos)
            {
                ConceptoCFDI conce = new ConceptoCFDI
                {
                    NoIdentificacion = concepto.NoIden,
                    Descripcion = concepto.Descripcion,
                    Unidad = concepto.UDM,
                    Cantidad = concepto.Cantidad,
                    ValorUnitario = concepto.PrecioDes,
                    ClaveProdServ = concepto.CveProSer,
                    ClaveUnidad = concepto.CveUni,
                    ObjetoImp = "02"
                };

                DatosImpuestoCFDI tras = new DatosImpuestoCFDI
                {
                    Impuesto = "002"
                };

                if (concepto.TipoIVA == 1)
                {
                    tras.TipoFactor = "Tasa";
                    tras.TasaOCuota = concepto.IVA>0?(decimal)0.16:(decimal)0.00;
                }
                else
                {
                    tras.TasaOCuota = 0;
                    tras.TipoFactor = "Exento";

                }

                conce.Traslados.Add(tras);
                comprobante.ComprobanteConceptos.Add(conce);
            }

            string carpetaTemporal = System.IO.Path.GetTempPath();  
            string archivoXML = General.NombreArchivoCfdi("FAC", vta.SerieFac, vta.FolioFac);
            comprobante.archivoXMLBase = GetTempXML();
            comprobante.archivoXMLFirmado = GetTempXML();

            comprobante.archivoXMLTimbrado = $@"{carpetaTemporal}\{archivoXML}";
            comprobante.CreaXML();

            string resultado = comprobante.SellaXML();
            string xml = "";


            if (resultado != "0")
            {
                MessageBox.Show($"Una factura no se pudo sellar: {resultado}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 4;
            }

            resultado = comprobante.TimbraSW();

            if (resultado != "000")
            {
                MessageBox.Show($"Una factura no se pudó timbrar {resultado} ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 5;
            }


            if (File.Exists(comprobante.archivoXMLTimbrado)== false)
            {
                MessageBox.Show($"Una factura no se pudó timbrar {resultado} ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 6;
            }

            xml = File.ReadAllText(comprobante.archivoXMLTimbrado);

            string uid = comprobante.GetFolioFiscal(xml);
            string csd = comprobante.GetEmisorCSD();

            sql = Queries.VentaUpdateTimbrado;

               
            using (FbCommand cmd = new FbCommand(sql, db,fbTransaction))
            {
                cmd.Parameters.AddWithValue("uid", uid);
                cmd.Parameters.AddWithValue("csd", csd);
                cmd.Parameters.AddWithValue("xml", xml);
                cmd.Parameters.AddWithValue("VentaId", vta.VentaId);
                await cmd.ExecuteNonQueryAsync();
            }

            vta.UID = uid;
            vta.CSD = csd;
            vta.xml = xml;

            if (guardarClienteFactura)
            {
                sql = Queries.VentaSetDatosFacturacion;
                db.Execute(sql, vta,fbTransaction);
            }

            

            if (incrementaFolioFactura)
            {
                UtilsInv.AlmacenIncrementaFolioFactura(vta.AlmacenId, db, fbTransaction);

            }

            string archivoPDF = GeneraPDFFacturaPDV(vta, conceptos,carpetaTemporal);

            if (imprimir)
            {
                ImprimeArchivo(archivoPDF, impresora);
            }
            archivoXML = comprobante.archivoXMLTimbrado;


            if (mandarCorreos)
            {
                await MandaCorreo(direcciones, archivoXML, archivoPDF);
            }


            if (File.Exists(cerTmp))
                File.Delete(cerTmp);

            if (File.Exists(llaveTmp))
                File.Delete(llaveTmp);

            if (File.Exists(comprobante.archivoXMLBase))
                File.Delete(comprobante.archivoXMLBase);

            if (File.Exists(comprobante.archivoXMLFirmado))
                File.Delete(comprobante.archivoXMLFirmado);

            if (File.Exists(comprobante.archivoXMLTimbrado))
                File.Delete(comprobante.archivoXMLTimbrado);

            if (File.Exists(archivoXML))
                File.Delete(archivoXML);

            if (File.Exists(archivoPDF))
                File.Delete(archivoPDF);

            return res;
        }

        private static async Task<int>  GeneraFactura(Ingreso ing,
            List<IngresoDetalle> conceptos,bool imprimir=false, string impresora="",
            bool mandarCorreos = false, string direcciones = "")
        {

            int emisorId = conceptos[0].EmisorId;
            string serie = conceptos[0].Serie;
            int folioFac = 0;
            string tipoDoc = "FAC";
            bool publico = ing.RazonSocialId == 0;

            RazonSocial razonSocial = new RazonSocial();
            Emisor emi = new Emisor();

            int serieId = 0;

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.SerieDocSelectXEmisorTipoSerie();
                SerieDoc serDoc = db.Query<SerieDoc>(sql, new {EmisorId=emisorId,Tipo =tipoDoc, Serie=serie }).FirstOrDefault();

                if (serDoc == null)
                    return 1;

                folioFac = serDoc.Folio;

                serieId = serDoc.SerieDocId;


                sql = Queries.RazonSocialSelect();

                if (publico == false)
                {
                    razonSocial = db.Query<RazonSocial>(sql, new { RazonSocialId = ing.RazonSocialId }).FirstOrDefault();
                }


                sql = Queries.EmisorSelect();

                emi = db.Query<Emisor>(sql, new { EmisorId = emisorId }).FirstOrDefault();

                if (emi == null)
                    return 1;
            }

            decimal subTotal = 0;
            decimal descuento = 0;
            decimal retISR = 0;
            decimal retIVA = 0;
            decimal iva = 0;
            decimal total = 0;

            foreach (var conce in conceptos)
            {
                subTotal += Math.Round(conce.Cantidad * conce.Precio, 2);
                descuento += conce.Descuento;
                retISR += conce.RetISR;
                retIVA += conce.RetIVA;
                iva += conce.IVA;
            }

            total = subTotal - descuento + iva - retISR -retIVA;

            CFDI cfdi = new CFDI();

            cfdi.IngresoId = ing.IngresoId;
            cfdi.EmisorId = emisorId;
            cfdi.EmisorRFC = emi.RFC;
            cfdi.EmisorNombre= emi.Nombre;
            cfdi.EmisorRegimenFiscal = emi.CveRef;
            cfdi.Serie = serie;
            cfdi.Folio = folioFac;
            cfdi.Fecha = DateTime.Now; //ing.Fecha;
            cfdi.PacienteId= ing.PacienteId;
            



            if (publico)
            {
                cfdi.RazonSocialId = 0;
                cfdi.ReceptorRFC = "XAXX010101000";
                cfdi.ReceptorNombre = "PUBLICO EN GENERAL";
                cfdi.ReceptorRegimenFiscal = "616";
                cfdi.FormaPago = ing.CveFOP;
                cfdi.MetodoPago = ing.CveMEP;
                cfdi.UsoCFdi = "S01";
            }
            else
            {
                string ciudad = General.GetDescripcion("CIU", razonSocial.CiudadId);
                string estado = General.GetDescripcion("EDO", razonSocial.EstadoId);                
                cfdi.RazonSocialId = ing.RazonSocialId;
                cfdi.ReceptorRFC = razonSocial.RFC;
                cfdi.ReceptorNombre = razonSocial.RazonSoc;
                cfdi.ReceptorDireccion = $"{razonSocial.Direccion.Trim()} {ciudad.Trim()} {estado.Trim()} {razonSocial.CP}";

                cfdi.ReceptorRegimenFiscal = razonSocial.CveREF;
                cfdi.FormaPago = ing.CveFOP;
                cfdi.MetodoPago = ing.CveMEP;
                cfdi.UsoCFdi = ing.CveUSO;

            }





            cfdi.TipoComprobante = "I";
            cfdi.Moneda = "MXN";
            cfdi.LugarExpedicion = emi.CP;
            cfdi.SubTotal = subTotal;
            cfdi.Descuento = descuento;
            cfdi.RetISR = retISR;
            cfdi.RetIVA= retIVA;
            cfdi.IVA = iva;
            cfdi.Total = total;



            ComprobanteCFDI comprobante = new ComprobanteCFDI();

            comprobante.Serie = cfdi.Serie;
            comprobante.Folio = folioFac;
            comprobante.Fecha = cfdi.Fecha;
            comprobante.FormaPago = cfdi.FormaPago;
            comprobante.MetodoPago= cfdi.MetodoPago;
            comprobante.LugarExpedicion= cfdi.LugarExpedicion;

            comprobante.ComprobanteEmisor.RFC = emi.RFC;
            comprobante.ComprobanteEmisor.Nombre = emi.Nombre;
            comprobante.ComprobanteEmisor.RegimenFiscal = emi.CveRef;

            comprobante.Certificado = emi.Certificado;
            comprobante.LlavePrivada   = emi.LlavePrivada;
            comprobante.PassWord = emi.PassWord;

            comprobante.ComprobanteReceptor.RFC = cfdi.ReceptorRFC;
            comprobante.ComprobanteReceptor.Nombre = cfdi.ReceptorNombre;
            comprobante.ComprobanteReceptor.DomicilioFiscalReceptor = publico?cfdi.LugarExpedicion:razonSocial.CP;
            comprobante.ComprobanteReceptor.RegimenFiscalReceptor = cfdi.ReceptorRegimenFiscal;
            comprobante.ComprobanteReceptor.UsoCFDI = cfdi.UsoCFdi;

            foreach (var concepto in conceptos)
            {
                ConceptoCFDI conce = new ConceptoCFDI();

                conce.NoIdentificacion = concepto.Clave;
                conce.Descripcion = concepto.Descripcion;
                conce.Unidad = concepto.UDM;
                conce.Cantidad = concepto.Cantidad;
                conce.ValorUnitario = concepto.Precio;
                conce.ClaveProdServ = concepto.CveProSer;
                conce.ClaveUnidad = concepto.CveUni;
                conce.ObjetoImp = "02";

                DatosImpuestoCFDI tras = new DatosImpuestoCFDI();

                tras.Impuesto = "002";

                if (concepto.TipoIVA == 1)
                {
                    tras.TipoFactor = "Tasa";
                    tras.TasaOCuota = (decimal)0.16;
                }
                else
                {
                    tras.TipoFactor = "Exento";

                }
                conce.Traslados.Add(tras);

                if (concepto.RetISR > 0)
                {
                    DatosImpuestoCFDI ret = new DatosImpuestoCFDI();
                    ret.Impuesto = "001";
                    ret.TipoFactor = "Tasa";
                    ret.TasaOCuota = concepto.PorceRetISR;
                    conce.Retenciones.Add(ret);

                }

                if (concepto.RetIVA > 0)
                {
                    DatosImpuestoCFDI ret = new DatosImpuestoCFDI();
                    ret.Impuesto = "002";
                    ret.TipoFactor = "Tasa";
                    ret.TasaOCuota = concepto.PorceRetIVA;
                    conce.Retenciones.Add(ret);

                }


                comprobante.ComprobanteConceptos.Add(conce);
            }

            List<CfdiDetalle> cfdiDetalle = new List<CfdiDetalle>();


            comprobante.archivoXMLBase = GetTempXML();
            comprobante.archivoXMLFirmado = GetTempXML();
            comprobante.archivoXMLTimbrado = General.CarpetaCfdi(emi.RFC,cfdi.Fecha) + General.NombreArchivoCfdi(tipoDoc,serie,folioFac);

            comprobante.CreaXML();
            string res  = comprobante.SellaXML();
            string xml = "";

            if (res != "0")
            {
                MessageBox.Show($"Una factura no se pudo timbrar: {res}","Aviso", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                res = comprobante.TimbraSW();
                if (res != "000")
                {
                    MessageBox.Show($"Una factura no se pudó timbrar {res} ", "Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return 1;


                }

                if (File.Exists(comprobante.archivoXMLTimbrado))
                {
                    xml = File.ReadAllText(comprobante.archivoXMLTimbrado);
                    cfdi.EmisorCSD = comprobante.GetEmisorCSD();

                    using (FbConnection db = General.GetDB())
                    {
                        string sql = "";
                        sql = Queries.SerieFolioIncrementa();
                        db.Execute(sql, new { SerieDocId = serieId });

                        cfdi.uid = comprobante.GetFolioFiscal(xml);
                        cfdi.EmisorCSD = comprobante.GetEmisorCSD();


                        int cfdiId = 0;
                        sql = Queries.CfdiInsert();
                        cfdiId = db.ExecuteScalar<int>(sql, cfdi);


                        foreach (var det in conceptos)
                        {
                            CfdiDetalle newDet = new CfdiDetalle();
                            newDet.CFDIId = cfdiId;
                            newDet.ArticuloId = det.ArticuloId;
                            newDet.NoIden = det.Clave;
                            newDet.Descripcion = det.Descripcion;
                            newDet.Cantidad = det.Cantidad;
                            newDet.ValorUnitario = det.Precio;
                            newDet.CveProSer = det.CveProSer;
                            newDet.CveUni = det.CveUni;
                            newDet.Descuento = det.Descuento;
                            newDet.TipoIVA = det.TipoIVA;
                            newDet.TasaIVA = det.TasaIVA;
                            newDet.IVA = det.IVA;
                            newDet.RetISR = det.RetISR;
                            newDet.RetIVA = det.RetIVA;

                            cfdiDetalle.Add(newDet);

                            sql = Queries.CfdiDetalleInsert();
                            db.Execute(sql, newDet);

                        }


                    }

                }


            }



            string archivoPDF=  GeneraPDFFactura(cfdi, cfdiDetalle,xml);

            if (imprimir)
            {
                ImprimeArchivo(archivoPDF, impresora);
            }
            
            if (mandarCorreos)
            {
                await MandaCorreo(direcciones, comprobante.archivoXMLTimbrado, archivoPDF);
            }
            return 0;


        }

        public static string GetTempXML()
        {
            string carpetaTemporal = Path.GetTempPath();
            string archivoXML = Path.GetRandomFileName();
            archivoXML = Path.GetFileNameWithoutExtension(archivoXML);
            archivoXML = carpetaTemporal + archivoXML+".xml";
            return archivoXML;

        }

        public static string GetTempCBB()
        {
            string carpetaTemporal = Path.GetTempPath();
            string archivoCBB = Path.GetRandomFileName();
            archivoCBB = Path.GetFileNameWithoutExtension(archivoCBB);
            archivoCBB = carpetaTemporal + archivoCBB + ".png";
            return archivoCBB;

        }


        public static string GeneraPDFComplementoDePago(long complementoId,string carpetaDestino="")
        {

            ComplementoPago complemento = new ComplementoPago();
            List<ComPagRel> relacionados = new List<ComPagRel>();
            Emisor emisor = new Emisor();
            RazonSocial receptor = new RazonSocial();

            string datosSucursal = string.Empty;
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.ComplementoDePagoSelect;
                complemento = db.Query<ComplementoPago>(sql, new { CompagId = complementoId }).FirstOrDefault();

                if (complemento == null || string.IsNullOrEmpty(complemento.xml))
                    return "";

                sql = Queries.ComPagRelsSelect;
                relacionados = db.Query<ComPagRel>(sql, new { ComPagoId = complementoId }).ToList();

                if (relacionados.Count == 0)
                    return "";


                sql = Queries.SucursalSelect();
                Sucursal suc = db.Query<Sucursal>(sql, new { SucursalId = 1 }).FirstOrDefault();

                if (suc != null)
                    datosSucursal = suc.DatosAdicionales;


                sql = Queries.EmisorSelect();
                emisor = db.Query<Emisor>(sql, new {complemento.EmisorId }).FirstOrDefault();

                sql = Queries.RazonSocialSelect();
                receptor = db.Query<RazonSocial>(sql, new { complemento.RazonSocialId }).FirstOrDefault();
            }



            string ciudad = General.GetDescripcion("CIU", receptor.CiudadId);
            string estado = General.GetDescripcion("EDO", receptor.EstadoId);

            string receptorRFC = receptor.RFC;
            string receptorNombre = receptor.RazonSoc;
            string receptorRegimen = $"{receptor.CveREF}:{General.GetDescripcionClaveSAT("REF", receptor.CveREF)}";
            string receptorDireccion = $"{receptor.Direccion.Trim()} {ciudad.Trim()} {estado.Trim()} {receptor.CP}";
            string formaPago = $"{complemento.CveFOP}:{General.GetDescripcionClaveSAT("FOP", complemento.CveFOP)}";

            List<ComplementoPago> datosPago = new List<ComplementoPago>
            {
                complemento
            };


            List<ReportDataSource> reportDataSources = new List<ReportDataSource>();

            reportDataSources.Add(
                new ReportDataSource { Name = "dsDatosPago", Value = datosPago }
            );

            reportDataSources.Add(
                new ReportDataSource { Name = "dsDocumentosRelacionados", Value = relacionados }
            );


            ReportViewer rptComplemento = new ReportViewer();

            rptComplemento.ProcessingMode = ProcessingMode.Local;
            string formatoComplemento = "ComplementoDePago";
            string rep = General.GetCarpetaReportes() + $@"\PDV\{formatoComplemento}.rdlc";
            rptComplemento.LocalReport.ReportPath = rep;

            rptComplemento.LocalReport.DataSources.Clear();


            foreach (var dato in reportDataSources)
            {
                rptComplemento.LocalReport.DataSources.Add(dato);
            }

            Conversion con = new Conversion();
            string let = con.enletras(complemento.Monto);
            string cadenaSAT = "";
            string selloCFD = "";
            string selloSAT = "";
            string certificadoSAT = "";
            string rfcPAC = "";
            string fechaTimbrado = "";
            string csd = "";


            ComprobanteCFDI comprobante = new ComprobanteCFDI();
            selloCFD = comprobante.GetSelloDigital(complemento.xml);
            selloSAT = comprobante.GetSelloSAT(complemento.xml);
            certificadoSAT = comprobante.GetCertificadoSAT(complemento.xml);
            rfcPAC = comprobante.GetRFCPAC(complemento.xml);
            fechaTimbrado = comprobante.GetFechaTimbrado(complemento.xml);
            csd = comprobante.GetEmisorCSD(complemento.xml);

            cadenaSAT = $"||1.1|{complemento.UID}{fechaTimbrado}|{selloCFD}|{certificadoSAT}||";
            


            string cadenaCBB = $"https://verificacfdi.facturaelectronica.sat.gob.mx/?id={complemento.UID}&re={emisor.RFC}";
            cadenaCBB += $"&rr={receptorRFC}&tt={complemento.Monto.ToString().Trim()}&fe={selloCFD.Substring(selloCFD.Length - 7)}";

            string archCBB = GetTempCBB();
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(cadenaCBB, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);

            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            qrCodeImage.Save(archCBB, System.DrawingCore.Imaging.ImageFormat.Png);



            ReportParameter emiRFC = new ReportParameter("EmisorRFC", emisor.RFC);
            ReportParameter emiNom = new ReportParameter("EmisorNombre", emisor.Nombre);
            ReportParameter emiRef = new ReportParameter("EmisorRegimen", emisor.CveRef);

            ReportParameter recRFC = new ReportParameter("ReceptorRFC", receptorRFC);
            ReportParameter recNom = new ReportParameter("ReceptorNombre", receptorNombre);
            receptorDireccion = string.IsNullOrEmpty(receptorDireccion) ? "." : receptorDireccion;
            ReportParameter recDir = new ReportParameter("ReceptorDireccion", receptorDireccion);
            ReportParameter recRef = new ReportParameter("ReceptorRegimen", receptorRegimen);




            ReportParameter folioCompleto = new ReportParameter("FolioCompleto", $"{complemento.Serie.Trim()} {complemento.Folio}");
            ReportParameter lugarFecha = new ReportParameter("LugarFecha", $"CP {emisor.CP.Trim()}   {complemento.Fecha.ToShortDateString()}");
            ReportParameter letras = new ReportParameter("Letras", let);

            ReportParameter cadenaOriginal = new ReportParameter("CadenaOriginal", cadenaSAT);
            ReportParameter selloC = new ReportParameter("SelloCFD", selloCFD);
            ReportParameter selloS = new ReportParameter("SelloSAT", selloSAT);
            ReportParameter rfcP = new ReportParameter("RFCPAC", rfcPAC);
            ReportParameter fechaTim = new ReportParameter("FechaTimbrado", fechaTimbrado);
            ReportParameter fop = new ReportParameter("FormaDePago", formaPago);



            ReportParameter cbb = new ReportParameter("cbb", new Uri(archCBB).AbsoluteUri);
            ReportParameter datosAdicionales = new ReportParameter("DatosSucursal", datosSucursal);
            ReportParameter emisorCSD = new ReportParameter("CSD", csd);





            ReportParameter[] parametros =
            {
                emiRFC,
                emiNom,
                emiRef,
                recRFC,
                recNom,
                recDir,
                recRef,
                folioCompleto,
                lugarFecha,
                letras,
                cadenaOriginal,
                selloC,
                selloS,
                rfcP,
                fechaTim,
                cbb,
                datosAdicionales,
                fop,
                emisorCSD
            };

            rptComplemento.LocalReport.EnableExternalImages = true;

            rptComplemento.LocalReport.SetParameters(parametros);

            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;


            string archivoPDF = 
                string.IsNullOrEmpty(carpetaDestino) ? General.CarpetaFacturaPDV(emisor.RFC, complemento.Fecha) : 
                carpetaDestino + @"\" + General.NombreArchivoPDF("CPG", complemento.Serie, complemento.Folio);


            var deviceInfo = @"<DeviceInfo>
            <EmbedFonts>None</EmbedFonts>
            </DeviceInfo>";

            byte[] bytes = rptComplemento.LocalReport.Render(
                "PDF", deviceInfo, out mimeType, out encoding, out filenameExtension,
                out streamids, out warnings);


            try
            {
                using (FileStream fs = new FileStream(archivoPDF, FileMode.Create))
                {
                    fs.Write(bytes, 0, bytes.Length);
                }

            }
            catch (Exception err)
            {

                MessageBox.Show($"No se pudo generar el PDF del complemento de pago\\n{err.Message}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (File.Exists(archCBB))
                File.Delete(archCBB);


            return archivoPDF;



        }

        public static string GeneraPDFNotaDeCreditoPDV(Venta nota, List<VentaDetalle> detalle, string carpetaDestino="")
        {
            long emisorId = nota.EmisorId;
            string serie = nota.Serie;
            int folio = nota.Folio;
            string receptorRFC = "";
            string receptorNombre = "";
            string receptorDireccion = "";
            string receptorRegimen = "";
            string formaPago = "";
            string metodoPago = "";
            string usoCFDI = "";


            Emisor emi = new Emisor();

            string datosSucursal = "";
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.EmisorSelect();
                emi = db.Query<Emisor>(sql, new { EmisorId = emisorId }).FirstOrDefault();

                if (emi == null)
                    return "";

                sql = Queries.SucursalSelect();
                Sucursal suc = db.Query<Sucursal>(sql, new { nota.SucursalId }).FirstOrDefault();
                if (suc != null)
                    datosSucursal = suc.DatosAdicionales;


                if (nota.ClienteId == 0)
                {
                    receptorRFC = "XAXX010101000";
                    receptorNombre = "PUBLICO EN GENERAL";
                    receptorRegimen = "616";

                }
                else
                {


                    sql = Queries.RazonSocialSelect();
                    RazonSocial razonSocial = db.Query<RazonSocial>(sql, new { RazonSocialId = nota.ClienteId }).FirstOrDefault();
                    if (razonSocial == null)
                        return "";

                    string ciudad = General.GetDescripcion("CIU", razonSocial.CiudadId);
                    string estado = General.GetDescripcion("EDO", razonSocial.EstadoId);

                    receptorRFC = razonSocial.RFC;
                    receptorNombre = razonSocial.RazonSoc;
                    receptorRegimen = $"{razonSocial.CveREF}:{General.GetDescripcionClaveSAT("REF", razonSocial.CveREF)}";
                    receptorDireccion = $"{razonSocial.Direccion.Trim()} {ciudad.Trim()} {estado.Trim()} {razonSocial.CP}";
                    formaPago = $"{nota.FormaPago}:{General.GetDescripcionClaveSAT("FOP", nota.FormaPago)}";
                    metodoPago = $"{nota.MetodoPago}:{General.GetDescripcionClaveSAT("MEP", nota.MetodoPago)}";
                    usoCFDI = $"{nota.Uso}:{General.GetDescripcionClaveSAT("USO", nota.Uso)}";

                }

            }


            List<Venta> datosFactura = new List<Venta>();
            nota.Total = nota.Subtotal + nota.IVA - nota.Descuento;
            datosFactura.Add(nota);


            List<ReportDataSource> reportDataSources = new List<ReportDataSource>();

            reportDataSources.Add(
                new ReportDataSource { Name = "dsDatosFactura", Value = datosFactura }
            );

            foreach (var ren in detalle)
            {
                ren.Precio = ren.PrecioDes;
            }
            reportDataSources.Add(
                new ReportDataSource { Name = "dsDetalleFactura", Value = detalle }
            );

            // PreVerReporte reporte = new PreVerReporte($@"{carpetaReportes}\Expedientes\Expediente.rdlc", reportDataSources, "Expediente");
            ReportViewer rptFactura = new ReportViewer();

            rptFactura.ProcessingMode = ProcessingMode.Local;
            rptFactura.LocalReport.ReportPath = @"C:\Users\Felipe  Juan\source\repos\ClinicaFB\ClinicaFB\Reportes\Ingresos\Factura.rdlc";
            string rep = General.GetCarpetaReportes() + @"\PDV\NotaDeCredito.rdlc";
            rptFactura.LocalReport.ReportPath = rep; // @"C:\Users\Felipe  Juan\source\repos\ClinicaFB\ClinicaFB\Reportes\Ingresos\Factura.rdlc";

            rptFactura.LocalReport.DataSources.Clear();


            foreach (var dato in reportDataSources)
            {
                rptFactura.LocalReport.DataSources.Add(dato);
            }

            Conversion con = new Conversion();
            string let = con.enletras(nota.Subtotal + nota.IVA - nota.Descuento);
            string cadenaSAT = "";
            string selloCFD = "";
            string selloSAT = "";
            string certificadoSAT = "";
            string rfcPAC = "";
            string fechaTimbrado = "";

            if (string.IsNullOrEmpty(nota.xml) == false)
            {
                ComprobanteCFDI comprobante = new ComprobanteCFDI();
                selloCFD = comprobante.GetSelloDigital(nota.xml);
                selloSAT = comprobante.GetSelloSAT(nota.xml);
                certificadoSAT = comprobante.GetCertificadoSAT(nota.xml);
                rfcPAC = comprobante.GetRFCPAC(nota.xml);
                fechaTimbrado = comprobante.GetFechaTimbrado(nota.xml);

                cadenaSAT = $"||1.1|{nota.UID}{fechaTimbrado}|{selloCFD}|{certificadoSAT}||";
            }


            string cadenaCBB = $"https://verificacfdi.facturaelectronica.sat.gob.mx/?id={nota.UID}&re={emi.RFC}";
            cadenaCBB += $"&rr={receptorRFC}&tt={nota.Total.ToString().Trim()}&fe={nota.CSD.Substring(nota.CSD.Length - 7)}";

            string archCBB = GetTempCBB();
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(cadenaCBB, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);

            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            qrCodeImage.Save(archCBB, System.DrawingCore.Imaging.ImageFormat.Png);



            ReportParameter emiRFC = new ReportParameter("EmisorRFC", emi.RFC);
            ReportParameter emiNom = new ReportParameter("EmisorNombre", emi.Nombre);
            ReportParameter emiRef = new ReportParameter("EmisorRegimen", emi.CveRef);

            ReportParameter recRFC = new ReportParameter("ReceptorRFC", receptorRFC);
            ReportParameter recNom = new ReportParameter("ReceptorNombre", receptorNombre);
            receptorDireccion = string.IsNullOrEmpty(receptorDireccion) ? "." : receptorDireccion;
            ReportParameter recDir = new ReportParameter("ReceptorDireccion", receptorDireccion);
            ReportParameter recRef = new ReportParameter("ReceptorRegimen", receptorRegimen);




            ReportParameter folioCompleto = new ReportParameter("FolioCompleto", $"{nota.SerieFac.Trim()} {nota.FolioFac.ToString()}");
            ReportParameter lugarFecha = new ReportParameter("LugarFecha", $"CP {emi.CP.Trim()}   {nota.FechaFac.ToShortDateString()}");
            ReportParameter letras = new ReportParameter("Letras", let);

            ReportParameter cadenaOriginal = new ReportParameter("CadenaOriginal", cadenaSAT);
            ReportParameter selloC = new ReportParameter("SelloCFD", selloCFD);
            ReportParameter selloS = new ReportParameter("SelloSAT", selloSAT);
            ReportParameter rfcP = new ReportParameter("RFCPAC", rfcPAC);
            ReportParameter fechaTim = new ReportParameter("FechaTimbrado", fechaTimbrado);


            ReportParameter cbb = new ReportParameter("cbb", new Uri(archCBB).AbsoluteUri);
            ReportParameter datosAdicionales = new ReportParameter("DatosSucursal", datosSucursal);
            string rel = $"{nota.CveRel} {nota.UIDRel}";
            ReportParameter relacion = new ReportParameter("Relacion",rel);




            ReportParameter[] parametros =
            {
                emiRFC,
                emiNom,
                emiRef,
                recRFC,
                recNom,
                recDir,
                recRef,
                folioCompleto,
                lugarFecha,
                letras,
                cadenaOriginal,
                selloC,
                selloS,
                rfcP,
                fechaTim,
                cbb,
                datosAdicionales,
                relacion
            };

            rptFactura.LocalReport.EnableExternalImages = true;

            rptFactura.LocalReport.SetParameters(parametros);

            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;



            string archivoPDF = "";

            if (string.IsNullOrEmpty(carpetaDestino))
            {
                archivoPDF = General.CarpetaFacturaPDV(emi.RFC, nota.FechaFac) + General.NombreArchivoPDF("NDC", nota.SerieFac, nota.FolioFac);
            }
            else
            {
                string nombrePDF = General.NombreArchivoPDF("NDC", nota.SerieFac, nota.FolioFac);
                archivoPDF = $@"{carpetaDestino}\{nombrePDF}";  
            }



                var deviceInfo = @"<DeviceInfo>
            <EmbedFonts>None</EmbedFonts>
            </DeviceInfo>";

            byte[] bytes = rptFactura.LocalReport.Render(
                "PDF", deviceInfo, out mimeType, out encoding, out filenameExtension,
                out streamids, out warnings);

            using (FileStream fs = new FileStream(archivoPDF, FileMode.Create))
            {
                fs.Write(bytes, 0, bytes.Length);
            }

            if (File.Exists(archCBB))
                File.Delete(archCBB);


            return archivoPDF;

        }


        public static string GeneraPDFFacturaPDV(Venta venta, List<VentaDetalle> detalle, string carpetaDestino = "")
        {
            long emisorId = venta.EmisorId;
            string serie = venta.Serie;
            int folio = venta.Folio;
            string receptorRFC = "";
            string receptorNombre = "";
            string receptorDireccion = "";
            string receptorRegimen = "";
            string formaPago = "";
            string metodoPago = "";
            string usoCFDI = "";


            Emisor emi = new Emisor();

            string datosSucursal = "";
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.EmisorSelect();
                emi = db.Query<Emisor>(sql, new { EmisorId = emisorId }).FirstOrDefault();

                if (emi == null)
                    return "";

                sql = Queries.SucursalSelect();
                Sucursal suc = db.Query<Sucursal>(sql, new { venta.SucursalId }).FirstOrDefault();
                if (suc != null)
                    datosSucursal = suc.DatosAdicionales;


                if (venta.ClienteId == 0)
                {
                    receptorRFC = "XAXX010101000";
                    receptorNombre = "PUBLICO EN GENERAL";
                    receptorRegimen = "616";

                }
                else
                {


                    sql = Queries.RazonSocialSelect();
                    RazonSocial razonSocial = db.Query<RazonSocial>(sql, new { RazonSocialId = venta.ClienteId }).FirstOrDefault();
                    if (razonSocial == null)
                        return "";

                    string ciudad = General.GetDescripcion("CIU", razonSocial.CiudadId);
                    string estado = General.GetDescripcion("EDO", razonSocial.EstadoId);

                    receptorRFC = razonSocial.RFC;
                    receptorNombre = razonSocial.RazonSoc;
                    receptorRegimen = $"{razonSocial.CveREF}:{General.GetDescripcionClaveSAT("REF", razonSocial.CveREF)}";
                    receptorDireccion = $"{razonSocial.Direccion.Trim()} {ciudad.Trim()} {estado.Trim()} {razonSocial.CP}";
                    formaPago = $"{venta.FormaPago}:{General.GetDescripcionClaveSAT("FOP", venta.FormaPago)}";
                    metodoPago = $"{venta.MetodoPago}:{General.GetDescripcionClaveSAT("MEP", venta.MetodoPago)}";
                    usoCFDI = $"{venta.Uso}:{General.GetDescripcionClaveSAT("USO", venta.Uso)}";

                }

            }

            
            List<Venta> datosFactura = new List<Venta>();
            venta.Total = venta.Subtotal + venta.IVA - venta.Descuento;
            datosFactura.Add(venta);


            List<ReportDataSource> reportDataSources = new List<ReportDataSource>();

            reportDataSources.Add(
                new ReportDataSource { Name = "dsDatosFactura", Value = datosFactura }
            );

            foreach (var ren in detalle)
            {
                ren.Precio = ren.PrecioDes;
            }
            reportDataSources.Add(
                new ReportDataSource { Name = "dsDetalleFactura", Value = detalle }
            );

            // PreVerReporte reporte = new PreVerReporte($@"{carpetaReportes}\Expedientes\Expediente.rdlc", reportDataSources, "Expediente");
            ReportViewer rptFactura = new ReportViewer();

            rptFactura.ProcessingMode = ProcessingMode.Local;
            rptFactura.LocalReport.ReportPath = @"C:\Users\Felipe  Juan\source\repos\ClinicaFB\ClinicaFB\Reportes\Ingresos\Factura.rdlc";
            string formatoFactura = UtilsPDV.GetFormatoFactura(venta);
            string rep = General.GetCarpetaReportes() + $@"\PDV\{formatoFactura}.rdlc";
            rptFactura.LocalReport.ReportPath = rep; // @"C:\Users\Felipe  Juan\source\repos\ClinicaFB\ClinicaFB\Reportes\Ingresos\Factura.rdlc";
            //rptFactura.LocalReport.ReportPath = @"C:\CLINICAFB DATOS\REPORTES\PDV\FACTURA.RDLC";

            rptFactura.LocalReport.DataSources.Clear();


            foreach (var dato in reportDataSources)
            {
                rptFactura.LocalReport.DataSources.Add(dato);
            }

            Conversion con = new Conversion();
            string let = con.enletras(venta.Subtotal+venta.IVA-venta.Descuento);
            string cadenaSAT = "";
            string selloCFD = "";
            string selloSAT = "";
            string certificadoSAT = "";
            string rfcPAC = "";
            string fechaTimbrado = "";

            if (string.IsNullOrEmpty(venta.xml) == false)
            {
                ComprobanteCFDI comprobante = new ComprobanteCFDI();
                selloCFD = comprobante.GetSelloDigital(venta.xml);
                selloSAT = comprobante.GetSelloSAT(venta.xml);
                certificadoSAT = comprobante.GetCertificadoSAT(venta.xml);
                rfcPAC = comprobante.GetRFCPAC(venta.xml);
                fechaTimbrado = comprobante.GetFechaTimbrado(venta.xml);

                cadenaSAT = $"||1.1|{venta.UID}{fechaTimbrado}|{selloCFD}|{certificadoSAT}||";
            }


            string cadenaCBB = $"https://verificacfdi.facturaelectronica.sat.gob.mx/?id={venta.UID}&re={emi.RFC}";
            cadenaCBB += $"&rr={receptorRFC}&tt={venta.Total.ToString().Trim()}&fe={venta.CSD.Substring(venta.CSD.Length - 7)}";

            string archCBB = GetTempCBB();
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(cadenaCBB, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);

            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            qrCodeImage.Save(archCBB, System.DrawingCore.Imaging.ImageFormat.Png);



            ReportParameter emiRFC = new ReportParameter("EmisorRFC", emi.RFC);
            ReportParameter emiNom = new ReportParameter("EmisorNombre", emi.Nombre);
            ReportParameter emiRef = new ReportParameter("EmisorRegimen", emi.CveRef);

            ReportParameter recRFC = new ReportParameter("ReceptorRFC", receptorRFC);
            ReportParameter recNom = new ReportParameter("ReceptorNombre", receptorNombre);
            receptorDireccion = string.IsNullOrEmpty(receptorDireccion) ? "." : receptorDireccion;
            ReportParameter recDir = new ReportParameter("ReceptorDireccion", receptorDireccion);
            ReportParameter recRef = new ReportParameter("ReceptorRegimen", receptorRegimen);




            ReportParameter folioCompleto = new ReportParameter("FolioCompleto", $"{venta.SerieFac.Trim()} {venta.FolioFac.ToString()}");
            ReportParameter lugarFecha = new ReportParameter("LugarFecha", $"CP {emi.CP.Trim()}   {venta.FechaFac.ToShortDateString()}");
            ReportParameter letras = new ReportParameter("Letras", let);

            ReportParameter cadenaOriginal = new ReportParameter("CadenaOriginal", cadenaSAT);
            ReportParameter selloC = new ReportParameter("SelloCFD", selloCFD);
            ReportParameter selloS = new ReportParameter("SelloSAT", selloSAT);
            ReportParameter rfcP = new ReportParameter("RFCPAC", rfcPAC);
            ReportParameter fechaTim = new ReportParameter("FechaTimbrado", fechaTimbrado);


            ReportParameter cbb = new ReportParameter("cbb", new Uri(archCBB).AbsoluteUri);
            ReportParameter datosAdicionales = new ReportParameter("DatosSucursal", datosSucursal);




            ReportParameter[] parametros =
            {
                emiRFC,
                emiNom,
                emiRef,
                recRFC,
                recNom,
                recDir,
                recRef,
                folioCompleto,
                lugarFecha,
                letras,
                cadenaOriginal,
                selloC,
                selloS,
                rfcP,
                fechaTim,
                cbb,
                datosAdicionales
            };

            rptFactura.LocalReport.EnableExternalImages = true;

            rptFactura.LocalReport.SetParameters(parametros);

            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;


            string archivoPDF = string.IsNullOrEmpty(carpetaDestino)?General.CarpetaFacturaPDV(emi.RFC, venta.FechaFac):carpetaDestino+@"\" + General.NombreArchivoPDF("FAC", venta.SerieFac, venta.FolioFac);


            var deviceInfo = @"<DeviceInfo>
            <EmbedFonts>None</EmbedFonts>
            </DeviceInfo>";

            byte[] bytes = rptFactura.LocalReport.Render(
                "PDF", deviceInfo, out mimeType, out encoding, out filenameExtension,
                out streamids, out warnings);

            using (FileStream fs = new FileStream(archivoPDF, FileMode.Create))
            {
                fs.Write(bytes, 0, bytes.Length);
            }

            if (File.Exists(archCBB))
                File.Delete(archCBB);


            return archivoPDF;

        }




        public static string GeneraPDFFactura(CFDI cfdi, List<CfdiDetalle> conceptos,string xml = "")

        {
            long emisorId = cfdi.EmisorId;
            string serie = cfdi.Serie;
            int folio = cfdi.Folio;


            string datosSucursal = "";


            Emisor emi = new Emisor();

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.EmisorSelect();
                emi = db.Query<Emisor>(sql, new {EmisorId =emisorId}).FirstOrDefault();

                if (emi == null)
                    return "";

                sql = Queries.IngresoSelect();
                Ingreso ing = db.Query<Ingreso>(sql, new {IngresoId =cfdi.IngresoId }).FirstOrDefault();

                if (ing == null)
                    return "";

                sql = Queries.SucursalSelect();
                Sucursal suc = db.Query<Sucursal>(sql, new {SucursalId=ing.SucursalId}).FirstOrDefault();
                if (suc != null)
                    datosSucursal = suc.DatosAdicionales;


                if (cfdi.RazonSocialId == 0)
                {
                    cfdi.ReceptorRFC = "XAXX010101000";
                    cfdi.ReceptorNombre = "PUBLICO EN GENERAL";
                    cfdi.ReceptorRegimenFiscal = "616";

                }
                else
                { 
                    sql = Queries.RazonSocialSelect();
                    RazonSocial razonSocial = db.Query<RazonSocial>(sql, new {RazonSocialId =cfdi.RazonSocialId }).FirstOrDefault();
                    string ciudad = General.GetDescripcion("CIU", razonSocial.CiudadId);
                    string estado = General.GetDescripcion("EDO", razonSocial.EstadoId);

                    cfdi.ReceptorRFC = razonSocial.RFC;
                    cfdi.ReceptorNombre = razonSocial.RazonSoc;
                    cfdi.ReceptorRegimenFiscal = razonSocial.CveREF;
                    cfdi.ReceptorDireccion = $"{razonSocial.Direccion.Trim()} {ciudad.Trim()} {estado.Trim()} {razonSocial.CP}";

                }



            }

            List<CFDI> datosFactura = new List<CFDI>();

            cfdi.ReceptorRegimenFiscal = cfdi.ReceptorRegimenFiscal.Trim() + ": " + General.GetDescripcionClaveSAT("REF", cfdi.ReceptorRegimenFiscal);
            cfdi.FormaPago = cfdi.FormaPago.Trim() + ": " + General.GetDescripcionClaveSAT("FOP", cfdi.FormaPago);
            cfdi.MetodoPago = cfdi.MetodoPago.Trim() + ": " + General.GetDescripcionClaveSAT("MEP", cfdi.MetodoPago);
            cfdi.UsoCFdi = cfdi.UsoCFdi.Trim() + ": " + General.GetDescripcionClaveSAT("USO", cfdi.UsoCFdi); ;
            datosFactura.Add(cfdi);


            List<ReportDataSource> reportDataSources= new List<ReportDataSource>();

            reportDataSources.Add(
                new ReportDataSource { Name = "dsDatosfactura", Value = datosFactura }
            );

            reportDataSources.Add(
                new ReportDataSource { Name = "dsDetallefactura", Value = conceptos }
            );

            // PreVerReporte reporte = new PreVerReporte($@"{carpetaReportes}\Expedientes\Expediente.rdlc", reportDataSources, "Expediente");
           ReportViewer rptFactura = new ReportViewer();

           rptFactura.ProcessingMode = ProcessingMode.Local;
            rptFactura.LocalReport.ReportPath = @"C:\Users\Felipe  Juan\source\repos\ClinicaFB\ClinicaFB\Reportes\Ingresos\Factura.rdlc";
            string rep = General.GetCarpetaReportes() + @"\Ingresos\Factura.rdlc";
            rptFactura.LocalReport.ReportPath = rep; // @"C:\Users\Felipe  Juan\source\repos\ClinicaFB\ClinicaFB\Reportes\Ingresos\Factura.rdlc";

            rptFactura.LocalReport.DataSources.Clear();


           foreach (var dato in reportDataSources)
           {
               rptFactura.LocalReport.DataSources.Add(dato);
           }

            Conversion con = new Conversion();
            string let = con.enletras(cfdi.Total);
            string cadenaSAT = "";
            string selloCFD = "";
            string selloSAT = "";
            string certificadoSAT = "";
            string rfcPAC = "";
            string fechaTimbrado = "";

            if (string.IsNullOrEmpty(xml) == false)
            {
                ComprobanteCFDI comprobante = new ComprobanteCFDI();
                selloCFD = comprobante.GetSelloDigital(xml);
                selloSAT = comprobante.GetSelloSAT(xml);
                certificadoSAT = comprobante.GetCertificadoSAT(xml);
                rfcPAC = comprobante.GetRFCPAC(xml);
                fechaTimbrado = comprobante.GetFechaTimbrado(xml);

                cadenaSAT ="||1.1|"+cfdi.uid+fechaTimbrado+"|"+selloCFD+"|"+certificadoSAT+"||";
            }



            string cadenaCBB = $"https://verificacfdi.facturaelectronica.sat.gob.mx/?id={cfdi.uid}&re={cfdi.EmisorRFC}";
            string csd = string.IsNullOrEmpty(cfdi.EmisorCSD) ? string.Empty : cfdi.EmisorCSD.Substring(cfdi.EmisorCSD.Length - 7);
            cadenaCBB += $"&rr={cfdi.ReceptorRFC}&tt={cfdi.Total.ToString().Trim()}&fe={csd}";

            string archCBB = GetTempCBB();
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(cadenaCBB, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);

            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            qrCodeImage.Save(archCBB, System.DrawingCore.Imaging.ImageFormat.Png);




            ReportParameter folioCompleto = new ReportParameter("FolioCompleto", $"{serie.Trim()} {folio.ToString()}");
            ReportParameter lugarFecha = new ReportParameter("LugarFecha", $"CP {emi.CP.Trim()}   {cfdi.Fecha.ToShortDateString()}");
            ReportParameter letras = new ReportParameter("Letras", let);

            ReportParameter cadenaOriginal = new ReportParameter("CadenaOriginal", cadenaSAT);
            ReportParameter selloC = new ReportParameter("SelloCFD", selloCFD);
            ReportParameter selloS = new ReportParameter("SelloSAT", selloSAT);
            ReportParameter rfcP = new ReportParameter("RFCPAC", rfcPAC);
            ReportParameter fechaTim = new ReportParameter("FechaTimbrado", fechaTimbrado);


            ReportParameter cbb = new ReportParameter("cbb", new Uri(archCBB).AbsoluteUri);
            ReportParameter datosAdicionales = new ReportParameter("DatosSucursal", datosSucursal);




            ReportParameter[] parametros = 
            {
                folioCompleto,
                lugarFecha,
                letras,
                cadenaOriginal,
                selloC,
                selloS,
                rfcP, 
                fechaTim,
                cbb, 
                datosAdicionales
            };

            rptFactura.LocalReport.EnableExternalImages= true;

           rptFactura.LocalReport.SetParameters(parametros);

           Warning[] warnings;
           string[] streamids;
           string mimeType;
           string encoding;
           string filenameExtension;

            string archivoPDF = General.CarpetaCfdi(cfdi.EmisorRFC, cfdi.Fecha) + General.NombreArchivoPDF("FAC",cfdi.Serie,cfdi.Folio);


            var deviceInfo = @"<DeviceInfo>
            <EmbedFonts>None</EmbedFonts>
            </DeviceInfo>";

            byte[] bytes = rptFactura.LocalReport.Render(
                "PDF", deviceInfo, out mimeType, out encoding, out filenameExtension,
                out streamids, out warnings);

           using (FileStream fs = new FileStream(archivoPDF, FileMode.Create))
           {
               fs.Write(bytes, 0, bytes.Length);
           }

           if (File.Exists(archCBB))
                File.Delete(archCBB);


            return archivoPDF;



        }

        private static void  ImprimeArchivo(string archivo, string impresora)
        {
            PdfDocumentView doc = new PdfDocumentView();
            doc.Load(archivo);
            
            PrinterSettings ps = new PrinterSettings();
            
            ps.PrinterName = impresora;
            


            PrintDialog dialog = new PrintDialog();

            dialog.PrinterSettings = ps;
            

            dialog.AllowPrintToFile = true;

            dialog.AllowSomePages = true;
            dialog.AllowCurrentPage = true;
            dialog.Document = doc.PrintDocument;

           
            //Print the PDF document
            //dialog.Document.Print();
            doc.Print(impresora);
            //Dispose the viewer
            doc.Dispose();

        }
    }
}
