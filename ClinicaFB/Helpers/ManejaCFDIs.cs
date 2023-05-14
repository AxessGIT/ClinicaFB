using CFDiLib;
using ClinicaFB.Modelo;
using ClinicaFB.Reportes;
using Dapper;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.Office.Interop.Excel;
using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.Interfaces;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.DrawingCore;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ClinicaFB.Helpers
{
    public static class ManejaCFDIs
    {

        public static void MandaArchivos(string archivolXML, string archivoPDF, List<string> destinatarios)
        {


        }
        public static void IngresoFacturar(int ingresoId)
        {
            Ingreso ing = new Ingreso();

            List<IngresoDetalle> detalle = new List<IngresoDetalle>();

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.IngresoSelect();
                ing = db.Query<Ingreso>(sql, new {IngresoId = ingresoId}).FirstOrDefault();
                if (ing == null)
                {
                    return;
                }

                sql = Queries.IngresoDetallesSelect();

                detalle = db.Query<IngresoDetalle>(sql, new {IngresoId = ingresoId}).ToList();

            }


            ing.IngresoId = ingresoId;

            var conceptosOrdenados = new BindingList<IngresoDetalle>(detalle.OrderBy(x => x.EmisorId).ThenBy(x => x.Serie).ToList());

            int emisorId = conceptosOrdenados[0].EmisorId;
            string serie = conceptosOrdenados[0].Serie;

            List<IngresoDetalle> conceptos = new List<IngresoDetalle>();

            foreach (var concepto in conceptosOrdenados)
            {
                if (concepto.EmisorId != emisorId || concepto.Serie != serie)
                {

                    GeneraFactura(ing, conceptos);
                    emisorId = concepto.EmisorId;
                    serie = concepto.Serie;
                    conceptos = new List<IngresoDetalle>();
                }
                conceptos.Add(concepto);

            }

            GeneraFactura(ing, conceptos);



        }

        private static void GeneraFactura(Ingreso ing, List<IngresoDetalle> conceptos)
        {

            int emisorId = conceptos[0].EmisorId;
            string serie = conceptos[0].Serie;
            int folioFac = 0;
            string tipoDoc = "FAC";

            RazonSocial razonSocial = new RazonSocial();
            Emisor emi = new Emisor();


            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.SerieDocSelectXEmisorTipoSerie();
                SerieDoc serDoc = db.Query<SerieDoc>(sql, new {EmisorId=emisorId,Tipo =tipoDoc, Serie=serie }).FirstOrDefault();

                if (serDoc == null)
                    return;

                folioFac = serDoc.Folio;

                sql = Queries.SerieFolioIncrementa();
                db.Execute(sql, new { SerieDocId = serDoc.SerieDocId });

                sql = Queries.RazonSocialSelect();

                razonSocial = db.Query<RazonSocial>(sql, new { RazonSocialId = ing.RazonSocialId }).FirstOrDefault();

                sql = Queries.EmisorSelect();

                emi = db.Query<Emisor>(sql, new { EmisorId = emisorId }).FirstOrDefault();

                if (emi == null)
                    return;
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
            cfdi.Fecha = ing.Fecha;
            cfdi.PacienteId= ing.PacienteId;
            cfdi.RazonSocialId= ing.RazonSocialId;
            cfdi.ReceptorRFC = razonSocial.RFC;
            cfdi.ReceptorNombre = razonSocial.RazonSoc;
            cfdi.ReceptorRegimenFiscal = razonSocial.CveREF;
            cfdi.TipoComprobante = "I";
            cfdi.FormaPago = razonSocial.CveFOP;
            cfdi.Moneda = "MXN";
            cfdi.MetodoPago = razonSocial.CveMEP;
            cfdi.LugarExpedicion = emi.CP;
            cfdi.UsoCFdi = razonSocial.CveUSO;
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

            comprobante.ComprobanteReceptor.RFC = razonSocial.RFC;
            comprobante.ComprobanteReceptor.Nombre = razonSocial.RazonSoc;
            comprobante.ComprobanteReceptor.DomicilioFiscalReceptor = razonSocial.CP;
            comprobante.ComprobanteReceptor.RegimenFiscalReceptor = razonSocial.CveREF;
            comprobante.ComprobanteReceptor.UsoCFDI = razonSocial.CveUSO;

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

            comprobante.archivoXMLBase = GetTempXML();
            comprobante.archivoXMLFirmado = GetTempXML();
            comprobante.archivoXMLTimbrado = General.CarpetaCfdi(emi.RFC,ing.Fecha) + General.NombreArchivoCfdi(tipoDoc,serie,folioFac);

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

                if (File.Exists(comprobante.archivoXMLTimbrado))
                {
                    xml = File.ReadAllText(comprobante.archivoXMLTimbrado);

                    cfdi.uid = comprobante.GetFolioFiscal(xml);
                    cfdi.EmisorCSD = comprobante.GetEmisorCSD();

                }


            }


           List<CFDIDetalle> cfdiDetalle = new List<CFDIDetalle>(); 

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.CfdiInsert();
                int cfdiId = db.ExecuteScalar<int>(sql,cfdi);

                foreach (var det in conceptos)
                {
                    CFDIDetalle newDet = new CFDIDetalle();
                    newDet.CFDIId = cfdiId;
                    newDet.ArticuloId = det.ArticuloId;
                    newDet.NoIden = det.Clave;
                    newDet.Descripcion= det.Descripcion;
                    newDet.Cantidad = det.Cantidad;
                    newDet.ValorUnitario = det.Precio;
                    newDet.CveProSer=det.CveProSer;
                    newDet.CveUni=det.CveUni;
                    newDet.Descuento=det.Descuento;
                    newDet.TipoIVA = det.TipoIVA.ToString();
                    newDet.TasaIVA= det.TasaIVA;
                    newDet.IVA=det.IVA;
                    newDet.RetISR=det.RetISR;
                    newDet.RetIVA=det.RetIVA;

                    cfdiDetalle.Add(newDet);   

                    sql = Queries.CfdiDetalleInsert();
                    db.Execute(sql, newDet);

                }
            }

            GeneraPDFFactura(cfdi, cfdiDetalle,xml);


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


        public static void GeneraPDFFactura(CFDI cfdi, List<CFDIDetalle> conceptos, string xml = "")
        {
            int emisorId = cfdi.EmisorId;
            string serie = cfdi.Serie;
            int folio = cfdi.Folio;


            string datosSucursal = "";


            Emisor emi = new Emisor();

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.EmisorSelect();
                emi = db.Query<Emisor>(sql, new {EmisorId =emisorId}).FirstOrDefault();

                if (emi == null)
                    return;

                sql = Queries.IngresoSelect();
                Ingreso ing = db.Query<Ingreso>(sql, new {IngresoId =cfdi.IngresoId }).FirstOrDefault();

                if (ing == null)
                    return;

                sql = Queries.SucursalSelect();
                Sucursal suc = db.Query<Sucursal>(sql, new {SucursalId=ing.SucursalId}).FirstOrDefault();
                if (suc != null)
                    datosSucursal = suc.DatosAdicionales;



            }

            List<CFDI> datosFactura = new List<CFDI>();



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
            cadenaCBB += $"&rr={cfdi.ReceptorRFC}&tt={cfdi.Total.ToString().Trim()}&fe={cfdi.EmisorCSD.Substring(cfdi.EmisorCSD.Length - 7)}";

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

           byte[] bytes = rptFactura.LocalReport.Render(
                "PDF", null, out mimeType, out encoding, out filenameExtension,
                out streamids, out warnings);

           using (FileStream fs = new FileStream(archivoPDF, FileMode.Create))
           {
               fs.Write(bytes, 0, bytes.Length);
           }

           if (File.Exists(archCBB))
                File.Delete(archCBB);





        }
    }
}
