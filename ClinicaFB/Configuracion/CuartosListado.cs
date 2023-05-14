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
    public partial class CuartosListado : Form
    {
        private FbConnection _db = null;
        private BindingList<Cuarto> _cuartos = null;

        public CuartosListado(FbConnection db)
        {
            _db = db;
            InitializeComponent();
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CuartosListado_Load(object sender, EventArgs e)
        {
            CargaCuartos();
            SetGrid();
        }

        private void CargaCuartos()
        {

            string sql = Helpers.Queries.CuartosSelect();
            var res = _db.Query<Cuarto>(sql).ToList();
            _cuartos = new BindingList<Cuarto>(res);
        }

        private void SetGrid()
        {
            grdCuartos.DataSource = null;



            grdCuartos.AllowUserToAddRows = false;
            grdCuartos.AllowUserToDeleteRows = false;


            grdCuartos.AutoGenerateColumns = false;
            grdCuartos.ReadOnly = true;
            grdCuartos.AllowUserToResizeColumns = false;
            grdCuartos.AllowUserToResizeRows = false;

            grdCuartos.ColumnCount = 1;

            grdCuartos.RowHeadersVisible = true;


            grdCuartos.ColumnHeadersDefaultCellStyle.Font = new Font(grdCuartos.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            grdCuartos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grdCuartos.Columns[0].HeaderText = "Cuarto";

            grdCuartos.Columns[0].DataPropertyName = "Nombre";
            grdCuartos.Columns[0].Width = 200;
            grdCuartos.DataSource = _cuartos;

        }


        private void AltasCambios(bool esAlta)
        {

            int id = 0;
            if (esAlta == false)
            {
                id = (int)_cuartos[grdCuartos.CurrentRow.Index].Cuarto_Id;
            }
            CuartosAltasCambios cuaAC = new CuartosAltasCambios(_db, esAlta, id);
            cuaAC.ShowDialog();

            CargaCuartos();
            SetGrid();


        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            AltasCambios(true);
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            if (grdCuartos.CurrentRow==null)
            {
                MessageBox.Show("Seleccione un cuarto","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;

            }
            AltasCambios(false);
        }

        private void grdCuartos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            AltasCambios(false);
        }
    }
}
