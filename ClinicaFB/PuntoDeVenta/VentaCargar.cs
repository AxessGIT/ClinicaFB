using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using FirebirdSql.Data.FirebirdClient;
using ClinicaFB.Helpers;
using ClinicaFB.Modelo;


namespace ClinicaFB.PuntoDeVenta
{
    public partial class VentaCargar : Form
    {
        public long VentaId { get; set; }
        public long CFDIId { get; set; }
        private long _emisorId;
        private long _almacenId;
        private bool _esPDV = false;

        public VentaCargar(bool esPDV, long emisorId, long almacenId)
        {
            InitializeComponent();
            _emisorId = emisorId;
            _almacenId = almacenId;
            _esPDV = esPDV;
        }

        private void TicketCargar_Load(object sender, EventArgs e)
        {

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

                string sql = _esPDV?Queries.VentaSelectxSerieyFolio: Queries.CfdiSelectXSerieYFolio();
                string serie = txtSerie.Text;
                int folio = (int)spnFolio.Value;


                if (_esPDV)
                {
                    Venta venta = db.Query<Venta>(sql, new { EmisorId = _emisorId, AlmacenId = _almacenId, Serie = serie, Folio = folio }).FirstOrDefault();

                    if (venta == null)
                    {
                        MessageBox.Show("No se encontró la venta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    VentaId = venta.VentaId;
                    Close();

                }
                else { 

                    CFDI cfdi = db.Query<CFDI>(sql, new {Serie = serie, Folio = folio }).FirstOrDefault();

                    if (cfdi == null)
                    {
                        MessageBox.Show("No se encontró la factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    CFDIId = cfdi.CfdiId;
                    Close();


                }

            }
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void spnFolio_Enter(object sender, EventArgs e)
        {
            spnFolio.Select(0, spnFolio.Value.ToString().Length);
        }
    }
}
