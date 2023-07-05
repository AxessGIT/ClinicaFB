using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFB.Ingresos
{
    public partial class TicketEnviarOpciones : Form
    {
        public bool Aceptar { get; set; } = false;

        public TicketEnviarOpciones()
        {
            InitializeComponent();
        }

        private void TicketEnviarOpciones_Load(object sender, EventArgs e)
        {
            CargaImpresoras();

        }

        private void CargaImpresoras()
        {
            foreach (string printname in PrinterSettings.InstalledPrinters)
            {
                cboImpresoras.Items.Add(printname);
            }

            PrinterSettings settings = new PrinterSettings();
            cboImpresoras.Text = settings.PrinterName;
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            if (chkMandarCorreo.Checked==false && chkImprimir.Checked == false) 
            {
            }

            if (chkMandarCorreo.Checked && string.IsNullOrEmpty(txtCorreos.Text))
            {
                MessageBox.Show("Indique la(s) dirección(es) de correo","Confirme",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            Aceptar = true;
            Close();
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            Aceptar = false;
            Close();
        }
    }
}
