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
    public partial class SalidasListado : Form
    {
        BindingList<Documento> _salidas = new BindingList<Documento>();

        public SalidasListado()
        {
            InitializeComponent();
        }

        private void SalidasListado_Load(object sender, EventArgs e)
        {
            dtpFechaInicial.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpFechaFinal.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            CargaSalidas();
            SetGrid();

        }
        private void CargaSalidas()
        {
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.SalidasSelect;
                var res = db.Query<Documento>(sql, new { FechaIni = dtpFechaInicial.Value, FechaFin = dtpFechaFinal.Value }).ToList();
                _salidas = new BindingList<Documento>(res);
            }
        }


        private void AltasCambios (bool esAlta)
        {
            long salidaId = 0;
            if (!esAlta)
            {
                salidaId = _salidas[grdSalidas.CurrentRow.Index].DocumentoId;
            }
            SalidasAltasCambios salidasAltasCambios = new SalidasAltasCambios(esAlta, salidaId);
            salidasAltasCambios.ShowDialog();
            CargaSalidas();
            SetGrid();
        }

        private void SetGrid()
        {
            grdSalidas.DataSource = null;



            grdSalidas.AllowUserToAddRows = false;
            grdSalidas.AllowUserToDeleteRows = false;


            grdSalidas.AutoGenerateColumns = false;
            grdSalidas.ReadOnly = true;
            grdSalidas.AllowUserToResizeColumns = false;
            grdSalidas.AllowUserToResizeRows = false;



            grdSalidas.ColumnHeadersDefaultCellStyle.Font = new Font(grdSalidas.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            grdSalidas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;



            grdSalidas.DataSource = _salidas;

        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            AltasCambios(true);
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            if (grdSalidas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una salida");
                return;
            }
            AltasCambios(false);
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdBorrar_Click(object sender, EventArgs e)
        {
            if (grdSalidas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una salida para borrar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("¿Está seguro de borrar la salida?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            long salidaId = _salidas[grdSalidas.CurrentRow.Index].DocumentoId;
            //Almacen almacen = new Almacen();
            long almacenId = _salidas[grdSalidas.CurrentRow.Index].AlmacenId;

            using (FbConnection db = General.GetDB())
            {
                string sql = "";
                sql = Queries.DocumentoDetalleSelect;
                var res = db.Query<DocumentoDetalle>(sql, new { DocumentoId = salidaId }).ToList();


                ArticuloExistencia articuloExistencia = new ArticuloExistencia();

                foreach (var borrado in res)
                {
                    sql = Queries.ArticuloExistenciaSelect;
                    articuloExistencia = db.Query<ArticuloExistencia>(sql, new { ArticuloId = borrado.ArticuloId, AlmacenId = almacenId }).FirstOrDefault();

                    if (articuloExistencia == null)
                        continue;

                    articuloExistencia.Salidas -= borrado.Cantidad;
                    sql = Queries.ArticuloExistenciaUpdate;
                    db.Execute(sql, articuloExistencia);

                }

                sql = Queries.DocumentoMovimientosDelete;
                db.Execute(sql, new {EsVenta = false, DocumentoId = salidaId });


                sql = Queries.DocumentoDetalleDelete;
                db.Execute(sql, new { DocumentoId = salidaId });

                sql = Queries.DocumentoDelete;
                db.Execute(sql, new { DocumentoId = salidaId });
            }

            CargaSalidas();
            SetGrid();

        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            CargaSalidas();
            SetGrid();
        }
    }
}
