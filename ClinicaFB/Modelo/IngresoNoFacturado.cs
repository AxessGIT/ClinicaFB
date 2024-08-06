using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Modelo
{
    public class IngresoNoFacturado
    {
        public int CfdiEmisorId { get; set; }
        public int CfdiId { get; set; }
        public string Serie { get; set; }
        public int Folio { get; set; }
        public int IngresoId { get; set; }
        public string TicketSerie { get; set; }
        public int TicketFolio { get; set; }
        public DateTime Fecha { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Total { get; set; }

    }
}
