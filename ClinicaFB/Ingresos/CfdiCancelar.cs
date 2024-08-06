using ClinicaFB.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using Dapper;
using ClinicaFB.Helpers;
using CFDiLib;
using Org.BouncyCastle.Asn1.Ocsp;

namespace ClinicaFB.Ingresos
{
    public partial class CfdiCancelar : Form
    {
        private CFDI _CFDi = new CFDI();
        public CfdiCancelar(int CFDiId)
        {
            InitializeComponent();
            _CFDi.CfdiId = CFDiId;
        }

        private void CfdiCancelar_Load(object sender, EventArgs e)
        {
            CargaCFDi();
            cboMotivos.SelectedIndex = 0;
            ActiveControl = txtSerieNueva;
        }

        private void CargaCFDi()
        {
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.CfdiSelect();
                _CFDi = db.Query<CFDI>(sql, new { Id = _CFDi.CfdiId }).FirstOrDefault();
                if (_CFDi == null)
                {
                    MessageBox.Show("No se encontró el CFDi", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                txtEmisor.Text = _CFDi.EmisorNombre;
                txtFecha.Text = _CFDi.Fecha.ToString("dd/MM/yyyy");
                txtSerie.Text = _CFDi.Serie;
                txtFolio.Text = _CFDi.Folio.ToString();
                txtImporte.Text = _CFDi.Total.ToString("C");    
                txtUID.Text = _CFDi.uid;

                txtReceptor.Text = string.IsNullOrEmpty(_CFDi.ReceptorNombre)?"PUBLICO EN GENERAL":_CFDi.ReceptorNombre;



            }
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            if (cboMotivos.SelectedIndex == 0 && string.IsNullOrEmpty(txtUIDNuevo.Text))
            {
                MessageBox.Show("Indique el folio fiscal de la factura que sustituye a la que está cancelando", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("¿Está seguro de cancelar el CFDi?", "Cancelar CFDi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            if (Cancelar())
            {
                Close();
            }


        }

        private void cmdValidar_Click(object sender, EventArgs e)
        {
            if (cboMotivos.SelectedIndex != 0)
            {
                MessageBox.Show("Solo se indica la factura cuando se cancela con sustitución", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (spnFolioNuevo.Value == 0)
            {
                MessageBox.Show("Indique folio de la factura que sustituye a la que está cancelando", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.CfdiSelectXSerieYFolio();
                CFDI cfdi = db.Query<CFDI>(sql, new { Serie = txtSerieNueva.Text, Folio = spnFolioNuevo.Value }).FirstOrDefault();
                if (cfdi == null)
                {
                    MessageBox.Show("No se encontró la factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cfdi.CfdiId == _CFDi.CfdiId)
                {
                    MessageBox.Show("No puede indicar la misma factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                txtEmisorNuevo.Text = cfdi.EmisorNombre;
                txtFechaNueva.Text = cfdi.Fecha.ToString("dd/MM/yyyy");
                txtUIDNuevo.Text = cfdi.uid;
                txtImporteNuevo.Text = cfdi.Total.ToString("C");
                txtReceptorNuevo.Text = string.IsNullOrEmpty(cfdi.ReceptorNombre) ? "PUBLICO EN GENERAL" : cfdi.ReceptorNombre;
            }
        }

        private bool Cancelar()
        {

            SplashScreen.WindowsForms.Splasher splasher = new SplashScreen.WindowsForms.Splasher("Cancelando factura...");
            splasher.Show();
            bool cancelada = false;


            string uid = "";
            string rfc = "";
            string cer = "";
            string key = "";
            string pas = "";

            using (FbConnection db = General.GetDB())
            {
                CFDI cfdi = new CFDI();

                string sql = Queries.CfdiSelect();
                cfdi = db.Query<CFDI>(sql, new { Id = _CFDi.CfdiId }).FirstOrDefault();

                if (cfdi == null)
                {
                    MessageBox.Show("No se encuentra el CFDi", "Confirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    splasher.Close();

                    return cancelada;
                }


                sql = Queries.EmisorSelect();
                int emisorId = cfdi.EmisorId;


                Emisor emi = db.Query<Emisor>(sql, new { EmisorId = emisorId }).FirstOrDefault();

                if (emi == null)
                {
                    return cancelada;
                }

                uid = cfdi.uid;
                rfc = emi.RFC;
                cer = emi.Certificado;
                key = emi.LlavePrivada;
                pas = emi.PassWord;
            }

            ComprobanteCFDI comprobante = new ComprobanteCFDI();

            string motivo = cboMotivos.Text.Substring(0, 2);
            string res =    cboMotivos.SelectedIndex==0? 
                            comprobante.CancelaSW(rfc, cer, key, pas, uid, motivo,txtUIDNuevo.Text.ToUpper().Trim()):
                            comprobante.CancelaSW(rfc, cer, key, pas, uid, motivo);


            if (res.Substring(0, 3) == "999")
            {
                MessageBox.Show("No fue posible cancelar la factura " + res, "Confirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                splasher.Close();

                return cancelada;

            }


            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.CfdiCancela();
                db.Execute(sql, new { Id = _CFDi.CfdiId, Acuse = res });
            }
            splasher.Close();

            MessageBox.Show("Factura cancelada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cancelada = true;
            return cancelada;



        }

    }
}

