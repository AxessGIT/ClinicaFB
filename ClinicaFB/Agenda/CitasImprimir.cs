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
using Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using ClinicaFB.Modelo;

namespace ClinicaFB.Agenda
{
    public partial class CitasImprimir : Form
    {
        private BindingList<Recurso> _recursos;
        private FbConnection _db;
        private DateTime _fecha;

        public CitasImprimir(FbConnection db, DateTime fecha)
        {
            _db = db;
            _fecha = fecha;
            InitializeComponent();
        }



        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CitasImprimir_Load(object sender, EventArgs e)
        {
            _recursos = new BindingList<Recurso>();
            LlenaRecursos("DOC");
            EnlazaComboRecursos();
            cboTipos.SelectedIndex = 0;
            dtpFecha.Value = _fecha;

        }

        private void LlenaRecursos(string tipo)
        {


            switch (tipo)
            {
                case "DOC":
                    _recursos= Helper.cargaDoctores(_db);

                    break;
                case "EQU":
                    _recursos = Helper.cargaEquipos(_db);
                    break;
                case "CUA":
                    _recursos = Helper.cargaCuartos(_db);
                    break;

            }


        }

        private void EnlazaComboRecursos()
        {
            cboRecursos.DisplayMember = "Nombre";
            cboRecursos.ValueMember = "Recurso_Id";
            cboRecursos.DataSource = _recursos;

        }

        private void cboTipos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipo = "";
            tipo = cboTipos.Text.Substring(0, 3).ToUpper();
            LlenaRecursos(tipo);
            EnlazaComboRecursos();

        }

        private void cmdImprimir_Click(object sender, EventArgs e)
        {
            DateTime fecha = dtpFecha.Value.Date;
            string tipo = cboTipos.Text.Substring(0, 3).ToUpper();
            int recursoID =(int) _recursos[cboRecursos.SelectedIndex].Recurso_Id;
            bool todos = chkImprimirTodos.Checked;
            string nombreRecurso = cboRecursos.Text.Trim();

            string sql = "";

            sql = "Select Citas.Cita_Id,Citas.TipoRecurso as Tipo,Citas.Recurso_Id,Citas.Fecha,Citas.Hora," +
                "Citas.Paciente_id as PacienteId,Pacientes.Nombres,Pacientes.Apellido_Paterno,Pacientes.Apellido_Materno," +
                "Pacientes.Telefonos,Pacientes.Sexo,Citas.Bloqueada,Descripciones.Descripcion As Motivo From Citas ";
            sql += " Left Join Pacientes On Citas.Paciente_id = Pacientes.Paciente_Id";
            sql += " Left Join Descripciones On BloqueoMotivo_Id = Descripciones.Descripcion_Id";

            if (todos)
            {
                sql += " Where SucursalId = @SucursalId And  Citas.Fecha = @Fecha And Citas.Cancelada <> True";
            }
            else
            {
                sql += " Where SucursalId = @SucursalId And   Citas.Fecha = @Fecha And Citas.TipoRecurso = @Tipo And Citas.Recurso_Id = @Recurso_id  And citas.Cancelada <> True";

            }
            sql += " Order by Hora";

            List<DatosReporte> res = _db.Query<DatosReporte>(sql, new
            {
                SucursalId = Properties.Settings.Default.SucursalId,
                Fecha = fecha,
                Tipo = tipo,
                Recurso_Id = recursoID
            }).ToList();

            Microsoft.Office.Interop.Excel.Application oExcel;
            oExcel = new Microsoft.Office.Interop.Excel.Application();

            var Libros = oExcel.Workbooks;
            Libros.Add();

            var VentanaActiva = oExcel.ActiveWindow;

            VentanaActiva.DisplayGridlines = false;

            int renTitulos = 5;
            int ren = 6;

            var HojaActiva = oExcel.ActiveSheet;

            HojaActiva.Cells[1, 1].Font.Bold = true;
            HojaActiva.Cells[1, 1].Font.Size = 12;
            HojaActiva.Cells[1, 1].Font.Name = "Tahoma";



            if (todos)
            {
                HojaActiva.Cells[1, 1] = "REPORTE DE CITAS DEL DIA " + fecha.ToLongDateString().ToUpper();
                HojaActiva.Cells[renTitulos, 3] = "TELEFONOS";
                HojaActiva.Cells[renTitulos, 4] = "RECURSO";
            }
            else
            {
                HojaActiva.Cells[1, 1] = "CITAS PARA " + nombreRecurso;
                HojaActiva.Cells[2, 1] = fecha.ToLongDateString().ToUpper();
            }

            string rangoTitulos = $"A{renTitulos.ToString().Trim()}:F{renTitulos.ToString().Trim()}";

            var Rango = oExcel.Range[rangoTitulos];
            Rango.Font.Size = 10;
            Rango.Font.Bold = true;
            Rango.Font.Name = "Tahoma";
            HojaActiva.Cells[renTitulos, 1] = "HORA";
            HojaActiva.Cells[renTitulos, 2] = "PACIENTE";

            if (todos == false)
            {
                HojaActiva.Cells[renTitulos, 3] = "TELEFONOS";
                HojaActiva.Cells[renTitulos, 4] = "VISITAS";
                HojaActiva.Cells[renTitulos, 5] = "SEXO";
                HojaActiva.Cells[renTitulos, 6] = "PROCEDIMIENTOS";

            }

            foreach (var cita in res)
            {
                string NombreRecurso = "";

                if (todos)
                {
                    switch (cita.Tipo)
                    {
                        case "DOC":
                            sql = Queries.DoctoresSelect();
                            Doctor doc = _db.QueryFirstOrDefault<Doctor>(sql, new { Doctor_Id = cita.Recurso_Id });
                            NombreRecurso = doc.NombreCompleto;
                            break;
                        case "EQU":
                            sql = Queries.EquipoSelect();
                            Equipo equ = _db.QueryFirstOrDefault<Equipo>(sql, new { Equipo_Id = cita.Recurso_Id });
                            NombreRecurso = equ == null ? "" : equ.Nombre;
                            break;
                        case "CUA":
                            sql = Queries.CuartosSelect();
                            Cuarto cua = _db.QueryFirstOrDefault<Cuarto>(sql, new { Cuarto_Id = cita.Recurso_Id });
                            NombreRecurso = cua == null ? "" : cua.Nombre;
                            break;

                    }
                }

                cita.Motivo = string.IsNullOrEmpty(cita.Motivo) ? "" : cita.Motivo;

                string pacienteNombre = string.IsNullOrEmpty(cita.Nombres) ? "": cita.Nombres.Trim()+" ";
                pacienteNombre += string.IsNullOrEmpty(cita.Apellido_Paterno) ? "" : cita.Apellido_Paterno.Trim() + " ";
                pacienteNombre += string.IsNullOrEmpty(cita.Apellido_Materno) ? "" : cita.Apellido_Materno.Trim() + " ";

                HojaActiva.Cells[ren, 1].Style.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                HojaActiva.Cells[ren, 1] = cita.Hora;

                HojaActiva.Cells[ren, 2].Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                HojaActiva.Cells[ren, 2] = cita.Bloqueada ? cita.Motivo : pacienteNombre;

                HojaActiva.Cells[ren, 3].Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                HojaActiva.Cells[ren, 3] = cita.Telefonos;

                if (todos)
                {

                    HojaActiva.Cells[ren, 4].Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                    HojaActiva.Cells[ren, 4] = NombreRecurso;

                }
                else
                {

                    sql = "Select Procedimientos.Procedimiento_Id,Procedimientos.Descripcion From CitasProIns" +
                        " inner join Procedimientos on CitasProIns.ProcIns_Id=Procedimientos.Procedimiento_Id" +
                        " Where CitasProIns.Cita_id = @Cita_Id";

                    List<Procedimiento> pros = _db.Query<Procedimiento>(sql, new { Cita_Id = cita.Cita_Id }).ToList();
                    string cadenaProcedimientos = "";

                    foreach (var pro in pros)
                    {
                        cadenaProcedimientos += pro.Descripcion + ", ";

                    }

                    if (string.IsNullOrEmpty(cadenaProcedimientos) == false)
                    {
                        cadenaProcedimientos = cadenaProcedimientos.Substring(0, cadenaProcedimientos.Length - 2);
                    }

                    int visitas = 0;

                    using (FbConnection db = General.GetDB())
                    {
                        string qry = Queries.PacienteVisitas();
                        visitas = db.ExecuteScalar<int>(qry, new { PacienteId = cita.PacienteId });
                    }

                    HojaActiva.Cells[ren, 4].Style.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    HojaActiva.Cells[ren, 4] = cita.Bloqueada?"": visitas.ToString();



                    HojaActiva.Cells[ren, 5].Style.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    HojaActiva.Cells[ren, 5] = cita.Sexo;

                    HojaActiva.Cells[ren, 6].Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                    HojaActiva.Cells[ren, 6] = cadenaProcedimientos;
                }

                ren++;
            }

            HojaActiva.Range["A1"].EntireColumn.ColumnWidth = 6;
            HojaActiva.Range["B1"].EntireColumn.ColumnWidth = 25;
            HojaActiva.Range["C1"].EntireColumn.ColumnWidth = 20;

            float margen = 5f;
            HojaActiva.PageSetup.TopMargin = margen;
            HojaActiva.PageSetup.LeftMargin = margen;
            HojaActiva.PageSetup.RightMargin = margen;
            HojaActiva.PageSetup.BottomMargin = margen;

            Marshal.ReleaseComObject(Rango);
            Marshal.ReleaseComObject(HojaActiva);

            Rango = null;
            HojaActiva = null;

            oExcel.Visible = true;

        }

        
        private void CitasImprimir_FormClosing(object sender, FormClosingEventArgs e)
        {
            General.CierraProcesos();

        }


    }

}
