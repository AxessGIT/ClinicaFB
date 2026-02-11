using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Modelo
{
    public class FormaPago
    {
        public int FormaPagoId { get; set; }
        public int Tipo { get; set; }
        public string Nombre { get; set; }
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
                    default:
                        return "Otro";

                }
            }
        }
        public string CveFOP { get; set; }
        public bool Todos { get; set; }
    }
}
