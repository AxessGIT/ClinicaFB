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

namespace ClinicaFB.PuntoDeVenta.Procesos
{
    public partial class ImpresoraTicketSeleccionar : Form
    {
        public ImpresoraTicketSeleccionar()
        {
            InitializeComponent();
        }

        private void ImpresoraTicketSeleccionar_Load(object sender, EventArgs e)
        {
            CargaImpresoras();
            string impresora = Properties.Settings.Default.ImpresoraTicket;
            if (string.IsNullOrEmpty(impresora) == false)
            {
                cboImpresoras.Text = impresora;
            }
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

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.ImpresoraTicket = cboImpresoras.Text;
            Properties.Settings.Default.Save();
            Close();
        }
    }
}
