using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Modelo
{
    public class Sucursal
    {
        public int SucursalId { get; set; }
        public string Nombre { get; set; }
        public string DatosAdicionales { get; set; }
        public string SerieIngresos { get; set; }
        public int FolioIngresos { get; set; }
    }
}
