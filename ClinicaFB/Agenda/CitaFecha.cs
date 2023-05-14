using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Agenda
{
    public class CitaFecha
    {
        public int Cita_id { get; set; }
        public int SucursalId { get; set; }
        public string TipoRecurso { get; set; }
        public int Recurso_Id { get; set; }
        public string Hora { get; set; }
        public string Nombres { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string BloqueoMotivo{ get; set; }
        public bool Bloqueada { get; set; }
        public int BloqueoMotivo_Id { get; set; }
        public bool Confirmado { get; set; }
        public bool Asistio { get; set; }

        public string NombreCompletoPaciente
        {
            get
            {
                string nom = "";
                nom = Nombres == null ? "" : Nombres + " ";
                nom += Apellido_Paterno == null ? "" : Apellido_Paterno + " ";
                nom += Apellido_Materno == null ? "" : Apellido_Materno;
                return nom;
            }

        }

    }
}
