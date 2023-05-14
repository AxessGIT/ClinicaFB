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
    public partial class pdvMenu : Form
    {
        public pdvMenu()
        {
            InitializeComponent();
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdArticulos_Click(object sender, EventArgs e)
        {
            ArticulosListado articulosListado = new ArticulosListado();
            articulosListado.Show();

        }
    }
}
