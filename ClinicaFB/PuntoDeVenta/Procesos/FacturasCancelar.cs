using CFDiLib;
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
using Twilio.TwiML.Voice;

namespace ClinicaFB.PuntoDeVenta.Procesos
{
    public partial class FacturasCancelar : Form
    {
        public FacturasCancelar()
        {
            InitializeComponent();
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdIniciar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea iniciar la revisión?", "Cancelar Facturas", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            using (FbConnection db = General.GetDB())
            {
                string sql = "Select VentaId,UID From Ventas Where Ventas.Cancelada = true and (Acuse is Null Or Acuse ='')";
                List<Venta> ventasCanceladas = db.Query<Venta>(sql).ToList();

                foreach (Venta venta in ventasCanceladas)
                {
                    sql = Queries.VentaSelect;
                    Venta ven = db.Query<Venta>(sql, new { VentaId = venta.VentaId }).FirstOrDefault();
                    if (ven == null)
                    {
                        continue;
                    }
                    if (ven.Timbrada)
                    {
                        sql = Queries.EmisorSelect();
                        Emisor emisor = db.Query<Emisor>(sql, new { EmisorId = ven.EmisorId }).FirstOrDefault();
                        if (emisor == null)
                        {
                            continue;
                        }
                        string cer = emisor.Certificado;
                        string key = emisor.LlavePrivada;
                        string pas = emisor.PassWord;
                        string uid = ven.UID;
                        string rfc = emisor.RFC;

                        ///////////////////////

                        ComprobanteCFDI comprobante = new ComprobanteCFDI();

                        string motivo = "02";
                        string res = comprobante.CancelaSW(rfc, cer, key, pas, uid, motivo);


                        if (res.Substring(0, 3) == "999")
                        {
                            continue;

                        }


                        sql = Queries.VentaSetDatosCancelacion;
                        db.Execute(sql, new { VentaId = venta.VentaId, Acuse = res });


                        ////////////////////////

                    }
                }

            }
            MessageBox.Show("Terminó la revisión de facturas canceladas");

        }
    }
}
