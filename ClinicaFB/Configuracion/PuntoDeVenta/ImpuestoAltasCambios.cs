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

namespace ClinicaFB.Configuracion.PuntoDeVenta
{
    public partial class ImpuestoAltasCambios : Form
    {
        private bool _esAlta=false;
        private long _impuestoId;
        private Impuesto _imp;

        public ImpuestoAltasCambios(bool esAlta, long impuestoId)
        {
            InitializeComponent();
            _impuestoId = impuestoId;
            _esAlta = esAlta;
        }



        private void ImpuestoAltasCambios_Load(object sender, EventArgs e)
        {
            txtporcentaje.NumberFormatInfo = General.GetFormatoDecimal();
            if (_esAlta)
            {
                Text = "Agregar impuesto";
            }
            else
            {
                Text = "Modificar impuesto";
                CargaDatos();
                PropiedadesAControles();
                if (ChecaDatos.ImpuestoReservado(txtDescripcion.Text))
                {
                    txtDescripcion.Enabled = false;

                }
            }
        }

        private void PropiedadesAControles()
        {
            txtDescripcion.Text = _imp.Descripcion;
            txtporcentaje.Value = (double) _imp.Porcentaje;

        }


        private void ControlesAPropiedades()
        {
            _imp.Descripcion= txtDescripcion.Text;
            _imp.Porcentaje = (decimal) txtporcentaje.Value;

        }


        private void CargaDatos()
        {

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.ImpuestoSelect();
                _imp = db.Query<Impuesto>(sql, new { ImpuestoId = _impuestoId }).FirstOrDefault();

            }

        }

        private bool ValidaDatos()
        {
            bool esValido = true;

            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                MessageBox.Show("Indique la descripción","Confirme",MessageBoxButtons.OK,MessageBoxIcon.Information);
                esValido = false;

            }
            if (_esAlta && ChecaDatos.ImpuestoReservado(txtDescripcion.Text))
            {
                MessageBox.Show("Esta descripción está reservada para el sistema", "Confirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                esValido = false;

            }

            if (txtporcentaje.Value<0)
            {
                MessageBox.Show("Debe indicar el porcentaje de impuesto", "Confirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                esValido = false;

            }

            return esValido;    

        }
        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidaDatos())
                return;

            string sql = "";


            using (FbConnection db = General.GetDB())
            {
                if (_esAlta)
                {
                    _imp = new Impuesto();
                    sql = Queries.ImpuestoInsert();
                }
                else
                {
                    _imp.ImpuestoId = (int) _impuestoId;
                    sql = Queries.ImpuestoUpdate();
                }

                ControlesAPropiedades();

                db.Execute(sql,_imp);



            }
            Close();

        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
