using ClinicaFB.Helpers;
using ClinicaFB.Modelo;
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

namespace ClinicaFB.PuntoDeVenta
{
    public partial class PdV : Form
    {
        private BindingList<Almacen> _almacenes = new BindingList<Almacen>();
        private BindingList<Doctor> _doctores = new BindingList<Doctor>();

        private Color colorFondo = Color.White;
        private Color colorLetra = Color.DarkGreen;

        public PdV()
        {
            InitializeComponent();
        }

        private void PdV_Load(object sender, EventArgs e)
        {
            PonColores();
            CargaAlmacenes();
            CargaDoctores();
        }

        private void CargaAlmacenes()
        {

            int almacenIdDefa = 0;
            string nombreAlmacenDefa = "";

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.AlmacenesSelect();

                var res = db.Query<Almacen>(sql).ToList();

                foreach (var alma in res)
                {
                    if (alma.Defa)
                    {
                        almacenIdDefa = alma.AlmacenId;
                        nombreAlmacenDefa = alma.Nombre;
                        break;
                    }

                }
                _almacenes = new BindingList<Almacen>(res);



            }
            cboAlmacenes.DataSource = null;
            cboAlmacenes.DataSource = _almacenes;
            cboAlmacenes.ValueMember = "AlmacenId";
            cboAlmacenes.DisplayMember = "Nombre";
            cboAlmacenes.SelectedValue = almacenIdDefa;


        }

        private void CargaDoctores()
        {
            int doctorIdDefa = 0;

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.DoctoresSelect();

                var res = db.Query<Doctor>(sql).ToList();

                if (res.Count == 0)
                {
                    return;
                }

                _doctores = new BindingList<Doctor>(res);
                doctorIdDefa = doctorIdDefa == 0 ? (int) _doctores[0].Doctor_Id : doctorIdDefa;
            }
            cboDoctores.DataSource = null;
            cboDoctores.DataSource = _doctores;
            cboDoctores.ValueMember = "Doctor_Id";
            cboDoctores.DisplayMember = "NombreCompleto";
            cboDoctores.SelectedValue = 0;//doctorIdDefa;

        }


        private void PonColores()
        {
            txtRFC.BackColor = colorFondo;
            txtRFC.ForeColor = colorLetra;

            txtRazonSocial.BackColor = colorFondo;
            txtRazonSocial.ForeColor = colorLetra;


        }

        private void cmdClienteBuscar_Click(object sender, EventArgs e)
        {
            PonColores();
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PdV_Shown(object sender, EventArgs e)
        {
            txtConcepto.Focus();

        }
    }
}
