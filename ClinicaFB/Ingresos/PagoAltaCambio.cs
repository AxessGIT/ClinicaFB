using ClinicaFB.Facturacion;
using ClinicaFB.Helpers;
using ClinicaFB.Modelo;
using ClinicaFB.PuntoDeVenta;
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
    public partial class PagoAltaCambio : Form
    {
        private bool _esPDV = false;
        private long _pagoId = 0;
        private long _emisorId = 0;
        private long _razonSocialId = 0;
        private bool _esAlta = true; // Indica si es alta o cambio
        private long _FacturaRelId = 0;


        public PagoAltaCambio(bool esPDV, bool esAlta, long pagoId, long emisorId)
        {
            InitializeComponent();
            _esPDV = esPDV;
            _pagoId = pagoId;
            _emisorId = emisorId;
            _esAlta = esAlta;
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdBuscarCveFOP_Click(object sender, EventArgs e)
        {
            General.BotonBuscarClaveSAT("FOP", ref txtCveFOP, ref txtDescripcionFOP);

        }

        private void txtCveFOP_Validated(object sender, EventArgs e)
        {
            General.ClaveSATValidar("FOP", ref txtCveFOP, ref txtDescripcionFOP);

        }

        private void PagoAltaCambio_Load(object sender, EventArgs e)
        {
            CargaEmisor();
            if (_esAlta == false)
            {
                CargaPago();
            }


        }


        private void CargaPago()
        {
            if (_pagoId == 0)
            {
                return;
            }
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.ComplementoDePagoSelect;
                ComplementoPago pago = db.Query<ComplementoPago>(sql, new { ComPagId = _pagoId }).FirstOrDefault();
                if (pago == null)
                {
                    return;
                }
                _emisorId = pago.EmisorId;
                _razonSocialId = pago.RazonSocialId;
                dtpFecha.Value = pago.Fecha;
                txtMonto.DecimalValue = pago.Monto;
                txtCveFOP.Text = pago.CveFOP;
                txtSerie.Text = pago.Serie;
                txtFolio.Text = pago.Folio.ToString();
                txtUID.Text = pago.UID;
                txtAcuse.Text = pago.Acuse;
                txtCveFOP.Text = pago.CveFOP;

                txtDescripcionFOP.Text =  General.GetDescripcionClaveSAT("FOP", pago.CveFOP);


                CargaEmisor();
                CargaDatosRazonSocial();
                GetCFDisRelacionados();
                
                if (pago.Timbrado)
                {
                    dtpFecha.Enabled = false;
                    txtCveFOP.Enabled = false;
                    cmdBuscarCveFOP.Enabled = false;
                    cmdBuscaFacturaRel.Enabled = false;
                    txtMonto.Enabled = false;
                    cmdClienteBuscar.Enabled = false;
                    cmdClienteAgregar.Enabled = false;
                    cmdClienteModificar.Enabled = false;
                    cmdPublico.Enabled = false;


                    cmdGuardar.Enabled = false;
                }

            }
        }
        private void CargaEmisor()
        {

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.EmisorSelect();
                Emisor emi = db.Query<Emisor>(sql, new { EmisorId = _emisorId }).FirstOrDefault();
                if (emi != null)
                {
                    txtEmisorNombre.Text = emi.Nombre;
                }

            }

        }


        private void CargaDatosRazonSocial()
        {
            if (_razonSocialId == 0)
            {
                txtRFC.Text = "XAXX010101000";
                txtRazonSocial.Text = "PUBLICO EN GENERAL";
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

        private void cmdClienteBuscar_Click(object sender, EventArgs e)
        {
            RazonesSocialesListado razonesSocialesListado = new RazonesSocialesListado(true);
            razonesSocialesListado.ShowDialog();

            if (razonesSocialesListado.RazonId != 0)
            {
                _razonSocialId = razonesSocialesListado.RazonId;
                CargaDatosRazonSocial();
            }

        }

        private void ClienteAltasCambios(bool esAlta)
        {
            int razId = _esAlta ? 0 : (int)_razonSocialId;
            RazSocAltasCambios razSocAltasCambios = new RazSocAltasCambios(esAlta, razId);
            razSocAltasCambios.ShowDialog();
            if (razSocAltasCambios.RazonId != 0)
            {
                _razonSocialId = razSocAltasCambios.RazonId;
                CargaDatosRazonSocial();
            }

        }

        private void cmdClienteAgregar_Click(object sender, EventArgs e)
        {
            ClienteAltasCambios(true);

        }

        private void cmdClienteModificar_Click(object sender, EventArgs e)
        {
            if (_razonSocialId == 0)
            {
                MessageBox.Show("No hay cliente seleccionado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ClienteAltasCambios(false);

        }

        private void cmdPublico_Click(object sender, EventArgs e)
        {
            _razonSocialId = 0;
            CargaDatosRazonSocial();

        }

        private void GetCFDisRelacionados()
        {

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.ComPagRelsSelect;

                List<ComPagRel> rels = db.Query<ComPagRel>(sql, new { ComPagoId = _pagoId }).ToList();
                if (rels.Count == 0)
                    return;
                _FacturaRelId = rels[0].DocumentoId;
                txtSerieRel.Text = rels[0].Serie;
                txtFolioRel.Text = rels[0].Folio.ToString();
                txtFechaRel.Text = rels[0].Fecha.ToShortDateString();
                txtUIDRel.Text = rels[0].UID;
                txtMonto.DecimalValue = rels[0].Importe;

            }
        }



        private void GuardaPago()        
        {
            ComplementoPago pago = new ComplementoPago();   
            pago.ComPagId = _pagoId;
            pago.EsPDV = _esPDV;
            pago.EmisorId = _emisorId;
            pago.RazonSocialId = _razonSocialId;
            pago.Fecha = dtpFecha.Value;
            pago.CveFOP = txtCveFOP.Text.Trim();
            pago.CveMON = "MXN";
            pago.TipoDeCambio = 1;
            pago.Monto = txtMonto.DecimalValue;


            using (FbConnection db = General.GetDB())
            {
                string serie = string.Empty;
                int folio = 0;

                string sql = string.Empty;
                if (_esAlta)
                {
                    long sucursalId = Properties.Settings.Default.SucursalId;
                    sql = Queries.SucursalSelect();
                    Sucursal suc = db.Query<Sucursal>(sql, new { SucursalId = sucursalId }).FirstOrDefault();
                    if (suc == null)
                    {
                        MessageBox.Show("No se encontró la sucursal del emisor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (suc.FolioPagos == 0)
                    {
                        sql = Queries.SucursalSetSiguienteFolioPagos;
                        db.Execute(sql, new { SucursalId = sucursalId });
                    }

                    serie = suc.SeriePagos;
                    folio = suc.FolioPagos == 0 ? 1 : suc.FolioPagos;

                    sql = Queries.SucursalSetSiguienteFolioPagos;
                    db.Execute(sql, new { SucursalId = sucursalId });


                }
                else
                {
                    serie = txtSerie.Text.Trim();
                    folio = int.Parse(txtFolio.Text.Trim());
                }



                if (_esAlta)
                {
                    pago.Serie = serie;
                    pago.Folio = folio;
                }


                sql = _esAlta ? Queries.ComplementoDePagoInsert : Queries.ComplementoDePagoUpdate;

                if (_esAlta)
                {
                    _pagoId = db.ExecuteScalar<long>(sql, pago);
                }
                else
                {
                    pago.ComPagId = _pagoId;
                    db.Execute(sql, pago);
                }
            }
            BorraRelacionados();
            GuardaRelacionados();

        }


        private void BorraRelacionados()
        {
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.ComPagRelsDelete;
                db.Execute(sql, new { ComPagoId = _pagoId });
            }
        }

        private void GuardaRelacionados() {
            if (_FacturaRelId == 0)
            {
                return;
            }


            
            ComPagRel rel = new ComPagRel();
            rel.ComPagoId = _pagoId;
            rel.DocumentoId = _FacturaRelId;
            rel.Serie = txtSerieRel.Text.Trim();
            rel.Folio = int.Parse(txtFolioRel.Text.Trim());
            rel.Fecha = DateTime.Parse(txtFechaRel.Text.Trim());
            rel.UID = txtUIDRel.Text.Trim();
            rel.CveMON = "MXN";
            rel.TipoDeCambio = 1;
            rel.Parcialidad = 1;
            rel.Importe = txtMonto.DecimalValue;
            rel.SaldoAnterior = 0;
            rel.Pagado = txtMonto.DecimalValue;
            rel.SaldoInsoluto = 0;
            rel.FechaPago = dtpFecha.Value;




            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.VentaDetallesSelect;

                decimal baseIVA16 = 0;
                decimal iva16 = 0;
                decimal baseIVA0 = 0;
                decimal baseExento = 0;

                List<VentaDetalle> detalles = db.Query<VentaDetalle>(sql, new { VentaId = _FacturaRelId }).ToList();

                baseIVA16 = detalles.Where(d => d.TipoIVA == 1 && d.TasaIVA==16).Sum(d => Math.Round(d.Cantidad * d.Precio,2) - d.Descuento);
                iva16 = Math.Round(baseIVA16 * 0.16m,2);

                baseIVA0 = detalles.Where(d => d.TipoIVA == 1 && d.TasaIVA == 0).Sum(d => Math.Round(d.Cantidad * d.Precio,2) - d.Descuento);
                baseExento = detalles.Where(d => d.TipoIVA == 0).Sum(d => Math.Round(d.Cantidad * d.Precio,2) - d.Descuento);

                rel.BaseIVA16 = baseIVA16;
                rel.IVA16 = iva16;
                rel.BaseIVA0 = baseIVA0;
                rel.BaseIVAExento = baseExento;




                sql = Queries.ComPagRelsInsert;
                db.Execute(sql, rel);
            }
        }



        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidaDAtos())
            {
                return;
            }

            GuardaPago();
            Close();
        }

        private bool ValidaDAtos()
        {
            if (_FacturaRelId == 0)
            {
                MessageBox.Show("Debe seleccionar una factura relacionada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            if (txtMonto.DecimalValue <= 0)
            {
                MessageBox.Show("Indique el monto del pago", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMonto.Focus();
                return false;
            }


            if (txtCveFOP.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Debe indicar la clave de forma de pago", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCveFOP.Focus();
                return false;
            }
            return true;
        }

        private void cmdBuscaFacturaRel_Click(object sender, EventArgs e)
        {
            FacturaBuscar facturaBuscar = new FacturaBuscar(_emisorId, esPDV: _esPDV);
            facturaBuscar.ShowDialog();
            if (facturaBuscar.FacturaId != 0)
            {
                _FacturaRelId = facturaBuscar.FacturaId;
                GetFacturaRelacionada();
            }

        }

        private void GetFacturaRelacionada()
        {
            if (_FacturaRelId == 0)
            {
                return;
            }
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.VentaSelect;
                Venta fac = db.Query<Venta>(sql, new { VentaId = _FacturaRelId }).FirstOrDefault();
                if (fac == null)
                {
                    return;
                }
                txtSerieRel.Text = fac.SerieFac;
                txtFolioRel.Text = fac.FolioFac.ToString();
                txtFechaRel.Text = fac.FechaFac.ToShortDateString();
                txtUIDRel.Text = fac.UID;
                txtMonto.DecimalValue = fac.Total;
                _razonSocialId = fac.ClienteId;
                CargaDatosRazonSocial();
                ActiveControl = txtMonto;   
            }
        }
        

    }
}
