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
                txtClave.ReadOnly = true;
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
                    txtCveProSer_Validated(new { }, new EventArgs { });
                    txtCveUni_Validated(new { }, new EventArgs { });

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
            if (ValidaDatos() == false)
                return;

            Articulo art = new Articulo();
            art.ArticuloId = _articuloId;
            art.Clave = txtClave.Text;
            art.Descripcion = txtDescripcion.Text;
            art.Tipo = cboTipos.SelectedIndex;
            art.UDM = txtUnidadDeMedida.Text;
            art.Costo = txtUltimoCosto.DecimalValue;
            art.Precio1 = txtPrecio1.DecimalValue;
            art.Precio2 = txtPrecio2.DecimalValue;
            art.Precio3 = txtPrecio3.DecimalValue;
            art.Precio4 = txtPrecio4.DecimalValue;
            art.Precio5 = txtPrecio5.DecimalValue;
            art.CveProSer = txtCveProSer.Text;
            art.CveUni = txtCveUni.Text;
            art.ImpuestoId = Convert.ToInt32(cboImpuestos.SelectedValue);
            art.MarcaId = 0;
            art.LineaId = 0;


            using (FbConnection db = General.GetDB())
            {
                string sql = _esAlta ? Queries.ArticuloInsert() : Queries.ArticuloUpdate();
                db.Execute(sql, art);
            }
            Close();


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
    }
}
