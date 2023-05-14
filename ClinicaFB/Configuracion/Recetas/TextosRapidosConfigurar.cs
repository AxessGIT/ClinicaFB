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


namespace ClinicaFB.Configuracion.Recetas
{
    public partial class TextosRapidosConfigurar : Form
    {
        private bool _esAlta;
        private int _usuarioId;
        private int _textoId=0;
        public TextosRapidosConfigurar()
        {
            InitializeComponent();
        }

        private void cmdRegresar_Click(object sender, EventArgs e)
        {
            GuardaTextos();
            Close();
        }

        private void TextosRapidosConfigurar_Load(object sender, EventArgs e)
        {
            _usuarioId = (int) Properties.Settings.Default.Usuario_ID;
            cargaTextos();
        }

        private void GuardaTextos()
        {
            TextoRapido tr = new TextoRapido();
            tr.TextoId = _textoId;
            tr.UsuarioId = _usuarioId;
            tr.Texto = txtTextosRapidos.Text;
            tr.Boton1 = txtBoton1.Text;
            tr.Boton2 = txtBoton2.Text;
            tr.Boton3 = txtBoton3.Text;
            tr.Boton4 = txtBoton4.Text;
            tr.Boton5 = txtBoton5.Text;
            tr.Boton6 = txtBoton6.Text;
            tr.Boton7 = txtBoton7.Text;


            using (FbConnection db = General.GetDB())
            {
                string sql = _esAlta?Queries.TRInsert():Queries.TRUpdate();
                db.Execute(sql, tr);
            }

        }
        private void cargaTextos()
        {

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.TRSelectByUsr();
                TextoRapido tr = db.QueryFirstOrDefault<TextoRapido>(sql, new {UsuarioId = _usuarioId });
                if (tr == null)
                {
                    _esAlta = true;
                }
                else
                {
                    _textoId = tr.TextoId;
                    txtTextosRapidos.Text = tr.Texto;
                    txtBoton1.Text = tr.Boton1;
                    txtBoton2.Text = tr.Boton2;
                    txtBoton3.Text = tr.Boton3; 
                    txtBoton4.Text = tr.Boton4; 
                    txtBoton5.Text = tr.Boton5;
                    txtBoton6.Text = tr.Boton6;
                    txtBoton7.Text = tr.Boton7;
                    _esAlta=false;

                }


            }


        }
        
    }
}
