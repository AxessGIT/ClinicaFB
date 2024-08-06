using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Modelo
{
    public class Documento
    {
        public int DocumentoId { get; set; }
        public int AlmacenId { get; set; }
        public string Tipo { get; set; }
        public DateTime Fecha { get; set; }
        public string Serie { get; set; }
        public int Folio { get; set; }
        public decimal SubTotal { get; set; }
        public decimal IVA { get; set; }
        public decimal Total { get; set; }
        public int ProveedorId { get; set; }
        public string ProveedorNombre { get; set; }
    }
}
