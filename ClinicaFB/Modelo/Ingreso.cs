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
        public string Tipo { get; set; }
        public int SucursalId { get; set; }
        public string Serie { get; set; }
        public int Folio { get; set; }
        public int PacienteId { get; set; }
        public string PacienteNombre { get; set; }
        public int RazonSocialId { get; set; }
        public string CveFOP { get; set; }
        public string CveMEP { get; set; }
        public string CveUSO { get; set; }
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
        public string WebId { get; set; }
        public string NomPac
        {
            get { return string.IsNullOrEmpty(PacienteNombre) ? "PUBLICO EN GENERAL" : PacienteNombre; }
        }
        public string NomRazon
        {
            get { return string.IsNullOrEmpty(RazonSoc) ? "PUBLICO EN GENERAL" : RazonSoc; }
        }
    }
}
