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

namespace ClinicaFB.PuntoDeVenta.Procesos
{
    public partial class ArticulosAsignar : Form
    {
        public List<Temporal> temporales = new List<Temporal>();
        public List<Articulo> articulos = new List<Articulo>();
        public ArticulosAsignar()
        {
            InitializeComponent();
        }

        private void ArticulosAsignar_Load(object sender, EventArgs e)
        {

            CargaDatos();
            AsignarArticulos();
            var sinArticuloId = temporales.Where(t => t.ArticuloId == 0).ToList();  
            grdArticulosFactura.DataSource = sinArticuloId;
            grdArticulos.DataSource = articulos;

            // Suscribir al evento SelectionChanged
            grdArticulosFactura.SelectionChanged += GrdArticulosFactura_SelectionChanged;
            
            // Suscribir al evento TextChanged del textbox
            txtBuscar.TextChanged += TxtBuscar_TextChanged;
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            FiltrarArticulos();
        }

        private void FiltrarArticulos()
        {
            string filtro = txtBuscar.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(filtro))
            {
                // Si el textbox está vacío, mostrar todos los artículos
                grdArticulos.DataSource = articulos;
            }
            else
            {
                // Filtrar artículos por descripción
                var resultado = articulos.Where(a => a.Descripcion.ToLower().Contains(filtro)).ToList();
                grdArticulos.DataSource = resultado;
            }
        }

        private void GrdArticulosFactura_SelectionChanged(object sender, EventArgs e)
        {

            if (grdArticulosFactura.CurrentRow != null && grdArticulosFactura.CurrentRow.Index >= 0)
            {
                // Obtener el temporal del renglón seleccionado
                var temporal = (Temporal)grdArticulosFactura.CurrentRow.DataBoundItem;
                
                // Actualizar el txtBuscar con la descripción del temporal
                txtBuscar.Text = temporal.Descripcion ?? string.Empty;
                
                BuscaArticulo(grdArticulosFactura.CurrentRow.Index);
            }
        }



        private void CargaDatos()
        {
            using (FbConnection db = General.GetDB())
            {
                string sql = "SELECT * FROM TEMPO order by TempoId";
                temporales = db.Query<Temporal>(sql).ToList();
                sql = Queries.ArticulosSelect();
                articulos = db.Query<Articulo>(sql).ToList();
            }
        }


        public void CargaArticulos()
        {
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.ArticulosSelect();
                articulos = db.Query<Articulo>(sql).ToList();
                grdArticulos.DataSource = articulos;
            }
        }

        private void cmdPasarID_Click(object sender, EventArgs e)
        {
            if (grdArticulos.CurrentRow != null && grdArticulosFactura.CurrentRow != null)
            {
                int renFactura = grdArticulosFactura.CurrentRow.Index;
                
                // Obtener el ArticuloId de la columna colArticuloId del grid
                var cellValue = grdArticulos.CurrentRow.Cells["colArtId"].Value;
                
                if (cellValue != null && long.TryParse(cellValue.ToString(), out long articuloId))
                {
                    var temporal = (Temporal)grdArticulosFactura.CurrentRow.DataBoundItem;
                    temporal.ArticuloId = articuloId;
                    
                    // Actualizar en la base de datos
                    string sql = "UPDATE TEMPO SET ArticuloId = @ArticuloId WHERE TempoId = @TempoId";
                    using (FbConnection db = General.GetDB())
                    {
                        db.Execute(sql, new { ArticuloId = articuloId, temporal.TempoId });
                    }
                    
                    grdArticulosFactura.Refresh();
                }
            }
        }

        public void BuscaArticulo(int indice)
        {
            if (grdArticulosFactura.Rows[indice] == null || grdArticulosFactura.Rows[indice].Index < 0)
                return;

            int renFactura = grdArticulosFactura.Rows[indice].Index;

            string filtro = temporales[renFactura].Descripcion.ToLower();
            var resultado = articulos.Where(a => a.Descripcion.ToLower().Contains(filtro)).ToList();
            grdArticulos.DataSource = resultado;
        }

        private void AsignarArticulos()
        {
            foreach (Temporal temporal in temporales)
            {

                string filtro = temporal.Descripcion.ToLower();
                var resultado = articulos.Where(a => a.Descripcion.ToLower().Contains(filtro)).ToList();

                if (resultado.Count == 1)
                {

                    temporal.ArticuloId = resultado[0].ArticuloId;
                    string sql = "update TEMPO set ArticuloId = @ArticuloId where TempoId = @TempoId";

                    using (FbConnection db = General.GetDB())
                        db.Execute(sql, new { temporal.ArticuloId, temporal.TempoId });
                }

            }

        }
    }
}
