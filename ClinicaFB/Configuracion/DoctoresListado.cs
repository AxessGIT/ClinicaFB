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
using ClinicaFB.Helpers;

namespace ClinicaFB.Configuracion
{
    public partial class DoctoresListado : Form
    {
        private FbConnection _db = null;
        private BindingList<Doctor> _doctores=null;
        public DoctoresListado(FbConnection db)
        {
            _db = db;
            InitializeComponent();
        }

        private void DoctoresListado_Load(object sender, EventArgs e)
        {
            CargaDoctores();
            SetGrid();
        }

        private void CargaDoctores()
        {

            string sql = Helpers.Queries.DoctoresSelect();

            var res = _db.Query<Doctor>(sql).ToList();
            _doctores = new BindingList<Doctor>(res);
        }

        private void SetGrid()
        {
            grdDoctores.DataSource = null;


            
            grdDoctores.AllowUserToAddRows = false;
            grdDoctores.AllowUserToDeleteRows = false;
            

            grdDoctores.AutoGenerateColumns = false;
            grdDoctores.ReadOnly = true;
            grdDoctores.AllowUserToResizeColumns = false;
            grdDoctores.AllowUserToResizeRows = false;

            grdDoctores.ColumnCount = 3;

            grdDoctores.RowHeadersVisible = true;


            grdDoctores.ColumnHeadersDefaultCellStyle.Font = new Font(grdDoctores.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            grdDoctores.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grdDoctores.Columns[0].HeaderText = "Nombre";

            grdDoctores.Columns[0].DataPropertyName = "NombreCompleto";
            grdDoctores.Columns[0].Width = 200;

            grdDoctores.Columns[1].HeaderText = "Teléfonos";
            grdDoctores.Columns[1].DataPropertyName = "Telefonos";
            grdDoctores.Columns[1].Width = 180;

            grdDoctores.Columns[2].HeaderText = "Correos";
            grdDoctores.Columns[2].DataPropertyName = "Correos";
            grdDoctores.Columns[2].Width = 180;

            grdDoctores.DataSource = _doctores;

        }


        private void AltasCambios(bool esAlta)
        {

            int id = 0;
            if (esAlta==false)
            {
                id = (int) _doctores[grdDoctores.CurrentRow.Index].Doctor_Id;
            }
            DoctoresAltasCambios docAC = new DoctoresAltasCambios(_db, esAlta, id);
            docAC.ShowDialog();

            CargaDoctores();
            SetGrid();


        }
        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void grdDoctores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 && e.ColumnIndex<0)
                return;

            AltasCambios(false);


        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            AltasCambios(true);
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            if (grdDoctores.CurrentRow==null)
            {
                MessageBox.Show("Seleccione un doctor para modificar","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            AltasCambios(false);
        }

        private void cmdEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}
