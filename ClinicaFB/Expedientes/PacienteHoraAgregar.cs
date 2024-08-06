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
    public partial class PacienteHoraAgregar : Form
    {
        private int _doctorId;
        private DateTime _fecha;
        private BindingList<Paciente> _pacientes = null;
        public PacienteHoraAgregar(int doctorId, string nombreDoctor, DateTime fecha)
        {
            InitializeComponent();
            lblDoctor.Text = nombreDoctor;
            lblFecha.Text = fecha.ToLongDateString();
            _doctorId = doctorId;
            _fecha = fecha;
        }

        private void PacienteHoraAgregar_Load(object sender, EventArgs e)
        {
            CargaHoras();
        }

        private void CargaHoras()
        {
            General.LlenaComboHoras(ref cboHoras);
            cboHoras.SelectedIndex = 0;
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

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargaPacientes();
                SetGrid();
            }
        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            if (grdPacientes.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un paciente");
                return;
            }

            int pacienteId = (int)_pacientes[grdPacientes.CurrentRow.Index].Paciente_Id;
            string hora = cboHoras.Text;

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.PacienteFechaInsert();
                db.Execute(sql, new { PacienteId = pacienteId, DoctorId = _doctorId, Fecha = _fecha, Hora = hora });
            }
            Close();
        }
    }
}
