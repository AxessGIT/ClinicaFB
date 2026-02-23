using AForge.Video.DirectShow;
using ClinicaFB.Agenda;
using ClinicaFB.Configuracion.Facturacion;
using ClinicaFB.Modelo;
using ClinicaFB.ModeloConfiguracion;
using ClinicaFB.ModeloWEB;
using CsvHelper;
using Dapper;
using FirebirdSql.Data.FirebirdClient;
using MailKit.Net.Smtp;
using Microsoft.ReportingServices.Interfaces;
using MimeKit;
using Syncfusion.Windows.Forms.PdfViewer;
using Syncfusion.WinForms.ListView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ClinicaFB.Helpers
{
    public class General
    {

        public static async Task<int> CreaCfdiDesdeCFDi(string archivoXML)
        {
            int resultado = 0;
            using (FbConnection db = GetDB())
            {
                await db.OpenAsync();
                using (var transaction = db.BeginTransaction())
                {

                    try
                    {

                        // Cargar archivo
                        XDocument xml = XDocument.Load(archivoXML);
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

                        String sql = "";
                        /*string sql = Queries.RazonSocialSelectXRFC();


                        long razonSocialId = 0;
                        if (rfcReceptor != "XAXX010101000")
                            razonSocialId = db.QuerySingleOrDefault<long>(sql, new { Rfc = rfcReceptor }, transaction);*/


                        CFDI newCFDi = new CFDI
                        {
                            EmisorId = 1,
                            Serie = serie,
                            Folio = Convert.ToInt32(folio),
                            PacienteId = 0,
                            RazonSocialId = 15699,
                            TipoComprobante = "I",
                            Fecha = new DateTime(2026, 1, 9),
                            FormaPago = cveFOP,
                            MetodoPago = cveMEP,
                            Moneda = "MXN",
                            TipoDeCambio = 1,
                            LugarExpedicion = "62260",
                            UsoCFdi = "G03",
                            SubTotal = subTotal,
                            Total = total,
                            IVA = totalImpuestos,
                            uid = uid,
                        };

                        sql = Queries.CfdiInsert();
                        long cfdiID = db.ExecuteScalar<long>(sql, newCFDi, transaction);



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
                            string descripcion = (string)concepto.Attribute("Descripcion") ?? "";



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
                                imp = db.Query<Impuesto>(sql, new { articulo.ImpuestoId }, transaction).FirstOrDefault();

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

                            CfdiDetalle detalle = new CfdiDetalle
                            {
                                CFDIId = (int)cfdiID,
                                ArticuloId = (int)articuloId,
                                NoIden = clave,
                                Descripcion = descripcion,
                                Cantidad = cantidad,
                                ValorUnitario = precio,
                                CveProSer = cveProSer,
                                CveUni = cveUNI,
                                TasaIVA = tasaIVA,                                
                                Descuento = 0,
                                TipoIVA = tipoIVA,
                                IVA = iva
                            };
                            sql = Queries.CfdiDetalleInsert();
                            db.Execute(sql, detalle, transaction);
                            resultado = newCFDi.Folio;

                        }


                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Error al crear CFDI desde XML: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return -1;
                    }
                }
            }
            return resultado;
        }



    public static void ImprimePDF(string rutaArchivoPDF)
    {
        try
        {
            PdfViewerControl pdfViewer = new PdfViewerControl();
            pdfViewer.Load(rutaArchivoPDF);

            // Configurar opciones de impresión
            using (PrintDialog printDialog = new PrintDialog())
            {
                printDialog.AllowCurrentPage = true;
                printDialog.AllowSomePages = true;
                printDialog.AllowSelection = false;
                printDialog.UseEXDialog = true;

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    // No se puede asignar PrinterSettings directamente, pero se puede especificar la impresora por nombre
                    string printerName = printDialog.PrinterSettings.PrinterName;                     
                    pdfViewer.Print(printerName);
                }
            }

            pdfViewer.Unload();
            pdfViewer.Dispose();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al imprimir: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }


  
        public static List<Articulo> GetArticulosFromCSV(string archivoCSV)
        {
            List<Articulo> articulos = new List<Articulo>();
            List<ArticuloImportar> articulosImportdos = new List<ArticuloImportar>();
            var csv = new CsvReader(new StreamReader(archivoCSV), CultureInfo.CurrentCulture);

            articulosImportdos = csv.GetRecords<ArticuloImportar>().ToList();

            foreach (var art in articulosImportdos)
            {
                Articulo articulo = new Articulo();
                articulo.CodigoBarras = art.Codigo;
                articulo.Descripcion = art.Nombre;
                articulo.Precio1 = art.Precio;
                articulo.ImpuestoId = art.Impuesto==15?1:2;
                articulos.Add(articulo);
            }

            return articulos;
        }

        public static Sucursal GetDatosSucursal()
        {
            int sucursalId = (int)Properties.Settings.Default.SucursalId;
            Sucursal sucursal = new Sucursal();

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.SucursalSelect();
                sucursal = db.Query<Sucursal>(sql, new {SucursalId = sucursalId }).FirstOrDefault();
            }
            return sucursal;
        }

        public static void IncrementaFolioFacPDV()
        {
            int sucursalId = (int)Properties.Settings.Default.SucursalId;
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.SucursalSetSiguienteFolioFacPDV;
                db.Execute(sql, new { SucursalId = sucursalId });
            }
        }

        public static void IncrementaFolioVentas()
        {
            int sucursalId = (int)Properties.Settings.Default.SucursalId;
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.SucursalSetSiguienteFolioVentas;
                db.Execute(sql, new { SucursalId = sucursalId });
            }
        }

        public static Almacen GetAlmacenDefault()
        {
            Almacen almacen = new Almacen();

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.AlmacenDefaultSelect();
                almacen = db.Query<Almacen>(sql).FirstOrDefault();


            }
            return almacen;
        }

  
        public static bool IngresoFacturado(long ingresoId)
        {
            bool facturado=false;

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.IngresoFacturado();
                CFDI cfdi = db.Query<CFDI>(sql, new {IngresoId = ingresoId }).FirstOrDefault();

                facturado = cfdi != null;
            }
            return facturado;
        }


        public static Doctor GetDoctorXUsuario()
        {
            Doctor doc;
            int usuarioId = (int) Properties.Settings.Default.Usuario_ID;
            doc = GetDoctorXUsuario(usuarioId);
            return doc;
        }

        public static Doctor GetDoctorXUsuario(int usuarioId)
        {
            Doctor doc = new Doctor();

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.DoctorSelectXUsuario();
                doc = db.Query<Doctor>(sql, new {UsuarioId = usuarioId }).FirstOrDefault();

            }
            return doc;

        }

        public static string GetCarpetaReportes()
        {
            string carpetaReportes = "";

            int sucursalId = (int)Properties.Settings.Default.SucursalId;

            string sql = Queries.SucursalSelect();

            using (FbConnection db = General.GetDB())
            {
                Sucursal sucursal = db.Query<Sucursal>(sql, new { SucursalId = sucursalId }).FirstOrDefault();
                if ((sucursal != null) && string.IsNullOrEmpty(sucursal.CarpetaReportes) == false)
                {
                    carpetaReportes = sucursal.CarpetaReportes;
                    return carpetaReportes;
                }
            }


            using (FbConnection db = General.GetConexionConfig())
            {

                sql = Queries.EmpresaSelect();
                Empresa emp = db.Query<Empresa>(sql, new { Empresa_Id = Properties.Settings.Default.Empresa_ID }).FirstOrDefault();
                carpetaReportes = emp.CarpetaReportes;
            }


            return carpetaReportes;

        }

        public  static string PacienteDireccion(int pacienteId)
        {
            string dir = "";

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.PacienteReporteExpedienteSelect();
                DatosExpediente datosExpediente= db.Query<DatosExpediente>(sql, new {PacienteId = pacienteId}).FirstOrDefault();
                if (datosExpediente != null)
                {
                    dir = datosExpediente.Direccion == null ? "" : datosExpediente.Direccion.Trim();
                    dir += datosExpediente.Colonia == null ? "" : $" {datosExpediente.Colonia.Trim()}";
                    dir += datosExpediente.Ciudad == null ? "" : $" {datosExpediente.Ciudad.Trim()}";
                    dir += datosExpediente.Estado == null ? "" : $" {datosExpediente.Estado.Trim()}";
                    dir += datosExpediente.CP== null ? "" : $" C.P. {datosExpediente.CP.Trim()}";
                }
            }
            return dir;
        }
        public static void BotonBuscarClaveSAT(string tipo, ref TextBox txtClave, ref TextBox txtDescripcion )
        {
            ClaveSATBuscar claveSATBuscar = new ClaveSATBuscar(tipo);
            claveSATBuscar.ShowDialog();

            if (!string.IsNullOrEmpty(claveSATBuscar.Clave))
            {
                txtClave.Text = claveSATBuscar.Clave;
                ClaveSATValidar(tipo, ref txtClave,ref txtDescripcion);

            }

        }
        public static void ClaveSATValidar(string tipo, ref TextBox txtClave, ref TextBox txtDescripcion)
        {

            if (string.IsNullOrEmpty(txtClave.Text))
            {
                return;
            }
            string des = General.GetDescripcionClaveSAT(tipo, txtClave.Text.Trim());

            if (string.IsNullOrEmpty(des))
            {
                MessageBox.Show("No existe esa clave", "Confirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtClave.Text = "";
                txtDescripcion.Text = "";

            }
            else
            {
                txtDescripcion.Text = des;
            }


        }

        public static  void CargaDispositivosVideo(ref ComboBox combo, ref FilterInfoCollection dispositivosVideo)
        {
            combo.Items.Clear();
            dispositivosVideo = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach (FilterInfo disp in dispositivosVideo)
            {
                combo.Items.Add(disp.Name);

            }

            if (combo.Items.Count > 0)
            {
                combo.SelectedIndex = 0;
            }
        }



        public static string CarpetaImagenesPaciente(int pacienteId)
        {

            string carpeta;

            carpeta = $@"pac{pacienteId.ToString("000000000000000")}\";
            CarpetaImagenes(CarpetaImagenesEmpresa(), carpeta);
            return carpeta;
        }


        public static string CarpetaImagenesEmpresa()
        {
            string carpeta = "";

            int sucursalId = (int)Properties.Settings.Default.SucursalId;
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.SucursalSelect();
                Sucursal sucursal = db.Query<Sucursal>(sql, new { SucursalId = sucursalId }).FirstOrDefault();
                if ((sucursal != null) && string.IsNullOrEmpty(sucursal.CarpetaImagenes) == false)
                {
                    carpeta = sucursal.CarpetaImagenes;
                    return carpeta;
                }
            }
            using (FbConnection db = General.GetConexionConfig())
            {
                int empresaId = (int)ClinicaFB.Properties.Settings.Default.Empresa_ID;
                string sql = Queries.EmpresaSelect();
                Empresa emp = db.Query<Empresa>(sql, new { Empresa_Id = empresaId }).FirstOrDefault();
                carpeta = emp.CarpetaImagenes;


            }

            return carpeta;

        }

        public static CorreoInfo DatosCorreo()
        {
            CorreoInfo datos = new CorreoInfo();

            datos.Servidor = Properties.Settings.Default.CorreoServidor;
            datos.Usuario = Properties.Settings.Default.CorreoUsuario;
            datos.Cuenta = Properties.Settings.Default.CorreoCuenta;
            datos.UsarSSL = Properties.Settings.Default.CorreoSSL;
            datos.Mensaje = Properties.Settings.Default.CorreoMensaje;

            return datos;
        }

        
        public static string NombreArchivoPDF(string tipo, string serie, int folio)
        {

            string nombreArchivo = tipo.Trim() + serie.Trim() + folio.ToString("D10") + ".pdf";
            return nombreArchivo;
        }


        public static string NombreArchivoCfdi(string tipo,string serie, int folio)
        {

            string nombreArchivo = tipo.Trim() + serie.Trim() + folio.ToString("D10") + ".xml";
            return nombreArchivo;
        }


        public static string CarpetaFacturaPDV(string rfcEmisor, DateTime Fecha)
        {
            string carpetaCfdis = ClinicaFB.Properties.Settings.Default.CarpetaDatos + $@"\{rfcEmisor}\PDV\Cfdis\";

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

        public static string CarpetaCfdi(string rfcEmisor, DateTime Fecha)
        {
            string carpetaCfdis = ClinicaFB.Properties.Settings.Default.CarpetaDatos +  $@"\{rfcEmisor}\Cfdis\";

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


        public static void GuardaCfdi(string rfcEmisor,string tipo,  DateTime fecha, string serie,int folio, string xml)
        {
            string carpeta = CarpetaCfdi(rfcEmisor, fecha);

            string nombreArchivo = carpeta + NombreArchivoCfdi(tipo, serie, folio);

            File.WriteAllText(nombreArchivo, xml);
            

        }

        private static Random random = new Random();




        

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static bool CarpetaImagenes(string raiz,string carpeta)
        {

            bool ok = true;
            string[] partes = carpeta.Split(new char[] { '\\' });
            string ruta = raiz.Trim();
            foreach (var folder in partes)
            {
                ruta = ruta.Trim()+ "\\"+folder.Trim();
                if (!Directory.Exists(ruta))
                {
                    Directory.CreateDirectory(ruta);

                }

            }


            return ok;

        }
        public static void BuscarClaveSAT(string tipo, ref TextBox txtClave, ref TextBox txtDescripcion)
        {
            ClaveSATBuscar claveSATBuscar = new ClaveSATBuscar(tipo);
            claveSATBuscar.ShowDialog();
            if (!string.IsNullOrEmpty(claveSATBuscar.Clave))
            {
                txtClave.Text = claveSATBuscar.Clave;
                ValidarClaveSAT(tipo, ref txtClave, ref txtDescripcion);
            }

        }
        public static void ValidarClaveSAT(string tipo, ref TextBox txtClave, ref TextBox txtDescripcion)
        {
            if (string.IsNullOrEmpty(txtClave.Text))
                return;

            string des = General.GetDescripcionClaveSAT(tipo, txtClave.Text.Trim());
            if (string.IsNullOrEmpty(des))
            {
                MessageBox.Show("No existe esa clave", "Confirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtClave.Text = "";
                txtDescripcion.Text = "";

            }
            else
            {
                txtDescripcion.Text = des;
            }


        }

        public static string GetDescripcionClaveSAT(string tipo, string clave)
        {
            string sql = Queries.ClaveSATSelectXClave();
            string des = "";
            using (FbConnection db = General.GetDB())
            {
                var res = db.Query<ClaveSAT>(sql, new { Tipo = tipo, Clave = clave }).FirstOrDefault();

                if (res != null)
                {
                    des = res.Descripcion;
                }

            }
            return des;

        }

        public static NumberFormatInfo GetFormatoDecimal()
        {
            NumberFormatInfo numberFormat = new NumberFormatInfo();
            numberFormat.NumberDecimalSeparator = ".";
            numberFormat.NumberGroupSeparator = ",";
            return numberFormat;

        }


        public static NumberFormatInfo GetFormatoPorcentajeRetencion()
        {
            NumberFormatInfo numberFormat = new NumberFormatInfo();
            numberFormat.NumberDecimalSeparator = ".";
            numberFormat.NumberGroupSeparator = ",";
            numberFormat.PercentDecimalDigits = 5;
            return numberFormat;

        }



        public static FbConnection GetConexionConfig()
        {

            DatosConexionServidor conexionDatos = GetDatosConexion();

            FbConnectionStringBuilder csb = new FbConnectionStringBuilder();

            csb.DataSource = conexionDatos.Servidor;

            string carpeta = conexionDatos.Carpeta;


            csb.Database = $@"{carpeta.Trim()}\Config\Configuracion.FDB";

            csb.UserID = "SYSDBA";


            csb.Password = conexionDatos.PassWord;

            FbConnection dbConfiguracion = new FbConnection();
            dbConfiguracion.ConnectionString = csb.ToString();
            return dbConfiguracion;



        }



        

        public static DatosConexionServidor GetDatosConexion()
        {
            DatosConexionServidor conexionDatos = null;

            if (!string.IsNullOrEmpty(Properties.Settings.Default.Servidor))
            {
                conexionDatos = new DatosConexionServidor();
                conexionDatos.Servidor = Properties.Settings.Default.Servidor;
                conexionDatos.Usuario = Properties.Settings.Default.UsuarioBD;
                conexionDatos.PassWord = Properties.Settings.Default.PassWord;
                conexionDatos.Puerto = Properties.Settings.Default.Puerto;
                conexionDatos.Carpeta = Properties.Settings.Default.CarpetaDatos;


                string bdd = "";
                if (string.IsNullOrEmpty(Properties.Settings.Default.BaseDeDatos) && Properties.Settings.Default.Empresa_ID != 0) {

                    FbConnectionStringBuilder csb = new FbConnectionStringBuilder();
                    csb.UserID = "SYSDBA";
                    csb.DataSource = conexionDatos.Servidor;
                    csb.Password = conexionDatos.PassWord;
                    csb.Port = conexionDatos.Puerto;
                    csb.Database = $@"{conexionDatos.Carpeta.Trim()}\Config\Configuracion.FDB";

                    string cadcon = csb.ToString();
                    FbConnection conn = new FbConnection(cadcon);
                    FbCommand comando = new FbCommand();
                    comando.Connection = conn;
                    comando.CommandText = "Select Nombre_Corto From Empresas Where Empresa_Id =" + Properties.Settings.Default.Empresa_ID.ToString();

                    conn.Open();
                    FbDataReader dr = comando.ExecuteReader();

                    if (dr.Read()) {
                        bdd = dr.GetString(0).Trim().ToUpper();
                        bdd= $@"{conexionDatos.Carpeta.Trim()}\{bdd}.FDB";
                    }
                    dr.Close();
                    conn.Close();

                }

                conexionDatos.BaseDeDatos = !string.IsNullOrEmpty(bdd)?bdd: Properties.Settings.Default.BaseDeDatos;


            }

            return conexionDatos;

        }
        

        public static string GetCadenaDeConexion()
        {
            string concad = "";

            DatosConexionServidor datosConexion = GetDatosConexion();
            if (datosConexion == null)
                return "";

            FbConnectionStringBuilder  csb = new FbConnectionStringBuilder ();

            csb.DataSource = datosConexion.Servidor;
            csb.UserID = "SYSDBA";// datosConexion.Usuario;
            csb.Password = datosConexion.PassWord;
            csb.Port = datosConexion.Puerto;
            csb.Database = datosConexion.BaseDeDatos;
            csb.Charset = "UTF8";
            csb.ConnectionLifeTime = 30;
            csb.Pooling = true;
            csb.MinPoolSize = 0;
            csb.MaxPoolSize = 15;
            csb.ConnectionTimeout = 15;
            csb.CommandTimeout = 30;
            csb.PacketSize = 8192;



            concad = csb.ToString();


            return concad;
        }


        /*public static FbConnection GetDB()
        {
            /*FbConnection conn = null;
            string concad = GetCadenaDeConexion();

            if (string.IsNullOrEmpty(concad))
                return conn;

            conn = new FbConnection();
            conn.ConnectionString = concad;

            return conn;

            string concad = GetCadenaDeConexion();
            FbConnection conn = new FbConnection(concad);

            // Validar conexión inmediatamente
            try
            {
                conn.Open();
                conn.Close();
            }
            catch (FbException)
            {
                // Si falla, limpiar pool y crear nueva
                FbConnection.ClearAllPools();
                conn.Dispose();
                conn = new FbConnection(concad);
            }

            return conn;



        }*/
        private static readonly object _poolLock = new object();
        private static DateTime _ultimaLimpieza = DateTime.MinValue;

        private static int _operacionesDesdeUltimaLimpieza = 0;
        private static readonly object _contadorLock = new object();

        public static FbConnection GetDB()
        {
            string concad = GetCadenaDeConexion();
            if (string.IsNullOrEmpty(concad))
                return null;

            // Incrementar contador thread-safe
            lock (_contadorLock)
            {
                _operacionesDesdeUltimaLimpieza++;
                
                // Limpiar cada 100 operaciones
                if (_operacionesDesdeUltimaLimpieza >= 100)
                {
                    LimpiarPoolConexiones();
                    _operacionesDesdeUltimaLimpieza = 0;
                }
            }

            try
            {
                return new FbConnection(concad);
            }
            catch (FbException)
            {
                LimpiarPoolConexiones();
                System.Threading.Thread.Sleep(50);
                return new FbConnection(concad);
            }
        }

        // Método thread-safe para limpiar pool
        public static void LimpiarPoolConexiones()
        {
            lock (_poolLock)
            {
                try
                {
                    // Evitar limpiezas muy frecuentes (mínimo 30 segundos entre limpiezas)
                    if ((DateTime.Now - _ultimaLimpieza).TotalSeconds < 30)
                        return;

                    FbConnection.ClearAllPools();
                    _ultimaLimpieza = DateTime.Now;
                    System.Diagnostics.Debug.WriteLine($"[{DateTime.Now:HH:mm:ss}] Pool limpiado");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error limpiando pool: {ex.Message}");
                }
            }
        }



        public static CitaWEB BuildCitaWEB(FbConnection db, Cita c)
        {
            CitaWEB cw = new CitaWEB();

            cw.CitaInicialId = c.Cita_Origen_Id;
            cw.Fecha = c.Fecha;
            cw.Hora = c.Hora;

            cw.TipoRecurso = c.TipoRecurso;
            cw.RecursoId = c.Recurso_Id;
            cw.RecursoNombre = GetNombreRecurso(cw.TipoRecurso, cw.RecursoId);

            cw.PacienteId = c.Paciente_Id;
            cw.PacienteNombre = GetNombrePaciente((int)c.Paciente_Id);

            cw.Bloqueada = c.Bloqueada;
            cw.BloqueoMotivoId = c.BloqueoMotivo_Id;
            cw.BloqueoMotivo = GetDescripcion("BLO", (int) cw.BloqueoMotivoId);

            cw.Cancelada = c.Cancelada;
            cw.CancelacionMotivoId = c.CancelacionMotivo_Id;
            cw.CancelacionMotivo = GetDescripcion("MOC", (int)cw.CancelacionMotivoId);

            cw.Asistio = c.Asistio;
            cw.Confirmado = c.Confirmado;
            cw.OriginalId = c.Cita_Id;

            return cw;

        }

        public static void MandaCorreoConfirmacionCancelacion
            (FbConnection db, 
            DatosEmpresa datosEmpresa, 
            Paciente paciente,
            DateTime fecha, 
            string hora, 
            string texto, 
            bool cancelada)
        {

            if (datosEmpresa == null)
                return;

            if (
                string.IsNullOrEmpty(paciente.Correos) ||
                string.IsNullOrEmpty(datosEmpresa.AvisosServidor) ||
                string.IsNullOrEmpty(datosEmpresa.AvisosCuenta) ||
                string.IsNullOrEmpty(datosEmpresa.AvisosPassword) ||
                string.IsNullOrEmpty(datosEmpresa.AvisosUsuario) ||
                datosEmpresa.AvisosPuerto == 0
                )
                return;


            var mailMessage = new MimeMessage();
            mailMessage.From.Add(new MailboxAddress(datosEmpresa.Nombre, datosEmpresa.AvisosCuenta));
            mailMessage.To.Add(new MailboxAddress(paciente.NombreCompleto, paciente.Correos));
            mailMessage.Subject = cancelada ? "Su cita ha sido cancelada" : "Su cita ha sido agendada";
            mailMessage.Body = new TextPart("plain")
            {
                Text = texto
            };


            try
            {
                using (var smtpClient = new SmtpClient())
                {
                    smtpClient.Connect(datosEmpresa.AvisosServidor, (int)datosEmpresa.AvisosPuerto, datosEmpresa.AvisosSSL == true);
                    smtpClient.Authenticate(datosEmpresa.AvisosUsuario, datosEmpresa.AvisosPassword);
                    smtpClient.Send(mailMessage);
                    smtpClient.Disconnect(true);
                }

            }
            catch (Exception)
            {

            }


        }

        public static void LLenaLista(FbConnection db, string tipo, ref BindingList<DescripcionCat> lista)
        {
            string sql = "Select Descripcion_Id, Tipo, Descripcion From Descripciones Where Tipo=@Tipo Order By Descripcion";

            var res = db.Query<DescripcionCat>(sql, new { Tipo = tipo }).ToList();
            lista = new BindingList<DescripcionCat>(res);

        }


        public static BindingList<DescripcionCat> DevuelveListaDescripcion(string tipo)
        {
            BindingList<DescripcionCat> lista = new BindingList<DescripcionCat>();


            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.DescripcionesSelectxTipo();// "Select Descripcion_Id, Tipo, Descripcion From Descripciones Where Tipo=@Tipo Order By Descripcion";
                var res = db.Query<DescripcionCat>(sql, new { Tipo = tipo }).ToList();
                lista = new BindingList<DescripcionCat>(res);

            }
            return lista;

        }


        public static List<InfoHorario> GeneraHorarios(int horaInicial, int horaFinal)
        {
            List<InfoHorario> horarios = new List<InfoHorario>();
            int renglon = 1;

            for (int i = horaInicial; i <= horaFinal; i++)
            {

                for (int j = 0; j <= 45; j += 15)
                {
                    horarios.Add(new InfoHorario() { Hora = $"{i.ToString("00")}:{j.ToString("00")}", Renglon = renglon });
                    renglon++;
                }

            }
            return horarios;

        }

        public static void LlenaComboHoras(ref ComboBox combo)
        {
            List<string> horas = GeneraHoras();
            combo.Items.Clear();
            foreach (var hora in horas)
            {
                combo.Items.Add(hora);
            }

        }

        public static List<string> GeneraHoras()
        {
            int horaInicial = 8;
            int horaFinal = 22;
            List<string> horarios = new List<string>();
            int renglon = 1;

            for (int i = horaInicial; i <= horaFinal; i++)
            {

                for (int j = 0; j <= 45; j += 15)
                {
                    horarios.Add($"{i.ToString("00")}:{j.ToString("00")}");
                    renglon++;
                }

            }
            return horarios;
        }

        public static int GetDescripcionId(string tipo, string des, bool agregar=false)
        {
            int id = 0;

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.DescripcionSelectxDescripcion();
                DescripcionCat cat = db.Query<DescripcionCat>(sql, new {Tipo=tipo, Descripcion=des  }).FirstOrDefault();
                if (cat == null)
                {
                    if (agregar)
                    {
                        cat = new DescripcionCat();
                        cat.Tipo = tipo;
                        cat.Descripcion = des;
                        sql = Queries.DescripcionInsert();

                        id = db.ExecuteScalar<int>(sql,cat);

                    }
                }
                else 
                { 
                    id = (int)cat.Descripcion_Id;
                }

            }
            return id;

        }

        public static string GetDescripcion(string tipo, int descripcionId)
        {
            if (string.IsNullOrEmpty(tipo) || descripcionId <= 0)
                return "";

            string nombre = "";
            DescripcionCat des = new DescripcionCat();
            string sql = Queries.DescripcionSelectxTipo();


            using (FbConnection db = General.GetDB())
            {
                des = db.QueryFirstOrDefault<DescripcionCat>(sql, new { Tipo = tipo, Descripcion_Id = descripcionId });

            }
            if (des != null)
                nombre = des.Descripcion;
            return nombre;
        }




        public static string GetNombrePaciente(int pacienteId)
        {
            if (pacienteId <= 0)
                return "";


            string nombre = "";

            using (FbConnection db = General.GetDB())
            {

                Paciente pac = new Paciente();
                string sql = Queries.PacienteSelect();
                pac = db.QueryFirstOrDefault<Paciente>(sql, new { Paciente_Id = pacienteId });

                if (pac != null)
                {
                    nombre = pac.NombreCompleto;
                }

            }

            return nombre;
        }

        public static string GetNombreRecurso(string tipo, long id)
        {
            string nombreRecurso = "";

            using (FbConnection db = General.GetDB())
            {


                switch (tipo)
                {
                    case "DOC":
                        Doctor doc = db.QueryFirstOrDefault<Doctor>(Queries.DoctorSelect(), new { Doctor_Id = id });
                        nombreRecurso = doc == null ? "" : doc.Nombres.Trim() + " " + doc.Apellido_Paterno.Trim() + " " + doc.Apellido_Materno.Trim();
                        break;
                    case "EQU":
                        Equipo equi = db.QueryFirstOrDefault<Equipo>(Queries.EquipoSelect(), new { Equipo_Id = id });
                        nombreRecurso = equi == null ? "" : equi.Nombre;
                        break;
                    case "CUA":
                        Cuarto cua = db.QueryFirstOrDefault<Cuarto>(Queries.CuartoSelect(), new { Cuarto_Id = id });
                        nombreRecurso = cua == null ? "" : cua.Nombre;
                        break;
                }
            }

            return nombreRecurso;

        }

        public static Image ByteArrayToImagen(byte[] datos)
        {
            Byte[] byteBLOBData = new Byte[0];
            byteBLOBData = datos;
            MemoryStream stmBLOBData = new MemoryStream(byteBLOBData);
            return Image.FromStream(stmBLOBData);

        }

        public static byte[] ImagenToByteArray(Image imagen)
        {
            var ms = new MemoryStream();

            imagen.Save(ms, imagen.RawFormat);
            return ms.ToArray();

        }

        public static int GetIdImpuestoDefault()
        {
            int impuestoId = 0;

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.ImpuestoSelectDefault();
                Impuesto imp = db.QueryFirstOrDefault<Impuesto>(sql);
                if (imp != null)
                {
                    impuestoId = imp.ImpuestoId;
                }
                     
            }
            return impuestoId;

        }
        public static void ConfiguraComboImpuestos(ref SfComboBox combo)
        {
            BindingList<Impuesto> impuestos = new BindingList<Impuesto>();

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.ImpuestosSelect();
                var res = db.Query<Impuesto>(sql).ToList();
                impuestos = new BindingList<Impuesto>(res);
            }
            combo.DataSource = impuestos;
            combo.DisplayMember = "Descripcion";
            combo.ValueMember = "ImpuestoId";

        }




        public static void ConfiguraCombo(ref SfComboBox combo,string tipo)
        {
            combo.DataSource = DevuelveListaDescripcion(tipo);
            combo.DisplayMember = "Descripcion";
            combo.ValueMember = "Descripcion_Id";
        }

        public static long DevuelveValorCombo(SfComboBox combo,string tipo)
        {
            long id = 0;
            if (combo.SelectedIndex >= 0)
                id  = Convert.ToInt64(combo.SelectedValue);
            else
            {
                if (string.IsNullOrEmpty(combo.Text.Trim())==false) {

                    using (FbConnection db = General.GetDB())
                    {
                        string sql = Queries.DescripcionSelectxDescripcion();
                        DescripcionCat des = db.QueryFirstOrDefault<DescripcionCat>(sql, new { Tipo = tipo, Descripcion = combo.Text.Trim() });

                        if (des == null)
                        {
                            sql = Queries.DescripcionInsert();
                            id = db.QuerySingle<long>(sql, new { Tipo = tipo, Descripcion = combo.Text.Trim() });
                        }
                        else
                        {
                            id = des.Descripcion_Id;
                        }

                    }
                }
            }
            return id;
        }

        public static void EnlazaCombo(ref ComboBox combo, BindingList<DescripcionCat> catalogo)
        {
            combo.DataSource = catalogo;
            combo.DisplayMember = "Descripcion";
            combo.ValueMember = "Descripcion_Id";

        }

        public static int calculaEdad(DateTime fechaNac)
        {
            int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            int dob = int.Parse(fechaNac.ToString("yyyyMMdd"));
            int age = (now - dob) / 10000;
            return age;
        }

        public static void CierraProcesos()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();

        }


    }
}
