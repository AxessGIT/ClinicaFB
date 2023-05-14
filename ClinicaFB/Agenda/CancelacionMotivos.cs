using ClinicaFB.Configuracion;
using ClinicaFB.Helpers;
using ClinicaFB.Modelo;
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

namespace ClinicaFB.Agenda
{
    public partial class CancelacionMotivos : Form
    {
        private FbConnection _db;
        private BindingList<DescripcionCat> _motivos;
        public int MotivoID { get; set; }

        public CancelacionMotivos(FbConnection db)
        {
            _db = db;
            InitializeComponent();
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            MotivoID = 0;
            Close();
        }

        private void CancelacionMotivos_Load(object sender, EventArgs e)
        {
            General.LLenaLista(_db, "MOC", ref _motivos);
            General.EnlazaCombo(ref cboMotivos, _motivos);
            if (_motivos.Count > 0)
            {
                cboMotivos.SelectedIndex = 0;
            }

        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            if (cboMotivos.SelectedIndex == -1)
            {
                MessageBox.Show("Indique el motivo de la cancelación", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MotivoID = (int)_motivos[cboMotivos.SelectedIndex].Descripcion_Id;
            Close();

        }

        private void btnAgregarMotivo_Click(object sender, EventArgs e)
        {
            DescripcionesAltasCambios desAC = new DescripcionesAltasCambios("MOC", _db, true, 0);

            desAC.ShowDialog();

            if (desAC.Descripcion_Id == 0)
                return;

            _motivos.Add(new DescripcionCat { Descripcion_Id = desAC.Descripcion_Id, Tipo = "MOC", Descripcion = desAC.Descripcion });


        }
    }
}
