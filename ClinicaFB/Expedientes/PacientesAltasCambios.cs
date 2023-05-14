using System.Collections.ObjectModel;

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
using ClinicaFB.Modelo;
using ClinicaFB.Helpers;
using Syncfusion.Windows.Forms.Tools;
using Syncfusion.WinForms.DataGrid;
using System.Diagnostics;
using ClinicaFB.Reportes;
using Microsoft.Reporting.WinForms;
using ClinicaFB.ModeloConfiguracion;
using Syncfusion.Windows.Forms.Grid;
using System.IO;

namespace ClinicaFB.Expedientes
{
    public partial class PacientesAltasCambios : Form
    {
        public int PacienteID = 0;
        private bool _esAlta = false;
        private Paciente _paciente = null;
        ObservableCollection<Nota> notas = new ObservableCollection<Nota>();
        BindingList<Receta> _listRecetas = new BindingList<Receta>();
        BindingList<PacientesImagenes> _PacienteImagenes = new BindingList<PacientesImagenes>();

        public PacientesAltasCambios(bool esAlta, int pacienteId)
        {
            _esAlta = esAlta;
            PacienteID = pacienteId;
            InitializeComponent();
        }

        private void PacientesAltasCambios_Load(object sender, EventArgs e)
        {
            SetCombos();

            if (_esAlta)
            {
                _paciente = new Paciente();
                Text = "Agregar paciente";
                cboSexos.SelectedIndex = 1;
            }
            else
            {
                Text = "Modificar paciente";
                CargaPaciente();
            }
            cboOrigen.SelectedValue = "AC2";


        }


        private void MuestraNombre()
        {
            lblNombrePaciente.Text = $"{txtNombre.Text.Trim()} {txtApellidoPaterno.Text.Trim()} {txtApellidoMaterno.Text.Trim()}";
        }

        private void MuestraEdad()
        {
            txtEdad.Text = General.calculaEdad(dtpFechaNacimiento.Value).ToString()+" años";

        }

        private void SetCombos()
        {
            General.ConfiguraCombo(ref cboEstadosCiviles, "EDC");
            General.ConfiguraCombo(ref cboOcupaciones, "OCU");
            General.ConfiguraCombo(ref cboReferentes, "REF");
            General.ConfiguraCombo(ref cboCiudadesOrigen, "CIU");
            General.ConfiguraCombo(ref cboLocalidades, "LOC");
            General.ConfiguraCombo(ref cboCiudades, "CIU");
            General.ConfiguraCombo(ref cboEstados, "EDO");
            General.ConfiguraCombo(ref cboPaises, "PAI");
            General.ConfiguraCombo(ref cboDiagnosticos, "DIA");
            General.ConfiguraCombo(ref cboColoresDePiel, "PIE");
            General.ConfiguraCombo(ref cboExposicionesSolares, "EXS");
            General.ConfiguraCombo(ref cboMedicos, "MED");
            General.ConfiguraCombo(ref cboMaquillajes, "MAQ");

        }



        private void CargaPaciente()
        {



            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.PacienteSelect();
                _paciente = db.QuerySingleOrDefault<Paciente>(sql, new { Paciente_Id = PacienteID });

                if (_paciente != null)
                {
                    PropiedadesAControles();
                    MuestraNombre();
                    MuestraEdad();

                }


            }

        }


        private void PropiedadesAControles()
        {
            txtNombre.Text = _paciente.Nombres;
            txtApellidoPaterno.Text = _paciente.Apellido_Paterno;
            txtApellidoMaterno.Text = _paciente.Apellido_Materno;
            txtTelefonos.Text = _paciente.Telefonos;
            txtCorreos.Text = _paciente.Correos;

            switch (_paciente.Sexo)
            {
                case "F":
                    cboSexos.SelectedIndex = 0;
                    break;
                case "M":
                    cboSexos.SelectedIndex = 1;
                    break;
                case "O":
                    cboSexos.SelectedIndex = 2;
                    break;

            }

            if (_paciente.Fecha_Nacimiento.Year>=dtpFechaNacimiento.MinDate.Year)
                dtpFechaNacimiento.Value = _paciente.Fecha_Nacimiento;


            cboEstadosCiviles.SelectedValue = _paciente.EdoCivilId;
            cboOcupaciones.SelectedValue = _paciente.OcupacionId;
            cboReferentes.SelectedValue = _paciente.ReferenteId;

            cboCiudadesOrigen.SelectedValue = _paciente.CiudadOrigenId;
            txtDireccion.Text=_paciente.Direccion;
            txtColonia.Text= _paciente.Colonia;
            cboLocalidades.SelectedValue = _paciente.LocalidadId;
            cboCiudades.SelectedValue = _paciente.CiudadId;
            cboEstados.SelectedValue = _paciente.EstadoId;
            cboPaises.SelectedValue = _paciente.PaisId;
            txtCP.Text= _paciente.CP;
            cboDiagnosticos.SelectedValue = _paciente.DiagnosticoId;
            cboColoresDePiel.SelectedValue = _paciente.PielId;
            cboExposicionesSolares.SelectedValue = _paciente.SolarId;
            cboMedicos.SelectedValue = _paciente.MedicoId;
            cboMaquillajes.SelectedValue = _paciente.MaquillajeId;
            txtMedicamentos.Text = _paciente.Medicamentos;
            txtAlergias.Text = _paciente.Alergias;
            txtAntecedentes.Text = _paciente.Antecedentes;
            cboOrigen.Text = _paciente.Origen;



        }


        private void ControlesAPropiedades()
        {
            _paciente.Nombres = txtNombre.Text;
            _paciente.Apellido_Paterno = txtApellidoPaterno.Text;
            _paciente.Apellido_Materno = txtApellidoMaterno.Text;
            _paciente.Telefonos = txtTelefonos.Text;
            _paciente.Correos = txtCorreos.Text;

            switch (cboSexos.SelectedIndex)
            {
                case 0:
                    _paciente.Sexo = "F";
                    break;
                case 1:
                    _paciente.Sexo = "M";
                    break;
                case 2:
                    _paciente.Sexo = "O";

                    break;

            }

            _paciente.Fecha_Nacimiento = dtpFechaNacimiento.Value;
            _paciente.EdoCivilId = General.DevuelveValorCombo(cboEstadosCiviles, "EDC");
            _paciente.OcupacionId = General.DevuelveValorCombo(cboOcupaciones, "OCU");
            _paciente.ReferenteId = General.DevuelveValorCombo(cboReferentes, "REF");
            _paciente.CiudadOrigenId = General.DevuelveValorCombo(cboCiudadesOrigen, "CIU");
            _paciente.Direccion = txtDireccion.Text;
            _paciente.Colonia = txtColonia.Text;
            _paciente.LocalidadId = General.DevuelveValorCombo(cboLocalidades, "LOC");
            _paciente.CiudadId = General.DevuelveValorCombo(cboCiudades, "CIU");
            _paciente.EstadoId = General.DevuelveValorCombo(cboEstados, "EDO");
            _paciente.PaisId= General.DevuelveValorCombo(cboPaises, "PAI");
            _paciente.CP = txtCP.Text;
            _paciente.DiagnosticoId = General.DevuelveValorCombo(cboDiagnosticos, "DIA");
            _paciente.PielId = General.DevuelveValorCombo(cboColoresDePiel, "PIE");
            _paciente.SolarId = General.DevuelveValorCombo(cboExposicionesSolares, "EXS");
            _paciente.MedicoId = General.DevuelveValorCombo(cboMedicos, "MED");
            _paciente.MaquillajeId = General.DevuelveValorCombo(cboMaquillajes, "MAQ");


            _paciente.Medicamentos= txtMedicamentos.Text;
            _paciente.Alergias= txtAlergias.Text;
            _paciente.Antecedentes= txtAntecedentes.Text;
            _paciente.Origen = cboOrigen.Text;



        }







        private void cmdGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidaDatos())
                return;

            ControlesAPropiedades();
            string sql = _esAlta ? Queries.PacienteInsert() : Queries.PacienteUpdate();

            using (FbConnection db = General.GetDB())
            {
                if (_esAlta)
                    PacienteID = db.QuerySingle<int>(sql, _paciente);
                else
                    db.Execute(sql, _paciente);

            }
            Close();

        }

        private bool ValidaDatos()
        {
            bool esValido = true;
            string cadenaErrores = "";


            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                cadenaErrores += "*Teclee el nombre";
                esValido = false;

            }


            if (string.IsNullOrEmpty(txtApellidoPaterno.Text))
            {
                cadenaErrores = cadenaErrores == string.Empty ? "" : cadenaErrores+="\n";
                cadenaErrores += "*Teclee el apellido paterno";
                esValido = false;

            }


            if (string.IsNullOrEmpty(txtTelefonos.Text))
            {
                cadenaErrores = cadenaErrores == string.Empty ? "" : cadenaErrores += "\n";
                cadenaErrores += "*Teclee el teléfono";
                //esValido = false;

            }

            if (esValido == false)
            {
                MessageBox.Show(cadenaErrores, "Confirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return esValido;
        }

        private void cmdSalir_Click(object sender, EventArgs e)
        {
            if (_esAlta && string.IsNullOrEmpty(lblNombrePaciente.Text))
            {
                Close();
                return;
            }

            if (ValidaDatos() == false)
            {

                return;
            }
            GuardaDatos();
            Close();
        }

        private void txtEstadoCivil_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(cboEstadosCiviles.SelectedIndex.ToString());
        }

        private void dtpFechaNacimiento_ValueChanged(object sender, EventArgs e)
        {
            MuestraEdad();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            MuestraNombre();
        }

        private void txtApellidoPaterno_TextChanged(object sender, EventArgs e)
        {
            MuestraNombre();

        }

        private void txtApellidoMaterno_TextChanged(object sender, EventArgs e)
        {
            MuestraNombre();

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void cboEstadosCiviles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboLocalidades_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void lblNombrePaciente_Click(object sender, EventArgs e)
        {

        }


        private void pagNotas_Enter(object sender, EventArgs e)
        {

            if (!ValidaDatos())
            {
                tabPaciente.SelectTab(0);
                return;

            }

            GuardaDatos();
            CargaNotas();
        }
        private void CargaNotas()
        {


            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.PacientesNotas();
                var resultado = db.Query<Nota>(sql, new {PacienteId = _paciente.Paciente_Id});
                notas = new ObservableCollection<Nota>(resultado);

            }

            grdNotas.DataSource = notas;
        }

        private void grdNotas_QueryRowHeight(object sender, Syncfusion.WinForms.DataGrid.Events.QueryRowHeightEventArgs e)
        {
            RowAutoFitOptions autoFitOptions = new RowAutoFitOptions();
            int autoHeight=0;
            if (grdNotas.AutoSizeController.GetAutoRowHeight(e.RowIndex, autoFitOptions, out autoHeight))
            {
                if (autoHeight > 24)
                {
                    e.Height = autoHeight+10;
                    e.Handled = true;
                }
            }
        }

        private void grdNotas_CurrentCellEndEdit(object sender, Syncfusion.WinForms.DataGrid.Events.CurrentCellEndEditEventArgs e)
        {
            grdNotas.InvalidateRowHeight(e.DataRow.RowIndex);
            grdNotas.TableControl.Invalidate();

        }

        private void grdNotas_CurrentCellKeyPress(object sender, Syncfusion.WinForms.DataGrid.Events.CurrentCellKeyPressEventArgs e)
        {
            grdNotas.InvalidateRowHeight(e.RowIndex);
            grdNotas.TableControl.Invalidate();

        }

        private void PacientesAltasCambios_FormClosing(object sender, FormClosingEventArgs e)
        {
                
        }
        private bool GuardaDatos()
        {                

            ControlesAPropiedades();
            string sql = _esAlta ? Queries.PacienteInsert() : Queries.PacienteUpdate();

            using (FbConnection db = General.GetDB())
            {
                if (_esAlta)
                {
                    _paciente.UsuarioCreacionId = (int)ClinicaFB.Properties.Settings.Default.Usuario_ID;
                    _paciente.FechaHoraCreacion = DateTime.Now;

                    PacienteID = db.QuerySingle<int>(sql, _paciente);

                    _esAlta = false;
                }
                else
                {
                    _paciente.UsuarioEdicionId = (int)ClinicaFB.Properties.Settings.Default.Usuario_ID;
                    _paciente.FechaHoraEdicion = DateTime.Now;

                    db.Execute(sql, _paciente);

                }

            }
            return true;

        }


        private void notaCapturar(bool esAlta)
        {

            int rowIndex = grdNotas.SelectionController.DataGrid.CurrentCell.RowIndex;
            int notaId=0;


            if (esAlta == false)
            {
                notaId = (int)notas[rowIndex - 1].NotaId;


            }

            NotaEditar notaEditar = new NotaEditar(PacienteID, esAlta, notaId);

            notaEditar.ShowDialog();
            CargaNotas();

            /*return;

            if (esAlta)
                
            {
                notaEditar.txtNota.Text = "";

            }
            else
            {
                rowIndex = grdNotas.SelectionController.DataGrid.CurrentCell.RowIndex;
                var recordIndex = grdNotas.TableControl.ResolveToRecordIndex(rowIndex);
                string cellValue = DataGridHelper.GetCellValue(grdNotas, recordIndex, 1).ToString();
                notaEditar.txtNota.Text = cellValue;
            }




            if (esAlta && string.IsNullOrEmpty(notaEditar.txtNota.Text))
                return;


            string sql = "";
            Nota currentNota;

            grdNotas.View.BeginInit();

            if (esAlta)
            {

                currentNota = new Nota();
                currentNota.PacienteId = PacienteID;
                currentNota.Fecha = DateTime.Now;
                currentNota.Texto = notaEditar.txtNota.Text;
                currentNota.UsuarioCreacionId = (int)ClinicaFB.Properties.Settings.Default.Usuario_ID;
                currentNota.FechaHoraCreacion = DateTime.Now;



                sql = Queries.NotaInsert();


                using (FbConnection db = General.GetDB())
                {
                    db.Execute(sql, currentNota);
                }

                notas.Insert(0, currentNota);

            }
            else
            {
                int id = (int) notas[rowIndex-1].NotaId;
                sql = Queries.NotaUpdate();


                using (FbConnection db = General.GetDB())
                {
                    db.Execute(sql, 
                        new { 
                            Texto = notaEditar.txtNota.Text, 
                            NotaId = id,
                            UsuarioEdicionId = (int)ClinicaFB.Properties.Settings.Default.Usuario_ID,
                            FechaHoraEdicion = DateTime.Now

                    });

                }
                notas[rowIndex - 1].Texto = notaEditar.txtNota.Text;



            }
            grdNotas.View.EndInit();
            grdNotas.View.Refresh();*/






        }
        private void cmdAgregar_Click(object sender, EventArgs e)
        {
            notaCapturar(true);
        }

        private void pagDermatologia_Enter(object sender, EventArgs e)
        {
            if (!ValidaDatos())
            {
                tabPaciente.SelectTab(0);
                return;

            }
            GuardaDatos();
        }

        private void grdNotas_CellDoubleClick(object sender, Syncfusion.WinForms.DataGrid.Events.CellClickEventArgs e)
        {

            if (SinRenglon())
                return;

            notaCapturar(false);
            
            
        }

        private void cmdBorrar_Click(object sender, EventArgs e)
        {

            if (SinRenglon())
                return;

            DialogResult SiNo = MessageBox.Show("¿Desea borrar la nota?","Confirme",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

            if (SiNo == DialogResult.No)
                return;

            int rowIndex = grdNotas.SelectionController.DataGrid.CurrentCell.RowIndex;
            int notaId = (int) notas[rowIndex-1].NotaId;
            string sql = Queries.NotaDelete();

            using (FbConnection db = General.GetDB())
            {
                db.Execute(sql, new { NotaId = notaId});
            }

            grdNotas.View.BeginInit();

            notas.RemoveAt(rowIndex-1);

            grdNotas.View.EndInit();
            grdNotas.View.Refresh();




        }

        private bool SinRenglon()
        {
            bool norow = false;
            if (grdNotas.SelectionController.DataGrid.CurrentCell.ColumnIndex == -1 || grdNotas.SelectionController.DataGrid.CurrentCell.RowIndex < 1)
                norow = true;

            return norow;
        }

        private void pagNotas_Click(object sender, EventArgs e)
        {

        }

        private void pagDatosAct_Enter(object sender, EventArgs e)
        {
            if (!ValidaDatos())
            {
                tabPaciente.SelectTab(0);
                return;

            }

            GuardaDatos();

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.ActDatosSelect();
                ActDatos actDatos = db.QueryFirstOrDefault<ActDatos>(sql, new {PacienteId = PacienteID });
                if (actDatos == null)
                    return;
                txtActPrefijo.Text = actDatos.Prefijo;
                txtActSaludo.Text =actDatos.Saludo;
                txtActCategoria.Text =actDatos.Categoria;
                txtActTitulo.Text =actDatos.Titulo;
                txtActEstadoCivil.Text =actDatos.EstadoCivil;
                txtActSexo.Text =actDatos.Sexo;
                txtActCiudadOrigen.Text =actDatos.CiudadOrigen;
                txtActAlergias1.Text=actDatos.Alergias1;
                txtActAlergias2.Text=actDatos.Alergias2;
                txtActMedico.Text =actDatos.Medico;
                txtActTipoPiel.Text =actDatos.TipoPiel;
                txtActMedicamentos.Text = actDatos.Medicamentos;
                txtActMaquillaje.Text =actDatos.Maquillaje;
                txtActTxPrevio.Text =actDatos.TxPrevio;
                txtActEdad.Text =actDatos.Edad;
                txtActEnfer1.Text = actDatos.Enfer1;
                txtActEnfer2.Text =actDatos.Enfer2;
                txtActEnfer3.Text =actDatos.Enfer3;
                txtActEnfer4.Text =actDatos.Enfer4;
                txtActEnfer5.Text =actDatos.Enfer5;
                txtActEnfer6.Text =actDatos.Enfer6;
                txtActEnfer7.Text =actDatos.Enfer7;
                txtActEnfer8.Text =actDatos.Enfer8;
                txtActEnfer9.Text =actDatos.Enfer9;
                txtActTelefono.Text =actDatos.Telefono;
                txtActRFC.Text =actDatos.RFC;
                txtActCURP.Text=actDatos.CURP;
                txtActDir1.Text=actDatos.Dir1;
                txtActDir2.Text=actDatos.Dir2;
                txtActDir3.Text=actDatos.Dir3;
                txtActCiudad.Text=actDatos.Ciudad;
                txtActEstado.Text=actDatos.Estado;
                txtActCodigoPostal.Text = actDatos.CP;
                txtActPais.Text=actDatos.Pais;



            }

        }

        private void cmdimprimirExpediente_Click(object sender, EventArgs e)
        {
            if (ValidaDatos() == false)
                return;

            GuardaDatos();


            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = @"C:\ClinicaFB\ImprimeFB.exe";
            startInfo.Arguments = PacienteID.ToString();

            Process.Start(startInfo);
        }

        private void cmdReporteExpediente_Click(object sender, EventArgs e)
        {
        }

        private void pagGenerales_Click(object sender, EventArgs e)
        {

        }

        private void pagRecetas_Enter(object sender, EventArgs e)
        {
            if (!ValidaDatos())
            {
                tabPaciente.SelectTab(0);
                return;

            }

            GuardaDatos();
            CargaRecetas();

        }
        private void CargaRecetas()
        {


            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.RecetasPacienteSelect();
                var res = db.Query<Receta>(sql, new { Pacienteid = PacienteID }).ToList();

                _listRecetas = new BindingList<Receta>(res);
            }

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

        private void grdRecetas_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int ren = e.RowIndex;
            txtRecetaGuardada.Text = _listRecetas[ren].Texto;

        }

        private void PacientesAltasCambios_Leave(object sender, EventArgs e)
        {
            MessageBox.Show("deactivar");
        }

        private void pagDermatologia_Click(object sender, EventArgs e)
        {

        }

        private void cmdImprimirExpedienteRDLC_Click(object sender, EventArgs e)
        {
            GuardaDatos();
            string carpetaReportes = "";
            using (FbConnection db = General.GetConexionConfig())
            {
                string sql = Queries.EmpresaSelect();
                Empresa emp = db.Query<Empresa>(sql, new { Empresa_Id = Properties.Settings.Default.Empresa_ID }).FirstOrDefault();
                carpetaReportes = emp.CarpetaReportes;
            }

            List<DatosExpediente> datosExpediente = new List<DatosExpediente>();

            using (FbConnection db = General.GetDB())
            {
                string sql = Queries.PacienteReporteExpedienteSelect();
                datosExpediente = db.Query<DatosExpediente>(sql, new { PacienteId = _paciente.Paciente_Id }).ToList();
            }

            datosExpediente[0].Edad = General.calculaEdad(datosExpediente[0].Fecha_Nacimiento).ToString()+" años";


            CargaNotas();
            List<ReportDataSource> reportDataSources = new List<ReportDataSource>();
            reportDataSources.Add
                (new ReportDataSource { Name = "dsDatosGenerales", Value = datosExpediente }
                );

            reportDataSources.Add
                ( new ReportDataSource { Name ="dsNotas",Value = notas }
                );
             //ReportDataSource reportDataSource = new ReportDataSource("dsNotas", notas);

            PreVerReporte reporte = new PreVerReporte($@"{carpetaReportes}\Expedientes\Expediente.rdlc", reportDataSources,"Expediente");
            reporte.ShowDialog();

        }

        private void pagImagenes_Enter(object sender, EventArgs e)
        {
            if (!ValidaDatos())
            {
                tabPaciente.SelectTab(0);
                return;

            }

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
                var res = db.Query<PacientesImagenes>(sql, new {PacienteId= _paciente.Paciente_Id}).ToList();

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

            //grdImagenes.ColumnCount = 4;

            //grdImagenes.RowHeadersVisible = true;


            //grdImagenes.ColumnHeadersDefaultCellStyle.Font = new Font(grdImagenes.ColumnHeadersDefaultCellStyle.Font, FontStyle.Bold);
            //grdImagenes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //grdImagenes.Columns[0].HeaderText = "Nombre";

            //grdImagenes.Columns[0].DataPropertyName = "NombreCompleto";
            //grdImagenes.Columns[0].Width = 300;

            //grdImagenes.Columns[1].HeaderText = "Teléfonos";
            //grdImagenes.Columns[1].DataPropertyName = "Telefonos";
            //grdImagenes.Columns[1].Width = 180;

            //grdImagenes.Columns[2].HeaderText = "Correos";
            //grdImagenes.Columns[2].DataPropertyName = "Correos";
            //grdImagenes.Columns[2].Width = 180;

            //grdImagenes.Columns[3].HeaderText = "Ubicación";
            //grdImagenes.Columns[3].DataPropertyName = "Ubicacion";
            //grdImagenes.Columns[3].Width = 80;

            grdImagenes.DataSource = _PacienteImagenes;

        }


        private void ImagenesAltasCambios(bool esAlta)
        {
            int id = 0;

            if (esAlta == false)
            {
                id = _PacienteImagenes[grdImagenes.CurrentRow.Index].PacImId;
            }
            ImagenAltasCambios imagenAltasCambios = new ImagenAltasCambios(id,(int) _paciente.Paciente_Id, esAlta);
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
                MessageBox.Show("Indique la imagen a modificar","Aviso",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ImagenesAltasCambios(false);

        }

        private void pagImagenes_Click(object sender, EventArgs e)
        {

        }
    }
}
