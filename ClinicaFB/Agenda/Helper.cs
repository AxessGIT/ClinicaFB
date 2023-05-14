using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace ClinicaFB.Agenda
{
    public static class Helper
    {
        public static InfoColumna GetInfoColumna(List<InfoColumna> infoColumnas, int columna)
        {
            InfoColumna infoColumna = infoColumnas.Find(x => x.Columna == columna);
            return infoColumna;
        }

        public static BindingList<Recurso> cargaDoctores(FbConnection db)
        {

            BindingList<Recurso> doctores = null;

            string sql = "Select Doctor_Id as Recurso_Id,'DOC' as Tipo, Trim(Nombres)||' '||Trim(Apellido_Paterno)||' '||Trim(Apellido_Materno) as Nombre From Doctores Order By Nombre";
            var res = db.Query<Recurso>(sql).ToList();
            doctores = new BindingList<Recurso>(res);

            return doctores;


        }

        public static BindingList<Recurso> cargaEquipos(FbConnection db)
        {

            BindingList<Recurso> equipos = null;

            string sql = "Select Equipo_Id as Recurso_Id,'EQU' as Tipo, Nombre From Equipos Order By Nombre";
            var res = db.Query<Recurso>(sql).ToList();
            equipos = new BindingList<Recurso>(res);

            return equipos;


        }

        public static BindingList<Recurso> cargaCuartos(FbConnection db)
        {

            BindingList<Recurso> cuartos = null;

            string sql = "Select Cuarto_Id as Recurso_Id,'CUA' as Tipo, Nombre From Cuartos Order By Nombre";
            var res = db.Query<Recurso>(sql).ToList();
            cuartos = new BindingList<Recurso>(res);

            return cuartos;


        }

    }
}
