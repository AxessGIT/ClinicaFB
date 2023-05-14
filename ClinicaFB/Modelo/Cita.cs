using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Modelo
{
    public class Cita
    {
        public long Cita_Id { get; set; }
        public long Cita_Origen_Id { get; set; }
        public long SucursalId { get; set; }
        public string TipoRecurso { get; set; }
        public long Recurso_Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public long Paciente_Id { get; set; }
        public string Observaciones { get; set; }

        public long UsuarioAlta { get; set; }
        public DateTime FechaHoraAlta { get; set; }

        public long UsuarioModificacion { get; set; }
        public DateTime FechaHoraModificacion { get; set; }
        public bool Cancelada { get; set; }
        public long CancelacionMotivo_Id { get; set; }
        public long UsuarioCancelacion { get; set; }
        public DateTime FechaHoracancelacion { get; set; }

        public bool Bloqueada { get; set; }
        public long BloqueoMotivo_Id { get; set; }
        public string ColorCitaLetra { get; set; }
        public string ColorCitaFondo { get; set; }

        public bool Confirmado { get; set; }
        public bool Asistio { get; set; }

    }
}
