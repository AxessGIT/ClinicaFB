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
using Dapper;
using ClinicaFB.Modelo;
using ClinicaFB.Helpers;
using ClinicaFB.ModeloConfiguracion;

namespace ClinicaFB.Configuracion
{
    public partial class DoctoresAltasCambios : Form
    {
        private int _doctorId = 0;
        private bool _esAlta = false;
        private FbConnection _db;
        private Doctor _doctor = null;
        private BindingList<Usuario> _usuarios = new BindingList<Usuario>();

        public DoctoresAltasCambios(FbConnection db,bool esAlta, int doctorId)
        {
            _db = db;
            _esAlta = esAlta;
            _doctorId = doctorId;
            InitializeComponent();
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DoctoresAltasCambios_Load(object sender, EventArgs e)
        {

            if (_esAlta)
            {
                _doctor = new Doctor();
                Text = "Agregar doctor";
            }
            else
            {
                Text = "Modificar doctor";
                CargaDoctor();
            }

            CargaUsuarios();

            if (_esAlta == false)
            {
                PonUsuario();
            }

        }


        private void CargaDoctor()
        {
            string sql = Queries.DoctorSelect();
           _doctor = _db.QuerySingleOrDefault<Doctor>(sql, new { Doctor_Id = _doctorId });

            if (_doctor!=null)
            {
                PropiedadesAControles();
                
            }
        }


        private void PropiedadesAControles()
        {
            txtNombre.Text = _doctor.Nombres;
            txtApellidoPaterno.Text = _doctor.Apellido_Paterno;
            txtApellidoMaterno.Text = _doctor.Apellido_Materno;
            txtTelefonos.Text = _doctor.Telefonos;
            txtCorreos.Text = _doctor.Correos;
            txtCedulaProfesional.Text = _doctor.CedProf;
            txtCedulaEspecialidad.Text = _doctor.CedEsp;
            txtCurriculum.Text = _doctor.Curriculum;
            chkMostrarEnConsulta.Checked = _doctor.MostrarEnConsultaAgenda;


        }
        private void PonUsuario()
        {
            if (_doctor.UsuarioId == 0)
            {
                cboUsuarios.SelectedItem = null;

            }
            else
            {
                Usuario usr = _usuarios.Where(u => u.Usuario_Id == _doctor.UsuarioId).FirstOrDefault();
                if (usr != null)
                {
                    cboUsuarios.SelectedItem = usr;
                }

            }

        }

        private void ControlesAPropiedades()
        {
            _doctor.Nombres = txtNombre.Text;
            _doctor.Apellido_Paterno= txtApellidoPaterno.Text;
            _doctor.Apellido_Materno= txtApellidoMaterno.Text;
            _doctor.Telefonos= txtTelefonos.Text;
            _doctor.Correos= txtCorreos.Text;
            _doctor.CedProf = txtCedulaProfesional.Text;
            _doctor.CedEsp  = txtCedulaEspecialidad.Text;
            _doctor.Curriculum = txtCurriculum.Text;
            _doctor.UsuarioId = Convert.ToInt32(cboUsuarios.SelectedValue);
            _doctor.MostrarEnConsultaAgenda = chkMostrarEnConsulta.Checked;

        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            if (!Validadatos())
                return;

            ControlesAPropiedades();
            string sql = _esAlta ? Queries.DoctorInsert() : Queries.DoctorUpdate();
            _db.Execute(sql, _doctor);
            Close();
            
        }

        private bool Validadatos()
        {
            string cadenaErrores = "";
            if (string.IsNullOrEmpty(txtNombre.Text.Trim()))
            {
                cadenaErrores = "* Teclee el nombre del doctor\n";
            }


            if (string.IsNullOrEmpty(txtApellidoPaterno.Text.Trim()))
            {
                cadenaErrores += "* Teclee el apellido paterno del doctor\n";
            }


            if (!string.IsNullOrEmpty(cadenaErrores))
            {
                MessageBox.Show(cadenaErrores, "Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void CargaUsuarios()
        {

           using (FbConnection db = General.GetConexionConfig())
            {
                string sql = Queries.UsuariosSelect();
                var res = db.Query<Usuario>(sql).ToList();

                _usuarios = new BindingList<Usuario>(res);

            }


            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.DoctoresUsuariosSelect();

                List<int> usuariosIds = db.Query<int>(sql).ToList<int>();


                foreach (var usrId in usuariosIds)
                {
                    Usuario usr = new Usuario();
                    
                   usr= _usuarios.Where(u=>u.Usuario_Id==usrId).FirstOrDefault();

                    if (usr != null && usr.Usuario_Id!=_doctor.UsuarioId)
                    {
                        _usuarios.Remove(usr);
                    }

                }

                cboUsuarios.DataSource = _usuarios;
                cboUsuarios.DisplayMember = "Nombre";
                cboUsuarios.ValueMember= "Usuario_Id";


            }
        }


        private void cmdQuitarUsuario_Click(object sender, EventArgs e)
        {
            cboUsuarios.SelectedValue = 0;
            cboUsuarios.SelectedItem= null;


        }
    }
}
