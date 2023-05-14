using CFDiLib;
using ClinicaFB.Helpers;
using ClinicaFB.Modelo;
using Dapper;
using FirebirdSql.Data.FirebirdClient;
using Syncfusion.Windows.Forms.Grid;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFB.Ingresos
{
    public partial class CFDisLIstado : Form
    {
        private BindingList<Emisor> _emisores = new BindingList<Emisor>();
        private BindingList<CFDI> _cfdis = new BindingList<CFDI>();

        public CFDisLIstado()
        {
            InitializeComponent();
        }

        private void cmdCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CFDisLIstado_Load(object sender, EventArgs e)
        {
            CargaEmisores();

        }


        private void CargaFacturas()
        {
            int emisorId =(int) cboEmisores.SelectedValue;
            DateTime fechaIni = dtpFechaInicial.Value;
            DateTime fechaFin = dtpFechaFinal.Value;


            using (FbConnection db = General.GetDB())
            {
                string sql = (emisorId==0)?Queries.FacturasSelectxFechas(): Queries.FacturasSelect();
                var res = db.Query<CFDI>(sql, new {EmisorId = emisorId, FechaIni = fechaIni, FechaFin = fechaFin }).ToList();
                _cfdis = new BindingList<CFDI>(res);
            }

        }

        private void SetGrid()
        {
            grdCfdis.DataSource = null;

            grdCfdis.AllowUserToAddRows = false;
            grdCfdis.AllowUserToDeleteRows = false;


            grdCfdis.AutoGenerateColumns = false;
            grdCfdis.ReadOnly = true;
            grdCfdis.AllowUserToResizeColumns = false;
            grdCfdis.AllowUserToResizeRows = false;

            grdCfdis.ColumnCount = 7;

            grdCfdis.RowHeadersVisible = true;


            grdCfdis.ColumnHeadersDefaultCellStyle.Font = new Font(grdCfdis.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            grdCfdis.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grdCfdis.Columns[0].HeaderText = "Emisor";

            grdCfdis.Columns[0].DataPropertyName = "EmisorNombre";
            grdCfdis.Columns[0].Width = 180;

            grdCfdis.Columns[1].HeaderText = "Fecha";
            grdCfdis.Columns[1].DataPropertyName = "Fecha";
            grdCfdis.Columns[1].Width = 90;

            grdCfdis.Columns[2].HeaderText = "Serie";
            grdCfdis.Columns[2].DataPropertyName = "Serie";
            grdCfdis.Columns[2].Width = 40;
            grdCfdis.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            grdCfdis.Columns[3].HeaderText = "Folio";
            grdCfdis.Columns[3].DataPropertyName = "Folio";
            grdCfdis.Columns[3].Width = 50;
            grdCfdis.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            grdCfdis.Columns[4].HeaderText = "Paciente";
            grdCfdis.Columns[4].DataPropertyName = "PacienteNombre";
            grdCfdis.Columns[4].Width = 200;
            //grdCfdis.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            grdCfdis.Columns[5].HeaderText = "Razon Social";
            grdCfdis.Columns[5].DataPropertyName = "ReceptorNombre";
            grdCfdis.Columns[5].Width = 200;
            //grdCfdis.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;



            grdCfdis.Columns[6].HeaderText = "Importe";
            grdCfdis.Columns[6].DataPropertyName = "Total";
            grdCfdis.Columns[6].Width = 80;
            grdCfdis.Columns[6].DefaultCellStyle.Format = "c2";
            grdCfdis.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            DataGridViewCheckBoxColumn colCancelada = new DataGridViewCheckBoxColumn();
            colCancelada.HeaderText = "Cancelada";
            colCancelada.DataPropertyName = "Cancelado";

            grdCfdis.Columns.Add(colCancelada);







            grdCfdis.DataSource = _cfdis;


        }


        private void CargaEmisores()
        {
            cboEmisores.DataSource = null;

            _emisores.Clear();
            _emisores.Add(new Emisor
            {
                EmisorId = 0,
                Nombre = "Todos"
            });

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.EmisoresSelect();
                var res = db.Query<Emisor>(sql).ToList();

                foreach (var emi in res)
                {
                    _emisores.Add(emi);

                }
            }

            cboEmisores.DataSource = _emisores;
            cboEmisores.DisplayMember = "Nombre";
            cboEmisores.ValueMember= "EmisorId";

            foreach (var emi in _emisores)
            {
                if (emi.Defa)
                {
                    cboEmisores.SelectedValue = emi.EmisorId;
                    break;
                }

            }
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            CargaFacturas();
            SetGrid();
        }

        private void cmdArchivos_Click(object sender, EventArgs e)
        {
            if (grdCfdis.CurrentRow == null)
            {
                MessageBox.Show("Seleccione la factura","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            int cfdiId = _cfdis[grdCfdis.CurrentRow.Index].CfdiId;
            CFDI cfdi= new CFDI();
            List<CFDIDetalle> detalle = new List<CFDIDetalle>();

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.CfdiSelect();
                cfdi = db.Query<CFDI>(sql, new {Id=cfdiId}).FirstOrDefault();

                if (cfdi == null)
                {
                    return;
                }

                sql = Queries.CfdiDetallesSelect();
                var res = db.Query<CFDIDetalle>(sql, new { Id = cfdiId }).ToList();
                detalle = new List<CFDIDetalle>(res);

            }

            string carpetaCfdi = General.CarpetaCfdi(cfdi.EmisorRFC, cfdi.Fecha);
            string archivoCfdi = carpetaCfdi +@"\"+ General.NombreArchivoCfdi("FAC", cfdi.Serie, cfdi.Folio);



            string xml = File.Exists(archivoCfdi) ? File.ReadAllText(archivoCfdi) : "";
            ComprobanteCFDI comprobante = new ComprobanteCFDI();

            cfdi.uid = comprobante.GetFolioFiscal(xml);
            cfdi.EmisorCSD= comprobante.GetEmisorCSDFromXML(xml);   

            ManejaCFDIs.GeneraPDFFactura(cfdi, detalle,xml);

            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
            {
                FileName = carpetaCfdi,
                UseShellExecute = true,
                Verb = "open"
            });
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            if (grdCfdis.CurrentRow == null)
            {
                MessageBox.Show("Seleccione la factura para cancelar", "Confirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_cfdis[grdCfdis.CurrentRow.Index].Cancelado )
            {
                MessageBox.Show("La factura ya está cancelada", "Confirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            if (MessageBox.Show("¿Desea cancelar la factura?","Confirme",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.No)
            {
                return;
            }


            int cfdId = _cfdis[grdCfdis.CurrentRow.Index].CfdiId;


            string uid = "";
            string rfc = "";
            string cer = "";
            string key = "";
            string pas = "";

            using (FbConnection db = General.GetDB())
            {
                CFDI cfdi = new CFDI();

                string sql = Queries.CfdiSelect();
                cfdi = db.Query<CFDI>(sql, new {Id = cfdId }).FirstOrDefault();

                if (cfdi == null) {
                    MessageBox.Show("No se encuentra el CFDi", "Confirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                sql = Queries.EmisorSelect();
                int emisorId = cfdi.EmisorId;


                Emisor emi = db.Query<Emisor>(sql, new {EmisorId = emisorId}).FirstOrDefault(); 

                if (emi == null)
                {
                    return;
                }

                uid = cfdi.uid;
                rfc = emi.RFC;
                cer = emi.Certificado;
                key = emi.LlavePrivada;
                pas = emi.PassWord;
            }

            ComprobanteCFDI comprobante = new ComprobanteCFDI();
            string res =comprobante.CancelaSW(rfc, cer, key,pas,uid,"02");

            if (res.Substring(0,3)=="999") 
            {
                MessageBox.Show("No fue posible cancelar la factura "+res, "Confirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }


            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.CfdiCancela();
                db.Execute(sql, new { Id = cfdId, Acuse=res });
            }
            CargaFacturas();



        }
    }
}
