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
    public partial class VentaVisor : Form
    {
        private long _ventaId;


        private BindingList<Emisor> _emisores = new BindingList<Emisor>();
        private BindingList<Almacen> _almacenes = new BindingList<Almacen>();
        private BindingList<Doctor> _doctores = new BindingList<Doctor>();
        private BindingList<VentaDetalle> _ventaArticulos = new BindingList<VentaDetalle>();

        public VentaVisor(long ventaId)
        {
            InitializeComponent();
            _ventaId = ventaId;
        }

        private void VentaVisor_Load(object sender, EventArgs e)
        {
            CargaVenta();
            CargaDetalle();
            SetGrid();

        }


        private void CargaVenta()
        {
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.VentaVisorSelect;
                Venta vta = db.Query<Venta>(sql, new { VentaId = _ventaId }).FirstOrDefault();

                if (vta == null)
                {
                    return;
                }

                txtTipo.Text = vta.Tipo;
                txtSerie.Text = vta.Serie;
                txtFolio.Text = vta.Folio.ToString();
                dtpFecha.Value = vta.Fecha;
                txtEmisor.Text = vta.EmisorNombre;
                txtUID.Text = vta.UID;
                txtAlmacen.Text = vta.AlmacenNombre;
                txtIVA.DecimalValue = vta.IVA;
                txtSubTotal.DecimalValue = vta.Subtotal;
                txtTotal.DecimalValue = vta.Subtotal+vta.IVA-vta.Descuento;
                txtEmisor.Text = vta.EmisorNombre;
                txtAlmacen.Text = vta.AlmacenNombre;
                txtDoctor.Text = vta.DoctorNombre;
                txtSerieFac.Text = vta.SerieFac;
                txtFolioFac.Text = vta.FolioFac.ToString();
                txtAcuse.Text = vta.Acuse;
                if (vta.ClienteId > 0)
                {
                    txtRazonSocial.Text = vta.ClienteNombre;
                }
                List<Pago> pagos = UtilsInv.GetPagosVenta(_ventaId);

                decimal totalPagos = pagos.Sum(x => x.Importe);
                foreach (Pago pago in pagos)
                {
                    switch (pago.Tipo)
                    {
                        case 1:
                            txtEfectivo.DecimalValue = pago.Importe;
                            break;
                        case 2:
                            txtTarjeta.DecimalValue = pago.Importe;
                            break;
                        case 3:
                            txtTransferencia.DecimalValue = pago.Importe;
                            break;
                        case 4:
                            txtTarjetaCredito.DecimalValue = pago.Importe;
                            break;
                        case 5:
                            txtCheque.DecimalValue = pago.Importe;
                            break;
                        case 6:
                            txtIntermediarios.DecimalValue = pago.Importe;
                            break;
                    }                    
                }

                txtTotalPagos.DecimalValue = totalPagos;
                txtCambio.DecimalValue = totalPagos - vta.Total;

                if (txtCambio.DecimalValue < 0)
                {
                    txtCambio.DecimalValue = 0;
                }

            }
        }
    
        private void CargaDetalle()
        {
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.VentaDetallesSelect;
                var res = db.Query<VentaDetalle>(sql, new { VentaId = _ventaId }).ToList();
                _ventaArticulos = new BindingList<VentaDetalle>(res);
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



            grdArticulos.DataSource = _ventaArticulos;

        }

    

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void currencyEdit1_TextBox_Validated(object sender, EventArgs e)
        {

        }
    }
}
