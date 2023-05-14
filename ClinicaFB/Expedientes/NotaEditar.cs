using ClinicaFB.Helpers;
using ClinicaFB.Modelo;
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

namespace ClinicaFB.Expedientes
{
    public partial class NotaEditar : Form
    {
        private int _pacienteId;
        private bool _esAlta;
        private int _notaId;
        public NotaEditar(int pacienteId,bool esAlta, int notaId)
        {
            InitializeComponent();
            _esAlta = esAlta;
            _notaId = notaId;
            _pacienteId = pacienteId;
        }

        private void NotaEditar_Load(object sender, EventArgs e)
        {
            if (_esAlta)
            {
                txtNota.Text = String.Empty;

            }
            else
            {

                using (FbConnection db = General.GetDB())
                {
                    string sql = Queries.NotaSelect();
                    Nota nota = db.QueryFirstOrDefault<Nota>(sql, new { NotaId = _notaId });

                    if (nota != null)
                    {
                        txtNota.Text = nota.Texto;
                    }

                }
            }
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void GuardaNota()
        {
            if (_esAlta && txtNota.Text == String.Empty)
                return;

            int usuarioId = (int) Properties.Settings.Default.Usuario_ID;
            string sql = "";
            sql = _esAlta ? Queries.NotaInsert() : Queries.NotaUpdate();
            Nota nota = new Nota();

            nota.PacienteId = _pacienteId;
            nota.Fecha = DateTime.Now;            
            nota.Texto = txtNota.Text;

            if (_esAlta)
            {
                nota.FechaHoraCreacion = DateTime.Now;
                nota.UsuarioCreacionId = usuarioId;
                _esAlta = false;
            }
            else
            {
                nota.NotaId = _notaId;
                nota.FechaHoraEdicion = DateTime.Now;
                nota.UsuarioEdicionId = usuarioId;

            }

            using (FbConnection db = General.GetDB())
            {
               _notaId = db.Execute(sql, nota);
            }

        }
        private void NotaEditar_FormClosing(object sender, FormClosingEventArgs e)
        {
            GuardaNota();
        }
    }
}
