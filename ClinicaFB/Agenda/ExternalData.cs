using ClinicaFB.Helpers;
using Dapper;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Agenda
{
    public class ExternalData
    {
        private int _rowCount;
        private int _colCount;
        private CeldaLayout[,] _data;
        private DateTime _fecha;

        private List<InfoColumna> _infoColumnas;
        private List<InfoHorario> _horarios;

        private string _sql = Queries.CitaFechaSelect();



        public ExternalData(int rows, int cols, DateTime fecha, List<InfoHorario> horarios, List<InfoColumna> infoColumnas)
        {
            //Sets number of rows and columns.
            _rowCount = rows;
            _colCount = cols;
            _fecha = fecha;

            _horarios = horarios;
            _infoColumnas = infoColumnas;

            //Allocates memory to store data values.
            Update();
        }

        //Sets Properties.
        public virtual CeldaLayout this[int row, int col]
        {
            get { return _data[row, col]; }
            set { _data[row, col] = value; }
        }

        public virtual int RowCount
        {
            get { return _rowCount; }
        }

        public virtual int ColCount
        {
            get { return _colCount; }
        }

        #region QueryDB
        private void Update()
        {

            _data = new CeldaLayout[_rowCount, _colCount];

            using (FbConnection db = General.GetDB())
            {
                int sucursalId = Properties.Settings.Default.SucursalId;
                var res = db.Query<CitaFecha>(_sql, new {SucursalId=sucursalId, Fecha = _fecha }).ToList();

                foreach (var c in res)
                {

                    string nombrePaciente = c.NombreCompletoPaciente;
                    string motivoDes = c.BloqueoMotivo == null ? "" : c.BloqueoMotivo;

                    string tipoRecurso = c.TipoRecurso;
                    int recursoId = c.Recurso_Id;

                    var columnasRecurso = _infoColumnas.FindAll(x => x.TipoRecurso == tipoRecurso && x.RecursoID == recursoId);

                    foreach (var cr in columnasRecurso)
                    {

                        InfoHorario datosHorario = _horarios.Find(x => x.Hora == c.Hora);

                        if (datosHorario != null)
                        {
                            int indiceHorario = _horarios.IndexOf(datosHorario);
                            var citas = res.FindAll(x => x.TipoRecurso == cr.TipoRecurso && x.Recurso_Id == cr.RecursoID && x.Hora == c.Hora);

                            int renglon = _horarios[indiceHorario].Renglon;
                            int columna = cr.Columna;

                            string leyenda = string.Empty;
                            string estatus = string.Empty;

                            if (citas.Count() == 1)
                            {
                                if (citas[0].Bloqueada)
                                {
                                    leyenda = citas[0].BloqueoMotivo;
                                    estatus = "BLO";

                                }
                                else
                                {
                                    leyenda = citas[0].NombreCompletoPaciente;
                                    estatus = "UNO";
                                    if (citas[0].Confirmado == true) estatus = "CON";
                                    if (citas[0].Asistio == true) estatus = "ASI";
                                }
                            }
                            else
                            {
                                leyenda = "Multiple";
                                estatus = "MUL";
                            }


                            CeldaLayout cl = new CeldaLayout()
                            {
                                Leyenda = leyenda,
                                Status = estatus
                            };

                            _data[renglon - 1, columna - 1] = cl;

                        }

                    }

                }
            }

         
        }
        #endregion

    }
}
