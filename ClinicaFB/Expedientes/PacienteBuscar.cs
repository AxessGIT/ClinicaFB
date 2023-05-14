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
    public partial class PacienteBuscar : Form
    {
        private BindingList<Paciente> _pacientes = null;
        public long Paciente_Id { get; set; }
        public PacienteBuscar()
        {
            
            InitializeComponent();
        }

        private void PacienteBuscar_Load(object sender, EventArgs e)
        {
            _pacientes = new BindingList<Paciente>();
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
            grdPacientes.Columns[0].Width = 250;

            grdPacientes.Columns[1].HeaderText = "Teléfonos";
            grdPacientes.Columns[1].DataPropertyName = "Telefonos";
            grdPacientes.Columns[1].Width = 130;

            grdPacientes.Columns[2].HeaderText = "Correos";
            grdPacientes.Columns[2].DataPropertyName = "Correos";
            grdPacientes.Columns[2].Width = 130;

            grdPacientes.Columns[3].HeaderText = "Ubi.";
            grdPacientes.Columns[3].DataPropertyName = "Ubicacion";
            grdPacientes.Columns[3].Width = 50;

            grdPacientes.DataSource = _pacientes;

        }
        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Paciente_Id = 0;
            Close();
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBuscar.Text.Trim())) {
                MessageBox.Show("Indique el texto a buscar","Confirme",MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Busca();
        }

        private void Busca()
        {
            string sql = Queries.PacientesSelectBuscar(txtBuscar.Text.Trim().ToUpper());


            using (FbConnection db = General.GetDB())
            {
                var res = db.Query<Paciente>(sql).ToList();
                _pacientes = new BindingList<Paciente>(res);

            }

            SetGrid();
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            if (grdPacientes.CurrentRow==null)
            {
                MessageBox.Show("Indique un paciente","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            Paciente_Id = _pacientes[grdPacientes.CurrentRow.Index].Paciente_Id;
            Close();
        }

        private void grdPacientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            Paciente_Id = _pacientes[grdPacientes.CurrentRow.Index].Paciente_Id;
            Close();

        }
    }
}
