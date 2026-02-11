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
        public string SerieFacGlobal { get; set; }
        public int FolioFacGlobal { get; set; }
        public string SerieFacPDV { get; set; }
        public int FolioFacPDV { get; set; }
        public string SerieVentas { get; set; }
        public int FolioVentas { get; set; }
        public string CarpetaReportes { get; set; }
        public string CarpetaImagenes { get; set; }
        public string SerieNC { get; set; }
        public int FolioNC { get; set; }
        public string SeriePagos { get; set; }
        public int FolioPagos { get; set; }

    }
}
