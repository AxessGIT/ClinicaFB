using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Modelo
{
    public class Parametro
    {
        public int Parametro_Id { get; set; }
        public string SysPassword { get; set; }
        public string ColorCitaLetra { get; set; }
        public string ColorCitaFondo { get; set; }
        public string ColorMultipleLetra { get; set; }
        public string ColorMultipleFondo { get; set; }

        public string ColorBloqueoLetra { get; set; }
        public string ColorBloqueoFondo { get; set; }

        public string ColorConfirmadoLetra { get; set; }
        public string ColorConfirmadoFondo { get; set; }

        public string ColorAsistioLetra { get; set; }
        public string ColorAsistioFondo { get; set; }

    }
}
