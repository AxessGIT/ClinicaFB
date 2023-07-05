using ClinicaFB.Expedientes;
using ClinicaFB.Facturacion;
using ClinicaFB.Helpers;
using ClinicaFB.Modelo;
using ClinicaFB.PuntoDeVenta;
using Dapper;
using FirebirdSql.Data.FirebirdClient;
using Syncfusion.Windows.Forms.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CFDiLib;
using Microsoft.Reporting.WinForms;
using QRCoder;
using System.IO;
using System.Diagnostics;

namespace ClinicaFB.Ingresos
{
    public partial class ingCaptura : Form
    {
        private int _pacienteId = 0;
        private int _razonSocialId=0;

        private string _tipo;

        private string _cveFOP;
        private string _cveMEP;
        private string _cveUSO;


        private bool _imprimir;
        private string _impresora;


        private bool _mandarCorreos;
        private string _correos;


        private Color _colorFondo = Color.White;
        private Color _colorFuente = Color.Black;
        private BindingList<IngresoDetalle> _conceptos = new BindingList<IngresoDetalle>();
        private BindingList<Emisor> _emisores = new BindingList<Emisor>();
        private BindingList<Almacen> _almacenes = new BindingList<Almacen>();

        private int _ingresoId = 0;
        private int _sucursalId = Properties.Settings.Default.SucursalId;


        public ingCaptura(string tipo, int pacienteId=0)
        {
            _pacienteId = pacienteId;
            _tipo = tipo;
            InitializeComponent();
        }

        private void ingCaptura_Load(object sender, EventArgs e)
        {


            CambiaColores();
            txtPorceRetISR.NumberFormatInfo = General.GetFormatoPorcentajeRetencion();
            txtPorceRetIVA.NumberFormatInfo = General.GetFormatoPorcentajeRetencion();

            if (_tipo == "PDV")
            {
                Text = "Captura de ventas";
                CargaAlmacenes();

                lblAlmacen.Visible = true;
                cboAlmacenes.Visible = true;
            }
            CargaDatosPaciente();
            SetGrid();
            CargaEmisores();

        }


   



        private async Task RegistraIngreso(bool facturar)
        {
            await Task.Run(() => GuardaIngreso(facturar));
        }


        private void GuardaIngreso(bool facturar)
        {

            int emisorDefaultId = (int) cboEmisores.SelectedValue;
            SerieDoc serieDocumento = new SerieDoc();




            string serie = "";
            int folio = 0;

            using (FbConnection db = General.GetDB())
            {
                string sql = "";

                sql = Queries.SucursalSelect();
                Sucursal suc = db.Query<Sucursal>(sql, new {SucursalId = _sucursalId }).FirstOrDefault();

                if (suc == null)
                {
                    MessageBox.Show("No existe información de serie, folio para ingresos de la sucursal", "Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return;
                }

                sql = Queries.SucursalSetSiguienteFolioIngresos();
                db.Execute(sql, new {SucursalId = _sucursalId});

                serie = suc.SerieIngresos;
                folio = suc.FolioIngresos;


            }

            Ingreso ing = new Ingreso();
            ing.SucursalId = _sucursalId;

            ing.Tipo = _tipo;
            
            ing.Serie = serie;
            ing.Folio= folio;
            ing.PacienteId = _pacienteId;
            ing.RazonSocialId= _razonSocialId;
            ing.CveFOP = _cveFOP;
            ing.CveMEP = _cveMEP;
            ing.CveUSO = _cveUSO;
            ing.Fecha = txtFecha.Value;
            ing.Hora = DateTime.Now.TimeOfDay.ToString(); 
            ing.Hora = ing.Hora.Substring(0, 8);
            ing.SubTotal = txtSubTotal.DecimalValue;
            ing.Impuesto = txtIVA.DecimalValue;
            ing.Descuento =txtDescuento.DecimalValue;
            ing.RetIVA = txtRetIVA.DecimalValue;
            ing.RetISR = txtRetISR.DecimalValue;
            ing.Total = txtTotal.DecimalValue;
            ing.Cancelado = false;
            ing.WebId = General.RandomString(5);


            

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.IngresoInsert();
                _ingresoId = db.ExecuteScalar<int>(sql,ing);

                foreach (IngresoDetalle det in _conceptos)
                {



                    IngresoDetalle ingDet = new IngresoDetalle();
                    ingDet.IngresoId = _ingresoId;
                    ingDet.ArticuloId= det.ArticuloId;
                    ingDet.ArticuloId = det.ArticuloId;
                    ingDet.Clave = det.Clave;
                    ingDet.Descripcion= det.Descripcion;
                    ingDet.UDM = det.UDM;
                    ingDet.Cantidad= det.Cantidad;
                    ingDet.Precio = det.Precio;
                    ingDet.Descuento= det.Descuento;

                    ingDet.CveProSer = det.CveProSer;
                    ingDet.CveUni = det.CveUni;


                    ingDet.TipoIVA= det.TipoIVA; //1=tasa 2=exento
                    ingDet.TasaIVA= det.TasaIVA;

                    ingDet.BaseIVA= det.BaseIVA;
                    ingDet.IVA= det.IVA;
                    
                    ingDet.PorceRetISR = det.PorceRetISR;
                    ingDet.PorceRetIVA = det.PorceRetIVA;

                    ingDet.EmisorId = det.EmisorId;
                    ingDet.Serie= det.Serie;

                    sql = Queries.IngresoDetalleInsert();

                    db.Execute(sql, ingDet);

                }
            }

            if (facturar)
            {
                ManejaCFDIs.IngresoFacturar(_ingresoId,_imprimir,_impresora,_mandarCorreos,_correos);
            }
            else
            {
                ManejaCFDIs.ImprimeTicket(ing, _conceptos,_imprimir,_impresora,_mandarCorreos,_correos);
            }
            Inicializa();





        }

        private void GeneraFacturas()
        {
            var conceptosOrdenados = new BindingList<IngresoDetalle>(_conceptos.OrderBy(x => x.EmisorId).ThenBy(x=>x.Serie).ToList());

            int emisorId = conceptosOrdenados[0].EmisorId;
            string serie = conceptosOrdenados[0].Serie;

            List<IngresoDetalle> conceptos = new List<IngresoDetalle>();

            foreach (var concepto in conceptosOrdenados)
            {
                if (concepto.EmisorId != emisorId || concepto.Serie != serie)
                {

                    GeneraFactura(conceptos);
                    emisorId = concepto.EmisorId;
                    serie = concepto.Serie;
                    conceptos = new List<IngresoDetalle>();
                }
                conceptos.Add(concepto);

            }



        }

        private void GeneraFactura(List<IngresoDetalle> conceptos)
        {
            //Comprobante comprobante= new Comprobante();


        }

        private void Inicializa()
        {
            _pacienteId = 0;
            _razonSocialId= 0;

            txtNombrePaciente.Text = "PUBLICO EN GENERAL";
            txtRazonSocial.Text = "PUBLICO EN GENERAL";

            txtConcepto.Text = "";
            spnCantidad.Value = 1;
            _conceptos = new BindingList<IngresoDetalle>();

            SetGrid();
            CalculaTotales();


            txtConcepto.Focus();



        }

        private void CargaEmisores()
        {


            int emisorIdDefa = 0;
            string nombreEmisorDefa = "";

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.EmisoresSelect();
                var res = db.Query<ClinicaFB.Modelo.Emisor>(sql).ToList();

                foreach (var emi in res)
                {
                    if (emi.Defa)
                    {
                        emisorIdDefa = emi.EmisorId;
                        nombreEmisorDefa = emi.Nombre;
                        break;
                    }

                }
                _emisores = new BindingList<ClinicaFB.Modelo.Emisor>(res);



            }
            cboEmisores.DataSource = null;
            cboEmisores.DataSource = _emisores;
            cboEmisores.ValueMember = "EmisorId";
            cboEmisores.DisplayMember = "Nombre";
            cboEmisores.SelectedValue = emisorIdDefa;

        }


        private void CargaAlmacenes()
        {

            int almacenIdDefa = 0;
            string nombreAlmacenDefa = "";

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.AlmacenesSelect();

                var res = db.Query<Almacen>(sql).ToList();

                foreach (var alma in res)
                {
                    if (alma.Defa)
                    {
                        almacenIdDefa = alma.AlmacenId;
                        nombreAlmacenDefa= alma.Nombre;
                        break;
                    }

                }
                _almacenes = new BindingList<Almacen>(res);



            }
            cboAlmacenes.DataSource = null;
            cboAlmacenes.DataSource = _almacenes;
            cboAlmacenes.ValueMember = "AlmacenId";
            cboAlmacenes.DisplayMember = "Nombre";
            cboAlmacenes.SelectedValue = almacenIdDefa;


        }
        private void CambiaColores()
        {
            txtNombrePaciente.BackColor = Color.LightGreen;
            txtNombrePaciente.ForeColor = Color.DarkBlue;

            txtRFC.BackColor = Color.LightGreen;
            txtRFC.ForeColor = Color.DarkBlue;


            txtRazonSocial.BackColor = Color.LightGreen;
            txtRazonSocial.ForeColor = Color.DarkBlue;

        }
        private void CargaDatosPaciente()
        {
            if (_pacienteId == 0)
            {
                return;

            }

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.PacienteSelect();
                Paciente pac = db.Query<Paciente>(sql, new { Paciente_Id = _pacienteId }).FirstOrDefault();

                if (pac != null)
                {
                    txtNombrePaciente.Text = pac.NombreCompleto;
                }
            }

        }

        private void CargaDatosRazonSocial()
        {
            if (_razonSocialId == 0)
            {
                return ;
            }

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.RazonSocialSelect();
                RazonSocial raz = db.Query<RazonSocial>(sql, new { RazonSocialId = _razonSocialId }).FirstOrDefault();

                if (raz != null)
                {
                    txtRFC.Text = raz.RFC;
                    txtRazonSocial.Text = raz.RazonSoc;
                    _cveFOP = raz.CveFOP;
                    _cveMEP = raz.CveMEP;
                    _cveUSO = raz.CveUSO;
                    _correos = raz.Email;
                }
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

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdBuscaPaciente_Click(object sender, EventArgs e)
        {
            PacienteBuscar pacienteBuscar = new PacienteBuscar();
            pacienteBuscar.ShowDialog();
            if (pacienteBuscar.Paciente_Id != 0)
            {
                _pacienteId = (int) pacienteBuscar.Paciente_Id;
                CargaDatosPaciente();
                
            }
            txtConcepto.Focus();
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
            txtConcepto.Focus();
        }

        private void txtConcepto_KeyDown(object sender, KeyEventArgs e)
        {

            bool agregar = false;
            switch (e.KeyCode) { 
                case Keys.Escape:
                    break;

                case Keys.F5:
                    ArticulosBuscar articulosBuscar = new ArticulosBuscar(txtConcepto.Text.Trim());
                    articulosBuscar.ShowDialog();

                    if (articulosBuscar.ArticuloId!= 0)
                    {

                        using (FbConnection db = General.GetDB())
                        {
                            string sql = Queries.ArticuloSelect();
                            Articulo art = db.Query<Articulo>(sql, new {ArticuloId = articulosBuscar.ArticuloId}).FirstOrDefault();
                            if (art != null)
                            {
                                txtConcepto.Text = art.Clave;
                                agregar = true;
                            }
                        }

                    }
                    break;
                case Keys.Enter:
                    if (string.IsNullOrEmpty(txtConcepto.Text))
                    {
                        return;
                    }
                    agregar= true;

                    break;
            }

            if (agregar)
            {
                AgregaArticulo();
                txtConcepto.Text = string.Empty;
                spnCantidad.Value = 1;
                txtConcepto.Focus();

            }

        }

        private void AgregaArticulo()
        {

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.ArticuloSelectxClave();
                Articulo art = db.Query<Articulo>(sql,new {Clave = txtConcepto.Text.Trim() }).FirstOrDefault();

                if (art == null)
                {
                    MessageBox.Show("Esa clave no existe","Aviso",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;

                }

                Impuesto imp = new Impuesto();

                int tipoIVA = 0;
                decimal tasaIVA = 0;

                if (art.ImpuestoId != 0)
                {
                    sql = Queries.ImpuestoSelect();
                    imp = db.Query<Impuesto>(sql, new {ImpuestoId = art.ImpuestoId }).FirstOrDefault();

                    if (imp!=null)
                    {
                        if (imp.Descripcion == "EXENTO")
                        {
                            tipoIVA= 2;
                            tasaIVA = 0;
                        }
                        else
                        {
                            tipoIVA = 1;
                            tasaIVA = imp.Porcentaje;

                        }
                    }

                }

                decimal baseIVA = Math.Round(spnCantidad.Value * art.Precio1, 2);
                decimal importeIVA = (tipoIVA==1)?Math.Round(baseIVA*tasaIVA/100,2):0;


                sql = Queries.SeriesConceptosSelectXArticulo();


                SerieConcepto serCon = db.Query<SerieConcepto>(sql, new {ArticuloId =art.ArticuloId }).FirstOrDefault();
                int emisorId = 0;
                string serie = "";
                string des = "";

                des = art.Descripcion.Trim();

                if (serCon != null)
                {
                    emisorId = serCon.EmisorId; serie = serCon.Serie;
                    if (serCon.AgregaPaciente && _pacienteId != 0)
                    {
                        des += " " + txtNombrePaciente.Text;
                    }


                }
                else
                {
                    emisorId = (int) cboEmisores.SelectedValue;
                    sql = Queries.SerieDefault();
                    SerieDoc serDefa = db.Query<SerieDoc>(sql, new {EmisorId = emisorId, Tipo="FAC"}).FirstOrDefault();

                    if (serDefa != null)
                    {
                        serie = serDefa.Serie;
                    }

                }


                _conceptos.Add(new IngresoDetalle
                {
                    ArticuloId = (int) art.ArticuloId,
                    Clave = txtConcepto.Text.Trim(),
                    Descripcion = des,
                    UDM = art.UDM,
                    CveUni = art.CveUni,
                    CveProSer = art.CveProSer,                    
                    Precio = art.Precio1,
                    Cantidad = spnCantidad.Value,
                    TipoIVA= tipoIVA,
                    BaseIVA= baseIVA,   
                    TasaIVA = tasaIVA,
                    IVA=importeIVA,
                    EmisorId=emisorId,
                    Serie= serie

                    
                });

                SetGrid();
                CalculaTotales();
                

            }

        }
        private void CalculaTotales()
        {
            decimal subTotal = 0, descuento = 0, IVA = 0, retISR = 0, retIVA = 0;

            foreach (var concepto in _conceptos)            
            {
                subTotal+= concepto.Total;
                descuento+= concepto.Descuento;
                IVA+= concepto.IVA;
                retISR+= concepto.RetISR;
                retIVA+= concepto.RetIVA;
            }

            txtSubTotal.DecimalValue = subTotal;
            txtDescuento.DecimalValue = descuento;
            txtIVA.DecimalValue = IVA;
            txtRetISR.DecimalValue = retISR;
            txtRetIVA.DecimalValue = retIVA;
            txtTotal.DecimalValue = subTotal - descuento + IVA - retISR - retIVA;


        }

        private void cmdTicket_Click(object sender, EventArgs e)
        {

            if (_conceptos.Count == 0)
            {
                MessageBox.Show("No se ha agregado ningún concepto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }

            TicketEnviarOpciones opciones = new TicketEnviarOpciones();
            opciones.ShowDialog();

            if (opciones.Aceptar == false)
            {
                return;
            }

            _imprimir = opciones.chkImprimir.Checked;
            _mandarCorreos = opciones.chkMandarCorreo.Checked;
            _correos=opciones.txtCorreos.Text.Trim();
           GuardaIngreso(false);
        }

        private void cmdConceptoBorrar_Click(object sender, EventArgs e)
        {
            if (grdConceptos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione el concepto a borrar","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            _conceptos.RemoveAt(grdConceptos.CurrentRow.Index);
            SetGrid();
            CalculaTotales();
        }

        private void cmdFactura_Click(object sender, EventArgs e)
        {
            if (_conceptos.Count == 0)
            {
                MessageBox.Show("No se ha agregado ningún concepto", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }

            IngresoFacturarOpciones clavesSATSeleccionar = new IngresoFacturarOpciones(_razonSocialId,_cveFOP,_cveMEP,_cveUSO,_correos);
            clavesSATSeleccionar.ShowDialog();

            if (clavesSATSeleccionar.Aceptar == false)
            {
                return;
            }

            _cveFOP = clavesSATSeleccionar.txtCveFOP.Text.Trim();
            _cveMEP = clavesSATSeleccionar.txtCveMEP.Text.Trim();
            _cveUSO = clavesSATSeleccionar.txtCveUSO.Text.Trim();
            _imprimir = clavesSATSeleccionar.chkImprimir.Checked;
            _impresora = clavesSATSeleccionar.cboImpresoras.Text.Trim();
            _mandarCorreos = clavesSATSeleccionar.chkMandarCorreo.Checked;
            _correos = clavesSATSeleccionar.txtCorreos.Text.Trim();

            GuardaIngreso(true);
            
        }

        private void cmdConceptoModificar_Click(object sender, EventArgs e)
        {
            if (grdConceptos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un concepto para modificar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            IngresoDetalle concepto = _conceptos[grdConceptos.CurrentRow.Index];
            ConceptoModificar conceptoModificar = new ConceptoModificar(concepto,txtNombrePaciente.Text.Trim(), (int)cboEmisores.SelectedValue);
            conceptoModificar.ShowDialog();

            if (conceptoModificar._guardar)
            {
                _conceptos[grdConceptos.CurrentRow.Index] = conceptoModificar._concepto;
                SetGrid();
                CalculaTotales();

            }

        }

        private void grdConceptos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cmdConceptoModificar_Click(sender, e);
        }

        private void txtConcepto_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRFC_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
