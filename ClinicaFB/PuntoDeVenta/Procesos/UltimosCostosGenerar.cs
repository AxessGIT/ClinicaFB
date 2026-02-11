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

namespace ClinicaFB.PuntoDeVenta.Procesos
{
    public partial class UltimosCostosGenerar : Form
    {
        public UltimosCostosGenerar()
        {
            InitializeComponent();
        }

        private void UtimosCostosGenerar_Load(object sender, EventArgs e)
        {

        }

        private void cmdGenerar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea generar los últimos costos de los artículos?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            Cursor = Cursors.WaitCursor;
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.ArticulosMovimientosSelect;
                List<ArticuloMovimiento> movimientos = db.Query<ArticuloMovimiento>(sql).ToList();

                foreach (var movimiento in movimientos)
                {

                    decimal ultimoCosto = UtilsInv.GetUltimoCostoArticulo(movimiento.AlmacenId, movimiento.ArticuloId, movimiento.Fecha);
                    sql = Queries.ArticuloMovimientoUltimoCostoUpdate; 

                    db.Execute(sql, new {ultimoCosto, movimiento.ArtMovId });
                }
            }
            Cursor = Cursors.Default;
            MessageBox.Show("Terminó de generar los últimos costos de los artículos");

        }

        private void cmdCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
