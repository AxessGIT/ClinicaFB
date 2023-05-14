using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Modelo
{
    public class Receta
    {
        public int PacienteRecetaId { get; set; }
        public string PacienteNombre { get; set; }
        public int PacienteId { get; set; }
        public DateTime Fecha { get; set; }
        public string Texto { get; set; }
        public string Etiquetas { get; set; }
        public int UsuarioId { get; set; }

        public string FechaLarga
        {
            get
            {
                
                return Fecha.ToLongDateString();
            }
        }

    }
}
