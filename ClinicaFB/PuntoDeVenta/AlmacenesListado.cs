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

namespace ClinicaFB.PuntoDeVenta
{
    public partial class AlmacenesListado : Form
    {
        private BindingList<Almacen> _almacenes = null;

        public AlmacenesListado()
        {
            InitializeComponent();
        }

        private void Almacenes_Load(object sender, EventArgs e)
        {
            CargaAlmacenes();
            SetGrid();
            
        }


        private void CargaAlmacenes()
        {

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.AlmacenesSelect();
                var res = db.Query<Almacen>(sql).ToList();

                _almacenes = new BindingList<Almacen>(res);

            }
        }


        private void SetGrid()
        {
            grdAlmacenes.DataSource = null;



            grdAlmacenes.AllowUserToAddRows = false;
            grdAlmacenes.AllowUserToDeleteRows = false;


            grdAlmacenes.AutoGenerateColumns = false;
            grdAlmacenes.ReadOnly = true;
            grdAlmacenes.AllowUserToResizeColumns = false;
            grdAlmacenes.AllowUserToResizeRows = false;

            //grdAlmacenes.ColumnCount =1;

            //grdAlmacenes.RowHeadersVisible = true;


            grdAlmacenes.ColumnHeadersDefaultCellStyle.Font = new Font(grdAlmacenes.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            grdAlmacenes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            /*dAlmacenes.Columns[0].HeaderText = "Nombre";
            grdAlmacenes.Columns[0].DataPropertyName = "Nombre";
            grdAlmacenes.Columns[0].Width = 150;*/


            grdAlmacenes.DataSource = _almacenes;

        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            AltasCambios(true);
        }

        private void AltasCambios(bool esAlta)
        {
            int almacenId = 0;
            if (esAlta == false)
            {
                if (grdAlmacenes.CurrentRow == null)
                {
                    MessageBox.Show(
                        "Indique el almacen a modificar",
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }
                almacenId = (int)_almacenes[grdAlmacenes.CurrentRow.Index].AlmacenId;

            }
            AlmacenesAltasCambios almacenesAltasCambios = new AlmacenesAltasCambios (esAlta, almacenId);
            almacenesAltasCambios.ShowDialog();
            CargaAlmacenes();
            SetGrid();
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            AltasCambios (false);
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
