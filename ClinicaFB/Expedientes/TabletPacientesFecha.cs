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
    public partial class TabletPacientesFecha : Form
    {
        public int PacienteId { get; set; } = 0;
        private BindingList<PacienteFecha> _pacientesFechas;
        private int _doctorId=0;
        private DateTime _fecha;
        public TabletPacientesFecha()
        {
            InitializeComponent();
        }

        private void TabletPacientesFecha_Load(object sender, EventArgs e)
        {
            _fecha = DateTime.Now;
            Doctor doctor = General.GetDoctorXUsuario();

            if (doctor == null)
            {
                MessageBox.Show("No se ha configurado el doctor para el usuario actual");
                Close();
                return;
            }
            _doctorId = (int) doctor.Doctor_Id;
            CargaPacientes();

        }


        private void CargaPacientes()
        {

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.PacientesXFecha();
                var res = db.Query<PacienteFecha>(sql, new { DoctorId = _doctorId, Fecha = _fecha }).ToList();
                _pacientesFechas = new BindingList<PacienteFecha>(res);

            }
            SetGrid();
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

            grdPacientes.ColumnCount = 2;

            grdPacientes.RowHeadersVisible = true;


            grdPacientes.ColumnHeadersDefaultCellStyle.Font = new Font(grdPacientes.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            grdPacientes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grdPacientes.Columns[0].HeaderText = "Hora";

            grdPacientes.Columns[0].DataPropertyName = "Hora";
            grdPacientes.Columns[0].Width = 100;

            grdPacientes.Columns[1].HeaderText = "Paciente";
            grdPacientes.Columns[1].DataPropertyName = "PacienteNombre";
            grdPacientes.Columns[1].Width = 200;


            grdPacientes.DataSource = _pacientesFechas;

        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdSeleccionar_Click(object sender, EventArgs e)
        {
            if (grdPacientes.CurrentRow == null)
                return;

            PacienteId = _pacientesFechas[grdPacientes.CurrentRow.Index].PacienteId;
            Close();
        }
    }
}
