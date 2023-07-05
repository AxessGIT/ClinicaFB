using AForge.Video;
using AForge.Video.DirectShow;
using ClinicaFB.Helpers;
using ClinicaFB.Modelo;
using ClinicaFB.ModeloConfiguracion;
using Dapper;
using FirebirdSql.Data.FirebirdClient;
using Org.BouncyCastle.Asn1.Crmf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.DrawingCore.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFB.Expedientes
{
    public partial class ImagenAltasCambios : Form
    {
        private bool _esAlta = false;
        private int _pacienteId;
        private int _pacienteImagenId;
        private string _carpetaImagenes;
        private string _imagenOrigen;
        public bool _reproduciendoVideo { get; set; }
        private FilterInfoCollection _dispositivosVideo;
        private VideoCaptureDevice _camara;

        public ImagenAltasCambios(int pacienteImagenId, int pacienteId, bool esAlta)
        {
            _esAlta = esAlta;
            _pacienteId= pacienteId;
            _pacienteImagenId = pacienteImagenId;
            InitializeComponent();
        }

        private void cmdCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog opfSeleccionaImagen = new OpenFileDialog();
            opfSeleccionaImagen.Filter = "png files (*.png)|*.png|jpg files (*.jpg)|*.jpg|jpeg files (*.jpeg)|*.jpeg|All files (*.*)|*.*";
            if(opfSeleccionaImagen.ShowDialog() == DialogResult.Cancel) {
                return;
            }

            picVideo.Image = Bitmap.FromFile(opfSeleccionaImagen.FileName);
            _imagenOrigen = opfSeleccionaImagen.FileName;
        }



        private void ImagenAltasCambios_Load(object sender, EventArgs e)
        {

            General.CargaDispositivosVideo(ref cboDispositivos, ref _dispositivosVideo);
            General.ConfiguraCombo(ref cboDiagnosticos, "DIA");

            if (_esAlta)
            {
                Text = "Agregar imagen";
                txtFecha.Value = DateTime.Now;
            }
            else
            {


                using (FbConnection db = General.GetDB())
                {
                    string sql = Queries.PacienteImagenSelect();
                    PacientesImagenes pacim = db.Query<PacientesImagenes>(sql, new { PacImId = _pacienteImagenId }).FirstOrDefault();

                    if (pacim == null)
                    {
                        return;
                    }

                    cmdVideo.Enabled = false;
                    //cmdGuardar.Enabled = false;

                    picVideo.Image = Bitmap.FromFile(pacim.RutaImagen);
                    txtFecha.Value = pacim.Fecha;
                    cboDiagnosticos.SelectedValue = pacim.DiagnosticoId;
                    txtPalabrasClave.Text = pacim.PalabrasClave;
                    _imagenOrigen = pacim.RutaImagen;

                }
                cmdCargar.Visible = false;
                txtFecha.Enabled = false;
                Text = "Modificar atributos de imagen";
            }

            _carpetaImagenes = General.CarpetaImagenesEmpresa();


        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            if (picVideo.Image == null)
            {
                MessageBox.Show("Indique la imagen","Aviso",MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrEmpty(cboDiagnosticos.Text))
            {
                MessageBox.Show("Indique le diagnóstico", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }


            string dia, mes, anio,carpeta;
            

            PacientesImagenes pacim = new PacientesImagenes();
            pacim.PacImId = _pacienteImagenId;
            pacim.PacienteId = _pacienteId;
            pacim.DiagnosticoId = (int)General.DevuelveValorCombo(cboDiagnosticos, "DIA");
            pacim.Fecha = txtFecha.Value;
            pacim.PalabrasClave = txtPalabrasClave.Text;

            dia = pacim.Fecha.Day.ToString("00");
            mes = pacim.Fecha.Month.ToString("00");
            anio = pacim.Fecha.Year.ToString();

            string nuevoArchivo = "";

           
            if (_esAlta)
            {
                //FileInfo infoOrigen = new FileInfo(_imagenOrigen);

                string ext = "png";
                carpeta =  General.CarpetaImagenesPaciente(_pacienteId) + $@"\{anio}\{mes}\{dia}\";

                if (General.CarpetaImagenes(_carpetaImagenes, carpeta) == false)
                {
                    MessageBox.Show("No fue posible accesar la carpeta para guardar imagenes", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                nuevoArchivo = _carpetaImagenes + @"\" + carpeta + Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ext;

                //picImagen.Image.Save(nuevoArchivo, ImageFormat.Png);
                picVideo.Image.Save(nuevoArchivo, System.Drawing.Imaging.ImageFormat.Png);
                //File.Copy(_imagenOrigen, nuevoArchivo);

            }


            pacim.RutaImagen = _esAlta?nuevoArchivo:_imagenOrigen;


            using (FbConnection db = General.GetDB())
            {
                string sql = _esAlta ? Queries.PacienteImagenInsert() : Queries.PacienteImagenUpdate();

                db.Execute(sql, pacim);

            }

            Close();




            




        }

        private void cmdCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }



        private void cmdVideo_Click(object sender, EventArgs e)
        {

            if (_reproduciendoVideo == true)
            {
                cmdVideo.Text = "Iniciar vídeo";
                CerrarCamara();
                _reproduciendoVideo = false;

            }

            else
            {
                if (_dispositivosVideo.Count == 0)
                {
                    MessageBox.Show("No hay ningún dispositivo de vídeo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                _reproduciendoVideo = true;
                cmdVideo.Text = "Capturar imagen";
                string nombredisp = _dispositivosVideo[cboDispositivos.SelectedIndex].MonikerString;
                _camara = new VideoCaptureDevice(nombredisp);
                _camara.NewFrame += new NewFrameEventHandler(Capturando);
                _camara.Start();

            }
        }

        private void CerrarCamara()
        {
            if (_camara!=null && _camara.IsRunning)
            {
                _camara.SignalToStop();
                //_camara.Stop();
                _camara = null;
            }
        }

        private void Capturando(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap imagen= (Bitmap)eventArgs.Frame.Clone();
            picVideo.Image=imagen;

        }

        private void ImagenAltasCambios_FormClosing(object sender, FormClosingEventArgs e)
        {
            CerrarCamara();
        }

    }
}
