using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Agenda
{
    public class CeldaDatos
    {
        public int SucursalId { get; set; }
        public string TipoRecurso { get; set; }
        public int RecursoID { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public int PacienteID { get; set; }
        public string NombrePaciente { get; set; }
        public string Observaciones { get; set; }
    }

}
