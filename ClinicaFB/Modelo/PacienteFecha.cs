using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Modelo
{
    public class PacienteFecha
    {
        public int PacienteFechaId { get; set; }
        public int DoctorId { get; set; }
        public string DoctorNombre { get; set; }
        public DateTime Fecha { get; set; }
        public int PacienteId { get; set; }
        public string PacienteNombre { get; set; }

        public string Hora { get; set; }

    }
}
