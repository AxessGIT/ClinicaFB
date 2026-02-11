using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Modelo
{
    public class ArticuloExistencia
    {
        public long ArtExiId { get; set; }
        public long ArticuloId { get; set; }
        public long AlmacenId { get; set; }
        public string AlmacenNombre { get; set; }
        public decimal Entradas { get; set; }
        public decimal Salidas { get; set; }
        public decimal Existencia { get; set; }
    }
}
