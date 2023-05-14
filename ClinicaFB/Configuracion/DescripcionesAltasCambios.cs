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
    public partial class DescripcionesAltasCambios : Form
    {
        private FbConnection _db;
        private bool _esAlta;
        private string _tipo;
        private DescripcionCat _descripcion;
        public int Descripcion_Id { get; set;}
        public string Descripcion { get; set; }

        public DescripcionesAltasCambios(string tipo, FbConnection db, bool esAlta, int descripcionId)
        {
            _tipo = tipo;
            _db = db;
            _esAlta = esAlta;
            Descripcion_Id = descripcionId;
            InitializeComponent();
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Descripcion_Id = 0;
            Descripcion = "";
            Close();
        }

        private void DescripcionAgregarModificar_Load(object sender, EventArgs e)
        {
            Text = _esAlta ? "Agregar " : "Modificar ";

            switch (_tipo)
            {
                case "INS":
                    Text += "instrucción";
                    break;
                case "BLO":
                    Text += "Motivo de bloqueo";
                    break;
                case "MOC":
                    Text += "Motivo de cancelación";
                    break;
                case "MAR":
                    Text += "Marca";
                    break;
                case "LIN":
                    Text += "Línea";
                    break;

            }
            lblLetrero.Text = Text;
            if (_esAlta)
            {
                _descripcion = new DescripcionCat();
            }
            else
            {
                CargaDescripcion();
            }

        }


        private void CargaDescripcion()
        {
            string sql = Queries.DescripcionSelect();
            _descripcion = _db.QuerySingleOrDefault<DescripcionCat>(sql, new { Descripcion_Id = Descripcion_Id });

            if (_descripcion != null)
            {
                PropiedadesAControles();

            }
        }


        private void PropiedadesAControles()
        {
            txtDescripcion.Text = _descripcion.Descripcion;


        }


        private void ControlesAPropiedades()
        {
            _descripcion.Tipo = _tipo;
            _descripcion.Descripcion = txtDescripcion.Text;
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            if (!Validadatos())
                return;

            ControlesAPropiedades();
            string sql = _esAlta ? Queries.DescripcionInsert() : Queries.DescripcionUpdate();

            if(_esAlta)
            {
                Descripcion_Id = _db.QuerySingle<int>(sql, _descripcion);
            }                
            else { 
                _db.Execute(sql, _descripcion);
            }

            Descripcion = txtDescripcion.Text.Trim();

            Close();

        }

        private bool Validadatos()
        {
            string cadenaErrores = "";
            if (string.IsNullOrEmpty(txtDescripcion.Text.Trim()))
            {
                cadenaErrores = "* Teclee la descripción \n";
            }

            if (!string.IsNullOrEmpty(cadenaErrores))
            {
                MessageBox.Show(cadenaErrores, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

    }
}
