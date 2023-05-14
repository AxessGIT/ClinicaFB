using ClinicaFB.ModeloConfiguracion;
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

namespace ClinicaFB.Configuracion.Usuarios
{
    public partial class UsuariosListado : Form
    {
        private FbConnection _dbConfig = null;
        private BindingList<Usuario> _usuarios = null;

        public UsuariosListado(FbConnection dbConfig)
        {
            _dbConfig = dbConfig;
            InitializeComponent();
        }


        private void AltasCambios(bool esAlta)
        {

            int id = 0;
            if (esAlta == false)
            {
                id = (int)_usuarios[grdUsuarios.CurrentRow.Index].Usuario_Id;
            }
            UsuariosAltasCambios usrAC = new UsuariosAltasCambios(_dbConfig, esAlta, id);
            usrAC.ShowDialog();

            CargaUsuarios();
            SetGrid();


        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UsuariosListado_Load(object sender, EventArgs e)
        {
            CargaUsuarios();
            SetGrid();
        }

        private void CargaUsuarios()
        {

            string sql = Helpers.Queries.UsuariosSelect();

            var res = _dbConfig.Query<Usuario>(sql).ToList();
            _usuarios = new BindingList<Usuario>(res);
        }

        private void SetGrid()
        {
            grdUsuarios.DataSource = null;



            grdUsuarios.AllowUserToAddRows = false;
            grdUsuarios.AllowUserToDeleteRows = false;


            grdUsuarios.AutoGenerateColumns = false;
            grdUsuarios.ReadOnly = true;
            grdUsuarios.AllowUserToResizeColumns = false;
            grdUsuarios.AllowUserToResizeRows = false;

            grdUsuarios.ColumnCount = 1;

            grdUsuarios.RowHeadersVisible = true;


            grdUsuarios.ColumnHeadersDefaultCellStyle.Font = new Font(grdUsuarios.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            grdUsuarios.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grdUsuarios.Columns[0].HeaderText = "Usuario";

            grdUsuarios.Columns[0].DataPropertyName = "Nombre";
            grdUsuarios.Columns[0].Width = 200;


            grdUsuarios.DataSource = _usuarios;

        }

        private void grdUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            AltasCambios(false);

        }

        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            AltasCambios(true);
        }

        private void cmdModificar_Click(object sender, EventArgs e)
        {

            if (grdUsuarios.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un usuario a modificar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }

            AltasCambios(false);

        }
    }
}
