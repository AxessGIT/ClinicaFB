using ClinicaFB.Helpers;
using ClinicaFB.Modelo;
using Dapper;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFB.Expedientes
{
    public partial class PacienteDatosAgenda : Form
    {
        public int PacienteID = 0;
        private bool _esAlta = false;
        private Paciente _paciente = null;

        public PacienteDatosAgenda(bool esAlta,int pacienteId)
        {
            _esAlta = esAlta;
            PacienteID = pacienteId;

            InitializeComponent();
        }

        private void PacienteDatosAgenda_Load(object sender, EventArgs e)
        {
            if (_esAlta)
            {
                _paciente = new Paciente();
                Text = "Agregar paciente";
                cboSexos.SelectedIndex = 1;
            }
            else
            {
                Text = "Modificar paciente";
                CargaPaciente();
            }

        }


        private void CargaPaciente()
        {



            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.PacienteSelect();
                _paciente = db.QuerySingleOrDefault<Paciente>(sql, new { Paciente_Id = PacienteID });

                if (_paciente != null)
                {
                    PropiedadesAControles();

                }


            }

        }


        private void PropiedadesAControles()
        {
            txtNombre.Text = _paciente.Nombres;
            txtApellidoPaterno.Text = _paciente.Apellido_Paterno;
            txtApellidoMaterno.Text = _paciente.Apellido_Materno;
            txtTelefonos.Text = _paciente.Telefonos;

            switch (_paciente.Sexo)
            {
                case "F":
                    cboSexos.SelectedIndex = 0;
                    break;
                case "M":
                    cboSexos.SelectedIndex = 1;
                    break;
                case "O":
                    cboSexos.SelectedIndex = 2;
                    break;

            }

        }


        private void ControlesAPropiedades()
        {
            _paciente.Nombres = txtNombre.Text;
            _paciente.Apellido_Paterno = txtApellidoPaterno.Text;
            _paciente.Apellido_Materno = txtApellidoMaterno.Text;
            _paciente.Telefonos = txtTelefonos.Text;

            switch (cboSexos.SelectedIndex)
            {
                case 0:
                    _paciente.Sexo = "F";
                    break;
                case 1:
                    _paciente.Sexo = "M";
                    break;
                case 2:
                    _paciente.Sexo = "O";

                    break;

            }


        }

        private void cmdCerrar_Click(object sender, EventArgs e)
        {
            if (ValidaDatos() == false)
                return;
            GuardaDatos();
            Close();

        }

        private bool ValidaDatos()
        {
            bool esValido = true;
            string cadenaErrores = "";
            if (string.IsNullOrEmpty(txtApellidoPaterno.Text))
            {
                cadenaErrores += "*Teclee el apellido paterno";
                esValido = false;

            }

            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                cadenaErrores = cadenaErrores == string.Empty ? "" : "\n";
                cadenaErrores += "*Teclee el nombre";
                esValido = false;

            }


            if (esValido == false)
            {
                MessageBox.Show(cadenaErrores, "Confirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return esValido;
        }


        private bool GuardaDatos()
        {

            ControlesAPropiedades();
            string sql = _esAlta ? Queries.PacienteAgendaInsert() : Queries.PacienteAgendaUpdate();

            using (FbConnection db = General.GetDB())
            {
                if (_esAlta)
                {
                   _paciente.UsuarioCreacionId= (int) ClinicaFB.Properties.Settings.Default.Usuario_ID;
                    _paciente.FechaHoraCreacion=DateTime.Now;

                    PacienteID = db.QuerySingle<int>(sql, _paciente);
                }
                else
                {
                    _paciente.UsuarioEdicionId = (int)ClinicaFB.Properties.Settings.Default.Usuario_ID;
                    _paciente.FechaHoraEdicion = DateTime.Now;
                    db.Execute(sql, _paciente);

                }

            }

            Close();
            return true;

        }

    }
}
