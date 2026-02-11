using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Modelo
{
    public class ComPagRel
    {
        public long ComPagRelId { get; set; }
        public long ComPagoId { get; set; }
        public long DocumentoId { get; set; }
        public string UID { get; set; }
        public string Serie { get; set; }
        public int Folio { get; set; }
        public DateTime Fecha { get; set; }
        public string CveMON { get; set; }
        public decimal TipoDeCambio { get; set; }
        public string CveMEP { get; set; }
        public decimal Parcialidad { get; set; }
        public decimal Importe { get; set; }
        public decimal SaldoAnterior { get; set; }
        public decimal Pagado { get; set; }
        public decimal SaldoInsoluto { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal BaseIVA16 { get; set; }
        public decimal IVA16 { get; set; }
        public decimal BaseIVA0 { get; set; }
        public decimal BaseIVAExento { get; set; }
    }
}
