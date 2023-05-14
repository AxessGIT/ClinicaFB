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

namespace ClinicaFB.Facturacion
{
    public partial class RazSocAltasCambios : Form
    {
        private bool _esAlta = false;
        private int _razonId;
        public RazSocAltasCambios(bool esAlta,int razonId)
        {
            InitializeComponent();
            _esAlta = esAlta;
            _razonId = razonId;
        }

        private void RazSocAltasCambios_Load(object sender, EventArgs e)
        {
            SetCombos();
            if (_esAlta)
            {
                Text = "Agregar razón social";
            }
            else
            {
                Text = "Modificar razón social";
                CargaRazonSocial();

            }
        }

        private void SetCombos()
        {
            General.ConfiguraCombo(ref cboCiudades, "CIU");
            General.ConfiguraCombo(ref cboEstados, "EDO");
            General.ConfiguraCombo(ref cboPaises, "PAI");

        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CargaRazonSocial()
        {

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.RazonSocialSelect();
                RazonSocial razSoc = db.Query<RazonSocial>(sql, new { RazonSocialId = _razonId }).FirstOrDefault();
                if (razSoc != null)
                {
                    txtRFC.Text = razSoc.RFC;
                    txtRazonSocial.Text = razSoc.RazonSoc;
                    txtDireccion.Text = razSoc.Direccion;
                    cboCiudades.SelectedValue = razSoc.CiudadId;
                    cboEstados.SelectedValue = razSoc.EstadoId;
                    cboPaises.SelectedValue = razSoc.PaisId;
                    txtCP.Text = razSoc.CP;
                    txtEMail.Text = razSoc.Email;
                    txtCveRef.Text = razSoc.CveREF;
                    txtCveUso.Text = razSoc.CveUSO;
                    txtCveFop.Text = razSoc.CveFOP;
                    txtCveMep.Text = razSoc.CveMEP;

                    txtCveRef_Validated(new { }, new EventArgs { });
                    txtCveUso_Validated(new { }, new EventArgs { });
                    txtCveFop_Validated(new { }, new EventArgs { });
                    txtCveMep_Validated(new { }, new EventArgs { });

                }

            }
        }

        private bool ValidaDatos()
        {
            if (string.IsNullOrEmpty(txtRFC.Text))
            {
                MessageBox.Show("Indique el RFC","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtRFC.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtRazonSocial.Text))
            {
                MessageBox.Show("Indique la razón social o nombre", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRazonSocial.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtCP.Text))
            {
                MessageBox.Show("Indique el código postal nombre", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCP.Focus();
                return false;
            }

            return true;
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            RazonSocial razSoc = new RazonSocial();
            razSoc.RazonSocialId = _razonId;
            razSoc.RFC = txtRFC.Text;
            razSoc.RazonSoc = txtRazonSocial.Text;
            razSoc.Direccion = txtDireccion.Text;
            razSoc.CiudadId = Convert.ToInt32(cboCiudades.SelectedValue);
            razSoc.EstadoId = Convert.ToInt32(cboEstados.SelectedValue);
            razSoc.PaisId = Convert.ToInt32(cboPaises.SelectedValue);
            razSoc.CP = txtCP.Text;

            razSoc.CveREF = txtCveRef.Text;
            razSoc.CveUSO = txtCveUso.Text;
            razSoc.CveFOP = txtCveFop.Text;
            razSoc.CveMEP = txtCveMep.Text;
            razSoc.Email = txtEMail.Text;





            string sql = _esAlta ? Queries.RazonSocialInsert():Queries.RazonSocialUpdate();


            using (FbConnection db = General.GetDB())
            {
                db.Execute(sql, razSoc);
            }
            Close();

        }

        private void txtCveRef_Validated(object sender, EventArgs e)
        {
            General.ValidarClaveSAT("REF",ref txtCveRef,ref txtRegimenFiscal);
        }

        private void txtCveUso_Validated(object sender, EventArgs e)
        {
            General.ValidarClaveSAT("USO", ref txtCveUso, ref txtUso);

        }

        private void txtCveFop_Validated(object sender, EventArgs e)
        {
            General.ValidarClaveSAT("FOP", ref txtCveFop, ref txtForma);

        }

        private void txtCveMep_Validated(object sender, EventArgs e)
        {
            General.ValidarClaveSAT("MEP", ref txtCveMep, ref txtMetodo);

        }

        private void cmdCveRefBuscar_Click(object sender, EventArgs e)
        {
            General.BuscarClaveSAT("REF", ref txtCveRef, ref txtRegimenFiscal);

        }

        private void cmdCveUsoBuscar_Click(object sender, EventArgs e)
        {
            General.BuscarClaveSAT("USO", ref txtCveUso, ref txtUso);

        }

        private void cmdCveFopBuscar_Click(object sender, EventArgs e)
        {
            General.BuscarClaveSAT("FOP", ref txtCveFop, ref txtForma);

        }

        private void cmdCveMepBuscar_Click(object sender, EventArgs e)
        {
            General.BuscarClaveSAT("MEP", ref txtCveMep, ref txtMetodo);

        }
    }
}
