using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Modelo
{
    public class DocumentoDetalle
    {
        public long DocsDetId { get; set; }
        public long DocumentoId { get; set; }
        public string ClaveProve { get; set; }
        public string Clave { get; set; }
        public string UDM { get; set; }
        public string ArticuloDescripcion { get; set; }
        public long ArticuloId { get; set; }
        public string NoIden { get; set; } = "";
        public string CveProSer { get; set; } = "";
        public string Cveuni { get; set; } = "";
        public Decimal Cantidad { get; set; }
        public Decimal Precio { get; set; }
        public Decimal Costo { get; set; } = 0;
        public int TipoIVA { get; set; }
        public Decimal TasaIVA { get; set; }
        public Decimal IVA { get; set; }
        public Decimal Importe { get {
                return Math.Round(Cantidad * Precio, 2);
            }}
        public bool Borrado { get; set; } = false;
        public Decimal ExistenciaInicial { get; set; }


    }
}
