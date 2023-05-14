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

namespace ClinicaFB.Configuracion.Facturacion
{
    public partial class EmisoresListado : Form
    {
        private BindingList<Emisor> _emisores = new BindingList<Emisor>();
        public EmisoresListado()
        {
            InitializeComponent();
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EmisoresListado_Load(object sender, EventArgs e)
        {
            CargaEmisores();
            SetGrid();
        }

        private void CargaEmisores()
        {

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.EmisoresSelect();
                var res = db.Query<Emisor>(sql).ToList();
                _emisores = new BindingList<Emisor>(res);

            }
        }

        private void AltasCambios(bool esAlta)
        {
            int emisorId = 0;
            if (!esAlta)
            {
                emisorId = _emisores[grdEmisores.CurrentRow.Index].EmisorId;
            }
            EmisoresAltasCambios emisoresAltasCambios = new EmisoresAltasCambios(esAlta, emisorId);
            emisoresAltasCambios.ShowDialog();
            CargaEmisores();
            SetGrid();
        }
        private void SetGrid()
        {
            grdEmisores.DataSource = null;



            grdEmisores.AllowUserToAddRows = false;
            grdEmisores.AllowUserToDeleteRows = false;


            grdEmisores.AutoGenerateColumns = false;
            grdEmisores.ReadOnly = true;
            grdEmisores.AllowUserToResizeColumns = false;
            grdEmisores.AllowUserToResizeRows = false;

           // grdEmisores.ColumnCount = 2;

            grdEmisores.RowHeadersVisible = true;


            grdEmisores.ColumnHeadersDefaultCellStyle.Font = new Font(grdEmisores.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            grdEmisores.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            /*grdEmisores.Columns[0].HeaderText = "RFC";

            grdEmisores.Columns[0].DataPropertyName = "RFC";
            grdEmisores.Columns[0].Width = 100;

            grdEmisores.Columns[1].HeaderText = "Nombre";
            grdEmisores.Columns[1].DataPropertyName = "Nombre";
            grdEmisores.Columns[1].Width = 350;*/




            grdEmisores.DataSource = _emisores;

        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            AltasCambios(true);
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            if (grdEmisores.CurrentRow == null)
            {
                MessageBox.Show("Indique el emisor a modificar","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            AltasCambios(false);
        }

        private void cmdDefault_Click(object sender, EventArgs e)
        {
            if (grdEmisores.CurrentRow == null)
            {
                MessageBox.Show("Seleccione el emisor predeterminado","Aviso",MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (_emisores[grdEmisores.CurrentRow.Index].Defa)
                return;


            using (FbConnection db = General.GetDB())
            {
                string sql = "Update Emisores set Defa=true where EmisorId=@EmisorId";
                db.Execute(sql, new { EmisorId = _emisores[grdEmisores.CurrentRow.Index].EmisorId });

                sql = "Update Emisores set Defa=false where EmisorId<>@EmisorId";
                db.Execute(sql, new { EmisorId = _emisores[grdEmisores.CurrentRow.Index].EmisorId });

            }
            CargaEmisores();
            SetGrid();
        }
    }
}
