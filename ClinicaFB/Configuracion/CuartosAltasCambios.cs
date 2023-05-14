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
    public partial class CuartosAltasCambios : Form
    {
        private int _cuartoId = 0;
        private bool _esAlta = false;
        private FbConnection _db;
        private Cuarto  _cuarto = null;

        public CuartosAltasCambios(FbConnection db, bool esAlta, int cuartoId)
        {

            _db = db;
            _esAlta = esAlta;
            _cuartoId = cuartoId;

            InitializeComponent();
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CuartosAltasCambios_Load(object sender, EventArgs e)
        {
            if (_esAlta)
            {
                _cuarto = new Cuarto();
                Text = "Agregar cuarto";
            }
            else
            {
                Text = "Modificar cuarto";
                CargaCuarto();
            }

        }


        private void CargaCuarto()
        {
            string sql = Queries.CuartoSelect();
            _cuarto = _db.QuerySingleOrDefault<Cuarto>(sql, new { Cuarto_Id = _cuartoId });

            if (_cuarto != null)
            {
                PropiedadesAControles();

            }
        }


        private void PropiedadesAControles()
        {
            txtNombre.Text = _cuarto.Nombre;
            chkMostrarEnConsulta.Checked = _cuarto.MostrarEnConsultaAgenda;

        }


        private void ControlesAPropiedades()
        {
            _cuarto.Nombre = txtNombre.Text;
            _cuarto.MostrarEnConsultaAgenda = chkMostrarEnConsulta.Checked;

        }


        private bool Validadatos()
        {
            string cadenaErrores = "";
            if (string.IsNullOrEmpty(txtNombre.Text.Trim()))
            {
                cadenaErrores = "* Teclee el nombre del cuarto\n";
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
            string sql = _esAlta ? Queries.CuartoInsert() : Queries.CuartoUpdate();
            _db.Execute(sql, _cuarto);
            Close();

        }
    }
}
