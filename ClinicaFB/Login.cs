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
using ClinicaFB.Helpers;
using ClinicaFB.ModeloConfiguracion;
using ClinicaFB.Configuracion.Conexion;

namespace ClinicaFB
{
    public partial class Login : Form
    {
        public int UsuarioID { get; set; }
        public Login()
        {
            InitializeComponent();
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            UsuarioID = 0;
            Close();
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string passWord = txtPassWord.Text.Trim();

            if (string.IsNullOrEmpty(usuario)|| string.IsNullOrEmpty(passWord))
            {
                MessageBox.Show("Teclee usuario y contraseña","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }


            string sql = Queries.UsuarioSelectxNombreyPassWord();



            Usuario usr = new Usuario();

            using (FbConnection db = General.GetConexionConfig()) {

                usr = db.Query<Usuario>(sql, new { Usuario = usuario, PassWord = passWord }).FirstOrDefault();

                if (usr == null)
                {
                    MessageBox.Show("Usuario o contraseña incorrectos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;

                }

            }


            ClinicaFB.Properties.Settings.Default.Usuario = usuario;
            ClinicaFB.Properties.Settings.Default.Usuario_ID = (int)usr.Usuario_Id;
            ClinicaFB.Properties.Settings.Default.SucursalId = (int)usr.SucursalId;
            ClinicaFB.Properties.Settings.Default.Save();

            UsuarioID = (int)usr.Usuario_Id;
            Close();

        }

        private void cmdMuestraPassWord_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassWord.PasswordChar = '\0';
        }

        private void cmdMuestraPassWord_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassWord.PasswordChar = '*';

        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtUsuario.Text = ClinicaFB.Properties.Settings.Default.Usuario;
            if (!string.IsNullOrEmpty(txtUsuario.Text))
                this.ActiveControl = txtPassWord;
        }

        private void cmdConexion_Click(object sender, EventArgs e)
        {
            ConexionDatos conexionDatos = new ConexionDatos();
            conexionDatos.ShowDialog();

        }
    }
}
