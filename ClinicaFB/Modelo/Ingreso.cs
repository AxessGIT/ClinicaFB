using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Modelo
{
    public class Ingreso
    {
        public int IngresoId { get; set; }
        public int SucursalId { get; set; }
        public string Serie { get; set; }
        public int Folio { get; set; }
        public int PacienteId { get; set; }
        public string NombrePaciente { get; set; }
        public int RazonSocialId { get; set; }
        public string RazonSoc { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Descuento { get; set; }
        public decimal RetIVA { get; set; }
        public decimal RetISR { get; set; }
        public decimal Total { get; set; }
        public bool Cancelado { get; set; }
        public decimal Pago1 { get; set; }
        public decimal Pago2 { get; set; }
        public decimal Pago3 { get; set; }
        public decimal Pago4 { get; set; }
        public decimal Pago5 { get; set; }
        public decimal Pago6 { get; set; }
        public decimal Pago7 { get; set; }
        public decimal Pago8 { get; set; }
        public decimal Pago9 { get; set; }
        public decimal Pago10 { get; set; }
        public string WebId { get; set; }
    }
}
