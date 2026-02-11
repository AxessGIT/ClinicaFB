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
    public partial class FacturaBuscar : Form
    {
        public long FacturaId { get; set; }
        private long _emisorId;
        private long _almacenId;
        private bool _esPDV = true;

        public FacturaBuscar(long emisorId,long almacenID=0,bool esPDV=true)
        {
            InitializeComponent();
            _emisorId = emisorId;
            _almacenId = almacenID;
            _esPDV = esPDV;
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            using (FbConnection db = General.GetDB())
            {
                if (spnFolio.Value == 0)
                {
                    MessageBox.Show("Indique el folio a cargar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string sql = _esPDV ? Queries.FacturaSelectxSerieyFolio : Queries.CfdiSelectXSerieYFolio();
                if (_almacenId == 0)
                {
                    sql = Queries.FacturaSelectxSerieyFolioSinAlmacen;
                }
                string serie = txtSerie.Text;
                int folio = (int)spnFolio.Value;

                if (_esPDV)
                {
                    Venta fac = db.Query<Venta>(sql, new { EmisorId = _emisorId, AlmacenId = _almacenId, Serie = serie, Folio = folio }).FirstOrDefault();
                    if (fac == null)
                    {
                        MessageBox.Show("No se encontró la factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    FacturaId = fac.VentaId;

                }
                else
                {
                    CFDI cfdi = db.Query<CFDI>(sql, new { Serie = serie, Folio = folio }).FirstOrDefault();
                    if (cfdi == null)
                    {
                        MessageBox.Show("No se encontró la factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    FacturaId = cfdi.CfdiId;
                }

                Close();

            }

        }

        private void FacturaBuscar_Load(object sender, EventArgs e)
        {

        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void spnFolio_Enter(object sender, EventArgs e)
        {
            spnFolio.Select(0, spnFolio.Text.Length);
        }
    }
}
