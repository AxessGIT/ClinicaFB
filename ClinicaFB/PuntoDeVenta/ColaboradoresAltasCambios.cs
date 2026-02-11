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
    public partial class ColaboradoresAltasCambios : Form
    {
        private bool _esAlta = false;
        private long _colaboradorId = 0;

        public ColaboradoresAltasCambios(bool esAlta, long colaboradorId)
        {
            InitializeComponent();
            _esAlta = esAlta;
            _colaboradorId = colaboradorId;
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ColaboradoresAltasCambios_Load(object sender, EventArgs e)
        {
            if (_esAlta)
            {
                this.Text = "Agregar colaborador";
            }
            else
            {
                this.Text = "Modificar colaborador";
                CargaColaborador();
            }
        }

        private void CargaColaborador()
        {
            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.ColaboradorSelect;
                Colaborador col = db.Query<Colaborador>(sql, new { ColaboradorId = _colaboradorId }).FirstOrDefault();
                if (col != null)
                {
                    txtNombre.Text = col.Nombre;
                }
            }

        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Debe capturar el nombre del colaborador", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (FbConnection db = General.GetDB())
            {
                string sql = _esAlta ? Queries.ColaboradorInsert : Queries.ColaboradorUpdate;
                Colaborador col = new Colaborador
                {
                    ColaboradorId = _colaboradorId,
                    Nombre = txtNombre.Text.Trim()
                };
                db.Execute(sql, col);
            }
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
