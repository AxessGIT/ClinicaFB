using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;

namespace ClinicaFB.Modelo
{
    public class ArticuloImportar
    {
        [Name(name: "codigo")]
        public string Codigo { get; set; }

        [Name(name: "nombre")]
        public string Nombre { get; set; }

        [Name(name: "precio")]
        public decimal Precio { get; set; }

        [Name(name: "impuesto")]
        public decimal Impuesto { get; set; }
    }
}
