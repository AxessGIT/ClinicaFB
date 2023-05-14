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
using Dapper;

namespace ClinicaFB.Configuracion
{
    public partial class DescripcionesListado : Form
    {
        private string _tipo;
        private FbConnection _db;
        private BindingList<DescripcionCat> _descripciones;

        public DescripcionesListado(FbConnection db, string tipo)
        {
            _db = db;
            _tipo = tipo;
            InitializeComponent();
        }

        private void DescripcionesListado_Load(object sender, EventArgs e)
        {
            switch (_tipo)
            {
                case "INS":
                    Text = "Catálogo de instrucciones";
                    break;
                case "BLO":
                    Text = "Motivos de bloqueo";
                    break;
                case "MOC":
                    Text = "Motivos de cancelación";
                    break;
                case "PAD":
                    Text = "Padecimientos";
                    break;
                case "MAR":
                    Text = "Marcas";
                    break;
                case "LIN":
                    Text = "Líneas";
                    break;

            }
            General.LLenaLista(_db, _tipo, ref _descripciones);
            SetGrid();
        }

        private void SetGrid()
        {
            grdDescripciones.DataSource = null;



            grdDescripciones.AllowUserToAddRows = false;
            grdDescripciones.AllowUserToDeleteRows = false;


            grdDescripciones.AutoGenerateColumns = false;
            grdDescripciones.ReadOnly = true;
            grdDescripciones.AllowUserToResizeColumns = false;
            grdDescripciones.AllowUserToResizeRows = false;

            grdDescripciones.ColumnCount = 1;

            grdDescripciones.RowHeadersVisible = true;


            grdDescripciones.ColumnHeadersDefaultCellStyle.Font = new Font(grdDescripciones.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            grdDescripciones.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grdDescripciones.Columns[0].HeaderText = "Descripcion";

            grdDescripciones.Columns[0].DataPropertyName = "Descripcion";
            grdDescripciones.Columns[0].Width = 200;
            grdDescripciones.DataSource = _descripciones;

        }

        private void AltasCambios(bool esAlta)
        {

            int id = 0;
            if (esAlta == false)
            {
                id = (int)_descripciones[grdDescripciones.CurrentRow.Index].Descripcion_Id;
            }
            DescripcionesAltasCambios desAC = new DescripcionesAltasCambios(_tipo,_db,esAlta,id);
            desAC.ShowDialog();

            cargaDatos();



        }

        private void cargaDatos()
        {
            General.LLenaLista(_db, _tipo, ref _descripciones);
            SetGrid();

        }



        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            AltasCambios(true);
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {
            if(grdDescripciones.CurrentRow==null) {
                MessageBox.Show("indique el registro a modificar","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            AltasCambios(false);

        }

        private void grdDescripciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            AltasCambios(false);
        }

        private void cmdEliminar_Click(object sender, EventArgs e)
        {
            if (grdDescripciones.CurrentRow == null)
            {
                MessageBox.Show("indique el registro a borrar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            if (_tipo == "BLO")
            {
                DialogResult SiNo;
                SiNo = MessageBox.Show(
                    "Si borra un motivo de bloqueo se borrarán TODOS los bloqueos con ese motivo. ¿Desea continuar?","Confirme",
                    MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                if (SiNo == DialogResult.No)
                    return;

                using (FbConnection db = General.GetDB())
                {
                    
                    int id = (int)_descripciones[grdDescripciones.CurrentRow.Index].Descripcion_Id;
                    string sql = "Delete From Citas Where BloqueoMotivo_Id=@BloqueoId";

                    db.Execute(sql, new {BloqueoId=id });
                    sql = "Delete From Descripciones Where Descripcion_Id = @DescripcionId";

                    db.Execute(sql, new { Descripcionid = id });
                    
                }
                MessageBox.Show("Se borró el motivo de bloqueo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cargaDatos();
            }
        }
    }
}
