using ClinicaFB.Helpers;
using ClinicaFB.Modelo;
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
using ClinicaFB.ModeloConfiguracion;
using System.IO;

namespace ClinicaFB.Configuracion.Empresas
{
    public partial class EmpresaAltasCambios : Form
    {
        private FbConnection _dbConfig;
        private bool _esAlta;
        private Empresa _empresa;
        public int EmpresaId { get; set; }


        public EmpresaAltasCambios(FbConnection dbConfig, bool esAlta, int empresaId)
        {
            _dbConfig = dbConfig;
            _esAlta = esAlta;
            EmpresaId = empresaId;
            InitializeComponent();
        }

        private void EmpresaAltasCambios_Load(object sender, EventArgs e)
        {
            if(_esAlta)
            {
                Text = "Agregar empresa";
                _empresa = new Empresa();
            }
            else
            {
                Text = "Modificar empresa";
                string sql = Queries.EmpresaSelect();
                _empresa = _dbConfig.QueryFirstOrDefault<Empresa>(sql, new { Empresa_id = EmpresaId });
                PropiedadesAControles();
            }
        }

        private void PropiedadesAControles()
        {
            txtNombreCompleto.Text = _empresa.Nombre;
            txtNombreCorto.Text = _empresa.Nombre_Corto;
            txtDireccion.Text = _empresa.Direccion;
            txtColonia.Text = _empresa.Colonia;
            txtLocalidad.Text = _empresa.Localidad;
            txtCiudad.Text = _empresa.Ciudad;
            txtEstado.Text = _empresa.Estado;
            txtCP.Text = _empresa.Cp;

            if (_empresa.Logotipo != null)
            {
                picLogotipo.Image = General.ByteArrayToImagen(_empresa.Logotipo);
            }

            txtURL.Text = _empresa.WebServiceURL;
            txtCarpetaWEB.Text = _empresa.CarpetaWEB;
            txtBaseDeDatosWEB.Text = _empresa.BddWEB;
            chkGenerarAgendaWEB.Checked = _empresa.CopiarWEB;
            txtCarpetaReportes.Text = _empresa.CarpetaReportes;
            txtCarpetaImagenes.Text = _empresa.CarpetaImagenes;

        }

        private void  ControlesAPropiedades()
        {
            _empresa.Nombre= txtNombreCompleto.Text;
            _empresa.Nombre_Corto= txtNombreCorto.Text;
            _empresa.Direccion= txtDireccion.Text;
            _empresa.Colonia= txtColonia.Text;
            _empresa.Localidad= txtLocalidad.Text;
            _empresa.Ciudad= txtCiudad.Text;
            _empresa.Estado= txtEstado.Text;
            _empresa.Cp= txtCP.Text;

            _empresa.Logotipo = General.ImagenToByteArray(picLogotipo.Image);

            _empresa.WebServiceURL= txtURL.Text;
            _empresa.CarpetaWEB = txtCarpetaWEB.Text;
            _empresa.BddWEB= txtBaseDeDatosWEB.Text;
            _empresa.CopiarWEB= chkGenerarAgendaWEB.Checked;
            _empresa.CarpetaReportes = txtCarpetaReportes.Text;
            _empresa.CarpetaImagenes = txtCarpetaImagenes.Text;


        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool ValidaDatos()
        {

            if (string.IsNullOrEmpty(txtNombreCompleto.Text.Trim()))
            {
                MessageBox.Show("Teclee el nombre completo de la empresa","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return false;
            }

            if (string.IsNullOrEmpty(txtNombreCorto.Text.Trim()))
            {
                MessageBox.Show("Teclee el nombre corto de la empresa", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }


            return true;
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            if (ValidaDatos() == false)
                return;

            ControlesAPropiedades();

            string sql = "";
            if (_esAlta)
            {
                sql = Queries.EmpresaInsert();
                EmpresaId = _dbConfig.QuerySingle<int>(sql, _empresa);

                DatosConexion dc = new DatosConexion("ConexionFb.xml");

                if (dc.Carpeta!="")
                {
                    string nuevaBaseDeDatos = dc.Carpeta + txtNombreCorto.Text.Trim()+".FDB";
                    
                    if (File.Exists(nuevaBaseDeDatos) == false){
                        File.Copy(dc.BaseDeDatosModelo, nuevaBaseDeDatos);
                   }

                    
                }

            }
            else
            {
                sql = Queries.EmpresaUpdate();
                _dbConfig.Execute(sql, _empresa);
            }
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

        private void cmdCarpetaImagenes_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog seleccionarCarpeta = new FolderBrowserDialog();


            if (seleccionarCarpeta.ShowDialog() == DialogResult.Cancel)
            {
                return;

            }
            txtCarpetaImagenes.Text = seleccionarCarpeta.SelectedPath;

        }
    }
}
