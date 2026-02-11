using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Modelo
{
    public class FormaPagoTotal
    {

        public int FormaPago { get; set; }

        public int Tipo { get; set; }

        public string TipoNombre
        {
            get
            {
                switch (Tipo)
                {
                    case 1:
                        return "Efectivo";
                    case 2:
                        return "Tarjeta debito";
                    case 3:
                        return "Transferencia";
                    case 4:
                        return "Tarjeta crédito";
                    case 5:
                        return "Cheque";
                    case 6:
                        return "Intermediarios";
                    default:
                        return "Otro";

                }
            }
        }

        public decimal Cambio { get; set; }


        public decimal Total { get; set; }



    }
}
