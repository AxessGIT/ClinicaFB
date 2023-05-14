using ClinicaFB.Modelo;
using Dapper;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFB.Helpers
{
    public static class ChecaDatos
    {
        public static void ChecaImpuestos()
        {
            string sql = Queries.ImpuestoSelectxDes();

            using (FbConnection db = General.GetDB())
            {
                Impuesto imp = new Impuesto();
                imp = db.Query<Impuesto>(sql, new {Descripcion="IVA" }).FirstOrDefault();

                if (imp == null)
                {

                    imp = new Impuesto();
                    imp.Descripcion = "IVA";
                    imp.Porcentaje = 16;
                    imp.Defa = true;

                    sql = Queries.ImpuestoInsert();
                    db.Execute(sql, imp);
                }

                sql = Queries.ImpuestoSelectxDes();
                imp = db.Query<Impuesto>(sql, new { Descripcion = "EXENTO" }).FirstOrDefault();

                if (imp == null)
                {

                    imp = new Impuesto();
                    imp.Descripcion = "EXENTO";
                    imp.Porcentaje = 0;
                    imp.Defa = false;

                    sql = Queries.ImpuestoInsert();
                    db.Execute(sql, imp);
                }


            }
        }

        public static bool ImpuestoReservado(string descripcion)
        {
            bool esReservado = false;
            string des = descripcion.ToUpper().Trim();
            string[] impuestos = { "IVA", "EXENTO" };

            foreach (string s in impuestos)
            {
                if (s == des)
                {
                    esReservado = true;
                    break;
                }
            }



            return esReservado;
        }
    }
}
