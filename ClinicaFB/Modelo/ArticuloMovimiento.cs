using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Modelo
{
    public class ArticuloMovimiento
    {
        public long ArtMovId { get; set; }
        public long ArticuloId { get; set; }
        public long AlmacenId { get; set; }
        public bool EsVenta { get; set; }
        public long ConceptoId { get; set; }
        public string ConceptoNombre { get; set; }
        public string ConceptoTipo { get; set; }
        public string Tipo { get; set; }
        public DateTime Fecha { get; set; }
        public long DocumentoId { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Importe { get; set; }
        public decimal UltimoCosto { get; set; }
    }
}
