using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Modelo
{
    public class SucursalAlmacen
    {
        public long SucAlmaId { get; set; }
        public long SucursalId { get; set; }
        public long AlmacenId { get; set; }
        public bool Defa { get; set; }
    }
}
