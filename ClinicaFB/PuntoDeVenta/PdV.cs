using ClinicaFB.Facturacion;
using ClinicaFB.Helpers;
using ClinicaFB.Ingresos;
using ClinicaFB.Modelo;
using Dapper;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;


namespace ClinicaFB.PuntoDeVenta
{
    public partial class PdV : Form
    {


        private int _razonSocialId = 0;

        //private string _tipo;

        private string _cveFOP;
        private string _cveMEP;
        private string _cveUSO;


        private bool _imprimir;
        private string _impresora;


        private bool _mandarCorreos;
        private string _correos;

        private int _sucursalId = 0;



        private BindingList<Emisor> _emisores = new BindingList<Emisor>();
        private BindingList<Almacen> _almacenes = new BindingList<Almacen>();
        private BindingList<Doctor> _doctores = new BindingList<Doctor>();
        private BindingList<VentaDetalle> _ventaArticulos = new BindingList<VentaDetalle>();
        private BindingList<VentaDetalle> _detalleOriginal = new BindingList<VentaDetalle>();
        private long _conceptoVentaId = 0;


        private Color colorFondo = Color.White;
        private Color colorLetra = Color.DarkGreen;
        private bool _esAlta = false;
        private long _ventaId = 0;
        private long _almacenOriginalId = 0;
        private Venta vta = new Venta();

        public PdV(bool esAlta = true, long ventaId = 0)
        {
            InitializeComponent();
            _esAlta = esAlta;
            _ventaId = ventaId;
        }

        private void PdV_Load(object sender, EventArgs e)
        {
            Sucursal suc = General.GetDatosSucursal();
            _conceptoVentaId = UtilsInv.GetConceptoInternoId("S", "VENTA");

            if (suc != null)
            {
                _sucursalId = suc.SucursalId;
            }

            PonColores();
            CargaEmisores();
            CargaAlmacenes();
            CargaDoctores();

            if (_esAlta == false)
            {
                CargaVenta();
                CargaDetalle();
                CargaPagos();
            }
            SetGrid();
        }


        private void SetGrid()
        {
            grdArticulos.DataSource = null;



            grdArticulos.AllowUserToAddRows = false;
            grdArticulos.AllowUserToDeleteRows = false;


            grdArticulos.AutoGenerateColumns = false;
            grdArticulos.ReadOnly = true;
            grdArticulos.AllowUserToResizeColumns = false;
            grdArticulos.AllowUserToResizeRows = false;



            grdArticulos.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(grdArticulos.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            grdArticulos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;



            grdArticulos.DataSource = _ventaArticulos;

        }


        private void CargaEmisores()
        {
            _emisores = UtilsPDV.GetEmisores();


            cboEmisores.DataSource = null;
            cboEmisores.DataSource = _emisores;
            cboEmisores.ValueMember = "EmisorId";
            cboEmisores.DisplayMember = "Nombre";
            cboEmisores.SelectedValue = _emisores[0].EmisorId;

        }


        private void CargaAlmacenes()
        {
            long almacenIdDefa = 0;
            _almacenes = UtilsPDV.GetAlmacenes();

            foreach (var alma in _almacenes)
            {
                if (alma.Defa)
                {
                    almacenIdDefa = alma.AlmacenId;
                    break;
                }

            }

            cboAlmacenes.DataSource = null;
            cboAlmacenes.DataSource = _almacenes;
            cboAlmacenes.ValueMember = "AlmacenId";
            cboAlmacenes.DisplayMember = "Nombre";
            cboAlmacenes.SelectedValue = almacenIdDefa;


        }

        private void CargaDoctores()
        {
            long doctorIdDefa = 0;

            using (FbConnection db = General.GetDB())
            {
                string sql = Helpers.Queries.DoctoresSelect();

                var res = db.Query<Doctor>(sql).ToList();

                if (res.Count == 0)
                {
                    return;
                }

                _doctores = new BindingList<Doctor>(res);
                doctorIdDefa = doctorIdDefa == 0 ? (long)_doctores[0].Doctor_Id : doctorIdDefa;
            }
            cboDoctores.DataSource = null;
            cboDoctores.DataSource = _doctores;
            cboDoctores.ValueMember = "Doctor_Id";
            cboDoctores.DisplayMember = "NombreCompleto";
            cboDoctores.SelectedValue = (long)0;//doctorIdDefa;

        }


        private void CargaVenta()
        {
            using (FbConnection db = General.GetDB())
            {
                string sql = Helpers.Queries.VentaSelect;

                vta = db.Query<Venta>(sql, new { VentaId = _ventaId }).FirstOrDefault();

                if (vta != null)
                {
                    if (vta.ClienteId != 0)
                    {
                        _razonSocialId = (int)vta.ClienteId;
                        CargaDatosRazonSocial();
                    }

                    dtpFecha.Value = vta.Fecha;
                    txtObservaciones.Text = vta.Observaciones;

                    if (vta.AlmacenId != 0)
                        cboAlmacenes.SelectedValue = vta.AlmacenId;

                    if (vta.DoctorId != 0)
                        cboDoctores.SelectedValue = vta.DoctorId;

                    if (vta.EmisorId != 0)
                        cboEmisores.SelectedValue = vta.EmisorId;

                    _almacenOriginalId = vta.AlmacenId;
                    _cveFOP = vta.FormaPago;
                    _cveMEP = vta.MetodoPago;
                    _cveUSO = vta.Uso;
                }
            }
        }

        private void CargaDetalle()
        {
            using (FbConnection db = General.GetDB())
            {
                string sql = Helpers.Queries.VentaDetallesSelect;
                List<VentaDetalle> detalle = db.Query<VentaDetalle>(sql, new { VentaId = _ventaId }).ToList();
                if (detalle != null)
                {
                    _ventaArticulos = new BindingList<VentaDetalle>(detalle);
                    SetGrid();
                    CalculaTotales();
                }
            }

            _detalleOriginal = new BindingList<VentaDetalle>();

            foreach (var det in _ventaArticulos)
            {
                _detalleOriginal.Add(new VentaDetalle
                {
                    VentaId = det.VentaId,
                    VentaDetId = det.VentaDetId,
                    ArticuloId = det.ArticuloId,
                    NoIden = det.NoIden,
                    Descripcion = det.Descripcion,
                    UDM = det.UDM,
                    Precio = det.Precio,
                    Cantidad = det.Cantidad,
                    CveProSer = det.CveProSer,
                    CveUni = det.CveUni,
                    TipoIVA = det.TipoIVA,
                    TasaIVA = det.TasaIVA,
                    Descuento = det.Descuento,
                    IVA = det.IVA
                });

            }
        }

        private void CargaPagos()
        {
            List<Pago> pagos = UtilsInv.GetPagosVenta(_ventaId);

            decimal totalPagos = pagos.Sum(x => x.Importe);
            foreach (Pago pago in pagos)
            {
                switch (pago.Tipo)
                {
                    case 1:
                        txtEfectivo.DecimalValue = pago.Importe;
                        break;
                    case 2:
                        txtTarjeta.DecimalValue = pago.Importe;
                        break;
                    case 3:
                        txtTransferencia.DecimalValue = pago.Importe;
                        break;
                    case 4:
                        txtTarjetaCredito.DecimalValue = pago.Importe;
                        break;
                    case 5:
                        txtCheque.DecimalValue = pago.Importe;
                        break;
                    case 6:
                        txtIntermediarios.DecimalValue = pago.Importe;
                        break;
                }
            }

            txtTotalPagos.DecimalValue = totalPagos;
            txtCambio.DecimalValue = totalPagos - txtTotal.DecimalValue;
            if (txtCambio.DecimalValue < 0)
            {
                txtCambio.DecimalValue = 0;
            }

        }

        private void PonColores()
        {
            txtRFC.BackColor = colorFondo;
            txtRFC.ForeColor = colorLetra;

            txtRazonSocial.BackColor = colorFondo;
            txtRazonSocial.ForeColor = colorLetra;


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
            txtConcepto.Focus();

        }


        private void CargaDatosRazonSocial()
        {
            if (_razonSocialId == 0)
            {
                return;
            }

            using (FbConnection db = General.GetDB())
            {
                string sql = Helpers.Queries.RazonSocialSelect();
                RazonSocial raz = db.Query<RazonSocial>(sql, new { RazonSocialId = _razonSocialId }).FirstOrDefault();

                if (raz != null)
                {
                    txtRFC.Text = raz.RFC;
                    txtRazonSocial.Text = raz.RazonSoc;
                    _cveFOP = raz.CveFOP;
                    _cveMEP = raz.CveMEP;
                    _cveUSO = raz.CveUSO;
                    _correos = raz.Email;
                }
            }


        }


        private void PdV_Shown(object sender, EventArgs e)
        {
            txtConcepto.Focus();

        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
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

        private void ClienteAltasCambios(bool esAlta)
        {
            int razId = esAlta ? 0 : _razonSocialId;
            RazSocAltasCambios razSocAltasCambios = new RazSocAltasCambios(esAlta, razId);
            razSocAltasCambios.ShowDialog();
            if (razSocAltasCambios.RazonId != 0)
            {
                _razonSocialId = razSocAltasCambios.RazonId;
                CargaDatosRazonSocial();
            }

        }

        private void txtConcepto_KeyDown(object sender, KeyEventArgs e)
        {

            bool agregar = false;
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    break;

                case Keys.F5:
                    ArticulosBuscar articulosBuscar = new ArticulosBuscar(txtConcepto.Text.Trim(), 0);
                    articulosBuscar.ShowDialog();

                    if (articulosBuscar.ArticuloId != 0)
                    {

                        using (FbConnection db = General.GetDB())
                        {
                            string sql = Helpers.Queries.ArticuloSelect();
                            Articulo art = db.Query<Articulo>(sql, new { ArticuloId = articulosBuscar.ArticuloId }).FirstOrDefault();
                            if (art != null)
                            {
                                txtConcepto.Text = art.Clave;
                                agregar = true;
                            }
                        }

                    }
                    break;
                case Keys.Enter:
                    if (string.IsNullOrEmpty(txtConcepto.Text))
                    {
                        return;
                    }
                    agregar = true;

                    break;
            }

            if (agregar)
            {
                AgregaArticulo();
                txtConcepto.Text = string.Empty;
                spnCantidad.Value = 1;
                txtConcepto.Focus();

            }


        }
        private void AgregaArticulo()
        {

            using (FbConnection db = General.GetDB())
            {
                string sql = Helpers.Queries.ArticuloSelectxClave();
                Articulo art = db.Query<Articulo>(sql, new { Clave = txtConcepto.Text.Trim() }).FirstOrDefault();

                if (art == null)
                {
                    MessageBox.Show("Esa clave no existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;

                }
                if (art.Tipo != 0)
                {
                    MessageBox.Show("Solo productos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (spnCantidad.Value <= 0)
                {
                    MessageBox.Show("La cantidad no puede ser cero", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Impuesto imp = new Impuesto();

                int tipoIVA = 0;
                decimal tasaIVA = 0;

                if (art.ImpuestoId != 0)
                {
                    sql = Helpers.Queries.ImpuestoSelect();
                    imp = db.Query<Impuesto>(sql, new { art.ImpuestoId }).FirstOrDefault();

                    if (imp != null)
                    {
                        if (imp.Descripcion == "EXENTO")
                        {
                            tipoIVA = 2;
                            tasaIVA = 0;
                        }
                        else
                        {
                            tipoIVA = 1;
                            tasaIVA = imp.Porcentaje;

                        }
                    }

                }

                //decimal baseIVA = Math.Round(spnCantidad.Value * art.Precio1, 2);
                //decimal importeIVA = (tipoIVA == 1) ? Math.Round(baseIVA * tasaIVA / 100, 2) : 0;

                long emisorId = cboEmisores.SelectedValue == null ? 0 : (long)cboEmisores.SelectedValue;
                string serie = "";
                string des = "";

                des = art.Descripcion.Trim();

                sql = Helpers.Queries.SerieDefault();
                SerieDoc serDefa = db.Query<SerieDoc>(sql, new { EmisorId = emisorId, Tipo = "FAC" }).FirstOrDefault();

                if (serDefa != null)
                {
                    serie = serDefa.Serie;
                }



                decimal descuento = Math.Round(art.Precio1 * spnDescuento.Value / 100, 2);
                decimal PrecioNeto = art.Precio1 - descuento;
                decimal iva = Math.Round(PrecioNeto * (decimal)spnCantidad.Value * tasaIVA / 100, 2);

                _ventaArticulos.Add(new VentaDetalle
                {
                    ArticuloId = (int)art.ArticuloId,
                    NoIden = txtConcepto.Text.Trim(),
                    Descripcion = art.Descripcion,
                    UDM = art.UDM,
                    Precio = art.Precio1,
                    Cantidad = (decimal)spnCantidad.Value,
                    CveProSer = art.CveProSer,
                    CveUni = art.CveUni,
                    TipoIVA = tipoIVA,
                    TasaIVA = tasaIVA,
                    Descuento = descuento,
                    IVA = iva


                });

                SetGrid();
                CalculaTotales();


            }

        }
        private void CalculaTotales()
        {
            decimal subTotal = 0, descuento = 0, IVA = 0, retISR = 0, retIVA = 0;

            foreach (var art in _ventaArticulos)
            {
                subTotal += art.Total;
                IVA += art.IVA;
            }

            txtSubTotal.DecimalValue = subTotal;
            txtIVA.DecimalValue = IVA;
            txtTotal.DecimalValue = subTotal - descuento + IVA - retISR - retIVA;


        }

        private void cmdConceptoModificar_Click(object sender, EventArgs e)
        {
            if (grdArticulos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un artículo para modificarlo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            VentaDetalle detalle = _ventaArticulos[grdArticulos.CurrentRow.Index];
            VentaConceptoModificar ventaConceptoModificar = new VentaConceptoModificar(detalle, spnDescuento.Value);
            ventaConceptoModificar.ShowDialog();
            if (ventaConceptoModificar.Guardar)
            {
                _ventaArticulos[grdArticulos.CurrentRow.Index] = ventaConceptoModificar._partida;
                SetGrid();
                CalculaTotales();
            }
        }

        private void cmdConceptoBorrar_Click(object sender, EventArgs e)
        {
            if (grdArticulos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un artículo para borrarlo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _ventaArticulos.RemoveAt(grdArticulos.CurrentRow.Index);
            SetGrid();
            CalculaTotales();

        }

        private void ChecaImportesPago(int cualPago)
        {
            txtTotalPagos.DecimalValue = txtEfectivo.DecimalValue + txtTarjeta.DecimalValue + txtTransferencia.DecimalValue +
                txtTarjetaCredito.DecimalValue + txtCheque.DecimalValue + txtIntermediarios.DecimalValue;
            txtCambio.DecimalValue = txtTotalPagos.DecimalValue - txtTotal.DecimalValue;

            if (txtCambio.DecimalValue < 0)
            {
                txtCambio.DecimalValue = 0;
            }

            if (txtCambio.DecimalValue > txtEfectivo.DecimalValue)
            {
                MessageBox.Show("El cambio no puede ser mayor al efectivo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }





        private void ChecaPago(int tipoPago)
        {
            decimal importe = txtTotal.DecimalValue - txtTotalPagos.DecimalValue;
            if (importe <= 0 && tipoPago != 1)
            {
                return;
            }

            switch (tipoPago)
            {
                case 1:
                    txtEfectivo.DecimalValue = importe;
                    break;
                case 2:
                    txtTarjeta.DecimalValue = importe;
                    break;
                case 3:
                    txtTransferencia.DecimalValue = importe;
                    break;
                case 4:
                    txtTarjetaCredito.DecimalValue = importe;
                    break;

                case 5:
                    txtCheque.DecimalValue = importe;

                    break;
                case 6:
                    txtIntermediarios.DecimalValue = importe;

                    break;
                default:
                    break;
            }
            txtTotalPagos.DecimalValue = txtEfectivo.DecimalValue + txtTarjeta.DecimalValue
                + txtTransferencia.DecimalValue + txtTarjetaCredito.DecimalValue + txtCheque.DecimalValue + txtIntermediarios.DecimalValue;
            txtCambio.DecimalValue = txtTotalPagos.DecimalValue - txtTotal.DecimalValue;

        }

        private void cmdEfectivo_Click(object sender, EventArgs e)
        {
            ChecaPago(1);
            ActiveControl = txtEfectivo;

        }

        private void cmdTarjeta_Click(object sender, EventArgs e)
        {
            ChecaPago(2);
            ActiveControl = txtTarjeta;

        }

        private void cmdTransferencia_Click(object sender, EventArgs e)
        {
            ChecaPago(3);
            ActiveControl = txtTransferencia;

        }

        private void txtEfectivo_Validated(object sender, EventArgs e)
        {
            ChecaImportesPago(1);

        }

        private void txtTarjeta_Validated(object sender, EventArgs e)
        {
            ChecaImportesPago(2);

        }

        private void txtTransferencia_Validated(object sender, EventArgs e)
        {
            ChecaImportesPago(3);

        }

        private bool PagoCompleto()
        {
            return txtTotal.DecimalValue <= txtTotalPagos.DecimalValue;

        }

        private async void cmdTicket_Click(object sender, EventArgs e)
        {
            if (_ventaArticulos.Count == 0)
            {
                MessageBox.Show("No se ha agregado ningún artículos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            if (!PagoCompleto())
            {
                MessageBox.Show("El total de los pagos no coincide con el total de la venta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            long emisorId = cboEmisores.SelectedValue == null ? 0 : (long)cboEmisores.SelectedValue;

            if (emisorId == 0)
            {
                MessageBox.Show("Seleccione el emisor", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            long almacenId = cboAlmacenes.SelectedValue == null ? 0 : (long)cboAlmacenes.SelectedValue;

            if (almacenId == 0)
            {
                MessageBox.Show("Seleccione el almacén", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (ExistenRenglonesSinPrecio())
            {
                MessageBox.Show("Existen renglones sin precio, verifique", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            TicketEnviarOpciones opciones = new TicketEnviarOpciones(enviar: false, impimir: true);
            opciones.ShowDialog();

            if (opciones.Aceptar == false)
            {
                return;
            }

            _imprimir = opciones.chkImprimir.Checked;
            _mandarCorreos = opciones.chkMandarCorreo.Checked;
            _correos = opciones.txtCorreos.Text.Trim();
            _impresora = opciones.cboImpresoras.Text.Trim();
            await GuardaVenta(false, pag: txtTotalPagos.DecimalValue, cam: txtCambio.DecimalValue);
            Inicializa();

        }


        private async Task ActualizaExistencias(FbConnection db, FbTransaction transaction)
        {
            string sql = "";
            ArticuloExistencia articuloExistencia = new ArticuloExistencia();

            long almacenId = cboAlmacenes.SelectedValue == null ? 0 : (long)cboAlmacenes.SelectedValue;


            foreach (var Renglon in _ventaArticulos)
            {
                sql = Helpers.Queries.ArticuloExistenciaSelect;
                articuloExistencia = db.Query<ArticuloExistencia>(sql, new { Renglon.ArticuloId, AlmacenId = almacenId }, transaction).FirstOrDefault();

                if (articuloExistencia == null)
                {
                    articuloExistencia = new ArticuloExistencia();
                    articuloExistencia.ArticuloId = Renglon.ArticuloId;
                    articuloExistencia.AlmacenId = almacenId;
                    articuloExistencia.Entradas = 0;
                    articuloExistencia.Salidas = Renglon.Cantidad;
                    sql = Helpers.Queries.ArticuloExistenciaInsert;
                    await db.ExecuteAsync(sql, articuloExistencia, transaction);
                }
                else
                {
                    articuloExistencia.Salidas = articuloExistencia.Salidas + Renglon.Cantidad;
                    sql = Helpers.Queries.ArticuloExistenciaUpdate;
                    await db.ExecuteAsync(sql, articuloExistencia, transaction);
                }

            }

        }



        private void CargaConceptoVenta()
        {


            using (FbConnection db = General.GetDB())
            {
                string sql = Helpers.Queries.ConceptoSelectByDescripcion;
                ConceptoMovInv conceptoMovInv = db.Query<ConceptoMovInv>(sql, new { Tipo = "S", Descripcion = "VENTA" }).FirstOrDefault();
                if (conceptoMovInv != null)
                {
                    _conceptoVentaId = conceptoMovInv.ConMovInvId;
                }
            }

        }

        private async Task GuardaVenta(bool facturar = false, decimal pag = 0, decimal cam = 0, DateTime fechaFac = default, bool soloGuardar = false)
        {
            CambiaBotones(false);
            using (FbConnection db = General.GetDB())
            {
                await db.OpenAsync();

                using (var transaction = db.BeginTransaction())
                {
                    try
                    {
                        string serie = "";
                        int folio = 0;
                        string serieFac = "";
                        int folioFac = 0;
                        long almacenId = cboAlmacenes.SelectedValue == null ? 0 : (long)cboAlmacenes.SelectedValue;

                        Almacen alma = new Almacen();
                        string sql = "";

                        if (_esAlta)
                        {
                            sql = Helpers.Queries.AlmacenSelect();
                            alma = db.Query<Almacen>(sql, new { AlmacenId = almacenId }, transaction).FirstOrDefault();

                            if (alma == null)
                            {
                                MessageBox.Show("No se encontró el almacén", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            serie = alma.SerieVen;
                            folio = alma.FolioVen;
                            UtilsInv.AlmacenIncrementaFolioVenta(almacenId, db, transaction);
                        }
                        else
                        {
                            await UtilsInv.DevuelveDetalleOriginal(_detalleOriginal.ToList(), _almacenOriginalId, entrada: false, db, transaction);
                            await UtilsInv.VentaBorraDetalle(_ventaId, db, transaction);
                            await UtilsInv.VentaBorraMovimientos(_ventaId, db, transaction);
                            await UtilsInv.BorraPagos(origenTipo: 2, docId: _ventaId, db, transaction);
                        }

                        if (facturar)
                        {
                            serieFac = alma.SerieFac;
                            folioFac = alma.FolioFac;
                        }

                        await ActualizaExistencias(db, transaction);

                        Emisor emi = new Emisor();
                        long emisorId = cboEmisores.SelectedValue == null ? 0 : (long)cboEmisores.SelectedValue;

                        sql = Helpers.Queries.EmisorSelect();
                        emi = db.Query<Emisor>(sql, new { EmisorId = emisorId }, transaction).FirstOrDefault();

                        long docId = (long)cboDoctores.SelectedValue;

                        if (_esAlta)
                        {
                            vta = new Venta
                            {
                                Serie = serie,
                                Folio = folio
                            };
                        }

                        vta.VentaId = _ventaId;
                        vta.SucursalId = _sucursalId;
                        vta.EmisorId = emisorId;
                        vta.AlmacenId = almacenId;
                        vta.DoctorId = docId;
                        vta.ClienteId = _razonSocialId;
                        vta.Tipo = facturar ? "FAC" : "TIC";
                        vta.Fecha = dtpFecha.Value;
                        vta.FormaPago = _cveFOP;
                        vta.Moneda = "MXN";
                        vta.TipoCambio = 1;
                        vta.MetodoPago = _cveMEP;
                        vta.LugarExpedicion = emi.CP;
                        vta.Uso = _cveUSO;
                        vta.Subtotal = txtSubTotal.DecimalValue;
                        vta.Descuento = 0;
                        vta.IVA = txtIVA.DecimalValue;
                        vta.RetISR = 0;
                        vta.RetIVA = 0;
                        vta.Total = txtTotal.DecimalValue;
                        vta.SerieFac = serieFac;
                        vta.FolioFac = folioFac;
                        vta.Observaciones = txtObservaciones.Text.Trim();
                        vta.Acuse = "";
                        vta.WebId = General.RandomString(5);
                        vta.FechaFac = fechaFac;

                        sql = _esAlta ? Helpers.Queries.VentaInsert : Helpers.Queries.VentaUpdate;

                        if (_esAlta)
                        {
                            _ventaId = await db.ExecuteScalarAsync<int>(sql, vta, transaction);
                            vta.VentaId = _ventaId;
                        }
                        else
                        {
                            await db.ExecuteAsync(sql, vta, transaction);
                        }

                        foreach (VentaDetalle det in _ventaArticulos)
                        {
                            sql = Helpers.Queries.VentaDetalleInsert;

                            VentaDetalle vtaDet = new VentaDetalle
                            {
                                VentaId = _ventaId,
                                ArticuloId = det.ArticuloId,
                                NoIden = det.NoIden,
                                Descripcion = det.Descripcion,
                                UDM = det.UDM,
                                Cantidad = det.Cantidad,
                                Precio = det.Precio,
                                Descuento = det.Descuento,
                                CveProSer = det.CveProSer,
                                CveUni = det.CveUni,
                                TipoIVA = det.TipoIVA,
                                TasaIVA = det.TasaIVA,
                                IVA = det.IVA
                            };

                            long detalleId = await db.ExecuteScalarAsync<long>(sql, vtaDet, transaction);

                            decimal ultimoCosto = 0;

                            sql = Helpers.Queries.DocumentoMovimientoInsert;

                            ArticuloMovimiento documentoMovimiento = new ArticuloMovimiento
                            {
                                DocumentoId = _ventaId,
                                AlmacenId = almacenId,
                                EsVenta = true,
                                Tipo = "VEN",
                                ConceptoId = _conceptoVentaId,
                                Fecha = dtpFecha.Value,
                                ArticuloId = det.ArticuloId,
                                Cantidad = det.Cantidad,
                                Importe = det.Precio,
                                UltimoCosto = ultimoCosto
                            };

                            await db.ExecuteAsync(sql, documentoMovimiento, transaction);
                        }

                        await UtilsInv.VentaReconstruyeCapasDeCostos(almacenId, _ventaArticulos.ToList(), db, transaction);

                        if (_esAlta == false)
                        {
                            await UtilsInv.VentaReconstruyeCapasDeCostos(almacenId, _detalleOriginal.ToList(), db, transaction);
                        }

                        List<Pago> pagos = new List<Pago>();
                        if (txtEfectivo.DecimalValue > 0)
                        {
                            pagos.Add(new Pago { OrigenTipo = 2, DoctoOrigenId = (int)_ventaId, Tipo = 1, Importe = txtEfectivo.DecimalValue, Cambio = txtCambio.DecimalValue });
                        }

                        if (txtTarjeta.DecimalValue > 0)
                        {
                            pagos.Add(new Pago { OrigenTipo = 2, DoctoOrigenId = (int)_ventaId, Tipo = 2, Importe = txtTarjeta.DecimalValue, Referencia = txtReferencia.Text });
                        }

                        if (txtTransferencia.DecimalValue > 0)
                        {
                            pagos.Add(new Pago { OrigenTipo = 2, DoctoOrigenId = (int)_ventaId, Tipo = 3, Importe = txtTransferencia.DecimalValue, Referencia = txtReferencia.Text });
                        }

                        if (txtTarjetaCredito.DecimalValue > 0)
                        {
                            pagos.Add(new Pago { OrigenTipo = 2, DoctoOrigenId = (int)_ventaId, Tipo = 4, Importe = txtTarjetaCredito.DecimalValue, Referencia = txtReferencia.Text });
                        }

                        if (txtCheque.DecimalValue > 0)
                        {
                            pagos.Add(new Pago { OrigenTipo = 2, DoctoOrigenId = (int)_ventaId, Tipo = 5, Importe = txtCheque.DecimalValue, Referencia = txtReferencia.Text });
                        }

                        if (txtIntermediarios.DecimalValue > 0)
                        {
                            pagos.Add(new Pago { OrigenTipo = 2, DoctoOrigenId = (int)_ventaId, Tipo = 6, Importe = txtIntermediarios.DecimalValue, Referencia = txtReferencia.Text });
                        }

                        if (pagos.Count > 0)
                        {
                            await Task.Run(() => UtilsInv.GuardaPagos(pagos, db, transaction));
                        }

                        // ✅ COMMIT - Todo lo crítico de BD ya se guardó
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error al guardar la venta: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            // ✅ Operaciones secundarias FUERA de la transacción
            if (!soloGuardar)
            {
                if (facturar)
                {
                    try
                    {
                        // Facturar requiere nueva conexión/transacción interna
                        using (FbConnection dbFac = General.GetDB())
                        {
                            await dbFac.OpenAsync();
                            using (var transFac = dbFac.BeginTransaction())
                            {
                                int res = await ManejaCFDIs.GeneraFactura(vta, dbFac, transFac,
                                    _imprimir, _impresora, _mandarCorreos, _correos);

                                if (res != 0)
                                {
                                    transFac.Rollback();
                                    await UtilsInv.QuitaDatosFactura(vta.VentaId);
                                    MessageBox.Show("La venta se guardó pero hubo un error al facturar. Puede facturar desde el módulo de facturas.",
                                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else
                                {
                                    transFac.Commit();
                                }
                            }
                        }
                    }
                    catch (Exception exFac)
                    {
                        System.Diagnostics.Debug.WriteLine($"Error facturando: {exFac.Message}");
                        MessageBox.Show("La venta se guardó correctamente pero no se pudo completar la facturación.",
                            "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    try
                    {
                        await Task.Run(() =>
                            ManejaCFDIs.ImprimeTicketPDV(vta, _ventaArticulos, _imprimir, _impresora,
                                _mandarCorreos, _correos, pagado: pag, cambio: cam));
                    }
                    catch (Exception exTicket)
                    {
                        System.Diagnostics.Debug.WriteLine($"Error imprimiendo/enviando ticket: {exTicket.Message}");
                        // No mostrar error al usuario, solo loguear
                    }
                }
            }
        }


        private bool ExistenRenglonesSinPrecio()
        {
            bool existen = false;
            foreach (var renglon in _ventaArticulos)
            {
                if (renglon.Precio <= 0)
                {
                    existen = true;
                    break;
                }
            }
            return existen;
        }

        private void CambiaBotones(bool habilitado)
        {
            cmdFactura.Enabled = habilitado;
            cmdGuardar.Enabled = habilitado;
            cmdTicket.Enabled = habilitado;
            cmdSalir.Enabled = habilitado;
        }
        private async void cmdFactura_Click(object sender, EventArgs e)
        {
            if (_ventaArticulos.Count == 0)
            {
                MessageBox.Show("No se ha agregado ningún artículo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }

            if (!PagoCompleto())
            {
                MessageBox.Show("El total de los pagos no coincide con el total de la venta", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            long emisorId = cboEmisores.SelectedValue == null ? 0 : (long)cboEmisores.SelectedValue;

            if (emisorId == 0)
            {
                MessageBox.Show("Seleccione el emisor", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            long almacenId = cboAlmacenes.SelectedValue == null ? (long)0 : (long)cboAlmacenes.SelectedValue;

            if (almacenId == 0)
            {
                MessageBox.Show("Seleccione el almacén", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (ExistenRenglonesSinPrecio())
            {
                MessageBox.Show("Existen renglones sin precio, verifique", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            CambiaBotones(false);

            decimal[] pagos = { txtEfectivo.DecimalValue, txtTarjeta.DecimalValue, txtTarjetaCredito.DecimalValue, txtTransferencia.DecimalValue, txtCheque.DecimalValue, txtIntermediarios.DecimalValue };

            Array.Sort(pagos);


            decimal pagoMayor = pagos[pagos.Count() - 1];

            if (pagoMayor == txtEfectivo.DecimalValue)
                _cveFOP = "01";
            else if (pagoMayor == txtTarjeta.DecimalValue)
                _cveFOP = "28";
            else if (pagoMayor == txtTarjetaCredito.DecimalValue)
                _cveFOP = "04";
            else if (pagoMayor == txtTransferencia.DecimalValue)
                _cveFOP = "03";
            else if (pagoMayor == txtCheque.DecimalValue)
                _cveFOP = "02";
            else if (pagoMayor == txtIntermediarios.DecimalValue)
                _cveFOP = "31";


            FacturarOpciones clavesSATSeleccionar = new FacturarOpciones(_razonSocialId, _cveFOP, _cveMEP, _cveUSO, _correos);
            clavesSATSeleccionar.ShowDialog();

            if (clavesSATSeleccionar.Aceptar == false)
            {
                CambiaBotones(true);
                return;
            }

            _cveFOP = clavesSATSeleccionar.txtCveFOP.Text.Trim();
            _cveMEP = clavesSATSeleccionar.txtCveMEP.Text.Trim();
            _cveUSO = clavesSATSeleccionar.txtCveUSO.Text.Trim();
            _imprimir = clavesSATSeleccionar.chkImprimir.Checked;
            _impresora = clavesSATSeleccionar.cboImpresoras.Text.Trim();
            _mandarCorreos = clavesSATSeleccionar.chkMandarCorreo.Checked;
            _correos = clavesSATSeleccionar.txtCorreos.Text.Trim();

            DateTime fechaFactura = clavesSATSeleccionar.dtpFecha.Value;

            await GuardaVenta(facturar: true, fechaFac: fechaFactura);
            Inicializa();


        }


        private void Inicializa()
        {
            _razonSocialId = 0;

            txtRFC.Text = "XAXX010101000";
            txtRazonSocial.Text = "PUBLICO EN GENERAL";

            txtConcepto.Text = "";
            spnCantidad.Value = 1;
            _ventaArticulos = new BindingList<VentaDetalle>();

            SetGrid();
            CalculaTotales();

            txtEfectivo.DecimalValue = 0;
            txtTarjeta.DecimalValue = 0;
            txtTarjetaCredito.DecimalValue = 0;
            txtTransferencia.DecimalValue = 0;
            txtCheque.DecimalValue = 0;
            txtIntermediarios.DecimalValue = 0;
            txtTotalPagos.DecimalValue = 0;
            txtCambio.DecimalValue = 0;
            spnDescuento.Value = 0;

            CambiaBotones(true);

            txtConcepto.Focus();



        }

        private void txtConcepto_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmdTarjetaCredito_Click(object sender, EventArgs e)
        {
            ChecaPago(4);
            ActiveControl = txtTarjetaCredito;
        }

        private void currencyEdit1_TextBox_Validated(object sender, EventArgs e)
        {

        }

        private void txtTarjetaCredito_Validated(object sender, EventArgs e)
        {
            ChecaImportesPago(4);
        }

        private void spnCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AgregaArticulo();
                txtConcepto.Text = string.Empty;
                spnCantidad.Value = 1;
                txtConcepto.Focus();
            }
        }

        private void spnDescuento_Validated(object sender, EventArgs e)
        {
            foreach (var art in _ventaArticulos)
            {
                art.Descuento = Math.Round(art.Precio * spnDescuento.Value / 100, 2);
                art.IVA = Math.Round((art.Precio - art.Descuento) * art.Cantidad * art.TasaIVA / 100, 2);


            }
            SetGrid();
            CalculaTotales();

        }

        private void cmdCheque_Click(object sender, EventArgs e)
        {
            ChecaPago(5);
            ActiveControl = txtCheque;

        }

        private void txtCheque_Validated(object sender, EventArgs e)
        {
            ChecaImportesPago(5);

        }

        private async void cmdExportarCaptura_Click(object sender, EventArgs e)
        {
            await Task.Run(() => Exportar());
        }

        private void Exportar()
        {
            Microsoft.Office.Interop.Excel.Application oExcel;

            oExcel = new Microsoft.Office.Interop.Excel.Application();
            oExcel.Workbooks.Add();


            int ren = 1;

            oExcel.Cells[ren, 1] = "ArticuloId";
            oExcel.Cells[ren, 2] = "Clave";
            oExcel.Cells[ren, 3] = "Descripcion";
            oExcel.Cells[ren, 4] = "Cantidad";
            oExcel.Cells[ren, 5] = "Precio";
            oExcel.Cells[ren, 6] = "Descuento";
            oExcel.Cells[ren, 7] = "IVA";
            oExcel.Cells[ren, 8] = "CveProSer";
            oExcel.Cells[ren, 9] = "CveUni";
            oExcel.Cells[ren, 10] = "TipoIVA";
            oExcel.Cells[ren, 11] = "TasaIVA";
            oExcel.Cells[ren, 12] = "IVA";
            ren++;

            foreach (var detalle in _ventaArticulos)
            {
                oExcel.Cells[ren, 1] = detalle.ArticuloId;
                oExcel.Cells[ren, 2] = $"'{detalle.NoIden}";
                oExcel.Cells[ren, 3] = detalle.Descripcion;
                oExcel.Cells[ren, 4] = detalle.Cantidad;
                oExcel.Cells[ren, 5] = detalle.Precio;
                oExcel.Cells[ren, 6] = detalle.Descuento;
                oExcel.Cells[ren, 7] = detalle.IVA;
                oExcel.Cells[ren, 8] = $"'{detalle.CveProSer}";
                oExcel.Cells[ren, 9] = detalle.CveUni;
                oExcel.Cells[ren, 10] = detalle.TipoIVA;
                oExcel.Cells[ren, 11] = detalle.TasaIVA;
                oExcel.Cells[ren, 12] = detalle.IVA;
                ren++;

            }




            oExcel.Visible = true;




        }

        private void cmdImportar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de Excel|*.xls;*.xlsx";
            openFileDialog.Title = "Seleccione el archivo de Excel";
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            Microsoft.Office.Interop.Excel.Application oExcel;

            oExcel = new Microsoft.Office.Interop.Excel.Application();
            oExcel.Workbooks.Open(openFileDialog.FileName);

            if (oExcel.Worksheets.Count == 0)
            {
                MessageBox.Show("No hay hojas en el archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (oExcel.Cells[1, 1].Value != "ArticuloId")
            {
                MessageBox.Show("No se encontró la columna ArticuloId", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int ren = 2;
            while (oExcel.Cells[ren, 1].Value != null)
            {
                VentaDetalle detalle = new VentaDetalle();
                detalle.ArticuloId = (int)oExcel.Cells[ren, 1].Value;
                detalle.NoIden = oExcel.Cells[ren, 2].Value;
                detalle.Descripcion = oExcel.Cells[ren, 3].Value;
                detalle.Cantidad = (decimal)oExcel.Cells[ren, 4].Value;
                detalle.Precio = (decimal)oExcel.Cells[ren, 5].Value;
                detalle.Descuento = (decimal)oExcel.Cells[ren, 6].Value;
                detalle.IVA = (decimal)oExcel.Cells[ren, 7].Value;
                detalle.CveProSer = oExcel.Cells[ren, 8].Value;
                detalle.CveUni = oExcel.Cells[ren, 9].Value;
                detalle.TipoIVA = (int)oExcel.Cells[ren, 10].Value;
                detalle.TasaIVA = (decimal)oExcel.Cells[ren, 11].Value;
                detalle.IVA = Math.Round(detalle.Cantidad * detalle.Precio * detalle.TasaIVA / 100, 2);

                _ventaArticulos.Add(detalle);
                ren++;
            }
            oExcel.Quit();
            SetGrid();
            CalculaTotales();



        }

        private void cmdIntermediarios_Click(object sender, EventArgs e)
        {
            ChecaPago(6);
            ActiveControl = txtCheque;

        }

        private void txtIntermediarios_Validated(object sender, EventArgs e)
        {
            ChecaImportesPago(6);

        }

        private void txtReferencia_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }


        private async void cmdGuardar_Click_1(object sender, EventArgs e)
        {
            if (_ventaArticulos.Count == 0)
            {
                MessageBox.Show("No se ha agregado ningún artículos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            await GuardaVenta(soloGuardar: true);
            Close();


        }

        private void cmdAmazonXL_Click(object sender, EventArgs e)
        {
            AmazonXLCargar amazonXLCargar = new AmazonXLCargar();
            amazonXLCargar.ShowDialog();

            if (amazonXLCargar.DialogResult == DialogResult.Cancel)
                return;

            string archivlXLS = amazonXLCargar.txtArchivoXLS.Text.Trim();
            int renIni = (int)amazonXLCargar.spnRenglonInicial.Value;
            int renFin = (int)amazonXLCargar.spnRenglonFinal.Value;
            CargarXLAmazon(archivlXLS, renIni, renFin);
        }

        private void CargarXLAmazon(string archivoXLS, int renIni, int renFin)
        {
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Workbook workbook = excelApp.Workbooks.Open(archivoXLS);
            Worksheet worksheet = workbook.Sheets[1];
            for (int ren = renIni; ren <= renFin; ren++)
            {
                string sku = worksheet.Cells[ren, 1].Value.ToString().Trim();
                decimal cantidad = Convert.ToDecimal(worksheet.Cells[ren, 3].Value);
                decimal precio = Convert.ToDecimal(worksheet.Cells[ren, 4].Value);

                if (string.IsNullOrEmpty(sku) || cantidad < 1 || precio < 1)
                {
                    continue;
                }

                int tipoIVA = 0;
                decimal tasaIVA = 0;
                Articulo art = new Articulo();

                using (FbConnection db = General.GetDB())
                {
                    string sql = Helpers.Queries.ArticuloSelectXSKU;
                    art = db.Query<Articulo>(sql, new { SKU = sku }).FirstOrDefault();

                    if (art == null)
                    {
                        continue;
                    }

                    /////////////////////////
                    ///

                    Impuesto imp = new Impuesto();


                    if (art.ImpuestoId != 0)
                    {
                        sql = Helpers.Queries.ImpuestoSelect();
                        imp = db.Query<Impuesto>(sql, new { art.ImpuestoId }).FirstOrDefault();

                        if (imp != null)
                        {
                            if (imp.Descripcion == "EXENTO")
                            {
                                tipoIVA = 2;
                                tasaIVA = 0;
                            }
                            else
                            {
                                tipoIVA = 1;
                                tasaIVA = imp.Porcentaje;

                            }
                        }

                    }
                }



                decimal descuento = Math.Round(precio * spnDescuento.Value / 100, 2);
                decimal PrecioNeto = precio - descuento;
                decimal iva = Math.Round(PrecioNeto * cantidad * tasaIVA / 100, 2);

                _ventaArticulos.Add(new VentaDetalle
                {
                    ArticuloId = (int)art.ArticuloId,
                    NoIden = art.CodigoBarras,
                    Descripcion = art.Descripcion,
                    UDM = art.UDM,
                    Precio = precio,
                    Cantidad = cantidad,
                    CveProSer = art.CveProSer,
                    CveUni = art.CveUni,
                    TipoIVA = tipoIVA,
                    TasaIVA = tasaIVA,
                    Descuento = descuento,
                    IVA = iva


                }
                );
            }
            workbook.Close();
            excelApp.Quit();
            SetGrid();
            CalculaTotales();
        }
    }
}