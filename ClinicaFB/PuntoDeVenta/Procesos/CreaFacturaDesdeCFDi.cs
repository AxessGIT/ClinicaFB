using ClinicaFB.Helpers;
using Syncfusion.Compression;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFB.PuntoDeVenta.Procesos
{
    public partial class CreaFacturaDesdeCFDi : Form
    {
        public CreaFacturaDesdeCFDi()
        {
            InitializeComponent();
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CreaFacturaDesdeCFDi_Load(object sender, EventArgs e)
        {

        }

        private void cmdBuscarCFDi_Click(object sender, EventArgs e)
        {
            FileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos XML (*.xml)|*.xml";
            if (ofd.ShowDialog() == DialogResult.Cancel)
                return;
            txtArchivoCFDi.Text = ofd.FileName;
            
        }

        private async void cmdCrearFactura_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtArchivoCFDi.Text))
            {
                MessageBox.Show("Debe seleccionar un archivo CFDI");
                return;
            }
            int i = await UtilsPDV.CreaVentaDesdeCFDi(txtArchivoCFDi.Text);

            if (i >= 0)
            {
                MessageBox.Show("Factura creada correctamente con el folio: " + i.ToString());
            }
            else
            {
                MessageBox.Show("Ocurrió un error al crear la factura desde el CFDI");
            }
        }
    }
}
