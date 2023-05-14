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

namespace ClinicaFB.Configuracion
{
    public partial class EquiposListado : Form
    {
        private FbConnection _db = null;
        private BindingList<Equipo> _equipos = null;

        public EquiposListado(FbConnection db)
        {
            _db = db;
            InitializeComponent();
        }

        private void EquiposListado_Load(object sender, EventArgs e)
        {
            CargaEquipos();
            SetGrid();
        }

        private void CargaEquipos()
        {

            string sql = Helpers.Queries.EquiposSelect();
            var res = _db.Query<Equipo>(sql).ToList();
            _equipos = new BindingList<Equipo>(res);
        }

        private void SetGrid()
        {
            grdEquipos.DataSource = null;



            grdEquipos.AllowUserToAddRows = false;
            grdEquipos.AllowUserToDeleteRows = false;


            grdEquipos.AutoGenerateColumns = false;
            grdEquipos.ReadOnly = true;
            grdEquipos.AllowUserToResizeColumns = false;
            grdEquipos.AllowUserToResizeRows = false;

            grdEquipos.ColumnCount = 1;

            grdEquipos.RowHeadersVisible = true;


            grdEquipos.ColumnHeadersDefaultCellStyle.Font = new Font(grdEquipos.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            grdEquipos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grdEquipos.Columns[0].HeaderText = "Equipo";

            grdEquipos.Columns[0].DataPropertyName = "Nombre";
            grdEquipos.Columns[0].Width = 200;
            grdEquipos.DataSource = _equipos;

        }


        private void AltasCambios(bool esAlta)
        {

            int id = 0;
            if (esAlta == false)
            {
                id = (int)_equipos[grdEquipos.CurrentRow.Index].Equipo_Id;
            }
            EquiposAltasCambios equAC = new EquiposAltasCambios(_db, esAlta, id);
            equAC.ShowDialog();

            CargaEquipos();
            SetGrid();


        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            if (grdEquipos.CurrentRow == null){
                MessageBox.Show("Seleccione un equipo a modificar","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;

            }

            AltasCambios(false);
        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            AltasCambios(true);
        }

        private void grdEquipos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            AltasCambios(false);
        }

        private void grdEquipos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
