using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Modelo
{
    public class ArticulosVendidos
    {
        public int ArticuloId { get; set; }
        public string Clave { get; set; }
        public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Importe { get; set; }
        public decimal Impuesto { get; set; }
    }
}
