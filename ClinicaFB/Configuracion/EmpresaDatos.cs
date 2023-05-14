using ClinicaFB.Helpers;
using ClinicaFB.ModeloConfiguracion;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;

namespace ClinicaFB.Configuracion
{
    public partial class EmpresaDatos : Form
    {
        private FbConnection _db;
        private DatosEmpresa _datosEmpresa;

        public EmpresaDatos(FbConnection db)
        {
            _db = db;
            InitializeComponent();
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EmpresaDatos_Load(object sender, EventArgs e)
        {
            _datosEmpresa = _db.QueryFirstOrDefault<DatosEmpresa>(Queries.EmpresaSelect());
            if (_datosEmpresa != null)
                camposAControles();

        }


        private void camposAControles()
        {
            txtNombre.Text = _datosEmpresa.Nombre;
            txtDireccion.Text = _datosEmpresa.Direccion;
            txtColonia.Text = _datosEmpresa.Colonia;
            txtCiudad.Text = _datosEmpresa.Ciudad;
            txtEstado.Text = _datosEmpresa.Estado;
            txtPais.Text = _datosEmpresa.Pais;
            txtCodigoPostal.Text = _datosEmpresa.CP;
            txtLocalidad.Text = _datosEmpresa.Localidad;
            txtTelefonos.Text = _datosEmpresa.Telefonos;
            txtCorreos.Text = _datosEmpresa.Correos;

            if (_datosEmpresa.Logotipo != null)
            {
                picLogotipo.Image = General.ByteArrayToImagen(_datosEmpresa.Logotipo);
            }

            txtAvisosServidor.Text = _datosEmpresa.AvisosServidor;
            txtAvisosUsuario.Text = _datosEmpresa.AvisosUsuario;
            txtAvisosPassword.Text = _datosEmpresa.AvisosPassword;
            txtAvisosCuenta.Text = _datosEmpresa.AvisosCuenta;
            spnAvisosPuerto.Value = _datosEmpresa.AvisosPuerto == 0 ? 465 : (int)_datosEmpresa.AvisosPuerto;
            txtCarpetaReportes.Text = _datosEmpresa.CarpetaReportes;
            chkAvisosUtilizarSSL.Checked = _datosEmpresa.AvisosSSL == true ? true : false;
        }


        private void ControlesACampos()
        {
            _datosEmpresa.Nombre = txtNombre.Text;
            _datosEmpresa.Direccion = txtDireccion.Text;
            _datosEmpresa.Colonia = txtColonia.Text;
            _datosEmpresa.Ciudad = txtCiudad.Text;
            _datosEmpresa.Estado = txtEstado.Text;
            _datosEmpresa.Pais = txtPais.Text;
            _datosEmpresa.CP = txtCodigoPostal.Text;
            _datosEmpresa.Localidad = txtLocalidad.Text;
            _datosEmpresa.Telefonos = txtTelefonos.Text;
            _datosEmpresa.Correos = txtCorreos.Text;
            _datosEmpresa.Logotipo = General.ImagenToByteArray(picLogotipo.Image);


            _datosEmpresa.AvisosServidor = txtAvisosServidor.Text;
            _datosEmpresa.AvisosUsuario = txtAvisosUsuario.Text;
            _datosEmpresa.AvisosPassword = txtAvisosPassword.Text;
            _datosEmpresa.AvisosCuenta = txtAvisosCuenta.Text;
            _datosEmpresa.AvisosPuerto = (int)spnAvisosPuerto.Value;
            _datosEmpresa.AvisosSSL = chkAvisosUtilizarSSL.Checked;
            _datosEmpresa.CarpetaReportes = txtCarpetaReportes.Text;


        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            bool nueva = false;
            string sql = "";
            if (_datosEmpresa == null)
            {
                _datosEmpresa = new DatosEmpresa();
                nueva = true;
            }

            ControlesACampos();
            if (nueva)
                sql = Queries.DatosEmpresaInsert();
            else
                sql = Queries.DatosEmpresaUpdate();


            _db.Execute(sql, _datosEmpresa);
            Close();

        }

        private void picLogotipo_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdSeleccionaArchivo = new OpenFileDialog();

            ofdSeleccionaArchivo.DefaultExt = "png";
            ofdSeleccionaArchivo.Filter =
                "Archivos png (*.png)|*.png|Archivos jpg (*.jpg)|*.jpg|Archivos jpeg (*.jpeg)|*.jpeg|Todos los archivos (*.*)|*.*";
            ofdSeleccionaArchivo.ShowDialog();
            if (ofdSeleccionaArchivo.FileName == string.Empty)
            {
                return;
            }

            picLogotipo.Image = Image.FromFile(ofdSeleccionaArchivo.FileName);

        }

        private void cmdCarpetaReportes_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog seleccionarCarpeta = new FolderBrowserDialog();

            
            if (seleccionarCarpeta.ShowDialog() == DialogResult.Cancel)
            {
                return;

            }
            txtCarpetaReportes.Text = seleccionarCarpeta.SelectedPath;

        }

        private void pagGenerales_Click(object sender, EventArgs e)
        {

        }
    }
}
