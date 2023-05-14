using ClinicaFB.Modelo;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ClinicaFB.Agenda;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ClinicaFB.ModeloConfiguracion;
using MimeKit;
using MailKit.Net.Smtp;
using ClinicaFB.ModeloWEB;
using Syncfusion.WinForms.ListView;
using System.Globalization;
using ClinicaFB.Configuracion.Facturacion;
using Microsoft.ReportingServices.Interfaces;

namespace ClinicaFB.Helpers
{
    public class General
    {

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

            concad = csb.ToString();


            return concad;
        }


        public static FbConnection GetDB()
        {
            FbConnection conn = null;
            string concad = GetCadenaDeConexion();

            if (string.IsNullOrEmpty(concad))
                return conn;

            conn = new FbConnection();
            conn.ConnectionString = concad;

            return conn;

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
            combo.Items.Clear();

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
