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

namespace ClinicaFB.Configuracion
{
    public partial class SeriesDocsAltasCambios : Form
    {
        private bool _esAlta;
        private int _emisorId;
        private string _tipo;
        private int _serieId;


        public SeriesDocsAltasCambios(bool esAlta, int emisorId,string tipo, int serieId)
        {
            InitializeComponent();
            _esAlta = esAlta;
            _emisorId = emisorId;
            _tipo = tipo;
            _serieId = serieId;
        }

        private void SeriesDocsAltasCambios_Load(object sender, EventArgs e)
        {
            if (_esAlta)
            {
                Text = "Agregar serie";
            }
            else
            {
                Text = "Modificar serie";
                txtSerie.ReadOnly = true;
                CargaSerie();
                spnFolio.Focus();

            }

        }

        private void CargaSerie()
        {

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.SerieDocSelect();
                SerieDoc ser = db.Query<SerieDoc>(sql, new { SerieDocId = _serieId }).FirstOrDefault();
                if (ser != null)
                {
                    txtSerie.Text = ser.Serie;
                    spnFolio.Value = ser.Folio;
                    chkActiva.Checked= ser.Activa;
                    chkDefault.Checked = ser.Defa;
                }

            }
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSerie.Text))
            {
               // MessageBox.Show("Teclee la serie","Aviso",MessageBoxButtons.OK, MessageBoxIcon.Information);
               // txtSerie.Focus();
                //return;
            }
            if (spnFolio.Value < 1)
            {
                MessageBox.Show("Folio no permitido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                spnFolio.Focus();
                return;

            }
            

            using (FbConnection db = General.GetDB())
            {
                string sql = "";

                if (_esAlta) { 
                    sql = Queries.SerieDocSelectXEmisorTipoSerie();
                    var res = db.QueryFirstOrDefault<SerieDoc>(sql, new { EmisorId = _emisorId,Tipo=_tipo, Serie=txtSerie.Text.Trim() });
                    if (res != null)
                    {
                        MessageBox.Show("La serie ya está registrada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtSerie.Focus();
                        return;

                    }
                }

                sql = _esAlta ? Queries.SerieDocInsert() : Queries.SerieDocUpdate();
                SerieDoc ser = new SerieDoc();
                ser.SerieDocId = _serieId; 
                ser.EmisorId = _emisorId;
                ser.Tipo = _tipo;
                ser.Serie = txtSerie.Text;
                ser.Folio = (int) spnFolio.Value;
                ser.Activa = chkActiva.Checked;
                ser.Defa = chkDefault.Checked;

                if (_esAlta)
                {
                  _serieId =  db.ExecuteScalar<int>(sql, ser);

                }
                else
                {
                    db.Execute(sql, ser);

                }

                if (ser.Defa)
                {
                    sql = Queries.SerieDocUpdateQuitaDefault();
                    db.Execute(sql, new {SerieDocId = _serieId });
                }

            }
            Close();

        }
    }
}
