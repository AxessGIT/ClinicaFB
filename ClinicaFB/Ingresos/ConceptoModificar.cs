using ClinicaFB.Configuracion.Facturacion;
using ClinicaFB.Helpers;
using ClinicaFB.Modelo;
using Dapper;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.Office.Interop.Excel;
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
    public partial class ConceptoModificar : Form
    {
        public IngresoDetalle _concepto;
        private Articulo _articulo;
        private string _nombrePaciente = "";
        public bool _guardar = false;
        private int _emisorId = 0;

        public ConceptoModificar(IngresoDetalle concepto,string nombrePaciente,int emisorId)
        {
            InitializeComponent();
            _concepto = concepto;
            _nombrePaciente=nombrePaciente;
            _emisorId= emisorId;

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.ArticuloSelect();
                _articulo= db.Query<Articulo>(sql, new {ArticuloId = _concepto.ArticuloId}).FirstOrDefault();
                _articulo.ArticuloId = _concepto.ArticuloId;
                
            }
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            _guardar = false;
            Close();
        }

        private void ConceptoModificar_Load(object sender, EventArgs e)
        {
            SetCombos();
            CargaDatos();

        }

        private void CargaDatos()
        {

            txtCveProSer_Validated(new { }, new EventArgs { });
            txtCveUni_Validated(new { }, new EventArgs { });


            txtClave.Text = _articulo.Clave;
            txtDescripcion.Text = _concepto.Descripcion;
            spnCantidad.Value = _concepto.Cantidad;
            txtPrecio.DecimalValue= _concepto.Precio;
            txtCveProSer.Text = _concepto.CveProSer;
            txtCveUni.Text = _concepto.CveUni;

            CalculaTotales();



        }

        private void CalculaTotales()
        {

            _concepto.BaseIVA = Math.Round(spnCantidad.Value * txtPrecio.DecimalValue, 2);
            _concepto.IVA = (_concepto.TipoIVA == 1) ? Math.Round(_concepto.BaseIVA * _concepto.TasaIVA / 100, 2) : 0;

            txtTotal.DecimalValue = Math.Round(spnCantidad.Value * txtPrecio.DecimalValue, 2);
        }

        private void SetCombos()
        {
            General.ConfiguraComboImpuestos(ref cboImpuestos);
            int impuestoId = 0;

            impuestoId = 0;
            if (_articulo!= null)
            {
                impuestoId = _articulo.ImpuestoId;
            }
            if (impuestoId != 0)
            {
              cboImpuestos.SelectedValue = impuestoId;
            }
        }

        private void AgregaArticulo()
        {

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.ArticuloSelectxClave();
                Articulo art = db.Query<Articulo>(sql, new { Clave = txtClave.Text.Trim() }).FirstOrDefault();

                if (art == null)
                {
                    MessageBox.Show("Esa clave no existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;

                }

                _articulo= art;

                Impuesto imp = new Impuesto();


                if (_articulo.ImpuestoId != 0)
                {
                    sql = Queries.ImpuestoSelect();
                    imp = db.Query<Impuesto>(sql, new { ImpuestoId = _articulo.ImpuestoId }).FirstOrDefault();

                    if (imp != null)
                    {
                        if (imp.Descripcion == "EXENTO")
                        {
                            _concepto.TipoIVA = 2;
                            _concepto.TasaIVA = 0;
                        }
                        else
                        {

                            _concepto.TipoIVA = 1;
                            _concepto.TasaIVA = imp.Porcentaje;


                        }
                    }

                }



                sql = Queries.SeriesConceptosSelectXArticulo();
                SerieConcepto serCon = db.Query<SerieConcepto>(sql, new { ArticuloId = _articulo.ArticuloId }).FirstOrDefault();


                int emisorId = 0;
                string serie = "";

                txtPrecio.DecimalValue = _articulo.Precio1;
                txtDescripcion.Text = _articulo.Descripcion;
                cboImpuestos.SelectedValue = _articulo.ImpuestoId;


                if (serCon != null)
                {
                    emisorId = serCon.EmisorId; 
                    serie = serCon.Serie;

                    _concepto.EmisorId= emisorId;
                    _concepto.Serie= serie;

                    if (serCon.AgregaPaciente && _nombrePaciente.Trim().ToUpper() != "PUBLICO EN GENERAL")
                    {
                        txtDescripcion.Text = _articulo.Descripcion.Trim()+ " " + _nombrePaciente.Trim().ToUpper();
                    }


                }
                else
                {
                    sql = Queries.SerieDefault();
                    SerieDoc serDefa = db.Query<SerieDoc>(sql, new { EmisorId = _emisorId, Tipo = "FAC" }).FirstOrDefault();

                    if (serDefa != null)
                    {
                        serie = serDefa.Serie;
                        _concepto.EmisorId= _emisorId;
                        _concepto.Serie= serie;
                    }

                }




            }

            CalculaTotales();

        }


        private void ActualizaConcepto()
        {


            _concepto.ArticuloId = (int)_articulo.ArticuloId;
            _concepto.Clave = txtClave.Text.Trim();
            _concepto.Descripcion = txtDescripcion.Text;
            _concepto.UDM = _articulo.UDM;
            _concepto.CveUni = txtCveUni.Text;
            _concepto.CveProSer = txtCveProSer.Text;
            _concepto.Precio = txtPrecio.DecimalValue;
            _concepto.Cantidad = spnCantidad.Value;

            CalculaTotales();

        }


        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            ActualizaConcepto();
            _guardar = true;
            Close();
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

        private void txtClave_Validated(object sender, EventArgs e)
        {
            AgregaArticulo();
        }

        private void spnCantidad_Validating(object sender, CancelEventArgs e)
        {
            CalculaTotales();
        }

        private void txtPrecio_Validated(object sender, EventArgs e)
        {
            CalculaTotales();
        }

        private void spnCantidad_ValueChanged(object sender, EventArgs e)
        {
            CalculaTotales();
        }
    }
}
