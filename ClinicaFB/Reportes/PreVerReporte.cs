using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFB.Reportes
{
    public partial class PreVerReporte : Form
    {

        private string _reporte;
        private string _titulo;
        private List<ReportDataSource> _datos;
        private bool _mediaCarta;

        public PreVerReporte(string Reporte, List<ReportDataSource> datos,string titulo,bool mediaCarta = false)
        {
            _reporte = Reporte;
            _datos = datos;
            _titulo = titulo;
            _mediaCarta = mediaCarta;
            InitializeComponent();
        }

        private void PreVerReporte_Load(object sender, EventArgs e)
        {
            Text = _titulo;
            Viewer.ProcessingMode = ProcessingMode.Local;
            Viewer.LocalReport.ReportPath = _reporte;
            Viewer.LocalReport.DataSources.Clear();

            foreach (var dato in _datos)
            {
                Viewer.LocalReport.DataSources.Add(dato);
            }


            System.Drawing.Printing.PageSettings hoja = new System.Drawing.Printing.PageSettings();

            if (_mediaCarta)
            {
                hoja.PaperSize = new System.Drawing.Printing.PaperSize("850 x 11 in", 850, 550);

            }
            else
            {
                hoja.PaperSize = new System.Drawing.Printing.PaperSize("Letter", 850, 1100);

            }
            hoja.Margins = new System.Drawing.Printing.Margins(10, 10, 10, 0);

            Viewer.SetPageSettings(hoja);
            Viewer.RefreshReport();
        }
    }
}
