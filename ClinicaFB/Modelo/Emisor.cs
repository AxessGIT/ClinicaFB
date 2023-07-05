using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Modelo
{
    internal class Emisor
    {
        public int EmisorId { get; set; }
        public string RFC { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Colonia { get; set; }
        public int CiudadId { get; set; }
        public int EstadoId { get; set; }
        public int PaisId { get; set; }
        public string CP { get; set; }
        public string CveRef { get; set; }
        public string Certificado { get; set; }
        public string LlavePrivada { get; set; }
        public string PassWord { get; set; }
        public bool Defa { get; set; }
        public bool PDV { get; set; }

    }
}
