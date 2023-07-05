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
    public partial class IngresoVer : Form
    {
        private int _ingresoId;
        private BindingList<IngresoDetalle> _conceptos = new BindingList<IngresoDetalle>();


        public IngresoVer(int ingresoId)
        {
            InitializeComponent();
            _ingresoId = ingresoId; 
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void IngresoVer_Load(object sender, EventArgs e)
        {
            CargaIngreso();
            CargaConceptos();
            SetGrid();
            CalculaTotales();
        }

        private void CargaIngreso()
        {

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.IngresoSelect();
                Ingreso ing = db.Query<Ingreso>(sql, new {IngresoId = _ingresoId}).FirstOrDefault();   

                if (ing== null)
                {
                    return;
                }
                txtSerie.Text = ing.Serie;
                txtFolio.Text = ing.Folio.ToString();
                txtWEBId.Text = ing.WebId;                
                txtNombrePaciente.Text = ing.PacienteNombre;


            }
        }

        private void CargaConceptos()
        {

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.IngresoDetallesSelect();
                var res = db.Query<IngresoDetalle>(sql, new {IngresoId = _ingresoId}).ToList();
                _conceptos = new BindingList<IngresoDetalle>(res);
            }

        }



        private void SetGrid()
        {
            grdConceptos.DataSource = null;

            grdConceptos.AllowUserToAddRows = false;
            grdConceptos.AllowUserToDeleteRows = false;


            grdConceptos.AutoGenerateColumns = false;
            grdConceptos.ReadOnly = true;
            grdConceptos.AllowUserToResizeColumns = false;
            grdConceptos.AllowUserToResizeRows = false;

            grdConceptos.ColumnCount = 9;

            grdConceptos.RowHeadersVisible = true;


            grdConceptos.ColumnHeadersDefaultCellStyle.Font = new Font(grdConceptos.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            grdConceptos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grdConceptos.Columns[0].HeaderText = "Clave";

            grdConceptos.Columns[0].DataPropertyName = "Clave";
            grdConceptos.Columns[0].Width = 90;

            grdConceptos.Columns[1].HeaderText = "Descripción";
            grdConceptos.Columns[1].DataPropertyName = "Descripcion";
            grdConceptos.Columns[1].Width = 180;

            grdConceptos.Columns[2].HeaderText = "Cant.";
            grdConceptos.Columns[2].DataPropertyName = "Cantidad";
            grdConceptos.Columns[2].Width = 60;
            grdConceptos.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            grdConceptos.Columns[3].HeaderText = "Precio";
            grdConceptos.Columns[3].DataPropertyName = "Precio";
            grdConceptos.Columns[3].Width = 100;
            grdConceptos.Columns[3].DefaultCellStyle.Format = "c2";
            grdConceptos.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            grdConceptos.Columns[4].HeaderText = "IVA";
            grdConceptos.Columns[4].DataPropertyName = "IVA";
            grdConceptos.Columns[4].Width = 100;
            grdConceptos.Columns[4].DefaultCellStyle.Format = "c2";
            grdConceptos.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            grdConceptos.Columns[5].HeaderText = "Descuento";
            grdConceptos.Columns[5].DataPropertyName = "Descuento";
            grdConceptos.Columns[5].Width = 100;
            grdConceptos.Columns[5].DefaultCellStyle.Format = "c2";
            grdConceptos.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;




            grdConceptos.Columns[6].HeaderText = "Ret. ISR";
            grdConceptos.Columns[6].DataPropertyName = "RetISR";
            grdConceptos.Columns[6].Width = 100;
            grdConceptos.Columns[6].DefaultCellStyle.Format = "c2";
            grdConceptos.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;



            grdConceptos.Columns[7].HeaderText = "Ret. IVA";
            grdConceptos.Columns[7].DataPropertyName = "RetIVA";
            grdConceptos.Columns[7].Width = 100;
            grdConceptos.Columns[7].DefaultCellStyle.Format = "c2";
            grdConceptos.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;



            grdConceptos.Columns[8].HeaderText = "Total";
            grdConceptos.Columns[8].DataPropertyName = "Total";
            grdConceptos.Columns[8].Width = 100;
            grdConceptos.Columns[8].DefaultCellStyle.Format = "c2";
            grdConceptos.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;



            grdConceptos.DataSource = _conceptos;


        }

        private void CalculaTotales()
        {
            decimal subTotal = 0, descuento = 0, IVA = 0, retISR = 0, retIVA = 0;

            foreach (var concepto in _conceptos)
            {
                subTotal += concepto.Total;
                descuento += concepto.Descuento;
                IVA += concepto.IVA;
                retISR += concepto.RetISR;
                retIVA += concepto.RetIVA;
            }

            txtSubTotal.DecimalValue = subTotal;
            txtDescuento.DecimalValue = descuento;
            txtIVA.DecimalValue = IVA;
            txtRetISR.DecimalValue = retISR;
            txtRetIVA.DecimalValue = retIVA;
            txtTotal.DecimalValue = subTotal - descuento + IVA - retISR - retIVA;


        }



    }
}
