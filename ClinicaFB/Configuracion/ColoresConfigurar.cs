using ClinicaFB.Helpers;
using ClinicaFB.Modelo;
using Dapper;
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

namespace ClinicaFB.Configuracion
{
    public partial class ColoresConfigurar : Form
    {
        private FbConnection _db;
        public ColoresConfigurar(FbConnection db)
        {
            _db = db;
            InitializeComponent();
        }

        private void ColoresConfigurar_Load(object sender, EventArgs e)
        {
            txtCita.ForeColor = Color.Black;
            txtCita.BackColor = Color.White;

            txtMultiple.ForeColor = Color.Black;
            txtMultiple.BackColor = Color.White;

            txtBloqueo.ForeColor = Color.Black;
            txtBloqueo.BackColor = Color.White;

            txtConfirmado.ForeColor = Color.Black;
            txtConfirmado.BackColor = Color.White;

            txtAsistio.ForeColor = Color.Black;
            txtAsistio.BackColor = Color.White;

            string sql = Queries.ParametroSelect();
            Parametro par = _db.QueryFirstOrDefault<Parametro>(sql);

            if (par!=null)
            {

                if (par.ColorCitaLetra != null) txtCita.ForeColor = ColorTranslator.FromHtml(par.ColorCitaLetra);
                if (par.ColorCitaFondo != null) txtCita.BackColor = ColorTranslator.FromHtml(par.ColorCitaFondo);

                if (par.ColorMultipleLetra != null) txtMultiple.ForeColor = ColorTranslator.FromHtml(par.ColorMultipleLetra);
                if (par.ColorMultipleFondo != null) txtMultiple.BackColor = ColorTranslator.FromHtml(par.ColorMultipleFondo);

                if (par.ColorBloqueoLetra != null) txtBloqueo.ForeColor = ColorTranslator.FromHtml(par.ColorBloqueoLetra);
                if (par.ColorBloqueoFondo != null) txtBloqueo.BackColor = ColorTranslator.FromHtml(par.ColorBloqueoFondo);

                if (par.ColorConfirmadoLetra != null) txtConfirmado.ForeColor = ColorTranslator.FromHtml(par.ColorConfirmadoLetra);
                if (par.ColorConfirmadoFondo != null) txtConfirmado.BackColor = ColorTranslator.FromHtml(par.ColorConfirmadoFondo);

                if (par.ColorAsistioLetra != null) txtAsistio.ForeColor = ColorTranslator.FromHtml(par.ColorAsistioLetra);
                if (par.ColorAsistioFondo != null) txtAsistio.BackColor = ColorTranslator.FromHtml(par.ColorAsistioFondo);

            }
        }

        private void cmdCitaLetra_Click(object sender, EventArgs e)
        {
            PonColor(ref txtCita, true);
        }

        private void cmdCitaFondo_Click(object sender, EventArgs e)
        {
            PonColor(ref txtCita, false);

        }

        private void cmdMultipleLetra_Click(object sender, EventArgs e)
        {
            PonColor(ref txtMultiple, true);
        }

        private void cmdMultipleFondo_Click(object sender, EventArgs e)
        {
            PonColor(ref txtMultiple, false);

        }

        private void cmdBloqueoLetra_Click(object sender, EventArgs e)
        {
            PonColor(ref txtBloqueo, true);
        }

        private void cmdBloqueoFondo_Click(object sender, EventArgs e)
        {
            PonColor(ref txtBloqueo, false);
        }

        private void cmdConfirmadoLetra_Click(object sender, EventArgs e)
        {
            PonColor(ref txtConfirmado, true);

        }

        private void cmdConfirmadoFondo_Click(object sender, EventArgs e)
        {
            PonColor(ref txtConfirmado, false);

        }

        private void cmdAsistioLetra_Click(object sender, EventArgs e)
        {
            PonColor(ref txtAsistio, true);
        }

        private void cmdAsistioFondo_Click(object sender, EventArgs e)
        {
            PonColor(ref txtAsistio, false);
        }

        private void PonColor(ref TextBox textBox, bool letra)
        {
            ColorPicker cp = new ColorPicker();
            if (cp.ShowDialog() == DialogResult.OK)
            {
                if (letra)
                    textBox.ForeColor = cp.ColorSeleccionado;
                else
                    textBox.BackColor = cp.ColorSeleccionado;
            }

        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdGuardar_Click(object sender, EventArgs e)
        {

            Parametro p = _db.QueryFirstOrDefault<Parametro>(Queries.ParametroSelect());

            bool nuevo = false;
            if (p == null)
            {

                p = new Parametro();
                nuevo = true;
            }

            p.ColorCitaLetra = ColorTranslator.ToHtml(txtCita.ForeColor);
            p.ColorCitaFondo = ColorTranslator.ToHtml(txtCita.BackColor);


            p.ColorMultipleLetra = ColorTranslator.ToHtml(txtMultiple.ForeColor);
            p.ColorMultipleFondo = ColorTranslator.ToHtml(txtMultiple.BackColor);


            p.ColorBloqueoLetra = ColorTranslator.ToHtml(txtBloqueo.ForeColor);
            p.ColorBloqueoFondo = ColorTranslator.ToHtml(txtBloqueo.BackColor);



            p.ColorConfirmadoLetra = ColorTranslator.ToHtml(txtConfirmado.ForeColor);
            p.ColorConfirmadoFondo = ColorTranslator.ToHtml(txtConfirmado.BackColor);

            p.ColorAsistioLetra = ColorTranslator.ToHtml(txtAsistio.ForeColor);
            p.ColorAsistioFondo = ColorTranslator.ToHtml(txtAsistio.BackColor);


            string sql = "";
            if (nuevo)
                sql = Queries.ParametroInsert();
            else
                sql = Queries.ParametroUpdate();

            _db.Execute(sql, p);

            Close();





        }
    }
}
