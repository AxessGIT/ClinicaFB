using ClinicaFB.Helpers;
using ClinicaFB.Modelo;
using Dapper;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.Office.Interop.Excel;
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
    public partial class CitasCanceladasImprimir : Form
    {
        private DateTime _fecha;
        private FbConnection _db;

        public CitasCanceladasImprimir(FbConnection db, DateTime fecha)
        {
            _fecha = fecha;
            _db = db;
            InitializeComponent();
        }

        private void CitasCanceladasImprimir_Load(object sender, EventArgs e)
        {
            dtpFecha.Value = _fecha;

        }


        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdImprimir_Click(object sender, EventArgs e)
        {
            DateTime fecha = dtpFecha.Value.Date;

            string sql = "";
            sql = "Select Citas.Cita_Id,Citas.TipoRecurso as Tipo,Citas.Recurso_Id,Citas.Fecha,Citas.Hora," +
                   "Pacientes.Nombres,Pacientes.Apellido_Paterno,Pacientes.Apellido_Materno," +
                   "Pacientes.Telefonos,Pacientes.Sexo,Pacientes.Fecha_Nacimiento,Citas.Bloqueada,Descripciones.Descripcion As Motivo From Citas ";
            sql += "Citas.UsuarioCancelacion As Usuariocancelacion_Id, usuarios.Usuario";

            sql += " Inner Join Pacientes On Citas.Paciente_id = Pacientes.Paciente_Id";
            sql += " Innerv Join Usuarios On Citas.UsuarioCancelacion=Usuarios.Usuario_Id";
            sql += " Where Citas.Fecha = @Fecha And Citas.Cancelada = True Order  By Hora";

            var res = _db.Query<DatosReporte>(sql).ToList();
/*            var res = (from s in _db.citas
                       join p in _db.pacientes on s.pacienteid equals p.pacienteid into pacres
                       from Paciente in pacres.DefaultIfEmpty()
                       join m in _db.descripciones on s.cancelacionmotivoid equals m.descripcionid into motres
                       from Motivo in motres.DefaultIfEmpty()
                       join u in _db.usuarios on s.usuariocacelacion equals u.usuarioid into usures
                       from User in usures.DefaultIfEmpty()
                       where s.fecha == fecha && s.cancelada != null && s.cancelada == true
                       orderby s.hora
                       select
                       new
                       {
                           CitaID = s.citaid,
                           Tipo = s.tiporecurso,
                           RecursoID = s.recursoid,
                           Fecha = s.fecha,
                           Hora = s.hora,
                           PacienteNombre = Paciente == null ? "" : Paciente.nombres.Trim() + " " + Paciente.apellidopaterno.Trim() + " " + Paciente.apellidomaterno.Trim(),
                           PacienteTelefonos = Paciente == null ? "" : Paciente.telefonos,
                           Motivo = Motivo == null ? "" : Motivo.descripcion,
                           UsuarioID = User == null ? 0 : User.usuarioid,
                           UsuarioNombre = User.nombre
                       }
                       ).ToList();
*/

            Microsoft.Office.Interop.Excel.Application oExcel;
            oExcel = new Microsoft.Office.Interop.Excel.Application();
            oExcel.Workbooks.Add();
            oExcel.ActiveWindow.DisplayGridlines = false;

            int renTitulos = 5;
            int ren = 6;

            oExcel.Cells[1, 1].Font.Bold = true;
            oExcel.Cells[1, 1].Font.Size = 12;
            oExcel.Cells[1, 1].Font.Name = "Tahoma";



            oExcel.Cells[1, 1] = "REPORTE DE CITAS CANCELADAS DEL DIA " + fecha.ToLongDateString().ToUpper();

            string rangoTitulos = $"A{renTitulos.ToString().Trim()}:F{renTitulos.ToString().Trim()}";
            oExcel.Range[rangoTitulos].Font.Size = 10;
            oExcel.Range[rangoTitulos].Font.Bold = true;
            oExcel.Range[rangoTitulos].Font.Name = "Tahoma";
            oExcel.Cells[renTitulos, 1] = "HORA";
            oExcel.Cells[renTitulos, 2] = "PACIENTE";
            oExcel.Cells[renTitulos, 3] = "RECURSO";
            oExcel.Cells[renTitulos, 4] = "MOTIVO";
            oExcel.Cells[renTitulos, 5] = "USUARIO CANCELACION";


            foreach (var cita in res)
            {
                string NombreRecurso = "";

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

                string PacienteNombre = "";
                string UsuarioNombre = "";

                oExcel.Cells[ren, 1].Style.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                oExcel.Cells[ren, 1] = cita.Hora;

                oExcel.Cells[ren, 2].Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                oExcel.Cells[ren, 2] = PacienteNombre;

                oExcel.Cells[ren, 3].Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                oExcel.Cells[ren, 3] = NombreRecurso;

                oExcel.Cells[ren, 4].Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                oExcel.Cells[ren, 4] = cita.Motivo;

                oExcel.Cells[ren, 5].Style.HorizontalAlignment = XlHAlign.xlHAlignLeft;
                oExcel.Cells[ren, 5] = UsuarioNombre;

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
    }
}
