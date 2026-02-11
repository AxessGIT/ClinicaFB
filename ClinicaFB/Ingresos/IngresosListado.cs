using ClinicaFB.Facturacion;
using ClinicaFB.Helpers;
using ClinicaFB.Modelo;
using Dapper;
using FirebirdSql.Data.FirebirdClient;
using SplashScreen.WindowsForms;
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
        private string _tipo;
        long _razonSocialId = 0;

        public IngresosListado(string tipo)
        {
            InitializeComponent();
            _tipo = tipo;
        }

        private void IngresosListado_Load(object sender, EventArgs e)
        {
            
        }


        private void CargaIngresos()
        {

            using (FbConnection db = General.GetDB())
            {
                string sql = _razonSocialId == 0 ? Queries.IngresosSelectxSucursalYFechas() : Queries.IngresosSelectxSucursalFechasYRazonSocial;

                DateTime fechaIni = dtpFechaInicial.Value;
                DateTime fechaFin = dtpFechaFinal.Value;

                var res = _razonSocialId==0 
                    ?
                    db.Query<Ingreso>(sql, new {Properties.Settings.Default.SucursalId, Tipo = _tipo, FechaInicial= fechaIni, FechaFinal= fechaFin }).ToList()
                    : db.Query<Ingreso>(sql, new { Properties.Settings.Default.SucursalId, Tipo = _tipo, FechaInicial = fechaIni, FechaFinal = fechaFin, RazonSocialId = _razonSocialId }).ToList()
                    ;

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
            grdIngresos.Columns[3].DataPropertyName = "NomPac";
            grdIngresos.Columns[3].Width = 200;

            grdIngresos.Columns[4].HeaderText = "Razon Social";
            grdIngresos.Columns[4].DataPropertyName = "NomRazon";
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

        private bool HayIngresoSeleccionado()
        {
            if (grdIngresos.CurrentRow==null)
            {
                MessageBox.Show("Seleccione el ingreso", "Verifique",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void cmdVer_Click(object sender, EventArgs e)
        {
            if (HayIngresoSeleccionado()==false)
            {
                return;
            }
            long ingresoId = _ingresos[grdIngresos.CurrentRow.Index].IngresoId;
            IngresoVer ingresoVer = new IngresoVer(ingresoId);
            ingresoVer.ShowDialog();

        }

        private void cmdTicket_Click(object sender, EventArgs e)
        {
            if (HayIngresoSeleccionado()==false)
            {
                return;
            }

            long ingresoId = _ingresos[grdIngresos.CurrentRow.Index].IngresoId;
            Ingreso ing = new Ingreso();
            BindingList<IngresoDetalle> conceptos = new BindingList<IngresoDetalle>();

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.IngresoSelect();
                ing = db.Query<Ingreso>(sql, new {IngresoId = ingresoId}).FirstOrDefault();

                if (ing == null)
                {
                    return;
                }

                sql = Queries.IngresoDetallesSelect();
                var res = db.Query<IngresoDetalle>(sql, new {IngresoId = ingresoId}).ToList();

                conceptos = new BindingList<IngresoDetalle>(res);


            }
            ManejaCFDIs.ImprimeTicket(ing, conceptos);

        }




        private void cmdFacturar_Click(object sender, EventArgs e)
        {
            if (HayIngresoSeleccionado() == false)
            {
                return;
            }

            if (_ingresos[grdIngresos.CurrentRow.Index].Cancelado)
            {
                MessageBox.Show("El Ingreso está cancelado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }



            long ingresoId = _ingresos[grdIngresos.CurrentRow.Index].IngresoId;
            if (General.IngresoFacturado(ingresoId))
            {
                MessageBox.Show("El Ingreso ya está facturado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Ingreso ing = _ingresos[grdIngresos.CurrentRow.Index];

            FacturarOpciones clavesSATSeleccionar = new FacturarOpciones(ing.RazonSocialId, ing.CveFOP, ing.CveMEP, ing.CveUSO,selRazon:true);
            clavesSATSeleccionar.ShowDialog();

            if (clavesSATSeleccionar.Aceptar == false)
            {
                return;
            }
            //grdIngresos.CurrentRow.Visible = false;
            ing.IngresoId = ingresoId;
            ing.RazonSocialId = clavesSATSeleccionar.RazonSocialId;
            ing.CveFOP = clavesSATSeleccionar.txtCveFOP.Text.Trim();
            ing.CveMEP = clavesSATSeleccionar.txtCveMEP.Text.Trim();
            ing.CveUSO = clavesSATSeleccionar.txtCveUSO.Text.Trim();

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.IngresoUpdateFacturacion();
                db.Execute(sql, ing);
            }
            bool _imprimir = clavesSATSeleccionar.chkImprimir.Checked;
            string _impresora = clavesSATSeleccionar.cboImpresoras.Text.Trim();
            bool _mandarCorreos = clavesSATSeleccionar.chkMandarCorreo.Checked;
            string _correos = clavesSATSeleccionar.txtCorreos.Text.Trim();

            Splasher splasher = new Splasher("Generando factura");
            splasher.Show();

           ManejaCFDIs.IngresoFacturar(ingresoId, _imprimir, _impresora, _mandarCorreos, _correos);
            splasher.Close();

            CargaIngresos();
            SetGrid();


        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            if (HayIngresoSeleccionado() == false)
            {
                return;
            }
            if (MessageBox.Show("¿Desea cancelar el ingreso?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            using (FbConnection db = General.GetDB())
            {
                long ingresoId = _ingresos[grdIngresos.CurrentRow.Index].IngresoId;
                string sql = Queries.IngresoCancelar();
                db.Execute(sql, new {IngresoId= ingresoId });
                _ingresos[grdIngresos.CurrentRow.Index].Cancelado = true;
                grdIngresos.DataSource = _ingresos;
                grdIngresos.Refresh();  
                MessageBox.Show("Ingreso Cancelado","Aviso",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void cmdExportar_Click(object sender, EventArgs e)
        {

        }

        private void cmdBuscaRazonSocial_Click(object sender, EventArgs e)
        {
            RazonesSocialesListado razonesSocialesListado = new RazonesSocialesListado(true);
            razonesSocialesListado.ShowDialog();
            if (razonesSocialesListado.RazonId != 0)
            {
                _razonSocialId = razonesSocialesListado.RazonId;
                CargaDatosRazonSocial();
            }
            

        }



        private void CargaDatosRazonSocial()
        {
            if (_razonSocialId == 0)
            {
                return;
            }

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.RazonSocialSelect();
                RazonSocial raz = db.Query<RazonSocial>(sql, new { RazonSocialId = _razonSocialId }).FirstOrDefault();

                if (raz != null)
                {
                    txtRFC.Text = raz.RFC;
                    txtRazonSocial.Text = raz.RazonSoc;
                  
                }
            }


        }
    }
}
