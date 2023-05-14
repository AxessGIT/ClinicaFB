using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Modelo
{
    public class Doctor
    {
        public Int64 Doctor_Id { get; set; }
        public string Nombres { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string Telefonos { get; set; }
        public string Correos { get; set; }
        public string CedProf { get; set; }
        public string CedEsp { get; set; }
        public string Curriculum { get; set; }
        public int UsuarioId { get; set; }
        public bool MostrarEnConsultaAgenda { get; set; }

        public string NombreCompleto {
            get { return $"{Nombres.Trim()} {Apellido_Paterno.Trim()} {Apellido_Materno.Trim()}"; }
        }
    }


}
