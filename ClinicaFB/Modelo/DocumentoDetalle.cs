using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Modelo
{
    public class DocumentoDetalle
    {
        public long DocsDetId { get; set; }
        public long DocumentoId { get; set; }
        public long ArticuloId { get; set; }
        public string NoIden { get; set; }
        public string Descripcion { get; set; }
        public string UDM { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Descuento { get; set; }
        public decimal PorceIVA { get; set; }
        public string CveProSer { get; set; }
        public string CveUni { get; set; }
        public decimal RetIVA { get; set; }
    }
}
