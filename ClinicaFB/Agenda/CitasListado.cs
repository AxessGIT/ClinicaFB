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
    public partial class CitasListado : Form
    {
        private BindingList<datosGrid> _citas;
        private FbConnection _db;
        private string _recursoTipo = "";
        private int _recursoID = 0;
        private DateTime _fecha;
        private string _hora;
        private int _pacienteID;
        public int CitaID { get; set; }
        public CitasListado(FbConnection db, string recursoTipo, int recursoID, DateTime fecha, string hora, int pacienteID)
        {
            _db = db;
            _recursoTipo = recursoTipo;
            _recursoID = recursoID;
            _fecha = fecha;
            _hora = hora;
            _pacienteID = pacienteID;
            InitializeComponent();
        }

        private void setGrid()
        {
            List<datosGrid> res = new List<datosGrid>();
            string sql = "";

            if (_pacienteID == 0)
            {
                sql = "Select Citas.Cita_Id,Citas.Fecha,Citas.Hora," +
                    " COALESCE(Trim(Pacientes.Nombres), '') || ' ' ||" +
                    " COALESCE(Trim(Pacientes.Apellido_Paterno), '')|| ' ' ||" +
                    " COALESCE(Trim(Pacientes.Apellido_Materno), '') As NombrePaciente," +
                    " COALESCE(Citas.Bloqueada, False),Descripciones.Descripcion as BloqueoMotivo " +
                    " From Citas " +
                    " Left Join Pacientes on Citas.Paciente_Id = Pacientes.Paciente_Id" +
                    " Left Join Descripciones On Citas.BloqueoMotivo_Id = Descripciones.Descripcion_Id" +
                    " Where " +
                    " Citas.SucursalId=@SucursalId and " +
                    " Citas.TipoRecurso=@TipoRecurso and " +
                    " Citas.Recurso_Id=@Recurso_Id and " +
                    " Citas.Fecha = @Fecha and " +
                    " Citas.Hora = @Hora";


                res = _db.Query<datosGrid>(sql, new 
                {
                    SucursalId = Properties.Settings.Default.SucursalId,
                    TipoRecurso = _recursoTipo,
                    Recurso_Id = _recursoID,
                    Fecha = _fecha,
                    Hora = _hora
                }).ToList();


            }
            else
            {

                sql = " Select Citas.Cita_id,Citas.Fecha,Citas.Hora,Citas.TipoRecurso, Citas.Recurso_id,'' as NombreRecurso From Citas " +
                    "Where Citas.Paciente_Id =@Paciente_id and Citas.Cita_Origen_id=Citas.Cita_Id and Citas.Cancelada<>True";



                res = _db.Query<datosGrid>(sql, new {Paciente_Id = _pacienteID}).ToList();

                foreach (var cita in res)
                {
                    cita.NombreRecurso = General.GetNombreRecurso(cita.TipoRecurso, cita.Recurso_Id);
                }

            }

            _citas = new BindingList<datosGrid>(res);

            grdCitas.AutoGenerateColumns = false;
            grdCitas.ReadOnly = true;
            grdCitas.AllowUserToResizeColumns = false;
            grdCitas.AllowUserToResizeRows = false;
            grdCitas.ColumnHeadersVisible = false;

            grdCitas.ColumnCount = 3;

            grdCitas.RowHeadersVisible = true;
            grdCitas.Columns[0].HeaderText = "Fecha";
            grdCitas.Columns[0].DataPropertyName = "Fecha";
            grdCitas.Columns[0].Width = 90;


            grdCitas.Columns[1].HeaderText = "Hora";
            grdCitas.Columns[1].DataPropertyName = "Hora";
            grdCitas.Columns[1].Width = 90;

            if (_pacienteID == 0)
            {
                grdCitas.Columns[2].HeaderText = "Paciente";
                grdCitas.Columns[2].DataPropertyName = "Leyenda";
                grdCitas.Columns[2].Width = 250;
            }
            else
            {
                grdCitas.Columns[2].HeaderText = "Recurso";
                grdCitas.Columns[2].DataPropertyName = "NombreRecurso";
                grdCitas.Columns[2].Width = 250;

            }
            grdCitas.DataSource = _citas;


        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            CitaID = 0;
            Close();
        }

        private void CitasListado_Load(object sender, EventArgs e)
        {
            Text = _pacienteID == 0 ? "Citas de la celda" : "Citas del paciente";
            setGrid();

        }

        private void cmdSeleccionar_Click(object sender, EventArgs e)
        {
            if (grdCitas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una cita", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int ren = grdCitas.CurrentRow.Index;

            if (_citas[ren].Bloqueda == true)
            {
                MessageBox.Show("Seleccione una cita no bloqueada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CitaID = _citas[ren].Cita_ID;
            Close();


        }
    }
    public class datosGrid
    {
        public int Cita_ID { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public string NombrePaciente { get; set; }
        public bool? Bloqueda { get; set; }

        public string TipoRecurso { get; set; }
        public int Recurso_Id { get; set; }
        public string NombreRecurso { get; set; }

        public string BloqueoMotivo { get; set; }
        public string Leyenda { get {
                return string.IsNullOrWhiteSpace(NombrePaciente) ? BloqueoMotivo : NombrePaciente;
            } }
    }
}
