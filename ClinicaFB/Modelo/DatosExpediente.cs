using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Modelo
{
    public class DatosExpediente
    {
        public int PacienteID { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string Edad { get; set; }
        public string EdoCivil { get; set; }
        public string Ocupacion { get; set; }
        public string Referente { get; set; }
        public string CiudadOri { get; set; }
        public string Direccion { get; set; }
        public string Colonia { get; set; }
        public string Localidad { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string CP { get; set; }
        public string Diagnostico { get; set; }
        public string Piel { get; set; }
        public string ExpSolar { get; set; }
        public string Medico { get; set; }
        public string Maquillaje { get; set; }
        public string Medicamentos { get; set; }
        public string Alergias { get; set; }

        public string Antecedentes { get; set; }
        public string Origen { get; set; }
        public string Telefonos { get; set; }
        public string Correos { get; set; }




    }
}
