using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Modelo
{
    public class SerieDoc
    {
        public int SerieDocId { get; set; }
        public int EmisorId { get; set; }
        public string Tipo { get; set; }
        public string Serie { get; set; }
        public int Folio { get; set; }
        public bool Defa { get; set; }
        public bool Activa { get; set; }
    }
}
