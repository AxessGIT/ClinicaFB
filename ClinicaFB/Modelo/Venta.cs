using System;

namespace ClinicaFB.Modelo
{
    public class Venta
    {
        public long VentaId { get; set; }
        public long SucursalId { get; set; }
        public long AlmacenId { get; set; }
        public string AlmacenNombre { get; set; }
        public long EmisorId { get; set; }
        public long DoctorId { get; set; }
        public string DoctorNombre { get; set; }
        public string EmisorNombre { get; set; }
        public long ClienteId { get; set; }
        public string ClienteNombre { get; set; }
        public string ClienteNom { get { return string.IsNullOrEmpty(ClienteNombre)?"PUBLICO EN GENERAL":ClienteNombre; } }
        public string Tipo { get; set; }
        public string Serie { get; set; }
        public string TipoComprobante { get; set; } = "I";
        public int Folio { get; set; }
        public DateTime Fecha { get; set; }
        public string FormaPago { get; set; }
        public string Moneda { get; set; }
        public decimal TipoCambio { get; set; }
        public string MetodoPago { get; set; }
        public string LugarExpedicion { get; set; }
        public string Uso { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Descuento { get; set; }
        public decimal IVA { get; set; }
        public decimal RetISR { get; set; }
        public decimal RetIVA { get; set; }
        public decimal Total { get; set; }
        public string SerieFac { get; set; }
        public int FolioFac { get; set; }
        public DateTime FechaFac { get; set; }

        public string UID { get; set; }
        public string CSD { get; set; }

        public bool Timbrada { get { return !string.IsNullOrEmpty(UID); }}
        public bool Cancelada { get; set; }
        public string Acuse { get; set; }
        public string WebId { get; set; }
        public decimal Tot { get { return Subtotal + IVA - Descuento; } }
        public bool Facturar { get; set; }
        public long FacturaGlobalId { get; set; }
        public string Observaciones { get; set; }
        public string CveRel { get; set; }
        public string UIDRel { get; set; }
        public long VentaIdRel { get; set; }
        public string xml { get; set; }
    }
}
