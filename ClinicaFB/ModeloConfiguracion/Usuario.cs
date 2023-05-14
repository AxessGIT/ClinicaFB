using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.ModeloConfiguracion
{
    public class Usuario
    {
        public Int64 Usuario_Id { get; set; }
        public string Usr { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public bool ConsultaAgenda { get; set; }
        public int SucursalId { get; set; }
    }
}
