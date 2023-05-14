using ClinicaFB.Modelo;
using ClinicaFB.ModeloConfiguracion;
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

namespace ClinicaFB.Configuracion.Empresas
{
    public partial class EmpresasListado : Form
    {
        private FbConnection _dbConfig = null;
        private BindingList<Empresa> _empresas = null;
        public int EmpresaId { get; set; } = 0;

        public EmpresasListado(FbConnection db)
        {
            _dbConfig = db;
            InitializeComponent();
        }

        private void EmpresasListado_Load(object sender, EventArgs e)
        {
            CargaEmpresas();
            SetGrid();
        }

        private void CargaEmpresas()
        {

            string sql = Helpers.Queries.EmpresasSelect();

            var res = _dbConfig.Query<Empresa>(sql).ToList();
            _empresas = new BindingList<Empresa>(res);
        }

        private void SetGrid()
        {
            grdEmpresas.DataSource = null;



            grdEmpresas.AllowUserToAddRows = false;
            grdEmpresas.AllowUserToDeleteRows = false;


            grdEmpresas.AutoGenerateColumns = false;
            grdEmpresas.ReadOnly = true;
            grdEmpresas.AllowUserToResizeColumns = false;
            grdEmpresas.AllowUserToResizeRows = false;

            grdEmpresas.ColumnCount = 1;

            grdEmpresas.RowHeadersVisible = true;


            grdEmpresas.ColumnHeadersDefaultCellStyle.Font = new Font(grdEmpresas.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            grdEmpresas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grdEmpresas.Columns[0].HeaderText = "Nombre";

            grdEmpresas.Columns[0].DataPropertyName = "Nombre_Corto";
            grdEmpresas.Columns[0].Width = 200;


            grdEmpresas.DataSource = _empresas;

        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            AltasCambios(true);
        }

        private void AltasCambios(bool esAlta)
        {

            int id = 0;
            if (esAlta == false)
            {
                id = (int)_empresas[grdEmpresas.CurrentRow.Index].Empresa_Id;
            }
            EmpresaAltasCambios empAC = new EmpresaAltasCambios(_dbConfig, esAlta, id);
            empAC.ShowDialog();

            CargaEmpresas();
            SetGrid();


        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            if (grdEmpresas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un equipo a modificar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }

            AltasCambios(false);

        }

        private void grdEmpresas_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grdEmpresas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            AltasCambios(false);

        }

        private void cmdSeleccionar_Click(object sender, EventArgs e)
        {
            if (grdEmpresas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una empresa","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;

            }
            EmpresaId = _empresas[grdEmpresas.CurrentRow.Index].Empresa_Id;
            Close();
            
        }

        private void grdEmpresas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
