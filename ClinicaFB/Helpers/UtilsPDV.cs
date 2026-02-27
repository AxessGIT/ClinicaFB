using CFDiLib;
using ClinicaFB.Modelo;
using Dapper;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;



namespace ClinicaFB.Helpers
{
    public static class UtilsPDV
    {


        public static async Task<int> CreaVentaDesdeCFDi(string archivoCfdi)
        {
            int resultado = 0;
            using (FbConnection db = General.GetDB())
            {
                await db.OpenAsync();
                using (var transaction = db.BeginTransaction())
                {

                    try { 

                        // Cargar archivo
                        XDocument xml = XDocument.Load(archivoCfdi);
                        XNamespace cfdi = "http://www.sat.gob.mx/cfd/4";

                        // Leer atributos del nodo raíz
                        var comprobante = xml.Root;
                        string serie = (string)comprobante.Attribute("Serie") ?? "";
                        string folio = (string)comprobante.Attribute("Folio");
                        string cveFOP = (string)comprobante.Attribute("FormaPago") ?? "";
                        string cveMEP = (string)comprobante.Attribute("MetodoPago") ?? "";
                        string cveUSO = (string)comprobante.Attribute("UsoCFDI") ?? "";
                        decimal subTotal = (decimal)comprobante.Attribute("SubTotal");
                        decimal total = (decimal)comprobante.Attribute("Total");

                        // Leer subnodos con namespace
                        var emisor = comprobante.Element(cfdi + "Emisor");
                        string rfcEmisor = (string)emisor.Attribute("Rfc");
                        string nombre = (string)emisor.Attribute("Nombre");

                        var receptor = comprobante.Element(cfdi + "Receptor");
                        string rfcReceptor = (string)receptor.Attribute("Rfc");

                        var impuestos = comprobante.Element(cfdi + "Impuestos");
                        decimal totalImpuestos = impuestos.ToString().Contains("TotalImpuestosTrasladados") ? (decimal)impuestos.Attribute("TotalImpuestosTrasladados") : 0;

                        XNamespace tfd = "http://www.sat.gob.mx/TimbreFiscalDigital";
                        var complemento = comprobante.Element(cfdi + "Complemento");
                        var timbreFiscal = complemento?.Element(tfd + "TimbreFiscalDigital");
                        string uid = (string)timbreFiscal?.Attribute("UUID") ?? "";

                        string sql = Queries.RazonSocialSelectXRFC();


                        long razonSocialId = 0;
                        if (rfcReceptor != "XAXX010101000")                 
                            razonSocialId = db.QuerySingleOrDefault<long>(sql, new { Rfc = rfcReceptor },transaction);



                        Venta venta = new Venta();
                        long emisorId = 5;
                        long almacenId = 1;

                        venta.SucursalId = Properties.Settings.Default.SucursalId;
                        venta.EmisorId = emisorId;
                        venta.AlmacenId = almacenId;
                        venta.ClienteId = razonSocialId;
                        venta.Tipo = "FAC";

                        venta.SerieFac = serie;
                        venta.FolioFac = int.TryParse(folio, out int folioNum) ? folioNum : 0;
                        venta.TipoComprobante = "I";
                        venta.Fecha = new DateTime(2026, 01, 09);
                        venta.FormaPago = cveFOP;
                        venta.MetodoPago = cveMEP;
                        venta.Moneda = "MXN";
                        venta.TipoCambio = 1;
                        venta.LugarExpedicion = "66260";
                        venta.Uso = cveUSO;
                        venta.Subtotal = subTotal;
                        venta.IVA = totalImpuestos;
                        venta.Total = total;

                        venta.CSD = "00001000000511825310";
                        venta.UID = uid;

                        string xmlstr = xml.ToString();

                        sql = Queries.VentaInsert;

                        venta.VentaId = await db.ExecuteScalarAsync<long>(sql, venta, transaction);

                        // Iterar conceptos
                        var conceptos = comprobante.Element(cfdi + "Conceptos")
                                                  .Elements(cfdi + "Concepto");


                        foreach (var concepto in conceptos)
                        {
                            string clave = (string)concepto.Attribute("NoIdentificacion");
                            decimal cantidad = (decimal)concepto.Attribute("Cantidad");
                            decimal precio = (decimal)concepto.Attribute("ValorUnitario");
                            string cveProSer = (string)concepto.Attribute("ClaveProdServ") ?? "";
                            string cveUNI = (string)concepto.Attribute("ClaveUnidad") ?? "";



                            if (clave == "104L 120ML")
                                clave = "XXXXX";

                            Articulo articulo = db.QueryFirstOrDefault<Articulo>(Queries.ArticuloSelectxClave(), new { Clave = clave }, transaction);
                            long articuloId = articulo != null ? articulo.ArticuloId : 0;




                            Impuesto imp = new Impuesto();

                            int tipoIVA = 0;
                            decimal tasaIVA = 0;

                            if (articulo.ImpuestoId != 0)
                            {
                                sql = Helpers.Queries.ImpuestoSelect();
                                imp = db.Query<Impuesto>(sql, new { articulo.ImpuestoId },transaction).FirstOrDefault();

                                if (imp != null)
                                {
                                    if (imp.Descripcion == "EXENTO")
                                    {
                                        tipoIVA = 2;
                                        tasaIVA = 0;
                                    }
                                    else
                                    {
                                        tipoIVA = 1;
                                        tasaIVA = imp.Porcentaje;

                                    }
                                }

                            }

                            decimal iva = Math.Round(precio * (decimal)cantidad * tasaIVA / 100, 2);


                            VentaDetalle ventaDetalle = new VentaDetalle
                            {
                                VentaId = venta.VentaId,
                                ArticuloId = articuloId,
                                NoIden = clave,
                                Descripcion = (string)concepto.Attribute("Descripcion"),
                                UDM = (string)concepto.Attribute("Unidad") ?? "",

                                Cantidad = cantidad,
                                Precio = precio,
                                TipoIVA = tipoIVA,
                                TasaIVA = tasaIVA,
                                Descuento = 0,
                                IVA = iva

                            };
                            sql = Queries.VentaDetalleInsert;
                            await db.ExecuteAsync(sql, ventaDetalle, transaction);

                        }

                        sql = Queries.VentaUpdateTimbrado;


                        using (FbCommand cmd = new FbCommand(sql, db, transaction))
                        {
                            cmd.Parameters.AddWithValue("uid", uid);
                            cmd.Parameters.AddWithValue("csd", venta.CSD);
                            cmd.Parameters.AddWithValue("xml", xmlstr);
                            cmd.Parameters.AddWithValue("VentaId", venta.VentaId);
                            await cmd.ExecuteNonQueryAsync();
                        }

                        resultado = venta.FolioFac; // Devolver folio como resultado exitoso
                        transaction.Commit();   

                    }
                    catch (Exception ex)
                    {

                        transaction.Rollback(); 

                        // Manejo de errores (puede ser logging o mostrar un mensaje al usuario)
                        Console.WriteLine($"Error al crear venta desde CFDI: {ex.Message}");
                        resultado = -1; // Indicar error
                    }
                }
            }
            return resultado;
        }

        public static async Task MuestraArchivosCFDi(long documentoId, string tipoDoc = "FAC")
        {


            Venta venta = new Venta();
            List<VentaDetalle> detalle = new List<VentaDetalle>();



            ComplementoPago complemento = new ComplementoPago();


            string carpetaCfdi = string.Empty;
            string carpetaEscritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string carpetaUsuario = $@"{carpetaEscritorio}\CFDIs";




            if (!Directory.Exists(carpetaUsuario))
            {
                Directory.CreateDirectory(carpetaUsuario);
            }


            string sql = string.Empty;

            string archivoCfdi = string.Empty;
            string archivoDestino = string.Empty;
            string serie = string.Empty;
            int folio = 0;
            Emisor emisor = new Emisor();



            using (FbConnection db = General.GetDB())
            {
                await db.OpenAsync();
                using (var transaction = db.BeginTransaction())
                {

                    if (tipoDoc == "FAC" || tipoDoc == "NDC")
                    {

                        sql = Queries.VentaSelect;
                        venta = db.Query<Venta>(sql, new { VentaId = documentoId },transaction).FirstOrDefault();
                        sql = Queries.VentaDetallesSelect;
                        detalle = db.Query<VentaDetalle>(sql, new { VentaId = documentoId },transaction).ToList();

                        sql = Queries.EmisorSelect();
                        emisor = db.Query<Emisor>(sql, new { venta.EmisorId },transaction).FirstOrDefault();


                        serie = venta.SerieFac;
                        folio = venta.FolioFac;

                    }
                    else
                    {
                        sql = Queries.ComplementoDePagoSelect;
                        complemento = db.Query<ComplementoPago>(sql, new { ComPagId = documentoId },transaction).FirstOrDefault();

                        sql = Queries.EmisorSelect();
                        emisor = db.Query<Emisor>(sql, new { complemento.EmisorId },transaction).FirstOrDefault();

                        serie = complemento.Serie;
                        folio = complemento.Folio;
                    }

                    archivoCfdi = General.NombreArchivoCfdi(tipoDoc, serie, folio);
                    archivoDestino = $@"{carpetaUsuario}\{archivoCfdi}";

                    if (tipoDoc == "FAC" || tipoDoc == "NDC")
                    {

                        if (string.IsNullOrEmpty(venta.xml))
                        {
                            carpetaCfdi = General.CarpetaFacturaPDV(emisor.RFC, venta.FechaFac);
                            archivoCfdi = carpetaCfdi + @"\" + General.NombreArchivoCfdi(venta.Tipo.Trim(), venta.SerieFac, venta.FolioFac);

                            if (File.Exists(archivoCfdi))
                            {
                                File.Copy(archivoCfdi, archivoDestino, true);
                            }
                        }
                        else
                        {

                            File.WriteAllText(archivoDestino, venta.xml);
                        }

                        if (string.IsNullOrEmpty(venta.xml) && File.Exists(archivoCfdi))
                        {
                            venta.xml = File.ReadAllText(archivoCfdi);

                        }


                        if (tipoDoc == "FAC")
                        {
                            ManejaCFDIs.GeneraPDFFacturaPDV(venta, detalle,db,transaction, carpetaUsuario);
                        }
                        else
                        {
                            ManejaCFDIs.GeneraPDFNotaDeCreditoPDV(venta, detalle, carpetaUsuario);
                        }

                    }

                    else if (tipoDoc == "CPG")
                    {
                        File.WriteAllText(archivoDestino, complemento.xml);
                        ManejaCFDIs.GeneraPDFComplementoDePago(complemento.ComPagId, carpetaUsuario);
                    }

                }
            }



            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
            {
                FileName = carpetaUsuario,
                UseShellExecute = true,
                Verb = "open"
            });


        }

        public static string GetFormatoFactura(Venta venta)
        {
            string formato = "FACTURA";
            
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.AlmacenSelect();
                var res = db.QueryFirstOrDefault<Almacen>(sql, new {venta.AlmacenId});

                if (res != null && !string.IsNullOrEmpty(res.FormatoFac))
                {
                    formato = res.FormatoFac;
                }
            }
            return formato;
        }

        public static BindingList<Almacen> GetAlmacenes()
        {
            BindingList<Almacen> almacenes = new BindingList<Almacen>();
            long sucursalId = Properties.Settings.Default.SucursalId;

            List<SucursalAlmacen> sucAlmacenes = GetSucursalAlmacenes(sucursalId);
            var almacenesPermitidos = new HashSet<long>(sucAlmacenes.Select(sa => sa.AlmacenId));

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.AlmacenesSelect();
                var res = db.Query<Almacen>(sql).ToList();
                var almacenesFiltrados = res.Where(a => almacenesPermitidos.Contains(a.AlmacenId)).ToList();
                if (sucAlmacenes.Count > 0)
                {
                    almacenes = new BindingList<Almacen>(almacenesFiltrados);
                }
                else
                {
                    almacenes = new BindingList<Almacen>(res);
                }
            }
            if (almacenes.Count == 1)
            { almacenes[0].Defa = true; }
            return almacenes;
        }

        public static BindingList<Emisor> GetEmisores()
        {
            BindingList<Emisor> emisores = new BindingList<Emisor>();
            long sucursalId = Properties.Settings.Default.SucursalId;
            List<SucursalEmisor> sucEmisores = GetSucursalEmisores(sucursalId);

            var emisoresPermitidos = new HashSet<long>(sucEmisores.Select(se => se.EmisorId));



            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.EmisoresPDVSelect;
                var res = db.Query<Emisor>(sql).ToList();

                var emisoresFiltrados = res.Where(e => emisoresPermitidos.Contains(e.EmisorId)).ToList();

                if (sucEmisores.Count > 0)
                {
                    emisores = new BindingList<Emisor>(emisoresFiltrados);

                }
                else
                {
                    emisores = new BindingList<Emisor>(res);
                }

            }
            return emisores;



        }




        public static List<SucursalAlmacen> GetSucursalAlmacenes(long sucursalId)
        {
            List<SucursalAlmacen> sucursalAlmacenes = new List<SucursalAlmacen>();
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.SucursalAlmacenesSelect;
                sucursalAlmacenes = db.Query<SucursalAlmacen>(sql, new { SucursalId = sucursalId }).ToList();
            }
            return sucursalAlmacenes;
        }

        public static List<SucursalEmisor> GetSucursalEmisores (long sucursalId)
        {
            List<SucursalEmisor> sucursalEmisores = new List<SucursalEmisor>();
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.SucursalEmisoresSelect;
                sucursalEmisores = db.Query<SucursalEmisor>(sql, new { SucursalId = sucursalId }).ToList();
            }


            return sucursalEmisores;
        }
    }
}
