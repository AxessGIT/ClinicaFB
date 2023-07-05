using ClinicaFB.Facturacion;
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
    public partial class IngresoFacturar : Form
    {
        private int _ingresoId;
        private int _razonSocialId;

        public IngresoFacturar(int ingresoId)
        {
            InitializeComponent();
            _ingresoId = ingresoId;
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void IngresoFacturar_Load(object sender, EventArgs e)
        {

        }

        private void cmdBuscaRazonSocial_Click(object sender, EventArgs e)
        {
            RazonesSocialesListado razonesSocialesListado = new RazonesSocialesListado(true);
            razonesSocialesListado.ShowDialog();
            if (razonesSocialesListado.RazonId != 0)
            {
                _razonSocialId = razonesSocialesListado.RazonId;
                CargaDatosRazonSocial();
            }

        }
        private void CargaDatosRazonSocial()
        {
            if (_razonSocialId == 0)
            {
                return;
            }

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.RazonSocialSelect();
                RazonSocial raz = db.Query<RazonSocial>(sql, new { RazonSocialId = _razonSocialId }).FirstOrDefault();

                if (raz != null)
                {
                    txtRFC.Text = raz.RFC;
                    txtRazonSocial.Text = raz.RazonSoc;
                }
            }


        }

    }
}
