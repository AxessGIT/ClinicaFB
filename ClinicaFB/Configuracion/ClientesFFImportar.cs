using ClinicaFB.Helpers;
using ClinicaFB.Modelo;
using Dapper;
using FirebirdSql.Data.FirebirdClient;
using Syncfusion.XPS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ClinicaFB.Configuracion
{
    public partial class ClientesFFImportar : Form
    {
        public ClientesFFImportar()
        {
            InitializeComponent();
        }

        private void cmdCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdBuscarCarpeta_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtFolder.Text = folderBrowserDialog.SelectedPath;
            }

        }

        private async void cmdImportar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFolder.Text))
            {
                MessageBox.Show("Seleccione la carpeta donde está instalado el FacturaFox","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            string tablaEmisores = txtFolder.Text + @"\Datos\Emisores.dbf";

            if (File.Exists(tablaEmisores) == false)
            {
                MessageBox.Show("No existe la tabla de emisores", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (MessageBox.Show("¿Desea iniciar la importación?","Confirme",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No) {
                return;
            }

            await ImportaClientes();
            lblEmisorCliente.Text = "";
            MessageBox.Show("Terminó la importación","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }

        private async Task ImportaClientes()
        {
            var progress = new Progress<string>(value =>
            {
                lblEmisorCliente.Text = "Actualizando: " + value;
            }
            );
            await Task.Run(()=> RecorreEmisores(progress));
        }

        private void RecorreEmisores(IProgress<string> progress)
        {

            OleDbConnectionStringBuilder cs = new OleDbConnectionStringBuilder();

            cs.Provider = "vfpoledb";
            cs.DataSource = txtFolder.Text + @"\Datos\";

            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = cs.ToString();

            OleDbCommand comando = new OleDbCommand("Select RFC From Emisores", conn);

            conn.Open();
            OleDbDataReader dr = comando.ExecuteReader();

            List<string> RFCs = new List<string>();
            while (dr.Read())
            {
                string RFC = dr.GetString(0);
                RFCs.Add(RFC);


            }

            dr.Close();
            conn.Close();

            foreach (string RFC in RFCs)
            {

                cs.DataSource = txtFolder.Text + $@"\Datos\{RFC.Trim()}\DBF\";

                conn = new OleDbConnection();
                conn.ConnectionString = cs.ToString();
                comando = new OleDbCommand("Select * From Clientes Order By RFC", conn);
                conn.Open();
                dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    string rfcCliente = dr.GetString(dr.GetOrdinal("RFC")).Trim();

                    using (FbConnection db = General.GetDB())
                    {
                        string sql = Queries.RazonSocialSelectXRFC();

                        RazonSocial razonSocial = db.Query<RazonSocial>(sql, new { RFC = rfcCliente }).FirstOrDefault();

                        if (razonSocial != null)
                        {
                            continue;
                        }


                        progress.Report($"Emisor: {RFC} Cliente: {rfcCliente} ");

                        string nombre = dr.GetString(dr.GetOrdinal("RazonSoc")).Trim().ToUpper();
                        string direccion = dr.GetString(dr.GetOrdinal("Calle")).Trim().ToUpper()+" "+
                            dr.GetString(dr.GetOrdinal("Colonia")).Trim().ToUpper();

                        int ciudadId = General.GetDescripcionId("CIU", dr.GetString(dr.GetOrdinal("Ciudad")).Trim(), true);
                        int estadoId = General.GetDescripcionId("EDO", dr.GetString(dr.GetOrdinal("Estado")).Trim(), true);
                        int paisId = General.GetDescripcionId("PAI", dr.GetString(dr.GetOrdinal("Pais")).Trim(), true);
                        string cp = dr.GetString(dr.GetOrdinal("CP")).Trim().ToUpper();
                        string cveREF = dr.GetString(dr.GetOrdinal("CVEREF")).Trim().ToUpper();
                        string cveMEP = dr.GetString(dr.GetOrdinal("CVEMEP")).Trim().ToUpper();
                        string cveFOP = dr.GetString(dr.GetOrdinal("CVEFOP")).Trim().ToUpper();
                        string cveUSO = dr.GetString(dr.GetOrdinal("CVEUSO")).Trim().ToUpper();
                        string correo = dr.GetString(dr.GetOrdinal("Correos")).Trim().ToUpper();

                        razonSocial = new RazonSocial();
                        razonSocial.RFC = rfcCliente;
                        razonSocial.RazonSoc = nombre;
                        razonSocial.Direccion = direccion;
                        razonSocial.LocalidadId = ciudadId;
                        razonSocial.CiudadId = ciudadId;
                        razonSocial.EstadoId = estadoId;
                        razonSocial.PaisId = paisId;
                        razonSocial.CP = cp;
                        razonSocial.CveREF = cveREF;
                        razonSocial.CveMEP = cveMEP;
                        razonSocial.CveFOP = cveFOP;
                        razonSocial.CveUSO = cveUSO;
                        razonSocial.Email = correo;

                        sql = Queries.RazonSocialInsert();
                        db.Execute(sql, razonSocial);





                    }



                }
                dr.Close();
                conn.Close();



            }

        }
    }
}
