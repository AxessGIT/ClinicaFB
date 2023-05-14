namespace ClinicaFB.Configuracion.Facturacion
{
    partial class EmisoresAltasCambios
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmisoresAltasCambios));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabEmisores = new System.Windows.Forms.TabControl();
            this.pagGenerales = new System.Windows.Forms.TabPage();
            this.txtRegimenFiscal = new System.Windows.Forms.TextBox();
            this.cmdCveRefBuscar = new System.Windows.Forms.Button();
            this.txtCveRef = new System.Windows.Forms.TextBox();
            this.cboPaises = new Syncfusion.WinForms.ListView.SfComboBox();
            this.cboEstados = new Syncfusion.WinForms.ListView.SfComboBox();
            this.cboCiudades = new Syncfusion.WinForms.ListView.SfComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtCP = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtColonia = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtRFC = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pagSeries = new System.Windows.Forms.TabPage();
            this.cmdModificarConcepto = new System.Windows.Forms.Button();
            this.cmdBorrarConcepto = new System.Windows.Forms.Button();
            this.cmdAgregarConcepto = new System.Windows.Forms.Button();
            this.grdConceptos = new System.Windows.Forms.DataGridView();
            this.label13 = new System.Windows.Forms.Label();
            this.cmdSerieEliminar = new System.Windows.Forms.Button();
            this.cmdSerieModificar = new System.Windows.Forms.Button();
            this.cmdSerieAgregar = new System.Windows.Forms.Button();
            this.grdSeries = new System.Windows.Forms.DataGridView();
            this.colSerie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFolio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActiva = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDefault = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pagCertificados = new System.Windows.Forms.TabPage();
            this.cmdMuestraPassWord = new System.Windows.Forms.Button();
            this.cmdBuscarLlavePrivada = new System.Windows.Forms.Button();
            this.cmdBuscarCertificado = new System.Windows.Forms.Button();
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.txtLlavePrivada = new System.Windows.Forms.TextBox();
            this.txtCertificado = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.cmdSalir = new System.Windows.Forms.Button();
            this.cmdGuardar = new System.Windows.Forms.Button();
            this.colClave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPorceRetIVA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRetISR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAgregarNombre = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tabEmisores.SuspendLayout();
            this.pagGenerales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPaises)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEstados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCiudades)).BeginInit();
            this.pagSeries.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdConceptos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSeries)).BeginInit();
            this.pagCertificados.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabEmisores
            // 
            this.tabEmisores.Controls.Add(this.pagGenerales);
            this.tabEmisores.Controls.Add(this.pagSeries);
            this.tabEmisores.Controls.Add(this.pagCertificados);
            this.tabEmisores.Location = new System.Drawing.Point(12, 20);
            this.tabEmisores.Name = "tabEmisores";
            this.tabEmisores.SelectedIndex = 0;
            this.tabEmisores.Size = new System.Drawing.Size(1035, 397);
            this.tabEmisores.TabIndex = 31;
            // 
            // pagGenerales
            // 
            this.pagGenerales.Controls.Add(this.txtRegimenFiscal);
            this.pagGenerales.Controls.Add(this.cmdCveRefBuscar);
            this.pagGenerales.Controls.Add(this.txtCveRef);
            this.pagGenerales.Controls.Add(this.cboPaises);
            this.pagGenerales.Controls.Add(this.cboEstados);
            this.pagGenerales.Controls.Add(this.cboCiudades);
            this.pagGenerales.Controls.Add(this.label12);
            this.pagGenerales.Controls.Add(this.txtCP);
            this.pagGenerales.Controls.Add(this.label11);
            this.pagGenerales.Controls.Add(this.label8);
            this.pagGenerales.Controls.Add(this.label7);
            this.pagGenerales.Controls.Add(this.txtColonia);
            this.pagGenerales.Controls.Add(this.txtDireccion);
            this.pagGenerales.Controls.Add(this.txtNombre);
            this.pagGenerales.Controls.Add(this.txtRFC);
            this.pagGenerales.Controls.Add(this.label5);
            this.pagGenerales.Controls.Add(this.label4);
            this.pagGenerales.Controls.Add(this.label3);
            this.pagGenerales.Controls.Add(this.label2);
            this.pagGenerales.Controls.Add(this.label1);
            this.pagGenerales.Location = new System.Drawing.Point(4, 25);
            this.pagGenerales.Name = "pagGenerales";
            this.pagGenerales.Padding = new System.Windows.Forms.Padding(3);
            this.pagGenerales.Size = new System.Drawing.Size(1027, 368);
            this.pagGenerales.TabIndex = 0;
            this.pagGenerales.Text = "Generales";
            this.pagGenerales.UseVisualStyleBackColor = true;
            // 
            // txtRegimenFiscal
            // 
            this.txtRegimenFiscal.Location = new System.Drawing.Point(281, 284);
            this.txtRegimenFiscal.Name = "txtRegimenFiscal";
            this.txtRegimenFiscal.ReadOnly = true;
            this.txtRegimenFiscal.Size = new System.Drawing.Size(288, 23);
            this.txtRegimenFiscal.TabIndex = 61;
            // 
            // cmdCveRefBuscar
            // 
            this.cmdCveRefBuscar.Location = new System.Drawing.Point(244, 284);
            this.cmdCveRefBuscar.Name = "cmdCveRefBuscar";
            this.cmdCveRefBuscar.Size = new System.Drawing.Size(31, 23);
            this.cmdCveRefBuscar.TabIndex = 57;
            this.cmdCveRefBuscar.Text = "...";
            this.cmdCveRefBuscar.UseVisualStyleBackColor = true;
            this.cmdCveRefBuscar.Click += new System.EventHandler(this.cmdCveRefBuscar_Click);
            // 
            // txtCveRef
            // 
            this.txtCveRef.Location = new System.Drawing.Point(129, 284);
            this.txtCveRef.Name = "txtCveRef";
            this.txtCveRef.Size = new System.Drawing.Size(109, 23);
            this.txtCveRef.TabIndex = 48;
            this.txtCveRef.Validated += new System.EventHandler(this.txtCveRef_Validated);
            // 
            // cboPaises
            // 
            this.cboPaises.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboPaises.AutoCompleteSuggestMode = Syncfusion.WinForms.ListView.Enums.AutoCompleteSuggestMode.Contains;
            this.cboPaises.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.cboPaises.Location = new System.Drawing.Point(129, 221);
            this.cboPaises.Name = "cboPaises";
            this.cboPaises.Size = new System.Drawing.Size(234, 28);
            this.cboPaises.Style.DropDownStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cboPaises.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboPaises.TabIndex = 44;
            // 
            // cboEstados
            // 
            this.cboEstados.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboEstados.AutoCompleteSuggestMode = Syncfusion.WinForms.ListView.Enums.AutoCompleteSuggestMode.Contains;
            this.cboEstados.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.cboEstados.Location = new System.Drawing.Point(129, 187);
            this.cboEstados.Name = "cboEstados";
            this.cboEstados.Size = new System.Drawing.Size(234, 28);
            this.cboEstados.Style.DropDownStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cboEstados.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboEstados.TabIndex = 42;
            // 
            // cboCiudades
            // 
            this.cboCiudades.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCiudades.AutoCompleteSuggestMode = Syncfusion.WinForms.ListView.Enums.AutoCompleteSuggestMode.Contains;
            this.cboCiudades.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.cboCiudades.Location = new System.Drawing.Point(129, 153);
            this.cboCiudades.Name = "cboCiudades";
            this.cboCiudades.Size = new System.Drawing.Size(234, 28);
            this.cboCiudades.Style.DropDownStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cboCiudades.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboCiudades.TabIndex = 40;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(29, 287);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 16);
            this.label12.TabIndex = 47;
            this.label12.Text = "Régimen fiscal";
            // 
            // txtCP
            // 
            this.txtCP.Location = new System.Drawing.Point(129, 255);
            this.txtCP.Name = "txtCP";
            this.txtCP.Size = new System.Drawing.Size(82, 23);
            this.txtCP.TabIndex = 46;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(89, 258);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 16);
            this.label11.TabIndex = 45;
            this.label11.Text = "C.P.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(89, 227);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 16);
            this.label8.TabIndex = 43;
            this.label8.Text = "País";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(74, 193);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 16);
            this.label7.TabIndex = 41;
            this.label7.Text = "Estado";
            // 
            // txtColonia
            // 
            this.txtColonia.Location = new System.Drawing.Point(129, 124);
            this.txtColonia.Name = "txtColonia";
            this.txtColonia.Size = new System.Drawing.Size(440, 23);
            this.txtColonia.TabIndex = 38;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(129, 95);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(440, 23);
            this.txtDireccion.TabIndex = 36;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(129, 66);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(440, 23);
            this.txtNombre.TabIndex = 34;
            // 
            // txtRFC
            // 
            this.txtRFC.Location = new System.Drawing.Point(129, 37);
            this.txtRFC.Name = "txtRFC";
            this.txtRFC.Size = new System.Drawing.Size(150, 23);
            this.txtRFC.TabIndex = 32;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(73, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 16);
            this.label5.TabIndex = 39;
            this.label5.Text = "Ciudad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(70, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 16);
            this.label4.TabIndex = 37;
            this.label4.Text = "Colonia";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 16);
            this.label3.TabIndex = 35;
            this.label3.Text = "Dirección";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 33;
            this.label2.Text = "Nombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 16);
            this.label1.TabIndex = 31;
            this.label1.Text = "RFC";
            // 
            // pagSeries
            // 
            this.pagSeries.Controls.Add(this.cmdModificarConcepto);
            this.pagSeries.Controls.Add(this.cmdBorrarConcepto);
            this.pagSeries.Controls.Add(this.cmdAgregarConcepto);
            this.pagSeries.Controls.Add(this.grdConceptos);
            this.pagSeries.Controls.Add(this.label13);
            this.pagSeries.Controls.Add(this.cmdSerieEliminar);
            this.pagSeries.Controls.Add(this.cmdSerieModificar);
            this.pagSeries.Controls.Add(this.cmdSerieAgregar);
            this.pagSeries.Controls.Add(this.grdSeries);
            this.pagSeries.Location = new System.Drawing.Point(4, 25);
            this.pagSeries.Name = "pagSeries";
            this.pagSeries.Padding = new System.Windows.Forms.Padding(3);
            this.pagSeries.Size = new System.Drawing.Size(1027, 368);
            this.pagSeries.TabIndex = 1;
            this.pagSeries.Text = "Series facturas";
            this.pagSeries.UseVisualStyleBackColor = true;
            this.pagSeries.Enter += new System.EventHandler(this.pagSeries_Enter);
            // 
            // cmdModificarConcepto
            // 
            this.cmdModificarConcepto.Image = ((System.Drawing.Image)(resources.GetObject("cmdModificarConcepto.Image")));
            this.cmdModificarConcepto.Location = new System.Drawing.Point(945, 43);
            this.cmdModificarConcepto.Name = "cmdModificarConcepto";
            this.cmdModificarConcepto.Size = new System.Drawing.Size(35, 35);
            this.cmdModificarConcepto.TabIndex = 22;
            this.toolTip.SetToolTip(this.cmdModificarConcepto, "Agregar serie");
            this.cmdModificarConcepto.UseVisualStyleBackColor = true;
            this.cmdModificarConcepto.Click += new System.EventHandler(this.cmdModificarConcepto_Click);
            // 
            // cmdBorrarConcepto
            // 
            this.cmdBorrarConcepto.Image = ((System.Drawing.Image)(resources.GetObject("cmdBorrarConcepto.Image")));
            this.cmdBorrarConcepto.Location = new System.Drawing.Point(986, 43);
            this.cmdBorrarConcepto.Name = "cmdBorrarConcepto";
            this.cmdBorrarConcepto.Size = new System.Drawing.Size(35, 35);
            this.cmdBorrarConcepto.TabIndex = 21;
            this.toolTip.SetToolTip(this.cmdBorrarConcepto, "Borrar serie");
            this.cmdBorrarConcepto.UseVisualStyleBackColor = true;
            this.cmdBorrarConcepto.Click += new System.EventHandler(this.cmdBorrarConcepto_Click);
            // 
            // cmdAgregarConcepto
            // 
            this.cmdAgregarConcepto.Image = ((System.Drawing.Image)(resources.GetObject("cmdAgregarConcepto.Image")));
            this.cmdAgregarConcepto.Location = new System.Drawing.Point(905, 43);
            this.cmdAgregarConcepto.Name = "cmdAgregarConcepto";
            this.cmdAgregarConcepto.Size = new System.Drawing.Size(35, 35);
            this.cmdAgregarConcepto.TabIndex = 19;
            this.toolTip.SetToolTip(this.cmdAgregarConcepto, "Agregar serie");
            this.cmdAgregarConcepto.UseVisualStyleBackColor = true;
            this.cmdAgregarConcepto.Click += new System.EventHandler(this.cmdAgregarConcepto_Click);
            // 
            // grdConceptos
            // 
            this.grdConceptos.AllowUserToAddRows = false;
            this.grdConceptos.AllowUserToDeleteRows = false;
            this.grdConceptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdConceptos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colClave,
            this.colDescripcion,
            this.colPrecio,
            this.colPorceRetIVA,
            this.colRetISR,
            this.colAgregarNombre});
            this.grdConceptos.Location = new System.Drawing.Point(375, 84);
            this.grdConceptos.Name = "grdConceptos";
            this.grdConceptos.Size = new System.Drawing.Size(646, 218);
            this.grdConceptos.TabIndex = 18;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(375, 52);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(203, 16);
            this.label13.TabIndex = 17;
            this.label13.Text = "Conceptos para facturación rápida";
            // 
            // cmdSerieEliminar
            // 
            this.cmdSerieEliminar.Image = ((System.Drawing.Image)(resources.GetObject("cmdSerieEliminar.Image")));
            this.cmdSerieEliminar.Location = new System.Drawing.Point(334, 43);
            this.cmdSerieEliminar.Name = "cmdSerieEliminar";
            this.cmdSerieEliminar.Size = new System.Drawing.Size(35, 35);
            this.cmdSerieEliminar.TabIndex = 16;
            this.toolTip.SetToolTip(this.cmdSerieEliminar, "Borrar serie");
            this.cmdSerieEliminar.UseVisualStyleBackColor = true;
            this.cmdSerieEliminar.Click += new System.EventHandler(this.cmdSerieEliminar_Click);
            // 
            // cmdSerieModificar
            // 
            this.cmdSerieModificar.Image = ((System.Drawing.Image)(resources.GetObject("cmdSerieModificar.Image")));
            this.cmdSerieModificar.Location = new System.Drawing.Point(293, 43);
            this.cmdSerieModificar.Name = "cmdSerieModificar";
            this.cmdSerieModificar.Size = new System.Drawing.Size(35, 35);
            this.cmdSerieModificar.TabIndex = 15;
            this.toolTip.SetToolTip(this.cmdSerieModificar, "Modificar serie");
            this.cmdSerieModificar.UseVisualStyleBackColor = true;
            this.cmdSerieModificar.Click += new System.EventHandler(this.cmdSerieModificar_Click);
            // 
            // cmdSerieAgregar
            // 
            this.cmdSerieAgregar.Image = ((System.Drawing.Image)(resources.GetObject("cmdSerieAgregar.Image")));
            this.cmdSerieAgregar.Location = new System.Drawing.Point(252, 43);
            this.cmdSerieAgregar.Name = "cmdSerieAgregar";
            this.cmdSerieAgregar.Size = new System.Drawing.Size(35, 35);
            this.cmdSerieAgregar.TabIndex = 14;
            this.toolTip.SetToolTip(this.cmdSerieAgregar, "Agregar serie");
            this.cmdSerieAgregar.UseVisualStyleBackColor = true;
            this.cmdSerieAgregar.Click += new System.EventHandler(this.cmdSerieAgregar_Click);
            // 
            // grdSeries
            // 
            this.grdSeries.AllowUserToAddRows = false;
            this.grdSeries.AllowUserToDeleteRows = false;
            this.grdSeries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSeries.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSerie,
            this.colFolio,
            this.colActiva,
            this.colDefault});
            this.grdSeries.Location = new System.Drawing.Point(6, 84);
            this.grdSeries.Name = "grdSeries";
            this.grdSeries.ReadOnly = true;
            this.grdSeries.Size = new System.Drawing.Size(363, 218);
            this.grdSeries.TabIndex = 0;
            this.grdSeries.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSeries_CellClick);
            this.grdSeries.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSeries_CellDoubleClick);
            this.grdSeries.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSeries_RowEnter);
            // 
            // colSerie
            // 
            this.colSerie.DataPropertyName = "Serie";
            this.colSerie.HeaderText = "Serie";
            this.colSerie.Name = "colSerie";
            this.colSerie.ReadOnly = true;
            this.colSerie.Width = 80;
            // 
            // colFolio
            // 
            this.colFolio.DataPropertyName = "Folio";
            this.colFolio.HeaderText = "Folio";
            this.colFolio.Name = "colFolio";
            this.colFolio.ReadOnly = true;
            this.colFolio.Width = 60;
            // 
            // colActiva
            // 
            this.colActiva.DataPropertyName = "Activa";
            this.colActiva.HeaderText = "Activa";
            this.colActiva.Name = "colActiva";
            this.colActiva.ReadOnly = true;
            this.colActiva.Width = 80;
            // 
            // colDefault
            // 
            this.colDefault.DataPropertyName = "Defa";
            this.colDefault.HeaderText = "Default";
            this.colDefault.Name = "colDefault";
            this.colDefault.ReadOnly = true;
            this.colDefault.Width = 80;
            // 
            // pagCertificados
            // 
            this.pagCertificados.Controls.Add(this.cmdMuestraPassWord);
            this.pagCertificados.Controls.Add(this.cmdBuscarLlavePrivada);
            this.pagCertificados.Controls.Add(this.cmdBuscarCertificado);
            this.pagCertificados.Controls.Add(this.txtPassWord);
            this.pagCertificados.Controls.Add(this.txtLlavePrivada);
            this.pagCertificados.Controls.Add(this.txtCertificado);
            this.pagCertificados.Controls.Add(this.label6);
            this.pagCertificados.Controls.Add(this.label9);
            this.pagCertificados.Controls.Add(this.label10);
            this.pagCertificados.Location = new System.Drawing.Point(4, 25);
            this.pagCertificados.Name = "pagCertificados";
            this.pagCertificados.Padding = new System.Windows.Forms.Padding(3);
            this.pagCertificados.Size = new System.Drawing.Size(1027, 368);
            this.pagCertificados.TabIndex = 2;
            this.pagCertificados.Text = "Certificados";
            this.pagCertificados.UseVisualStyleBackColor = true;
            // 
            // cmdMuestraPassWord
            // 
            this.cmdMuestraPassWord.Image = ((System.Drawing.Image)(resources.GetObject("cmdMuestraPassWord.Image")));
            this.cmdMuestraPassWord.Location = new System.Drawing.Point(587, 101);
            this.cmdMuestraPassWord.Name = "cmdMuestraPassWord";
            this.cmdMuestraPassWord.Size = new System.Drawing.Size(31, 30);
            this.cmdMuestraPassWord.TabIndex = 69;
            this.cmdMuestraPassWord.UseVisualStyleBackColor = true;
            this.cmdMuestraPassWord.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cmdMuestraPassWord_MouseDown);
            this.cmdMuestraPassWord.MouseUp += new System.Windows.Forms.MouseEventHandler(this.cmdMuestraPassWord_MouseUp);
            // 
            // cmdBuscarLlavePrivada
            // 
            this.cmdBuscarLlavePrivada.Location = new System.Drawing.Point(587, 76);
            this.cmdBuscarLlavePrivada.Name = "cmdBuscarLlavePrivada";
            this.cmdBuscarLlavePrivada.Size = new System.Drawing.Size(31, 23);
            this.cmdBuscarLlavePrivada.TabIndex = 68;
            this.cmdBuscarLlavePrivada.Text = "...";
            this.cmdBuscarLlavePrivada.UseVisualStyleBackColor = true;
            this.cmdBuscarLlavePrivada.Click += new System.EventHandler(this.cmdBuscarLlavePrivada_Click);
            // 
            // cmdBuscarCertificado
            // 
            this.cmdBuscarCertificado.Location = new System.Drawing.Point(587, 47);
            this.cmdBuscarCertificado.Name = "cmdBuscarCertificado";
            this.cmdBuscarCertificado.Size = new System.Drawing.Size(31, 23);
            this.cmdBuscarCertificado.TabIndex = 67;
            this.cmdBuscarCertificado.Text = "...";
            this.cmdBuscarCertificado.UseVisualStyleBackColor = true;
            this.cmdBuscarCertificado.Click += new System.EventHandler(this.cmdBuscarCertificado_Click);
            // 
            // txtPassWord
            // 
            this.txtPassWord.Location = new System.Drawing.Point(141, 105);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.PasswordChar = '*';
            this.txtPassWord.Size = new System.Drawing.Size(440, 23);
            this.txtPassWord.TabIndex = 66;
            // 
            // txtLlavePrivada
            // 
            this.txtLlavePrivada.Location = new System.Drawing.Point(141, 76);
            this.txtLlavePrivada.Name = "txtLlavePrivada";
            this.txtLlavePrivada.ReadOnly = true;
            this.txtLlavePrivada.Size = new System.Drawing.Size(440, 23);
            this.txtLlavePrivada.TabIndex = 64;
            // 
            // txtCertificado
            // 
            this.txtCertificado.Location = new System.Drawing.Point(141, 47);
            this.txtCertificado.Name = "txtCertificado";
            this.txtCertificado.ReadOnly = true;
            this.txtCertificado.Size = new System.Drawing.Size(440, 23);
            this.txtCertificado.TabIndex = 62;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(59, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 16);
            this.label6.TabIndex = 65;
            this.label6.Text = "Contraseña";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(49, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 16);
            this.label9.TabIndex = 63;
            this.label9.Text = "Llave Privada";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(63, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 16);
            this.label10.TabIndex = 61;
            this.label10.Text = "Certificado";
            // 
            // cmdSalir
            // 
            this.cmdSalir.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalir.Image")));
            this.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSalir.Location = new System.Drawing.Point(507, 423);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(118, 53);
            this.cmdSalir.TabIndex = 56;
            this.cmdSalir.Text = "&Salir";
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // cmdGuardar
            // 
            this.cmdGuardar.Image = ((System.Drawing.Image)(resources.GetObject("cmdGuardar.Image")));
            this.cmdGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdGuardar.Location = new System.Drawing.Point(376, 423);
            this.cmdGuardar.Name = "cmdGuardar";
            this.cmdGuardar.Size = new System.Drawing.Size(118, 53);
            this.cmdGuardar.TabIndex = 55;
            this.cmdGuardar.Text = "&Guardar";
            this.cmdGuardar.UseVisualStyleBackColor = true;
            this.cmdGuardar.Click += new System.EventHandler(this.cmdGuardar_Click);
            // 
            // colClave
            // 
            this.colClave.DataPropertyName = "Clave";
            this.colClave.HeaderText = "Clave";
            this.colClave.Name = "colClave";
            this.colClave.ReadOnly = true;
            this.colClave.Width = 80;
            // 
            // colDescripcion
            // 
            this.colDescripcion.DataPropertyName = "Descripcion";
            this.colDescripcion.HeaderText = "Descripción";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.ReadOnly = true;
            // 
            // colPrecio
            // 
            this.colPrecio.DataPropertyName = "Precio";
            dataGridViewCellStyle1.Format = "c2";
            dataGridViewCellStyle1.NullValue = null;
            this.colPrecio.DefaultCellStyle = dataGridViewCellStyle1;
            this.colPrecio.HeaderText = "Precio";
            this.colPrecio.Name = "colPrecio";
            this.colPrecio.ReadOnly = true;
            this.colPrecio.Width = 80;
            // 
            // colPorceRetIVA
            // 
            this.colPorceRetIVA.DataPropertyName = "PorceRetIVA";
            dataGridViewCellStyle2.Format = "#0.##%";
            dataGridViewCellStyle2.NullValue = null;
            this.colPorceRetIVA.DefaultCellStyle = dataGridViewCellStyle2;
            this.colPorceRetIVA.HeaderText = "% Ret. IVA";
            this.colPorceRetIVA.Name = "colPorceRetIVA";
            // 
            // colRetISR
            // 
            this.colRetISR.DataPropertyName = "PorceRetISR";
            dataGridViewCellStyle3.Format = "#0.##%";
            dataGridViewCellStyle3.NullValue = null;
            this.colRetISR.DefaultCellStyle = dataGridViewCellStyle3;
            this.colRetISR.HeaderText = "% Ret. ISR";
            this.colRetISR.Name = "colRetISR";
            // 
            // colAgregarNombre
            // 
            this.colAgregarNombre.DataPropertyName = "AgregaPaciente";
            this.colAgregarNombre.HeaderText = "Agregar nombre Px.";
            this.colAgregarNombre.Name = "colAgregarNombre";
            this.colAgregarNombre.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colAgregarNombre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // EmisoresAltasCambios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 510);
            this.Controls.Add(this.tabEmisores);
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.cmdGuardar);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EmisoresAltasCambios";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EmisoresAltasCambios";
            this.Load += new System.EventHandler(this.EmisoresAltasCambios_Load);
            this.tabEmisores.ResumeLayout(false);
            this.pagGenerales.ResumeLayout(false);
            this.pagGenerales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboPaises)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEstados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboCiudades)).EndInit();
            this.pagSeries.ResumeLayout(false);
            this.pagSeries.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdConceptos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSeries)).EndInit();
            this.pagCertificados.ResumeLayout(false);
            this.pagCertificados.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabEmisores;
        private System.Windows.Forms.TabPage pagGenerales;
        private System.Windows.Forms.TextBox txtRegimenFiscal;
        private System.Windows.Forms.Button cmdCveRefBuscar;
        private System.Windows.Forms.TextBox txtCveRef;
        private Syncfusion.WinForms.ListView.SfComboBox cboPaises;
        private Syncfusion.WinForms.ListView.SfComboBox cboEstados;
        private Syncfusion.WinForms.ListView.SfComboBox cboCiudades;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCP;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtColonia;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtRFC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage pagSeries;
        private System.Windows.Forms.TabPage pagCertificados;
        private System.Windows.Forms.Button cmdGuardar;
        private System.Windows.Forms.Button cmdSalir;
        private System.Windows.Forms.Button cmdMuestraPassWord;
        private System.Windows.Forms.Button cmdBuscarLlavePrivada;
        private System.Windows.Forms.Button cmdBuscarCertificado;
        private System.Windows.Forms.TextBox txtPassWord;
        private System.Windows.Forms.TextBox txtLlavePrivada;
        private System.Windows.Forms.TextBox txtCertificado;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView grdSeries;
        private System.Windows.Forms.Button cmdSerieEliminar;
        private System.Windows.Forms.Button cmdSerieModificar;
        private System.Windows.Forms.Button cmdSerieAgregar;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button cmdBorrarConcepto;
        private System.Windows.Forms.Button cmdAgregarConcepto;
        private System.Windows.Forms.DataGridView grdConceptos;
        private System.Windows.Forms.Button cmdModificarConcepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSerie;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFolio;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colActiva;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colDefault;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClave;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPorceRetIVA;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRetISR;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colAgregarNombre;
    }
}