using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Modelo
{
    public class Articulo
    {
        public long ArticuloId { get; set; }
        public string Clave { get; set; }
        public string CodigoBarras { get; set; }
        public string Descripcion { get; set; }
        public int Tipo { get; set; }
        public string UDM { get; set; }
        public string Moneda { get; set; }= "MXN";
        public decimal Costo { get; set; }
        public decimal Precio1 { get; set; }
        public decimal Precio2 { get; set; }
        public decimal Precio3 { get; set; }
        public decimal Precio4 { get; set; }
        public decimal Precio5 { get; set; }
        public string CveProSer { get; set; }
        public string CveUni { get; set; }
        public decimal PorceIVA { get; set; }
        public long ImpuestoId { get; set; }
        public long MarcaId { get; set; }
        public long LineaId { get; set; }
        public decimal PrecioNeto   
        { get { return Math.Round(Precio1 * (1 + PorceIVA / 100), 2); } }
        public DateTime FechaUltimaCompra { get; set; }
        public string SKU { get; set; }

    }
}
