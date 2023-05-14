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

namespace ClinicaFB.Agenda
{
    public partial class FechasDesbloquear : Form
    {
        private FbConnection _db;
        private BindingList<Recurso> _recursos;
        private List<string> _horasIniciales;
        private List<string> _horasFinales;

        public FechasDesbloquear(FbConnection db)
        {
            _db = db;
            InitializeComponent();
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FechasDesbloquear_Load(object sender, EventArgs e)
        {
            _recursos = new BindingList<Recurso>();
            LlenaListados();

            LlenaRecursos("DOC");
            EnlazaCombos();
            cboTipos.SelectedIndex = 0;

        }

        private void LlenaListados()
        {

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
            cboRecursos.ValueMember = "RecursoID";
            cboRecursos.DataSource = _recursos;

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

        private void cmdDesBloquear_Click(object sender, EventArgs e)
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


            if (MessageBox.Show("¿Desea realizar el Desbloqueo?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;


            int indice = cboRecursos.SelectedIndex;
            string tipo = _recursos[indice].Tipo;
            int recursoID = (int) _recursos[indice].Recurso_Id;

            string horaInicial = _horasIniciales[indiceHoraInicial].Trim();
            string horaFinal = _horasFinales[indiceHoraFinal].Trim();

            DateTime fechaActual = fechaInicial.Date;


            string sql = "Delete From Citas Where SucursalId =@SucursalId and  Fecha Between @FechaInicial and @FechaFinal And Hora Between @HoraInicial And @HoraFinal And Bloqueada = True";

            _db.Execute(sql, new
            {
                SucursalId = Properties.Settings.Default.SucursalId,
                FechaInicial = fechaInicial,
                FechaFinal = fechaFinal,
                HoraInicial = horaInicial,
                HoraFinal = horaFinal
            });
            MessageBox.Show("Se desbloquearon las fechas especificadas", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();


        }
    }
}
