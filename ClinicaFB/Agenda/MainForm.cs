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
using ClinicaFB.ModeloConfiguracion;
using ClinicaFB.Expedientes;

namespace ClinicaFB.Agenda
{
    public partial class MainForm : Form
    {

        private ExternalData _extData;
        private List<InfoColumna> _infoColumnas;
        private List<InfoHorario> _horarios;


        private int _horaInicial = 8;
        private int _horaFinal = 20;
        private int _cuantosRenglones = 52;
        private int _cuantasColumnas = 20;

        private int _anchoColumnas = 70;
        private int _anchoColumnasHeader = 40;
        private int _altoRenglones = 20;
        private int _altoRenglonesHeaders = 45;

        private Color _colorCitaLetra = Color.Black;
        private Color _colorCitaFondo = Color.White;

        private Color _colorMultipleLetra = Color.Black;
        private Color _colorMultipleFondo = Color.White;


        private Color _colorBloqueoLetra = Color.Black;
        private Color _colorBloqueoFondo = Color.White;


        private Color _colorConfirmadoLetra = Color.Black;
        private Color _colorConfirmadoFondo = Color.White;

        private Color _colorAsistioLetra = Color.Black;
        private Color _colorAsistioFondo = Color.White;


        private int _pacienteID;

        private bool _copiando = false;
        private bool _moviendo = false;
        private int _citaIDCopiarMover;


        private FbConnection _db;
        private FbConnection _dbConfig;

        public MainForm(FbConnection db,FbConnection dbConfig)
        {
            _db = db;
            _dbConfig = dbConfig;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            PonHorarios();
            CargaColores();
            CargaInformacionColumnas();
            PonDatosEmpresa();
            ActualizaAgenda();
            muestraNombreUsuario();



        }


        private void ActualizaAgenda()
        {

            _extData = new ExternalData(_cuantosRenglones, _cuantasColumnas, calCalendario.SelectionStart.Date, _horarios, _infoColumnas);
            grdAgenda.ResetVolatileData();
            grdAgenda.Refresh();

        }

        private void PonHorarios()
        {
            _horarios = General.GeneraHorarios(_horaInicial, _horaFinal);
        }


        private void CargaColores()
        {
            Parametro par = _db.QueryFirstOrDefault<Parametro>(Queries.ParametroSelect());

            if (par == null) return;

            if (par.ColorCitaLetra != null) _colorCitaLetra = ColorTranslator.FromHtml(par.ColorCitaLetra);
            if (par.ColorCitaFondo != null) _colorCitaFondo = ColorTranslator.FromHtml(par.ColorCitaFondo);
            if (par.ColorMultipleLetra != null) _colorMultipleLetra = ColorTranslator.FromHtml(par.ColorMultipleLetra);
            if (par.ColorMultipleFondo != null) _colorMultipleFondo = ColorTranslator.FromHtml(par.ColorMultipleFondo);

            if (par.ColorBloqueoLetra != null) _colorBloqueoLetra = ColorTranslator.FromHtml(par.ColorBloqueoLetra);
            if (par.ColorBloqueoFondo != null) _colorBloqueoFondo = ColorTranslator.FromHtml(par.ColorBloqueoFondo);

            if (par.ColorConfirmadoLetra != null) _colorConfirmadoLetra = ColorTranslator.FromHtml(par.ColorConfirmadoLetra);
            if (par.ColorConfirmadoFondo != null) _colorConfirmadoFondo = ColorTranslator.FromHtml(par.ColorConfirmadoFondo);

            if (par.ColorAsistioLetra != null) _colorAsistioLetra = ColorTranslator.FromHtml(par.ColorAsistioLetra);
            if (par.ColorAsistioFondo != null) _colorAsistioFondo = ColorTranslator.FromHtml(par.ColorAsistioFondo);

        }


        private void PonDatosEmpresa()
        {

            using (FbConnection db = General.GetConexionConfig())
            {
                long empresaId = Properties.Settings.Default.Empresa_ID;
                Empresa emp = db.QueryFirstOrDefault<Empresa>(Queries.EmpresaSelect(), new { Empresa_Id = empresaId });

                if (emp == null)
                    return;

                if (emp.Logotipo != null)
                {
                    picLogotipo.Image = General.ByteArrayToImagen(emp.Logotipo);
                }

            }

        }


        private void CargaInformacionColumnas()
        {



            int usuario_Id = (int) ClinicaFB.Properties.Settings.Default.Usuario_ID;
            string sql = Queries.RecursosColumnasSelect();
            _infoColumnas = new List<InfoColumna>();

            var res = _db.Query<ColRecurso>(sql,new {Usuario_Id = usuario_Id }).ToList();

            _cuantasColumnas = res.Count();
            _cuantasColumnas = _cuantasColumnas < 20 ? 20 : _cuantasColumnas;

            string nombreRecurso = "";
            foreach (var col in res)
            {
                nombreRecurso = GetNombreRecurso(col);

                _infoColumnas.Add
                    (new InfoColumna()
                    {
                        ColRecurso_Id = (int) col.ColRecurso_Id,
                        Columna = (int)col.Numero,
                        TipoRecurso = col.Tipo,
                        RecursoID = (long)col.Recurso_Id,
                        NombreRecurso = nombreRecurso
                    }

                    );

            }

        }

        private string GetNombreRecurso(ColRecurso columna)
        {
            string nombreRecurso = "";
            nombreRecurso = General.GetNombreRecurso(columna.Tipo, columna.Recurso_Id);
            return nombreRecurso;

        }

        #region ManejaInput
        private void QuitaCopiandoMoviendo()
        {
            _copiando = false;
            _moviendo = false;
            lblCopiando.Visible = false;
            lblMoviendo.Visible = false;
        }

        private void grdAgenda_CellClick(object sender, Syncfusion.Windows.Forms.Grid.GridCellClickEventArgs e)
        {
            if (e.RowIndex == 0 && e.ColIndex > 0)
                ConfiguraColumna(e.ColIndex);
            else
            {
                if (e.MouseEventArgs.Button == MouseButtons.Right)
                {
                    QuitaCopiandoMoviendo();
                    return;
                }

                if (_copiando)
                {
                    CitaCopiarMover(e.RowIndex, e.ColIndex, false);
                    ActualizaAgenda();
                    return;
                }

                if (_moviendo)
                {
                    CitaCopiarMover(e.RowIndex, e.ColIndex, true);
                    ActualizaAgenda();
                    QuitaCopiandoMoviendo();
                    return;

                }
                ManejaCitas(e.RowIndex, e.RowIndex, e.ColIndex, e.ColIndex);


            }
        }
        private void CitaCopiarMover(int renglon, int columnaDestino, bool mover)
        {
            InfoColumna infoColumna = Helper.GetInfoColumna(_infoColumnas, columnaDestino);

            if (infoColumna == null)
            {
                MessageBox.Show("La columna no tiene un recurso asignado",
                    "Verifique",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string sql = Queries.CitaSelect();
            Cita citaOrigen = _db.QueryFirstOrDefault<Cita>(sql, new { Cita_Id = _citaIDCopiarMover });

            if (citaOrigen == null)
                return;

            sql = Queries.CitasSelectOrigen();
            var citasACopiar = _db.Query<Cita>(sql, new { Cita_Origen_Id = citaOrigen.Cita_Id }).ToList();

            string horaInicial = _horarios[renglon - 1].Hora.Trim();
            int hora = Convert.ToInt32(horaInicial.Substring(0, 2));
            int minutos = Convert.ToInt32(horaInicial.Substring(3, 2));


            int i = 0;
            int idOrigen = 0;

            foreach (var citaOriginal in citasACopiar)
            {
                Cita citaCopiada = new Cita();

                string horaCopia = $"{hora:00}:{minutos:00}";
                citaCopiada.Fecha = calCalendario.SelectionStart.Date;
                citaCopiada.Hora = horaCopia;
                citaCopiada.SucursalId = Properties.Settings.Default.SucursalId;
                citaCopiada.TipoRecurso = infoColumna.TipoRecurso;
                citaCopiada.Recurso_Id = infoColumna.RecursoID;
                citaCopiada.Paciente_Id = citaOriginal.Paciente_Id;
                citaCopiada.Observaciones = citaOriginal.Observaciones;
                citaCopiada.UsuarioAlta = ClinicaFB.Properties.Settings.Default.Usuario_ID;
                citaCopiada.FechaHoraAlta = DateTime.Now;
                citaCopiada.Bloqueada = citaOriginal.Bloqueada;
                citaCopiada.BloqueoMotivo_Id = citaOriginal.BloqueoMotivo_Id;
                

                i++;

                int nuevaCitaId = 0;

                if (i > 1)
                {
                    citaCopiada.Cita_Origen_Id = idOrigen;
                }


                sql = Queries.CitaInsert();
                nuevaCitaId = _db.QuerySingle<int>(sql,  citaCopiada );

                if (i == 1)
                {
                    sql = Queries.CitaUpdateOrigenId();
                    _db.Execute(sql, new { Cita_origen_Id = nuevaCitaId, Cita_id = nuevaCitaId });
                    idOrigen = nuevaCitaId;
                }



                sql = Queries.CitaProInsSelectxCita();
                var procsIns = _db.Query<CitaProins>(sql, new { Cita_id = citaOriginal.Cita_Id }).ToList();


                foreach (var proins in procsIns)
                {
                    CitaProins citaProIns = new CitaProins()
                    {
                        Cita_Id = nuevaCitaId,
                        Tipo = proins.Tipo,
                        ProcIns_Id = proins.ProcIns_Id
                    };

                    sql = Queries.CitaProInsInsert();
                    _db.Execute(sql,  citaProIns );
                }

                if (mover)
                {
                    sql = Queries.CitaProInsDeletexCita();
                    _db.Execute(sql, new { Cita_Id = citaOriginal.Cita_Id });
                }


                minutos += 15;
                if (minutos > 45)
                {
                    hora++;
                    minutos = 0;
                }

                if (hora > _horaFinal)
                {
                    break;
                }



            }

            if (mover)
            {
                sql = "Delete From Citas Where Cita_Origen_Id = @Cita_Id";
                _db.Execute(sql, new { Cita_id = citaOrigen.Cita_Id });

            }


        }

        private void ConfiguraColumna(int columna)
        {
            AsignaRecurso ar = new AsignaRecurso(columna, _infoColumnas, _db);

            DialogResult Salida;
            Salida = ar.ShowDialog();

            if (Salida == DialogResult.Cancel)
                return;

            _infoColumnas = ar._infoColumnas;

            InfoColumna infoColumna = _infoColumnas.Find(x => x.Columna == columna);

            ar.Dispose();
            ActualizaAgenda();

        }
        private void ManejaCitas(int top, int bottom, int left, int right)
        {

            int renglon = 0, columna = 0;
            bool hayCitas = false;

            List<CeldaDatos> celdasSeleccionadas = new List<CeldaDatos>();

            string horaInicial = string.Empty;
            string hora = string.Empty;
            string horaFinal = string.Empty;



            horaInicial = _horarios[top - 1].Hora;
            horaFinal = _horarios[bottom - 1].Hora;


            for (renglon = top; renglon <= bottom; renglon++)
            {
                hora = _horarios[renglon - 1].Hora;
                for (columna = left; columna <= right; columna++)
                {

                    InfoColumna infoColumna = Helper.GetInfoColumna(_infoColumnas, columna);

                    if (infoColumna == null)
                    {
                        MessageBox.Show("Alguna de las columnas seleccionadas no tiene un recurso asignado",
                            "Verifique",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }


                    if (_extData[renglon - 1, columna - 1] != null &&
                        string.IsNullOrEmpty(_extData[renglon - 1, columna - 1].Leyenda) == false)
                    {
                        hayCitas = true;

                    }

                    CeldaDatos celdaDatos = new CeldaDatos();


                    celdaDatos.SucursalId=Properties.Settings.Default.SucursalId;
                    celdaDatos.Fecha = calCalendario.SelectionStart.Date;
                    celdaDatos.Hora = hora;
                    celdaDatos.PacienteID = _pacienteID;
                    celdaDatos.TipoRecurso = infoColumna.TipoRecurso;
                    celdaDatos.RecursoID = (int)infoColumna.RecursoID;

                    celdasSeleccionadas.Add(celdaDatos);

                }

            }


            string estatusCelda = "";
            bool multiple = false;
            bool celdaVacia = false;


            if (_extData[top - 1, left - 1] != null)
            {
                estatusCelda = _extData[top - 1, left - 1].Status;
                multiple = celdasSeleccionadas.Count == 1 && estatusCelda == "MUL";
            }
            else
                celdaVacia = true;


            MenuCita mc = new MenuCita(_db,_dbConfig, calCalendario.SelectionStart.Date, hora, _pacienteID, celdasSeleccionadas, multiple, celdaVacia, hayCitas);
            mc.ShowDialog();

            if (mc.Copiar)
            {
                lblCopiando.Visible = true;
                _citaIDCopiarMover = mc.CitaID;
                _copiando = true;
            }


            if (mc.Mover)
            {
                lblMoviendo.Visible = true;
                _citaIDCopiarMover = mc.CitaID;
                _moviendo = true;
            }

            ActualizaAgenda();



        }

        #endregion

        #region ConfiguraGrid
        private void grdAgenda_QueryColCount(object sender, Syncfusion.Windows.Forms.Grid.GridRowColCountEventArgs e)
        {
            e.Count = _cuantasColumnas;
            e.Handled = true;

        }


        private void grdAgenda_QueryCellInfo(object sender, Syncfusion.Windows.Forms.Grid.GridQueryCellInfoEventArgs e)
        {
            
            if (e.ColIndex == 0 && e.RowIndex > 0)
            {
                e.Style.CellValue = _horarios[e.RowIndex - 1].Hora;
            }

            if (e.RowIndex == 0 && e.ColIndex > 0)
            {

                int indiceInfoColumna = 0;
                var infoColumna = _infoColumnas.Find(x => x.Columna == e.ColIndex);
                indiceInfoColumna = infoColumna == null ? -1 : _infoColumnas.IndexOf(infoColumna);

                if (indiceInfoColumna == -1)
                    e.Style.CellValue = "Libre";
                else
                    e.Style.CellValue = _infoColumnas[indiceInfoColumna].NombreRecurso;
            }

            if (e.ColIndex > 0 && e.RowIndex > 0)
            {
                e.Style.Font = new Syncfusion.Windows.Forms.Grid.GridFontInfo() { Facename = "Tahoma", Size = 8, Bold = false };
                e.Style.CellType = "Static";

                //By using indexers, pass value to a cell from a given data source.

                string leyenda = "";
                string estatus = "";

                if (this._extData[e.RowIndex - 1, e.ColIndex - 1] != null)
                {
                    leyenda = this._extData[e.RowIndex - 1, e.ColIndex - 1].Leyenda;
                    estatus = this._extData[e.RowIndex - 1, e.ColIndex - 1].Status;
                }

                e.Style.CellValue = leyenda;


                if (string.IsNullOrEmpty(leyenda) == false)
                {
                    switch (estatus)
                    {

                        case "UNO":
                            e.Style.TextColor = _colorCitaLetra;
                            e.Style.BackColor = _colorCitaFondo;
                            break;
                        case "MUL":
                            e.Style.TextColor = _colorMultipleLetra;
                            e.Style.BackColor = _colorMultipleFondo;
                            break;
                        case "BLO":
                            e.Style.TextColor = _colorBloqueoLetra;
                            e.Style.BackColor = _colorBloqueoFondo;
                            break;
                        case "CON":
                            e.Style.TextColor = _colorConfirmadoLetra;
                            e.Style.BackColor = _colorConfirmadoFondo;
                            break;
                        case "ASI":
                            e.Style.TextColor = _colorAsistioLetra;
                            e.Style.BackColor = _colorAsistioFondo;
                            break;



                    }
                }

                e.Style.ReadOnly = true;
                e.Handled = true;
            }
        }


        private void grdAgenda_QueryColWidth(object sender, Syncfusion.Windows.Forms.Grid.GridRowColSizeEventArgs e)
        {
            if (e.Index == 0)
                e.Size = _anchoColumnasHeader;
            else
                e.Size = _anchoColumnas;
            e.Handled = true;

        }

        private void grdAgenda_QueryRowCount(object sender, Syncfusion.Windows.Forms.Grid.GridRowColCountEventArgs e)
        {
            //Determines number of rows.
            e.Count = _cuantosRenglones;
            e.Handled = true;

        }

        private void grdAgenda_QueryRowHeight(object sender, Syncfusion.Windows.Forms.Grid.GridRowColSizeEventArgs e)
        {
            e.Size = e.Index == 0 ? _altoRenglonesHeaders : _altoRenglones;
            e.Handled = true;

        }

        #endregion


        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();

        }

        #region Paciente
        private void cmdPacienteBuscar_Click(object sender, EventArgs e)
        {
            PacienteBuscar pacBuscar = new PacienteBuscar();
            pacBuscar.ShowDialog();

            if (pacBuscar.Paciente_Id!=0)
            {
                _pacienteID = (int) pacBuscar.Paciente_Id;
                MuestraDatosPaciente();
            }
        }


        private void MuestraDatosPaciente()
        {

            string sql = Queries.PacienteSelect();

            using (FbConnection db = General.GetDB())
            {
                Paciente pac = db.QueryFirstOrDefault<Paciente>(sql, new { Paciente_Id = _pacienteID });
                txtPaciente.Text = pac.NombreCompleto;

                sql = Queries.PacienteVisitas();
                int visitas = db.ExecuteScalar<int>(sql, new { PacienteId = _pacienteID });
                lblCitasRegistradas.Text = $"Citas registradas: {visitas}";

            }
        }

        private void PacienteAltasCambios(bool esAlta)
        {
            PacienteDatosAgenda pacientesAltasCambios = new PacienteDatosAgenda(esAlta, esAlta ? 0 : _pacienteID);
            pacientesAltasCambios.ShowDialog();

            if (pacientesAltasCambios.PacienteID != 0)
            {
                _pacienteID = pacientesAltasCambios.PacienteID;
            }
            if (_pacienteID!=0)
                MuestraDatosPaciente();
        }


        private void cmdPacienteModificar_Click(object sender, EventArgs e)
        {
            if (_pacienteID==0)
            {
                MessageBox.Show("No está seleccionado ningùn paciente", "Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            PacienteAltasCambios(false);
            /*PacientesAltasCambios pacientesAltasCambios = new PacientesAltasCambios(_db, false, _pacienteID);
            pacientesAltasCambios.ShowDialog();
            MuestraDatosPaciente();*/

        }

        #endregion

        private void calCalendario_DateChanged(object sender, DateRangeEventArgs e)
        {
            ActualizaAgenda();
        }

        private void grdAgenda_SelectionChanged(object sender, Syncfusion.Windows.Forms.Grid.GridSelectionChangedEventArgs e)
        {
            if (e.Reason == Syncfusion.Windows.Forms.Grid.GridSelectionReason.MouseUp && grdAgenda.Model.SelectedRanges.Count > 0)
            {
                if (grdAgenda.Model.SelectedRanges[0].Top == 0 && grdAgenda.Model.SelectedRanges[0].Left > 0)
                {
                    return;

                }

                ManejaCitas(
                    grdAgenda.Model.SelectedRanges[0].Top,
                    grdAgenda.Model.SelectedRanges[0].Bottom,
                    grdAgenda.Model.SelectedRanges[0].Left,
                    grdAgenda.Model.SelectedRanges[0].Right
                    );


            }

        }

        private void cmdBloquear_Click(object sender, EventArgs e)
        {
            FechasBloquear fechasBloquear = new FechasBloquear(_db);
            fechasBloquear.ShowDialog();
            ActualizaAgenda();
        }

        private void cmdDesbloquear_Click(object sender, EventArgs e)
        {
            FechasDesbloquear fechasDesbloquear = new FechasDesbloquear(_db);
            fechasDesbloquear.ShowDialog();
            ActualizaAgenda();
        }

        private void cmdImprimirDia_Click(object sender, EventArgs e)
        {
            DiaImprimir diaImprimir = new DiaImprimir(_db, calCalendario.SelectionStart.Date);
            diaImprimir.ShowDialog();
        }

        private void cmdImprimirCitas_Click(object sender, EventArgs e)
        {
            CitasImprimir citasImprimir = new CitasImprimir(_db, calCalendario.SelectionStart.Date);
            citasImprimir.ShowDialog();

        }

        private void grdAgenda_CellCursor(object sender, Syncfusion.Windows.Forms.Grid.GridCellCursorEventArgs e)
        {
            if (_copiando)
            {
                e.Cursor = Cursors.Hand;
                e.Cancel = true;
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 27:
                    QuitaCopiandoMoviendo();
                    break;
            }
        }

        private void muestraNombreUsuario()
        {
            if (Properties.Settings.Default.Usuario_ID==0)
            {
                lblUsuario.Text = "Usuario: SA";
            }
            else
            {
                string sql = Queries.UsuarioSelect();
                Usuario usuario =  _dbConfig.Query<Usuario>(sql, new { Usuario_Id = Properties.Settings.Default.Usuario_ID }).FirstOrDefault();
                string nombreSucursal = "";

                using (FbConnection db = General.GetDB())
                {
                    sql = Queries.SucursalSelect();
                    Sucursal suc = db.Query<Sucursal>(sql,new {SucursalId = usuario.SucursalId}).FirstOrDefault();
                    if (suc != null)
                    {
                        nombreSucursal = suc.Nombre;
                    }

                }

                if (usuario!=null)
                    lblUsuario.Text = $"Usuario: {usuario.Nombre.Trim()} Sucursal {usuario.SucursalId} {nombreSucursal}";

            }
        }

        private void ssStatus_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void cmdPacienteAgregar_Click(object sender, EventArgs e)
        {
            PacienteAltasCambios(true);
        }

        private void cmdVerCitas_Click(object sender, EventArgs e)
        {
            if (_pacienteID == 0)
            {
                MessageBox.Show("No hay ningún paciente seleccionado", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CitasListado cl = new CitasListado(_db, "", 0, DateTime.Now, "", _pacienteID);
            cl.ShowDialog();

        }

        private void cmdActualizar_Click(object sender, EventArgs e)
        {
            ActualizaAgenda();
        }

        private void cmdDepurar_Click(object sender, EventArgs e)
        {

        }
    }
}
