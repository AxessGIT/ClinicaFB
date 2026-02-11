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

namespace ClinicaFB.PuntoDeVenta
{
    public partial class SalidasAltasCambios : Form
    {
        private long _almacenId = 0;
        private long _almacenOriginalId = 0;
        private long _salidaId = 0;
        private bool _esAlta = false;
        private BindingList<Almacen> _almacenes = new BindingList<Almacen>();
        private BindingList<DocumentoDetalle> _salidaArticulos = new BindingList<DocumentoDetalle>();
        private List<DocumentoDetalle> _detalleOriginal = new List<DocumentoDetalle>();

        public SalidasAltasCambios(bool esAlta, long salidaId)
        {
            InitializeComponent();
            _salidaId = salidaId;
            _esAlta = esAlta;
        }

        private void SalidasAltasCambios_Load(object sender, EventArgs e)
        {

            cboTipos.SelectedIndex = 0;
            SetGrid();

            if (!_esAlta)
            {
                CargaSalida();
                CargaDetalle();
                cboAlmacenes.Enabled = false;
                _detalleOriginal = UtilsInv.GetDetalleOriginal(_salidaArticulos.ToList());


            }
            CargaAlmacenes();

        }


        private void CargaAlmacenes()
        {

            long almacenIdDefa = 0;

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.AlmacenesSelect();

                var res = db.Query<Almacen>(sql).ToList();
                _almacenes = new BindingList<Almacen>(res);

                foreach (var alma in res)
                {
                    if (_esAlta)
                    {
                        if (alma.Defa)
                        {
                            almacenIdDefa = alma.AlmacenId;
                            break;
                        }
                    }
                    else
                    {
                        if (alma.AlmacenId == _almacenOriginalId)
                        {
                            almacenIdDefa = alma.AlmacenId;
                        }
                    }
                }

                cboAlmacenes.DataSource = null;
                cboAlmacenes.DataSource = _almacenes;
                cboAlmacenes.ValueMember = "AlmacenId";
                cboAlmacenes.DisplayMember = "Descripcion";
                cboAlmacenes.SelectedValue = almacenIdDefa;

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



            grdArticulos.DataSource = _salidaArticulos;

        }



        private void CargaSalida()
        {
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.DocumentoSelect;
                Documento salida = db.Query<Documento>(sql, new { DocumentoId = _salidaId }).FirstOrDefault();

                if (salida != null)
                {
                    dtpFecha.Value = salida.Fecha;
                    _almacenOriginalId = salida.AlmacenId;
                    txtObservaciones.Text = salida.Observaciones.Trim();

                    switch (salida.Tipo)
                    {
                        case "CAD":
                            cboTipos.SelectedIndex = 0;
                            break;
                        case "DEV": 
                            cboTipos.SelectedIndex = 1;
                            break;
                        case "AJU":
                            cboTipos.SelectedIndex = 2;
                            break;
                        case "DEP":
                            cboTipos.SelectedIndex = 3;
                            break;
                    }



                }
            }
        }
        private void CargaDetalle()
        {
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.DocumentoDetalleSelect;

                var detalle = new BindingList<DocumentoDetalle>(db.Query<DocumentoDetalle>(sql, new { DocumentoId = _salidaId }).ToList());
                _salidaArticulos = new BindingList<DocumentoDetalle>(detalle);

                SetGrid();

            }
        }



        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void cmdGuardar_Click(object sender, EventArgs e)
        {
            if (!await Guardar())
                return;
            MessageBox.Show("Salida guardada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private async Task<bool> Guardar()
        {
            if (_salidaArticulos.Count == 0)
            {
                MessageBox.Show("Favor de agregar al menos un artículo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            string sql = "";
            int folio = 0;

            _almacenId = (long)cboAlmacenes.SelectedValue;


            using (FbConnection db = General.GetDB())
            {
                await db.OpenAsync();

                using (var transaction = db.BeginTransaction())
                {
                    try
                    {

                        if (_esAlta)
                        {
                            sql = Queries.SalidaFolioMayor;
                            folio = await db.ExecuteScalarAsync<int>(sql);
                        }
                        else
                        {
                            await UtilsInv.DevuelveDetalleOriginal(_detalleOriginal.ToList(), _almacenOriginalId, false, db, transaction);
                            await UtilsInv.DocumentoBorraDetalle(_salidaId, db, transaction);
                            await UtilsInv.DocumentoBorraMovimientosXId(_salidaId, db, transaction);

                        }

                        folio++;

                        sql = "";
                        Documento documentoSalida = new Documento();
                        documentoSalida.DocumentoId = _salidaId;
                        documentoSalida.ProveedorId = 0;
                        documentoSalida.AlmacenId = _almacenId;


                        // "(Tipo = 'DEV'  or Tipo = 'AJU' or Tipo = 'CAD' or Tipo = 'DEP') " +


                        switch (cboTipos.SelectedIndex)
                        {
                            case 0:
                                documentoSalida.Tipo = "CAD";
                                break;
                            case 1:
                                documentoSalida.Tipo = "DEV";
                                break;
                            case 2:
                                documentoSalida.Tipo = "AJU";
                                break;
                            case 3:
                                documentoSalida.Tipo = "DEP";
                                break;
                        }

                        documentoSalida.Fecha = dtpFecha.Value;
                        documentoSalida.Serie = "";
                        documentoSalida.Folio = folio;
                        documentoSalida.SubTotal = 0;
                        documentoSalida.IVA = 0;
                        documentoSalida.Total = 0;
                        documentoSalida.Observaciones = txtObservaciones.Text.Trim();

                        sql = _esAlta ? Queries.DocumentoInsert : Queries.DocumentoUpdate;
                        if (_esAlta)
                            _salidaId = await db.ExecuteScalarAsync<int>(sql, documentoSalida, transaction);
                        else
                        {
                            await db.ExecuteAsync(sql, documentoSalida, transaction);
                        }


                        foreach (var detalle in _salidaArticulos)
                        {

                            sql = Queries.DocumentoDetalleInsert;

                            DocumentoDetalle documentoDetalle = new DocumentoDetalle();
                            documentoDetalle.DocumentoId = _salidaId;
                            documentoDetalle.ArticuloId = detalle.ArticuloId;
                            documentoDetalle.Cantidad = detalle.Cantidad;
                            documentoDetalle.Precio = 0;
                            documentoDetalle.IVA = 0;
                            documentoDetalle.TasaIVA = 0;
                            documentoDetalle.TipoIVA = 0;
                            await db.ExecuteAsync(sql, documentoDetalle);

                            sql = Queries.DocumentoMovimientoInsert;

                            ArticuloMovimiento documentoMovimiento = new ArticuloMovimiento();
                            documentoMovimiento.DocumentoId = _salidaId;
                            documentoMovimiento.AlmacenId = _almacenId;
                            documentoMovimiento.Tipo = documentoSalida.Tipo;
                            documentoMovimiento.Fecha = dtpFecha.Value;
                            documentoMovimiento.ArticuloId = detalle.ArticuloId;
                            documentoMovimiento.Cantidad = detalle.Cantidad;
                            documentoMovimiento.Importe = 0;
                            await db.ExecuteAsync(sql, documentoMovimiento);


                            await UtilsInv.ActualizaExistencia(detalle.ArticuloId, _almacenId,db,transaction, salidas: detalle.Cantidad);


                        }
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error al guardar la salida: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;



                    }
                    return true;

                }
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
                            Articulo art = db.Query<Articulo>(sql, new { articulosBuscar.ArticuloId }).FirstOrDefault();
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
            if (string.IsNullOrEmpty(txtConcepto.Text))
            {
                return;
            }
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.ArticuloSelectxClave();
                Articulo art = db.Query<Articulo>(sql, new { Clave = txtConcepto.Text }).FirstOrDefault();
                if (art == null)
                {
                    MessageBox.Show("Articulo no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool nuevo = true;
                DocumentoDetalle renglon = new DocumentoDetalle();
                decimal cantidad = 0;

                foreach (var articulo in _salidaArticulos)
                {
                    if (articulo.ArticuloId == art.ArticuloId)
                    {
                        nuevo = false;
                        renglon = articulo;
                        cantidad = articulo.Cantidad;

                    }
                }

                renglon.ArticuloId = (int)art.ArticuloId;
                renglon.Clave = art.Clave;
                renglon.ArticuloDescripcion = art.Descripcion;
                renglon.Cantidad = cantidad + spnCantidad.Value;

                if (nuevo)
                {
                    renglon.ExistenciaInicial = 0;
                    _salidaArticulos.Add(renglon);

                }
                SetGrid();

            }
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

        private void cmdBorrar_Click(object sender, EventArgs e)
        {
            if (grdArticulos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un artículo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _salidaArticulos.RemoveAt(grdArticulos.CurrentRow.Index);
            SetGrid();

        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {

            if (grdArticulos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un artículo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            PreguntaExistencia preguntaExistencia = new PreguntaExistencia();
            preguntaExistencia.spnCantidad.Value = _salidaArticulos[grdArticulos.CurrentRow.Index].Cantidad;
            preguntaExistencia.ShowDialog();

            if (preguntaExistencia.Aceptar)
            {
                _salidaArticulos[grdArticulos.CurrentRow.Index].Cantidad = preguntaExistencia.spnCantidad.Value;
                SetGrid();
            }


        }
    }
}
