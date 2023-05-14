using ClinicaFB.ModeloConfiguracion;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Net;
using System.IO;

namespace ClinicaFB.Helpers
{
    public class SincronizaAgendaWEB
    {
        private FbConnection _dbConfiguracion;
        private FbConnection _db;
        private Empresa _datosEmpresa;
        private string _servicioWEBURL;


        public SincronizaAgendaWEB(FbConnection dbConfiguracion, FbConnection db)
        {
            _dbConfiguracion = dbConfiguracion;
            _db = db;

        }
        public async Task Sincroniza()
        {
            await Task.Run(() => cargaDatosEmpresa());

            if (_datosEmpresa == null)
                return;

            if (string.IsNullOrEmpty(_datosEmpresa.WebServiceURL) || string.IsNullOrEmpty(_datosEmpresa.CarpetaWEB)
                || string.IsNullOrEmpty(_datosEmpresa.BddWEB))
                return;

            _servicioWEBURL = _datosEmpresa.WebServiceURL + "/ClinicaFB/";


        }

        private void cargaDatosEmpresa()
        {
            long empresaId =  Properties.Settings.Default.Empresa_ID;

            string sql = Queries.EmpresaSelect();
            _datosEmpresa = _dbConfiguracion.QueryFirstOrDefault<Empresa>(sql, new { Empresa_id = empresaId });


        }

        private void ActualizaRecursos()
        {

        }

        private void ActualizaDoctores()
        {
            HttpWebRequest request = WebRequest.Create("http://www.url.com/api/Memberapi") as HttpWebRequest;
            //optional
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Stream stream = response.GetResponseStream();
        }
    }
}
