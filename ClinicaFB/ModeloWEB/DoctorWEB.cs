using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.ModeloWEB
{
    public class DoctorWEB
    {
        public int DoctorId { get; set; }
        public string Nombres { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Telefonos { get; set; }
        public string Correos { get; set; }
        public int OriginalId { get; set; }
    }
}
