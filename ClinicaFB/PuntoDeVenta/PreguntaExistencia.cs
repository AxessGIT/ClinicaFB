using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFB.PuntoDeVenta
{
    public partial class PreguntaExistencia : Form
    {
        public bool Aceptar { get; set; }
        public PreguntaExistencia()
        {
            InitializeComponent();
        }

        private void PreguntaExistencia_Load(object sender, EventArgs e)
        {

        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            Aceptar = true;
            Close();
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Aceptar = false;
            Close();
        }
    }
}
