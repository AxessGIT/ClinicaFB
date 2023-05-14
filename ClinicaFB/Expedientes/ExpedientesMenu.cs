using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFB.Expedientes
{

    public partial class ExpedientesMenu : Form
    {
        FbConnection _db;
        public ExpedientesMenu(FbConnection db)
        {
            _db = db;
            InitializeComponent();
        }

        private void cmdPacientes_Click(object sender, EventArgs e)
        {
            PacientesListado pacientesListado = new PacientesListado();
            pacientesListado.ShowDialog();

        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
