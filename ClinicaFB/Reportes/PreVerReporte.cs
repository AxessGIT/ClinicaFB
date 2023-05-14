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

        public PreVerReporte(string Reporte, List<ReportDataSource> datos,string titulo)
        {
            _reporte = Reporte;
            _datos = datos;
            _titulo = titulo;
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


            System.Drawing.Printing.PageSettings carta = new System.Drawing.Printing.PageSettings();
            carta.PaperSize = new System.Drawing.Printing.PaperSize("Letter", 850, 1100);
            carta.Margins = new System.Drawing.Printing.Margins(10, 10, 10, 0);

            Viewer.SetPageSettings(carta);
            Viewer.RefreshReport();
        }
    }
}
