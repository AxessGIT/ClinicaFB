using ClinicaFB.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using ClinicaFB.Modelo;
using FirebirdSql.Data.FirebirdClient;
using Dapper;

namespace ClinicaFB.Ingresos
{
    public partial class IngresoFacturarOpciones : Form
    {
        private int _razonSocialId;
        private string _cveFOP;
        private string _cveMEP;
        private string _cveUSO;
        private string _correos;

        public bool Aceptar { get; set; }


        public IngresoFacturarOpciones(int razonSocialId,string cveFOP="", string cveMEP = "",string cveUSO = "",string correos="" )
        {
            InitializeComponent();
            _razonSocialId = razonSocialId; 
            _cveFOP= cveFOP;
            _cveMEP= cveMEP;
            _cveUSO = cveUSO;
            _correos = correos;
        }

        private void ClavesSATSeleccionar_Load(object sender, EventArgs e)
        {
            CargaImpresoras();

            if (_razonSocialId == 0)
            {
                chkMandarCorreo.Checked=false;
                txtCorreos.Enabled =false;
            }
            else
            {

                using (FbConnection db = General.GetDB())
                {
                    string sql = Queries.RazonSocialSelect();
                    RazonSocial raz = db.Query<RazonSocial>(sql, new {RazonSocialId = _razonSocialId }).FirstOrDefault();

                    if (raz!= null)
                    {
                        txtRFC.Text = raz.RFC;
                        txtRazonSocial.Text = raz.RazonSoc;
                        txtCveFOP.Text = raz.CveFOP;
                        txtCveMEP.Text = raz.CveMEP;
                        txtCveUSO.Text = raz.CveUSO;
                        txtCorreos.Text = raz.Email;

                    }
                    else
                    {
                        txtCveFOP.Text = _cveFOP;
                        txtCveMEP.Text = _cveMEP;
                        txtCveUSO.Text = _cveUSO;
                        txtCorreos.Text = _correos;

                    }

                }
                txtCveMEP.Enabled = true;
                cmdBuscarCveMEP.Enabled =true;

                txtCveUSO.Enabled = true;
                cmdBuscarCveUSO.Enabled=true;


                General.ClaveSATValidar("FOP", ref txtCveFOP, ref txtDescripcionFOP);
                General.ClaveSATValidar("MEP", ref txtCveMEP, ref txtDescripcionMEP);
                General.ClaveSATValidar("USO", ref txtCveUSO, ref txtDescripcionUSO);

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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cmdBuscarCveFOP_Click(object sender, EventArgs e)
        {
            General.BotonBuscarClaveSAT("FOP", ref txtCveFOP, ref txtDescripcionFOP);

        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            Aceptar = false;
            Close();
        }

        private void txtCveFOP_Validated(object sender, EventArgs e)
        {
            General.ClaveSATValidar("FOP", ref txtCveFOP, ref txtDescripcionFOP);

        }

        private void txtCveMEP_Validated(object sender, EventArgs e)
        {
            General.ClaveSATValidar("MEP", ref txtCveMEP, ref txtDescripcionMEP);

        }

        private void cmdBuscarCveMEP_Click(object sender, EventArgs e)
        {
            General.BotonBuscarClaveSAT("MEP", ref txtCveMEP, ref txtDescripcionMEP);

        }

        private void txtCveUSO_Validated(object sender, EventArgs e)
        {
            General.ClaveSATValidar("USO", ref txtCveUSO, ref txtDescripcionUSO);

        }

        private void cmdBuscarCveUSO_Click(object sender, EventArgs e)
        {
            General.BotonBuscarClaveSAT("USO", ref txtCveUSO, ref txtDescripcionUSO);

        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCveFOP.Text) || string.IsNullOrEmpty(txtCveMEP.Text) || string.IsNullOrEmpty(txtCveUSO.Text))
            {
                MessageBox.Show("Indique las claves del SAT","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            Aceptar = true;
            Close();
        }
    }
}
