using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Modelo
{
    public class DatoFiscal
    {
        public long DatoFiscalId { get; set; }
        public string RFC { get; set; }
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        public string Localidad { get; set; }
        public string Ciudad { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string CP { get; set; }
        public string CveREF { get; set; }
        public string CveUSO { get; set; }
        public string CveMEP { get; set; }
        public string CveFOP { get; set; }
    }
}
