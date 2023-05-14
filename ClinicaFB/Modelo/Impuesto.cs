using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Modelo
{
    public class Impuesto
    {
        public int ImpuestoId { get; set; }
        public string Descripcion { get; set; }
        public decimal Porcentaje { get; set; }
        public bool Defa { get; set; }
    }
}
