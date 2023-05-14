using ClinicaFB.Helpers;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace ClinicaFB.Modelo
{
    public class PacienteNotas
    {
        private ObservableCollection<Nota> _notas;
        private long _pacienteId;

        public ObservableCollection<Nota> Notas
        {
            get { return _notas; }
            set { _notas = value; }

        }

        public PacienteNotas(long pacienteId)
        {
            _pacienteId = pacienteId;
            GetNotas();

        }

        private void GetNotas()
        {

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.PacientesNotas();
                var result = db.Query<Nota>(sql, new { PacienteId = _pacienteId }).ToList();
                _notas = new ObservableCollection<Nota>(result);


            }


        }
    }
}
