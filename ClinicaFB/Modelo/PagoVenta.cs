using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Modelo
{
    public class PagoVenta
    {
        public long VentaId { get; set; }
        public string Serie { get; set; }
        public string Folio { get; set; }

        public DateTime Fecha { get; set; }
        public long ClienteId { get; set; }
        public string ClienteNombre { get; set; }

        public long FormaPagoId { get; set; }
        public string FormaPagoNombre { get; set; }
        public decimal Importe { get; set; }
    }
}
