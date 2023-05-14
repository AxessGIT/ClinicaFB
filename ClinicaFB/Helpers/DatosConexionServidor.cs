using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Helpers
{
    public class DatosConexionServidor
    {
        public string Servidor { get; set; }
        public int Puerto { get; set; }
        public string Usuario { get; set; }
        public string PassWord { get; set; }
        public string Carpeta { get; set; }
        public string BaseDeDatos { get; set; }

    }
}
