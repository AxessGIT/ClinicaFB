using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Modelo
{
    public class ComplementoPago
    {
        public long ComPagId { get; set; }
        public bool EsPDV { get; set; }
        public long EmisorId { get; set; }
        public long RazonSocialId { get; set; }
        public string ReceptorNombre { get; set; }

        public string Serie { get; set; }= string.Empty;
        public int Folio { get; set; }
        public DateTime Fecha { get; set; }
        public string CveFOP { get; set; } = string.Empty;
        public string CveMON { get; set; } = "MXN";
        public decimal TipoDeCambio { get; set; } = 1;
        public decimal Monto { get; set; }
        public string UID { get; set; }=string.Empty;
        public bool Cancelado { get; set; } = false;
        public string Acuse { get; set; } = string.Empty;
        public string CveMotCan { get; set; }=string.Empty;
        public string xml { get; set; }
        public bool Timbrado { get { return !string.IsNullOrEmpty(UID); } }

    }
}
