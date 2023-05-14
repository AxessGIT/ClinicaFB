using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Modelo
{
    public class CorreoInfo
    {
        public string Servidor { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Cuenta { get; set; }
        public bool UsarSSL { get; set; }
        public string Mensaje { get; set; }
    }
}
