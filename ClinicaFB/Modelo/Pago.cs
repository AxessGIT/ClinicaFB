using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Modelo
{
    public class Pago
    {
        public int PagoId { get; set; }
        public int OrigenTipo { get; set; }
        public int DoctoOrigenId { get; set; }
        public int Tipo { get; set; }
        public decimal Importe { get; set; }
        public string Referencia { get; set; }
    }
}
