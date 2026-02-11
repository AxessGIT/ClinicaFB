using ClinicaFB.Helpers;
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

namespace ClinicaFB.PuntoDeVenta.Procesos
{
    public partial class ProcesosMenu : Form
    {
        public ProcesosMenu()
        {
            InitializeComponent();
        }

        private void cmdInicializar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea inicializar la base de datos de inventarios?\nVentas\nCompras\nAjustes\nExistencias", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            using (FbConnection db = General.GetDB())
            {
                string[] instrucciones =
                    {
                    Queries.VentasDelete,
                    Queries.VentasDetalleDelete,
                    Queries.DocumentosDelete,
                    Queries.DocumentosDetalleDelete,
                    Queries.ArticulosExistenciasDelete,
                    Queries.ArticulosMovimientosDelete
                };

                foreach (var instruccion in instrucciones)
                {
                    db.Execute(instruccion);
                }
            }
            MessageBox.Show("Terminó la inicialización de inventarios");

        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdImportar_Click(object sender, EventArgs e)
        {
            ArticulosImportar articulosImportar = new ArticulosImportar();
            articulosImportar.ShowDialog();
        }

        private void cmdImpresoraTicketSeleccionar_Click(object sender, EventArgs e)
        {
            ImpresoraTicketSeleccionar impresoraTicketSeleccionar = new ImpresoraTicketSeleccionar();
            impresoraTicketSeleccionar.ShowDialog();
        }

        private void cmdAjustarExistencias_Click(object sender, EventArgs e)
        {
        }

        private void cmdGenerarExistencias_Click(object sender, EventArgs e)
        {
        }

        private void cmdGenerarInventarioInicial_Click(object sender, EventArgs e)
        {
            InventarioInicialCrear inventarioInicialCrear = new InventarioInicialCrear();
            inventarioInicialCrear.ShowDialog();
        }

        private void cmdCancelarFacturas_Click(object sender, EventArgs e)
        {
            FacturasCancelar facturasCancelar = new FacturasCancelar();
            facturasCancelar.ShowDialog();
        }

        private void cmdCostosGenerar_Click(object sender, EventArgs e)
        {
            UltimosCostosGenerar costosGenerar = new UltimosCostosGenerar();
            costosGenerar.ShowDialog();

        }

        private void cmdCargarDetalle_Click(object sender, EventArgs e)
        {
            CargarDetalle cargarDetalle = new CargarDetalle();
            cargarDetalle.ShowDialog();
        }

        private void cmdCrearDesdeCFdi_Click(object sender, EventArgs e)
        {
            CreaFacturaDesdeCFDi creaFacturaDesdeCFDi = new CreaFacturaDesdeCFDi();
            creaFacturaDesdeCFDi.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreaCFDiDesdeCFDi creaCFDiDesdeCFDi = new CreaCFDiDesdeCFDi();
            creaCFDiDesdeCFDi.ShowDialog();
        }
    }
}
