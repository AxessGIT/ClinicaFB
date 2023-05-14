using ClinicaFB.Helpers;
using ClinicaFB.Modelo;
using ClinicaFB.PuntoDeVenta;
using Dapper;
using FirebirdSql.Data.FirebirdClient;
using Syncfusion.DocIO.DLS;
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

    public partial class SeriesConceptosAltasCambios : Form
    {
        private bool _esAlta = false;
        private int _serieConceptoId = 0;
        private int _serieId = 0;
        private int _articuloId=0;

        public SeriesConceptosAltasCambios(bool esAlta, int serieConceptoId, int serieId)
        {
            InitializeComponent();
            _esAlta = esAlta;
            _serieConceptoId = serieConceptoId;
            _serieId = serieId; 
        }

        private void SeriesConceptosAltasCambios_Load(object sender, EventArgs e)
        {
            txtDescripcion.BackColor = Color.White;
            txtDescripcion.ForeColor = Color.Black;

            txtPrecio.BackGroundColor= Color.White;
            txtPrecio.ForeColor = Color.Black;

            txtTipo.BackColor = Color.White;
            txtTipo.ForeColor = Color.Black;

            txtUDM.BackColor = Color.White;
            txtUDM.ForeColor = Color.Black;

            txtCveProSer.BackColor= Color.White;
            txtCveProSer.ForeColor = Color.Black;

            txtCveUni.BackColor = Color.White;
            txtCveUni.ForeColor = Color.Black;

            if (_esAlta)
            {
                Text = "Agregar concepto";

            }
            else
            {
                Text = "Modificar concepto";
                CamposAPropiedades();
            }

        }

        private void CamposAPropiedades()
        {

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.SerieConceptoSelect();
                SerieConcepto serCon = db.Query<SerieConcepto>(sql, new { SerieConceptoId = _serieConceptoId }).FirstOrDefault();
                if (serCon == null)
                {
                    return;
                }

                _articuloId = serCon.ArticuloId;
                MuestraArticulo();
                txtPorceRetISR.DoubleValue = (double)serCon.PorceRetISR;
                txtPorceRetIVA.DoubleValue = (double)serCon.PorceRetIVA;
                chkAgregarNombrePaciente.Checked = serCon.AgregaPaciente;



            }

        }

        private void GuardaSerieConcepto()
        {
            SerieConcepto serCon= new SerieConcepto();

            serCon.SerieConceptoId= _serieConceptoId;
            serCon.SerieId = _serieId;
            serCon.ArticuloId= _articuloId;
            serCon.PorceRetISR = (decimal)txtPorceRetISR.DoubleValue;
            serCon.PorceRetIVA = (decimal)txtPorceRetIVA.DoubleValue;
            serCon.AgregaPaciente = chkAgregarNombrePaciente.Checked;

            string sql = _esAlta?Queries.SerieConceptoInsert():Queries.SerieConceptoUpdate();


            using (FbConnection db = General.GetDB())
            {
                if (_esAlta)
                {
                    _serieConceptoId = db.ExecuteScalar<int>(sql,serCon);
                }
                else
                {
                    db.Execute(sql,serCon);
                }

            }


        }

        private void cmdBuscarArticulo_Click(object sender, EventArgs e)
        {
            ArticulosBuscar articulosBuscar = new ArticulosBuscar();
            articulosBuscar.ShowDialog();

            if (articulosBuscar.ArticuloId == 0)
            {
                return;
            }

            _articuloId = articulosBuscar.ArticuloId;

            if (_articuloId== 0)
            {
                return;
            }

            MuestraArticulo();

        }

        private void MuestraArticulo()
        {

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.ArticuloSelect();
                Articulo art = db.Query<Articulo>(sql, new { ArticuloId = _articuloId }).FirstOrDefault();
                if(art == null)
                {
                    return;
                }

                txtClave.Text = art.Clave;
                txtDescripcion.Text = art.Descripcion;
                txtPrecio.DecimalValue = art.Precio1;
                txtTipo.Text = art.Tipo == 1 ? "Producto" : "Servicio";
                txtUDM.Text = art.UDM;
                txtCveProSer.Text = art.CveProSer;
                txtCveUni.Text = art.CveUni;

                sql = Queries.ImpuestoSelect();

                Impuesto imp = db.Query<Impuesto>(sql, new {ImpuestoId = art.ImpuestoId }).FirstOrDefault();

                if (imp == null)
                    return;

                txtImpuesto.Text = imp.Descripcion;
            }

        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            if (_articuloId == 0)
            {
                MessageBox.Show("Indique el artículo","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information); 
                return;
            }
            GuardaSerieConcepto();
            Close();
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
