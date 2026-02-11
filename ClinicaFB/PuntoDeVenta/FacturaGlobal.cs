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
    public partial class FacturaGlobal: Form
    {
        private BindingList<Emisor> _emisores = new BindingList<Emisor>();
        private BindingList<Almacen> _almacenes = new BindingList<Almacen>();

        private BindingList<Venta> _ventas = new BindingList<Venta>();

        public FacturaGlobal()
        {
            InitializeComponent();
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FacturaGlobal_Load(object sender, EventArgs e)
        {
            CargaEmisores();
            CargaAlmacenes();
            CargaVentas();
            SetGrid();
        }

        private void SeleccionarVentas(int cuales)
        {
            foreach (Venta vta in _ventas)
            {
                switch (cuales)
                {
                    case 1:
                        vta.Facturar = true;
                        break;
                    case 2:
                        vta.Facturar = false;
                        break;
                    case 3:
                        vta.Facturar = !vta.Facturar;
                        break;
                }
            }
            SetGrid();
        }
        private void CargaVentas()
        {
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.VentasNoFacturadasSelect;

                int sucursalId = Properties.Settings.Default.SucursalId;
                long almacenId = (long)cboAlmacenes.SelectedValue;

                DateTime fechaIni = dtpFechaInicial.Value;
                DateTime fechaFin = dtpFechaFinal.Value;

                var res = db.Query<Venta>(sql, 
                    new {AlmacenId= almacenId, SucursalId = sucursalId, FechaIni = fechaIni, FechaFin = fechaFin }).ToList();
                _ventas = new BindingList<Venta>(res);
            }
        }

        private void SetGrid()
        {
            grdVentas.DataSource = null;

            grdVentas.AllowUserToAddRows = false;
            grdVentas.AllowUserToDeleteRows = false;


            grdVentas.AutoGenerateColumns = false;
            grdVentas.ReadOnly = false;
            grdVentas.AllowUserToResizeColumns = false;
            grdVentas.AllowUserToResizeRows = false;




            grdVentas.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(grdVentas.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            grdVentas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdVentas.Columns["colFacturar"].ReadOnly = false;

            grdVentas.DataSource = _ventas;

        }



        private void CargaAlmacenes()
        {

            long almacenIdDefa = 0;
            _almacenes = UtilsPDV.GetAlmacenes();


            foreach (var alma in _almacenes)
            {
                if (alma.Defa)
                {
                    almacenIdDefa = alma.AlmacenId;
                    break;
                }
            }

            cboAlmacenes.DataSource = null;
            cboAlmacenes.DataSource = _almacenes;
            cboAlmacenes.ValueMember = "AlmacenId";
            cboAlmacenes.DisplayMember = "Nombre";
            cboAlmacenes.SelectedValue = almacenIdDefa;




        }
        private void CargaEmisores()
        {
            _emisores = UtilsPDV.GetEmisores();

            cboEmisores.DataSource = null;
            cboEmisores.DataSource = _emisores;
            cboEmisores.ValueMember = "EmisorId";
            cboEmisores.DisplayMember = "Nombre";
            cboEmisores.SelectedValue = _emisores[0].EmisorId;

        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            CargaVentas();
            SetGrid();
        }

        private void cmdTodas_Click(object sender, EventArgs e)
        {
            SeleccionarVentas(1);
        }

        private void cmdNinguna_Click(object sender, EventArgs e)
        {
            SeleccionarVentas(2);
        }

        private void cmdInvertir_Click(object sender, EventArgs e)
        {
            SeleccionarVentas(3);
        }

        private async void cmdGenerar_Click(object sender, EventArgs e)
        {
            var seleccionado = _ventas.Where(v => v.Facturar).ToList();
            if (seleccionado.Count() == 0)
            {
                MessageBox.Show("No hay ventas seleccionadas para facturar", "Factura Global", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("¿Desea generar la factura global?", "Factura Global", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            int sucursalId = Properties.Settings.Default.SucursalId;
            long almacenId = (long)cboAlmacenes.SelectedValue;
            long emisorId = (long)cboEmisores.SelectedValue;

            List<Venta> ventasFacturar = _ventas.Where(v => v.Facturar).ToList();


            Emisor emisor = new Emisor();
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.EmisorSelect();
                emisor = db.Query<Emisor>(sql, new { EmisorId = emisorId }).FirstOrDefault();
            }


            SplashScreen.WindowsForms.Splasher splasher = new SplashScreen.WindowsForms.Splasher("Generando factura(s)...");
            splasher.Show();

            await ManejaCFDIs.GeneraFacturaGlobal(sucursalId, almacenId, emisor, ventasFacturar,detallada:rbDetallada.Checked);
            splasher.Close();
            MessageBox.Show("Factura global generada correctamente", "Factura Global", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();


        }

        private void cmdVer_Click(object sender, EventArgs e)
        {
            if (grdVentas.CurrentRow == null)
            {
                MessageBox.Show("No hay una venta seleccionada","Aviso",MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            long ventaId = _ventas[grdVentas.CurrentRow.Index].VentaId;
            VentaVisor ventaVisor = new VentaVisor(ventaId);
            ventaVisor.ShowDialog();



        }
    }
}
