using ClinicaFB.Helpers;
using ClinicaFB.PuntoDeVenta.Procesos;
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
    public partial class ReportesMenu : Form
    {
        public ReportesMenu()
        {
            InitializeComponent();
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pdvReportes_Load(object sender, EventArgs e)
        {

        }

        private void cmdExistencias_Click(object sender, EventArgs e)
        {
            ExistenciaYValor rptExistenciaYValor = new ExistenciaYValor();
            rptExistenciaYValor.ShowDialog();
        }

        private void cmdFacturas_Click(object sender, EventArgs e)
        {
            rptFacturas rptFacturas = new rptFacturas();
            rptFacturas.ShowDialog();
        }



        private void cmdKardex_Click(object sender, EventArgs e)
        {
            Kardex rptKardex = new Kardex();
            rptKardex.ShowDialog();
        }

        private void cmdRecalcular_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea recalcular los costos de los productos?", "Recalcular Costos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            Splasher splasher = new Splasher("Recalculando costos");
            splasher.Show();

            using (FbConnection db = General.GetDB())
            {

                db.OpenAsync();
                string sql = "EXECUTE PROCEDURE SP_RECONSTRUIR_CAPAS_DE_COSTOS";
                using (FbCommand cmd = new FbCommand(sql, db))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = 0; // Sin límite de tiempo
                    cmd.ExecuteNonQuery();
                }
                db.CloseAsync();

            }
            splasher.Close();
            MessageBox.Show("Recalculo de costos finalizado.", "Recalcular Costos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cmdFacturas_Click_1(object sender, EventArgs e)
        {
            rptFacturas rptFacturas = new rptFacturas();
            rptFacturas.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ArticulosAsignar articulosAsignar = new ArticulosAsignar();
            articulosAsignar.ShowDialog();
        }
    }
}
