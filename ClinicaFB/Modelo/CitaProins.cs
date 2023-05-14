using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Modelo
{
    public class CitaProins
    {
        public long CitaProIns_Id { get; set; }
        public long Cita_Id { get; set; }
        public string Tipo { get; set; }
        public long ProcIns_Id { get; set; }
        public decimal Importe { get; set; }
    }
}
