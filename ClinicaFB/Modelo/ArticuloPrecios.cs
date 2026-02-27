using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Modelo
{
    public class ArticuloPrecios
    {
        public long ArticuloPrecioId { get; set; }
        public long ListaPrecioId { get; set; }
        public long ArticuloId { get; set; }
        public decimal Precio1 { get; set; }
        public decimal Precio2 { get; set; }
        public decimal Precio3 { get; set; }
        public decimal Precio4 { get; set; }
        public decimal Precio5 { get; set; }
    }
}
