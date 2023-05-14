using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Modelo
{
    public class IngresoDetalle
    {
        public int IngresoDetalleId { get; set; }
        public int IngresoId { get; set; }
        public int ArticuloId { get; set; }
        public string Clave { get; set; }
        public string Descripcion { get; set; }
        public string UDM { get; set; }
        public decimal Cantidad { get; set; }
        public string CveProSer { get; set; }
        public string CveUni { get; set; }
        public decimal Precio { get; set; }
        public decimal SubTotal { get; set; }
        public decimal PorceDes { get; set; }
        public decimal Descuento { get; set; }
        public decimal BaseIVA { get; set; }
        public int TipoIVA { get; set; }
        public decimal TasaIVA { get; set; }
        public decimal IVA { get; set; }
        public decimal BaseRetISR { get; set; }
        public decimal PorceRetISR { get; set; }
        public decimal RetISR { get; set; }
        public decimal PorceRetIVA { get; set; }
        public decimal RetIVA { get; set; }
        public int EmisorId { get; set; }
        public string Serie { get; set; }

        public decimal Total {
            get
            {
                return Math.Round(Precio * Cantidad, 2) - Descuento;

            } }


    }
}
