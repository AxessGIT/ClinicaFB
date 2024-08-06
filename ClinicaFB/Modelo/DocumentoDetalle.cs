using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Modelo
{
    public class DocumentoDetalle
    {
        public int DocsDetId { get; set; }
        public int DocumentoId { get; set; }
        public string ClaveProve { get; set; }
        public string Clave { get; set; }
        public string UDM { get; set; }
        public string ArticuloDescripcion { get; set; }
        public int ArticuloId { get; set; }
        public Decimal Cantidad { get; set; }
        public Decimal Precio { get; set; }
        public Decimal IVA { get; set; }
        public Decimal Importe { get {
                return Math.Round(Cantidad * Precio, 2);
            }}
    }
}
