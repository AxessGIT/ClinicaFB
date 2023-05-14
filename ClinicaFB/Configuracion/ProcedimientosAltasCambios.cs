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
    public partial class ProcedimientosAltasCambios : Form
    {
        public int Procedimiento_Id { get; set; }
        public string Descripcion { get; set; }

        private int _procedimientoId = 0;
        private bool _esAlta = false;
        private FbConnection _db;
        private Procedimiento _procedimiento = null;

        public ProcedimientosAltasCambios(FbConnection db, bool esAlta, int procedimientoId)
        {
            _db = db;
            _esAlta = esAlta;
            _procedimientoId = procedimientoId;

            InitializeComponent();
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Procedimiento_Id = 0;
            Close();
        }

        private void ProcedimientosAltasCambios_Load(object sender, EventArgs e)
        {
            if (_esAlta)
            {
                _procedimiento = new Procedimiento();
                Text = "Agregar procedimiento";
            }
            else
            {
                Text = "Modificar procedimiento";
                CargaProcedimiento();
            }

        }


        private void CargaProcedimiento()
        {
            string sql = Queries.ProcedimientoSelect();
            _procedimiento = _db.QuerySingleOrDefault<Procedimiento>(sql, new { Procedimiento_Id = _procedimientoId });

            if (_procedimiento != null)
            {
                PropiedadesAControles();

            }
        }


        private void PropiedadesAControles()
        {
            txtDescripcion.Text = _procedimiento.Descripcion;
            txtPrecio.DecimalValue = _procedimiento.Precio;
            

        }


        private void ControlesAPropiedades()
        {
            _procedimiento.Descripcion = txtDescripcion.Text;
            _procedimiento.Precio = txtPrecio.DecimalValue;
            

        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            if (!Validadatos())
                return;

            ControlesAPropiedades();
            string sql = "";

            if (_esAlta) {
                sql = Queries.ProcedimientoInsert();
                Procedimiento_Id = _db.QuerySingle<int>(sql,_procedimiento);
                Descripcion = txtDescripcion.Text.Trim();
            }
            else
            {
                sql = Queries.ProcedimientoUpdate();
                _db.Execute(sql, _procedimiento);
            }
            Close();

        }

        private bool Validadatos()
        {
            string cadenaErrores = "";
            if (string.IsNullOrEmpty(txtDescripcion.Text.Trim()))
            {
                cadenaErrores = "* Teclee la descripción del procedimiento\n";
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
