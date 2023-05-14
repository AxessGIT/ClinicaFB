using System;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace ClinicaFB.Configuracion.Conexion
{
    public partial class ConexionDatos : Form
    {
        public ConexionDatos()
        {
            InitializeComponent();
        }

        private void ConexionDatos_Load(object sender, EventArgs e)
        {
            txtServidor.Text = string.IsNullOrEmpty(Properties.Settings.Default.Servidor)?"localhost": Properties.Settings.Default.Servidor;
            txtPassword.Text = string.IsNullOrEmpty(Properties.Settings.Default.PassWord)?"masterkey": Properties.Settings.Default.PassWord;
            txtCarpeta.Text = string.IsNullOrEmpty(Properties.Settings.Default.CarpetaDatos)?@"C:\ClinicaFB Datos": Properties.Settings.Default.CarpetaDatos;
            txtPuerto.IntegerValue = Properties.Settings.Default.Puerto==0?3050: Properties.Settings.Default.Puerto;
        }


        private void cargaConexion()
        {

        }
        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {

            Properties.Settings.Default.Servidor = txtServidor.Text;
            Properties.Settings.Default.PassWord = txtPassword.Text;
            Properties.Settings.Default.CarpetaDatos= txtCarpeta.Text;
            Properties.Settings.Default.Puerto=(int) txtPuerto.IntegerValue;
            Properties.Settings.Default.Save();
            Close();

        }

        private void cmdProbar_Click(object sender, EventArgs e)
        {
            FbConnectionStringBuilder csb = new FbConnectionStringBuilder();
            csb.DataSource = txtServidor.Text.Trim();
            csb.UserID = "SYSDBA";
            csb.Password = txtPassword.Text.Trim();
            csb.Port = (int) txtPuerto.IntegerValue;
            csb.Database = $"{txtCarpeta.Text.Trim()}\\Config\\Configuracion.fdb";

            FbConnection conn = new FbConnection();
            conn.ConnectionString = csb.ToString();

            bool sinError = true;

            try
            {
                conn.Open();
            }
            catch (FbException err)
            {
                sinError = false;
                MessageBox.Show($"Error de conexión: {err.Message}");


            }
            finally {
                conn.Close();
            }
            if (sinError)
                MessageBox.Show("Conexión existosa","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
          
        }
    }
}
