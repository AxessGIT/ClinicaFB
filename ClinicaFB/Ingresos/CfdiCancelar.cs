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
    public partial class CfdiCancelar : Form
    {
        public CfdiCancelar()
        {
            InitializeComponent();
        }

        private void CfdiCancelar_Load(object sender, EventArgs e)
        {
            cboMotivos.SelectedIndex = 1;
        }
    }
}
