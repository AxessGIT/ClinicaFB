using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClinicaFB.Helpers;
using ClinicaFB.Modelo;
using Dapper;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.Office.Interop.Excel;

namespace ClinicaFB.Agenda
{
    public partial class DiaImprimir : Form
    {
        private FbConnection _db;
        private DateTime _fecha;
        public DiaImprimir(FbConnection db, DateTime fecha)
        {
            _db = db;
            _fecha = fecha;
            InitializeComponent();
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DiaImprimir_Load(object sender, EventArgs e)
        {
            dtpFecha.Value = _fecha;

        }

        
        private void ImprimeDia(FbConnection db)
        {
            DateTime fecha = dtpFecha.Value.Date;


            string sql = "";

            sql = "Select Citas.Cita_Id,Citas.TipoRecurso as Tipo,Citas.Recurso_Id,Citas.Fecha,Citas.Hora," +
                "Pacientes.Nombres,Pacientes.Apellido_Paterno,Pacientes.Apellido_Materno," +
                "Pacientes.Telefonos,Pacientes.Sexo,Pacientes.Fecha_Nacimiento,Citas.Bloqueada,Descripciones.Descripcion As Motivo From Citas ";
            sql += " Left Join Pacientes On Citas.Paciente_id = Pacientes.Paciente_Id";
            sql += " Left Join Descripciones On BloqueoMotivo_Id = Descripciones.Descripcion_Id";
            sql += " Where SucursalId =@SucursalId and  Citas.Fecha = @Fecha And Citas.Cancelada <> True" +
                " Order by Hora";

            List<DatosReporte> res = _db.Query<DatosReporte>(sql, new {SucursalId = Properties.Settings.Default.SucursalId, Fecha = fecha }).ToList();

            Microsoft.Office.Interop.Excel.Application oExcel;
            oExcel = new Microsoft.Office.Interop.Excel.Application();
            oExcel.Workbooks.Add();
            oExcel.ActiveWindow.DisplayGridlines = false;

            int renTitulos = 5;
            int ren = 6;

            oExcel.Cells[1, 1].Font.Bold = true;
            oExcel.Cells[1, 1].Font.Size = 12;
            oExcel.Cells[1, 1].Font.Name = "Tahoma";



            oExcel.Cells[1, 1] = "REPORTE DE CITAS DEL DIA " + fecha.ToLongDateString().ToUpper();
            oExcel.Cells[renTitulos, 3] = "TELEFONOS";
            oExcel.Cells[renTitulos, 4] = "RECURSO";

            string rangoTitulos = $"A{renTitulos.ToString().Trim()}:F{renTitulos.ToString().Trim()}";
            oExcel.Range[rangoTitulos].Font.Size = 10;
            oExcel.Range[rangoTitulos].Font.Bold = true;
            oExcel.Range[rangoTitulos].Font.Name = "Tahoma";
            oExcel.Cells[renTitulos, 1] = "HORA";
            oExcel.Cells[renTitulos, 2] = "PACIENTE";


            foreach (var cita in res)
            {
                string NombreRecurso = "";

                switch (cita.Tipo)
                {
                    case "DOC":
                        sql = Queries.DoctorSelect();
                        Doctor doc = db.QueryFirstOrDefault<Doctor>(sql, new { Doctor_Id = cita.Recurso_Id });
                        NombreRecurso = doc.NombreCompleto;
                        break;
                    case "EQU":
                        sql = Queries.EquipoSelect();
                        Equipo equ = db.QueryFirstOrDefault<Equipo>(sql, new { Equipo_Id = cita.Recurso_Id });
                        NombreRecurso = equ == null ? "" : equ.Nombre;
                        break;
                    case "CUA":
                        sql = Queries.CuartosSelect();
                        Cuarto cua = db.QueryFirstOrDefault<Cuarto>(sql, new { Cuarto_Id = cita.Recurso_Id });
                        NombreRecurso = cua == null ? "" : cua.Nombre;
                        break;


                }
                cita.Motivo = string.IsNullOrEmpty(cita.Motivo) ? "" : cita.Motivo;

                string pacienteNombre = string.IsNullOrEmpty(cita.Nombres) ? "" : cita.Nombres.Trim() + " ";
                pacienteNombre += string.IsNullOrEmpty(cita.Apellido_Paterno) ? "" : cita.Apellido_Paterno.Trim() + " ";
                pacienteNombre += string.IsNullOrEmpty(cita.Apellido_Materno) ? "" : cita.Apellido_Materno.Trim() + " ";


                oExcel.Cells[ren, 1].Style.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                oExcel.Cells[ren, 1] = cita.Hora;

                oExcel.Cells[ren, 2].Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                oExcel.Cells[ren, 2] = cita.Bloqueada ? cita.Motivo : pacienteNombre;

                oExcel.Cells[ren, 3].Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                oExcel.Cells[ren, 3] = cita.Telefonos;

                oExcel.Cells[ren, 4].Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                oExcel.Cells[ren, 4] = NombreRecurso;


                ren++;
            }

            oExcel.Range["A1"].EntireColumn.ColumnWidth = 6;
            oExcel.Range["B1"].EntireColumn.ColumnWidth = 25;
            oExcel.Range["C1"].EntireColumn.ColumnWidth = 20;

            float margen = 5f;
            oExcel.ActiveSheet.PageSetup.TopMargin = margen;
            oExcel.ActiveSheet.PageSetup.LeftMargin = margen;
            oExcel.ActiveSheet.PageSetup.RightMargin = margen;
            oExcel.ActiveSheet.PageSetup.BottomMargin = margen;

            oExcel.Visible = true;
        }

        private void cmdImprimir_Click(object sender, EventArgs e)
        {
            // Task.Run(() => ImprimeDia(_db));
            ImprimeDia(_db);
            //MessageBox.Show("Se generó el reporte","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void DiaImprimir_FormClosing(object sender, FormClosingEventArgs e)
        {
            General.CierraProcesos();

        }
    }
    }


