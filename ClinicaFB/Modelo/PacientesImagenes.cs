using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Modelo
{
    public class PacientesImagenes
    {
        public int PacImId { get; set; }
        public int PacienteId { get; set;}
        public string RutaImagen { get; set; }
        public byte[] Imagen { get; set; }
        public DateTime Fecha { get; set; }
        public int DiagnosticoId { get; set; }
        public string Diagnostico { get; set; }
        public string PalabrasClave { get; set; }
    }
}
