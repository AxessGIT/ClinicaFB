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
    public partial class ConceptosAltasCambios : Form
    {
        private long _conceptoId = 0;
        private bool _esAlta = true;
        private string _tipo = "";

        public ConceptosAltasCambios(bool esAlta,string tipo, long conceptoId)
        {
            InitializeComponent();
            _conceptoId = conceptoId;
            _esAlta = esAlta;
            _tipo = tipo;
        }

        private void ConceptosAltasCambios_Load(object sender, EventArgs e)
        {
            txtTipo.Text = _tipo=="E"?"ENTRADA":"SALIDA";
            if (_esAlta)
            {
                this.Text = "Alta de Concepto";
            }
            else
            {
                this.Text = "Cambio de Concepto";
                CargaConcepto();
                CargaFolio();
            }
            ActiveControl = txtDescripcion;
        }


        private void CargaConcepto()
        {
            using (FbConnection db = General.GetDB()) {
                string sql = Queries.ConceptoSelect;
                ConceptoMovInv concepto = db.QueryFirst<ConceptoMovInv>(sql, new { ConMovInvId = _conceptoId });
                if (concepto==null)
                {
                   
                    return;
                }
                
                txtDescripcion.Text = concepto.Descripcion;
                cboPrecioCosto.SelectedIndex = concepto.PrecioCosto == "C" ? 0 : 1;
                chkEsVenta.Checked = concepto.EsVenta;
            }
        }

        private void CargaFolio()
        {
            using (FbConnection db = General.GetDB())
            {
                Sucursal sucursal = General.GetDatosSucursal();
                long sucursalId = sucursal.SucursalId;
                string sql = Queries.ConceptoInvFolioSelectBySucursal;
                ConceptoMovInvFolio folio = db.QueryFirstOrDefault<ConceptoMovInvFolio>(sql, new { SucursalId = sucursalId, ConceptoId = _conceptoId});
                if (folio != null)
                {
                    spnFolio.Value = folio.Folio;
                }
            }
        }

        private void GuardaFolio() {             
            using (FbConnection db = General.GetDB())
            {
                Sucursal sucursal = General.GetDatosSucursal();
                long sucursalId = sucursal.SucursalId;
                string sql = Queries.ConceptoInvFolioSelectBySucursal;
                ConceptoMovInvFolio folio = db.QueryFirstOrDefault<ConceptoMovInvFolio>(sql, new { SucursalId = sucursalId, ConceptoId = _conceptoId });
                if (folio == null)
                {
                    sql = Queries.ConceptoInvFolioInsert;
                    db.Execute(sql, new
                    {
                        SucursalId = sucursalId,
                        ConceptoId = _conceptoId,
                        Serie = txtSerie.Text,
                        Folio = spnFolio.Value
                    });
                }
                else
                {
                    sql = Queries.ConceptoInvFolioUpdate;
                    db.Execute(sql, new
                    {
                        Serie = txtSerie.Text,
                        Folio = spnFolio.Value,
                        folio.ConInvFolId
                    });
                }
            }
        }


        private bool Guardar(){

            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                MessageBox.Show("Debe capturar la descripcion del concepto");
                return false;
            }
            using (FbConnection db = General.GetDB())
            {
                string sql = "";
                string precioCosto = cboPrecioCosto.SelectedIndex == 0 ? "C" : "P";
                if (_esAlta)
                {
                    sql = Queries.ConceptoInsert;
                    long conceptoId = db.ExecuteScalar<long>(sql, new
                    {
                        Tipo = _tipo,
                        Descripcion = txtDescripcion.Text,
                        EsVenta = chkEsVenta.Checked,
                        PrecioCosto = precioCosto,
                        Reservado = false
                    });

                    _conceptoId = conceptoId;
                }
                else
                {
                    sql = Queries.ConceptoUpdate;
                    db.Execute(sql, new
                    {
                        Tipo = _tipo,
                        Descripcion = txtDescripcion.Text,
                        EsVenta = chkEsVenta.Checked,
                        PrecioCosto = precioCosto,
                        Reservado = false,
                        ConMovInvId = _conceptoId
                    });
                }
            }

            GuardaFolio();
            return true;
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            if (Guardar())
            {
                Close();
            }   
        }
    }
}
