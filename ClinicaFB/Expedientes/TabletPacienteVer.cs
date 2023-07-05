using AForge.Video.DirectShow;
using ClinicaFB.Helpers;
using ClinicaFB.Modelo;
using ClinicaFB.Reportes;
using Dapper;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.Reporting.WinForms;
using Syncfusion.WinForms.DataGrid;
using Syncfusion.XPS;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaFB.Expedientes
{
    public partial class TabletPacienteVer : Form
    {
        private int _pacienteId;
        private Paciente _paciente;

        ObservableCollection<Nota> _notas = new ObservableCollection<Nota>();
        BindingList<Receta> _listRecetas = new BindingList<Receta>();
        BindingList<RecetaMedipiel> _listRecetasMedipiel = new BindingList<RecetaMedipiel>();

        BindingList<PacientesImagenes> _PacienteImagenes = new BindingList<PacientesImagenes>();


        public TabletPacienteVer(int pacienteId)
        {
            _pacienteId = pacienteId;
            InitializeComponent();
        }

        private void TabletPacienteVer_Load(object sender, EventArgs e)
        {

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.PacienteSelect();
                _paciente = db.Query<Paciente>(sql, new { Paciente_Id = _pacienteId }).FirstOrDefault();

            }

            if (_paciente == null)
                return;


            MuestraDatos();
            CargaNotas();


        }

        private void MuestraDatos()
        {



            if (_paciente.Fecha_Nacimiento>=dtpFechaNacimiento.MinDate)
                dtpFechaNacimiento.Value = _paciente.Fecha_Nacimiento;

            txtEdad.Text = General.calculaEdad(dtpFechaNacimiento.Value).ToString() + " años";

            txtEstadoCivil.Text = General.GetDescripcion("EDC", (int)_paciente.EdoCivilId);
            txtOcupacion.Text = General.GetDescripcion("OCU", (int)_paciente.OcupacionId);
            txtReferidoPor.Text = General.GetDescripcion("REF", (int)_paciente.ReferenteId);
            txtOrigen.Text = General.GetDescripcion("CIU", (int)_paciente.CiudadOrigenId);
            txtDiagnostico.Text = General.GetDescripcion("DIA", (int)_paciente.DiagnosticoId);

            txtColorDePiel.Text = General.GetDescripcion("PIE", (int)_paciente.PielId);
            txtExposicionSolar.Text = General.GetDescripcion("EXS", (int)_paciente.SolarId);

            txtMedico.Text = General.GetDescripcion("MED", (int)_paciente.MedicoId);
            txtMaquillaje.Text = General.GetDescripcion("MAQ", (int)_paciente.MaquillajeId);

            txtMedicamentos.Text = _paciente.Medicamentos;
            txtAntecedentes.Text = _paciente.Antecedentes;
            txtAlergias.Text = _paciente.Alergias;


            MuestraFoto();


        }


        private void MuestraFoto()
        {
            string carpeta = General.CarpetaImagenesEmpresa() + "\\" + General.CarpetaImagenesPaciente(_pacienteId) + "\\";
            string archivo = carpeta + "Foto.png";




            if (File.Exists(archivo)) {


                using (var fs = new FileStream(archivo, FileMode.Open, FileAccess.Read))
                {
                    Image tmpImage = Image.FromStream(fs);
                    picFoto.Image = new Bitmap(tmpImage);
                    tmpImage.Dispose();
                }


                //Image img = Image.FromStream(new MemoryStream(File.ReadAllBytes(archivo)));
                //picFoto.Image = img;
            }


        }
        private void CargaNotas()
        {


            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.PacientesNotas();
                var resultado = db.Query<Nota>(sql, new { PacienteId = _paciente.Paciente_Id });
                _notas = new ObservableCollection<Nota>(resultado);

            }

            grdNotas.DataSource = _notas;
        }

        private void grdNotas_QueryRowHeight(object sender, Syncfusion.WinForms.DataGrid.Events.QueryRowHeightEventArgs e)
        {
            RowAutoFitOptions autoFitOptions = new RowAutoFitOptions();
            int autoHeight = 0;
            if (grdNotas.AutoSizeController.GetAutoRowHeight(e.RowIndex, autoFitOptions, out autoHeight))
            {
                if (autoHeight > 24)
                {
                    e.Height = autoHeight + 10;
                    e.Handled = true;
                }
            }

        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pagDatosACT_Enter(object sender, EventArgs e)
        {

                using (FbConnection db = General.GetDB())
                {
                    string sql = Queries.ActDatosSelect();
                    ActDatos actDatos = db.QueryFirstOrDefault<ActDatos>(sql, new { PacienteId = _pacienteId });
                    if (actDatos == null)
                        return;
                    txtActPrefijo.Text = actDatos.Prefijo;
                    txtActSaludo.Text = actDatos.Saludo;
                    txtActCategoria.Text = actDatos.Categoria;
                    txtActTitulo.Text = actDatos.Titulo;
                    txtActEstadoCivil.Text = actDatos.EstadoCivil;
                    txtActSexo.Text = actDatos.Sexo;
                    txtActCiudadOrigen.Text = actDatos.CiudadOrigen;
                    txtActAlergias1.Text = actDatos.Alergias1;
                    txtActAlergias2.Text = actDatos.Alergias2;
                    txtActMedico.Text = actDatos.Medico;
                    txtActTipoPiel.Text = actDatos.TipoPiel;
                    txtActMedicamentos.Text = actDatos.Medicamentos;
                    txtActMaquillaje.Text = actDatos.Maquillaje;
                    txtActTxPrevio.Text = actDatos.TxPrevio;
                    txtActEdad.Text = actDatos.Edad;
                    txtActEnfer1.Text = actDatos.Enfer1;
                    txtActEnfer2.Text = actDatos.Enfer2;
                    txtActEnfer3.Text = actDatos.Enfer3;
                    txtActEnfer4.Text = actDatos.Enfer4;
                    txtActEnfer5.Text = actDatos.Enfer5;
                    txtActEnfer6.Text = actDatos.Enfer6;
                    txtActEnfer7.Text = actDatos.Enfer7;
                    txtActEnfer8.Text = actDatos.Enfer8;
                    txtActEnfer9.Text = actDatos.Enfer9;
                    txtActTelefono.Text = actDatos.Telefono;
                    txtActRFC.Text = actDatos.RFC;
                    txtActCURP.Text = actDatos.CURP;
                    txtActDir1.Text = actDatos.Dir1;
                    txtActDir2.Text = actDatos.Dir2;
                    txtActDir3.Text = actDatos.Dir3;
                    txtActCiudad.Text = actDatos.Ciudad;
                    txtActEstado.Text = actDatos.Estado;
                    txtActCodigoPostal.Text = actDatos.CP;
                    txtActPais.Text = actDatos.Pais;



                }

        }

        private void grdNotas_QueryRowHeight_1(object sender, Syncfusion.WinForms.DataGrid.Events.QueryRowHeightEventArgs e)
        {
            RowAutoFitOptions autoFitOptions = new RowAutoFitOptions();
            int autoHeight=0;
            if (this.grdNotas.AutoSizeController.GetAutoRowHeight(e.RowIndex, autoFitOptions, out autoHeight))
            {
                if (autoHeight > 24)
                {
                    e.Height = autoHeight;
                    e.Handled = true;
                }
            }
    }

        private void pagRecetas_Enter(object sender, EventArgs e)
        {
            CargaTextosRapidos();
        }

        private void CargaTextosRapidos()
        {

            using (FbConnection db = General.GetDB())
            {
                BindingList<string> textosRapidos = new BindingList<string>();
                int usuarioId = (int) Properties.Settings.Default.Usuario_ID;
                string sql = Queries.TRSelectByUsr();
                TextoRapido tr = db.QueryFirstOrDefault<TextoRapido>(sql, new {UsuarioId = usuarioId });
                if (tr != null)
                {
                    string[] lineas = tr.Texto.Split(new string[] { Environment.NewLine },StringSplitOptions.None);
                    Array.Sort(lineas);

                    textosRapidos = new BindingList<string>(lineas);

                    
                    cboTextosRapidos.DataSource = textosRapidos;
                    cmdBoton1.Text = tr.Boton1;
                    cmdBoton2.Text = tr.Boton2;
                    cmdBoton3.Text = tr.Boton3;
                    cmdBoton4.Text = tr.Boton4;
                    cmdBoton5.Text = tr.Boton5;
                    cmdBoton6.Text = tr.Boton6;
                    cmdBoton7.Text = tr.Boton7;




                }
            }

        }

        private void pagRecetas_Click(object sender, EventArgs e)
        {

        }

        private void PonTextoBoton(Button boton)
        {
            txtTexto.Text += boton.Text+" ";

        }

        private void cmdBoton1_Click(object sender, EventArgs e)
        {
            PonTextoBoton(cmdBoton1);

        }

        private void cmdBoton2_Click(object sender, EventArgs e)
        {
            PonTextoBoton(cmdBoton2);

        }

        private void cmdBoton3_Click(object sender, EventArgs e)
        {
            PonTextoBoton(cmdBoton3);

        }

        private void cmdBoton4_Click(object sender, EventArgs e)
        {
            PonTextoBoton(cmdBoton4);

        }

        private void cmdBoton5_Click(object sender, EventArgs e)
        {
            PonTextoBoton(cmdBoton5);

        }

        private void cmdBoton6_Click(object sender, EventArgs e)
        {
            PonTextoBoton(cmdBoton6);

        }
        private void cmdBoton7_Click(object sender, EventArgs e)
        {
            PonTextoBoton(cmdBoton7);
        }

        private void cboTextosRapidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTexto.Text += cboTextosRapidos.SelectedValue+" ";
        }

        private void pagRecetasPaciente_Enter(object sender, EventArgs e)
        {
            txtRecetaGuardada.BackColor = Color.White;
            txtRecetaGuardada.ForeColor = Color.Black;

            txtEtiquetasGuardadas.BackColor = Color.White;
            txtEtiquetasGuardadas.ForeColor = Color.Black;

            CargaRecetas(1);

        }
        private void CargaRecetas(int tipo)
        {

            string query = "";
            switch (tipo)
            {
                case 1:
                    query = Queries.RecetasPacienteSelect();
                    break; 
                case 2:
                    query= Queries.RecetasDoctorSelect();
                    break;
                case 3:
                    query = Queries.RecetasBuscar(txtBuscarRecetas.Text);
                    break;
                case 4:
                    query = Queries.RecetasBuscar(txtBuscarRecetasDoctor.Text);
                    break;
            }


            using (FbConnection db = General.GetDB())
            {
                string sql = query;
                List<Receta> res = new List<Receta>();
                if (tipo==1 )
                    res = db.Query<Receta>(sql, new { Pacienteid = _pacienteId }).ToList();
                else
                    res = db.Query<Receta>(sql, new { UsuarioId = ClinicaFB.Properties.Settings.Default.Usuario_ID }).ToList();


                _listRecetas = new BindingList<Receta>(res);
            }

            if (tipo==1 || tipo==3)
            { 
                grdRecetas.DataSource = null;

                grdRecetas.AutoGenerateColumns = false;
                grdRecetas.ReadOnly = true;
                grdRecetas.AllowUserToResizeColumns = false;
                grdRecetas.AllowUserToResizeRows = false;
                grdRecetas.ColumnHeadersVisible = false;

                grdRecetas.ColumnCount = 1;

                grdRecetas.RowHeadersVisible = true;
                grdRecetas.Columns[0].HeaderText = "Fecha";
                grdRecetas.Columns[0].DataPropertyName = "FechaLarga";
                grdRecetas.Columns[0].Width = 230;
                grdRecetas.DataSource = _listRecetas;
            }

            if (tipo==2 || tipo==4)
            {
                grdRecetasDoctor.DataSource = null;

                grdRecetasDoctor.AutoGenerateColumns = false;
                grdRecetasDoctor.ReadOnly = true;
                grdRecetasDoctor.AllowUserToResizeColumns = false;
                grdRecetasDoctor.AllowUserToResizeRows = false;
                grdRecetasDoctor.ColumnHeadersVisible = false;

                grdRecetasDoctor.ColumnCount = 1;

                grdRecetasDoctor.RowHeadersVisible = true;
                grdRecetasDoctor.Columns[0].HeaderText = "Fecha";
                grdRecetasDoctor.Columns[0].DataPropertyName = "FechaLarga";
                grdRecetasDoctor.Columns[0].Width = 230;
                grdRecetasDoctor.DataSource = _listRecetas;

            }
        }

        private void cmdGurdarReceta_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTexto.Text))
            {
                MessageBox.Show("Indique el texto de la receta","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            
            DateTime fecha = DateTime.Now;
            string sql = Queries.RecetasPacienteSelectByPacAndFec();

            using (FbConnection db = General.GetDB())
            {
                Receta rec = db.QueryFirstOrDefault<Receta>(sql, new {PacienteId= _pacienteId, Fecha=fecha });

                if (rec != null)
                {
                   if ( MessageBox.Show("Ya existe(n) otra(s) receta(s) guardada(s) en esta fecha ¿Desea guardar una nueva receta?",
                        "Confirme", 
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question)==DialogResult.No)
                        return;

                }

                sql = Queries.RecetaPacienteInsert();
                rec = new Receta();
                rec.PacienteId = _pacienteId;
                rec.Fecha = fecha;
                rec.Texto = txtTexto.Text;  
                rec.Etiquetas= txtEtiquetas.Text;
                rec.UsuarioId = (int)Properties.Settings.Default.Usuario_ID;

                db.Execute(sql, rec);
                MessageBox.Show("Se guardó la receta","Aviso",MessageBoxButtons.OK, MessageBoxIcon.Information);


            }

        }

        private void grdRecetas_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int ren = e.RowIndex;
            txtRecetaGuardada.Text = _listRecetas[ren].Texto;
            txtEtiquetasGuardadas.Text = _listRecetas[ren].Etiquetas;
        }

        private void cmdTraerUltimaReceta_Click(object sender, EventArgs e)
        {

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.RecetasPacienteSelectUltima();
                Receta rec = db.QueryFirstOrDefault<Receta>(sql, new { PacienteId = _pacienteId });
                if (rec == null)
                {
                    MessageBox.Show("No existen recetas guardadas para ese paciente","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return;
                }

                txtTexto.Text = rec.Texto;
                txtEtiquetas.Text = rec.Etiquetas;

            }
        }

        private void pagRecetasMedipiel_Click(object sender, EventArgs e)
        {

        }

        private void pagRecetasMedipiel_Enter(object sender, EventArgs e)
        {
            txtRecetaMedipiel.BackColor = Color.White;
            txtRecetaMedipiel.ForeColor = Color.Black;

            txtCompletoMedipiel.BackColor= Color.White;
            txtCompletoMedipiel.ForeColor= Color.Black;
            CargaRecetasMedipiel(Queries.RecetasMedipielSelect());
        }

        private void CargaRecetasMedipiel(string query)
        {


            using (FbConnection db = General.GetDB())
            {
                string sql = query;

                var res = db.Query<RecetaMedipiel>(sql).ToList();

                _listRecetasMedipiel = new BindingList<RecetaMedipiel>(res);
            }

            grdRecetasMedipiel.DataSource = null;

            grdRecetasMedipiel.AutoGenerateColumns = false;
            grdRecetasMedipiel.ReadOnly = true;
            grdRecetasMedipiel.AllowUserToResizeColumns = false;
            grdRecetasMedipiel.AllowUserToResizeRows = false;
            grdRecetasMedipiel.ColumnHeadersVisible = false;

            grdRecetasMedipiel.ColumnCount = 1;

            grdRecetasMedipiel.RowHeadersVisible = true;
            grdRecetasMedipiel.Columns[0].HeaderText = "Receta";
            grdRecetasMedipiel.Columns[0].DataPropertyName = "Rece";
            grdRecetasMedipiel.Columns[0].Width = 230;
            grdRecetasMedipiel.DataSource = _listRecetasMedipiel;
        }

        private void grdRecetasMedipiel_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtRecetaMedipiel.Text = _listRecetasMedipiel[e.RowIndex].Rece;
            txtCompletoMedipiel.Text = _listRecetasMedipiel[e.RowIndex].Completo;

        }

        private void cmdPasarAReceta_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRecetaGuardada.Text) && string.IsNullOrEmpty(txtEtiquetasGuardadas.Text))
                return;

            if (string.IsNullOrEmpty(txtRecetaGuardada.Text)==false)
                txtTexto.Text = txtRecetaGuardada.Text;


            if (string.IsNullOrEmpty(txtEtiquetasGuardadas.Text) == false)
                txtEtiquetas.Text = txtEtiquetasGuardadas.Text;

            txtTexto.Focus();
            tabPaciente.SelectedIndex = 2;
        }

        private void cmdBorrarRecetaGuardada_Click(object sender, EventArgs e)
        {
            if (grdRecetas.CurrentRow == null)
            {
                MessageBox.Show("Indique la receta que desea borrar","Verifique",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("¿Desea borrar la receta?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            using (FbConnection db = General.GetDB())
            {
                int recetaId = _listRecetas[grdRecetas.CurrentRow.Index].PacienteRecetaId;
                string sql = Queries.RecetaPacienteDelete();
                db.Execute(sql, new { PacienteRecetaId = recetaId });
                CargaRecetas(1);
                txtRecetaGuardada.Text = "";
                txtEtiquetasGuardadas.Text = "";
            }
        }

        private void cmdBuscarRecetaMedipiel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBuscarRecetasMedipiel.Text))
            {
                MessageBox.Show("Indique lo que desea buscar","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            string sql = Queries.RecetasMedipielBuscar(txtBuscarRecetasMedipiel.Text);
            CargaRecetasMedipiel(sql);
        }

        private void cmdQuitarFiltro_Click(object sender, EventArgs e)
        {
            CargaRecetasMedipiel(Queries.RecetasMedipielSelect());
        }

        private void cmdQuitarFiltroRecetas_Click(object sender, EventArgs e)
        {
            CargaRecetas(1);

        }

        private void cmdFiltrarRecetas_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBuscarRecetas.Text))
            {
                MessageBox.Show("Indique el texto a buscar","Confime",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            CargaRecetas(3);

        }

        private void cmdPasarRecetaMedipiel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRecetaMedipiel.Text))
                return;

            txtTexto.Text = txtRecetaMedipiel.Text;



            txtTexto.Focus();
            tabPaciente.SelectedIndex = 2;

        }

        private void pagImagenes_Enter(object sender, EventArgs e)
        {
            RefrescaImagenes();
        }

        private void RefrescaImagenes()
        {
            Cargaimagenes();
            SetGridImagenes();

        }

        private void Cargaimagenes()
        {

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.PacienteImagenesSelect();
                var res = db.Query<PacientesImagenes>(sql, new { PacienteId = _paciente.Paciente_Id }).ToList();

                _PacienteImagenes = new BindingList<PacientesImagenes>(res);
                foreach (var img in _PacienteImagenes)
                {
                    img.Imagen = File.ReadAllBytes(img.RutaImagen);

                }
            }

        }


        private void SetGridImagenes()
        {
            grdImagenes.DataSource = null;



            grdImagenes.AllowUserToAddRows = false;
            grdImagenes.AllowUserToDeleteRows = false;


            grdImagenes.AutoGenerateColumns = false;
            grdImagenes.ReadOnly = true;
            grdImagenes.AllowUserToResizeColumns = false;
            grdImagenes.AllowUserToResizeRows = false;
            colImagen.ImageLayout = DataGridViewImageCellLayout.Stretch;



            grdImagenes.DataSource = _PacienteImagenes;

        }


        private void ImagenesAltasCambios(bool esAlta)
        {
            int id = 0;

            if (esAlta == false)
            {
                id = _PacienteImagenes[grdImagenes.CurrentRow.Index].PacImId;
            }
            ImagenAltasCambios imagenAltasCambios = new ImagenAltasCambios(id, (int)_paciente.Paciente_Id, esAlta);
            imagenAltasCambios.ShowDialog();
            RefrescaImagenes();


        }

        private void cmdImagenAgregar_Click(object sender, EventArgs e)
        {
            ImagenesAltasCambios(true);

        }

        private void cmdImagenModificar_Click(object sender, EventArgs e)
        {
            if (grdImagenes.CurrentRow == null)
            {
                MessageBox.Show("Indique la imagen a modificar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ImagenesAltasCambios(false);

        }

        private void cmdImagenBorrar_Click(object sender, EventArgs e)
        {
            if (grdImagenes.CurrentRow == null)
            {
                MessageBox.Show("Indique la imagen a borrar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (MessageBox.Show("¿Desea borrar la imagen?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;


            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.PacienteImagenDelete();
                int id = _PacienteImagenes[grdImagenes.CurrentRow.Index].PacImId;
                db.Execute(sql, new { PacImId = id });
            }
            RefrescaImagenes();

        }

        private void picFoto_Click(object sender, EventArgs e)
        {

        }

        private void cmdVideo_Click(object sender, EventArgs e)
        {
            PacienteFotoTomar pacienteFotoTomar = new PacienteFotoTomar(_pacienteId);
            pacienteFotoTomar.ShowDialog();
            MuestraFoto();
        }

        private void pagRecetasUsuario_Enter(object sender, EventArgs e)
        {
            txtRecetaGuardadaDoctor.BackColor = Color.White;
            txtRecetaGuardadaDoctor.ForeColor = Color.Black;

            txtEtiquetasGuardadasDoctor.BackColor = Color.White;
            txtEtiquetasGuardadasDoctor.ForeColor = Color.Black;

            CargaRecetas(2);

        }

        private void cmdFiltrarRecetasDoctor_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBuscarRecetasDoctor.Text))
            {
                MessageBox.Show("Indique el texto a buscar", "Confime", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            CargaRecetas(4);

        }

        private void cmdQuitarFiltroRecetasDoctor_Click(object sender, EventArgs e)
        {
            CargaRecetas(2);
        }

        private void cmdPasarARecetaDoctor_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRecetaGuardadaDoctor.Text) && string.IsNullOrEmpty(txtEtiquetasGuardadasDoctor.Text))
                return;

            if (string.IsNullOrEmpty(txtRecetaGuardadaDoctor.Text) == false)
                txtTexto.Text = txtRecetaGuardadaDoctor.Text;


            if (string.IsNullOrEmpty(txtEtiquetasGuardadasDoctor.Text) == false)
                txtEtiquetas.Text = txtEtiquetasGuardadasDoctor.Text;

            txtTexto.Focus();
            tabPaciente.SelectedIndex = 2;

        }

        private void cmdBorrarRecetaDoctor_Click(object sender, EventArgs e)
        {
            if (grdRecetasDoctor.CurrentRow == null)
            {
                MessageBox.Show("Indique la receta que desea borrar", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("¿Desea borrar la receta?", "Confirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            using (FbConnection db = General.GetDB())
            {
                int recetaId = _listRecetas[grdRecetasDoctor.CurrentRow.Index].PacienteRecetaId;
                string sql = Queries.RecetaPacienteDelete();
                db.Execute(sql, new { PacienteRecetaId = recetaId });
                CargaRecetas(2);
                txtRecetaGuardadaDoctor.Text = "";
                txtEtiquetasGuardadasDoctor.Text = "";
            }

        }

        private void grdRecetasDoctor_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int ren = e.RowIndex;
            txtRecetaGuardadaDoctor.Text = _listRecetas[ren].Texto;
            txtEtiquetasGuardadasDoctor.Text = _listRecetas[ren].Etiquetas;

        }

        private void cmdImprimirReceta_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTexto.Text))
            {
                MessageBox.Show("Indique el texto de la receta","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }


            string dir = General.PacienteDireccion(_pacienteId);

            RecetaDatos resDat = new RecetaDatos();

            Doctor doc = General.GetDoctorXUsuario((int)Properties.Settings.Default.Usuario_ID);
            if (doc != null)
            {
                resDat.DoctorNombre = doc.NombreCompleto;
                resDat.DoctorCV = doc.Curriculum;
                resDat.DoctorCedulaProf = doc.CedProf;
                resDat.DoctorCedulaEsp = doc.CedEsp;


            }



            resDat.Fecha = DateTime.Now.ToShortDateString();
            resDat.PacienteNombre = lblNombrePaciente.Text;
            resDat.PacienteEdad= txtEdad.Text;
            resDat.PacienteDireccion = dir;
            resDat.Indicaciones = txtTexto.Text;

            string carpetaReportes = General.GetCarpetaReportes();

            List<RecetaDatos> datosReceta = new List<RecetaDatos>();
            datosReceta.Add(resDat);

            List<ReportDataSource> reportDataSources = new List<ReportDataSource>();

            reportDataSources.Add
                (new ReportDataSource { Name = "dsReceta", Value = datosReceta }
                );


            PreVerReporte reporte = new PreVerReporte($@"{carpetaReportes}\Recetas\RecetaFormato.rdlc", reportDataSources, "Receta",true);
            reporte.ShowDialog();




        }
    }
}
