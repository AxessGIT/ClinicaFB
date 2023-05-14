using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Modelo
{
    public class RazonSocial
    {
        public int RazonSocialId { get; set; }
        public string RFC { get; set; }
        public string RazonSoc { get; set; }
        public string Direccion { get; set; }
        public int LocalidadId { get; set; }
        public int CiudadId { get; set; }
        public int EstadoId { get; set; }
        public int PaisId { get; set; }
        public string CP { get; set; }
        public string CveREF { get; set; }
        public string CveUSO { get; set; }
        public string CveFOP { get; set; }
        public string CveMEP { get; set; }
        public string Email { get; set; }
    }
}
