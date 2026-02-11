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
using ClinicaFB.PuntoDeVenta;
using System.IO;

namespace ClinicaFB.Ingresos
{
    public partial class CfdiCancelar : Form
    {
        private CFDI _CFDi = new CFDI();
        private bool _esPDV = false;
        private string _tipo = "";
        long _cfdiId = 0;
        long _almacenId = 0;
        public bool Cancelada { get; set; } = false;

        public CfdiCancelar(long CFDiId, bool esPDV= false, string tipo = "FAC")
        {
            InitializeComponent();
            _CFDi.CfdiId = CFDiId;
            _esPDV = esPDV;
            _cfdiId = CFDiId;
            _tipo = tipo;
        }

        private void CfdiCancelar_Load(object sender, EventArgs e)
        {
            if (_tipo == "FAC")
                CargaFactura();
            else if (_tipo == "CPG")
                CargaComplemento();


            cboMotivos.SelectedIndex = 0;
            ActiveControl = txtSerieNueva;
        }


        private void CargaComplemento()
        {
            //Carga complemento de pago si existe
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.ComplementoDePagoSelect;
                var complemento = db.Query<ComplementoPago>(sql, new { ComPagId = _cfdiId }).FirstOrDefault();
                if (complemento == null)
                    return;
                sql = Queries.EmisorSelect();
                Emisor emisor = db.Query<Emisor>(sql, new { complemento.EmisorId }).FirstOrDefault();
                if (emisor == null)
                    return;
                sql = Queries.RazonSocialSelect();
                RazonSocial receptor = db.Query<RazonSocial>(sql, new { complemento.RazonSocialId }).FirstOrDefault();
                txtEmisor.Text = emisor.Nombre;
                txtFecha.Text = complemento.Fecha.ToString("dd/MM/yyyy");
                txtSerie.Text = complemento.Serie;
                txtFolio.Text = complemento.Folio.ToString();
                txtImporte.Text = complemento.Monto.ToString("C");
                txtUID.Text = complemento.UID;
                txtReceptor.Text = receptor == null ? "PUBLICO EN GENERAL" : receptor.RazonSoc;



            }
        }
        private void CargaFactura()
        {
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.CfdiSelect();
                if (_esPDV)
                {
                    sql = Queries.VentaVisorSelect;
                    Venta vta = db.Query<Venta>(sql, new { VentaId = _cfdiId }).FirstOrDefault();
                    if (vta == null)
                    {
                        MessageBox.Show("No se encontró la venta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    _almacenId = vta.AlmacenId;
                    txtEmisor.Text = vta.EmisorNombre;
                    txtFecha.Text = vta.Fecha.ToString("dd/MM/yyyy");
                    txtSerie.Text = vta.SerieFac;
                    txtFolio.Text = vta.FolioFac.ToString();
                    txtImporte.Text = (vta.Subtotal+vta.IVA-vta.Descuento).ToString("C");
                    txtUID.Text = vta.UID;
                    txtReceptor.Text = string.IsNullOrEmpty(vta.ClienteNombre) ? "PUBLICO EN GENERAL" : vta.ClienteNombre;
                }
                else { 
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
                Cancelada = true;
                Close();
            }


        }

        private void cmdValidar_Click(object sender, EventArgs e)
        {
            if (cboMotivos.SelectedIndex != 0)
            {
                MessageBox.Show("Solo se indica se cancela con sustitución", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (spnFolioNuevo.Value == 0)
            {
                MessageBox.Show("Indique folio del documento que sustituye al que está cancelando", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_tipo == "FAC")
                CargaFacturaSustituta();
            else if (_tipo == "CPG")
                CargaComplementoSustituto();



        }

        private void CargaComplementoSustituto()
        {
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.ComplementoDePagoSelectXSerieYFolio;
                ComplementoPago complemento = db.Query<ComplementoPago>(sql, new { Serie = txtSerieNueva.Text.Trim(), Folio = spnFolioNuevo.Value }).FirstOrDefault();
                if (complemento == null)
                {
                    MessageBox.Show("No se encontró el complemento de pago", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (complemento.ComPagId == _cfdiId)
                {
                    MessageBox.Show("No puede indicar el mismo complemento de pago", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                sql = Queries.EmisorSelect();
                Emisor emisor = db.Query<Emisor>(sql, new { complemento.EmisorId }).FirstOrDefault();
                if (emisor == null)
                    return;
                sql = Queries.RazonSocialSelect();
                RazonSocial receptor = db.Query<RazonSocial>(sql, new { complemento.RazonSocialId }).FirstOrDefault();
                txtEmisorNuevo.Text = emisor.Nombre;
                txtFechaNueva.Text = complemento.Fecha.ToString("dd/MM/yyyy");
                txtUIDNuevo.Text = complemento.UID;
                txtImporteNuevo.Text = complemento.Monto.ToString("C");
                txtReceptorNuevo.Text = receptor == null ? "PUBLICO EN GENERAL" : receptor.RazonSoc;
            }
        }

        private void CargaFacturaSustituta()
        {
            using (FbConnection db = General.GetDB())
            {
                string sql = "";
                if (_esPDV)
                {
                    sql = Queries.VentaVisorSelectXSerieYFolio;
                    Venta vta = db.Query<Venta>(sql, new { Serie = txtSerieNueva.Text.Trim(), Folio = spnFolioNuevo.Value }).FirstOrDefault();
                    if (vta == null)
                    {
                        MessageBox.Show("No se encontró la venta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (vta.VentaId == _cfdiId)
                    {
                        MessageBox.Show("No puede indicar la misma factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    txtEmisorNuevo.Text = vta.EmisorNombre;
                    txtFechaNueva.Text = vta.Fecha.ToString("dd/MM/yyyy");
                    txtUIDNuevo.Text = vta.UID;
                    txtImporteNuevo.Text = (vta.Subtotal + vta.IVA - vta.Descuento).ToString("C");
                    txtReceptorNuevo.Text = string.IsNullOrEmpty(vta.ClienteNombre) ? "PUBLICO EN GENERAL" : vta.ClienteNombre;
                }
                else
                {
                    sql = Queries.CfdiSelectXSerieYFolio();
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
            long emisorId = 0;
            string sql = "";
            string cerTmp = Path.GetTempFileName() + ".cer";
            string llaveTmp = Path.GetTempFileName() + ".key";

            using (FbConnection db = General.GetDB())
            {



                if (_tipo == "FAC")
                {

                    if (_esPDV)
                    {
                        Venta vta = new Venta();
                        sql = Queries.VentaSelect;
                        vta = db.Query<Venta>(sql, new { VentaId = _cfdiId }).FirstOrDefault();

                        if (vta == null)
                        {
                            MessageBox.Show("No se encuentra la venta", "Confirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            splasher.Close();

                            return cancelada;
                        }

                        uid = vta.UID;
                        emisorId = vta.EmisorId;
                    }
                    else
                    {


                        CFDI cfdi = new CFDI();

                        sql = Queries.CfdiSelect();
                        cfdi = db.Query<CFDI>(sql, new { Id = _CFDi.CfdiId }).FirstOrDefault();

                        if (cfdi == null)
                        {
                            MessageBox.Show("No se encuentra el CFDi", "Confirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            splasher.Close();

                            return cancelada;
                        }
                        uid = cfdi.uid;
                        emisorId = cfdi.EmisorId;
                    }
                }
                else if (_tipo == "CPG")
                {
                    ComplementoPago complemento = new ComplementoPago();
                    sql = Queries.ComplementoDePagoSelect;
                    complemento = db.Query<ComplementoPago>(sql, new { ComPagId = _cfdiId }).FirstOrDefault();
                    if (complemento == null)
                    {
                        MessageBox.Show("No se encuentra el complemento de pago", "Confirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        splasher.Close();
                        return cancelada;
                    }
                    uid = complemento.UID;
                    emisorId = complemento.EmisorId;
                }

                sql = Queries.EmisorSelect();           
                Emisor emi = db.Query<Emisor>(sql, new { EmisorId = emisorId }).FirstOrDefault();

                if (emi == null)
                {
                    return cancelada;
                }



                if (emi.Cer.Length > 0 && emi.Llave.Length > 0)
                {
                    File.WriteAllBytes(cerTmp, emi.Cer);
                    File.WriteAllBytes(llaveTmp, emi.Llave);
                }

                rfc = emi.RFC;
                cer = File.Exists(cerTmp)?cerTmp:emi.Certificado;
                key = File.Exists(llaveTmp)?llaveTmp: emi.LlavePrivada;
                pas = emi.PassWord;
            }

            ComprobanteCFDI comprobante = new ComprobanteCFDI();

            string motivo = cboMotivos.Text.Substring(0, 2);
            string res =    cboMotivos.SelectedIndex==0? 
                            comprobante.CancelaSW(rfc, cer, key, pas, uid, motivo,txtUIDNuevo.Text.ToUpper().Trim()):
                            comprobante.CancelaSW(rfc, cer, key, pas, uid, motivo);


            //Eliminar archivos temporales
            try
            {
                if (File.Exists(cerTmp)) File.Delete(cerTmp);
                if (File.Exists(llaveTmp)) File.Delete(llaveTmp);
            }
            catch { }
            if (res.Substring(0, 3) == "999" || res.Contains("Status:201")==false && res.Contains("Status:202") == false)
            {
                MessageBox.Show("No fue posible cancelar la factura " + res, "Confirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                splasher.Close();

                return cancelada;

            }


            using (FbConnection db = General.GetDB())
            {

                if (_tipo == "FAC")
                { 
                    if (_esPDV)
                    {
                        sql = Queries.VentaSetDatosCancelacion;
                        db.Execute(sql, new { VentaId = _cfdiId, Acuse = res });
                    }
                    else
                    {
                        sql = Queries.CfdiCancela();
                        db.Execute(sql, new { Id = _CFDi.CfdiId, Acuse = res });
                    }
                }
                else if (_tipo == "CPG")
                {
                    sql = Queries.ComplementoDePagoUpdateCancelacion;
                    db.Execute(sql, new { ComPagId = _cfdiId, Acuse = res });
                }
            }
            splasher.Close();

            MessageBox.Show($"Documento cancelado\nAcuse: {res} ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cancelada = true;
            return cancelada;



        }

 

    }
}

