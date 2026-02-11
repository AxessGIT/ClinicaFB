using CFDiLib;
using ClinicaFB.Modelo;
using ClinicaFB.PuntoDeVenta;
using Dapper;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.Reporting.WinForms;
using QRCoder;
using Syncfusion.Windows.Forms.PivotAnalysis;
using Syncfusion.WinForms.ListView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Twilio.Annotations;

namespace ClinicaFB.Helpers
{
    public static class UtilsInv
    {


        #region CapasDeCostos

        public static async Task RegistrarEntradaPorNCAsync(long articuloId, long sucursalId, long almacenId,
                                                long ventaIdNC, long ventaDetIdNC,
                                                DateTime fechaNC, decimal cantidad,FbConnection db, FbTransaction transaction)
        {

            using (FbCommand cmd = new FbCommand("SP_CAPASDECOSTOS_REGISTRAR_NC", db,transaction))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Definición de parámetros para el SP
                cmd.Parameters.Add("@P_ARTICULOID", FbDbType.BigInt).Value = articuloId;
                cmd.Parameters.Add("@P_SUCURSALID", FbDbType.BigInt).Value = sucursalId;
                cmd.Parameters.Add("@P_ALMACENID", FbDbType.BigInt).Value = almacenId;
                cmd.Parameters.Add("@P_TIPODOC", FbDbType.VarChar).Value = "NDC";
                cmd.Parameters.Add("@P_CONCEPTOID", FbDbType.BigInt).Value = 5;
                cmd.Parameters.Add("@P_DOCUMENTOID", FbDbType.BigInt).Value = ventaIdNC;
                cmd.Parameters.Add("@P_DETALLEID", FbDbType.BigInt).Value = ventaDetIdNC;
                cmd.Parameters.Add("@P_FECHA_NC", FbDbType.TimeStamp).Value = fechaNC;
                cmd.Parameters.Add("@P_CANTIDAD", FbDbType.Numeric).Value = cantidad;

                // Ejecución asíncrona
                await cmd.ExecuteNonQueryAsync();
            }
                
        }

        public async static Task CapasDeCostosRegistrarEntrada
           (
            long articuloId, long sucursalId, long almacenId, DateTime fecha, 
            long conceptoId, long docId, long detalleId, decimal cantidad, decimal costo, 
            FbConnection db, FbTransaction transaction
            )

            {

                var parametros = new DynamicParameters();
                parametros.Add("P_ARTICULOID", articuloId, DbType.Int64);
                parametros.Add("P_SUCURSALID", sucursalId, DbType.Int64);
                parametros.Add("P_ALMACENID", almacenId, DbType.Int64);
                parametros.Add("P_FECHA", fecha, DbType.DateTime);
                parametros.Add("P_CONCEPTOID", conceptoId, DbType.Int64);
                parametros.Add("P_DOCUMENTOID", docId, DbType.Int64);
                parametros.Add("P_DETALLEID", detalleId, DbType.Int64);
                parametros.Add("P_CANTIDAD", cantidad, DbType.Decimal);
                parametros.Add("P_COSTOUNITARIO", costo, DbType.Decimal);

                string sql = Queries.CapasDeCostosRegistrarEntradaSP;
                await db.ExecuteAsync(sql, param: parametros, transaction:transaction, commandType: CommandType.StoredProcedure);
            }

        public async static Task CapasDeCostosReconstruirByArticuloYAlmacen   
            (
                long articuloId, long almacenId,
                FbConnection db, FbTransaction transaction
            )

        {

            // 1. Aquí va tu lógica actual para hacer UPDATE a DOCUMENTOSDETALLE
            // ActualizarCantidadEnTablasMaestras(articuloId, nuevaCantidad, trans);

            // 2. Llamada al SP Quirúrgico para limpiar y re-costear este artículo
            using (FbCommand cmd = new FbCommand("SP_RECONSTRUIR_CAPAS_DE_COSTOS", db, transaction))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@P_ARTICULOID", FbDbType.BigInt).Value = articuloId;
                cmd.Parameters.Add("@P_ALMACENID", FbDbType.BigInt).Value = almacenId;

                cmd.ExecuteNonQuery();
            }
        }




        #endregion




        // 2026-02-02 18:45 - Optimización de reconstrucción por lote
        public async static Task DocumentoReconstruyeCapasDeCostos(long almacenId, List<DocumentoDetalle> detalle, FbConnection db, FbTransaction transaction)
        {
            if (detalle == null || !detalle.Any()) return;

            // Extraemos IDs únicos para evitar procesar el mismo artículo varias veces
            var articulosUnicos = detalle
                .Select(d => d.ArticuloId)
                .Distinct()
                .ToList();

            foreach (var artId in articulosUnicos)
            {
                // Solo reconstruimos si el ID es válido
                if (artId > 0)
                {
                    await UtilsInv.CapasDeCostosReconstruirByArticuloYAlmacen(
                        articuloId: artId,
                        almacenId: almacenId,
                        db: db,
                        transaction: transaction
                    );
                }
            }
        }

        public async static Task ppDocumentoReconstruyeCapasDeCostos(long almacenId,List<DocumentoDetalle> detalle, FbConnection db, FbTransaction transaction)
        {

            foreach (var det in detalle)
            {
                await UtilsInv.CapasDeCostosReconstruirByArticuloYAlmacen(
                    articuloId: det.ArticuloId,
                    almacenId: almacenId,
                    db: db,
                    transaction: transaction
                    );
            }
        }



        public async static Task DocumentoRevierteEntrada(long conceptoId, List<DocumentoDetalle> detalle,FbConnection db, FbTransaction transaction)
        {
            string sqlSp = "SP_CAPASDECOSTOS_REVERTIR_ENTRADA";

            foreach (var det in detalle)
            {
                // Usamos DynamicParameters para capturar los valores de retorno del SP
                var p = new DynamicParameters();
                p.Add("P_CONCEPTOID", conceptoId);
                p.Add("P_DETALLEID", det.DocsDetId);
                p.Add("EXITO", dbType: DbType.Int16, direction: ParameterDirection.Output);
                p.Add("MENSAJE", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);

                await db.ExecuteAsync(sqlSp, p, transaction, commandType: CommandType.StoredProcedure);

                short exito = p.Get<short>("EXITO");
                string mensaje = p.Get<string>("MENSAJE");

                // Si el SP nos dice que NO se puede revertir (porque ya hubo ventas)
                if (exito == 0)
                {
                    transaction.Rollback();
                    throw new Exception($"Error en artículo {det.ArticuloDescripcion}: {mensaje}");
                }
            }
        }



        // 2026-02-02 18:50 - Reconstrucción optimizada para Ventas
        public async static Task VentaReconstruyeCapasDeCostos(long almacenId, List<VentaDetalle> detalle, FbConnection db, FbTransaction transaction)
        {
            if (detalle == null || !detalle.Any()) return;

            // Obtenemos solo los ArticuloId únicos para evitar procesos redundantes
            var articulosUnicos = detalle
                .Where(d => d.ArticuloId > 0)
                .Select(d => d.ArticuloId)
                .Distinct()
                .ToList();

            foreach (var artId in articulosUnicos)
            {
                await CapasDeCostosReconstruirByArticuloYAlmacen(
                    articuloId: artId,
                    almacenId: almacenId,
                    db: db,
                    transaction: transaction
                );
            }
        }
        public async static Task ppVentaReconstruyeCapasDeCostos(long almacenId, List<VentaDetalle> detalle, FbConnection db, FbTransaction transaction)
        {

            foreach (var det in detalle)
            {
                await CapasDeCostosReconstruirByArticuloYAlmacen(
                    articuloId: det.ArticuloId,
                    almacenId: almacenId,
                    db: db,
                    transaction: transaction
                    );
            }
        }




        public static async Task VentaRevierteSalidaCapasDeCostos (long conceptoId, List<VentaDetalle> detalle, FbConnection db, FbTransaction transaction)
        {
            string sqlSp = "SP_CAPASDECOSTOS_REVERTIR_SALIDA";
            foreach (var det in detalle)
            {
                // Usamos DynamicParameters para capturar los valores de retorno del SP
                var p = new DynamicParameters();
                p.Add("P_CONCEPTOID", conceptoId);
                p.Add("P_DETALLEID", det.VentaDetId);
                await db.ExecuteAsync(sqlSp, p, transaction, commandType: CommandType.StoredProcedure);
            }
        }


        public async static Task VentaRevierteEntrada(long conceptoId, List<VentaDetalle> detalle)
        {
            using (FbConnection db = General.GetDB())
            {
                await db.OpenAsync();

                using (var transaction = db.BeginTransaction())
                {
                    try
                    {
                        string sqlSp = "SP_CAPASDECOSTOS_REVERTIR_ENTRADA";

                        foreach (var det in detalle)
                        {
                            // Usamos DynamicParameters para capturar los valores de retorno del SP
                            var p = new DynamicParameters();
                            p.Add("P_CONCEPTOID", conceptoId);
                            p.Add("P_DETALLEID", det.VentaDetId);
                            p.Add("EXITO", dbType: DbType.Int16, direction: ParameterDirection.Output);
                            p.Add("MENSAJE", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);

                            await db.ExecuteAsync(sqlSp, p, transaction, commandType: CommandType.StoredProcedure);

                            short exito = p.Get<short>("EXITO");
                            string mensaje = p.Get<string>("MENSAJE");

                            // Si el SP nos dice que NO se puede revertir (porque ya hubo ventas)
                            if (exito == 0)
                            {
                                transaction.Rollback();
                                throw new Exception($"Error en artículo {det.Descripcion}: {mensaje}");
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw; // Re-lanzar para que la UI lo maneje
                    }
                }
            }
        }



        public static async Task SalidaRevierteCapasDeCostos(long conceptoId, List<DocumentoDetalle> detalle)
        {
            using (FbConnection db = General.GetDB())
            {
                await db.OpenAsync();
                using (var transaction = db.BeginTransaction())
                {
                    try
                    {
                        string sqlSp = "SP_CAPASDECOSTOS_REVERTIR_SALIDA";
                        foreach (var det in detalle)
                        {
                            // Usamos DynamicParameters para capturar los valores de retorno del SP
                            var p = new DynamicParameters();
                            p.Add("P_CONCEPTOID", conceptoId);
                            p.Add("P_DETALLEID", det.DocsDetId);
                            await db.ExecuteAsync(sqlSp, p, transaction, commandType: CommandType.StoredProcedure);
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw; // Re-lanzar para que la UI lo maneje
                    }
                }
            }
        }



        public async static Task<bool> DocumentoCapasUtilizadas(long conceptoId, long documentoId)
        {
            bool utilizadas = false;
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.CapasDeCostoUtilizadasXDocSelect;
                var capas = await db.QueryAsync<CapaDeCosto>(sql, new { ConceptoId = conceptoId, DocumentoId = documentoId });
                if (capas != null && capas.Count() > 0)
                    utilizadas = true;
            }
            return utilizadas;

        }


        public static string GeneraPDFDocumento(Documento doc, List<DocumentoDetalle> detalle)
        {
            string serie = doc.Serie;
            int folio = doc.Folio;
            string receptorNombre = "";
            string datosSucursal = "";

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.SucursalSelect();
                
                Sucursal suc = db.Query<Sucursal>(sql, new { doc.SucursalId }).FirstOrDefault();

                if (suc != null)
                    datosSucursal = suc.DatosAdicionales;




            }


            List<Documento> datosDocumento = new List<Documento>();
            doc.Total = doc.SubTotal + doc.IVA;
            datosDocumento.Add(doc);


            List<ReportDataSource> reportDataSources = new List<ReportDataSource>();

            reportDataSources.Add(
                new ReportDataSource { Name = "dsDocumento", Value = datosDocumento }
            );

            reportDataSources.Add(
                new ReportDataSource { Name = "dsDocumentoDetalle", Value = detalle }
            );

            ReportViewer rptDocumento = new ReportViewer();

            rptDocumento.ProcessingMode = ProcessingMode.Local;
            string rep = General.GetCarpetaReportes() + @"\PDV\Documento.rdlc";

            rptDocumento.LocalReport.ReportPath = rep;

            rptDocumento.LocalReport.DataSources.Clear();


            foreach (var dato in reportDataSources)
            {
                rptDocumento.LocalReport.DataSources.Add(dato);
            }

            Conversion con = new Conversion();
            string let = con.enletras(doc.SubTotal + doc.IVA);



            ReportParameter recNom = new ReportParameter("ReceptorNombre", receptorNombre);




            ReportParameter folioCompleto = new ReportParameter("FolioCompleto", $"{doc.Serie.Trim()} {doc.Folio.ToString()}");
            ReportParameter letras = new ReportParameter("Letras", let);

            ReportParameter datosAdicionales = new ReportParameter("DatosSucursal", datosSucursal);




            ReportParameter[] parametros =
            {
                recNom,
                folioCompleto,
                letras,
                datosAdicionales
            };

            rptDocumento.LocalReport.EnableExternalImages = true;
            rptDocumento.LocalReport.SetParameters(parametros);

            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;


            string archivoPDF = CarpetaDocumentosPDV(doc.SucursalId, doc.Fecha) + General.NombreArchivoPDF("DOC", doc.Serie, doc.Folio);


            var deviceInfo = @"<DeviceInfo>
            <EmbedFonts>None</EmbedFonts>
            </DeviceInfo>";

            byte[] bytes = rptDocumento.LocalReport.Render(
                "PDF", deviceInfo, out mimeType, out encoding, out filenameExtension,
                out streamids, out warnings);

            using (FileStream fs = new FileStream(archivoPDF, FileMode.Create))
            {
                fs.Write(bytes, 0, bytes.Length);
            }


            return archivoPDF;


        }


        public static string CarpetaDocumentosPDV(long sucursalId, DateTime Fecha)
        {
            string carpetaCfdis = ClinicaFB.Properties.Settings.Default.CarpetaDatos +$@"\SUC{sucursalId.ToString("D3")}\DOCSINV\";

            if (!Directory.Exists(carpetaCfdis))
            {
                Directory.CreateDirectory(carpetaCfdis);
            }
            string anio = Fecha.Year.ToString();

            carpetaCfdis = carpetaCfdis + anio + @"\";

            if (!Directory.Exists(carpetaCfdis))
            {
                Directory.CreateDirectory(carpetaCfdis);
            }


            string mes = Fecha.Month.ToString("D2");

            carpetaCfdis = carpetaCfdis + mes + @"\";

            if (!Directory.Exists(carpetaCfdis))
            {
                Directory.CreateDirectory(carpetaCfdis);
            }


            string dia = Fecha.Day.ToString("D2");

            carpetaCfdis = carpetaCfdis + dia + @"\";

            if (!Directory.Exists(carpetaCfdis))
            {
                Directory.CreateDirectory(carpetaCfdis);
            }



            return carpetaCfdis;

        }



        public static long GetConceptoInternoId(string tipo, string concepto)
        {
            long conceptoInternoId = 0; 
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.ConceptoSelectByDescripcion;
                conceptoInternoId = db.Query<long>(sql, new { Tipo =tipo, Descripcion = concepto}).FirstOrDefault();
            }
            return conceptoInternoId;
        }


        public static decimal ArticuloGetUltimoCostoFromCapas(long articuloId, long almacenId, long sucursalId)
        {
            decimal costo = 0;

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.ArticuloUltimoCostoByCapa;
                costo = db.Query<decimal>(sql, new { ARTICULOID = articuloId, ALMACENID = almacenId, SUCURSALID = sucursalId }).FirstOrDefault();

            }

            return costo;
        }

        public static decimal GetUltimoCostoArticulo(long almacenId, long articuloId, DateTime fecha)
        {
            decimal costo = 0;
            decimal conceptoCompraId = GetConceptoInternoId("E", "COMPRA");

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.ArticuloUltimoCostoFromCompras;

                List<ArticuloMovimiento> movimientos = db.Query<ArticuloMovimiento>(sql,  
                    new { AlmacenId=almacenId, ArticuloId = articuloId, ConceptoId = conceptoCompraId, Fecha= fecha }).ToList();

                if (movimientos != null && movimientos.Count > 0)
                {
                    
                    costo = movimientos[0].Importe;
                }
                if (costo<=1)
                {

                    //Si no tiene compras, se toma el costo del articulo
                    Articulo articulo = new Articulo();
                    sql = Queries.ArticuloSelect();
                    articulo = db.Query<Articulo>(sql, new { ArticuloId = articuloId }).FirstOrDefault();
                    if (articulo != null)
                        costo = articulo.Costo;
                }



            }
            return costo;
        }
        public static List<ConceptoMovInv> GetConceptosMovimientosInv(string tipo)
        {
            List<ConceptoMovInv> conceptos = new List<ConceptoMovInv>();
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.ConceptosSelect;
                conceptos = db.Query<ConceptoMovInv>(sql, new {Tipo = tipo }).ToList();


            }
            return conceptos;
        }


        public static async Task<List<DocumentoDetalle>> GetDocumentoDetalle(long documentoId)
        {
            List<DocumentoDetalle> detalle = new List<DocumentoDetalle>();
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.DocumentoDetalleSelect;
                detalle = (await db.QueryAsync<DocumentoDetalle>(sql, new { DocumentoId = documentoId })).ToList();
            }
            return detalle;
        }

        public static async Task QuitaDatosFactura(long ventaId)
        {

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.VentaQuitaDatosFactura;
                await db.ExecuteAsync(sql, new { VentaId = ventaId });
            }
        }

        public static async Task BorraPagos(int origenTipo, long docId, FbConnection db, FbTransaction transaction)
        {
            string sql = Queries.PagosDelete;
            await db.ExecuteAsync(sql, new { OrigenTipo = origenTipo, DoctoOrigenId = docId }, transaction);        

        }
        public static async Task GuardaPagos(List<Pago> pagos, FbConnection db, FbTransaction transaction)
        {
            string sql = Queries.PagoInsert;
            int origenTipo = pagos[0].OrigenTipo;
            int doctoOrigenId = pagos[0].DoctoOrigenId;

            foreach (var pagoDocto in pagos)
            {
                Pago pago = new Pago
                {
                    OrigenTipo = origenTipo,
                    DoctoOrigenId = doctoOrigenId,
                    Tipo = pagoDocto.Tipo,
                    Importe = pagoDocto.Importe,
                    Referencia = pagoDocto.Referencia
                };

                await db.ExecuteAsync(sql, pago,transaction);
            }
        }


        public static string MovimientoEntradaOSalida(ArticuloMovimiento movimiento)
        {
            string tipo = string.Empty;

            switch (movimiento.Tipo)
            {
                case "INI":
                    tipo = "E";
                    break;
                case "COM":
                    tipo = "E";
                    break;
                case "FAC":
                    tipo = "S";
                    break;
                case "TIC":
                    tipo = "S";
                    break;
                case "CAD":
                    tipo = "S";
                    break;
                case "DEV":
                    tipo = "S";
                    break;
                case "NDC":
                    tipo = "E";
                    break;
            }

            return tipo;
        }

        public static void AlmacenIncrementaFolioVenta(long almacenId, FbConnection db, FbTransaction fbtra)
        {
            string sql = Queries.AlmacenIncrementaFolioVenta;
            db.Execute(sql, new { AlmacenId = almacenId }, transaction: fbtra);
            
        }


        public static void AlmacenIncrementaFolioFactura(long almacenId, FbConnection db, FbTransaction fbtra)
        {
            string sql = Queries.AlmacenIncrementaFolioFactura;
            db.Execute(sql, new { AlmacenId = almacenId }, transaction: fbtra);
            
        }


        public static List<VentaDetalle> GetVentaDetalle(long ventaId)
        {
            List<VentaDetalle> ventas = new List<VentaDetalle>();
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.VentaDetallesSelect;
                ventas = db.Query<VentaDetalle>(sql, new { VentaId = ventaId }).ToList();
            }
            return ventas;
        }
        public static async Task<List<ArticuloMovimiento>> GetArticuloMovimientos(long articuloId, long almacenId, DateTime fechaInicial, DateTime fechaFinal)
        {
            List<ArticuloMovimiento> movimientos = new List<ArticuloMovimiento>();
            string sql = Queries.ArticuloAlmacenMovimientosSelect;
            using (FbConnection db = General.GetDB())
            {
                movimientos = (await db.QueryAsync<ArticuloMovimiento>(sql, new { ArticuloId = articuloId, AlmacenId = almacenId, FechaIni = fechaInicial, FechaFin = fechaFinal })).ToList();
            }
            return movimientos;
        }

        public static async Task<decimal> ArticuloGetInventarioInicial(int articuloId, long almacenId)
        {
            decimal inicial = 0;
            string sql = Queries.InventarioInicialSelect;
            using (FbConnection db = General.GetDB())
            {
                var inv = await db.QueryAsync<InventarioInicial>(sql, new { ArticuloId = articuloId, AlmacenId = almacenId });

                if (inv != null && inv.FirstOrDefault() !=null)
                    inicial = inv.FirstOrDefault().Cantidad;
            }

            return inicial;

        }

        public static async Task<decimal> ArticuloEntradas(int articuloId, long almacenId, DateTime fechaInicial, DateTime fechaFinal)
        {
            decimal entradas = 0;
            string sql = Queries.ArticuloAlmacenMovimientosSelect;

            using (FbConnection db = General.GetDB())
            {
               var movimientos = await db.QueryAsync<ArticuloMovimiento>(sql, new { ArticuloId = articuloId, AlmacenId = almacenId, FechaIni = fechaInicial, FechaFin = fechaFinal });

                foreach (var mov in movimientos)
                {
                    if (mov.Tipo == "COM")
                        entradas += mov.Cantidad;
                }


            }
            return entradas;
        }


        public static async Task<decimal> ArticuloSalidas(int articuloId, long almacenId, DateTime fechaInicial, DateTime fechaFinal)
        {
            decimal entradas = 0;
            string sql = Queries.ArticuloAlmacenMovimientosSelect;

            using (FbConnection db = General.GetDB())
            {
                var movimientos = await db.QueryAsync<ArticuloMovimiento>(sql, new { ArticuloId = articuloId, AlmacenId = almacenId, FechaIni = fechaInicial, FechaFin = fechaFinal });

                foreach (var mov in movimientos)
                {
                    if (mov.Tipo == "VEN")
                    {
                        Venta venta = db.Query<Venta>(Queries.VentaSelect, new { VentaId = mov.DocumentoId }).FirstOrDefault();
                        if (venta == null || venta.Cancelada || venta.Tipo=="GLO")
                            continue;

                        entradas += mov.Cantidad;
                    }
                }


            }
            return entradas;
        }



        public static async Task ArticuloActualizaFechaYCostoUltimaCompra(long articuloId, DateTime fecha,FbConnection db, FbTransaction transaction, decimal uCosto=0)
        {
            string sql = Queries.ArticuloSelect();
            Articulo articulo = db.Query<Articulo>(sql, new { ArticuloId = articuloId },transaction).FirstOrDefault();

            if (articulo == null || articulo.FechaUltimaCompra>=fecha) {
                return;
            }


            sql = Queries.ArticuloUpdateFechaUltimaCompra;
            await db.ExecuteAsync(sql, new { FechaUltimaCompra = fecha, ArticuloId = articuloId },transaction);
            if (uCosto > 0)
            {
                sql = Queries.ArticuloUpdateCosto;
                await db.ExecuteAsync(sql, new { Costo = uCosto, ArticuloId = articuloId }, transaction);
            }
        }

        public static string GetNombreTipoPago(int tipoPago)
        {
            string nombre = "";

            switch (tipoPago)
            {
                case 1:
                    nombre = "Efectivo";
                    break;
                case 2:
                    nombre = "Tarjeta debito";
                    break;
                case 3:
                    nombre = "Transferencia";
                    break;
                case 4:
                    nombre = "Tarjeta crédito";
                    break;
                case 5:
                    nombre = "Cheque";
                    break;
                case 6:
                    nombre = "Intermediarios";
                    break;
                default:
                    break;
            }
            return nombre;

        }

        public static string GetClaveFOP(int formaPago)
        {
            string cveFOP = "";

            switch (formaPago)
            {
                case 1:
                    cveFOP = "01";
                    break;
                case 2:
                    cveFOP = "28";
                    break;
                case 3:
                    cveFOP = "03";
                    break;
                case 4:
                    cveFOP = "04";
                    break;
                case 5:
                    cveFOP = "02";
                    break;
                case 6:
                    cveFOP = "31";
                    break;
                default:
                    break;
            }


            return cveFOP;
        }

        public static int GetFormaDePagomayor(List<Venta> ventas)
        {
            int tipoMayor = 0;
            List<Pago> pagos = new List<Pago>();    
            foreach (var venta in ventas)
            {
                var pag = UtilsInv.GetPagosVenta(venta.VentaId);

                foreach (var p in pag)
                {
                    int index = pagos.FindIndex(x => x.Tipo == p.Tipo);

                    if (index == -1)
                    {
                        pagos.Add(p);
                    }
                    else
                    {
                        pagos[index].Importe += p.Importe;
                    }
                }
            }

            pagos = pagos.OrderByDescending(x => x.Importe).ToList();

            tipoMayor = pagos.Count > 0 ? pagos[0].Tipo : 1;
            return tipoMayor;

        }
        public static List<Pago> GetPagosVenta(long ventaId)
        {
            List<Pago> pagos = new List<Pago>();
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.VentaPagosSelect;
                pagos = db.Query<Pago>(sql, new { DoctoOrigenId = ventaId }).ToList();
            }
            return pagos;
        }

        public static List<ArticulosVendidos> GetArticulosVendidos(int sucursalId, long almacenId, DateTime fechaInicial, DateTime fechaFinal)
        {
            List<ArticulosVendidos> articulosVendidos = new List<ArticulosVendidos>();
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.ArticulosVendidosXSucursalYFechas;
                articulosVendidos = db.Query<ArticulosVendidos>(sql, new { SucursalId = sucursalId, AlmacenId=almacenId, FechaIni = fechaInicial, FechaFin = fechaFinal }).ToList();
            }
            return articulosVendidos;
        }

        public static List<FormaPagoTotal> GetFormasPagoFechas(int sucursalId,long almacenId, int tipoOrigen, DateTime fechaInicial, DateTime fechaFinal)
        {
            List<FormaPagoTotal> formasPagoTotales = new List<FormaPagoTotal>();
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.FormasDePagoFechas;
                formasPagoTotales = db.Query<FormaPagoTotal>(sql, new {SucursalId = sucursalId, AlmacenId = almacenId, OrigenTipo = tipoOrigen, FechaIni = fechaInicial, FechaFin = fechaFinal }).ToList();
            }
            return formasPagoTotales;
        }


        public static BindingList<ArticuloExistencia> GetArticuloExistencias(int articuloId)
        {
            BindingList<ArticuloExistencia> existencias = new BindingList<ArticuloExistencia>();
            using (FbConnection db = General.GetDB())
            {

                string sql = Queries.ArticuloExistenciasSelect;
                var res = db.Query<ArticuloExistencia>(sql, new { ArticuloId = articuloId }).ToList();

                existencias = new BindingList<ArticuloExistencia>(res);
            }
            return existencias;
        }


        public static async Task VentaBorraDetalle(long ventaId, FbConnection db, FbTransaction transaction)
        {
            string sql = Queries.VentaDetallesDelete;
            await db.ExecuteAsync(sql, new { VentaId = ventaId }, transaction);
            

        }

        public static async Task VentaBorraMovimientos(long ventaId, FbConnection db, FbTransaction transaction)
        {
            string sql = Queries.DocumentoMovimientosDelete;
            await db.ExecuteAsync(sql, new { EsVenta = true, DocumentoId = ventaId }, transaction);
            
        }


        public static async Task DevuelveDetalleOriginal(List<VentaDetalle> articulos, long almacen, bool entrada,FbConnection db, FbTransaction fbTransaction)
        {
            foreach (var art in articulos)
            {
                string sql = Queries.ArticuloExistenciaSelect;
                ArticuloExistencia artExis = db.Query<ArticuloExistencia>(sql, new { AlmacenId = almacen, art.ArticuloId },transaction: fbTransaction).FirstOrDefault();

                if (artExis != null)
                {
                    if (entrada)
                        artExis.Entradas -= art.Cantidad;
                    else
                        artExis.Salidas -= art.Cantidad;

                    sql = Queries.ArticuloExistenciaUpdate;
                    await db.ExecuteAsync(sql, artExis,transaction: fbTransaction);
                }

                
            }


        }



        public static List<DocumentoDetalle> GetDetalleOriginal(List<DocumentoDetalle> detalle)
        {
            List<DocumentoDetalle> detalleOriginal = new List<DocumentoDetalle>();
            foreach (var det in detalle)
            {
                detalleOriginal.Add(new DocumentoDetalle
                {
                    DocsDetId = det.DocsDetId,
                    DocumentoId = det.DocumentoId,
                    ClaveProve = det.ClaveProve,
                    Clave = det.Clave,
                    UDM = det.UDM,
                    ArticuloDescripcion = det.ArticuloDescripcion,
                    ArticuloId = det.ArticuloId,
                    NoIden = det.NoIden,
                    CveProSer = det.CveProSer,
                    Cveuni = det.Cveuni,
                    Cantidad = det.Cantidad,
                    Precio = det.Precio,
                    TipoIVA = det.TipoIVA,
                    TasaIVA = det.TasaIVA,
                    IVA = det.IVA,
                    Borrado = det.Borrado,
                    ExistenciaInicial = det.ExistenciaInicial
                });
            }
            return detalleOriginal;
        }


        public static List<VentaDetalle> GetDetalleOriginal(List<VentaDetalle> detalle)
        {
            List<VentaDetalle> detalleOriginal = new List<VentaDetalle>();
            foreach (var det in detalle)
            {
                detalleOriginal.Add(new VentaDetalle
                {
                    VentaDetId = det.VentaDetId,
                    VentaId = det.VentaId,
                    ArticuloId = det.ArticuloId,
                    NoIden = det.NoIden,
                    Descripcion = det.Descripcion,
                    UDM = det.UDM,
                    Cantidad = det.Cantidad,
                    Precio = det.Precio,
                    Descuento = det.Descuento,
                    IVA = det.IVA,
                    TipoIVA = det.TipoIVA,
                    TasaIVA = det.TasaIVA,
                    CveProSer = det.CveProSer,
                    CveUni = det.CveUni,
                    RetIVA = det.RetIVA,
                    RetISR = det.RetISR,
                    DetalleIdRel = det.DetalleIdRel
                });
            }
            return detalleOriginal;
        }



        public static async Task DevuelveDetalleOriginal(List<DocumentoDetalle> articulos, long almacenId, bool entrada, FbConnection db, FbTransaction transaction)
        {
            foreach (var art in articulos)
            {
                string sql = Queries.ArticuloExistenciaSelect;
                ArticuloExistencia artExis = db.Query<ArticuloExistencia>(sql, new { AlmacenId = almacenId, art.ArticuloId },transaction).FirstOrDefault();
                if (artExis != null)
                {
                    if (entrada)
                        artExis.Entradas -= art.Cantidad;
                    else
                        artExis.Salidas -= art.Cantidad;

                    sql = Queries.ArticuloExistenciaUpdate;
                    await db.ExecuteAsync(sql, artExis, transaction);
                }
            }


        }

        public static async Task DocumentoBorra(long documentoId)
        {
            string sql = Queries.DocumentoDelete;
            using (FbConnection db = General.GetDB())
            {
                await db.ExecuteAsync(sql, new { DocumentoId = documentoId });
            }
        }

        public static async Task DocumentoBorraDetalle(long documentoId, FbConnection db, FbTransaction transaction)
        {
            string sql = Queries.DocumentoDetalleDelete;
            await db.ExecuteAsync(sql, new { DocumentoId = documentoId }, transaction);
        }

        public static async Task DocumentoBorraMovimientosXId(long documentoId,FbConnection db,FbTransaction transaction)
        {
            string sql = Queries.DocumentoMovimientosDelete;
            await db.ExecuteAsync(sql, new {EsVenta = false,DocumentoId = documentoId }, transaction);
        }



        public static async Task DocumentoBorraMovimientos(long documentoId)
        {
            string sql = Queries.DocumentoMovimientosDelete;
            using (FbConnection db = General.GetDB())
            {
                await db.ExecuteAsync(sql, new { EsVenta = false, DocumentoId = documentoId });
            }
        }

     



        public static void CargaAlmacenes(ref SfComboBox combo)
        {

            long almacenIdDefa = 0;
            string nombreAlmacenDefa = "";
            BindingList<Almacen> almacenes = null;

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
                almacenes = new BindingList<Almacen>(res);



            }
            combo.DataSource = null;
            combo.DataSource = almacenes;
            combo.ValueMember = "AlmacenId";
            combo.DisplayMember = "Nombre";
            combo.SelectedValue = almacenIdDefa;


        }




        public static async Task ActualizaExistencia(long articuloId, long almacenId,FbConnection db, FbTransaction transaction,  decimal entradas=0, decimal salidas=0)
        {
            string sql = "";
            ArticuloExistencia articuloExistencia = new ArticuloExistencia();
            sql = Queries.ArticuloExistenciaSelect;

            articuloExistencia = db.Query<ArticuloExistencia>(sql, new { ArticuloId = articuloId, AlmacenId = almacenId },transaction).FirstOrDefault();

            if (articuloExistencia == null)
            {

                articuloExistencia = new ArticuloExistencia();
                articuloExistencia.ArticuloId = articuloId;
                articuloExistencia.AlmacenId = almacenId;
                articuloExistencia.Entradas = entradas;
                articuloExistencia.Salidas = salidas;
                sql = Queries.ArticuloExistenciaInsert;

                await db.ExecuteAsync(sql, articuloExistencia,transaction);
            }
            else
            {
                articuloExistencia.Entradas = articuloExistencia.Entradas + entradas;
                articuloExistencia.Salidas = articuloExistencia.Salidas + salidas;
                sql = Queries.ArticuloExistenciaUpdate;
                await db.ExecuteAsync(sql, articuloExistencia, transaction);
            }


        }



        public static decimal GetExistencia(long articuloId, long almacenId)
        {
            decimal existencia = 0;
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.ArticuloExistenciaSelect;
                ArticuloExistencia articuloExistencia = db.Query<ArticuloExistencia>(sql, new { ArticuloId = articuloId, AlmacenId = almacenId }).FirstOrDefault();

                if (articuloExistencia != null)
                    existencia = articuloExistencia.Existencia;
            }
            return existencia;
        }
        public static async Task  ActualizaExistenciasYMovimientosVentaCancelada(long ventaId,FbConnection db, FbTransaction transaction)
        {

            string sql = Queries.VentaSelect;
            Venta vta = db.Query<Venta>(sql, new {VentaId = ventaId },transaction).FirstOrDefault();
            if (vta == null)
                return;

            sql = Queries.VentaDetallesSelect;
            var res = db.Query<VentaDetalle>(sql, new { VentaId = ventaId },transaction).ToList();


            ArticuloExistencia articuloExistencia;

            foreach (var cancelado in res)
            {
                sql = Queries.ArticuloExistenciaSelect;
                articuloExistencia = db.Query<ArticuloExistencia>(sql, new { cancelado.ArticuloId, vta.AlmacenId },transaction).FirstOrDefault();

                if (articuloExistencia == null)
                    continue;

                articuloExistencia.Salidas -= cancelado.Cantidad;
                sql = Queries.ArticuloExistenciaUpdate;
                db.Execute(sql, articuloExistencia,transaction);

            }

            

            await UtilsInv.VentaBorraMovimientos(ventaId, db, transaction);


        }

        public static void ActualizaExistenciasYMovimientosNotaCancelada(long notaId)
        {

            using (FbConnection db = General.GetDB())
            {


                string sql = Queries.VentaSelect;
                Venta nota = db.Query<Venta>(sql, new { VentaId = notaId }).FirstOrDefault();

                if (nota == null)
                    return;

                sql = Queries.VentaDetallesSelect;
                var res = db.Query<VentaDetalle>(sql, new { VentaId = notaId }).ToList();


                ArticuloExistencia articuloExistencia = new ArticuloExistencia();

                foreach (var cancelado in res)
                {
                    sql = Queries.ArticuloExistenciaSelect;
                    articuloExistencia = db.Query<ArticuloExistencia>(sql, new {cancelado.ArticuloId, nota.AlmacenId }).FirstOrDefault();

                    if (articuloExistencia == null)
                        continue;

                    articuloExistencia.Entradas -= cancelado.Cantidad;
                    sql = Queries.ArticuloExistenciaUpdate;
                    db.Execute(sql, articuloExistencia);

                }

                sql = Queries.DocumentoMovimientosDelete;
                db.Execute(sql, new { EsVenta = true, DocumentoId = nota.VentaId });


            }


        }


    }
}
