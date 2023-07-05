namespace ClinicaFB.Ingresos
{
    partial class ingCaptura
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ingCaptura));
            this.label1 = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.grdConceptos = new System.Windows.Forms.DataGridView();
            this.colClave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImpuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRetISR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRetIVA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombrePaciente = new System.Windows.Forms.TextBox();
            this.txtRFC = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmdBuscaPaciente = new System.Windows.Forms.Button();
            this.cmdBuscaRazonSocial = new System.Windows.Forms.Button();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.cmdSalir = new System.Windows.Forms.Button();
            this.cmdFactura = new System.Windows.Forms.Button();
            this.cmdConceptoBorrar = new System.Windows.Forms.Button();
            this.cmdConceptoModificar = new System.Windows.Forms.Button();
            this.cmdTicket = new System.Windows.Forms.Button();
            this.chkAplicarRetISR = new System.Windows.Forms.CheckBox();
            this.chkAplicarRetIVA = new System.Windows.Forms.CheckBox();
            this.txtPorceRetISR = new Syncfusion.WinForms.Input.SfNumericTextBox();
            this.txtPorceRetIVA = new Syncfusion.WinForms.Input.SfNumericTextBox();
            this.sfNumericTextBox1 = new Syncfusion.WinForms.Input.SfNumericTextBox();
            this.chkDescuento = new System.Windows.Forms.CheckBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtConcepto = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.spnCantidad = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.cboEmisores = new Syncfusion.WinForms.ListView.SfComboBox();
            this.txtSubTotal = new Syncfusion.Windows.Forms.Tools.CurrencyEdit();
            this.txtDescuento = new Syncfusion.Windows.Forms.Tools.CurrencyEdit();
            this.txtIVA = new Syncfusion.Windows.Forms.Tools.CurrencyEdit();
            this.txtRetISR = new Syncfusion.Windows.Forms.Tools.CurrencyEdit();
            this.txtRetIVA = new Syncfusion.Windows.Forms.Tools.CurrencyEdit();
            this.txtTotal = new Syncfusion.Windows.Forms.Tools.CurrencyEdit();
            this.cboAlmacenes = new Syncfusion.WinForms.ListView.SfComboBox();
            this.lblAlmacen = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdConceptos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmisores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubTotal.TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescuento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescuento.TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIVA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIVA.TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRetISR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRetISR.TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRetIVA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRetIVA.TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAlmacenes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 38;
            this.label1.Text = "Fecha";
            // 
            // txtFecha
            // 
            this.txtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFecha.Location = new System.Drawing.Point(63, 12);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(127, 23);
            this.txtFecha.TabIndex = 39;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Conceptos";
            // 
            // grdConceptos
            // 
            this.grdConceptos.AllowUserToAddRows = false;
            this.grdConceptos.AllowUserToDeleteRows = false;
            this.grdConceptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdConceptos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colClave,
            this.colDescripcion,
            this.colCantidad,
            this.colPrecio,
            this.colImpuesto,
            this.colDescuento,
            this.colRetISR,
            this.colRetIVA,
            this.colTotal});
            this.grdConceptos.Location = new System.Drawing.Point(19, 111);
            this.grdConceptos.Name = "grdConceptos";
            this.grdConceptos.ReadOnly = true;
            this.grdConceptos.Size = new System.Drawing.Size(991, 228);
            this.grdConceptos.TabIndex = 47;
            this.grdConceptos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdConceptos_CellDoubleClick);
            // 
            // colClave
            // 
            this.colClave.HeaderText = "Clave";
            this.colClave.Name = "colClave";
            this.colClave.ReadOnly = true;
            this.colClave.Width = 80;
            // 
            // colDescripcion
            // 
            this.colDescripcion.HeaderText = "Descripción";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.ReadOnly = true;
            this.colDescripcion.Width = 200;
            // 
            // colCantidad
            // 
            this.colCantidad.HeaderText = "Cant.";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.ReadOnly = true;
            this.colCantidad.Width = 50;
            // 
            // colPrecio
            // 
            this.colPrecio.HeaderText = "Precio";
            this.colPrecio.Name = "colPrecio";
            this.colPrecio.ReadOnly = true;
            this.colPrecio.Width = 80;
            // 
            // colImpuesto
            // 
            this.colImpuesto.HeaderText = "IVA";
            this.colImpuesto.Name = "colImpuesto";
            this.colImpuesto.ReadOnly = true;
            this.colImpuesto.Width = 80;
            // 
            // colDescuento
            // 
            this.colDescuento.HeaderText = "Descuento";
            this.colDescuento.Name = "colDescuento";
            this.colDescuento.ReadOnly = true;
            this.colDescuento.Width = 80;
            // 
            // colRetISR
            // 
            this.colRetISR.HeaderText = "Ret. ISR";
            this.colRetISR.Name = "colRetISR";
            this.colRetISR.ReadOnly = true;
            this.colRetISR.Width = 80;
            // 
            // colRetIVA
            // 
            this.colRetIVA.HeaderText = "Ret. IVA";
            this.colRetIVA.Name = "colRetIVA";
            this.colRetIVA.ReadOnly = true;
            this.colRetIVA.Width = 80;
            // 
            // colTotal
            // 
            this.colTotal.HeaderText = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            this.colTotal.Width = 80;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(232, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 40;
            this.label3.Text = "Paciente";
            // 
            // txtNombrePaciente
            // 
            this.txtNombrePaciente.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombrePaciente.Location = new System.Drawing.Point(293, 12);
            this.txtNombrePaciente.Name = "txtNombrePaciente";
            this.txtNombrePaciente.ReadOnly = true;
            this.txtNombrePaciente.Size = new System.Drawing.Size(502, 23);
            this.txtNombrePaciente.TabIndex = 41;
            // 
            // txtRFC
            // 
            this.txtRFC.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRFC.Location = new System.Drawing.Point(293, 41);
            this.txtRFC.Name = "txtRFC";
            this.txtRFC.ReadOnly = true;
            this.txtRFC.Size = new System.Drawing.Size(156, 23);
            this.txtRFC.TabIndex = 44;
            this.txtRFC.Text = "XAXX010101000";
            this.txtRFC.TextChanged += new System.EventHandler(this.txtRFC_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(130, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 16);
            this.label4.TabIndex = 43;
            this.label4.Text = "Razón social para facturar";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(763, 349);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 16);
            this.label5.TabIndex = 26;
            this.label5.Text = "Subtotal";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(778, 379);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 16);
            this.label6.TabIndex = 30;
            this.label6.Text = "I.V.A.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(595, 409);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 16);
            this.label7.TabIndex = 32;
            this.label7.Text = "Ret. ISR";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(595, 379);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 16);
            this.label8.TabIndex = 34;
            this.label8.Text = "Ret. IVA";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(781, 409);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 16);
            this.label9.TabIndex = 36;
            this.label9.Text = "Total";
            // 
            // cmdBuscaPaciente
            // 
            this.cmdBuscaPaciente.Location = new System.Drawing.Point(801, 12);
            this.cmdBuscaPaciente.Name = "cmdBuscaPaciente";
            this.cmdBuscaPaciente.Size = new System.Drawing.Size(36, 23);
            this.cmdBuscaPaciente.TabIndex = 42;
            this.cmdBuscaPaciente.Text = "...";
            this.cmdBuscaPaciente.UseVisualStyleBackColor = true;
            this.cmdBuscaPaciente.Click += new System.EventHandler(this.cmdBuscaPaciente_Click);
            // 
            // cmdBuscaRazonSocial
            // 
            this.cmdBuscaRazonSocial.Location = new System.Drawing.Point(801, 41);
            this.cmdBuscaRazonSocial.Name = "cmdBuscaRazonSocial";
            this.cmdBuscaRazonSocial.Size = new System.Drawing.Size(36, 23);
            this.cmdBuscaRazonSocial.TabIndex = 46;
            this.cmdBuscaRazonSocial.Text = "...";
            this.cmdBuscaRazonSocial.UseVisualStyleBackColor = true;
            this.cmdBuscaRazonSocial.Click += new System.EventHandler(this.cmdBuscaRazonSocial_Click);
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocial.Location = new System.Drawing.Point(455, 41);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.ReadOnly = true;
            this.txtRazonSocial.Size = new System.Drawing.Size(340, 23);
            this.txtRazonSocial.TabIndex = 45;
            this.txtRazonSocial.Text = "PUBLICO EN GENERAL";
            this.txtRazonSocial.TextChanged += new System.EventHandler(this.txtRazonSocial_TextChanged);
            // 
            // cmdSalir
            // 
            this.cmdSalir.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalir.Image")));
            this.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdSalir.Location = new System.Drawing.Point(604, 446);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(112, 58);
            this.cmdSalir.TabIndex = 50;
            this.cmdSalir.Text = "Salir";
            this.cmdSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip.SetToolTip(this.cmdSalir, "Cierra el módulo");
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // cmdFactura
            // 
            this.cmdFactura.Image = ((System.Drawing.Image)(resources.GetObject("cmdFactura.Image")));
            this.cmdFactura.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdFactura.Location = new System.Drawing.Point(486, 446);
            this.cmdFactura.Name = "cmdFactura";
            this.cmdFactura.Size = new System.Drawing.Size(112, 58);
            this.cmdFactura.TabIndex = 49;
            this.cmdFactura.Text = "Factura";
            this.cmdFactura.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip.SetToolTip(this.cmdFactura, "Genera la factura");
            this.cmdFactura.UseVisualStyleBackColor = true;
            this.cmdFactura.Click += new System.EventHandler(this.cmdFactura_Click);
            // 
            // cmdConceptoBorrar
            // 
            this.cmdConceptoBorrar.Image = ((System.Drawing.Image)(resources.GetObject("cmdConceptoBorrar.Image")));
            this.cmdConceptoBorrar.Location = new System.Drawing.Point(975, 72);
            this.cmdConceptoBorrar.Name = "cmdConceptoBorrar";
            this.cmdConceptoBorrar.Size = new System.Drawing.Size(35, 31);
            this.cmdConceptoBorrar.TabIndex = 5;
            this.toolTip.SetToolTip(this.cmdConceptoBorrar, "Borrar serie");
            this.cmdConceptoBorrar.UseVisualStyleBackColor = true;
            this.cmdConceptoBorrar.Click += new System.EventHandler(this.cmdConceptoBorrar_Click);
            // 
            // cmdConceptoModificar
            // 
            this.cmdConceptoModificar.Image = ((System.Drawing.Image)(resources.GetObject("cmdConceptoModificar.Image")));
            this.cmdConceptoModificar.Location = new System.Drawing.Point(934, 72);
            this.cmdConceptoModificar.Name = "cmdConceptoModificar";
            this.cmdConceptoModificar.Size = new System.Drawing.Size(35, 31);
            this.cmdConceptoModificar.TabIndex = 4;
            this.toolTip.SetToolTip(this.cmdConceptoModificar, "Modificar serie");
            this.cmdConceptoModificar.UseVisualStyleBackColor = true;
            this.cmdConceptoModificar.Click += new System.EventHandler(this.cmdConceptoModificar_Click);
            // 
            // cmdTicket
            // 
            this.cmdTicket.Image = ((System.Drawing.Image)(resources.GetObject("cmdTicket.Image")));
            this.cmdTicket.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdTicket.Location = new System.Drawing.Point(368, 446);
            this.cmdTicket.Name = "cmdTicket";
            this.cmdTicket.Size = new System.Drawing.Size(112, 58);
            this.cmdTicket.TabIndex = 48;
            this.cmdTicket.Text = "Ticket";
            this.cmdTicket.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip.SetToolTip(this.cmdTicket, "Emite el ticket");
            this.cmdTicket.UseVisualStyleBackColor = true;
            this.cmdTicket.Click += new System.EventHandler(this.cmdTicket_Click);
            // 
            // chkAplicarRetISR
            // 
            this.chkAplicarRetISR.AutoSize = true;
            this.chkAplicarRetISR.Location = new System.Drawing.Point(25, 388);
            this.chkAplicarRetISR.Name = "chkAplicarRetISR";
            this.chkAplicarRetISR.Size = new System.Drawing.Size(116, 20);
            this.chkAplicarRetISR.TabIndex = 22;
            this.chkAplicarRetISR.Text = "Aplicar Ret. ISR";
            this.chkAplicarRetISR.UseVisualStyleBackColor = true;
            this.chkAplicarRetISR.Visible = false;
            // 
            // chkAplicarRetIVA
            // 
            this.chkAplicarRetIVA.AutoSize = true;
            this.chkAplicarRetIVA.Location = new System.Drawing.Point(25, 419);
            this.chkAplicarRetIVA.Name = "chkAplicarRetIVA";
            this.chkAplicarRetIVA.Size = new System.Drawing.Size(116, 20);
            this.chkAplicarRetIVA.TabIndex = 24;
            this.chkAplicarRetIVA.Text = "Aplicar Ret. IVA";
            this.chkAplicarRetIVA.UseVisualStyleBackColor = true;
            this.chkAplicarRetIVA.Visible = false;
            // 
            // txtPorceRetISR
            // 
            this.txtPorceRetISR.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPorceRetISR.FormatMode = Syncfusion.WinForms.Input.Enums.FormatMode.Percent;
            this.txtPorceRetISR.Location = new System.Drawing.Point(161, 387);
            this.txtPorceRetISR.Name = "txtPorceRetISR";
            this.txtPorceRetISR.Size = new System.Drawing.Size(77, 23);
            this.txtPorceRetISR.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtPorceRetISR.TabIndex = 23;
            this.txtPorceRetISR.Text = "0,00 %";
            this.txtPorceRetISR.Visible = false;
            // 
            // txtPorceRetIVA
            // 
            this.txtPorceRetIVA.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPorceRetIVA.FormatMode = Syncfusion.WinForms.Input.Enums.FormatMode.Percent;
            this.txtPorceRetIVA.Location = new System.Drawing.Point(161, 418);
            this.txtPorceRetIVA.Name = "txtPorceRetIVA";
            this.txtPorceRetIVA.Size = new System.Drawing.Size(77, 23);
            this.txtPorceRetIVA.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtPorceRetIVA.TabIndex = 25;
            this.txtPorceRetIVA.Text = "0,00 %";
            this.txtPorceRetIVA.Visible = false;
            // 
            // sfNumericTextBox1
            // 
            this.sfNumericTextBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.sfNumericTextBox1.FormatMode = Syncfusion.WinForms.Input.Enums.FormatMode.Percent;
            this.sfNumericTextBox1.Location = new System.Drawing.Point(161, 355);
            this.sfNumericTextBox1.Name = "sfNumericTextBox1";
            this.sfNumericTextBox1.Size = new System.Drawing.Size(77, 23);
            this.sfNumericTextBox1.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.sfNumericTextBox1.TabIndex = 21;
            this.sfNumericTextBox1.Text = "0,00 %";
            this.sfNumericTextBox1.Visible = false;
            // 
            // chkDescuento
            // 
            this.chkDescuento.AutoSize = true;
            this.chkDescuento.Location = new System.Drawing.Point(25, 356);
            this.chkDescuento.Name = "chkDescuento";
            this.chkDescuento.Size = new System.Drawing.Size(127, 20);
            this.chkDescuento.TabIndex = 20;
            this.chkDescuento.Text = "Aplicar descuento";
            this.chkDescuento.UseVisualStyleBackColor = true;
            this.chkDescuento.Visible = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(583, 349);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(66, 16);
            this.label18.TabIndex = 28;
            this.label18.Text = "Descuento";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(535, 79);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(60, 16);
            this.label19.TabIndex = 0;
            this.label19.Text = "Concepto";
            // 
            // txtConcepto
            // 
            this.txtConcepto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtConcepto.Location = new System.Drawing.Point(601, 76);
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(219, 23);
            this.txtConcepto.TabIndex = 1;
            this.txtConcepto.TextChanged += new System.EventHandler(this.txtConcepto_TextChanged);
            this.txtConcepto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtConcepto_KeyDown);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(826, 79);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(14, 16);
            this.label20.TabIndex = 2;
            this.label20.Text = "x";
            // 
            // spnCantidad
            // 
            this.spnCantidad.DecimalPlaces = 4;
            this.spnCantidad.Location = new System.Drawing.Point(845, 76);
            this.spnCantidad.Name = "spnCantidad";
            this.spnCantidad.Size = new System.Drawing.Size(80, 23);
            this.spnCantidad.TabIndex = 3;
            this.spnCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.spnCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(158, 79);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(46, 16);
            this.label21.TabIndex = 51;
            this.label21.Text = "Emisor";
            // 
            // cboEmisores
            // 
            this.cboEmisores.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboEmisores.AutoCompleteSuggestMode = Syncfusion.WinForms.ListView.Enums.AutoCompleteSuggestMode.Contains;
            this.cboEmisores.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.cboEmisores.DropDownStyle = Syncfusion.WinForms.ListView.Enums.DropDownStyle.DropDownList;
            this.cboEmisores.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cboEmisores.Location = new System.Drawing.Point(210, 73);
            this.cboEmisores.Name = "cboEmisores";
            this.cboEmisores.Size = new System.Drawing.Size(317, 28);
            this.cboEmisores.Style.DropDownStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cboEmisores.Style.EditorStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cboEmisores.Style.ReadOnlyEditorStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cboEmisores.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboEmisores.Style.TokenStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cboEmisores.TabIndex = 52;
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.BeforeTouchSize = new System.Drawing.Size(92, 24);
            this.txtSubTotal.Enabled = false;
            this.txtSubTotal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubTotal.Location = new System.Drawing.Point(821, 345);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.ShowCalculator = false;
            this.txtSubTotal.Size = new System.Drawing.Size(92, 24);
            this.txtSubTotal.TabIndex = 60;
            // 
            // 
            // 
            this.txtSubTotal.TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSubTotal.TextBox.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtSubTotal.TextBox.Location = new System.Drawing.Point(2, 4);
            this.txtSubTotal.TextBox.Name = "";
            this.txtSubTotal.TextBox.Size = new System.Drawing.Size(88, 16);
            this.txtSubTotal.TextBox.TabIndex = 0;
            this.txtSubTotal.TextBox.Text = "$0.00";
            this.txtSubTotal.TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSubTotal.ThemeName = "WindowsXP";
            this.txtSubTotal.UseVisualStyle = true;
            // 
            // txtDescuento
            // 
            this.txtDescuento.BeforeTouchSize = new System.Drawing.Size(92, 24);
            this.txtDescuento.Enabled = false;
            this.txtDescuento.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescuento.Location = new System.Drawing.Point(653, 345);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.ShowCalculator = false;
            this.txtDescuento.Size = new System.Drawing.Size(92, 24);
            this.txtDescuento.TabIndex = 61;
            // 
            // 
            // 
            this.txtDescuento.TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescuento.TextBox.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtDescuento.TextBox.Location = new System.Drawing.Point(2, 4);
            this.txtDescuento.TextBox.Name = "";
            this.txtDescuento.TextBox.Size = new System.Drawing.Size(88, 16);
            this.txtDescuento.TextBox.TabIndex = 0;
            this.txtDescuento.TextBox.Text = "$0.00";
            this.txtDescuento.TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDescuento.ThemeName = "WindowsXP";
            this.txtDescuento.UseVisualStyle = true;
            // 
            // txtIVA
            // 
            this.txtIVA.BeforeTouchSize = new System.Drawing.Size(92, 24);
            this.txtIVA.Enabled = false;
            this.txtIVA.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIVA.Location = new System.Drawing.Point(821, 375);
            this.txtIVA.Name = "txtIVA";
            this.txtIVA.ShowCalculator = false;
            this.txtIVA.Size = new System.Drawing.Size(92, 24);
            this.txtIVA.TabIndex = 62;
            // 
            // 
            // 
            this.txtIVA.TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIVA.TextBox.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtIVA.TextBox.Location = new System.Drawing.Point(2, 4);
            this.txtIVA.TextBox.Name = "";
            this.txtIVA.TextBox.Size = new System.Drawing.Size(88, 16);
            this.txtIVA.TextBox.TabIndex = 0;
            this.txtIVA.TextBox.Text = "$0.00";
            this.txtIVA.TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIVA.ThemeName = "WindowsXP";
            this.txtIVA.UseVisualStyle = true;
            // 
            // txtRetISR
            // 
            this.txtRetISR.BeforeTouchSize = new System.Drawing.Size(92, 24);
            this.txtRetISR.Enabled = false;
            this.txtRetISR.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRetISR.Location = new System.Drawing.Point(653, 405);
            this.txtRetISR.Name = "txtRetISR";
            this.txtRetISR.ShowCalculator = false;
            this.txtRetISR.Size = new System.Drawing.Size(92, 24);
            this.txtRetISR.TabIndex = 63;
            // 
            // 
            // 
            this.txtRetISR.TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRetISR.TextBox.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtRetISR.TextBox.Location = new System.Drawing.Point(2, 4);
            this.txtRetISR.TextBox.Name = "";
            this.txtRetISR.TextBox.Size = new System.Drawing.Size(88, 16);
            this.txtRetISR.TextBox.TabIndex = 0;
            this.txtRetISR.TextBox.Text = "$0.00";
            this.txtRetISR.TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRetISR.ThemeName = "WindowsXP";
            this.txtRetISR.UseVisualStyle = true;
            // 
            // txtRetIVA
            // 
            this.txtRetIVA.BeforeTouchSize = new System.Drawing.Size(92, 24);
            this.txtRetIVA.Enabled = false;
            this.txtRetIVA.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRetIVA.Location = new System.Drawing.Point(653, 375);
            this.txtRetIVA.Name = "txtRetIVA";
            this.txtRetIVA.ShowCalculator = false;
            this.txtRetIVA.Size = new System.Drawing.Size(92, 24);
            this.txtRetIVA.TabIndex = 64;
            // 
            // 
            // 
            this.txtRetIVA.TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRetIVA.TextBox.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtRetIVA.TextBox.Location = new System.Drawing.Point(2, 4);
            this.txtRetIVA.TextBox.Name = "";
            this.txtRetIVA.TextBox.Size = new System.Drawing.Size(88, 16);
            this.txtRetIVA.TextBox.TabIndex = 0;
            this.txtRetIVA.TextBox.Text = "$0.00";
            this.txtRetIVA.TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRetIVA.ThemeName = "WindowsXP";
            this.txtRetIVA.UseVisualStyle = true;
            // 
            // txtTotal
            // 
            this.txtTotal.BeforeTouchSize = new System.Drawing.Size(92, 24);
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(821, 405);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ShowCalculator = false;
            this.txtTotal.Size = new System.Drawing.Size(92, 24);
            this.txtTotal.TabIndex = 65;
            // 
            // 
            // 
            this.txtTotal.TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotal.TextBox.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtTotal.TextBox.Location = new System.Drawing.Point(2, 4);
            this.txtTotal.TextBox.Name = "";
            this.txtTotal.TextBox.Size = new System.Drawing.Size(88, 16);
            this.txtTotal.TextBox.TabIndex = 0;
            this.txtTotal.TextBox.Text = "$0.00";
            this.txtTotal.TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotal.ThemeName = "WindowsXP";
            this.txtTotal.UseVisualStyle = true;
            // 
            // cboAlmacenes
            // 
            this.cboAlmacenes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboAlmacenes.AutoCompleteSuggestMode = Syncfusion.WinForms.ListView.Enums.AutoCompleteSuggestMode.Contains;
            this.cboAlmacenes.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.cboAlmacenes.DropDownStyle = Syncfusion.WinForms.ListView.Enums.DropDownStyle.DropDownList;
            this.cboAlmacenes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cboAlmacenes.Location = new System.Drawing.Point(860, 26);
            this.cboAlmacenes.Name = "cboAlmacenes";
            this.cboAlmacenes.Size = new System.Drawing.Size(214, 28);
            this.cboAlmacenes.Style.DropDownStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cboAlmacenes.Style.EditorStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cboAlmacenes.Style.ReadOnlyEditorStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cboAlmacenes.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboAlmacenes.Style.TokenStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cboAlmacenes.TabIndex = 67;
            // 
            // lblAlmacen
            // 
            this.lblAlmacen.AutoSize = true;
            this.lblAlmacen.Location = new System.Drawing.Point(857, 7);
            this.lblAlmacen.Name = "lblAlmacen";
            this.lblAlmacen.Size = new System.Drawing.Size(56, 16);
            this.lblAlmacen.TabIndex = 66;
            this.lblAlmacen.Text = "Almacen";
            // 
            // ingCaptura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 526);
            this.Controls.Add(this.cboAlmacenes);
            this.Controls.Add(this.lblAlmacen);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.txtRetIVA);
            this.Controls.Add(this.txtRetISR);
            this.Controls.Add(this.txtIVA);
            this.Controls.Add(this.txtDescuento);
            this.Controls.Add(this.txtSubTotal);
            this.Controls.Add(this.cboEmisores);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.spnCantidad);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.txtConcepto);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.sfNumericTextBox1);
            this.Controls.Add(this.chkDescuento);
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.cmdFactura);
            this.Controls.Add(this.txtPorceRetIVA);
            this.Controls.Add(this.txtPorceRetISR);
            this.Controls.Add(this.chkAplicarRetIVA);
            this.Controls.Add(this.chkAplicarRetISR);
            this.Controls.Add(this.cmdConceptoBorrar);
            this.Controls.Add(this.cmdConceptoModificar);
            this.Controls.Add(this.cmdTicket);
            this.Controls.Add(this.txtRazonSocial);
            this.Controls.Add(this.cmdBuscaRazonSocial);
            this.Controls.Add(this.cmdBuscaPaciente);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtRFC);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNombrePaciente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.grdConceptos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "ingCaptura";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Captura de ingresos";
            this.Load += new System.EventHandler(this.ingCaptura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdConceptos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmisores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubTotal.TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescuento.TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescuento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIVA.TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIVA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRetISR.TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRetISR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRetIVA.TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRetIVA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAlmacenes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker txtFecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView grdConceptos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombrePaciente;
        private System.Windows.Forms.TextBox txtRFC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button cmdBuscaPaciente;
        private System.Windows.Forms.Button cmdBuscaRazonSocial;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button cmdTicket;
        private System.Windows.Forms.Button cmdConceptoBorrar;
        private System.Windows.Forms.Button cmdConceptoModificar;
        private System.Windows.Forms.CheckBox chkAplicarRetISR;
        private System.Windows.Forms.CheckBox chkAplicarRetIVA;
        private Syncfusion.WinForms.Input.SfNumericTextBox txtPorceRetISR;
        private Syncfusion.WinForms.Input.SfNumericTextBox txtPorceRetIVA;
        private System.Windows.Forms.Button cmdFactura;
        private System.Windows.Forms.Button cmdSalir;
        private Syncfusion.WinForms.Input.SfNumericTextBox sfNumericTextBox1;
        private System.Windows.Forms.CheckBox chkDescuento;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClave;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImpuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRetISR;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRetIVA;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtConcepto;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.NumericUpDown spnCantidad;
        private System.Windows.Forms.Label label21;
        private Syncfusion.WinForms.ListView.SfComboBox cboEmisores;
        private Syncfusion.Windows.Forms.Tools.CurrencyEdit txtSubTotal;
        private Syncfusion.Windows.Forms.Tools.CurrencyEdit txtDescuento;
        private Syncfusion.Windows.Forms.Tools.CurrencyEdit txtIVA;
        private Syncfusion.Windows.Forms.Tools.CurrencyEdit txtRetISR;
        private Syncfusion.Windows.Forms.Tools.CurrencyEdit txtRetIVA;
        private Syncfusion.Windows.Forms.Tools.CurrencyEdit txtTotal;
        private Syncfusion.WinForms.ListView.SfComboBox cboAlmacenes;
        private System.Windows.Forms.Label lblAlmacen;
    }
}