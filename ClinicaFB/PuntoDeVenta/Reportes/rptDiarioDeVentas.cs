using ClinicaFB.Helpers;
using ClinicaFB.Modelo;
using Dapper;
using FirebirdSql.Data.FirebirdClient;
using SplashScreen.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFB.PuntoDeVenta.Reportes
{
    public partial class rptDiarioDeVentas : Form
    {
        private BindingList<Almacen> _almacenes;


        public rptDiarioDeVentas()
        {
            InitializeComponent();
        }

        private void rptDiarioDeVentas_Load(object sender, EventArgs e)
        {
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
                    if (alma.Defa)
                        almacenIdDefa = alma.AlmacenId;

                }

                cboAlmacenes.DataSource = null;
                cboAlmacenes.DataSource = _almacenes;
                cboAlmacenes.ValueMember = "AlmacenId";
                cboAlmacenes.DisplayMember = "Nombre";
                cboAlmacenes.SelectedValue = almacenIdDefa;

            }


        }
        private void GeneraDiario()
        {
            long almacenId = (long)cboAlmacenes.SelectedValue;
            string almacenNombre = cboAlmacenes.Text.Trim();    

            int sucursalId = Properties.Settings.Default.SucursalId;

            string sql = string.Empty;

            DateTime FechaIni = dtpFechaInicial.Value;
            DateTime FechaFin = dtpFechaFinal.Value;

            List<Venta> ventas = new List<Venta>();

            decimal subTotal = 0, iva = 0, total = 0;

            using (FbConnection db = General.GetDB())
            {
                sql = Queries.VentasSelectxSucursalYFechas;
                ventas = db.Query<Venta>(sql, new { SucursalId = sucursalId, AlmacenId = almacenId, FechaIni, FechaFin }).ToList();

            }




            Microsoft.Office.Interop.Excel.Application oExcel;

            oExcel = new Microsoft.Office.Interop.Excel.Application();
            oExcel.Workbooks.Add();


            int ren = 1;
            oExcel.Cells[ren, 1] = almacenNombre;

            ren++;
            oExcel.Cells[ren, 1] = "DIARIOS DE VENTAS DE MOSTRADOR";
            oExcel.Cells[ren, 1].Font.Bold = true;

            ren++;
            oExcel.Cells[ren, 1] = "Desde";
            oExcel.Cells[ren, 2] = FechaIni.ToLongDateString();


            ren++;
            oExcel.Cells[ren, 1] = "Hasta";
            oExcel.Cells[ren, 2] = dtpFechaFinal.Value.ToLongDateString();


            ren++;
            oExcel.Cells[ren, 1] = "Ventas de mostrador";
            oExcel.Cells[ren, 1].Font.Bold = true;


            ren += 2;

            oExcel.Cells[ren, 1] = "Fecha";
            oExcel.Cells[ren, 2] = "Folio";
            oExcel.Cells[ren, 3] = "Cliente";
            oExcel.Cells[ren, 7] = "Importe neto";
            oExcel.Cells[ren, 8] = "Impuesto";
            oExcel.Cells[ren, 10] = "Total";

            oExcel.Cells[ren, 1].Font.Bold = true;
            oExcel.Cells[ren, 2].Font.Bold = true;
            oExcel.Cells[ren, 3].Font.Bold = true;
            oExcel.Cells[ren, 7].Font.Bold = true;
            oExcel.Cells[ren, 8].Font.Bold = true;
            oExcel.Cells[ren, 10].Font.Bold = true;



            foreach (var venta in ventas)
            {
                ren++;
                oExcel.Cells[ren, 1] = $"'{venta.Fecha.ToShortDateString()}";
                oExcel.Cells[ren, 2] = $"{venta.Serie.Trim()}{venta.Folio}";
                oExcel.Cells[ren, 3] = venta.ClienteNombre;
                oExcel.Cells[ren, 7] = venta.Subtotal;
                oExcel.Cells[ren, 8] = venta.IVA;
                oExcel.Cells[ren, 10] = venta.Total;
                oExcel.Cells[ren, 1].NumberFormat = "dd/MM/yyyy";
                oExcel.Cells[ren, 7].NumberFormat = "$#,##0.00";
                oExcel.Cells[ren, 8].NumberFormat = "$#,##0.00";
                oExcel.Cells[ren, 10].NumberFormat = "$#,##0.00";
                subTotal += venta.Subtotal;
                iva += venta.IVA;
                total += venta.Total;

                ren++;

                oExcel.Cells[ren, 2] = "Artículo";
                oExcel.Cells[ren, 6] = "Unidades";
                oExcel.Cells[ren, 8] = "Precio";
                oExcel.Cells[ren, 10] = "Importe neto";
                oExcel.Cells[ren, 2].Font.Bold = true;
                oExcel.Cells[ren, 6].Font.Bold = true;
                oExcel.Cells[ren, 8].Font.Bold = true;
                oExcel.Cells[ren, 10].Font.Bold = true;



                List<VentaDetalle> detalleVenta = new List<VentaDetalle>(); 
                using (FbConnection db = General.GetDB())
                {
                    sql = Queries.VentaDetallesSelect;
                    detalleVenta = db.Query<VentaDetalle>(sql, new {venta.VentaId }).ToList();
                    foreach (var det in detalleVenta)
                    {
                        ren++;
                        oExcel.Cells[ren, 2] = det.Descripcion;
                        oExcel.Cells[ren, 6] = det.Cantidad;
                        oExcel.Cells[ren, 8] = det.PrecioNeto;
                        oExcel.Cells[ren, 10] = det.TotalNeto;
                        oExcel.Cells[ren, 2].NumberFormat = "@";
                        oExcel.Cells[ren, 6].NumberFormat = "0.00";
                        oExcel.Cells[ren, 8].NumberFormat = "$#,##0.00";
                        oExcel.Cells[ren, 10].NumberFormat = "$#,##0.00";
                    }
                    ren++;
                    oExcel.Cells[ren, 2] = "Forma de cobro";
                    oExcel.Cells[ren, 4] = "Importe";
                    oExcel.Cells[ren, 2].Font.Bold = true;
                    oExcel.Cells[ren, 4].Font.Bold = true;
                    List<Pago> pagos = new List<Pago>();
                    sql = Queries.VentaPagosSelect;
                    pagos = db.Query<Pago>(sql, new { DoctoOrigenId = venta.VentaId }).ToList();
                    foreach (var pago in pagos)
                    {
                        ren++;

                        long formaPagoId = pago.Tipo;
                        string nombreFormaPago = UtilsInv.GetNombreTipoPago((int)formaPagoId);


                        oExcel.Cells[ren, 2] = nombreFormaPago;
                        oExcel.Cells[ren, 4] = pago.Importe;
                        oExcel.Cells[ren, 2].NumberFormat = "@";
                        oExcel.Cells[ren, 4].NumberFormat = "$#,##0.00";
                    }



                }
            }

            ren++;
            oExcel.Cells[ren, 1] = $"Total {ventas.Count} documentos";
            oExcel.Cells[ren, 7] = subTotal;
            oExcel.Cells[ren, 8] = iva;
            oExcel.Cells[ren, 10] = total;
            oExcel.Cells[ren, 7].NumberFormat = "$#,##0.00";
            oExcel.Cells[ren, 8].NumberFormat = "$#,##0.00";
            oExcel.Cells[ren, 10].NumberFormat = "$#,##0.00";
            oExcel.Cells[ren, 1].Font.Bold = true;
            oExcel.Cells[ren, 7].Font.Bold = true;
            oExcel.Cells[ren, 8].Font.Bold = true;
            oExcel.Cells[ren, 10].Font.Bold = true;


            oExcel.Visible = true;



        }


        private async void cmdGenerar_Click(object sender, EventArgs e)
        {
            long almacenId = (long)cboAlmacenes.SelectedValue;
            if (almacenId == 0)
            {
                MessageBox.Show("Seleccione un almacén", "Almacén", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpFechaInicial.Value.Date > dtpFechaFinal.Value.Date)
            {
                MessageBox.Show("La fecha inicial no puede ser mayor a la fecha final", "Fechas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Splasher splasher = new Splasher("Generando Diario");
            splasher.Show();
            await Task.Run(() => GeneraDiario());
            splasher.Close();

        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
