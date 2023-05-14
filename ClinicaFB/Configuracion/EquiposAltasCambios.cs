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

namespace ClinicaFB.Configuracion
{
    public partial class EquiposAltasCambios : Form
    {
        private int _equipoId = 0;
        private bool _esAlta = false;
        private FbConnection _db;
        private Equipo _equipo = null;

        public EquiposAltasCambios(FbConnection db,bool esAlta, int equipoId)
        {
            _db = db;
            _esAlta = esAlta;
            _equipoId = equipoId;
            InitializeComponent();
        }

        private void EquiposAltasCambios_Load(object sender, EventArgs e)
        {
            if (_esAlta)
            {
                _equipo = new Equipo();
                Text = "Agregar equipo";
            }
            else
            {
                Text = "Modificar equipo";
                CargaEquipo();
            }

        }


        private void CargaEquipo()
        {
            string sql = Queries.EquipoSelect();
            _equipo = _db.QuerySingleOrDefault<Equipo>(sql, new { Equipo_Id = _equipoId });

            if (_equipo != null)
            {
                PropiedadesAControles();

            }
        }


        private void PropiedadesAControles()
        {
            txtNombre.Text = _equipo.Nombre;
            chkMostrarEnConsulta.Checked = _equipo.MostrarEnConsultaAgenda;

        }


        private void ControlesAPropiedades()
        {
            _equipo.Nombre = txtNombre.Text;
            _equipo.MostrarEnConsultaAgenda= chkMostrarEnConsulta.Checked;

        }


        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }



        private bool Validadatos()
        {
            string cadenaErrores = "";
            if (string.IsNullOrEmpty(txtNombre.Text.Trim()))
            {
                cadenaErrores = "* Teclee el nombre del equipo\n";
            }

            if (!string.IsNullOrEmpty(cadenaErrores))
            {
                MessageBox.Show(cadenaErrores, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            if (!Validadatos())
                return;

            ControlesAPropiedades();
            string sql = _esAlta ? Queries.EquipoInsert() : Queries.EquipoUpdate();
            _db.Execute(sql, _equipo);
            Close();

        }
    }
}
