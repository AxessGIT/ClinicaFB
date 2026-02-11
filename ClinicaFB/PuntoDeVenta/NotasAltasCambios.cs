using ClinicaFB.Facturacion;
using ClinicaFB.Helpers;
using ClinicaFB.Modelo;
using Dapper;
using FirebirdSql.Data.FirebirdClient;
using SplashScreen.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFB.PuntoDeVenta
{
    public partial class NotasAltasCambios : Form
    {
        private bool _esAlta = false;
        private long _notaId = 0;
        //private long _cfdiId = 0;
        private long _razonSocialId = 0;
        private long _almacenOriginalId = 0;




        private long _emisorId = 0;
        private long _almacenId = 0;



        private BindingList<Emisor> _emisores = new BindingList<Emisor>();
        private BindingList<Almacen> _almacenes = new BindingList<Almacen>();
        private BindingList<VentaDetalle> _notaArticulos = new BindingList<VentaDetalle>();
        private List<VentaDetalle> _detalleOriginal = new List<VentaDetalle>();
        private Venta _notaOriginal;
        private long _ventaIdRel = 0;
        private bool _esPDV = false;


        public NotasAltasCambios(bool esPDV, bool esAlta,long emisorId,long almacenId, long notaId)
        {
            InitializeComponent();
            _esAlta = esAlta;
            _notaId = notaId;
            _emisorId=emisorId;
            _almacenId=almacenId;
            _esPDV = esPDV;
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NotasAltasCambios_Load(object sender, EventArgs e)
        {
            CargaEmisor();
            CargaAlmacen();

            if (!_esAlta)
            {
                CargaNota();
                CalculaTotales();
                _detalleOriginal = UtilsInv.GetDetalleOriginal(_notaArticulos.ToList());
            }
            SetGrid();

            if (_esPDV == false)
            {
                lblAlmacen.Visible = false;
                txtAlmacenNombre.Visible = false;
                cmdCargarVentaOFactura.Text = "Cargar Fac.";

            }
        }

        private void DesHabilitaControles()
        {
            dtpFecha.Enabled = false;
            cmdCargarVentaOFactura.Enabled = false;
            cmdClienteBuscar.Enabled = false;
            cmdClienteAgregar.Enabled = false;
            cmdClienteModificar.Enabled = false;
            cmdPublico.Enabled = false;
            txtConcepto.Enabled = false;
            spnCantidad.Enabled = false;
            cmdConceptoModificar.Enabled = false;
            cmdConceptoBorrar.Enabled = false;
            txtObservaciones.Enabled = false;

            txtCveRel.Enabled = false;
            cmdBuscarCveRel.Enabled = false;
            txtCveFOP.Enabled = false;
            cmdBuscarCveFOP.Enabled = false;
            txtCveMEP.Enabled = false;
            cmdBuscarCveMEP.Enabled = false;
            txtCveUSO.Enabled = false;
            cmdBuscarCveUSO.Enabled = false;
            cmdGuardar.Enabled = false;
            cmdTimbrar.Enabled = false;
            cmdBuscaFacturaRel.Enabled = false;


        }


        private void CargaNota()
        {
            Venta nota = new Venta();
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.VentaSelect;
                nota = db.Query<Venta>(sql, new { VentaId = _notaId }).FirstOrDefault();
                if (nota == null)
                {
                    MessageBox.Show("No se encontró la nota", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                txtSerie.Text = nota.Serie;
                txtFolio.Text = nota.Folio.ToString();
                dtpFecha.Value = nota.Fecha;
                txtObservaciones.Text = nota.Observaciones;
                txtCveFOP.Text = nota.FormaPago;
                txtCveMEP.Text = nota.MetodoPago;
                txtCveUSO.Text = nota.Uso;
                txtUID.Text = nota.UID;
                txtAcuse.Text = nota.Acuse;

                txtCveFOP_Validated(new object(), new EventArgs());
                txtCveMEP_Validated(new object(), new EventArgs());
                txtCveUSO_Validated(new object(), new EventArgs());

                _razonSocialId = nota.ClienteId;
                CargaDatosRazonSocial();
                _almacenOriginalId = nota.AlmacenId;
                _notaOriginal = nota;
                _ventaIdRel = nota.VentaIdRel;
            }
            CargaDetalle(_notaId);
            BuscaFacturaRelacionada();
            if (nota.Timbrada || nota.Cancelada)
            {
                DesHabilitaControles();
            }

        }

        private void CargaAlmacen()
        {


            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.AlmacenSelect();

                Almacen al = db.Query<Almacen>(sql, new { AlmacenId = _almacenId }).FirstOrDefault();

                if (al != null)
                {
                    txtAlmacenNombre.Text = al.Nombre;
                }




            }
        }

        private void CargaEmisor()
        {

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.EmisorSelect();
                Emisor emi = db.Query<Emisor>(sql, new {EmisorId = _emisorId }).FirstOrDefault();
                if (emi != null)
                {
                    txtEmisorNombre.Text = emi.Nombre;
                }

            }

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



            grdArticulos.ColumnHeadersDefaultCellStyle.Font = new Font(grdArticulos.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            grdArticulos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;



            grdArticulos.DataSource = _notaArticulos;

        }

        private void cmdCargarTicket_Click(object sender, EventArgs e)
        {
            
            VentaCargar ventaCargar = new VentaCargar(_esPDV, _emisorId, _almacenId);
            ventaCargar.ShowDialog();
            if (ventaCargar.VentaId == 0 && ventaCargar.CFDIId == 0)
            {
                return;
            }

            using (FbConnection db = General.GetDB())
            {
                string sql = _esPDV?Queries.VentaSelect:Queries.CfdiSelect();


                if (_esPDV)
                {
                    Venta venta = db.Query<Venta>(sql, new { ventaCargar.VentaId }).FirstOrDefault();


                    if (venta != null)
                    {
                        _ventaIdRel = venta.FacturaGlobalId;

                        if (_ventaIdRel == 0 && !string.IsNullOrEmpty(venta.UID))
                        {
                            _ventaIdRel = venta.VentaId;

                        }
                    }
                }
                else {                     
                    CFDI cfdi = db.Query<CFDI>(sql, new { Id = ventaCargar.CFDIId }).FirstOrDefault();
                    if (cfdi != null)
                    {
                        _ventaIdRel = cfdi.CfdiId;
                    }
                }
            }
            BuscaFacturaRelacionada();

            bool borrarActual = false;

            if (_notaArticulos.Count>0 && MessageBox.Show("¿Desea borrar los artìculos actuales?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                borrarActual = true;
                _notaArticulos.Clear();
            }

            if (_esPDV)
            {
                CargaDetalle(ventaCargar.VentaId, borrarActual);
            }
            else
            {
                CargaDetalleCFDi(_ventaIdRel,borrarActual);
            }
        }

        private void CargaDetalleCFDi(long cfdiId, bool borraActual)
        {
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.CfdiDetallesSelect();                
                List<CfdiDetalle> detalle = db.Query<CfdiDetalle>(sql, new { Id = cfdiId }).ToList();

                if (detalle == null || detalle.Count == 0)
                {
                    MessageBox.Show("No se encontró detalle", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (borraActual)
                {
                    _notaArticulos.Clear();
                }

                foreach (var det in detalle)
                {
                    _notaArticulos.Add(new VentaDetalle
                    {
                        ArticuloId = det.ArticuloId,
                        NoIden = det.NoIden,
                        Descripcion = det.Descripcion,
                        UDM = det.UDM,
                        Precio = det.ValorUnitario,
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
            SetGrid();
            CalculaTotales();

        }

        private void BuscaFacturaRelacionada()
        {
            if (_ventaIdRel == 0)
            {
                return;
            }

            using(FbConnection db = General.GetDB())
            {
                string sql = _esPDV?Queries.VentaSelect:Queries.CfdiSelect();

                if (_esPDV)
                {
                    Venta facturaRel = db.Query<Venta>(sql, new { VentaId = _ventaIdRel }).FirstOrDefault();
                    if (facturaRel != null)
                    {
                        txtSerieRel.Text = facturaRel.SerieFac;
                        txtFolioRel.Text = facturaRel.FolioFac.ToString();
                        txtFechaRel.Text = facturaRel.Fecha.ToShortDateString();
                        txtUIDRel.Text = facturaRel.UID;
                    }
                }
                else {                     

                    CFDI cfdiRel = db.Query<CFDI>(sql, new { Id = _ventaIdRel }).FirstOrDefault();

                    if (cfdiRel != null)
                    {
                        txtSerieRel.Text = cfdiRel.Serie;
                        txtFolioRel.Text = cfdiRel.Folio.ToString();
                        txtFechaRel.Text = cfdiRel.Fecha.ToShortDateString();
                        txtUIDRel.Text = cfdiRel.uid;
                    }
                }
            }
        }

        private void CargaDetalle(long ventaId, bool borrar=false)
        {
            List<VentaDetalle> detalle = new List<VentaDetalle>();

            detalle = UtilsInv.GetVentaDetalle(ventaId);
            
            
            if (detalle == null || detalle.Count == 0)
            {
                MessageBox.Show("No se encontró detalle", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (borrar)
            {
                _notaArticulos = new BindingList<VentaDetalle>(detalle);
            }
            else
            {
                var tempList = _notaArticulos.ToList();
                tempList.AddRange(detalle);
                _notaArticulos = new BindingList<VentaDetalle>(tempList);
            }
            foreach (var art in _notaArticulos)
            {
                art.DetalleIdRel = art.VentaDetId;
            }

            SetGrid();
            CalculaTotales();
        }

        private void CalculaTotales()
        {
            decimal subTotal = 0, descuento = 0, IVA = 0, retISR = 0, retIVA = 0;

            foreach (var art in _notaArticulos)
            {
                subTotal += art.Total;
                IVA += art.IVA;
            }

            txtSubTotal.DecimalValue = subTotal;
            txtIVA.DecimalValue = IVA;
            txtTotal.DecimalValue = subTotal - descuento + IVA - retISR - retIVA;


        }

        private void cmdConceptoBorrar_Click(object sender, EventArgs e)
        {
            if (grdArticulos.CurrentRow == null)
            {
                MessageBox.Show("Favor de seleccionar un artículo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _notaArticulos.RemoveAt(grdArticulos.CurrentRow.Index);
            CalculaTotales();
            SetGrid();

        }

        private void cmdConceptoModificar_Click(object sender, EventArgs e)
        {
            if (grdArticulos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un artículo para modificarlo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            VentaDetalle detalle = _notaArticulos[grdArticulos.CurrentRow.Index];
            VentaConceptoModificar ventaConceptoModificar = new VentaConceptoModificar(detalle);
            ventaConceptoModificar.ShowDialog();
            if (ventaConceptoModificar.Guardar)
            {
                _notaArticulos[grdArticulos.CurrentRow.Index] = ventaConceptoModificar._partida;
                SetGrid();
                CalculaTotales();
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
                    ArticulosBuscar articulosBuscar = new ArticulosBuscar(txtConcepto.Text.Trim());
                    articulosBuscar.ShowDialog();

                    if (articulosBuscar.ArticuloId != 0)
                    {

                        using (FbConnection db = General.GetDB())
                        {
                            string sql = Queries.ArticuloSelect();
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
                string sql = Queries.ArticuloSelectxClave();
                Articulo art = db.Query<Articulo>(sql, new { Clave = txtConcepto.Text.Trim() }).FirstOrDefault();

                if (art == null)
                {
                    MessageBox.Show("Esa clave no existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    sql = Queries.ImpuestoSelect();
                    imp = db.Query<Impuesto>(sql, new { ImpuestoId = art.ImpuestoId }).FirstOrDefault();

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


                string serie = "";
                string des = "";

                des = art.Descripcion.Trim();

                sql = Queries.SerieDefault();
                SerieDoc serDefa = db.Query<SerieDoc>(sql, new { EmisorId = _emisorId, Tipo = "FAC" }).FirstOrDefault();

                if (serDefa != null)
                {
                    serie = serDefa.Serie;
                }



                decimal descuento = 0;//Math.Round(art.Precio1 * spnDescuento.Value / 100, 2);
                decimal PrecioNeto = art.Precio1 - descuento;
                decimal iva = Math.Round(PrecioNeto * (decimal)spnCantidad.Value * tasaIVA / 100, 2);

                _notaArticulos.Add(new VentaDetalle
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
                txtRFC.Text = "XAXX010101000";
                txtRazonSocial.Text = "PUBLICO EN GENERAL";
                txtCveUSO.Text = "S01";
                txtDescripcionUSO.Text = "Sin efectos fiscales";
                txtCveMEP.Text = "PUE";
                txtDescripcionMEP.Text = "Pago en una sola exhibición";

                txtCveUSO.Enabled = false;
                cmdBuscarCveUSO.Enabled = false;
                return;
            }

            txtCveUSO.Enabled = true;
            cmdBuscarCveUSO.Enabled = true;

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


        private async Task GuardaNota(bool timbrar)
        {
            if (_notaArticulos.Count == 0)
            {
                MessageBox.Show("No hay artículos en la nota", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            using (FbConnection db = General.GetDB()) 
            { 
                await db.OpenAsync();
                using (FbTransaction transaction = db.BeginTransaction())
                {
                    try
                    {

                        long sucursalId = 0;
                        await UtilsInv.VentaBorraDetalle(_notaId, db,transaction);
                        long notaDeCreditoconceptoId = UtilsInv.GetConceptoInternoId("E", "NOTA DE CREDITO");

                        if (_esAlta == false && _esPDV)
                        {
                            await UtilsInv.DevuelveDetalleOriginal(_detalleOriginal.ToList(), _almacenOriginalId, true, db, transaction);
                            await UtilsInv.VentaBorraMovimientos(_notaId,db,transaction);

                        }

                        string serie = "";
                        int folio = 0;
                        Emisor emi = new Emisor();
                        string sql = string.Empty;

                        Venta nota = new Venta();



                        if (_esAlta)
                        {

                            if (_esPDV)
                            {
                                sql = Queries.AlmacenSelect();
                                Almacen alma = db.Query<Almacen>(sql, new { AlmacenId = _almacenId },transaction).FirstOrDefault();


                                serie = alma.SerieNC;
                                folio = alma.FolioNC;
                                sql = Queries.AlmacenIncrementaFolioNC;
                                db.Execute(sql, new { AlmacenId = _almacenId },transaction);

                            }
                            else
                            {
                                sucursalId = Properties.Settings.Default.SucursalId;
                                sql = Queries.SucursalSelect();
                                Sucursal suc = db.Query<Sucursal>(sql, new { SucursalId = sucursalId },transaction).FirstOrDefault();

                                if (suc == null)
                                {
                                    MessageBox.Show("No existe información de serie, folio para ingresos de la sucursal", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }



                                serie = suc.SerieNC;
                                folio = suc.FolioNC == 0 ? 1 : suc.FolioNC;


                                if (suc.FolioNC == 0)
                                {
                                    sql = Queries.SucursalSetSiguienteFolioNC;
                                    db.Execute(sql, new { SucursalId = sucursalId },transaction);
                                }

                                sql = Queries.SucursalSetSiguienteFolioNC;
                                db.Execute(sql, new { SucursalId = sucursalId },transaction);


                            }

                        }


                        sql = Queries.EmisorSelect();
                        emi = db.Query<Emisor>(sql, new { EmisorId = _emisorId },transaction).FirstOrDefault();


                        if (_esAlta == false)
                        {
                            nota = _notaOriginal;
                        }

                        nota.EmisorId = _emisorId;
                        nota.AlmacenId = _almacenId;
                        nota.LugarExpedicion = emi.CP;

                        if (_esAlta)
                        {
                            nota.Tipo = "NDC";
                            nota.TipoComprobante = "E";
                            nota.Serie = serie;
                            nota.Folio = folio;
                            nota.SerieFac = serie;
                            nota.FolioFac = folio;
                            nota.Moneda = "MXN";
                            nota.TipoCambio = 1;
                            nota.SucursalId = Properties.Settings.Default.SucursalId;
                            nota.DoctorId = 0;
                            nota.RetISR = 0;
                            nota.RetIVA = 0;
                            nota.Descuento = 0;
                            nota.Acuse = "";

                        }

                        nota.ClienteId = _razonSocialId;
                        nota.Fecha = dtpFecha.Value;
                        nota.FechaFac = dtpFecha.Value;
                        nota.FormaPago = txtCveFOP.Text.Trim();
                        nota.MetodoPago = txtCveMEP.Text.Trim();
                        nota.Uso = txtCveUSO.Text.Trim();
                        nota.Subtotal = txtSubTotal.DecimalValue;
                        nota.IVA = txtIVA.DecimalValue;
                        nota.Total = txtTotal.DecimalValue;
                        nota.Observaciones = txtObservaciones.Text.Trim();
                        nota.WebId = General.RandomString(5);
                        nota.CveRel = txtCveRel.Text.Trim();
                        nota.UIDRel = txtUIDRel.Text.Trim();
                        nota.VentaIdRel = _ventaIdRel;
                        nota.xml = "";


                        if (_esAlta)
                        {
                            sql = Queries.VentaInsert;
                            _notaId = db.ExecuteScalar<int>(sql, nota, transaction);
                            nota.VentaId = _notaId;
                        }
                        else
                        {
                            nota.VentaId = _notaId;
                            sql = Queries.VentaUpdate;
                            db.Execute(sql, nota, transaction);
                        }



                        sucursalId = Properties.Settings.Default.SucursalId;
                        foreach (VentaDetalle det in _notaArticulos)
                        {
                            sql = Queries.VentaDetalleInsert;
                            det.VentaId = _notaId;
                            long detalleId = await db.ExecuteScalarAsync<long>(sql, det, transaction);

                            await UtilsInv.RegistrarEntradaPorNCAsync
                                (det.ArticuloId, sucursalId, _almacenId, _notaId, detalleId, nota.Fecha, det.Cantidad, db, transaction);


                            if (_esPDV)
                            {
                                sql = Queries.DocumentoMovimientoInsert;


                                ArticuloMovimiento documentoMovimiento = new ArticuloMovimiento
                                {
                                    DocumentoId = _notaId,
                                    AlmacenId = _almacenId,

                                    ConceptoId = 5,
                                    EsVenta = true,
                                    Tipo = "NDC",
                                    Fecha = dtpFecha.Value,
                                    ArticuloId = det.ArticuloId,
                                    Cantidad = det.Cantidad,
                                    Importe = det.Precio
                                };
                                db.Execute(sql, documentoMovimiento,transaction);
                            }
                        }


                        if (_esPDV)
                        {
                            await ActualizaExistencias(db,transaction);
                            await UtilsInv.VentaReconstruyeCapasDeCostos(_almacenId, _notaArticulos.ToList(), db, transaction);

                            if (_esAlta == false)
                            {
                                await UtilsInv.VentaReconstruyeCapasDeCostos(_almacenId, _detalleOriginal.ToList(), db, transaction);
                            }
                        }


                        if (timbrar)
                        {
                            int res = await ManejaCFDIs.GeneraNotaDeCredito(nota, db, transaction);
                            if (res != 0)
                            {
                                throw new Exception($"Error al timbrar la nota {res}");
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error al guardar la nota: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }




        }




        private async Task ActualizaExistencias(FbConnection db, FbTransaction transaction)
        {
            ArticuloExistencia articuloExistencia = new ArticuloExistencia();        

            foreach (var Renglon in _notaArticulos)
            {
                string sql = Queries.ArticuloExistenciaSelect;
                articuloExistencia = db.Query<ArticuloExistencia>(sql, new { Renglon.ArticuloId, AlmacenId = _almacenId },transaction).FirstOrDefault();

                if (articuloExistencia == null)
                {
                    articuloExistencia = new ArticuloExistencia
                    {
                        ArticuloId = Renglon.ArticuloId,
                        AlmacenId = _almacenId,
                        Entradas = Renglon.Cantidad,
                        Salidas = 0
                    };
                    sql = Queries.ArticuloExistenciaInsert;
                    await db.ExecuteAsync(sql, articuloExistencia,transaction);
                }
                else
                {
                    articuloExistencia.Entradas = articuloExistencia.Entradas + Renglon.Cantidad;
                    sql = Queries.ArticuloExistenciaUpdate;
                    await db.ExecuteAsync(sql, articuloExistencia,transaction);
                }

            }



            

        }



        private async void cmdGuardar_Click(object sender, EventArgs e)
        {
            await GuardaNota(false);
            Close();
        }

        private void cmdClienteAgregar_Click(object sender, EventArgs e)
        {
            ClienteAltasCambios(true);

        }
        private void ClienteAltasCambios(bool esAlta)
        {
            int razId = _esAlta ? 0 :(int) _razonSocialId;
            RazSocAltasCambios razSocAltasCambios = new RazSocAltasCambios(esAlta, razId);
            razSocAltasCambios.ShowDialog();
            if (razSocAltasCambios.RazonId != 0)
            {
                _razonSocialId = razSocAltasCambios.RazonId;
                CargaDatosRazonSocial();
            }

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

        private void cmdBuscarCveRel_Click(object sender, EventArgs e)
        {
            General.BotonBuscarClaveSAT("REL", ref txtCveRel, ref txtDescripcionREL);

        }

        private void txtCveRel_Validated(object sender, EventArgs e)
        {
            General.ClaveSATValidar("REL", ref txtCveRel, ref txtDescripcionREL);

        }

        private void cmdBuscaFacturaRel_Click(object sender, EventArgs e)
        {
            FacturaBuscar facturaBuscar = new FacturaBuscar(_emisorId, _almacenId);
            facturaBuscar.ShowDialog();
            if (facturaBuscar.FacturaId != 0)
            {
                _ventaIdRel = facturaBuscar.FacturaId;
                BuscaFacturaRelacionada();
            }
        }

        private void cmdBuscarCveFOP_Click(object sender, EventArgs e)
        {
            General.BotonBuscarClaveSAT("FOP", ref txtCveFOP, ref txtDescripcionFOP);

        }

        private void cmdBuscarCveMEP_Click(object sender, EventArgs e)
        {
            General.BotonBuscarClaveSAT("MEP", ref txtCveMEP, ref txtDescripcionMEP);

        }

        private void cmdBuscarCveUSO_Click(object sender, EventArgs e)
        {
            General.BotonBuscarClaveSAT("USO", ref txtCveUSO, ref txtDescripcionUSO);

        }

        private void txtCveFOP_Validated(object sender, EventArgs e)
        {
            General.ClaveSATValidar("FOP", ref txtCveFOP, ref txtDescripcionFOP);

        }

        private void txtCveMEP_Validated(object sender, EventArgs e)
        {
            General.ClaveSATValidar("MEP", ref txtCveMEP, ref txtDescripcionMEP);

        }

        private void txtCveUSO_Validated(object sender, EventArgs e)
        {
            General.ClaveSATValidar("USO", ref txtCveUSO, ref txtDescripcionUSO);

        }

        private async void cmdTimbrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de timbrar la nota?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            Splasher splasher = new Splasher("Timbrando la nota");
            splasher.Show();
            await GuardaNota(true);
            splasher.Close();
            MessageBox.Show("Proceso concluído", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();


        }

        private void cmdPublico_Click(object sender, EventArgs e)
        {
            _razonSocialId = 0;
            CargaDatosRazonSocial();
        }
    }

}
