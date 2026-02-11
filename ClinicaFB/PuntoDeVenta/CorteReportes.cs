using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFB.Helpers;
using ClinicaFB.Modelo;
using Dapper;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.Office.Interop.Excel;
using SplashScreen.WindowsForms;

namespace ClinicaFB.PuntoDeVenta
{
    public partial class CorteReportes : Form
    {
        private DateTime _fechaInicial;
        private DateTime _fechaFinal;
        private long _almacenId;
        List<Venta> _ventas = new List<Venta>();

        List<FormaPagoTotal> formasPagoTotales = new List<FormaPagoTotal>();

        public CorteReportes(long almacenId, DateTime fechaInicial, DateTime fechaFinal)
        {
            InitializeComponent();
            _fechaInicial = fechaInicial;
            _fechaFinal = fechaFinal;
            _almacenId = almacenId;
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CargaVentas()
        {
            using (FbConnection db = General.GetDB())
            {
                string sql = ClinicaFB.Helpers.Queries.VentasSelectxSucursalYFechasSinCancelar;
                int sucursalId = Properties.Settings.Default.SucursalId;

                _ventas = db.Query<Venta>(sql, new { SucursalId = sucursalId, AlmacenId = _almacenId, FechaIni = _fechaInicial, FechaFin = _fechaFinal }).ToList();
            }
        }


        private void CorteReportes_Load(object sender, EventArgs e)
        {
            txtFondoInicial.DecimalValue = 0;
        }

        private void cmdGenerar_Click(object sender, EventArgs e)
        {
            CargaVentas();
            if (_ventas.Count == 0)
            {
                MessageBox.Show("No hay ventas en el periodo seleccionado", "Corte de caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!chkCorte.Checked && !chkFormasDePago.Checked && !chkArticulosVendidos.Checked)
            {
                MessageBox.Show("Seleccione al menos un reporte", "Corte de caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Splasher splasher = new Splasher("Generando reportes del corte");
            splasher.Show();

            int sucursalId = Properties.Settings.Default.SucursalId;

            formasPagoTotales = UtilsInv.GetFormasPagoFechas(sucursalId, _almacenId, 2, _fechaInicial, _fechaFinal);
            if (chkCorte.Checked)
                Corte();

            if (chkArticulosVendidos.Checked)
                ArticulosVendidos();
            if (chkFormasDePago.Checked)
                FormasDePago();

            splasher.Close();


        }




        private void Corte()
        {
            int folioInicial = _ventas.Min(v => v.Folio);
            int folioFinal = _ventas.Max(v => v.Folio);

            decimal subTotal = _ventas.Sum(v => v.Subtotal);
            decimal iva = _ventas.Sum(v => v.IVA);

            decimal total = _ventas.Sum(v => v.Total);

            Microsoft.Office.Interop.Excel.Application oExcel;

            oExcel = new Microsoft.Office.Interop.Excel.Application();
            oExcel.Workbooks.Add();


            int ren = 1;
            oExcel.Cells[ren, 1] = "Corte de caja";
            oExcel.Cells[ren, 1].Font.Bold = true;

            ren++;
            oExcel.Cells[ren, 1] = "Fecha inicial";
            oExcel.Cells[ren, 2] = _fechaInicial.ToShortDateString();

            ren++;
            oExcel.Cells[ren, 1] = "Fecha final";
            oExcel.Cells[ren, 2] = _fechaFinal.ToShortDateString();

            ren += 2;
            oExcel.Cells[ren, 1] = "Número de folios (Sin cancelar)";
            oExcel.Cells[ren, 2] = _ventas.Count;

            ren++;
            oExcel.Cells[ren, 1] = "Folio inicial";
            oExcel.Cells[ren, 2] = folioInicial;

            ren++;
            oExcel.Cells[ren, 1] = "Folio final";
            oExcel.Cells[ren, 2] = folioFinal;



            ren += 2;
            oExcel.Cells[ren, 1] = "Fondo inicial";
            oExcel.Cells[ren, 2] = txtFondoInicial.DecimalValue;
            oExcel.Cells[ren, 2].NumberFormat = "$#,##0.00";

            ren += 2;
            oExcel.Cells[ren, 1] = "Ventas";
            oExcel.Cells[ren, 1].Font.Bold = true;

            ren++;
            oExcel.Cells[ren, 1] = "Subtotal";
            oExcel.Cells[ren, 2] = subTotal;
            oExcel.Cells[ren, 2].NumberFormat = "$#,##0.00";

            ren++;
            oExcel.Cells[ren, 1] = "IVA";
            oExcel.Cells[ren, 2] = iva;
            oExcel.Cells[ren, 2].NumberFormat = "$#,##0.00";

            ren++;
            oExcel.Cells[ren, 1] = "Total";
            oExcel.Cells[ren, 2] = total;
            oExcel.Cells[ren, 2].NumberFormat = "$#,##0.00";

            ren += 2;
            oExcel.Cells[ren, 1] = "Total final";
            oExcel.Cells[ren, 1].Font.Bold = true;

            oExcel.Cells[ren, 2] = txtFondoInicial.DecimalValue + total;
            oExcel.Cells[ren, 2].NumberFormat = "$#,##0.00";
            oExcel.Cells[ren, 2].Font.Bold = true;


            ren = 1;
            oExcel.Cells[ren, 4] = "Formas de pago";
            oExcel.Cells[ren, 4].Font.Bold = true;
            ren++;
            //decimal cambioTotal = 0;
            foreach (var formaPago in formasPagoTotales)
            {
                oExcel.Cells[ren, 4] = formaPago.TipoNombre;
                oExcel.Cells[ren, 5] = formaPago.Total;
                //oExcel.Cells[ren, 6] = formaPago.Cambio;
                oExcel.Cells[ren, 5].NumberFormat = "$#,##0.00";
                oExcel.Cells[ren, 6].NumberFormat = "$#,##0.00";
                //cambioTotal += formaPago.Cambio;
                ren++;
            }
            ren++;

            decimal totalNeto = formasPagoTotales.Sum(f => f.Total);
            decimal cambioTotal = totalNeto - total;
            totalNeto = totalNeto - cambioTotal;
            oExcel.Cells[ren, 4] = "- Cambio";
            oExcel.Cells[ren, 5] = cambioTotal;
            oExcel.Cells[ren, 5].NumberFormat = "$#,##0.00";
            ren++;
            oExcel.Cells[ren, 4] = "Total";
            oExcel.Cells[ren, 5] = totalNeto;
            oExcel.Cells[ren, 5].NumberFormat = "$#,##0.00";


            oExcel.Visible = true;

        }

        private void ArticulosVendidos()
        {
            int sucursalId = Properties.Settings.Default.SucursalId;
            List<ArticulosVendidos> articulosVendidos = UtilsInv.GetArticulosVendidos(sucursalId, _almacenId, _fechaInicial, _fechaFinal);

            if (articulosVendidos.Count == 0)
            {
                return;
            }

            Microsoft.Office.Interop.Excel.Application oExcel;

            oExcel = new Microsoft.Office.Interop.Excel.Application();
            oExcel.Workbooks.Add();


            int ren = 1;
            oExcel.Cells[ren, 1] = "Artículos vendidos";
            oExcel.Cells[ren, 1].Font.Bold = true;

            ren++;
            oExcel.Cells[ren, 1] = "Fecha inicial";
            oExcel.Cells[ren, 2] = _fechaInicial.ToShortDateString();

            ren++;
            oExcel.Cells[ren, 1] = "Fecha final";
            oExcel.Cells[ren, 2] = _fechaFinal.ToShortDateString();

            ren += 2;
            oExcel.Cells[ren, 1] = "Artículo";
            oExcel.Cells[ren, 2] = "Cantidad";
            oExcel.Cells[ren, 3] = "Importe";
            oExcel.Cells[ren, 4] = "Impuesto";
            oExcel.Cells[ren, 5] = "Total";
            oExcel.Range[oExcel.Cells[ren, 1], oExcel.Cells[ren, 5]].Font.Bold = true;

            ren++;
            foreach (var articulo in articulosVendidos)
            {
                oExcel.Cells[ren, 1] = articulo.Descripcion;
                oExcel.Cells[ren, 2] = articulo.Cantidad;
                oExcel.Cells[ren, 3] = articulo.Importe;
                oExcel.Cells[ren, 3].NumberFormat = "$#,##0.00";
                oExcel.Cells[ren, 4] = articulo.Impuesto;
                oExcel.Cells[ren, 4].NumberFormat = "$#,##0.00";
                decimal total = articulo.Importe + articulo.Impuesto;
                oExcel.Cells[ren, 5] = total;
                oExcel.Cells[ren, 5].NumberFormat = "$#,##0.00";
                ren++;
            }
            ren += 2;
            oExcel.Cells[ren, 1] = "Total";
            oExcel.Cells[ren, 2] = articulosVendidos.Sum(a => a.Cantidad);
            oExcel.Cells[ren, 3] = articulosVendidos.Sum(a => a.Importe);
            oExcel.Cells[ren, 3].NumberFormat = "$#,##0.00";
            oExcel.Cells[ren, 4] = articulosVendidos.Sum(a => a.Impuesto);
            oExcel.Cells[ren, 4].NumberFormat = "$#,##0.00";
            oExcel.Cells[ren, 5] = articulosVendidos.Sum(a => a.Importe + a.Impuesto);
            oExcel.Cells[ren, 5].NumberFormat = "$#,##0.00";

            oExcel.Visible = true;


        }

        private void FormasDePago()
        {
            using (FbConnection db = General.GetDB())
            {
                string sql = ClinicaFB.Helpers.Queries.FormasPagoVentas;
                int sucursalId = Properties.Settings.Default.SucursalId;

                List<PagoVenta> pagosVentas = db.Query<PagoVenta>(sql, 
                    new { SucursalId = sucursalId, 
                        AlmacenId = _almacenId,
                        OrigenTipo = 2,
                        FechaIni = _fechaInicial, 
                        FechaFin = _fechaFinal }).ToList();

                if (pagosVentas.Count == 0)
                {
                    return;
                }
                Microsoft.Office.Interop.Excel.Application oExcel;
                oExcel = new Microsoft.Office.Interop.Excel.Application();
                oExcel.Workbooks.Add();
                int ren = 1;
                oExcel.Cells[ren, 1] = "Formas de pago";
                oExcel.Cells[ren, 1].Font.Bold = true;
                ren++;
                oExcel.Cells[ren, 1] = "Fecha inicial";
                oExcel.Cells[ren, 2] = _fechaInicial.ToShortDateString();
                ren++;
                oExcel.Cells[ren, 1] = "Fecha final";
                oExcel.Cells[ren, 2] = _fechaFinal.ToShortDateString();
                ren += 2;
                oExcel.Cells[ren, 1] = "Serie";
                oExcel.Cells[ren, 2] = "Folio";
                oExcel.Cells[ren, 3] = "Fecha";
                oExcel.Cells[ren, 4] = "Cliente";
                oExcel.Cells[ren, 6] = "Importe";
                oExcel.Range[oExcel.Cells[ren, 1], oExcel.Cells[ren, 6]].Font.Bold = true;
                ren++;

                long formaPagoId = 0;
                string nombreFormaPago = UtilsInv.GetNombreTipoPago((int)formaPagoId);
                decimal totalFormaPago = 0;
                decimal totalTotal = 0;
                bool primeraVez = true;

                foreach (var pago in pagosVentas)
                {
                    if (pago.FormaPagoId != formaPagoId)
                    {
                        if (!primeraVez)
                        {
                            oExcel.Cells[ren, 7] = totalFormaPago;
                            oExcel.Cells[ren, 7].NumberFormat = "$#,##0.00";
                            ren++;
                        }
                        totalFormaPago = 0;
                        primeraVez = false;
                        formaPagoId = pago.FormaPagoId;
                        nombreFormaPago = UtilsInv.GetNombreTipoPago((int)formaPagoId);
                        ren++; 
                        oExcel.Cells[ren, 1] = nombreFormaPago;
                        oExcel.Cells[ren, 1].Font.Bold = true;
                        ren++;
                    }

                    oExcel.Cells[ren, 1] = pago.Serie;
                    oExcel.Cells[ren, 2] = pago.Folio;
                    oExcel.Cells[ren, 3] = pago.Fecha.ToString("dd/MM/yyyy");
                    oExcel.Cells[ren, 4] = string.IsNullOrEmpty(pago.ClienteNombre)?"PUBLICO EN GENERAL":pago.ClienteNombre;
                    oExcel.Cells[ren, 6] = pago.Importe;
                    oExcel.Cells[ren, 6].NumberFormat = "$#,##0.00";
                    totalFormaPago += pago.Importe;
                    totalTotal += pago.Importe;
                    ren++;
                }
                if (!primeraVez)
                {
                    oExcel.Cells[ren, 7] = totalFormaPago;
                    oExcel.Cells[ren, 7].NumberFormat = "$#,##0.00";
                    ren++;
                }
                oExcel.Cells[ren, 6] = "Total";
                oExcel.Cells[ren, 7] = totalTotal;
                oExcel.Cells[ren, 7].NumberFormat = "$#,##0.00";
                oExcel.Visible = true;
            }

        }
    }
}