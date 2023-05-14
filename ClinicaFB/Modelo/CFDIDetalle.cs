using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.Rest.Api.V2010.Account.Sip.Domain.AuthTypes.AuthTypeCalls;

namespace ClinicaFB.Modelo
{
    public class CFDIDetalle
    {
        public int CFDIDetId { get; set; }
        public int CFDIId { get; set; }
        public int ArticuloId { get; set; }
        public string NoIden { get; set; }
        public string Descripcion { get; set; }
        public string UDM { get; set; }
        public decimal Cantidad { get; set; }
        public decimal ValorUnitario { get; set; }
        public string CveProSer { get; set; }
        public string CveUni { get; set; }
        public decimal SubTotal 
        {
            get { 
                return Math.Round(Cantidad*ValorUnitario,2,MidpointRounding.AwayFromZero);
            } 
        }

        public decimal Descuento { get; set; } = 0;
        public decimal TasaIVA { get; set; } = 0;
        public string TipoIVA { get; set; }
        public decimal IVA { get; set; } = 0;
        public decimal RetIVA { get; set; } = 0;
        public decimal RetISR { get; set; } = 0;

        public decimal Total
        {
            get
            {
                return SubTotal-Descuento+IVA-RetIVA-RetISR;
            }
        }


    }
}
