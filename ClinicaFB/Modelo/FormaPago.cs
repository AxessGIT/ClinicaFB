using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Modelo
{
    public class FormaPago
    {
        public int FormaPagoId { get; set; }
        public int Clave { get; set; }
        public string Nombre { get; set; }
        public string CveFOP { get; set; }
    }
}
