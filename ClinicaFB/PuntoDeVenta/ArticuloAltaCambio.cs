using ClinicaFB.Helpers;
using ClinicaFB.Modelo;
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
using Dapper;
using ClinicaFB.Configuracion.Facturacion;
using static Syncfusion.Windows.Forms.TabBar;

namespace ClinicaFB.PuntoDeVenta
{
    public partial class ArticuloAltaCambio : Form
    {
        private bool _esAlta;
        private int _articuloId;

        public ArticuloAltaCambio(bool esAlta, int articuloId )
        {
            InitializeComponent();
            _articuloId = articuloId;
            _esAlta = esAlta;   
        }

        private void ArticuloAltaCambio_Load(object sender, EventArgs e)
        {
            SetCombos();

            if (_esAlta)
            {
                Text = "Agregar artículo";
                cboTipos.SelectedIndex= 0;
            }
            else
            {
                Text = "Modificar artículo";
                CargaArticulo();

            }

        }

        private void SetCombos()
        {
            General.ConfiguraComboImpuestos(ref cboImpuestos);
            if (_esAlta)
            {
                int impuestoId = 0;
                impuestoId = General.GetIdImpuestoDefault();
                if (impuestoId != 0)
                {
                    cboImpuestos.SelectedValue = impuestoId;
                }
            }
            General.ConfiguraCombo(ref cboMarcas, "MAR");
            General.ConfiguraCombo(ref cboLineas, "LIN");

        }

        private void CargaArticulo()
        {
            Articulo art = new Articulo();


            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.ArticuloSelect();
                art = db.Query<Articulo>(sql, new { ArticuloId = _articuloId }).FirstOrDefault();
                if (art != null)
                {
                    txtClave.Text = art.Clave;
                    txtCodigoBarras.Text = art.CodigoBarras;
                    txtSKU.Text = art.SKU;
                    txtDescripcion.Text = art.Descripcion;
                    cboTipos.SelectedIndex = art.Tipo;
                    txtUnidadDeMedida.Text = art.UDM;
                    txtUltimoCosto.DecimalValue = art.Costo;
                    txtPrecio1.DecimalValue = art.Precio1;
                    txtPrecio2.DecimalValue = art.Precio2;
                    txtPrecio3.DecimalValue = art.Precio3;
                    txtPrecio4.DecimalValue = art.Precio4;
                    txtPrecio5.DecimalValue = art.Precio5;
                    txtCveProSer.Text = art.CveProSer;
                    txtCveUni.Text = art.CveUni;
                    cboImpuestos.SelectedValue = art.ImpuestoId;
                    cboMarcas.SelectedValue = art.MarcaId;
                    cboLineas.SelectedValue = art.LineaId;

                    txtCveProSer_Validated(new { }, new EventArgs { });
                    txtCveUni_Validated(new { }, new EventArgs { });

                    long sucursalId = Properties.Settings.Default.SucursalId;
                    Sucursal suc = db.Query<Sucursal>(Queries.SucursalSelect(), new { SucursalId = sucursalId }).FirstOrDefault();  

                    if (suc.ListaDePreciosId != 0)
                    {
                        sql = Queries.ArticuloPreciosSelectByArticuloYLista;
                        ArticuloPrecios ap = db.Query<ArticuloPrecios>(sql, new { ArticuloId = _articuloId,ListaPrecioId = suc.ListaDePreciosId }).FirstOrDefault();
                        if (ap != null)
                        {
                            txtPrecio1.DecimalValue = ap.Precio1;
                            txtPrecio2.DecimalValue = ap.Precio2;
                            txtPrecio3.DecimalValue = ap.Precio3;
                            txtPrecio4.DecimalValue = ap.Precio4;
                            txtPrecio5.DecimalValue = ap.Precio5;
                        }

                    }


                }
            }

        }

        private void currencyEdit2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {

        }

        private bool ValidaDatos()
        {
            if (string.IsNullOrEmpty(txtClave.Text))
            {
                MessageBox.Show("Teclee la clave", "Confirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                MessageBox.Show("Teclee la descripción", "Confirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (_esAlta == false)
            {
                using (FbConnection db = General.GetDB())
                {
                    string sql = Queries.ArticuloSelectExisteClave;
                    Articulo art = db.Query<Articulo>(sql, new {ArticuloId=_articuloId, Clave = txtClave.Text.Trim() }).FirstOrDefault();
                    if (art != null)
                    {
                        MessageBox.Show("Ya existe un artículo con esa clave", "Confirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    sql = Queries.ArticuloSelectExisteCodigo;
                    art = db.Query<Articulo>(sql, new { ArticuloId = _articuloId, CodigoBarras = txtCodigoBarras.Text.Trim() }).FirstOrDefault();
                    if (art != null)
                    {
                        MessageBox.Show("Ya existe un artículo con ese código de barras", "Confirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }

            }

            return true;
        }

        private void txtCveProSer_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCveProSer.Text))
            {
                return;
            }
            string des = General.GetDescripcionClaveSAT("CPS", txtCveProSer.Text.Trim());
            if (string.IsNullOrEmpty(des))
            {
                MessageBox.Show("No existe esa clave", "Confirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCveProSer.Text = "";
                txtDescripcionProSer.Text = "";

            }
            else
            {
                txtDescripcionProSer.Text = des;
            }

        }

        private void cmdBuscarCveProSer_Click(object sender, EventArgs e)
        {
            ClaveSATBuscar claveSATBuscar = new ClaveSATBuscar("CPS");
            claveSATBuscar.ShowDialog();
            if (!string.IsNullOrEmpty(claveSATBuscar.Clave))
            {
                txtCveProSer.Text = claveSATBuscar.Clave;
                txtCveProSer_Validated(sender, e);
            }

        }

        private void txtCveUni_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCveUni.Text))
            {
                return;
            }
            string des = General.GetDescripcionClaveSAT("UNI", txtCveUni.Text.Trim());
            if (string.IsNullOrEmpty(des))
            {
                MessageBox.Show("No existe esa clave", "Confirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCveUni.Text = "";
                txtDescripcionUnidad.Text = "";

            }
            else
            {
                txtDescripcionUnidad.Text = des;
            }

        }

        private void cmdBuscarCveUni_Click(object sender, EventArgs e)
        {
            ClaveSATBuscar claveSATBuscar = new ClaveSATBuscar("UNI");
            claveSATBuscar.ShowDialog();
            if (!string.IsNullOrEmpty(claveSATBuscar.Clave))
            {
                txtCveUni.Text = claveSATBuscar.Clave;
                txtCveUni_Validated(sender, e);
            }

        }

        private void cmdSalir_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private async void cmdGuardar_Click_1(object sender, EventArgs e)
        {
            if (!ValidaDatos())
            {
                return;
            }

            using (FbConnection db = General.GetDB())
            {
                await db.OpenAsync();
                using (var transaction = db.BeginTransaction())
                {
                    try
                    {
                        string sql = "";

                        Articulo art = new Articulo
                        {
                            ArticuloId = _articuloId,
                            Clave = txtClave.Text,
                            CodigoBarras = txtClave.Text,
                            SKU = txtSKU.Text,
                            Descripcion = txtDescripcion.Text,
                            Tipo = cboTipos.SelectedIndex,
                            UDM = txtUnidadDeMedida.Text,
                            Costo = txtUltimoCosto.DecimalValue,
                            Moneda = "MXN",
                            Precio1 = txtPrecio1.DecimalValue,
                            Precio2 = txtPrecio2.DecimalValue,
                            Precio3 = txtPrecio3.DecimalValue,
                            Precio4 = txtPrecio4.DecimalValue,
                            Precio5 = txtPrecio5.DecimalValue,
                            CveProSer = txtCveProSer.Text,
                            CveUni = txtCveUni.Text,
                            ImpuestoId = (int)cboImpuestos.SelectedValue,
                            MarcaId = (int)General.DevuelveValorCombo(cboMarcas, "MAR"),
                            LineaId = (int)General.DevuelveValorCombo(cboLineas, "LIN")
                        };

                        long sucursalId = Properties.Settings.Default.SucursalId;
                        if (sucursalId != 0)
                        {
                            Sucursal suc = db.Query<Sucursal>(Queries.SucursalSelect(), new { SucursalId = sucursalId },transaction).FirstOrDefault();
                            if (suc.ListaDePreciosId != 0)
                            {
                                ArticuloPrecios ap = new ArticuloPrecios
                                {
                                    ArticuloId = _articuloId,
                                    ListaPrecioId = suc.ListaDePreciosId,
                                    Precio1 = txtPrecio1.DecimalValue,
                                    Precio2 = txtPrecio2.DecimalValue,
                                    Precio3 = txtPrecio3.DecimalValue,
                                    Precio4 = txtPrecio4.DecimalValue,
                                    Precio5 = txtPrecio5.DecimalValue
                                };
                                sql = Queries.ArticuloPreciosSelectByArticuloYLista;
                                ArticuloPrecios apExiste = db.Query<ArticuloPrecios>(sql, new { ArticuloId = _articuloId,ListaPrecioId = suc.ListaDePreciosId },transaction).FirstOrDefault();
                                if (apExiste == null)
                                {
                                    sql = Queries.ArticuloPreciosInsert;
                                    db.Execute(sql, ap, transaction);
                                }
                                else
                                {
                                    ap.ArticuloPrecioId = apExiste.ArticuloPrecioId;
                                    sql = Queries.ArticuloPreciosUpdate;
                                    db.Execute(sql, ap, transaction);
                                }
                            }

                        }




                        if (_esAlta)
                        {
                            art.FechaUltimaCompra = DateTime.Now;
                            sql = Queries.ArticuloInsert();
                        }

                        else
                        {
                            sql = Queries.ArticuloUpdate();

                        }
                        _articuloId = db.ExecuteScalar<int>(sql, art, transaction);


                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error al guardar el artículo: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                Close();
            }
        }
    }
}
