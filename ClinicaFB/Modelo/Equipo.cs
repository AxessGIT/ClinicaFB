using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Modelo
{
    public class Equipo
    {
        public long Equipo_Id { get; set; }
        public string Nombre { get; set; }
        public bool MostrarEnConsultaAgenda { get; set; }
    }
}
