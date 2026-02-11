using ClinicaFB.Helpers;
using ClinicaFB.Modelo;
using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFB.PuntoDeVenta
{
    public partial class ColaboradoresListado : Form
    {
        private BindingList<Colaborador> _colaboradores = null;
        public ColaboradoresListado()
        {
            InitializeComponent();
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ColaboradoresListado_Load(object sender, EventArgs e)
        {
            CargaColaboradores();
            SetGrid();
        }

        private void CargaColaboradores()
        {
            using (var db = General.GetDB())
            {
                string sql = Queries.ColaboradoresSelect;
                var res = db.Query<Colaborador>(sql).ToList();
                _colaboradores = new BindingList<Colaborador>(res);
            }
        }

        private void SetGrid()
        {
            grdColaboradores.DataSource = null;

            grdColaboradores.AllowUserToAddRows = false;
            grdColaboradores.AllowUserToDeleteRows = false;

            grdColaboradores.AutoGenerateColumns = false;
            grdColaboradores.ReadOnly = true;
            grdColaboradores.AllowUserToResizeColumns = false;
            grdColaboradores.AllowUserToResizeRows = false;


            grdColaboradores.ColumnHeadersDefaultCellStyle.Font = new Font(grdColaboradores.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            grdColaboradores.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;



            grdColaboradores.DataSource = _colaboradores;

        }

        private void AltasCambios(bool esAlta)
        {
            long colaboradorId = 0;
            if (!esAlta)
            {
                if (grdColaboradores.CurrentRow == null)
                {
                    MessageBox.Show("Debe seleccionar un colaborador para modificarlo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                colaboradorId = _colaboradores[grdColaboradores.CurrentRow.Index].ColaboradorId;
            }
            using (var frm = new ColaboradoresAltasCambios(esAlta, colaboradorId))
            {
                var res = frm.ShowDialog();
                CargaColaboradores();
                SetGrid();

            }
        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            AltasCambios(true);
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            AltasCambios(false);
        }

        private void cmdBorrar_Click(object sender, EventArgs e)
        {
            if (grdColaboradores.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar un colaborador para borrarlo", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("¿Confirma que desea borrar el colaborador seleccionado?", "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            long colaboradorId = _colaboradores[grdColaboradores.CurrentRow.Index].ColaboradorId;
            using (var db = General.GetDB())
            {
                string sql = Queries.ColaboradorDelete;
                var res = db.Execute(sql, new { ColaboradorId = colaboradorId });
                CargaColaboradores();
                SetGrid();
            }
        }
    }
}
