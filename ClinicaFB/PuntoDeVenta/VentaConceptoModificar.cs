using ClinicaFB.Helpers;
using ClinicaFB.Modelo;
using ClinicaFB.ModeloConfiguracion;
using Dapper;
using FirebirdSql.Data.FirebirdClient;
using Org.BouncyCastle.Asn1.Mozilla;
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
    public partial class VentaConceptoModificar : Form
    {
        private decimal _porceDes;
        public VentaDetalle _partida;
        public bool Guardar = false;   
        public bool IncImpVta=true;

        public VentaConceptoModificar(VentaDetalle detalle, decimal porceDes=0)
        {
            InitializeComponent();
            _partida = detalle;
            _porceDes = porceDes;
        }

        private void VentaConceptoModificar_Load(object sender, EventArgs e)
        {
            txtDescuento.Enabled = false;
            txtClave.Text = _partida.NoIden;
            txtDescripcion.Text = _partida.Descripcion;
            txtPrecio.DecimalValue = _partida.PrecioNeto;
            spnCantidad.Value = _partida.Cantidad;
            ActiveControl = spnCantidad;

            using (FbConnection db = General.GetConexionConfig())
            {
                Empresa empresa = new Empresa();
                string sql = Queries.EmpresaSelect();
                int empresaId = (int) Properties.Settings.Default.Empresa_ID;
                empresa = db.Query<Empresa>(sql, new { Empresa_Id = empresaId }).FirstOrDefault();

                if (empresa != null)
                {
                    IncImpVta = empresa.IncImpVta;
                }

            }

            if (IncImpVta)
            {
                lblIncluyeIVA.Text = "Precio incluye IVA";
            }
            else
            {
                lblIncluyeIVA.Text = "Precio NO incluye IVA";
            }





            CalculaTotales();

        }

        private void CalculaTotales()
        {

            decimal baseIVA = Math.Round(spnCantidad.Value * txtPrecio.DecimalValue, 2);
            _partida.IVA = (_partida.TipoIVA == 1) ? Math.Round(baseIVA * _partida.TasaIVA / 100, 2) : 0;

            txtTotal.DecimalValue = Math.Round(spnCantidad.Value * txtPrecio.DecimalValue, 2);
        }

        private void txtPrecio_Validated(object sender, EventArgs e)
        {
            CalculaTotales();
        }

        private void spnCantidad_Validated(object sender, EventArgs e)
        {
            CalculaTotales();
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            _partida.Cantidad = spnCantidad.Value;
            if (IncImpVta)
            {
                _partida.Precio = Math.Round(txtPrecio.DecimalValue / (1 + _partida.TasaIVA / 100),2);
            }
            else
            {
                _partida.Precio = txtPrecio.DecimalValue;
            }

            _partida.IVA = (_partida.TipoIVA == 1) ? Math.Round(_partida.Cantidad * _partida.Precio * _partida.TasaIVA / 100, 2) : 0;

            Guardar = true;
            Close();
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Guardar = false;
            Close();

        }
    }
}
