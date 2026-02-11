using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Modelo
{
    public class ConceptoMovInv
    {
        public long ConMovInvId { get; set; }
        public string Tipo { get; set; }
        public string Descripcion{ get; set; }

        public bool Reservado { get; set; } = false; 
        public bool EsVenta { get; set; } = false;
        public string PrecioCosto { get; set; }
    }
}
