using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Agenda
{
    public class DatosReporte
    {
        public int Cita_Id { get; set; }
        public string Tipo { get; set; }
        public int Recurso_Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public string Nombres { get; set; }
        public int PacienteId { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string Telefonos { get; set; }
        public string Sexo { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public bool Bloqueada { get; set; }
        public string Motivo { get; set; }
        public int UsuarioCancelacion_Id { get; set; }
        public string UsuarioCancelacion_Nombre { get; set; }

    }
}
