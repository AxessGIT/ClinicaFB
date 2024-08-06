using ClinicaFB.Ingresos;
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

        private void cmdAlmacenes_Click(object sender, EventArgs e)
        {
            AlmacenesListado almacenesListado = new AlmacenesListado();
            almacenesListado.ShowDialog();
        }

        private void cmdPuntoDeVenta_Click(object sender, EventArgs e)
        {
            PdV pdV = new PdV();
            pdV.ShowDialog();

        }

        private void cmdProveedores_Click(object sender, EventArgs e)
        {
            ProveedoresListado proveedoresListado = new ProveedoresListado();
            proveedoresListado.ShowDialog();
        }

        private void cmdCompras_Click(object sender, EventArgs e)
        {
            ComprasListado comprasListado = new ComprasListado();
            comprasListado.ShowDialog();
        }
    }
}
