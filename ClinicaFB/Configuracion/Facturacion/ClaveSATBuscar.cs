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
using Twilio.Rest.Preview.Sync.Service.Document;

namespace ClinicaFB.Configuracion.Facturacion
{
    public partial class ClaveSATBuscar : Form
    {
        public string Clave { get; set; }
        private string _tipo;
        private BindingList<ClaveSAT> _clavesSAT = new BindingList<ClaveSAT>();

        public ClaveSATBuscar(string tipo)
        {
            InitializeComponent();
            _tipo = tipo;
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            Clave = "";
            Close();
        }


        private void CargaClaves()
        {
            string sql = "";
            string buscar = "%" + txtBuscar.Text.Trim().ToUpper() + "%";

            if (string.IsNullOrEmpty(txtBuscar.Text.Trim()))
            {
                sql = Queries.ClavesSATSelectXTipo();
            }
            else
            {
                sql = Queries.ClavesSATSelectXDescripcion();
            }

            using (FbConnection db = General.GetDB())
            {
                List<ClaveSAT> res = new List<ClaveSAT>();

                res = db.Query<ClaveSAT>(sql, new { Tipo = _tipo, Texto = buscar }).ToList();
                _clavesSAT = new BindingList<ClaveSAT>(res);


            }


        }


        private void SetGrid()
        {
            grdClavesSAT.DataSource = null;



            grdClavesSAT.AllowUserToAddRows = false;
            grdClavesSAT.AllowUserToDeleteRows = false;


            grdClavesSAT.AutoGenerateColumns = false;
            grdClavesSAT.ReadOnly = true;
            grdClavesSAT.AllowUserToResizeColumns = false;
            grdClavesSAT.AllowUserToResizeRows = false;

            grdClavesSAT.ColumnCount = 2;

            grdClavesSAT.RowHeadersVisible = true;


            grdClavesSAT.ColumnHeadersDefaultCellStyle.Font = new Font(grdClavesSAT.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            grdClavesSAT.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grdClavesSAT.Columns[0].HeaderText = "Clave";
            grdClavesSAT.Columns[0].DataPropertyName = "Clave";
            grdClavesSAT.Columns[0].Width = 80;

            grdClavesSAT.Columns[1].HeaderText = "Descripción";
            grdClavesSAT.Columns[1].DataPropertyName = "Descripcion";
            grdClavesSAT.Columns[1].Width = 400;


            grdClavesSAT.DataSource = _clavesSAT;

        }

        private void ClaveSATBuscar_Load(object sender, EventArgs e)
        {
            Actualiza();
        }

        private void Actualiza()
        {
            CargaClaves();
            SetGrid();
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            Actualiza();
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            if (grdClavesSAT.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una clave","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            Clave = _clavesSAT[grdClavesSAT.CurrentRow.Index].Clave;
            Close();
        }

        private void grdClavesSAT_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cmdAceptar_Click(sender, e);
        }
    }
}
