using ClinicaFB.Helpers;
using ClinicaFB.Modelo;
using Dapper;
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

namespace ClinicaFB.Configuracion
{
    public partial class ClavesSATActualiza : Form
    {
        public ClavesSATActualiza()
        {
            InitializeComponent();
        }

        private void ClavesSATActualiza_Load(object sender, EventArgs e)
        {
            txtArchivoExcel.BackColor= Color.White;
            txtArchivoExcel.ForeColor = Color.Black;
        }

        private void cmdSeleccionarArchivo_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos de excel (*.xls)|*.xls|Todos los archivos (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtArchivoExcel.Text = ofd.FileName;
            }
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void cmdActualizar_Click(object sender, EventArgs e)
        {
            if (txtArchivoExcel.Text == String.Empty)
            {
                MessageBox.Show("Indique el archivo para importar claves","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("¿Desea iniciar col la actualización?","Confirme",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.No)

            {
                return;
            }

            lblLeyenda.Visible = true;

            await ActualizaClaves();
            General.CierraProcesos();



        }

        private async Task ActualizaClaves()
        {
            var progress = new Progress<string>(value =>
            { 
                lblLeyenda.Text = "Actualizando: "+ value;
            }
            );

            await Task.Run(() => RecorreExcel(progress));
        }

        private void RecorreExcel(IProgress<string> progress)
        {

            string[,] aClaves = new string[6, 3];

            aClaves[0, 0] = "UNI";
            aClaves[0, 1] = "c_ClaveUnidad";
            aClaves[0, 2] = "Unidades de medida";


            aClaves[1, 0] = "FOP";
            aClaves[1, 1] = "c_FormaPago";
            aClaves[1, 2] = "Formas de pago";


            aClaves[2, 0] = "MEP";
            aClaves[2, 1] = "c_MetodoPago";
            aClaves[2, 2] = "Métodos de pago";


            aClaves[3, 0] = "REF";
            aClaves[3, 1] = "c_RegimenFiscal";
            aClaves[3, 2] = "Régimenes fiscales";


            aClaves[4, 0] = "CPS";
            aClaves[4, 1] = "c_ClaveProdServ";
            aClaves[4, 2] = "Claves Prod y Serv";


            aClaves[5, 0] = "USO";
            aClaves[5, 1] = "c_UsoCFDI";
            aClaves[5, 2] = "Claves uso CFDi";




            string archivoExcel = txtArchivoExcel.Text;
            Microsoft.Office.Interop.Excel.Application oExcel;
            oExcel = new Microsoft.Office.Interop.Excel.Application();

            var Libro = oExcel.Workbooks;

            Libro.Open(archivoExcel);




            int i = 0;
            int cuantasClaves = aClaves.GetLength(0);




            string sqlInsert = "Insert Into ClavesSAT (Tipo,Clave,Descripcion) Values (@Tipo,@Clave,@Descripcion)";

            using (FbConnection db = General.GetDB())
            {

                for (i = 0; i < cuantasClaves; i++)
                {
                   
                    string sql = "Delete From ClavesSAT Where Tipo = @Tipo";
                    string tip = aClaves[i, 0];

                    db.Execute(sql, new { Tipo = tip });

                    string Hoja = aClaves[i, 1];
                    oExcel.Worksheets[Hoja].Activate();

                    int j = 7;
                    var clave = oExcel.ActiveSheet.Cells[j, 1].Value;



                    while (clave != null)
                    {

                        progress.Report(aClaves[i, 2]+" "+j.ToString());
                        string des = oExcel.ActiveSheet.Cells[j, 2].Value;

                        if (des != null)
                        {
                            //byte[] bytes = Encoding.UTF8.GetBytes(des);
                            //des = Encoding.Default.GetString(bytes);

                            ClaveSAT cveSAT = new ClaveSAT();

                            des = des.Replace('–', ' ');
                            des = des.Replace('’', ' ');
                            des = des.Replace('“', ' ');
                            des = des.Replace('”', ' ');
                            des = des.Replace('‘', ' ');
                            des = des.Replace('™', ' ');
                            


                            /*if(des== "Mezclas de nitrógeno – fósforo – potasio – npk")
                                des = "Mezclas de nitrógeno  fósforo – potasio – npk";*/

                            cveSAT.Tipo = tip;
                            cveSAT.Clave = Convert.ToString(clave);
                            cveSAT.Descripcion = des;
                            db.Execute(sqlInsert, cveSAT);

                        }

                        j++;
                        clave = oExcel.ActiveSheet.Cells[j, 1].Value;

                    }


                }

            }



            oExcel.Quit();
            oExcel = null;
            
            progress.Report("Finalizó");

            


        }
    }
}
