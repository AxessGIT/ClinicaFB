using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using ClinicaFB.Agenda;
using ClinicaFB.Configuracion;
using ClinicaFB.Configuracion.Conexion;
using ClinicaFB.Configuracion.Empresas;
using ClinicaFB.Expedientes;
using ClinicaFB.Helpers;
using ClinicaFB.PuntoDeVenta;
using ClinicaFB.Modelo;

using ClinicaFB.ModeloConfiguracion;
using Dapper;
using FirebirdSql.Data.Client;
using FirebirdSql.Data.FirebirdClient;
using ClinicaFB.Ingresos;
using ClinicaFB.Facturacion;

namespace ClinicaFB
{
    public partial class MenuPrincipal : Form
    {
        private FbConnection _dbConfiguracion;
        private FbConnection _db=null;
        private MainForm _moduloAgenda = null;
        private pdvMenu _moduloPDV = null;
        private int _empresaId=0;
        private bool _desarrollo = false;


        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default.Servidor))
                ConfiguraConexion();

            if (string.IsNullOrEmpty(Properties.Settings.Default.Servidor))
            {
                Close();
                return;
            }



            if (_desarrollo == false){
                Login login = new Login();
                login.ShowDialog();

                if(login.UsuarioID==0)
                {
                    Close();
                    return;
                }

                _dbConfiguracion = General.GetConexionConfig();

                ClinicaFB.Properties.Settings.Default.Save(); 
                ClinicaFB.Properties.Settings.Default.Usuario_ID = login.UsuarioID;
               
                SeleccionaEmpresa();

                if (_empresaId == 0) { 
                    Close();
                    return;
                }

                Properties.Settings.Default.Empresa_ID = _empresaId;
                
            }


            else { 
                cargaConexionEmpresa(@"CDI");
                Properties.Settings.Default.Empresa_ID = 7;

            }

            SetDatos();

        }

        private void SetDatos()
        {
            ChecaDatos.ChecaImpuestos();

        }


        private void SeleccionaEmpresa()
        {
            EmpresasListado empresasListado = new EmpresasListado(_dbConfiguracion);
            empresasListado.ShowDialog();

            _empresaId = empresasListado.EmpresaId;

            if (_empresaId==0)
            {
                return;
            }

            Properties.Settings.Default.Empresa_ID = _empresaId;
            string sql = Queries.EmpresaSelect();
            Empresa emp = _dbConfiguracion.QueryFirstOrDefault<Empresa>(sql, new { Empresa_Id = _empresaId });

            string empnombre = emp.Nombre_Corto.Trim();

            
            cargaConexionEmpresa(empnombre);
        }



        private void cargaConexionEmpresa(string empresa)
        {
            DatosConexionServidor conexionDatos = General.GetDatosConexion();
            FbConnectionStringBuilder csb = new FbConnectionStringBuilder();


            csb.DataSource = conexionDatos.Servidor;

            string carpeta = conexionDatos.Carpeta;

            if (_desarrollo)
                csb.Database = $@"{empresa.Trim()}.FDB";

            else
                csb.Database = $@"{carpeta.Trim()}\{empresa.Trim()}.FDB";

            csb.UserID = "SYSDBA";



            csb.Password = conexionDatos.PassWord;
            _db = new FbConnection();
            _db.ConnectionString = csb.ToString();


        }
        private void ConfiguraConexion()
        {

            ConexionDatos conexionDatos = new ConexionDatos();
            conexionDatos.ShowDialog();

        }
        private void cmdConfigurar_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Usuario no autorizado");
            //return;
            ConfiguracionMenu conmenu = new ConfiguracionMenu(_db, _dbConfiguracion);
            conmenu.ShowDialog();
        }

        private void cmdExpedientes_Click(object sender, EventArgs e)
        {
            PacientesListado pacientesListado = new PacientesListado();
            pacientesListado.Show();

        }

        private void cmdAgenda_Click(object sender, EventArgs e)
        {
            if (_moduloAgenda == null || _moduloAgenda.IsDisposed)
            {
                _moduloAgenda = new MainForm(_db,_dbConfiguracion);
            }


            _moduloAgenda.Show();
            _moduloAgenda.WindowState = FormWindowState.Normal;
            _moduloAgenda.Activate();

        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdExpediente_Click(object sender, EventArgs e)
        {
            TabletListadoPacientes tabletListadoPacientes = new TabletListadoPacientes();
            tabletListadoPacientes.Show();    
        }


        private void cmdPuntoDeVenta_Click(object sender, EventArgs e)
        {
            if (_moduloPDV == null || _moduloPDV.IsDisposed)
            {
                _moduloPDV = new pdvMenu();
            }


            _moduloPDV.Show();
            _moduloPDV.WindowState = FormWindowState.Normal;
            _moduloPDV.Activate();
        }

        private void cmdIngresos_Click(object sender, EventArgs e)
        {
            IngMenu ingMenu = new IngMenu();    
            ingMenu.Show();
        }


        
    }
}
