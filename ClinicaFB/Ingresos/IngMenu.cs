using ClinicaFB.Facturacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFB.Ingresos
{
    public partial class IngMenu : Form
    {
        public IngMenu()
        {
            InitializeComponent();
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdCapturaIngreso_Click(object sender, EventArgs e)
        {
            ingCaptura ingCaptura = new ingCaptura("CLI");
            ingCaptura.Show();
        }

        private void IngMenu_Load(object sender, EventArgs e)
        {

        }

        private void cmdRazonesSociales_Click(object sender, EventArgs e)
        {
            RazonesSocialesListado razonesSocialesListado = new RazonesSocialesListado();
            razonesSocialesListado.Show();
        }

        private void cmdFacturas_Click(object sender, EventArgs e)
        {
            CFDisLIstado facturasLIstado = new CFDisLIstado();
            facturasLIstado.Show();

        }

        private void cmdListadoIngresos_Click(object sender, EventArgs e)
        {
            IngresosListado ingresosListado=new IngresosListado("CLI");
            ingresosListado.Show();
        }
    }
}
