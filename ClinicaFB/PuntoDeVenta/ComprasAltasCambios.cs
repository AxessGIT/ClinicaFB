using ClinicaFB.Helpers;
using ClinicaFB.Modelo;
using Dapper;
using FirebirdSql.Data.FirebirdClient;
using Syncfusion.Data.Extensions;
using Syncfusion.Windows.Forms.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ClinicaFB.PuntoDeVenta
{
    public partial class ComprasAltasCambios : Form
    {
        private bool _esAlta = false;
        private long _compraId = 0;
        private long _proveedorId = 0;
        private long _articuloId = 0;
        private decimal _tasaIVA = 0;
        private int _tipoIVA = 0;
        private long _almacenId = 0;

        private BindingList<Almacen> _almacenes = new BindingList<Almacen>();

        private BindingList<DocumentoDetalle> _compraArticulos = new BindingList<DocumentoDetalle>();
        private List<DocumentoDetalle> _detalleOriginal = new List<DocumentoDetalle>();
        private long _conceptoCompraId;

        public ComprasAltasCambios(bool esAlta, long compraId, long almacenId)
        {
            InitializeComponent();
            _esAlta = esAlta;
            _compraId = compraId;
            _almacenId = almacenId;
        }

        private async void ComprasAltasCambios_Load(object sender, EventArgs e)
        {
            CargaAlmacen();
            _conceptoCompraId = UtilsInv.GetConceptoInternoId("E", "COMPRA");

            if (_esAlta)
            {
                BuscaProveedor();
                dtpFecha.Value = DateTime.Today;
                spnFolio.Value = 0;
            }
            else
            {


                CargaCompra();
                CargaDetalle();
                _detalleOriginal = UtilsInv.GetDetalleOriginal(_compraArticulos.ToList());

            }
            grdArticulos.EditingControlShowing += grdArticulos_EditingControlShowing;
            ActiveControl = txtConcepto;
            SetGrid();
        }


        private void InhabilitaControles()
        {
            txtProveedorNombre.Enabled = false;
            txtProveedorRFC.Enabled = false;
            cmdAgregarProveedor.Enabled = false;
            cmdProveedorBuscar.Enabled = false;
            dtpFecha.Enabled = false;
            txtSerie.Enabled = false;
            spnFolio.Enabled = false;
            txtConcepto.Enabled = false;
            txtDescripcion.Enabled = false;
            txtCosto.Enabled = false;
            txtCantidad.Enabled = false;
            cmdGuardar.Enabled = false;
            cmdAgregar.Enabled = false;
            cmdBorrar.Enabled = false;
            cmdModificar.Enabled = false;
            cmdCFDiCargar.Enabled = false;
            lblConsumidos.Visible = true;
        }


        private void CargaAlmacen()
        {
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.AlmacenSelect();
                Almacen al = db.QueryFirstOrDefault<Almacen>(sql, new { AlmacenId = _almacenId });
                if (al != null)
                {
                    txtAlmacenNombre.Text = al.Nombre;
                }
            }
        }


        private void CargaProveedor()
        {
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.ProveedorSelect;
                Proveedor proveedor = db.Query<Proveedor>(sql, new { ProveedorId = _proveedorId }).FirstOrDefault();
                if (proveedor != null)
                {
                    txtProveedorRFC.Text = proveedor.RFC;
                    txtProveedorNombre.Text = proveedor.Nombre;
                }
            }
        }
        private void BuscaProveedor()
        {
            ProveedoresBuscar proveedoresBuscar = new ProveedoresBuscar();
            proveedoresBuscar.ShowDialog();
            if (proveedoresBuscar.ProveedorId > 0)
            {
                _proveedorId = proveedoresBuscar.ProveedorId;
                CargaProveedor();

            }
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtConcepto_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    break;

                case Keys.F5:
                    ArticulosBuscar articulosBuscar = new ArticulosBuscar(txtConcepto.Text.Trim());
                    articulosBuscar.ShowDialog();

                    if (articulosBuscar.ArticuloId != 0)
                    {
                        _articuloId = articulosBuscar.ArticuloId;
                        BuscaArticulo(false, articulosBuscar.ArticuloId);
                    }
                    break;
                case Keys.Enter:
                case Keys.Tab:
                    BuscaArticulo(true);
                    break;
            }
        }


        private void BuscaArticulo(bool porClave, int articuloId = 0)
        {
            if (string.IsNullOrEmpty(txtConcepto.Text) && porClave)
            {
                return;
            }
            using (FbConnection db = General.GetDB())
            {
                string sql = porClave ? Queries.ArticuloSelectxClave() : Queries.ArticuloSelect();
                Articulo art =
                    porClave ?
                    db.Query<Articulo>(sql, new { Clave = txtConcepto.Text.Trim() }).FirstOrDefault() :
                    db.Query<Articulo>(sql, new { ArticuloId = articuloId }).FirstOrDefault();

                if (art == null)
                {
                    MessageBox.Show("Esa clave no existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;

                }


                _articuloId = (int)art.ArticuloId;
                txtConcepto.Text = art.Clave;
                txtDescripcion.Text = art.Descripcion;
                Impuesto imp = new Impuesto();

                decimal tasaIVA = 0;
                int tipoIVA = 0;

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





                txtDescripcion.Text = art.Descripcion;
                txtCosto.DecimalValue = art.Costo;
                txtCantidad.Value = 1;
                _articuloId = (int)art.ArticuloId;
                _tasaIVA = tasaIVA;
                _tipoIVA = tipoIVA;
                ActiveControl = txtCantidad;

            }


        }
        private void SetGrid()
        {
            grdArticulos.DataSource = null;



            grdArticulos.AllowUserToAddRows = false;
            grdArticulos.AllowUserToDeleteRows = false;



            grdArticulos.AutoGenerateColumns = false;
            grdArticulos.ReadOnly = false;
            grdArticulos.AllowUserToResizeColumns = false;
            grdArticulos.AllowUserToResizeRows = false;



            grdArticulos.ColumnHeadersDefaultCellStyle.Font = new Font(grdArticulos.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            grdArticulos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;



            grdArticulos.DataSource = _compraArticulos;

        }


        private void grdArticulos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // Obtener la columna actual
            DataGridViewColumn col = grdArticulos.Columns[grdArticulos.CurrentCell.ColumnIndex];

            if (e.Control is TextBox textBox)
            {
                // Solo "colClave" es totalmente editable
                if (col.Name == "colClave")
                {
                    textBox.ReadOnly = false;
                    textBox.BackColor = Color.White;
                }
                // "colClaveProveedor" es seleccionable pero no editable
                else if (col.Name == "colClaveProveedor")
                {
                    textBox.ReadOnly = true;
                    textBox.BackColor = Color.FromArgb(245, 245, 220); // Color diferente para distinguir
                }
                // Todas las demás columnas también son solo lectura
                else
                {
                    textBox.ReadOnly = true;
                    textBox.BackColor = Color.FromArgb(240, 240, 240);
                }
            }
        }


        private void CalculaTotales()
        {
            decimal subTotal = 0, IVA = 0;

            foreach (var articulo in _compraArticulos)
            {
                subTotal += Math.Round(articulo.Precio * articulo.Cantidad, 2);
                IVA += articulo.IVA;
            }

            txtSubTotal.DecimalValue = subTotal;
            txtIVA.DecimalValue = IVA;
            txtTotal.DecimalValue = subTotal + IVA;


        }

        private void CargaCompra()
        {
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.DocumentoSelect;
                Documento compra = db.Query<Documento>(sql, new { DocumentoId = _compraId }).FirstOrDefault();

                if (compra != null)
                {

                    _proveedorId = compra.ProveedorId;
                    CargaProveedor();

                    dtpFecha.Value = compra.Fecha;
                    txtSerie.Text = compra.Serie;
                    spnFolio.Value = compra.Folio;
                }

                if (compra.Cancelado)
                {
                    InhabilitaControles();
                    lblCancelada.Visible = true;
                }
            }
        }
        private void CargaDetalle()
        {
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.DocumentoDetalleSelect;

                var detalle = new BindingList<DocumentoDetalle>(db.Query<DocumentoDetalle>(sql, new { DocumentoId = _compraId }).ToList());
                _compraArticulos = new BindingList<DocumentoDetalle>(detalle);



                SetGrid();
                CalculaTotales();

            }
        }

        private void AgregaArticulo()
        {
            _compraArticulos.Add(new DocumentoDetalle
            {
                ArticuloId = _articuloId,
                Clave = txtConcepto.Text.Trim(),
                ArticuloDescripcion = txtDescripcion.Text.Trim(),
                UDM = "PZA",
                Precio = txtCosto.DecimalValue,
                Cantidad = (decimal)txtCantidad.Value,
                TipoIVA = _tipoIVA,
                TasaIVA = _tasaIVA,
                IVA = Math.Round(txtCosto.DecimalValue * (decimal)txtCantidad.Value) * _tasaIVA / 100
            });

            SetGrid();
            LimpiaCaptura();
            CalculaTotales();
            txtConcepto.Focus();
        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            if (_articuloId == 0)
            {
                MessageBox.Show("Favor de seleccionar un artículo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtCantidad.Value == 0)
            {
                MessageBox.Show("Favor de indicar la cantidad", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtCosto.DecimalValue == 0)
            {
                MessageBox.Show("Favor de indicar el costo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            AgregaArticulo();

        }

        private void LimpiaCaptura()
        {
            txtConcepto.Text = "";
            txtDescripcion.Text = "";
            txtCosto.DecimalValue = 0;
            txtCantidad.Value = 0;
            _articuloId = 0;
            _tasaIVA = 0;

        }

        private void cmdBorrar_Click(object sender, EventArgs e)
        {
            if (grdArticulos.CurrentRow == null)
            {
                MessageBox.Show("Favor de seleccionar un artículo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _compraArticulos.RemoveAt(grdArticulos.CurrentRow.Index);
            CalculaTotales();
            SetGrid();

        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            if (grdArticulos.CurrentRow == null)
            {
                MessageBox.Show("Favor de seleccionar un artículo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DocumentoDetalle detalle = _compraArticulos[grdArticulos.CurrentRow.Index];
            DocumentoDetalleModificar compraDetalleModificar = new DocumentoDetalleModificar(detalle);
            compraDetalleModificar.ShowDialog();

            if (compraDetalleModificar._guardar)
            {
                _compraArticulos[grdArticulos.CurrentRow.Index] = compraDetalleModificar._partida;
                SetGrid();
                CalculaTotales();
            }

        }

        private async void cmdGuardar_Click(object sender, EventArgs e)
        {
            cmdGuardar.Enabled = false;
            cmdSalir.Enabled = false;
            if (!await Guardar())
                return;
            MessageBox.Show("Compra guardada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();

        }








        private async Task<bool> Guardar()
        {
            if (_compraArticulos.Count == 0)
            {
                MessageBox.Show("Favor de agregar al menos un artículo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (_proveedorId == 0 && string.IsNullOrEmpty(txtProveedorRFC.Text.Trim()))
            {
                MessageBox.Show("Favor de seleccionar un proveedor", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (spnFolio.Value == 0)
            {
                MessageBox.Show("Indique el folio de la factura", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            foreach (var detalle in _compraArticulos)
            {
                if (detalle.ArticuloId == 0)
                {
                    MessageBox.Show("Indique las claves de todos los artículos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            // Mostrar controles de progreso
            lblGuardar.Visible = true;
            pgGuardar.Visible = true;
            pgGuardar.Value = 0;
            pgGuardar.Maximum = 100;
            Application.DoEvents();

            using (FbConnection db = General.GetDB())
            {

                await db.OpenAsync();
                lblGuardar.Text = "Conectando a la base de datos...";
                pgGuardar.Value = 5;
                Application.DoEvents();

                using (FbTransaction transaction = db.BeginTransaction())
                {
                    try
                    {
                        if (!_esAlta)
                        {
                            lblGuardar.Text = "Eliminando detalle anterior...";
                            pgGuardar.Value = 10;
                            Application.DoEvents();
                            
                            await UtilsInv.DevuelveDetalleOriginal(_detalleOriginal.ToList(), _almacenId, true,db,transaction);
                            await UtilsInv.DocumentoBorraDetalle(_compraId,db,transaction);
                            await UtilsInv.DocumentoBorraMovimientosXId(_compraId,db,transaction);
                        }

                        lblGuardar.Text = "Validando proveedor...";
                        pgGuardar.Value = 20;
                        Application.DoEvents();

                        string sql = "";

                        if (_proveedorId == 0)
                        {
                            sql = Queries.ProveedorInsert;
                            Proveedor proveedor = new Proveedor();
                            proveedor.RFC = txtProveedorRFC.Text.Trim();
                            proveedor.Nombre = txtProveedorNombre.Text.Trim();
                            _proveedorId = await db.ExecuteScalarAsync<int>(sql, proveedor,transaction);
                        }
                        
                        lblGuardar.Text = "Guardando documento de compra...";
                        pgGuardar.Value = 25;
                        Application.DoEvents();
                        
                        Documento documentoCompra = new Documento();
                        documentoCompra.SucursalId = Properties.Settings.Default.SucursalId;
                        documentoCompra.DocumentoId = _compraId;
                        documentoCompra.ProveedorId = _proveedorId;
                        documentoCompra.AlmacenId = _almacenId;
                        documentoCompra.ConceptoId = _conceptoCompraId;
                        documentoCompra.Tipo = "COM";
                        documentoCompra.Fecha = dtpFecha.Value;
                        documentoCompra.Serie = txtSerie.Text;
                        documentoCompra.Folio = (int)spnFolio.Value;
                        documentoCompra.SubTotal = txtSubTotal.DecimalValue;
                        documentoCompra.IVA = txtIVA.DecimalValue;
                        documentoCompra.Total = txtTotal.DecimalValue;

                        sql = _esAlta ? Queries.DocumentoInsert : Queries.DocumentoUpdate;

                        if (_esAlta)
                            _compraId = await db.ExecuteScalarAsync<int>(sql, documentoCompra,transaction);
                        else
                        {
                            await db.ExecuteAsync(sql, documentoCompra, transaction);
                        }

                        pgGuardar.Value = 30;
                        Application.DoEvents();

                        int articuloIndex = 0;
                        int totalArticulos = _compraArticulos.Count;
                        int progresoArticulos = 40; // Progreso disponible para los artículos (del 30 al 70)

                        foreach (var detalle in _compraArticulos)
                        {
                            articuloIndex++;
                            lblGuardar.Text = $"Procesando artículo {articuloIndex} de {totalArticulos}...";
                            pgGuardar.Value = 30 + (progresoArticulos * articuloIndex / totalArticulos);
                            Application.DoEvents();
                            
                            sql = Queries.DocumentoDetalleInsert;

                            detalle.DocumentoId = _compraId;

                            long detalleId = await db.ExecuteScalarAsync<long>(sql, detalle, transaction);


                            if (string.IsNullOrEmpty(detalle.ClaveProve) == false)
                            {
                                sql = Queries.ArticuloClaveDeleteXCveProv;
                                await db.ExecuteAsync(sql, new { ProveedorId = _proveedorId, ClaveProveedor = detalle.ClaveProve }, transaction);

                                sql = Queries.ArticuloClaveInsert;
                                ArticuloClave articuloClave = new ArticuloClave
                                {
                                    ArticuloId = detalle.ArticuloId,
                                    ProveedorId = _proveedorId,
                                    ClaveProveedor = detalle.ClaveProve
                                };
                                await db.ExecuteAsync(sql, articuloClave, transaction);
                            }

                            sql = Queries.DocumentoMovimientoInsert;
                            ArticuloMovimiento documentoMovimiento = new ArticuloMovimiento
                            {
                                DocumentoId = _compraId,
                                AlmacenId = _almacenId,
                                EsVenta = false,
                                ConceptoId = _conceptoCompraId,
                                Tipo = "COM",
                                Fecha = dtpFecha.Value,
                                ArticuloId = detalle.ArticuloId,
                                Cantidad = detalle.Cantidad,
                                Importe = detalle.Precio,
                                UltimoCosto = detalle.Precio
                            };
                            await db.ExecuteAsync(sql, documentoMovimiento, transaction);


                            await UtilsInv.ActualizaExistencia(detalle.ArticuloId, _almacenId, db, transaction, entradas: detalle.Cantidad);

                            if (detalle.Precio > 1)
                                await UtilsInv.ArticuloActualizaFechaYCostoUltimaCompra(detalle.ArticuloId, dtpFecha.Value,db,transaction, detalle.Precio);

                        }

                        lblGuardar.Text = "Reconstruyendo capas de costos...";
                        pgGuardar.Value = 80;
                        Application.DoEvents();
                        
                        await UtilsInv.DocumentoReconstruyeCapasDeCostos(_almacenId, _compraArticulos.ToList(), db, transaction);

                        if (!_esAlta)
                        {
                            await UtilsInv.DocumentoReconstruyeCapasDeCostos(_almacenId, _detalleOriginal.ToList(), db, transaction);
                        }

                        lblGuardar.Text = "Confirmando transacción...";
                        pgGuardar.Value = 95;
                        Application.DoEvents();

                        transaction.Commit();
                        
                        pgGuardar.Value = 100;
                        lblGuardar.Text = "Compra guardada exitosamente";
                        Application.DoEvents();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        lblGuardar.Visible = false;
                        pgGuardar.Visible = false;
                        MessageBox.Show("Error al guardar la compra: " + ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    finally
                    {
                        lblGuardar.Visible = false;
                        pgGuardar.Visible = false;
                    }


                }
            }

            return true;

        }


        private void cmdCFDiCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos XML|*.xml";
            openFileDialog.Title = "Selecciona el archivo XML del CFDi";
            openFileDialog.ShowDialog();
            string archivoXML = openFileDialog.FileName;
            if (string.IsNullOrEmpty(archivoXML))
            {
                return;
            }
            XmlDocument xml = new XmlDocument();
            try
            {
                xml.Load(archivoXML);

            }
            catch (Exception err)
            {

                MessageBox.Show("Error al cargar el archivo XML: " + err.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            XmlNamespaceManager namespaces = new XmlNamespaceManager(xml.NameTable);
            namespaces.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/4");


            XmlNode comprobante = xml.SelectSingleNode("cfdi:Comprobante", namespaces);

            if (comprobante == null)
            {
                MessageBox.Show("No es un archivo XML de CFDi válido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            XmlNode conceptos = comprobante.SelectSingleNode("cfdi:Conceptos", namespaces);
            if (conceptos == null)
            {
                MessageBox.Show("No es un archivo XML de CFDi válido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string serie = "";
            if (comprobante.Attributes["Serie"] != null)
            {
                serie = comprobante.Attributes["Serie"].Value;
            }

            string folioCompleto = comprobante.Attributes["Folio"].Value;
            string folio = folioCompleto.Length > 4 ? folioCompleto.Substring(folioCompleto.Length - 4) : folioCompleto;

            txtSerie.Text = serie;

            spnFolio.Value = int.Parse(folio);

            string sql = Queries.ProveedorSelectXRFC;

            XmlNode emisor = comprobante.SelectSingleNode("cfdi:Emisor", namespaces);
            if (emisor == null)
            {
                MessageBox.Show("No es un archivo XML de CFDi válido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string rfcEmisor = emisor.Attributes["Rfc"].Value;
            string nombre = emisor.Attributes["Nombre"].Value;


            _proveedorId = 0;

            using (FbConnection db = General.GetDB())
            {
                Proveedor proveedor = db.Query<Proveedor>(sql, new { RFC = rfcEmisor }).FirstOrDefault();
                if (proveedor == null)
                {
                    MessageBox.Show("El proveedor no está registrado\nSe registrará automáticamente en en catálogo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _proveedorId = proveedor.ProveedorId;
                }
            }

            txtProveedorRFC.Text = rfcEmisor;
            txtProveedorNombre.Text = nombre;


            _compraArticulos.Clear();
            foreach (XmlNode concepto in conceptos.ChildNodes)
            {
                string des = "";
                string cveEmp = "";
                long articuloId = 0;
                string clave = concepto.Attributes["NoIdentificacion"].Value;
                articuloId = 0;

                if (!string.IsNullOrEmpty(clave))
                {

                    using (FbConnection db = General.GetDB())
                    {
                        sql = Queries.ArticuloClaveSelectXCveProv;
                        ArticuloClave articuloClave = db.Query<ArticuloClave>(sql, new { ProveedorId = _proveedorId, ClaveProveedor = clave }).FirstOrDefault();

                        if (articuloClave != null)
                        {

                            articuloId = articuloClave.ArticuloId;
                            sql = Queries.ArticuloSelect();
                            Articulo art = db.Query<Articulo>(sql, new { ArticuloId = articuloId }).FirstOrDefault();
                            if (art != null)
                            {
                                cveEmp = art.Clave;
                                des = art.Descripcion;

                            }
                        }
                    }


                }
                string unidad = concepto.Attributes["Unidad"]==null ? "" : concepto.Attributes["Unidad"].Value;
                string descripcion = string.IsNullOrEmpty(des) ? concepto.Attributes["Descripcion"].Value : des;
                decimal cantidad = decimal.Parse(concepto.Attributes["Cantidad"].Value);
                decimal precio = decimal.Parse(concepto.Attributes["ValorUnitario"].Value);
                decimal importe = decimal.Parse(concepto.Attributes["Importe"].Value);
                string claveProdServ = concepto.Attributes["ClaveProdServ"].Value;
                string claveUnidad = concepto.Attributes["ClaveUnidad"].Value;
                XmlNode conceptoImpuestos = concepto.SelectSingleNode("cfdi:Impuestos", namespaces);
                decimal tasaIVA = 0;

                if (conceptoImpuestos != null)
                {
                    tasaIVA = ManejaCFDIs.GetTasaIVA(conceptoImpuestos) * 100;
                }
                _compraArticulos.Add(new DocumentoDetalle
                {
                    ArticuloId = articuloId,
                    ClaveProve = clave,
                    Clave = cveEmp,
                    ArticuloDescripcion = descripcion,
                    UDM = unidad,
                    Cantidad = cantidad,
                    Precio = precio,
                    CveProSer = claveProdServ,
                    Cveuni = claveUnidad,
                    TipoIVA = 1,
                    TasaIVA = tasaIVA,
                    IVA = Math.Round(cantidad * precio * tasaIVA / 100, 2)

                });
            }
            SetGrid();
            CalculaTotales();
        }

        private void grdArticulos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string clave = _compraArticulos[e.RowIndex].Clave; //grdArticulos.Rows[e.RowIndex].Cells["colClave"].Value.ToString();
            if (string.IsNullOrEmpty(clave))
            {
                grdArticulos.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
            }
        }


        private void grdArticulos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string nuevaClave = _compraArticulos[e.RowIndex].Clave;

            if (string.IsNullOrEmpty(nuevaClave))
            {
                return;
            }

            string sql = Queries.ArticuloSelectxClave();
            using (FbConnection db = General.GetDB())
            {
                Articulo art = db.Query<Articulo>(sql, new { Clave = nuevaClave }).FirstOrDefault();
                if (art == null)
                {
                    MessageBox.Show("Esa clave no existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                _compraArticulos[e.RowIndex].ArticuloId = (int)art.ArticuloId;
                _compraArticulos[e.RowIndex].ArticuloDescripcion = art.Descripcion;
                _compraArticulos[e.RowIndex].Clave = nuevaClave;
                SetGrid();
                CalculaTotales();
            }

        }

        private void cmdProveedorBuscar_Click(object sender, EventArgs e)
        {
            BuscaProveedor();
        }

        private void cmdAgregarProveedor_Click(object sender, EventArgs e)
        {
            ProveedorAltasCambios proveedorAltasCambios = new ProveedorAltasCambios(true, 0);
            proveedorAltasCambios.ShowDialog();
            if (proveedorAltasCambios.ProveedorId > 0)
            {
                _proveedorId = proveedorAltasCambios.ProveedorId;
                CargaProveedor();
            }
        }

        private void grdArticulos_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F5)
            {
                string clave = "";
                string des = "";
                if (grdArticulos.CurrentRow == null)
                    return;
                ArticulosBuscar articulosBuscar = new ArticulosBuscar();
                articulosBuscar.ShowDialog();
                if (articulosBuscar.ArticuloId != 0)
                {
                    using (FbConnection db = General.GetDB())
                    {
                        string sql = Queries.ArticuloSelect();
                        Articulo art = db.Query<Articulo>(sql, new { articulosBuscar.ArticuloId }).FirstOrDefault();
                        if (art != null)
                        {
                            clave = art.Clave;
                            des = art.Descripcion;
                        }
                        else
                        {
                            return;
                        }


                    }

                    if (articulosBuscar.ArticuloId != 0)
                        _compraArticulos[grdArticulos.CurrentRow.Index].ArticuloId = articulosBuscar.ArticuloId;

                    if (!string.IsNullOrEmpty(clave))
                        _compraArticulos[grdArticulos.CurrentRow.Index].Clave = clave;
                    if (!string.IsNullOrEmpty(des))
                        _compraArticulos[grdArticulos.CurrentRow.Index].ArticuloDescripcion = des;
                    SetGrid();
                    int ren = grdArticulos.CurrentRow.Index;
                    ren++;
                    if (ren >= grdArticulos.RowCount)
                        ren = grdArticulos.RowCount - 1;

                    grdArticulos.CurrentCell = grdArticulos.Rows[ren].Cells[1];

                }
            }
        }

        private void cmdTempo_Click(object sender, EventArgs e)
        {
            List<Temporal> temporales = new List<Temporal>();
            using (FbConnection db = General.GetDB())
            {
                string sql = "SELECT * FROM TEMPO WHERE ARTICULOID IS NOT NULL";
                temporales = db.Query<Temporal>(sql).ToList();
            }

            foreach (var temp in temporales)
            {
                using (FbConnection db = General.GetDB())
                {

                    string sql = Queries.ArticuloSelect();
                    Articulo art =
                        db.Query<Articulo>(sql, new { temp.ArticuloId }).FirstOrDefault();


                    _articuloId = (int)art.ArticuloId;
                    Impuesto imp = new Impuesto();

                    decimal tasaIVA = 0;
                    int tipoIVA = 0;

                    if (art.ImpuestoId != 0)
                    {
                        sql = Queries.ImpuestoSelect();
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

                    _articuloId = (int)art.ArticuloId;
                    _tasaIVA = tasaIVA;
                    _tipoIVA = tipoIVA;

                    ///


                    _compraArticulos.Add(new DocumentoDetalle
                    {
                        ArticuloId = _articuloId,
                        Clave = art.CodigoBarras,
                        ArticuloDescripcion = art.Descripcion,
                        UDM = "PZA",
                        Precio = temp.ValorUnitario,
                        Cantidad = (decimal)temp.Cantidad,
                        TipoIVA = _tipoIVA,
                        TasaIVA = _tasaIVA,
                        IVA = Math.Round(temp.ValorUnitario * (decimal)temp.Cantidad) * _tasaIVA / 100
                    });





                }
            }
            SetGrid();
            CalculaTotales();
        }
    }
}
 