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
    public partial class SucursalesAltasCambios : Form
    {
        private bool _esAlta=false;
        private int _sucursalId = 0;
        public SucursalesAltasCambios(bool esAlta,int sucursalId)
        {
            InitializeComponent();
            _esAlta = esAlta;
            _sucursalId=sucursalId;
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SucursalesAltasCambios_Load(object sender, EventArgs e)
        {
            if (_esAlta)
            {
                Text = "Agregar sucursal";
            }

            else
            {
                Text = "Modificar sucursal";
                CargaDatos();
            }
        }

        private void GuardaDatos()
        {
            if (string.IsNullOrEmpty(txtNombre.Text.Trim()))
            {
                MessageBox.Show("Teclee el nombre", "Aviso", MessageBoxButtons.OK);
                txtNombre.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtSerie.Text.Trim()))
            {
                MessageBox.Show("Teclee la serie", "Aviso", MessageBoxButtons.OK);
                txtSerie.Focus();
                return;
            }

            if (spnFolio.Value<1)
            {
                MessageBox.Show("Teclee el folio", "Aviso", MessageBoxButtons.OK);
                spnFolio.Focus();
                return;
            }


            using (FbConnection db = General.GetDB())
            {
                string sql = _esAlta?Queries.SucursalInsert():Queries.SucursalUpdate();
                Sucursal suc = new Sucursal();
                suc.SucursalId = _sucursalId;
                suc.Nombre= txtNombre.Text.Trim();
                suc.DatosAdicionales = txtDatosAdicionales.Text.Trim();
                suc.SerieIngresos= txtSerie.Text.Trim();
                suc.FolioIngresos = (int) spnFolio.Value;
                suc.SerieFacGlobal = txtSerieFacturaGlobal.Text.Trim();
                suc.FolioFacGlobal = (int)spnFolioFacturaGlobal.Value;
                suc.SerieFacPDV = txtSerieFacturaPDV.Text.Trim();
                suc.FolioFacPDV = (int)spnFolioFacturaPDV.Value;
                suc.SerieVentas = txtSerieVentas.Text.Trim();
                suc.FolioVentas = (int)spnFolioVentas.Value;
                suc.SerieNC = txtSerieNC.Text.Trim();
                suc.FolioNC = (int)spnFolioNC.Value;
                suc.CarpetaReportes = txtCarpetaReportes.Text.Trim();
                suc.CarpetaImagenes = txtCarpetaImagenes.Text.Trim();

                db.Execute(sql, suc);

            }


        }

        private void CargaDatos()
        {

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.SucursalSelect();
                Sucursal suc = db.Query<Sucursal>(sql, new {SucursalId = _sucursalId}).FirstOrDefault();

                if (suc == null)
                {
                    return;

                }

                txtNombre.Text = suc.Nombre;
                txtDatosAdicionales.Text = suc.DatosAdicionales;
                txtSerie.Text = suc.SerieIngresos;
                spnFolio.Value = suc.FolioIngresos;
                txtSerieFacturaGlobal.Text = suc.SerieFacGlobal;
                spnFolioFacturaGlobal.Value = suc.FolioFacGlobal;
                txtSerieFacturaPDV.Text = suc.SerieFacPDV;
                spnFolioFacturaPDV.Value = suc.FolioFacPDV;
                txtSerieVentas.Text = suc.SerieVentas;
                spnFolioVentas.Value = suc.FolioVentas;
                txtSerieNC.Text = suc.SerieNC;
                spnFolioNC.Value = suc.FolioNC;
                txtCarpetaReportes.Text = suc.CarpetaReportes;
                txtCarpetaImagenes.Text = suc.CarpetaReportes;


            }
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            GuardaDatos();
            Close();
        }

        private void cmdBuscaCarpetaReportes_Click(object sender, EventArgs e)
        {
            BuscaCarpeta(ref txtCarpetaReportes);
        }

        private void cmdBuscaCarpetaImagenes_Click(object sender, EventArgs e)
        {
            BuscaCarpeta(ref txtCarpetaImagenes);
        }

        private void BuscaCarpeta(ref TextBox cuadroTexto)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Seleccione la carpeta";
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                cuadroTexto.Text = fbd.SelectedPath;
            }
        }
    }
}
