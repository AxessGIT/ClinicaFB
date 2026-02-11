using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Modelo
{
    public class VentaDetalle
    {
        public long VentaDetId { get; set; }
        public long VentaId { get; set; }
        public long ArticuloId { get; set; }
        public string NoIden { get; set; }
        public string Descripcion { get; set; }
        public string UDM { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal PrecioDes { get { return Precio - Descuento; } }
        public decimal PrecioNeto
        {
            get
            {
                return Math.Round((Precio - Descuento) * (1 + TasaIVA / 100), 2);
            }
        }
        public decimal Descuento { get; set; }
        public decimal IVA { get; set; }
        public int TipoIVA { get; set; }
        public decimal TasaIVA { get; set; }
        public string CveProSer { get; set; }
        public string CveUni { get; set; }
        public decimal RetIVA { get; set; }
        public decimal RetISR { get; set; }
        public decimal Total { get {return Math.Round(Cantidad * (Precio - Descuento), 2);}}
        public decimal TotalNeto { get { return Math.Round(Cantidad * PrecioNeto, 2); } }
        public long DetalleIdRel { get; set; }
    }
}
