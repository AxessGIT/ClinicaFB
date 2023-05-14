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

namespace ClinicaFB.Ingresos
{
    public partial class IngresosListado : Form
    {
        private BindingList<Ingreso> _ingresos = new BindingList<Ingreso>();

        public IngresosListado()
        {
            InitializeComponent();
        }

        private void IngresosListado_Load(object sender, EventArgs e)
        {
            
        }


        private void CargaIngresos()
        {

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.IngresosSelectxSucursalYFechas();

                DateTime fechaIni = dtpFechaInicial.Value;
                DateTime fechaFin = dtpFechaFinal.Value;

                var res = db.Query<Ingreso>(sql, new {SucursalId = Properties.Settings.Default.SucursalId, FechaInicial= fechaIni, FechaFinal= fechaFin }).ToList();

                _ingresos = new BindingList<Ingreso>(res);
            }

        }

        private void SetGrid()
        {
            grdIngresos.DataSource = null;

            grdIngresos.AllowUserToAddRows = false;
            grdIngresos.AllowUserToDeleteRows = false;


            grdIngresos.AutoGenerateColumns = false;
            grdIngresos.ReadOnly = true;
            grdIngresos.AllowUserToResizeColumns = false;
            grdIngresos.AllowUserToResizeRows = false;

            grdIngresos.ColumnCount = 6;

            grdIngresos.RowHeadersVisible = true;


            grdIngresos.ColumnHeadersDefaultCellStyle.Font = new Font(grdIngresos.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            grdIngresos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grdIngresos.Columns[0].HeaderText = "Fecha";
            grdIngresos.Columns[0].DataPropertyName = "Fecha";
            grdIngresos.Columns[0].Width = 90;

            grdIngresos.Columns[1].HeaderText = "Serie";
            grdIngresos.Columns[1].DataPropertyName = "Serie";
            grdIngresos.Columns[1].Width = 40;
            grdIngresos.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            grdIngresos.Columns[2].HeaderText = "Folio";
            grdIngresos.Columns[2].DataPropertyName = "Folio";
            grdIngresos.Columns[2].Width = 50;
            grdIngresos.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            grdIngresos.Columns[3].HeaderText = "Paciente";
            grdIngresos.Columns[3].DataPropertyName = "PacienteNombre";
            grdIngresos.Columns[3].Width = 200;

            grdIngresos.Columns[4].HeaderText = "Razon Social";
            grdIngresos.Columns[4].DataPropertyName = "RazonSoc";
            grdIngresos.Columns[4].Width = 200;



            grdIngresos.Columns[5].HeaderText = "Importe";
            grdIngresos.Columns[5].DataPropertyName = "Total";
            grdIngresos.Columns[5].Width = 80;
            grdIngresos.Columns[5].DefaultCellStyle.Format = "c2";
            grdIngresos.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            DataGridViewCheckBoxColumn colCancelada = new DataGridViewCheckBoxColumn();
            colCancelada.HeaderText = "Cancelado";
            colCancelada.DataPropertyName = "Cancelado";

            grdIngresos.Columns.Add(colCancelada);


            grdIngresos.DataSource = _ingresos;

        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            CargaIngresos();
            SetGrid();
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
