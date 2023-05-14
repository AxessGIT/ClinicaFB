using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.ModeloWEB
{
    public class CitaWEB
    {
        public long CitaId { get; set; }
        public long CitaInicialId { get; set; }

        public string TipoRecurso { get; set; }
        public long RecursoId { get; set; }
        public string RecursoNombre { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public long PacienteId { get; set; }
        public string PacienteNombre { get; set; }
        public string PacienteSexo { get; set; }
        public DateTime PacienteFechaNac { get; set; }

        public string Observaciones { get; set; }

        public bool Cancelada { get; set; }
        public long CancelacionMotivoId { get; set; }

        public string CancelacionMotivo { get; set; }
        public bool Bloqueada { get; set; }
        public long BloqueoMotivoId { get; set; }
        public string BloqueoMotivo { get; set; }

        public bool Confirmado { get; set; }
        public bool Asistio { get; set; }
        public long OriginalId { get; set; }

        public string Estatus { get; set; }



    }
}
