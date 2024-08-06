using ClinicaFB.Helpers;
using ClinicaFB.Modelo;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;

namespace ClinicaFB.Ingresos
{
    public partial class FacturaGlobalGenerar : Form
    {
        private BindingList<Emisor> _emisores = new BindingList<Emisor>();
        public FacturaGlobalGenerar()
        {
            InitializeComponent();
        }

        private void FacturaGlobalGenerar_Load(object sender, EventArgs e)
        {
            CargaEmisores();
        }


        private void CargaEmisores()
        {
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.EmisoresSelect();
                _emisores = new BindingList<Emisor>(db.Query<Emisor>(sql).ToList());
            }

            foreach (var emisor in _emisores)
            {
                chlEmisores.Items.Add(emisor.Nombre, true);

            }
        }

        private void chkSeleccionarTodos_CheckedChanged(object sender, EventArgs e)
        {
            CambiaEmisores(chkSeleccionarTodos.Checked);


        }

        private void CambiaEmisores(bool estado)
        {
            for (int i = 0; i < chlEmisores.Items.Count; i++)
            {
                chlEmisores.SetItemChecked(i, estado);
            }
        }

        private void chkSeleccionarTodos_Validated(object sender, EventArgs e)
        {
            //PonEmisores(chkSeleccionarTodos.Checked);

        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdGenerar_Click(object sender, EventArgs e)
        {
            if (chlEmisores.CheckedItems.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un emisor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SplashScreen.WindowsForms.Splasher splasher = new SplashScreen.WindowsForms.Splasher("Generando factura(s)...");
            splasher.Show();


            for (int i = 0; i < chlEmisores.Items.Count; i++)
            {
                if (chlEmisores.GetItemChecked(i))
                {
                    Emisor emisor = _emisores[i];
                    GeneraFactura(emisor);
                }
            }
            splasher.Close();
            MessageBox.Show("Factura(s) generada(s) correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            
        }

        private void GeneraFactura(Emisor emisor)
        {
            List<IngresoNoFacturado> ingresosNoFacturados = new List<IngresoNoFacturado>();

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.IngresosNoFacturadosSelect();
                var ingresos = 
                    db.Query<IngresoNoFacturado>(sql, 
                    new {EmisorId=emisor.EmisorId, FechaIni = dtpFechaInicial.Value, FechaFin = dtpFechaFinal.Value}).ToList();
                if (ingresos.Count == 0)
                {
                    return;
                }


                sql = Queries.IngresoPagosTarjetaOTransferenciaSelect;
                foreach (var ingreso in ingresos)
                {

                    var pagos = db.Query<Pago>(sql, new { DoctoOrigenId = ingreso.IngresoId }).ToList();

                    if (pagos.Count == 0)
                    {
                        ingresosNoFacturados.Add(ingreso);
                    }
                }


                
            }

            if (ingresosNoFacturados.Count == 0)
            {
                return;
            }
            ManejaCFDIs.GeneraFacturaGlobal(emisor, ingresosNoFacturados);
        }
    }
}


