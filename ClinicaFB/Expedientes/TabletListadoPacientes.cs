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

namespace ClinicaFB.Expedientes
{
    public partial class TabletListadoPacientes : Form
    {
        private BindingList<Paciente> _pacientes = null;

        public TabletListadoPacientes()
        {
            InitializeComponent();
        }

        private void TabletListadoPacientes_Load(object sender, EventArgs e)
        {

        }


        private void CargaPacientes()
        {

            string sql = "";

            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
                sql = Helpers.Queries.PacientesSelect(true);
            else
                sql = Helpers.Queries.PacientesSelectBuscar(txtBuscar.Text.Trim());


            using (FbConnection db = General.GetDB())
            {
                var res = db.Query<Paciente>(sql, new { Origen = "EXP" }).ToList();
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

            grdPacientes.ColumnCount = 1;

            grdPacientes.RowHeadersVisible = true;


            grdPacientes.ColumnHeadersDefaultCellStyle.Font = new Font(grdPacientes.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            grdPacientes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grdPacientes.Columns[0].HeaderText = "Nombre";

            grdPacientes.Columns[0].DataPropertyName = "NombreCompleto";
            grdPacientes.Columns[0].Width = 600;


            grdPacientes.DataSource = _pacientes;

        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            CargaPacientes();
            SetGrid();

        }

        private void cmdVer_Click(object sender, EventArgs e)
        {
            if (grdPacientes.CurrentRow==null)
                return;

            int pacienteId = (int) _pacientes[grdPacientes.CurrentRow.Index].Paciente_Id;
            TabletPacienteVer tabletPacienteVer = new TabletPacienteVer(pacienteId);
            tabletPacienteVer.Text = _pacientes[grdPacientes.CurrentRow.Index].NombreCompleto;
            tabletPacienteVer.lblNombrePaciente.Text= _pacientes[grdPacientes.CurrentRow.Index].NombreCompleto;

            tabletPacienteVer.Show();
        }

        private void grdPacientes_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cmdVer_Click(sender, e);
        }
    }
}
