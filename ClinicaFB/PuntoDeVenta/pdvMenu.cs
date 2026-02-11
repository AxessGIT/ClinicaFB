using ClinicaFB.Ingresos;
using ClinicaFB.PuntoDeVenta.Procesos;
using ClinicaFB.PuntoDeVenta.Reportes;
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
    public partial class pdvMenu : Form
    {
        public pdvMenu()
        {
            InitializeComponent();
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdArticulos_Click(object sender, EventArgs e)
        {
            ArticulosListado articulosListado = new ArticulosListado();
            articulosListado.Show();

        }

        private void cmdAlmacenes_Click(object sender, EventArgs e)
        {
            AlmacenesListado almacenesListado = new AlmacenesListado();
            almacenesListado.ShowDialog();
        }

        private void cmdPuntoDeVenta_Click(object sender, EventArgs e)
        {
            PdV pdV = new PdV();
            pdV.ShowDialog();

        }

        private void cmdProveedores_Click(object sender, EventArgs e)
        {
            ProveedoresListado proveedoresListado = new ProveedoresListado();
            proveedoresListado.ShowDialog();
        }

        private void cmdCompras_Click(object sender, EventArgs e)
        {
            ComprasListado comprasListado = new ComprasListado();
            comprasListado.ShowDialog();
        }

        private void cmdVentasListado_Click(object sender, EventArgs e)
        {
            VentasListado ventasListado = new VentasListado();
            ventasListado.ShowDialog();
        }



        private void cmdNotasDeCredito_Click(object sender, EventArgs e)
        {
            NotasDeCreditoListado notasDeCreditoListado = new NotasDeCreditoListado(esPDV:true);
            notasDeCreditoListado.ShowDialog();
        }

        private void cmdSalidas_Click(object sender, EventArgs e)
        {
            //SalidasListado salidasListado = new SalidasListado();
            //salidasListado.ShowDialog();
            EntradasSalidasListado entradasSalidasListado = new EntradasSalidasListado("S");
            entradasSalidasListado.ShowDialog();

        }

        private void cmdReportes_Click(object sender, EventArgs e)
        {
            ReportesMenu pdvReportes = new ReportesMenu();
            pdvReportes.ShowDialog();
        }

        private void cmdProcesos_Click(object sender, EventArgs e)
        {
            ProcesosMenu pdvProcesosMenu = new ProcesosMenu();
            pdvProcesosMenu.ShowDialog();

        }

        private void cmdFacturaGlobal_Click(object sender, EventArgs e)
        {
            FacturaGlobal facturaGlobal = new FacturaGlobal();
            facturaGlobal.ShowDialog();
        }

        private void cmdFacturasGlobalesListado_Click(object sender, EventArgs e)
        {
            FacturasGlobalesListado facturasGlobalesListado = new FacturasGlobalesListado();
            facturasGlobalesListado.ShowDialog();
        }

        private void cmdEntradas_Click(object sender, EventArgs e)
        {
            EntradasSalidasListado entradasSalidasListado = new EntradasSalidasListado("E");
            entradasSalidasListado.ShowDialog();
        }

        private void cmdConceptos_Click(object sender, EventArgs e)
        {
            ConceptosListado conceptosListado = new ConceptosListado();
            conceptosListado.ShowDialog();
        }

        private void cmdColaboradores_Click(object sender, EventArgs e)
        {
            ColaboradoresListado colaboradoresListado = new ColaboradoresListado();
            colaboradoresListado.ShowDialog();
        }

        private void cmdPagos_Click(object sender, EventArgs e)
        {
            PagosListado pagosListado = new PagosListado(esPDV:true);
            pagosListado.ShowDialog();
        }
    }
}
