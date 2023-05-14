using ClinicaFB.Configuracion;
using ClinicaFB.Helpers;
using ClinicaFB.Modelo;
using ClinicaFB.ModeloConfiguracion;
using ClinicaFB.ModeloWEB;
using Dapper;
using FirebirdSql.Data.FirebirdClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFB.Agenda
{
    public partial class CitaAC : Form
    {

        private bool _esAlta;
        private FbConnection _db;
        private FbConnection _dbConfig;

        private BindingList<DescripcionCat> _procedimientosDis;
        private BindingList<DescripcionCat> _instruccionesDis;

        private BindingList<DescripcionCat> _procedimientosSel;
        private BindingList<DescripcionCat> _instruccionesSel;

        private List<CeldaDatos> _celdasSeleccionadas;
        private int _citaID;
        private Cita _cita;
        private int _pacienteID;
        private Paciente _paciente;

        public CitaAC(FbConnection db, FbConnection dbConfig, bool esAlta, List<CeldaDatos> celdasSeleccionadas, int citaID, int pacienteID)
        {

            _db = db;
            _dbConfig = dbConfig;
            _esAlta = esAlta;
            _celdasSeleccionadas = celdasSeleccionadas;
            _citaID = citaID;
            _pacienteID = pacienteID;

            InitializeComponent();
        }

        private void cmdCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CitaAC_Load(object sender, EventArgs e)
        {
            _procedimientosSel = new BindingList<DescripcionCat>();
            _instruccionesSel = new BindingList<DescripcionCat>();

            _procedimientosDis = CargaProcedimientosInstruccionesDisponibles("PRO");
            _instruccionesDis = CargaProcedimientosInstruccionesDisponibles("INS");

            SetGrid(ref grdProcedimientosDisponibles, ref _procedimientosDis);
            SetGrid(ref grdProcedimientosSeleccionados, ref _procedimientosSel);


            SetGrid(ref grdInstruccionesDisponibles, ref _instruccionesDis);
            SetGrid(ref grdInstruccionesSeleccionadas, ref _instruccionesSel);


            string sql = Queries.PacienteSelect();
            _paciente = _db.QueryFirstOrDefault<Paciente>(sql, new { Paciente_Id = _pacienteID });

            if (_paciente!=null ) { 
                lblNombrePaciente.Text = _paciente.NombreCompleto.Trim()+" "+_paciente.Telefonos;
            }

            lblFechaHora.Text = $"{_celdasSeleccionadas[0].Fecha.ToShortDateString()} {_celdasSeleccionadas[0].Hora}";



            if (_esAlta)
            {
                Text = "Agregar cita";
                cmdBorrar.Enabled = false;
                sql = Queries.EmpresaSelect();
               // _datosEmpresa = _db.QueryFirstOrDefault<DatosEmpresa>(sql);
            }
            else
            {
                Text = "Modificar cita";
                sql = Queries.CitaSelect();
                _cita = _db.QueryFirstOrDefault<Cita>(sql, new { Cita_Id = _citaID });

                sql = Queries.UsuarioSelect();
                Usuario usr = _dbConfig.QueryFirstOrDefault<Usuario>(sql, new { Usuario_Id = _cita.UsuarioAlta });
                if (usr!=null) { 
                    lblUsuarioRegistro.Visible = true;
                    lblUsuarioRegistro.Text += " "+usr.Nombre;
                }

                txtObservaciones.Text = _cita.Observaciones;
                lblConfirmado.Visible = _cita.Confirmado == true ? true : false;
                lblAsistio.Visible = _cita.Asistio == true ? true : false;


                
                CargaSeleccionados();


            }

        }

        private void CargaSeleccionados()
        {
            _procedimientosSel = new BindingList<DescripcionCat>();
            _instruccionesSel = new BindingList<DescripcionCat>();


            string sql = Queries.CitaProInsSelectxCita();

            var cpi = _db.Query<CitaProins>(sql, new { Cita_Id = _citaID }).ToList();


            foreach (var proins in cpi)
            {

                DescripcionCat elemento = new DescripcionCat();

                elemento.Tipo = proins.Tipo;
                elemento.Descripcion_Id = proins.ProcIns_Id;

                if (proins.Tipo=="PRO")
                {
                    sql = Queries.ProcedimientoSelect();
                    var proc = _db.QueryFirstOrDefault<Procedimiento>(sql,new {Procedimiento_Id=proins.ProcIns_Id});
                    elemento.Descripcion = proc.Descripcion;

                }
                else
                {
                    sql = Queries.DescripcionSelect();
                    var des = _db.QueryFirstOrDefault<DescripcionCat>(sql, new { Descripcion_Id = proins.ProcIns_Id });
                    elemento.Descripcion = des.Descripcion;

                }




                if (elemento.Tipo == "PRO")
                {

                    _procedimientosSel.Add(elemento);

                    var ABorrarPro = (_procedimientosDis.Where(x => x.Descripcion_Id == elemento.Descripcion_Id)).FirstOrDefault();
                    if (ABorrarPro != null)
                        _procedimientosDis.RemoveAt(_procedimientosDis.IndexOf(ABorrarPro));
                }
                else
                {
                    _instruccionesSel.Add(elemento);

                    var ABorrarIns = (_instruccionesDis.Where(x => x.Descripcion_Id == elemento.Descripcion_Id)).FirstOrDefault();
                    if (ABorrarIns != null)
                        _instruccionesDis.RemoveAt(_instruccionesDis.IndexOf(ABorrarIns));

                }


            }

            grdProcedimientosSeleccionados.DataSource = _procedimientosSel;
            grdInstruccionesSeleccionadas.DataSource = _instruccionesSel;



        }

        private BindingList<DescripcionCat> CargaProcedimientosInstruccionesDisponibles(string tipo)
        {
            BindingList<DescripcionCat> lista = new BindingList<DescripcionCat>();

            string sql = "";
            if (tipo=="PRO")
            {
                sql = Queries.ProcedimientosSelect();
                var procs = _db.Query<Procedimiento>(sql).ToList();

                foreach (var p in procs)
                {
                    lista.Add(new DescripcionCat
                    {
                        Descripcion_Id = p.Procedimiento_Id,
                        Tipo = "PRO",
                        Descripcion = p.Descripcion

                    }); 

                }
                
            }
            else{
                sql = Queries.DescripcionesSelect();
                var des = _db.Query<DescripcionCat>(sql, new { Tipo = "INS" }).ToList();
                lista = new BindingList<DescripcionCat>(des);
            }
            return lista;
        }

        private void SetGrid(ref DataGridView grid, ref BindingList<DescripcionCat> dataSource)
        {
            grid.AutoGenerateColumns = false;
            grid.ReadOnly = true;
            grid.AllowUserToResizeColumns = false;
            grid.AllowUserToResizeRows = false;
            grid.ColumnHeadersVisible = false;

            grid.ColumnCount = 1;

            grid.RowHeadersVisible = false;
            grid.Columns[0].HeaderText = "Descripción";
            grid.Columns[0].DataPropertyName = "descripcion";
            grid.Columns[0].Width = 172;


            grid.DataSource = dataSource;


        }

        private void Pasa(int indice, ref BindingList<DescripcionCat> origen, ref BindingList<DescripcionCat> destino)
        {
            DescripcionCat elemento = origen[indice];
            destino.Add(elemento);
            origen.RemoveAt(indice);


        }

        private void cmdPasaProcedimiento_Click(object sender, EventArgs e)
        {
            if (grdProcedimientosDisponibles.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un procedimiento disponible", "Confirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int Renglon = grdProcedimientosDisponibles.CurrentRow.Index;
            Pasa(Renglon, ref _procedimientosDis, ref _procedimientosSel);

        }

        private void cmdDevuelveProcedimiento_Click(object sender, EventArgs e)
        {
            if (grdProcedimientosSeleccionados.CurrentRow == null)
            {
                MessageBox.Show("Indique un procedimiento seleccionado", "Confirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int Renglon = grdProcedimientosSeleccionados.CurrentRow.Index;
            Pasa(Renglon, ref _procedimientosSel, ref _procedimientosDis);

        }

        private void cmdPasaInstruccion_Click(object sender, EventArgs e)
        {
            if (grdInstruccionesDisponibles.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una instruccion disponible", "Confirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int Renglon = grdInstruccionesDisponibles.CurrentRow.Index;
            Pasa(Renglon, ref _instruccionesDis, ref _instruccionesSel);

        }

        private void cmdDevuelveInstruccion_Click(object sender, EventArgs e)
        {
            if (grdInstruccionesSeleccionadas.CurrentRow == null)
            {
                MessageBox.Show("Indique una instrucción seleccionada", "Confirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int Renglon = grdInstruccionesSeleccionadas.CurrentRow.Index;
            Pasa(Renglon, ref _instruccionesSel, ref _instruccionesDis);


        }

        private void btnAgregarProcedimiento_Click(object sender, EventArgs e)
        {
            ProcedimientosAltasCambios proAC = new ProcedimientosAltasCambios(_db, true, 0);

            proAC.ShowDialog();

            if (proAC.Procedimiento_Id== 0)
                return;

            _procedimientosDis.Add(new DescripcionCat {Tipo="PRO", Descripcion_Id= proAC.Procedimiento_Id, Descripcion = proAC.Descripcion });

        }

        private void cmdAgregarInstruccion_Click(object sender, EventArgs e)
        {
            DescripcionesAltasCambios desAC = new DescripcionesAltasCambios("INS", _db, true, 0);

            desAC.ShowDialog();

            if (desAC.Descripcion_Id == 0)
                return;

            _instruccionesDis.Add(new DescripcionCat { Descripcion_Id = desAC.Descripcion_Id, Tipo = "INS", Descripcion = desAC.Descripcion });

        }

        private  async void cmdGuardar_Click(object sender, EventArgs e)
        {
            int primeraCitaID = 0;
            int i = 0;
            DateTime fecha = DateTime.Now;

            string hora = "";
            string tipoRecurso = "";
            int recursoID = 0;


            string sqlInsert = Queries.CitaInsert();
            string sqlUpdate = Queries.CitaUpdate();
            string sqlUpdateCitaOrigen = "Update Citas Set Cita_Origen_Id = @Cita_origen_Id Where Cita_id = @Cita_Id";
            if (_esAlta)
            {

                CitaWEB cw = new CitaWEB();

                foreach (var celda in _celdasSeleccionadas)
                {
                    Cita cita = new Cita();
                    cita.Fecha = celda.Fecha;

                    cita.Hora = celda.Hora;

                    cita.SucursalId = Properties.Settings.Default.SucursalId;

                    cita.TipoRecurso = celda.TipoRecurso;
                    cita.Recurso_Id = celda.RecursoID;
                    cita.Paciente_Id = _pacienteID;
                    cita.UsuarioAlta = Properties.Settings.Default.Usuario_ID;
                    cita.FechaHoraAlta = DateTime.Now;
                    cita.Observaciones = txtObservaciones.Text.Trim();

                    i++;

                    if (i > 1)
                    {
                        cita.Cita_Origen_Id = primeraCitaID;
                    }


                    int nuevaCitaId = await _db.QuerySingleAsync<int>(sqlInsert, cita);
                    
                    if (i == 1)
                    {
                        fecha = (DateTime)cita.Fecha;
                        hora = cita.Hora;
                        tipoRecurso = cita.TipoRecurso;
                        recursoID = (int)cita.Recurso_Id;
                        primeraCitaID = nuevaCitaId;
                        await _db.ExecuteAsync(sqlUpdateCitaOrigen, new { Cita_Origen_id = primeraCitaID, Cita_Id = nuevaCitaId });
                        cw = General.BuildCitaWEB(_db,cita);
                    }

                    GuardaSeleccionados(nuevaCitaId);


                }

               GuardaCitasWEB(primeraCitaID);

                // MandaCorreo(fecha, hora, tipoRecurso, recursoID);
            }
            else
            {

                _cita.Observaciones = txtObservaciones.Text.Trim();
                _cita.UsuarioModificacion = Properties.Settings.Default.Usuario_ID;
                _cita.FechaHoraModificacion = DateTime.Now;

                await _db.ExecuteAsync(sqlUpdate, _cita);
               GuardaSeleccionados(_cita.Cita_Id);
            }
            Close();

        }


        private async void GuardaCitasWEB(int citaInicialId)
        {

            Empresa empresa = new Empresa();
            string sql = Queries.EmpresaSelect();
            int empresaID = (int) Properties.Settings.Default.Empresa_ID;

//            empresa = await Task.Run(() => _dbConfig.QueryFirstOrDefault<Empresa>(sql, new { Empresa_Id = Properties.Settings.Default.Empresa_ID }));

            empresa = _dbConfig.QueryFirstOrDefault<Empresa>(sql, new { Empresa_Id = empresaID });

            if (empresa==null || empresa.CopiarWEB!=true || string.IsNullOrEmpty(empresa.WebServiceURL) || string.IsNullOrEmpty(empresa.BddWEB) || string.IsNullOrEmpty(empresa.CarpetaWEB))
                return;


            List<Recurso> recursos = new List<Recurso>();
            foreach (var celda in _celdasSeleccionadas)
            {
                Recurso r = new Recurso();
                r.Tipo = celda.TipoRecurso;
                r.Recurso_Id = celda.RecursoID;
                var esta = recursos.Where(x => x.Tipo == celda.TipoRecurso && x.Recurso_Id == celda.RecursoID).FirstOrDefault();
                if (esta==null)
                {
                    r.Nombre = General.GetNombreRecurso(r.Tipo, r.Recurso_Id);
                    recursos.Add(r);
                }
            }





            string horaInicial = _celdasSeleccionadas[0].Hora;
            string horaFinal = _celdasSeleccionadas[_celdasSeleccionadas.Count - 1].Hora;


            foreach (var recurso in recursos)
            {
                CitaWEB cw = new CitaWEB();
                cw.Fecha = _celdasSeleccionadas[0].Fecha;
                cw.TipoRecurso = recurso.Tipo;
                cw.RecursoId = recurso.Recurso_Id;
                cw.RecursoNombre = recurso.Nombre;
                cw.PacienteId = _paciente.Paciente_Id;
                cw.PacienteNombre = _paciente.NombreCompleto;
                cw.CitaInicialId = citaInicialId;

                try {
                    var json = JsonConvert.SerializeObject(cw);
                    var url = empresa.WebServiceURL.Trim() + $"ClinicaFb/AgregaCita?HoraInicial={horaInicial}&HoraFinal={horaFinal}&Datos={json}";
                    var client = new HttpClient();
                    var response = await client.GetAsync(url);
                }
                catch  {
                }

            }


            //            CitaWEB cw = await Task.Run(()=> General.BuildCitaWEB(_db, c));
            //var data = new StringContent(json, Encoding.UTF8, "application/json");

            //        var url = empresa.WebServiceURL.Trim()+"ClinicaFb/AgregaCita?Datos="+json;

            //      var response = await client.GetAsync(url);
            //    string result = response.Content.ReadAsStringAsync().Result;
        }
        private async void GuardaSeleccionados(long citaid)
        {

                string sql = "";
                if (_esAlta == false)
                {
                    sql = Queries.CitaProInsDeletexCita();
                    await _db.ExecuteAsync(sql, new { Cita_id = citaid });
                }

                CitaProins nuevo = new CitaProins();
                sql = Queries.CitaProInsInsert();

                foreach (var proc in _procedimientosSel)
                {
                    nuevo = new CitaProins{ Tipo = "PRO", Cita_Id = citaid,ProcIns_Id = proc.Descripcion_Id };
                    await _db.ExecuteAsync(sql, nuevo);


                }

                foreach (var ins in _instruccionesSel)

                {
                    nuevo = new CitaProins { Tipo = "INS", Cita_Id = citaid, ProcIns_Id = ins.Descripcion_Id };
                    await _db.ExecuteAsync(sql, nuevo);


                }



        }

        private void cmdBorrar_Click(object sender, EventArgs e)
        {
            DialogResult SiNo;
            SiNo = MessageBox.Show("¿Desea eliminar definitivamente la cita?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (SiNo == DialogResult.No)
                return;

            string sql = Queries.CitaDelete();
            _db.Execute(sql, new { Cita_Id = _citaID });

            sql = Queries.CitaProInsDeletexCita();
            _db.Execute(sql, new { Cita_Id = _citaID });

            Close();


        }
    }
}
