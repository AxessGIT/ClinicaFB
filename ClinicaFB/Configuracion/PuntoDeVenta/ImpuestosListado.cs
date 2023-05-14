using ClinicaFB.Helpers;
using ClinicaFB.Modelo;
using ClinicaFB.Reportes;
using Dapper;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFB.Configuracion.PuntoDeVenta
{
    public partial class ImpuestosListado : Form
    {
        private BindingList<Impuesto> _impuestos;

        public ImpuestosListado()
        {
            InitializeComponent();
        }

        private void ImpuestosListado_Load(object sender, EventArgs e)
        {
            CargaImpuestos();
            SetGrid();

        }

        private void CargaImpuestos()
        {

            string sql = "";

            sql = Queries.ImpuestosSelect();
            using (FbConnection db = General.GetDB())
            {
                var res = db.Query<Impuesto>(sql).ToList();
                _impuestos = new BindingList<Impuesto>(res);

            }

        }


        private void SetGrid()
        {
            grdImpuestos.DataSource = null;

            grdImpuestos.RowHeadersVisible = true;


            grdImpuestos.AllowUserToAddRows = false;
            grdImpuestos.AllowUserToDeleteRows = false;


            grdImpuestos.AutoGenerateColumns = false;
            grdImpuestos.ReadOnly = true;
            grdImpuestos.AllowUserToResizeColumns = false;
            grdImpuestos.AllowUserToResizeRows = false;



            grdImpuestos.ColumnHeadersDefaultCellStyle.Font = new Font(grdImpuestos.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            grdImpuestos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grdImpuestos.Columns[0].DataPropertyName = "Descripcion";
            grdImpuestos.Columns[1].DataPropertyName = "Porcentaje";
            grdImpuestos.Columns[2].DataPropertyName = "Defa";

            grdImpuestos.DataSource = _impuestos;






        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            AltasCambios(true);
        }

        private void AltasCambios(bool esAlta)
        {
            int id = 0;
            if (!esAlta)
            {
                if (grdImpuestos.CurrentRow == null)
                {
                    MessageBox.Show("Indique el impuesto a modificar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                id = _impuestos[grdImpuestos.CurrentRow.Index].ImpuestoId;
            }
            ImpuestoAltasCambios impAC = new ImpuestoAltasCambios(esAlta, id);
            impAC.ShowDialog();
            CargaImpuestos();
            SetGrid();
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            AltasCambios(false);

        }

        private void grdImpuestos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AltasCambios(false);
        }

        private void cmdDefault_Click(object sender, EventArgs e)
        {
            if (grdImpuestos.CurrentRow == null)
            {
                MessageBox.Show("Indique el impuesto predeterminado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int id = _impuestos[grdImpuestos.CurrentRow.Index].ImpuestoId;

            using (FbConnection db = General.GetDB())
            {
                string sql = "Update Impuestos Set Defa=true where ImpuestoId=@ImpuestoId";
                db.Execute(sql, new { ImpuestoId = id });

                sql = "Update Impuestos Set Defa=false where ImpuestoId<>@ImpuestoId";
                db.Execute(sql, new { ImpuestoId = id });


            }
            CargaImpuestos();
            SetGrid();
        }

        private void cmdImprimir_Click(object sender, EventArgs e)
        {





       /*     ReportViewer reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;

            //reportViewer.LocalReport.ReportPath = @"Impuestos.rdlc";
            reportViewer.LocalReport.ReportEmbeddedResource = "Impuestos";

            ReportDataSource reportDataSource = new ReportDataSource("dsReporte", _impuestos);

            PreVerReporte reporte = new PreVerReporte("Impuestos.rdlc", reportDataSource,"Impuestos");
            reporte.ShowDialog();
            return;*/



            /*
             *             string deviceInfo = string.Empty;
            string[] streamIds;
            Warning[] warnings;

            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;

             * reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(reportDataSource);
            reportViewer.RefreshReport();

            var bytes = reportViewer.LocalReport.Render("PDF",deviceInfo,out mimeType,out encoding, out extension,out streamIds, out warnings);

            string fileName = @"c:\prgs\facturafox\Impuestos.pdf";
            File.WriteAllBytes(fileName, bytes);
            System.Diagnostics.Process.Start(fileName);*/


        }
    }
}
