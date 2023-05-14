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
        public string Tipo { get; set; }
        public string Folio { get; set; }
        public DateTime Fecha { get; set; }
        public long DatoFiscalId { get; set; }
        public decimal SubTotal { get; set; }
        public decimal IVA { get; set; }
        public decimal IEPS { get; set; }
        public decimal RetISR { get; set; }
        public decimal RetIVA { get; set; }
        public decimal Total { get; set; }
    }
}
