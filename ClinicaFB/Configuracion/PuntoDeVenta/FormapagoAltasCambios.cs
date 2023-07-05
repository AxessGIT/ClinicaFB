using ClinicaFB.Configuracion.Facturacion;
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

namespace ClinicaFB.Configuracion.PuntoDeVenta
{
    public partial class FormapagoAltasCambios : Form
    {
        private bool _esalta;
        private int _formaPagoId;

        public FormapagoAltasCambios(bool esalta, int formaPagoId)
        {
            InitializeComponent();
            _esalta = esalta;
            _formaPagoId=formaPagoId;
        }

        private void FormapagoAltasCambios_Load(object sender, EventArgs e)
        {
            if (_esalta)
            {
                Text = "Agregar forma de pago";

                using (FbConnection db = General.GetDB())
                {
                    string sql = Queries.FormaPagoUltimaClave();
                    int cve = db.ExecuteScalar<int>(sql);
                    cve++;
                    spnClave.Value = cve;
                    txtNombre.Focus();

                }
            }
            else
            {
                spnClave.Enabled = false;
                Text = "Modificar forma de pago";
                CargaFormaPago();
            }

        }



        private void CargaFormaPago()
        {


            using (FbConnection db = General.GetDB())
            {
                FormaPago formaPago = new FormaPago();

                string sql = Queries.FormaPagoSelect();

                formaPago = db.Query<FormaPago>(sql, new { FormaPagoId = _formaPagoId }).FirstOrDefault();

                if (formaPago != null)
                {
                    spnClave.Value = formaPago.Clave;
                    txtNombre.Text = formaPago.Nombre;
                    txtCveFOP.Text = formaPago.CveFOP;
                    txtCveFOP_Validated(new { }, new EventArgs { });

                }
            }

        }
        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtCveFOP_Validated(object sender, EventArgs e)
        {

            General.ClaveSATValidar("FOP", ref txtCveFOP, ref txtDescripcionFOP);

        }

        private void cmdBuscarCveFOP_Click(object sender, EventArgs e)
        {
            General.BotonBuscarClaveSAT("FOP", ref txtCveFOP, ref txtDescripcionFOP);

        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            if (spnClave.Value < 1)
            {
                MessageBox.Show("Indique la clave","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                spnClave.Focus();
                return;
            }



            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Indique el nombre", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombre.Focus();
                return;
            }

            string sql = "";
            using (FbConnection db = General.GetDB())
            {
                sql = Queries.FormaPagoExisteClave();
                FormaPago fp = new FormaPago();

                if (_esalta) { 
                    fp = db.Query<FormaPago>(sql, new {Clave = spnClave.Value}).FirstOrDefault();

                    if (fp!= null)
                    {
                        MessageBox.Show("Esa clave ya existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNombre.Focus();
                        return;

                    }
                }

                fp = new FormaPago();
                fp.FormaPagoId = _formaPagoId;
                fp.Clave = (int) spnClave.Value;
                fp.Nombre = txtNombre.Text;
                fp.CveFOP = txtCveFOP.Text;

                sql = _esalta ? Queries.FormaPagoInsert() : Queries.FormaPagoUpdate();
                db.Execute(sql, fp);
                Close();






            }



        }
    }
}
