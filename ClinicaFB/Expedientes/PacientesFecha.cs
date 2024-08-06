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

namespace ClinicaFB.Expedientes
{
    public partial class PacientesFecha : Form
    {
        private BindingList<Doctor> _doctores;
        private BindingList<PacienteFecha> _pacientesFechas;

        public PacientesFecha()
        {
            InitializeComponent();
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PacientesFecha_Load(object sender, EventArgs e)
        {
            CargaDoctores();
            CargaPacientes();
        }



        private void CargaPacientes()
        {
            var doctor = (Doctor)cboDoctores.SelectedItem;
            DateTime fecha = dtpFecha.Value;
            int doctorId = (int) doctor.Doctor_Id;

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.PacientesXFecha();
                var res = db.Query<PacienteFecha>(sql, new {DoctorId =doctorId, Fecha = fecha  }).ToList();
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




        private void CargaDoctores()
        {

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.DoctoresSelect();
                var res  = db.Query<Doctor>(sql).ToList();
                _doctores = new BindingList<Doctor>(res);   

            }
            cboDoctores.DataSource = _doctores;
            cboDoctores.DisplayMember = "NombreCompleto";
            cboDoctores.ValueMember = "Doctor_Id";
        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            var dr = (Doctor)cboDoctores.SelectedItem;
            int doctorId = (int) dr.Doctor_Id;
            PacienteHoraAgregar pacienteAgregar = new PacienteHoraAgregar(doctorId, cboDoctores.Text, dtpFecha.Value);
            pacienteAgregar.ShowDialog();
            CargaPacientes();
        }

        private void cmdBorrar_Click(object sender, EventArgs e)
        {
            if (grdPacientes.CurrentRow==null)
            {
                MessageBox.Show("Seleccione un paciente");
                return;
            }


            using (FbConnection db = General.GetDB())
            {
                int pacienteFechaId = (int)_pacientesFechas[grdPacientes.CurrentRow.Index].PacienteFechaId;
                string sql = Queries.PacienteFechaDelete();
                db.Execute(sql, new { PacienteFechaId = pacienteFechaId });
            }
            CargaPacientes();
        }

        private void cboDoctores_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaPacientes();
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            CargaPacientes();
        }
    }
}
