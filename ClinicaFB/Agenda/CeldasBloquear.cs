using ClinicaFB.Configuracion;
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

namespace ClinicaFB.Agenda
{
    public partial class CeldasBloquear : Form
    {
        private FbConnection _db;
        private List<CeldaDatos> _celdasSeleccionadas;
        private BindingList<DescripcionCat> _motivos;

        public CeldasBloquear(FbConnection db, List<CeldaDatos> celdas)
        {
            _db = db;
            _celdasSeleccionadas = celdas;
            InitializeComponent();
        }

        private void cmdBloquear_Click(object sender, EventArgs e)
        {
            if (grdMotivos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un motivo del bloqueo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int motivoID = (int)_motivos[grdMotivos.CurrentRow.Index].Descripcion_Id;

            int i = 0;
            int citaInicialID = 0;

            string sqlBloqueada = Queries.CitaBloqueada();
            string sqlInsert = Queries.CitaInsert();
            string sqlActualiazaOrigenId = Queries.CitaUpdateOrigenId();

            foreach (var celda in _celdasSeleccionadas)
            {
                var celdaBloqueada = _db.QueryFirstOrDefault(sqlBloqueada, new
                {
                    SucursalId = celda.SucursalId,
                    TipoRecurso = celda.RecursoID,
                    Recurso_Id = celda.RecursoID,
                    Fecha = celda.Fecha,
                    Hora = celda.Hora

                });

                if (celdaBloqueada != null)
                    continue;

                string horaInicial = _celdasSeleccionadas[0].Hora;
                string horaFinal = _celdasSeleccionadas[_celdasSeleccionadas.Count() - 1].Hora;

                i++;
                Cita nuevaCitaBloqueada = new Cita
                {
                    SucursalId = celda.SucursalId,
                    TipoRecurso = celda.TipoRecurso,
                    Recurso_Id = celda.RecursoID,
                    Fecha = celda.Fecha,
                    Hora = celda.Hora,
                    Paciente_Id = 0,
                    UsuarioAlta = Properties.Settings.Default.Usuario_ID,
                    FechaHoraAlta = DateTime.Now,
                    Bloqueada = true,
                    BloqueoMotivo_Id = motivoID

                };

                if (i > 1)
                {
                    nuevaCitaBloqueada.Cita_Origen_Id = citaInicialID;
                }

                int nuevaCitaId = _db.QueryFirst<int>(sqlInsert, nuevaCitaBloqueada);

                if (i == 1)
                {
                    citaInicialID = nuevaCitaId;
                    _db.Execute(sqlActualiazaOrigenId, new { Cita_Origen_id = citaInicialID, Cita_id = nuevaCitaId });
                }



            }
            Close();

        }

        private void btnAgregarMotivoBloqueo_Click(object sender, EventArgs e)
        {
            DescripcionesAltasCambios desAC = new DescripcionesAltasCambios("BLO", _db, true, 0);

            desAC.ShowDialog();

            if (desAC.Descripcion_Id == 0)
                return;

            _motivos.Add(new DescripcionCat { Descripcion_Id = desAC.Descripcion_Id, Tipo = "PRO", Descripcion = desAC.Descripcion });

        }

        private void CeldasBloquear_Load(object sender, EventArgs e)
        {
            General.LLenaLista(_db, "BLO", ref _motivos);
            SetGrid();

        }


        private void SetGrid()
        {
            grdMotivos.DataSource = null;

            grdMotivos.AutoGenerateColumns = false;
            grdMotivos.ReadOnly = true;
            grdMotivos.AllowUserToResizeColumns = false;
            grdMotivos.AllowUserToResizeRows = false;
            grdMotivos.ColumnHeadersVisible = false;

            grdMotivos.ColumnCount = 1;

            grdMotivos.RowHeadersVisible = false;
            grdMotivos.Columns[0].HeaderText = "Descripción";
            grdMotivos.Columns[0].DataPropertyName = "descripcion";
            grdMotivos.Columns[0].Width = 172;


            grdMotivos.DataSource = _motivos;


        }

    }
}
