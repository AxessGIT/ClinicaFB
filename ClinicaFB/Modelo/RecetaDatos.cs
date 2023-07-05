using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Modelo
{
    public class RecetaDatos
    {
        public string DoctorNombre { get; set; } = "";
        public string DoctorCedulaProf { get; set; } = "";
        public string DoctorCedulaEsp { get; set; } = "";
        public string DoctorCV { get; set; } = "";
        public string Fecha { get; set; }
        public string PacienteNombre { get; set; } = "";
        public string PacienteEdad { get; set; } = "";
        public string PacienteDireccion { get; set; } = "";
        public string Indicaciones { get; set; }
    }
}
