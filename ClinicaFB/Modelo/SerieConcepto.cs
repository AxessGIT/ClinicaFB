using Syncfusion.XlsIO.Implementation.PivotTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Modelo
{
    public class SerieConcepto
    {
        public int SerieConceptoId { get; set; }
        public int SerieId { get; set; }
        public string Serie { get; set; }
        public int EmisorId { get; set; }
        public int ArticuloId { get; set; }
        public string Clave { get; set; }

        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public decimal PorceRetISR { get; set; }
        public decimal PorceRetIVA { get; set; }
        public bool AgregaPaciente { get; set; }
    }
}
