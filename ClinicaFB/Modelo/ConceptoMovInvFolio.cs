using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Modelo
{
    public class ConceptoMovInvFolio
    {
        public long ConInvFolId { get; set; }
        public long SucursalId { get; set; }
        public long ConceptoId { get; set; }
        public string Serie { get; set; }
        public int Folio { get; set; }
    }
}
