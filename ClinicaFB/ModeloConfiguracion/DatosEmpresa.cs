using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.ModeloConfiguracion
{
    public class DatosEmpresa
    {
        public Int64 Empresa_Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Colonia { get; set; }
        public string Localidad { get; set; }
        public string CP { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public string Estado { get; set; }
        public string Telefonos { get; set; }
        public string Correos { get; set; }
        public byte[] Logotipo { get; set; }
        public string AvisosServidor { get; set; }
        public string AvisosUsuario { get; set; }
        public string AvisosPassword { get; set; }
        public string AvisosCuenta { get; set; }
        public bool AvisosSSL { get; set; }
        public int AvisosPuerto { get; set; }
        public string CarpetaReportes { get; set; }

    }
}
