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

namespace ClinicaFB.Configuracion.PuntoDeVenta
{
    public partial class FormasPagoListado : Form
    {
        private BindingList<FormaPago> _formasPago;

        public FormasPagoListado()
        {
            InitializeComponent();
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormasPagoListado_Load(object sender, EventArgs e)
        {
            CargaFormasPago();
            SetGrid();
        }


        private void CargaFormasPago()
        {

            string sql = "";

            sql = Queries.FormasPagoSelect();
            using (FbConnection db = General.GetDB())
            {
                var res = db.Query<FormaPago>(sql).ToList();
                _formasPago = new BindingList<FormaPago>(res);

            }

        }


        private void AltasCambios(bool esAlta)
        {
            int id = 0;
            if (!esAlta)
            {
                if (grdFormasPago.CurrentRow == null)
                {
                    MessageBox.Show("Indique la forma de pago a modificar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                id = _formasPago[grdFormasPago.CurrentRow.Index].FormaPagoId;
            }

            FormapagoAltasCambios formapagoAltasCambios = new FormapagoAltasCambios(esAlta,id);
            formapagoAltasCambios.ShowDialog();
            CargaFormasPago();
            SetGrid();
        }



        private void SetGrid()
        {
            grdFormasPago.DataSource = null;

            grdFormasPago.RowHeadersVisible = true;


            grdFormasPago.AllowUserToAddRows = false;
            grdFormasPago.AllowUserToDeleteRows = false;


            grdFormasPago.AutoGenerateColumns = false;
            grdFormasPago.ReadOnly = true;
            grdFormasPago.AllowUserToResizeColumns = false;
            grdFormasPago.AllowUserToResizeRows = false;



            grdFormasPago.ColumnHeadersDefaultCellStyle.Font = new Font(grdFormasPago.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            grdFormasPago.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grdFormasPago.DataSource = _formasPago;


        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            AltasCambios(true);
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            if (grdFormasPago.CurrentRow == null)
            {
                MessageBox.Show("Seleccione la forma de pago a modificar","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            AltasCambios(false);
        }
    }
}
