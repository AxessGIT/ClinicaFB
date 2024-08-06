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
    public partial class ComprasAltasCambios : Form
    {
        private bool _esAlta = false;
        private int _compraId = 0;
        private int _proveedorId = 0;
        private int _articuloId = 0;
        private decimal _tasaIVA = 0;   
        private BindingList<DocumentoDetalle> _compraArticulos = new BindingList<DocumentoDetalle>();

        public ComprasAltasCambios(bool esAlta, int compraId)
        {
            InitializeComponent();
            _esAlta = esAlta;
            _compraId = compraId;
        }

        private void ComprasAltasCambios_Load(object sender, EventArgs e)
        {
            BuscaProveedor();
            ActiveControl = txtConcepto;
        }

        private void BuscaProveedor()
        {
            ProveedoresBuscar proveedoresBuscar = new ProveedoresBuscar();
            proveedoresBuscar.ShowDialog();
            if (proveedoresBuscar.ProveedorId > 0)
            {
                _proveedorId = proveedoresBuscar.ProveedorId;

                using (FbConnection db = General.GetDB())
                {
                    string sql = Queries.ProveedorSelect;
                    Proveedor proveedor = db.Query<Proveedor>(sql, new { ProveedorId = _proveedorId }).FirstOrDefault();

                    if (proveedor != null)
                    {
                        txtProveedorNombre.Text = proveedor.Nombre;
                    }
                }
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
                        BuscaArticulo(false, articulosBuscar.ArticuloId);

                        /*using (FbConnection db = General.GetDB())
                        {
                            string sql = Queries.ArticuloSelect();
                            Articulo art = db.Query<Articulo>(sql, new { ArticuloId = articulosBuscar.ArticuloId }).FirstOrDefault();
                            if (art != null)
                            {
                                txtConcepto.Text = art.Clave;
                                txtDescripcion.Text = art.Descripcion;
                                txtCosto.DecimalValue = art.Costo;
                                txtCantidad.Value = 1;
                                txtCosto.Focus();
                            }
                        }*/

                    }
                    break;
                case Keys.Enter:
                    BuscaArticulo(true);
                    break;
            }    
        }


        private void BuscaArticulo(bool porClave, int articuloId=0)
        {
            if (string.IsNullOrEmpty(txtConcepto.Text))
            {
                return;
            }
            using (FbConnection db = General.GetDB())
            {
                string sql = porClave? Queries.ArticuloSelectxClave(): Queries.ArticuloSelect();
                Articulo art = 
                    porClave?
                    db.Query<Articulo>(sql, new { Clave = txtConcepto.Text.Trim() }).FirstOrDefault():
                    db.Query<Articulo>(sql, new {ArticuloId = articuloId }).FirstOrDefault();

                if (art == null)
                {
                    MessageBox.Show("Esa clave no existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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





                txtDescripcion.Text = art.Descripcion;
                txtCosto.DecimalValue = art.Costo;
                txtCantidad.Value = 1;
                _articuloId = (int) art.ArticuloId;
                _tasaIVA = tasaIVA;
                ActiveControl = txtCantidad;

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



            grdArticulos.DataSource = _compraArticulos;

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

                decimal baseIVA = Math.Round((decimal)txtCantidad.Value * txtCosto.DecimalValue, 2);
                decimal importeIVA = (tipoIVA == 1) ? Math.Round(baseIVA * tasaIVA / 100, 2) : 0;


                string des = "";

                des = art.Descripcion.Trim();


                decimal importe = Math.Round((decimal)txtCantidad.Value * txtCosto.DecimalValue, 2);    
                _compraArticulos.Add(new DocumentoDetalle
                {
                    ArticuloId = (int)art.ArticuloId,
                    Clave = txtConcepto.Text.Trim(),
                    ArticuloDescripcion = des,
                    UDM = art.UDM,
                    Precio = txtCosto.DecimalValue,
                    Cantidad = (decimal) txtCantidad.Value,
                    IVA = importeIVA
                    
                });

                SetGrid();
                CalculaTotales();


            }

        }
        private void CalculaTotales()
        {
            decimal subTotal = 0, IVA = 0;

            foreach (var articulo in _compraArticulos)
            {
                subTotal += Math.Round(articulo.Precio * articulo.Cantidad,2);
                IVA += articulo.IVA;
            }

            txtSubTotal.DecimalValue = subTotal;
            txtIVA.DecimalValue = IVA;
            txtTotal.DecimalValue = subTotal + IVA;


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
            _compraArticulos.Add(new DocumentoDetalle
            {
                ArticuloId = _articuloId,
                Clave = txtConcepto.Text.Trim(),
                ArticuloDescripcion = txtDescripcion.Text.Trim(),
                UDM = "PZA",
                Precio = txtCosto.DecimalValue,
                Cantidad = (decimal)txtCantidad.Value,
                IVA = _tasaIVA
            });

            SetGrid();
            LimpiaCaptura();
            CalculaTotales();
            txtConcepto.Focus();
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
            if (grdArticulos.CurrentRow== null)
            {
                MessageBox.Show("Favor de seleccionar un artículo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            _compraArticulos.RemoveAt(grdArticulos.CurrentRow.Index);
            SetGrid();
        }
    }
}
