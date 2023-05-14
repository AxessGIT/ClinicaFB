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
    public partial class PdV : Form
    {
        private Color colorFondo = Color.White;
        private Color colorLetra = Color.DarkGreen;

        public PdV()
        {
            InitializeComponent();
        }

        private void PdV_Load(object sender, EventArgs e)
        {
            PonColores();
        }

        private void PonColores()
        {
            txtRFC.BackColor = colorFondo;
            txtRFC.ForeColor = colorLetra;

            txtRazonSocial.BackColor = colorFondo;
            txtRazonSocial.ForeColor = colorLetra;


        }

        private void cmdClienteBuscar_Click(object sender, EventArgs e)
        {
            PonColores();
        }
    }
}
