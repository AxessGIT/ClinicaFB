using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.ModeloConfiguracion
{
    public class Empresa
    {
        public int Empresa_Id { get; set; }
        public string Nombre { get; set; }
        public string Nombre_Corto { get; set; }
        public string Direccion { get; set; }
        public string Colonia { get; set; }
        public string Localidad { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public string Cp { get; set; }
        public byte[] Logotipo { get; set; }
        public string WebServiceURL { get; set; }
        public string CarpetaWEB { get; set; }
        public string CarpetaReportes { get; set; }
        public string CarpetaImagenes { get; set; }
        public string BddWEB { get; set; }
        public bool CopiarWEB { get; set; }
    }
}
