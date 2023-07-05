using ClinicaFB.Helpers;
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
using Dapper;
using ClinicaFB.Modelo;

namespace ClinicaFB.PuntoDeVenta
{
    public partial class AlmacenesAltasCambios : Form
    {
        private int _almacenId;
        private bool _esAlta;

        public AlmacenesAltasCambios(bool esAlta, int almacenId)
        {
            InitializeComponent();
            _almacenId = almacenId;
            _esAlta = esAlta;   
        }

        private void AlmacenesAltasCambios_Load(object sender, EventArgs e)
        {
            if (_esAlta)
            {
                Text = "Agregar almacen";
            }
            else
            {
                Text = "Modificar almacen";
                CargaAlmacen();

            }
        }

        private void CargaAlmacen()
        {

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.AlmacenSelect();
                Almacen al = db.Query<Almacen>(sql,new { AlmacenId = _almacenId }).FirstOrDefault();
                if (al != null)
                {
                    txtNombre.Text = al.Nombre;
                    chkPrincipal.Checked = al.Defa;
                }
            }
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text)) { 
                    MessageBox.Show("Teclee el nombre del almacen","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information); 
                    return;
            }


            using (FbConnection db = General.GetDB())
            {
                Almacen al = new Almacen();
                al.AlmacenId = _almacenId;
                al.Nombre = txtNombre.Text; 
                al.Defa = chkPrincipal.Checked;
                string sql = "";

                if (chkPrincipal.Checked)
                {
                    sql = Queries.AlmacenesQuitaDefault();
                    db.Execute(sql);
                    
                }
                sql = _esAlta ? Queries.AlmacenInsert() : Queries.AlmacenUpdate();


                db.Execute(sql, al);
                Close();

            }
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
