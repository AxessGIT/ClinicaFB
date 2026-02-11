using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Modelo
{
    public class ArticuloClave
    {
        public long ArticuloClaveId { get; set; }
        public long ProveedorId { get; set; }
        public string ClaveProveedor { get; set; }
        public long ArticuloId { get; set; }
    }
}
