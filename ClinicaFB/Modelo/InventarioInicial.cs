using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Modelo
{
    public class InventarioInicial
    {
        public int InventarioInicialId { get; set; }
        public int ArticuloId { get; set; }
        public int AlmacenId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Cantidad { get; set; }
    }
}
