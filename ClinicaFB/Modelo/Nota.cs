using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Modelo
{
    public class Nota
    {
        public long NotaId { get; set; }
        public long PacienteId { get; set; }
        public DateTime Fecha{ get; set; }
        public string Texto { get; set; }
        public DateTime FechaHoraCreacion { get; set; }
        public int UsuarioCreacionId { get; set; }
        public DateTime FechaHoraEdicion { get; set; }
        public int UsuarioEdicionId { get; set; }

    }
}
