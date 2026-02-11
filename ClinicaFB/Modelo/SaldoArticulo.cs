using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Modelo
{
    public class SaldoArticulo
    {
        public long ArticuloId { get; set; }
        public int Anio { get; set; }
        public int Mes { get; set; }
        public decimal Entradas { get; set; }
        public decimal Salidas { get; set; }

        public decimal CostoEntradas { get; set; }
        public decimal Saldo { get { return Entradas - Salidas; } }
    }
}
