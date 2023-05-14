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
    public partial class ColorPicker : Form
    {
        public Color ColorSeleccionado { get; set; }

        public ColorPicker()
        {
            InitializeComponent();
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ColorPicker_Load(object sender, EventArgs e)
        {

        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            ColorSeleccionado = colPicker.SelectedColor;
            Close();

        }
    }
}
