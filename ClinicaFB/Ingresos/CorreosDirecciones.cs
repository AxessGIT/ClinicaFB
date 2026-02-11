using ClinicaFB.Helpers;
using ClinicaFB.Modelo;
using Dapper;
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

namespace ClinicaFB.Ingresos
{
    public partial class CorreosDirecciones : Form
    {
        long _razonSocialId = 0;
        public bool Aceptar { get; set; } = false;

        public CorreosDirecciones(long razonSocialId =0)
        {
            InitializeComponent();
            _razonSocialId = razonSocialId;
        }

        private void CorreosDirecciones_Load(object sender, EventArgs e)
        {
            if (_razonSocialId  != 0) {

                using (FbConnection db = General.GetDB())
                {
                    string sql = Queries.RazonSocialSelect();
                    RazonSocial razon = db.Query<RazonSocial>(sql, new {RazonSocialId = _razonSocialId }).FirstOrDefault();

                    if (razon != null)
                    {
                        txtDirecciones.Text = razon.Email;

                    }
                }
            }
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDirecciones.Text))
            {
                MessageBox.Show("Teclee las direcciones","Aviso",MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Aceptar = true;
            Close();
        }

        private void cmdCerrar_Click(object sender, EventArgs e)
        {
            Aceptar = false;
            Close();

        }
    }
}
