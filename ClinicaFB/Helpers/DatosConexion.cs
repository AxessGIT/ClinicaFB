using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ClinicaFB.Helpers
{
    public class DatosConexion
    {
        private string _archivoXML = "";
        public string Servidor { get; set; }="";
        public string Usuario { get; set; } = "";
        public string PassWord { get; set; } = "";
        public string Carpeta { get; set; } = "";
        public string BaseDeDatos { get; set; } = "";
        public string CarpetaConfig { get; set; } = "";
        public string BaseDeDatosConfig { get; set; } = "";
        public string BaseDeDatosModelo { get; set; } = "";

        public DatosConexion(string archivoXml)
        {
            _archivoXML = archivoXml;
            cargaDatosConexion();

        }


        private void cargaDatosConexion()
        {
            XmlDocument conexionxml = new XmlDocument();
            conexionxml.Load(_archivoXML);
            XmlNode root = conexionxml.DocumentElement;

            XmlNode nodo = root.SelectSingleNode("servidor");

            if (nodo!=null)
            {
                Servidor = nodo.InnerText.Trim();
            }

            nodo = root.SelectSingleNode("usuario");
            if (nodo != null)
            {
                Usuario = nodo.InnerText.Trim();
            }

            nodo = root.SelectSingleNode("password");

            if (nodo != null)
            {
                PassWord = nodo.InnerText.Trim();
            }

            nodo = root.SelectSingleNode("carpeta");

            if (nodo != null)
            {
                Carpeta= nodo.InnerText.Trim()+@"\";
            }

            if (Carpeta != "")
                CarpetaConfig = Carpeta + @"Config\";

            BaseDeDatosConfig = CarpetaConfig + @"\Configuracion.FDB";
            BaseDeDatosModelo = CarpetaConfig + @"\Modelo.FDB";


        }

    }
}
