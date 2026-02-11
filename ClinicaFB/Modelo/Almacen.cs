using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Modelo
{
    public class Almacen
    {
        public long AlmacenId { get; set; }
        public string Nombre { get; set; }
        public bool Defa { get; set; }
        public string SerieVen { get; set; }
        public int FolioVen { get; set; }
        public string SerieFac { get; set; }
        public int FolioFac { get; set; }
        public string SerieNC { get; set; }
        public int FolioNC { get; set; }
        public string FormatoFac { get; set; }
    }
}
