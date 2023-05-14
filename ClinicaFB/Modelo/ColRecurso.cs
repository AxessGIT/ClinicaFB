using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Modelo
{
    public class ColRecurso
    {
        public long ColRecurso_Id { get; set; }
        public long Usuario_Id { get; set; }
        public short Numero { get; set; }
        public string Tipo { get; set; }
        public long Recurso_Id { get; set; }
    }
}
