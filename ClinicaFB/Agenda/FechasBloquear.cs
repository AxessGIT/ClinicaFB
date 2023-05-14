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
    public partial class FechasBloquear : Form
    {
        private FbConnection _db;
        private BindingList<DescripcionCat> _motivos;
        private BindingList<Recurso> _recursos;
        private List<string> _horasIniciales;
        private List<string> _horasFinales;

        public FechasBloquear(FbConnection db)
        {
            _db = db;
            InitializeComponent();
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LlenaListados()
        {

            General.LLenaLista(_db, "BLO", ref _motivos);
            _horasIniciales = General.GeneraHoras();
            _horasFinales = General.GeneraHoras();
        }

        public void EnlazaCombos()
        {
            cboHorasIniciales.DataSource = _horasIniciales;
            cboHorasFinales.DataSource = _horasFinales;

            EnlazaComboRecursos();


        }

        private void EnlazaComboRecursos()
        {
            cboRecursos.DisplayMember = "Nombre";
            cboRecursos.ValueMember = "Recurso_Id";
            cboRecursos.DataSource = _recursos;

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
            grdMotivos.Columns[0].DataPropertyName = "Descripcion";
            grdMotivos.Columns[0].Width = 172;


            grdMotivos.DataSource = _motivos;


        }

        private void FechasBloquear_Load(object sender, EventArgs e)
        {
            _recursos = new BindingList<Recurso>();
            LlenaListados();
            SetGrid();

            _recursos = Helper.cargaDoctores(_db);
            EnlazaCombos();
            cboTipos.SelectedIndex = 0;

        }

        private void LlenaRecursos(string tipo)
        {
            List<Recurso> res = new List<Recurso>();


            switch (tipo)
            {
                case "DOC":
                    _recursos = Helper.cargaDoctores(_db);
                    break;
                case "EQU":
                    _recursos = Helper.cargaEquipos(_db);
                    break;
                case "CUA":
                    _recursos = Helper.cargaCuartos(_db);
                    break;

            }


        }

        private void cboTipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipo = "";
            tipo = cboTipos.Text.Substring(0, 3).ToUpper();
            LlenaRecursos(tipo);
            EnlazaComboRecursos();

        }

        private void cboRecursos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregarMotivoBloqueo_Click(object sender, EventArgs e)
        {
            DescripcionesAltasCambios desAC = new DescripcionesAltasCambios("BLO", _db, true, 0);

            desAC.ShowDialog();

            if (desAC.Descripcion_Id == 0)
                return;

            _motivos.Add(new DescripcionCat { Descripcion_Id = desAC.Descripcion_Id, Tipo = "PRO", Descripcion = desAC.Descripcion });

        }

        private void cmdBloquear_Click(object sender, EventArgs e)
        {
            DateTime fechaInicial = dtpFechaInicial.Value.Date;
            DateTime fechaFinal = dtpFechaFinal.Value.Date;

            int indiceHoraInicial = cboHorasIniciales.SelectedIndex;
            int indiceHoraFinal = cboHorasFinales.SelectedIndex;

            if (fechaFinal < fechaInicial)
            {
                MessageBox.Show("La fecha final no puede ser anterior a la inicial", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (indiceHoraFinal < indiceHoraInicial)
            {
                MessageBox.Show("La hora final no puede ser anterior a la inicial", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (grdMotivos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione el motivo de bloqueo", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Desea realizar el bloqueo?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int motivoID = 0;

            motivoID = (int)_motivos[grdMotivos.CurrentRow.Index].Descripcion_Id;

            int indice = cboRecursos.SelectedIndex;
            string tipo = _recursos[indice].Tipo;
            int recursoID =  (int)_recursos[indice].Recurso_Id;

            DateTime fechaActual = fechaInicial.Date;


            string sqlBloqueada = Queries.CitaBloqueada();
            string sqlInsert = Queries.CitaInsert();
            string sqlActualiazaOrigenId = Queries.CitaUpdateOrigenId();


            while (fechaActual <= fechaFinal)
            {
                for (int i = indiceHoraInicial; i <= indiceHoraFinal; i++)
                {

                    string horaCita = _horasIniciales[i].Trim();


                    var celdaBloqueada = _db.QueryFirstOrDefault(sqlBloqueada, new
                    {
                        SucursalId = Properties.Settings.Default.SucursalId,
                        TipoRecurso = tipo,
                        Recurso_Id = recursoID,
                        Fecha = fechaActual,
                        Hora = horaCita

                    });

                    if (celdaBloqueada != null)
                        continue;

                    Cita nuevaCitaBloqueada = new Cita
                    {
                        SucursalId = Properties.Settings.Default.SucursalId,
                        TipoRecurso =tipo,
                        Recurso_Id = recursoID,
                        Fecha = fechaActual,
                        Hora = horaCita,
                        Paciente_Id = 0,
                        UsuarioAlta = Properties.Settings.Default.Usuario_ID,
                        FechaHoraAlta = DateTime.Now,
                        Bloqueada = true,
                        BloqueoMotivo_Id = motivoID

                    };


                    int nuevaCita_id = _db.QuerySingle<int>(sqlInsert, nuevaCitaBloqueada);

                    _db.Execute(sqlActualiazaOrigenId, new { Cita_Origen_id = nuevaCita_id, Cita_id = nuevaCita_id});


                }

                fechaActual = fechaActual.AddDays(1);
            }
            MessageBox.Show("Se bloquearon las fechas especificadas", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();

        }
    }
}
