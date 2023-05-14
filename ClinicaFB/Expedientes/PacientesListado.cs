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

namespace ClinicaFB.Expedientes
{
    public partial class PacientesListado : Form
    {
        private BindingList<Paciente> _pacientes = null;

        public PacientesListado()
        {
            InitializeComponent();
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void CargaPacientes()
        {

            string sql = "";

            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
                sql = Helpers.Queries.PacientesSelect();
            else
                sql = Helpers.Queries.PacientesSelectBuscar(txtBuscar.Text.Trim());


            using (FbConnection db = General.GetDB())
            {
                var res = db.Query<Paciente>(sql, new {Origen="EXP"}).ToList();
                _pacientes = new BindingList<Paciente>(res);

            }

        }

        private void SetGrid()
        {
            grdPacientes.DataSource = null;



            grdPacientes.AllowUserToAddRows = false;
            grdPacientes.AllowUserToDeleteRows = false;


            grdPacientes.AutoGenerateColumns = false;
            grdPacientes.ReadOnly = true;
            grdPacientes.AllowUserToResizeColumns = false;
            grdPacientes.AllowUserToResizeRows = false;

            grdPacientes.ColumnCount = 4;

            grdPacientes.RowHeadersVisible = true;


            grdPacientes.ColumnHeadersDefaultCellStyle.Font = new Font(grdPacientes.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            grdPacientes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grdPacientes.Columns[0].HeaderText = "Nombre";

            grdPacientes.Columns[0].DataPropertyName = "NombreCompleto";
            grdPacientes.Columns[0].Width = 300;

            grdPacientes.Columns[1].HeaderText = "Teléfonos";
            grdPacientes.Columns[1].DataPropertyName = "Telefonos";
            grdPacientes.Columns[1].Width = 180;

            grdPacientes.Columns[2].HeaderText = "Correos";
            grdPacientes.Columns[2].DataPropertyName = "Correos";
            grdPacientes.Columns[2].Width = 180;

            grdPacientes.Columns[3].HeaderText = "Ubicación";
            grdPacientes.Columns[3].DataPropertyName = "Ubicacion";
            grdPacientes.Columns[3].Width = 80;

            grdPacientes.DataSource = _pacientes;

        }


        private void AltasCambios(bool esAlta)
        {


            int id = 0;

            if (esAlta == false)
            {
                id = (int)_pacientes[grdPacientes.CurrentRow.Index].Paciente_Id;
            }

            PacientesAltasCambios pacAC = new PacientesAltasCambios(esAlta, id);
            pacAC.Show();

            CargaPacientes();
            SetGrid();


        }

        private void PacientesListado_Load(object sender, EventArgs e)
        {
        }

        private void grdPacientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            AltasCambios(false);
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            PacienteBuscar pacBus = new PacienteBuscar();
            pacBus.ShowDialog();
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {

        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            AltasCambios(true);
        }

        private void cmdBuscar_Click_1(object sender, EventArgs e)
        {
            CargaPacientes();
            SetGrid();
        }

        private void cmdEliminar_Click(object sender, EventArgs e)
        {

        }

        private void cmdVer_Click(object sender, EventArgs e)
        {
            if (grdPacientes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un paciente","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            AltasCambios(false);
        }
    }
}
