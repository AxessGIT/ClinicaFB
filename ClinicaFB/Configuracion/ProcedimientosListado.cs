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

namespace ClinicaFB.Configuracion
{
    public partial class ProcedimientosListado : Form
    {
        private FbConnection _db = null;
        private BindingList<Procedimiento> _procedimientos = null;

        public ProcedimientosListado(FbConnection db)
        {
            _db = db;
            InitializeComponent();
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ProcedimientosListado_Load(object sender, EventArgs e)
        {
            CargaProcedimientos();
            SetGrid();
        }

        private void CargaProcedimientos()
        {

            string sql = Queries.ProcedimientosSelect();

            var res = _db.Query<Procedimiento>(sql).ToList();
            _procedimientos = new BindingList<Procedimiento>(res);
        }

        private void SetGrid()
        {
            grdProcedimientos.DataSource = null;



            grdProcedimientos.AllowUserToAddRows = false;
            grdProcedimientos.AllowUserToDeleteRows = false;


            grdProcedimientos.AutoGenerateColumns = false;
            grdProcedimientos.ReadOnly = true;
            grdProcedimientos.AllowUserToResizeColumns = false;
            grdProcedimientos.AllowUserToResizeRows = false;

            grdProcedimientos.ColumnCount = 2;

            grdProcedimientos.RowHeadersVisible = true;


            grdProcedimientos.ColumnHeadersDefaultCellStyle.Font = new Font(grdProcedimientos.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            grdProcedimientos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grdProcedimientos.Columns[0].HeaderText = "Procedimiento";

            grdProcedimientos.Columns[0].DataPropertyName = "Descripcion";
            grdProcedimientos.Columns[0].Width = 150;

            grdProcedimientos.Columns[1].DefaultCellStyle.Format = "c2";
            grdProcedimientos.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grdProcedimientos.Columns[1].HeaderText = "Precio";
            grdProcedimientos.Columns[1].DataPropertyName = "Precio";
            grdProcedimientos.Columns[1].Width = 100;

            grdProcedimientos.DataSource = _procedimientos;

        }

        private void AltasCambios(bool esAlta)
        {

            int id = 0;
            if (esAlta == false)
            {
                id = (int)_procedimientos[grdProcedimientos.CurrentRow.Index].Procedimiento_Id;
            }
            ProcedimientosAltasCambios proAC = new ProcedimientosAltasCambios(_db, esAlta, id);
            proAC.ShowDialog();

            CargaProcedimientos();
            SetGrid();


        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            AltasCambios(true);
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            if (grdProcedimientos.CurrentRow == null){
                MessageBox.Show("Seleccione un procedimiento","Confirme",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;

            }

            AltasCambios(false);

        }

        private void grdProcedimientos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex<0 || e.RowIndex<0){
                return;
            }
            AltasCambios(false);
        }

        private void cmdEliminar_Click(object sender, EventArgs e)
        {
            if (grdProcedimientos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un procedimiento", "Confirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }

            if (MessageBox.Show("¿Desea eliminar el procedimiento?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int procedimientoId = _procedimientos[grdProcedimientos.CurrentRow.Index].Procedimiento_Id;
            string sql = "Delete From CitasProins Where Tipo='PRO' and ProcIns_Id=@Id";
            _db.Execute(sql, new { Id = procedimientoId });
            sql = "Delete From Procedimientos Where Procedimiento_Id = @Id";
            _db.Execute(sql, new { Id = procedimientoId });
            CargaProcedimientos();
            SetGrid();

        }
    }
}
