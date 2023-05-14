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
using FirebirdSql.Data.FirebirdClient;
using ClinicaFB.Helpers;

namespace ClinicaFB.Configuracion.Usuarios
{
    public partial class UsuariosAltasCambios : Form
    {
        private FbConnection _dbConfig;
        private bool _esAlta;
        private Usuario _usuario;
        public int UsuarioId { get; set; }

        public UsuariosAltasCambios(FbConnection dbConfig, bool esAlta, int usuarioId)
        {
            _dbConfig = dbConfig;
            _esAlta = esAlta;
            UsuarioId = usuarioId;
            InitializeComponent();

        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UsuariosAltasCambios_Load(object sender, EventArgs e)
        {

            if (_esAlta)
            {
                Text = "Agregar usuario";
                _usuario = new Usuario();
            }
            else
            {
                txtUsuario.Enabled = false;
                txtUsuario.BackColor = Color.White;
                txtUsuario.ForeColor = Color.Black;
                
                Text = "Modificar usuario";
                string sql = Queries.UsuarioSelect();
                _usuario = _dbConfig.QueryFirstOrDefault<Usuario>(sql, new { Usuario_id = UsuarioId });
                PropiedadesAControles();
            }
        }

        private void PropiedadesAControles()
        {

            txtUsuario.Text = _usuario.Usr;
            txtNombre.Text = _usuario.Nombre;
            txtPassWord.Text = _usuario.Password;
            chkConsultaAgenda.Checked = _usuario.ConsultaAgenda;


        }

        private void ControlesAPropiedades()
        {

            _usuario.Usr= txtUsuario.Text.Trim();
            _usuario.Nombre = txtNombre.Text.Trim();
            _usuario.Password = txtPassWord.Text.Trim();
            _usuario.ConsultaAgenda = chkConsultaAgenda.Checked;



        }

        private void cmdMuestraPassWord_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassWord.PasswordChar = '\0';
        }

        private void cmdMuestraPassWord_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassWord.PasswordChar = '*';

        }

        private bool ValidaDatos()
        {

            if (string.IsNullOrEmpty(txtUsuario.Text.Trim()))
            {
                MessageBox.Show("Teclee el usuario", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (string.IsNullOrEmpty(txtNombre.Text.Trim()))
            {
                MessageBox.Show("Teclee el nombre del usuario", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (string.IsNullOrEmpty(txtPassWord.Text.Trim()))
            {
                MessageBox.Show("Teclee la contraseña", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                sql = Queries.UsuarioInsert();
                UsuarioId = _dbConfig.QuerySingle<int>(sql, _usuario);

            }
            else
            {
                sql = Queries.UsuarioUpdate();
                _dbConfig.Execute(sql, _usuario);
            }
            Close();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
