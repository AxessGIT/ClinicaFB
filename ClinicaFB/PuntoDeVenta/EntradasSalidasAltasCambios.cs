using ClinicaFB.Helpers;
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
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFB.PuntoDeVenta
{
    public partial class EntradasSalidasAltasCambios : Form
    {
        private string _tipo = string.Empty;
        private bool _esAlta = false;
        private long _almacenId=0;
        private long _docId = 0;

        private BindingList<ConceptoMovInv> _conceptos = new BindingList<ConceptoMovInv>();
        private BindingList<DocumentoDetalle> _entradaSalidaArticulos = new BindingList<DocumentoDetalle>();
        private List<DocumentoDetalle> _detalleOriginal = new List<DocumentoDetalle>();



        public EntradasSalidasAltasCambios()
        {
            InitializeComponent();
        }
        public EntradasSalidasAltasCambios(string tipo, bool esAlta, long almacenId, long docId)
        {
            InitializeComponent();
            _tipo = tipo;
            _esAlta = esAlta;
            _docId = docId;
            _almacenId = almacenId;

        }
        private async void EntradasSalidasAltasCambios_Load(object sender, EventArgs e)
        {
            Text = _tipo == "E" ? (_esAlta ? "Alta de Entrada" : "Cambio de Entrada") : (_esAlta ? "Alta de Salida" : "Cambio de Salida");
            CargaTipos();
            SetGrid();

            if (!_esAlta)
            {
                CargaEntradaSalida();
                CargaDetalle();
                _detalleOriginal = UtilsInv.GetDetalleOriginal(_entradaSalidaArticulos.ToList());
                cboConceptos.Enabled = false;   
                CalculaTotales();

                long conceptoId = cboConceptos.SelectedValue != null ? (long)cboConceptos.SelectedValue : 0;

                if (_tipo == "E")
                {
                    bool capasUtilizadas = await UtilsInv.DocumentoCapasUtilizadas(conceptoId, _docId);

                    if (capasUtilizadas)
                    {
                        MessageBox.Show("No se puede borrar el documento porque ya se han utilizado capas de costos generadas por la misma.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }



            }
        }

        private void DesHabilitaControles()
        {
            dtpFecha.Enabled = false;
            txtObservaciones.ReadOnly = true;
            cboConceptos.Enabled = false;
            txtConcepto.ReadOnly = true;
            spnCantidad.Enabled = false;
            cmdBorrar.Enabled = false;
            cmdModificar.Enabled = false;
            cmdImportar.Enabled = false;
            cmdGuardar.Enabled = false;
            lblConsumidos.Visible = true;
        }

        private void CargaTipos()
        {


            _conceptos = new BindingList<ConceptoMovInv>(UtilsInv.GetConceptosMovimientosInv(_tipo));

            cboConceptos.DataSource = null;
            cboConceptos.DataSource = _conceptos;
            cboConceptos.ValueMember = "ConMovInvId";
            cboConceptos.DisplayMember = "Descripcion";

            if (_esAlta && _conceptos.Count > 0)
            {
                cboConceptos.SelectedValue = _conceptos[0].ConMovInvId;
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



            grdArticulos.DataSource = _entradaSalidaArticulos;

        }



        private void CargaEntradaSalida()
        {
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.DocumentoSelect;
                Documento entradaSalida = db.Query<Documento>(sql, new { DocumentoId = _docId }).FirstOrDefault();

                if (entradaSalida != null)
                {
                    dtpFecha.Value = entradaSalida.Fecha;
                    txtObservaciones.Text = entradaSalida.Observaciones.Trim();

                    cboConceptos.SelectedValue = entradaSalida.ConceptoId;
                    txtSerie.Text = entradaSalida.Serie;
                    txtFolio.Text = entradaSalida.Folio.ToString();

                }
            }
        }
        private void CargaDetalle()
        {
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.DocumentoDetalleSelect;

                var detalle = new BindingList<DocumentoDetalle>(db.Query<DocumentoDetalle>(sql, new { DocumentoId = _docId }).ToList());
                _entradaSalidaArticulos = new BindingList<DocumentoDetalle>(detalle);

                SetGrid();

            }
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
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
                cboConceptos.Enabled = false;


            }



        }

        private void AgregaArticulo()
        {
            if (string.IsNullOrEmpty(txtConcepto.Text))
            {
                return;
            }

            long sucursalId = Properties.Settings.Default.SucursalId;
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.ArticuloSelectxClave();
                Articulo art = db.Query<Articulo>(sql, new { Clave = txtConcepto.Text }).FirstOrDefault();
                if (art == null)
                {
                    MessageBox.Show("Articulo no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                
                sql = Queries.ConceptoSelect;
                long conceptoId = cboConceptos.SelectedValue != null ? (long)cboConceptos.SelectedValue : 0;
                ConceptoMovInv concepto = db.Query<ConceptoMovInv>(sql, new { ConMovInvId = conceptoId }).FirstOrDefault();

                string precioCosto = concepto != null ? concepto.PrecioCosto : "C";
                decimal valorUnitario = art.Precio1;

                if (precioCosto == "C")
                {
                    valorUnitario = UtilsInv.GetUltimoCostoArticulo(_almacenId, art.ArticuloId, dtpFecha.Value);
                }

                //if (_tipo == "S")
                valorUnitario = UtilsInv.ArticuloGetUltimoCostoFromCapas(art.ArticuloId, _almacenId, sucursalId);

                if (valorUnitario == 0)
                    valorUnitario = art.Costo;

                bool nuevo = true;
                DocumentoDetalle renglon = new DocumentoDetalle();
                decimal cantidad = 0;



                foreach (var articulo in _entradaSalidaArticulos)
                {
                    if (articulo.ArticuloId == art.ArticuloId)
                    {
                        nuevo = false;
                        renglon = articulo;
                        cantidad = articulo.Cantidad;

                    }
                }




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




                renglon.ArticuloId = (int)art.ArticuloId;
                renglon.Clave = art.Clave;
                renglon.ArticuloDescripcion = art.Descripcion;
                renglon.Cantidad = cantidad + spnCantidad.Value;
                renglon.Precio = valorUnitario;
                renglon.UDM = art.UDM;
                renglon.TipoIVA = tipoIVA;
                renglon.TasaIVA = tasaIVA;
                renglon.IVA = Math.Round(renglon.Cantidad * renglon.Precio * renglon.TasaIVA / 100, 2);



                if (nuevo)
                {
                    renglon.ExistenciaInicial = 0;
                    _entradaSalidaArticulos.Add(renglon);

                }
                SetGrid();
                CalculaTotales();

            }
        }


        private void CalculaTotales()
        {
            decimal subTotal = 0, IVA = 0;

            foreach (var articulo in _entradaSalidaArticulos)
            {
                subTotal += Math.Round(articulo.Precio * articulo.Cantidad, 2);
                IVA += articulo.IVA;
            }

            txtSubTotal.DecimalValue = subTotal;
            txtIVA.DecimalValue = IVA;
            txtTotal.DecimalValue = subTotal + IVA;


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

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            if (grdArticulos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un artículo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DocumentoDetalleModificar documentoDetalleModificar = new DocumentoDetalleModificar(_entradaSalidaArticulos[grdArticulos.CurrentRow.Index],_tipo);
            documentoDetalleModificar.ShowDialog();

            if (documentoDetalleModificar._guardar)
            {
                _entradaSalidaArticulos[grdArticulos.CurrentRow.Index] = documentoDetalleModificar._partida;
                SetGrid();
                CalculaTotales();
            }


        }

        private void cmdBorrar_Click(object sender, EventArgs e)
        {
            if (grdArticulos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un artículo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _entradaSalidaArticulos.RemoveAt(grdArticulos.CurrentRow.Index);

            if (_entradaSalidaArticulos.Count == 0 && _esAlta)
            {
                cboConceptos.Enabled = true;
            }
            SetGrid();
            CalculaTotales();

        }

        private async void cmdGuardar_Click(object sender, EventArgs e)
        {
            if (!await Guardar())
                return;
            MessageBox.Show("Movimiento guardado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();

        }

        private async Task<bool> Guardar()
        {
            if (_entradaSalidaArticulos.Count == 0)
            {
                MessageBox.Show("Favor de agregar al menos un artículo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (_tipo == "S")
            {
                foreach (var articulo in _entradaSalidaArticulos)
                {
                    if (articulo.Precio <= 0)
                    {
                        MessageBox.Show($"El artículo no tiene costo unitario {articulo.Clave} - {articulo.ArticuloDescripcion}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }


            string sql = "";
            int folio = 0;
            long conceptoId = cboConceptos.SelectedValue != null ? (long)cboConceptos.SelectedValue : 0;


            using (FbConnection db = General.GetDB())
            {
                await db.OpenAsync();
                using (FbTransaction transaction = db.BeginTransaction())
                {
                    try
                    {

                        if (_esAlta)
                        {
                             sql = Queries.EntradaSalidaFolioMayor;
                            folio = await db.ExecuteScalarAsync<int>(sql, new { TipoCon = _tipo },transaction);
                            

                        }
                        else
                        {
                            bool esEntrada = _tipo == "E";
                            await UtilsInv.DevuelveDetalleOriginal(_detalleOriginal.ToList(), almacenId: _almacenId, esEntrada,db,transaction);
                            await UtilsInv.DocumentoBorraDetalle(_docId,db,transaction);
                            await UtilsInv.DocumentoBorraMovimientosXId(_docId,db,transaction);
                        }

                        folio++;


                        sql = "";
                        Sucursal suc = General.GetDatosSucursal();
                        Documento docto = new Documento();



                        docto.DocumentoId = _docId;
                        docto.ProveedorId = 0;
                        docto.SucursalId = suc.SucursalId;
                        docto.AlmacenId = _almacenId;

                        docto.ConceptoId = conceptoId;

                        docto.Fecha = dtpFecha.Value;
                        docto.Serie = "";
                        docto.Folio = folio;
                        docto.SubTotal = txtSubTotal.DecimalValue;
                        docto.IVA = txtIVA.DecimalValue;
                        docto.Total = txtTotal.DecimalValue;
                        docto.Observaciones = txtObservaciones.Text.Trim();

                        sql = _esAlta ? Queries.DocumentoInsert : Queries.DocumentoUpdate;

                        if (_esAlta)
                            _docId = await db.ExecuteScalarAsync<int>(sql, docto,transaction);
                        else
                        {
                            await db.ExecuteAsync(sql, docto,transaction);
                        }


                        foreach (var detalle in _entradaSalidaArticulos)
                        {

                            sql = Queries.DocumentoDetalleInsert;

                            DocumentoDetalle documentoDetalle = new DocumentoDetalle
                            {
                                DocumentoId = _docId,
                                ArticuloId = detalle.ArticuloId,
                                Cantidad = detalle.Cantidad,
                                Precio = detalle.Precio,
                                IVA = 0,
                                TasaIVA = 0,
                                TipoIVA = 0
                            };
                            long detalleId = await db.ExecuteScalarAsync<long>(sql, documentoDetalle,transaction);

                            sql = Queries.DocumentoMovimientoInsert;
                            ArticuloMovimiento documentoMovimiento = new ArticuloMovimiento
                            {
                                DocumentoId = _docId,
                                AlmacenId = _almacenId,
                                ConceptoId = conceptoId,
                                Tipo = docto.Tipo,
                                Fecha = dtpFecha.Value,
                                ArticuloId = detalle.ArticuloId,
                                Cantidad = detalle.Cantidad,
                                Importe = 0,
                                UltimoCosto = detalle.Precio
                            };

                            await db.ExecuteAsync(sql, documentoMovimiento, transaction);

                            decimal ent = 0;
                            decimal sal = 0;

                            if (_tipo == "E")
                            {
                                ent = detalle.Cantidad;
                            }
                            else
                            {
                                sal = detalle.Cantidad;
                            }
                            await UtilsInv.ActualizaExistencia(detalle.ArticuloId, _almacenId, db,transaction, entradas: ent,salidas:sal);

                            long sucursalId = Properties.Settings.Default.SucursalId;
                    

                        }

                        await UtilsInv.DocumentoReconstruyeCapasDeCostos(_almacenId, _entradaSalidaArticulos.ToList(), db, transaction);


                        if (!_esAlta)
                        {
                            await UtilsInv.DocumentoReconstruyeCapasDeCostos(_almacenId, _detalleOriginal.ToList(), db, transaction);
                        }



                        transaction.Commit();

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error al guardar el movimiento: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            return true;

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


            int ren = 3;
            List<string> codigosNoEncontrados = new List<string>();
            while (oExcel.Cells[ren, 1].Value != null)
            {
                DocumentoDetalle detalle = new DocumentoDetalle();
                detalle.NoIden = Convert.ToString(oExcel.Cells[ren, 1].Value);

                using (FbConnection db = General.GetDB())
                {
                    string sql = Queries.ArticuloSelectxClave();
                    Articulo art = db.Query<Articulo>(sql, new { Clave = detalle.NoIden }).FirstOrDefault();
                    if (art == null)
                    {
                        sql = Queries.ArticuloInsert();
                        art = new Articulo();
                        art.Clave = detalle.NoIden;
                        art.CodigoBarras = detalle.NoIden;
                        art.UDM = "PIEZA";
                        art.Descripcion = Convert.ToString(oExcel.Cells[ren, 2].Value);
                        art.Moneda = "MXN";
                        art.Costo = (decimal)oExcel.Cells[ren, 4].Value;
                        art.CveProSer = "51241200";
                        art.CveUni = "H87";
                        art.Tipo = 0;
                        art.ImpuestoId = 1;
                        long nuevoArticuloId = db.ExecuteScalar<long>(sql, art);
                        art.ArticuloId = nuevoArticuloId;                 

                    }
                    detalle.ArticuloId = (int)art.ArticuloId;
                }
                detalle.Clave = detalle.NoIden;
                detalle.ArticuloDescripcion = oExcel.Cells[ren, 2].Value;
                detalle.Cantidad = (decimal)oExcel.Cells[ren, 3].Value;
                detalle.Precio = (decimal)oExcel.Cells[ren, 4].Value;

                _entradaSalidaArticulos.Add(detalle);
                ren++;
            }
            /*if (codigosNoEncontrados.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Los siguientes códigos no fueron encontrados:");
                foreach (var codigo in codigosNoEncontrados)
                {
                    sb.AppendLine(codigo);
                }
                MessageBox.Show(sb.ToString(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }*/
            oExcel.Quit();
            SetGrid();
            CalculaTotales();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
