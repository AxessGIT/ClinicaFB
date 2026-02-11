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
using System.Xml;

namespace ClinicaFB.PuntoDeVenta.Procesos
{
    public partial class CargarDetalle : Form
    {
        public CargarDetalle()
        {
            InitializeComponent();
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdSeleccionarArchivo_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "Archivos XML (*.xml)|*.xml|Todos los archivos (*.*)|*.*";
                fileDialog.FilterIndex = 1;
                fileDialog.Title = "Seleccionar archivo XML";
                
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtArchivoXML.Text = fileDialog.FileName;

                    try
                    {
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.Load(fileDialog.FileName);

                        XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDoc.NameTable);
                        nsmgr.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/3");
                        nsmgr.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/4");

                        XmlNode comprobanteNode = xmlDoc.SelectSingleNode("//cfdi:Comprobante", nsmgr);

                        if (comprobanteNode == null)
                        {
                            MessageBox.Show("El archivo XML no contiene un nodo cfdi:Comprobante válido.", 
                                "Archivo inválido", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Warning);
                            txtArchivoXML.Text = string.Empty;
                            return;
                        }

                        MessageBox.Show("Archivo CFDI válido cargado correctamente.", 
                            "Éxito", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Information);
                    }
                    catch (XmlException ex)
                    {
                        MessageBox.Show($"Error al leer el archivo XML: {ex.Message}", 
                            "Error de XML", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Error);
                        txtArchivoXML.Text = string.Empty;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al cargar el archivo: {ex.Message}", 
                            "Error", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Error);
                        txtArchivoXML.Text = string.Empty;
                    }
                }
            }

        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(txtArchivoXML.Text))
            {
                MessageBox.Show("Indique todos los valores", 
                    "Archivo no seleccionado", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);
                return;
            }
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.VentaSelectxSerieyFolio;
                //int almacenId = 1;
                //int emisorId = 1;

                /*Venta vta = db.QueryFirstOrDefault<Venta>(sql, new { Serie = txtSerie.Text.Trim(), Folio = Convert.ToInt32(txtFolio.Text), AlmacenId = almacenId, EmisorId = emisorId });

                if (vta == null)
                {
                    MessageBox.Show("No se encontró la venta con la serie y folio indicados.", 
                        "Venta no encontrada", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Warning);
                    return;
                }*/
                int ventaId = 4500;
                string xmlContent;
                try
                {
                    xmlContent = System.IO.File.ReadAllText(txtArchivoXML.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al leer el archivo XML: {ex.Message}", 
                        "Error de archivo", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Error);
                    return;
                }

                // Cargar los conceptos del CFDI
                try
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xmlContent);

                    XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDoc.NameTable);
                    nsmgr.AddNamespace("cfdi", "http://www.sat.gob.mx/cfd/4");

                    XmlNodeList conceptosNodes = xmlDoc.SelectNodes("//cfdi:Comprobante/cfdi:Conceptos/cfdi:Concepto", nsmgr);


                    if (conceptosNodes == null || conceptosNodes.Count == 0)
                    {
                        MessageBox.Show("No se encontraron conceptos en el CFDI.", 
                            "Sin conceptos", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Warning);
                        return;
                    }

                    List<VentaDetalle> detalles = new List<VentaDetalle>();

                    foreach (XmlNode concepto in conceptosNodes)
                    {

                        decimal tasaIVA = 0;


                        string codigo = concepto.Attributes["NoIdentificacion"]?.Value ?? "";
                        if (string.IsNullOrEmpty(codigo))
                            continue;

                        sql = Queries.ArticuloSelectxCodigo;
                        var articulo = db.QueryFirstOrDefault<Articulo>(sql, new { CodigoBarras = codigo});

                        if (articulo == null)
                            continue;

                        if (articulo.ImpuestoId == 1)
                        {
                            tasaIVA = 0.16M;
                        }

                        VentaDetalle detalle = new VentaDetalle
                        {


                            VentaId = ventaId,
                            ArticuloId = articulo.ArticuloId,
                            NoIden = codigo,
                            Descripcion = articulo.Descripcion,
                            UDM = articulo.UDM,
                            Cantidad = Convert.ToDecimal(concepto.Attributes["Cantidad"]?.Value ?? "0"),
                            Precio = Convert.ToDecimal(concepto.Attributes["ValorUnitario"]?.Value ?? "0"),
                            TipoIVA = 1,
                            CveProSer = concepto.Attributes["ClaveProdServ"]?.Value ?? "",
                            CveUni = concepto.Attributes["ClaveUnidad"]?.Value ?? "",
                            TasaIVA = tasaIVA*100
                        };

                        detalle.IVA = Math.Round(detalle.Cantidad * detalle.Precio * detalle.TasaIVA / 100, 2);
                        detalles.Add(detalle);
                    }

                    // Insertar los detalles en la base de datos
                    string sqlInsert = Queries.VentaDetalleInsert;
                    
                    foreach (var detalle in detalles)
                    {
                        db.Execute(sqlInsert, detalle);
                    }

                    MessageBox.Show($"Se cargaron {detalles.Count} conceptos correctamente.", 
                        "Éxito", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Information);
                    
                    Close();
                }
                catch (XmlException ex)
                {
                    MessageBox.Show($"Error al procesar el XML del CFDI: {ex.Message}", 
                        "Error XML", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los conceptos: {ex.Message}", 
                        "Error", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Error);
                }
            }
        }
    }
}
