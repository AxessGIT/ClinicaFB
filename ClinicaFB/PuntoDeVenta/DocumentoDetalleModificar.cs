using ClinicaFB.Modelo;
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
    public partial class DocumentoDetalleModificar : Form
    {
        public  DocumentoDetalle _partida;
        public bool _guardar = false;
        private string _tipo = "";
        public DocumentoDetalleModificar(DocumentoDetalle doctoDetalle,string tipo = "")
        {
            _partida = doctoDetalle;
            _tipo = tipo;
            InitializeComponent();
        }

        private void CompraDetalleModificar_Load(object sender, EventArgs e)
        {
            MuestraDatos();
            ActiveControl = spnCantidad;
            //if (_tipo == "S")
            //{
               // txtCosto.Enabled = false;
            //}
        }

        private void CalculaTotal()
        {
            txtTotal.DecimalValue = Math.Round(spnCantidad.Value * txtCosto.DecimalValue,2);
        }

        private void MuestraDatos()
        {
            txtClave.Text = _partida.Clave;
            txtDescripcion.Text = _partida.ArticuloDescripcion;
            spnCantidad.Value = _partida.Cantidad;
            txtCosto.DecimalValue = _partida.Precio;
            txtTotal.DecimalValue = _partida.Importe;
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            _guardar = false;
            Close();
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            _partida.Cantidad = spnCantidad.Value;
            _partida.Precio = txtCosto.DecimalValue;
            _partida.IVA = Math.Round(_partida.Cantidad * _partida.Precio * _partida.TasaIVA/100,2);

            _guardar = true;
            Close();
        }

        private void txtCosto_Validated(object sender, EventArgs e)
        {
            CalculaTotal();
        }

        private void spnCantidad_Validated(object sender, EventArgs e)
        {
            CalculaTotal();

        }
    }
}
