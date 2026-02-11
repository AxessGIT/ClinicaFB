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
    public partial class ArticuloExistencias : Form
    {
        private int _articuloId = 0;
        BindingList<ArticuloExistencia> _existencias = new BindingList<ArticuloExistencia>();

        public ArticuloExistencias(int articuloId)
        {
            InitializeComponent();
            _articuloId = articuloId;
        }

        private void Kardex_Load(object sender, EventArgs e)
        {
            BuscaArticulo();
            CargaExistencias();
            SetGrid();
        }
        private void CargaExistencias()
        {
            _existencias = UtilsInv.GetArticuloExistencias(_articuloId);
        }
        private void BuscaArticulo()
        {
            using (FbConnection db = General.GetDB())
            {
                Articulo articulo = new Articulo();
                string sql = Queries.ArticuloSelect();
                articulo = db.Query<Articulo>(sql, new { ArticuloId = _articuloId }).FirstOrDefault();
                if (articulo == null)
                       return;

                txtClave.Text = articulo.Clave;
                txtCodigoBarras.Text = articulo.CodigoBarras;
                txtDescripcion.Text = articulo.Descripcion;



            }

        }
        private void SetGrid()
        {
            grdExistencias.DataSource = null;



            grdExistencias.AllowUserToAddRows = false;
            grdExistencias.AllowUserToDeleteRows = false;


            grdExistencias.AutoGenerateColumns = false;
            grdExistencias.ReadOnly = true;
            grdExistencias.AllowUserToResizeColumns = false;
            grdExistencias.AllowUserToResizeRows = false;



            grdExistencias.ColumnHeadersDefaultCellStyle.Font = new Font(grdExistencias.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            grdExistencias.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;



            grdExistencias.DataSource = _existencias;

        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
