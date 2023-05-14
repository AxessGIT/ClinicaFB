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
using ClinicaFB.Helpers;
using ClinicaFB.Modelo;

namespace ClinicaFB.Agenda
{
    public partial class AsignaRecurso : Form
    {
        private FbConnection _db;
        private BindingList<Recurso> _recursos;
        private int _columna = 0;
        public List<InfoColumna> _infoColumnas;

        public AsignaRecurso(int columna, List<InfoColumna> infoColumnas, FbConnection db)
        {
            _columna = columna;
            _db = db;
            _infoColumnas = infoColumnas;

            InitializeComponent();
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AsignaRecurso_Load(object sender, EventArgs e)
        {
            cboTipos.SelectedIndex = 0;

            Text = "Configurar columna " + _columna.ToString();

            var infoColumna = _infoColumnas.Find(x => x.Columna == _columna);

            if (infoColumna != null)
            {
                switch (infoColumna.TipoRecurso)
                {
                    case "DOC":
                        cboTipos.SelectedIndex = 0;
                        break;
                    case "EQU":
                        cboTipos.SelectedIndex = 1;
                        break;
                    case "CUA":
                        cboTipos.SelectedIndex = 2;
                        break;
                }
                cmdQuitar.Visible = true;
            }

            SetGrid();


        }

        private void SetGrid()
        {
            grdRecursos.DataSource = null;



            grdRecursos.AllowUserToAddRows = false;
            grdRecursos.AllowUserToDeleteRows = false;


            grdRecursos.AutoGenerateColumns = false;
            grdRecursos.ReadOnly = true;
            grdRecursos.AllowUserToResizeColumns = false;
            grdRecursos.AllowUserToResizeRows = false;

            grdRecursos.ColumnCount = 1;

            grdRecursos.RowHeadersVisible = true;


            grdRecursos.ColumnHeadersDefaultCellStyle.Font = new Font(grdRecursos.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            grdRecursos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grdRecursos.Columns[0].HeaderText = "Recurso";

            grdRecursos.Columns[0].DataPropertyName = "Nombre";
            grdRecursos.Columns[0].Width = 300;



            switch (cboTipos.SelectedIndex)
            {
                case 0:
                    _recursos = Helper.cargaDoctores(_db);
                    break;
                case 1:
                    _recursos = Helper.cargaEquipos(_db);
                    break;
                case 2:
                    _recursos = Helper.cargaCuartos(_db);
                    break;

            }



            grdRecursos.DataSource = _recursos;

        }



        private void cboTipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetGrid();
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            if (grdRecursos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un registro para asignar a la columna", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int rowIndex = grdRecursos.CurrentRow.Index;

            bool esNueva = false;



            var infoColumna = _infoColumnas.Find(x => x.Columna == _columna);
            ColRecurso Columna = new ColRecurso();


            long Usuario_Id = Properties.Settings.Default.Usuario_ID;

            if (infoColumna == null)
            {
                Columna.Usuario_Id = Usuario_Id;
                Columna.Numero = (short)_columna;
                esNueva = true;
            }
            else
            {
                Columna.ColRecurso_Id = infoColumna.ColRecurso_Id;
            }

            Columna.Tipo = _recursos[rowIndex].Tipo;
            Columna.Recurso_Id = _recursos[rowIndex].Recurso_Id;

            string sql = "";

            if (esNueva)
            {
                sql = Queries.RecursosColumnaInsert();
                _infoColumnas.Add(new InfoColumna { Columna = (int)Columna.Numero, TipoRecurso = Columna.Tipo, RecursoID = (int)Columna.Recurso_Id, NombreRecurso = _recursos[rowIndex].Nombre });


            }
            else
            {
                int indiceInfoColumna = _infoColumnas.IndexOf(infoColumna);
                _infoColumnas[indiceInfoColumna].RecursoID = (long)Columna.Recurso_Id;
                _infoColumnas[indiceInfoColumna].TipoRecurso = Columna.Tipo;
                _infoColumnas[indiceInfoColumna].NombreRecurso = _recursos[rowIndex].Nombre;

                sql = Queries.RecursosColumnaUpdate();
            }

            _db.Execute(sql, Columna);
            Close();

        }

        private void cmdQuitar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea borrar la asignación de la columna?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;


            int usuario_Id = (int)Properties.Settings.Default.Usuario_ID;

            string sql = "Delete From ColsRecursos Where Usuario_Id = @Usuario_Id And Numero = @Numero";
            _db.Execute(sql, new { Usuario_Id = usuario_Id, Numero = _columna });
            InfoColumna infoColumna = _infoColumnas.Find(x => x.Columna == _columna);

            if (infoColumna != null)
            {
                int indiceInfoColumna = _infoColumnas.IndexOf(infoColumna);
                _infoColumnas.RemoveAt(indiceInfoColumna);
            }
            Close();


        }
    }
}
