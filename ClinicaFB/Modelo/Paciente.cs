using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Modelo
{
    public class Paciente
    {
        public long Paciente_Id { get; set; }
        public string Nombres { get; set; }
        public string Apellido_Paterno { get; set; }
        public string Apellido_Materno { get; set; }
        public string Sexo { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string Telefonos { get; set; }
        public string Correos { get; set; }

        public long EdoCivilId { get; set; }
        public long OcupacionId { get; set; }
        public long ReferenteId { get; set; }
        public long CiudadOrigenId { get; set; }

        public string Direccion { get; set; }
        public string Colonia { get; set; }
        public long LocalidadId { get; set; }
        public long CiudadId { get; set; }
        public long EstadoId { get; set; }
        public long PaisId { get; set; }
        public string CP { get; set; }
        public long DiagnosticoId { get; set; }
        public long PielId { get; set; }
        public long SolarId { get; set; }
        public long MedicoId { get; set; }
        public long MaquillajeId { get; set; }
        public string Medicamentos { get; set; }
        public string Alergias { get; set; }
        public string Antecedentes { get; set; }
        public string Origen { get; set; }
        public DateTime FechaHoraCreacion { get; set; }
        public int UsuarioCreacionId { get; set; }
        public DateTime FechaHoraEdicion { get; set; }
        public int UsuarioEdicionId { get; set; }
        public string PassWord { get; set; }

        public string NombreCompleto
        {
            get
            {
                string nom = "";
                nom = Nombres == null ? "" : Nombres + " ";
                nom += Apellido_Paterno == null ? "" : Apellido_Paterno + " ";
                nom += Apellido_Materno == null ? "" : Apellido_Materno;
                return nom;
            }
        }
        public string Ubicacion
        {
            get
            {
                string or = "";
                or = String.IsNullOrEmpty(Origen)? "AGE" : Origen;
                return or;
            }

        }
    }
}
