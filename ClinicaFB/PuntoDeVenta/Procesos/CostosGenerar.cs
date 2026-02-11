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

    public partial class CostosGenerar : Form
    {
        private List<UltimoCosto> _ultimosCostos = new List<UltimoCosto>(); 
        public CostosGenerar()
        {
            InitializeComponent();
        }

        private void cmdCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CostosGenerar_Load(object sender, EventArgs e)
        {

        }

        private void cmdExaminar_Click(object sender, EventArgs e)
        {
            string archivoCSV = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivos CSV (*.csv)|*.csv|Todos los archivos (*.*)|*.*";
                openFileDialog.Title = "Seleccionar archivo CSV de costos";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    archivoCSV = openFileDialog.FileName;
                    txtArchivoCSV.Text = archivoCSV;

                }
            }
        }

        private void cmdGenerar_Click(object sender, EventArgs e)
        {
            string archivoCSV = txtArchivoCSV.Text.Trim();
            if (string.IsNullOrEmpty(archivoCSV) || !System.IO.File.Exists(archivoCSV))
            {
                MessageBox.Show("Por favor, seleccione un archivo CSV válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                _ultimosCostos.Clear();
                var lineas = System.IO.File.ReadAllLines(archivoCSV);
                foreach (var linea in lineas)
                {
                    var partes = linea.Split(',');
                    if (partes.Length == 2)
                    {
                        var ultimoCosto = new UltimoCosto
                        {
                            Descripcion = partes[0].Trim(),
                            Costo = decimal.Parse(partes[1].Trim())
                        };
                        _ultimosCostos.Add(ultimoCosto);
                    }
                }

                using (FbConnection db = General.GetDB())
                {
                    string sql = Queries.ArticulosSinCostoSelect;
                    List<Articulo> articulosSinCosto = db.Query<Articulo>(sql).ToList();

                    foreach (Articulo art in articulosSinCosto)
                    {
                        sql = Queries.ArticuloCostoUltimaCompraSelect;
                        UltimaFechaYCosto ultimaFechaYCosto = db.QueryFirstOrDefault<UltimaFechaYCosto>(sql, new {art.ArticuloId});

                        if (ultimaFechaYCosto != null)
                        {

                            sql = Queries.ArticuloUpdateFechaUltimaCompra;
                            db.Execute(sql, new { art.FechaUltimaCompra, art.ArticuloId });
                            sql = Queries.ArticuloUpdateCosto;
                            db.Execute(sql, new { art.Costo, art.ArticuloId });

                            art.FechaUltimaCompra = ultimaFechaYCosto.FechaUltimaCompra;
                            art.Costo = ultimaFechaYCosto.Costo;
                        }
                        else 
                        { 
                                // Buscar el último costo en la lista de costos proporcionada
                                var ultimoCosto = _ultimosCostos.FirstOrDefault(c => c.Descripcion.Equals(art.Descripcion, StringComparison.OrdinalIgnoreCase));
                                if (ultimoCosto != null)
                                {
                                    art.Costo = ultimoCosto.Costo;
                                    art.FechaUltimaCompra = DateTime.Now; // Asignar la fecha actual como fecha de última compra
    
                                    // Actualizar el artículo con el nuevo costo y fecha de última compra
                                    sql = Queries.ArticuloUpdateCosto;
                                    db.Execute(sql, new { art.Costo, art.ArticuloId });
                            }
                        }
                    }

                }

                MessageBox.Show("Costos generados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar el archivo CSV: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class UltimoCosto
    {
        public string Descripcion { get; set; }
        public decimal Costo { get; set; }
    }

    public class UltimaFechaYCosto
    {
        public DateTime FechaUltimaCompra { get; set; }
        public decimal Costo { get; set; }
    }

}
