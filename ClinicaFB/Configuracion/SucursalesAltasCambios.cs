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
            }
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            GuardaDatos();
            Close();
        }
    }
}
