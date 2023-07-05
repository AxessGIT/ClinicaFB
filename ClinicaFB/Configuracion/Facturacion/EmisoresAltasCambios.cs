using ClinicaFB.Helpers;
using ClinicaFB.Modelo;
using ClinicaFB.PuntoDeVenta;
using Dapper;
using FirebirdSql.Data.FirebirdClient;
using Syncfusion.PivotAnalysis.Base;
using Syncfusion.Windows.Forms.Edit.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFB.Configuracion.Facturacion
{
    public partial class EmisoresAltasCambios : Form
    {
        private bool _esAlta;
        private int _emisorId;
        private bool _emisorDefault = false;
        private BindingList<SerieDoc> _series = new BindingList<SerieDoc>();
        private BindingList<SerieConcepto> _seriesConceptos = new BindingList<SerieConcepto>();

        public EmisoresAltasCambios(bool esAlta, int emisorId)
        {
            InitializeComponent();
            _esAlta = esAlta;
            _emisorId = emisorId;
        }

        private void EmisoresAltasCambios_Load(object sender, EventArgs e)
        {
            SetCombos();

            if (_esAlta)
            {
                Text = "Agregar emisor";
            }
            else
            {
                Text = "Modificar emisor";
                CargaEmisor();

            }
        }
        private void SetCombos()
        {
            General.ConfiguraCombo(ref cboCiudades, "CIU");
            General.ConfiguraCombo(ref cboEstados, "EDO");
            General.ConfiguraCombo(ref cboPaises, "PAI");

        }

        private void CargaEmisor()
        {

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.EmisorSelect();
                Emisor emi = db.Query<Emisor>(sql, new {EmisorId = _emisorId }).FirstOrDefault();

                if (emi != null)
                {
                    txtRFC.Text=emi.RFC;
                    txtNombre.Text=emi.Nombre;
                    txtDireccion.Text=emi.Direccion;
                    txtColonia.Text=emi.Colonia;
                    cboCiudades.SelectedValue = emi.CiudadId;
                    cboEstados.SelectedValue = emi.EstadoId;
                    cboPaises.SelectedValue = emi.PaisId;
                    txtCP.Text=emi.CP;
                    txtCertificado.Text=emi.Certificado;
                    txtLlavePrivada.Text=emi.LlavePrivada;
                    txtPassWord.Text=emi.PassWord;

                    txtCveRef.Text = emi.CveRef;
                    _emisorDefault = emi.Defa;
                    chkPDV.Checked = emi.PDV;
                    txtCveRef_Validated(new {}, new EventArgs());
                }
            }
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void GuardaEmisor()
        {
            Emisor emi = new Emisor();
            emi.EmisorId = _emisorId;
            emi.RFC = txtRFC.Text;
            emi.Nombre = txtNombre.Text;
            emi.Direccion = txtDireccion.Text;
            emi.Colonia = txtColonia.Text;

            emi.CiudadId = (int)General.DevuelveValorCombo(cboCiudades, "CIU");
            emi.EstadoId = (int)General.DevuelveValorCombo(cboEstados, "EDO");
            emi.PaisId = (int)General.DevuelveValorCombo(cboPaises, "PAI");
            emi.CP = txtCP.Text;
            emi.CveRef = txtCveRef.Text;
            emi.Certificado = txtCertificado.Text;
            emi.LlavePrivada = txtLlavePrivada.Text;
            emi.PassWord = txtPassWord.Text;
            emi.PDV=chkPDV.Checked;

            string sql = "";

            if (_esAlta)
            {
                sql = Queries.EmisorInsert();


            }
            else
            {
                emi.Defa = _emisorDefault;
                sql = Queries.EmisorUpdate();
            }


            using (FbConnection db = General.GetDB())
            {
                if (_esAlta)
                {
                    _emisorId = db.ExecuteScalar<int>(sql, emi);
                    _esAlta = false;


                }
                else
                {
                    db.Execute(sql, emi);

                }
            }


        }
        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            if (ValidaDatos() == false)
                return;

            GuardaEmisor();
            Close();
        }

        private bool ValidaDatos()
        {
            bool valida = true;
            string errores = "";

            if (string.IsNullOrEmpty(txtRFC.Text))
            {
                errores = "* Teclee el RFC \n";
                valida = false;
            }

            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                errores = "* Teclee el Nombre \n";
                valida = false;
            }

            if (valida == false)
            {
                MessageBox.Show("es necesario que corrija lo siguiente\n"+errores,"Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

            return valida;

        }

        private void cmdMuestraPassWord_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassWord.PasswordChar = '\0';


        }

        private void cmdMuestraPassWord_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassWord.PasswordChar = '*';

        }

        private void cmdCveRefBuscar_Click(object sender, EventArgs e)
        {
            General.BuscarClaveSAT("REF", ref txtCveRef, ref txtRegimenFiscal);
            //ClaveSATBuscar claveSATBuscar = new ClaveSATBuscar("REF");
            //claveSATBuscar.ShowDialog();
            //if (!string.IsNullOrEmpty(claveSATBuscar.Clave))
            //{
            //    txtCveRef.Text = claveSATBuscar.Clave;
            //    txtCveRef_Validated(sender, e);
            //}
        }

        private void txtCveRef_Validated(object sender, EventArgs e)
        {
            General.ValidarClaveSAT("REF", ref txtCveRef,ref txtRegimenFiscal);
/*            string des = General.GetDescripcionClaveSAT("REF", txtCveRef.Text.Trim());
            if (string.IsNullOrEmpty(des))
            {
                MessageBox.Show("No existe esa clave","Confirme",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtCveRef.Text = "";
                txtRegimenFiscal.Text = "";

            }
            else
            {
                txtRegimenFiscal.Text = des;
            }*/
        }

        private void cmdBuscarCertificado_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos certificado (*.cer)|*.cer";
            if (ofd.ShowDialog() == DialogResult.OK || !string.IsNullOrEmpty(ofd.FileName))
            {
                txtCertificado.Text = ofd.FileName;
            }
        }

        private void cmdBuscarLlavePrivada_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos de llave priv. (*.key)|*.key";
            if (ofd.ShowDialog() == DialogResult.OK || !string.IsNullOrEmpty(ofd.FileName))
            {
                txtLlavePrivada.Text = ofd.FileName;
            }

        }

        private void pagSeries_Enter(object sender, EventArgs e)
        {
            if (_esAlta)
            {
                if (!ValidaDatos())
                {
                    tabEmisores.SelectedTab = pagGenerales;
                    return;
                }
                GuardaEmisor();
            }

            CargaSeries();
            SetGridSeries();
        }

        private void CargaSeries()
        {

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.SeriesDocsSelectXEmisorYTipo();
                var res = db.Query<SerieDoc>(sql, new {EmisorId = _emisorId, Tipo ="FAC" }).ToList();
                _series = new BindingList<SerieDoc>(res);

            }

        }

        private void SetGridSeries()
        {
            grdSeries.AutoGenerateColumns = false;
            grdSeries.ReadOnly = true;
            grdSeries.DataSource = null;
            grdSeries.DataSource = _series;
            return;




            grdSeries.AllowUserToAddRows = false;
            grdSeries.AllowUserToDeleteRows = false;


            grdSeries.AutoGenerateColumns = false;
            grdSeries.ReadOnly = true;
            grdSeries.AllowUserToResizeColumns = false;
            grdSeries.AllowUserToResizeRows = false;

            grdSeries.ColumnCount = 2;

            grdSeries.RowHeadersVisible = true;


            //grdSeries.ColumnHeadersDefaultCellStyle.Font = new Font(grdSeries.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            grdSeries.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grdSeries.Columns[0].HeaderText = "Serie";

            grdSeries.Columns[0].DataPropertyName = "Serie";
            grdSeries.Columns[0].Width = 80;

            grdSeries.Columns[1].HeaderText = "Siguiente Folio";
            grdSeries.Columns[1].DataPropertyName = "Folio";
            grdSeries.Columns[1].Width = 80;


            grdSeries.Columns[2].HeaderText = "Activa";
            grdSeries.Columns[2].DataPropertyName = "Activa";
            grdSeries.Columns[2].Width = 70;


            grdSeries.Columns[3].HeaderText = "Default";
            grdSeries.Columns[3].DataPropertyName = "Defa";
            grdSeries.Columns[3].Width = 70;



        }


        private void CargaConceptos(int rowIndex)
        {

            if (grdSeries.Rows[rowIndex]==null)
                return;

            int serieId = 0;
            serieId = _series[rowIndex].SerieDocId;

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.SeriesConceptosSelectXSerie();
                var res = db.Query<SerieConcepto>(sql, new { SerieId = serieId}).ToList();
                _seriesConceptos = new BindingList<SerieConcepto>(res);

            }

        }

        private void SetGridConceptos()
        {
            grdConceptos.DataSource = null;
            grdConceptos.AutoGenerateColumns = false;
            grdConceptos.ReadOnly = false;
            grdConceptos.AllowUserToResizeColumns = false;
            grdConceptos.AllowUserToResizeRows = false;

            grdConceptos.DataSource = _seriesConceptos;

        }



        private void cmdSerieAgregar_Click(object sender, EventArgs e)
        {
            SeriesAltasCambios(true);
        }

        private void SeriesAltasCambios(bool esAlta)
        {
            int serieId = 0;
            if (!esAlta)
            {
                serieId= _series[grdSeries.CurrentRow.Index].SerieDocId; ;
            }
            SeriesDocsAltasCambios seriesDocsAltasCambios = new SeriesDocsAltasCambios(esAlta,_emisorId,"FAC", serieId);
            seriesDocsAltasCambios.ShowDialog();
            CargaSeries();
            SetGridSeries();

        }

        private void cmdSerieModificar_Click(object sender, EventArgs e)
        {
            if (grdSeries.CurrentRow==null)
            {
                MessageBox.Show("Seleccione una serie","Aviso",MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            SeriesAltasCambios(false);
}


        private void grdSeries_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cmdSerieModificar_Click(sender, e);

        }

        private void cmdSerieEliminar_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("¿Desea borrar la serie?","Confirme",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.No)
                return;

            if (grdSeries.CurrentRow == null)
            {
                MessageBox.Show("Indique la serie a borrar","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return ;
            }

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.SerieDocDelete();
                int serieId = _series[grdSeries.CurrentRow.Index].SerieDocId;
                db.Execute(sql, new { SerieDocId = serieId });

                sql = Queries.SerieConceptosDelete();
                db.Execute(sql, new {SerieId=serieId}); 

            }
            CargaSeries();
            SetGridSeries();
            _seriesConceptos = new BindingList<SerieConcepto>();
            SetGridConceptos();


        }

        private void cmdAgregarConcepto_Click(object sender, EventArgs e)
        {

            SeriesConceptosAC(true);


        }

        private void SeriesConceptosAC(bool esAlta)
        {

            if (grdSeries.CurrentRow == null)
            {
                return;

            }
            int serieId = _series[grdSeries.CurrentRow.Index].SerieDocId;

            int id = 0;
            if (esAlta==false)
            {
                id = _seriesConceptos[grdConceptos.CurrentRow.Index].SerieConceptoId;
            }

            SeriesConceptosAltasCambios seriesConceptosAltasCambios = new SeriesConceptosAltasCambios(esAlta, id,serieId);
            seriesConceptosAltasCambios.ShowDialog();
            CargaConceptos(grdSeries.CurrentRow.Index);
            SetGridConceptos();


        }

        private void grdSeries_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
            CargaConceptos(e.RowIndex);
            SetGridConceptos();

        }

        private void grdSeries_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdSeries.CurrentRow.Index == 0)
                return;

            //CargaConceptos();
            //SetGridConceptos();

        }

        private void cmdBorrarConcepto_Click(object sender, EventArgs e)
        {
            if (grdConceptos.CurrentRow == null)
            {
                MessageBox.Show("Indique el concepto a borrar","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.SerieConceptoDelete();
                db.Execute(sql, new { SerieConceptoId = _seriesConceptos[grdConceptos.CurrentRow.Index].SerieConceptoId});
            }

            CargaConceptos(grdSeries.CurrentRow.Index);
            SetGridConceptos();
        }

        private void cmdModificarConcepto_Click(object sender, EventArgs e)
        {
            if (grdConceptos.CurrentRow==null)
            {
                MessageBox.Show("Seleccione el concepto a  modificar", "Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            SeriesConceptosAC(false);
        }
    }
}
