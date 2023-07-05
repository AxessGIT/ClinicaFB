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
using ClinicaFB.Helpers;
using ClinicaFB.ModeloConfiguracion;
using System.Net.Http;
using ClinicaFB.Ingresos;

namespace ClinicaFB.Agenda
{
    public partial class MenuCita : Form
    {
        private FbConnection _db;
        private FbConnection _dbConfig;
        private DateTime _fecha;
        private string _hora;
        private long _pacienteID;
        private List<CeldaDatos> _celdasSeleccionadas;

        private bool _multiple = false;
        private bool _celdaVacia = true;
        private bool _hayCitas;

        public bool Mover { get; set; }
        public bool Copiar { get; set; }
        public int CitaID { get; set; }

        public MenuCita(FbConnection db, FbConnection dbConfig, DateTime fecha, string hora, int pacienteid, List<CeldaDatos> celdasSeleccionadas, bool multiple, bool celdaVacia, bool hayCitas)
        {
            _db = db;
            _dbConfig = dbConfig;
            _fecha = fecha;
            _hora = hora;
            _pacienteID = pacienteid;
            _celdasSeleccionadas = celdasSeleccionadas;
            _multiple = multiple;
            _celdaVacia = celdaVacia;
            _hayCitas = hayCitas;
            InitializeComponent();
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MenuCita_Load(object sender, EventArgs e)
        {
            lblFechaHora.Text = $"{_fecha.ToShortDateString()} {_hora}";

            if (_pacienteID == 0)
                cmdNueva.Enabled = false;

            if (_celdaVacia || !_hayCitas)
            {
                cmdVer.Enabled = false;
                cmdCopiar.Enabled = false;
                cmdMover.Enabled = false;
                cmdCancelar.Enabled = false;
                cmdConfirmado.Enabled = false;
                cmdAsistio.Enabled = false;
                cmdPagar.Enabled = false;
            }
            Mover = false;
            Copiar = false;

        }

        private void cmdBloquear_Click(object sender, EventArgs e)
        {
            CeldasBloquear cb = new CeldasBloquear(_db, _celdasSeleccionadas);
            cb.ShowDialog();
            Close();

        }

        private void cmdNueva_Click(object sender, EventArgs e)
        {
            CitasAltasCambios(true, 0);
            Close();
        }

        private void CitasAltasCambios(bool esAlta, int citaID)
        {


            CitaAC citaAltasCambios = new CitaAC(_db, _dbConfig, esAlta, _celdasSeleccionadas, citaID, (int)_pacienteID);
            citaAltasCambios.ShowDialog();

        }

        private void cmdVer_Click(object sender, EventArgs e)
        {
            int citaID = SeleccionarCita(false);
            if (citaID == 0)
                return;

            CitasAltasCambios(false, citaID);
            Close();

        }

        private int SeleccionarCita(bool copiarMover)
        {
            string sql = "";
            int citaID = 0;

            Cita cita = new Cita();

            string tipo = _celdasSeleccionadas[0].TipoRecurso;
            int recursoID = _celdasSeleccionadas[0].RecursoID;

            if (_multiple)
            {

                CitasListado cl = new CitasListado(_db, tipo, recursoID, _fecha, _hora, 0);

                cl.ShowDialog();
                citaID = cl.CitaID;

                if (citaID == 0)
                {
                    return 0;
                }
                sql = Queries.CitaSelect();
                cita = _db.QueryFirstOrDefault<Cita>(sql, new { Cita_Id = citaID });
            }
            else
            {

                sql = Queries.CitaSelectRecursoFecha();

                cita = _db.QueryFirstOrDefault<Cita>(sql, new
                {
                    SucursalId = Properties.Settings.Default.SucursalId,
                    TipoRecurso = tipo,
                    Recurso_Id = recursoID,
                    Fecha = _fecha,
                    Hora = _hora
                });

                if (cita.Bloqueada == true && copiarMover==false)
                {
                    MessageBox.Show("Celda bloqueada", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return 0;
                }

                citaID = (int)cita.Cita_Id;
            }

            _pacienteID = (int)cita.Paciente_Id;
            return citaID;
        }

        private void cmdDesbloquear_Click(object sender, EventArgs e)
        {
            string sql = "Delete From Citas Where SucursalId = @SucursalId and  TipoRecurso =@TipoRecurso and Recurso_Id = @Recurso_Id and Fecha =@Fecha and Hora =@Hora";
            foreach (var Celda in _celdasSeleccionadas)
            {
                _db.Execute(sql, new { 
                    SucursalId = Celda.SucursalId,
                    TipoRecurso = Celda.TipoRecurso,
                    Recurso_Id = Celda.RecursoID,
                    Fecha = Celda.Fecha,
                    Hora = Celda.Hora
                });

            }
            Close();


        }

        private void cmdCopiar_Click(object sender, EventArgs e)
        {
            if(CopiarMover(true))
                Close();

        }

        private void cmdMover_Click(object sender, EventArgs e)
        {
            if (CopiarMover(false))
                Close();

        }

        private bool CopiarMover (bool copiar)
        {
            CitaID = SeleccionarCita(true);
            if (CitaID == 0)
                return false;

            string sql = Queries.CitaSelect();
            Cita cita = _db.QueryFirstOrDefault<Cita>(sql, new { Cita_Id = CitaID });

            if (cita == null)
                return false;

            if (cita.Cita_Origen_Id != cita.Cita_Id)
            {
                MessageBox.Show("No es la cita inicial del grupo. Seleccione la primera cita", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }


            if (copiar)
                Copiar = true;
            else
                Mover = true;
            return true;

        }

        private void cmdConfirmado_Click(object sender, EventArgs e)
        {
            if (PonQuitaConfirmadoAsistio(false))
                Close();

        }

        private void cmdAsistio_Click(object sender, EventArgs e)
        {
            if (PonQuitaConfirmadoAsistio(true))
                Close();

        }

        private bool PonQuitaConfirmadoAsistio(bool cambiarAsistio)
        {
            CitaID = SeleccionarCita(false);
            if (CitaID == 0)
                return false;

            string sql = Queries.CitaSelect();
            Cita cita = _db.QueryFirstOrDefault<Cita>(sql, new { Cita_Id = CitaID });

            if (cita.Cita_Origen_Id != cita.Cita_Id)
            {
                MessageBox.Show("No es la cita inicial del grupo. Seleccione la primera cita", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            sql = Queries.CitasSelectOrigen();

            if (cambiarAsistio)
                sql = "Update Citas Set Asistio=iif(Asistio=True,False,True) Where Cita_Origen_Id=@Cita_Origen_Id";
            else
                sql = "Update Citas Set Confirmado=iif(Confirmado=True,False,True) Where Cita_Origen_Id=@Cita_Origen_Id";

            _db.Execute(sql, new { Cita_Origen_Id = cita.Cita_Id });

            return true;

        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            int citaID = SeleccionarCita(false);
            if (citaID == 0)
                return;

            string sql = Queries.CitaSelect();
            Cita cita = _db.QueryFirstOrDefault<Cita>(sql, new { Cita_Id = citaID });

            if (cita != null)
            {
                if (cita.Cita_Origen_Id != cita.Cita_Id)
                {
                    MessageBox.Show("No es la cita inicial del grupo. Seleccione la primera cita", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                CancelacionMotivos canMot = new CancelacionMotivos(_db);
                canMot.ShowDialog();

                if (canMot.MotivoID == 0)
                    return;

                sql = "Update Citas set UsuarioCancelacion=@UsuarioCancelacion,FechaHoraCancelacion = @FechaHoraCancelacion,CancelacionMotivo_Id =@CancelacionMotivo_Id, Cancelada = True" +
                    " Where Cita_origen_Id = @Cita_Origen_Id";


                _db.Execute(sql, new { 
                    UsuarioCancelacion = Properties.Settings.Default.Usuario_ID,
                    FechaHoraCancelacion =DateTime.Now,
                    CancelacionMotivo_id = canMot.MotivoID,
                    Cita_Origen_id = cita.Cita_Id
                });

            }
            Close();


        }


   
        private void cmdPagar_Click(object sender, EventArgs e)
        {
            CitaID = SeleccionarCita(false);

            if (CitaID == 0)
                return;

            string sql = Queries.CitaSelect();
            Cita cita = _db.QueryFirstOrDefault<Cita>(sql, new { Cita_Id = CitaID });

            if (cita == null)
                return;

            if (cita.Cita_Origen_Id != cita.Cita_Id)
            {
                MessageBox.Show("No es la cita inicial del grupo. Seleccione la primera cita", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ingCaptura ingCaptura = new ingCaptura("CLI", Convert.ToInt32(cita.Paciente_Id));
            ingCaptura.Show();

        }
    }
}
