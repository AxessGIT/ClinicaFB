using AForge.Video;
using AForge.Video.DirectShow;
using ClinicaFB.Helpers;
using ClinicaFB.Modelo;
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

namespace ClinicaFB.Expedientes
{
    public partial class PacienteFotoTomar : Form
    {
        private FilterInfoCollection _dispositivosVideo;
        private VideoCaptureDevice _camara;
        private bool _tomandoVideo = false;
        private int _pacienteId = 0;

        public PacienteFotoTomar(int pacienteId)
        {
            InitializeComponent();
            _pacienteId = pacienteId;   
        }

        private void PacienteFotoTomar_Load(object sender, EventArgs e)
        {
            General.CargaDispositivosVideo(ref cboDispositivos, ref _dispositivosVideo);
        }



        private void CerrarCamara()
        {
            if (_camara != null && _camara.IsRunning)
            {
                _camara.SignalToStop();
                _camara = null;
            }
        }

        private void PacienteFotoTomar_FormClosing(object sender, FormClosingEventArgs e)
        {
            CerrarCamara();
        }

        private void cmdVideo_Click(object sender, EventArgs e)
        {

            Bitmap imagen = (Bitmap)picFoto.Image;
            CerrarCamara();

            if (_tomandoVideo)
            {
                _tomandoVideo = false;
                cmdVideo.Text = "&Iniciar vídeo";

          /*      if (_camara != null && _camara.IsRunning)
                {
                    picFoto.Image = imagen;
                }*/


            }
            else 
            {
                _tomandoVideo = true;
                cmdVideo.Text = "Capturar imagen";
                if (_dispositivosVideo.Count == 0)
                {
                    MessageBox.Show("No hay ningún dispositivo de vídeo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string nombredisp = _dispositivosVideo[cboDispositivos.SelectedIndex].MonikerString;
                _camara = new VideoCaptureDevice(nombredisp);
                _camara.NewFrame += new NewFrameEventHandler(Capturando);
                _camara.Start();
            }


        }


        private void Capturando(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap imagen = (Bitmap)eventArgs.Frame.Clone();
            picFoto.Image = imagen;

        }


        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            CerrarCamara();
            if (picFoto.Image != null)
            {
                string carpeta = General.CarpetaImagenesEmpresa() + "\\" + General.CarpetaImagenesPaciente(_pacienteId) + "\\";
                string archivo = carpeta + "Foto.png";
                if (File.Exists(archivo))
                {
                    File.Delete(archivo);

                }
                picFoto.Image.Save(archivo);
            }
            Close();

        }
    }
}
