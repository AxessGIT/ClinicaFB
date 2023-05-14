using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Modelo
{
    public class CFDI
    {
        public int CfdiId { get; set; }
        public int EmisorId { get; set; }
        public int PacienteId { get; set; }
        public string PacienteNombre { get; set; }
        public int RazonSocialId { get; set; }

        public string TipoComprobante { get; set; } = "I";

        public string Serie { get; set; }
        public int Folio { get; set; }

        public DateTime Fecha { get; set; }
        public string FormaPago { get; set; }
        public string Moneda { get; set; } = "MXN";
        public decimal TipoDeCambio { get; set; } = 1;
        public string MetodoPago { get; set; }
        public string LugarExpedicion { get; set; }

        public string EmisorRFC { get; set; }
        public string EmisorNombre { get; set; }
        public string EmisorRegimenFiscal { get; set; }


        public string ReceptorRFC { get; set; }
        public string ReceptorNombre { get; set; }
        public string ReceptorRegimenFiscal { get; set; }
        public string UsoCFdi { get; set; }

        public decimal SubTotal { get; set; } = 0;
        public decimal Descuento { get; set; } = 0;
        public decimal IVA { get; set; } = 0;
        public decimal RetISR { get; set; } = 0;
        public decimal RetIVA { get; set; } = 0;
        public decimal Total { get; set; } = 0;
        public string uid { get; set; }

        public bool Cancelado { get; set; } = false;
        public string AcuseCan { get; set; } = "";

        public string EmisorCSD { get; set; } = "";
        public string CadenaOriginalSAT { get; set; } = "";
        public string SelloDigital { get; set; } = "";
        public string SelloSAT { get; set; } = "";
        public string RFCPAC { get; set; } = "";
        public DateTime FechaCertificacion { get; set; }
        public string CertificadoSAT { get; set; }
        public int IngresoId { get; set; }

    }
}
