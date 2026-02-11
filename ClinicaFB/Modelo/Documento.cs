using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Modelo
{
    public class Documento
    {
        public long DocumentoId { get; set; }
        public long SucursalId { get; set; }
        public long AlmacenId { get; set; }
        public string AlmacenNombre { get; set; }
        public long AlmacenDestinoId { get; set; }
        public string AlmacenDestinoNombre { get; set; }
        public long ConceptoId { get; set; }
        public string ConceptoNombre { get; set; }
        public string Tipo { get; set; }
        public DateTime Fecha { get; set; }
        public string Serie { get; set; }
        public int Folio { get; set; }
        public decimal SubTotal { get; set; }
        public decimal IVA { get; set; }
        public decimal Total { get; set; }
        public long ProveedorId { get; set; }
        public string ProveedorNombre { get; set; }
        public string Observaciones { get; set; }
        public bool Cancelado { get; set; }
    }
}
