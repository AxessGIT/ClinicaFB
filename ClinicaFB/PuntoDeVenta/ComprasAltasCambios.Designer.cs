namespace ClinicaFB.PuntoDeVenta
{
    partial class ComprasAltasCambios
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComprasAltasCambios));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.grdArticulos = new System.Windows.Forms.DataGridView();
            this.colClaveProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtConcepto = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.cmdProveedorBuscar = new System.Windows.Forms.Button();
            this.txtProveedorNombre = new System.Windows.Forms.TextBox();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.spnPlazo = new System.Windows.Forms.NumericUpDown();
            this.spnFolio = new System.Windows.Forms.NumericUpDown();
            this.txtTotal = new Syncfusion.Windows.Forms.Tools.CurrencyEdit();
            this.txtIVA = new Syncfusion.Windows.Forms.Tools.CurrencyEdit();
            this.txtSubTotal = new Syncfusion.Windows.Forms.Tools.CurrencyEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtCantidad = new Syncfusion.WinForms.Input.SfNumericTextBox();
            this.txtCosto = new Syncfusion.Windows.Forms.Tools.CurrencyTextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cmdAgregar = new System.Windows.Forms.Button();
            this.cmdBorrar = new System.Windows.Forms.Button();
            this.cmdModificar = new System.Windows.Forms.Button();
            this.cmdAgregarProveedor = new System.Windows.Forms.Button();
            this.cmdGuardar = new System.Windows.Forms.Button();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.cmdCFDiCargar = new System.Windows.Forms.Button();
            this.txtProveedorRFC = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtAlmacenNombre = new System.Windows.Forms.TextBox();
            this.lblConsumidos = new System.Windows.Forms.Label();
            this.lblCancelada = new System.Windows.Forms.Label();
            this.cmdTempo = new System.Windows.Forms.Button();
            this.lblGuardar = new System.Windows.Forms.Label();
            this.pgGuardar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.grdArticulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnPlazo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnFolio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIVA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIVA.TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubTotal.TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCosto)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(420, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fecha";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(641, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Proveedor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(376, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Plazo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Serie factura";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(200, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Folio factura";
            // 
            // grdArticulos
            // 
            this.grdArticulos.AllowUserToAddRows = false;
            this.grdArticulos.AllowUserToDeleteRows = false;
            this.grdArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdArticulos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colClaveProveedor,
            this.colClave,
            this.colDescripcion,
            this.colCantidad,
            this.colPrecio,
            this.colImporte});
            this.grdArticulos.Location = new System.Drawing.Point(11, 145);
            this.grdArticulos.Name = "grdArticulos";
            this.grdArticulos.Size = new System.Drawing.Size(1088, 422);
            this.grdArticulos.TabIndex = 30;
            this.grdArticulos.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdArticulos_CellEndEdit);
            this.grdArticulos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdArticulos_CellFormatting);
            this.grdArticulos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdArticulos_KeyDown);
            // 
            // colClaveProveedor
            // 
            this.colClaveProveedor.DataPropertyName = "ClaveProve";
            this.colClaveProveedor.HeaderText = "Clave Prove.";
            this.colClaveProveedor.Name = "colClaveProveedor";
            this.colClaveProveedor.Width = 250;
            // 
            // colClave
            // 
            this.colClave.DataPropertyName = "Clave";
            this.colClave.HeaderText = "Clave";
            this.colClave.Name = "colClave";
            this.colClave.Width = 150;
            // 
            // colDescripcion
            // 
            this.colDescripcion.DataPropertyName = "ArticuloDescripcion";
            this.colDescripcion.HeaderText = "Descripción";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.ReadOnly = true;
            this.colDescripcion.Width = 300;
            // 
            // colCantidad
            // 
            this.colCantidad.DataPropertyName = "Cantidad";
            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.ReadOnly = true;
            // 
            // colPrecio
            // 
            this.colPrecio.DataPropertyName = "Precio";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.colPrecio.DefaultCellStyle = dataGridViewCellStyle3;
            this.colPrecio.HeaderText = "Costo";
            this.colPrecio.Name = "colPrecio";
            this.colPrecio.ReadOnly = true;
            // 
            // colImporte
            // 
            this.colImporte.DataPropertyName = "Importe";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C2";
            this.colImporte.DefaultCellStyle = dataGridViewCellStyle4;
            this.colImporte.HeaderText = "Importe";
            this.colImporte.Name = "colImporte";
            this.colImporte.ReadOnly = true;
            // 
            // txtConcepto
            // 
            this.txtConcepto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtConcepto.Location = new System.Drawing.Point(144, 112);
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(169, 23);
            this.txtConcepto.TabIndex = 14;
            this.txtConcepto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtConcepto_KeyDown);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(13, 115);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(125, 16);
            this.label19.TabIndex = 13;
            this.label19.Text = "Artículo (F5=Buscar)";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(467, 15);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(110, 23);
            this.dtpFecha.TabIndex = 3;
            // 
            // cmdProveedorBuscar
            // 
            this.cmdProveedorBuscar.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.cmdProveedorBuscar.Location = new System.Drawing.Point(710, 13);
            this.cmdProveedorBuscar.Name = "cmdProveedorBuscar";
            this.cmdProveedorBuscar.Size = new System.Drawing.Size(38, 26);
            this.cmdProveedorBuscar.TabIndex = 5;
            this.cmdProveedorBuscar.Text = "...";
            this.cmdProveedorBuscar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdProveedorBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.cmdProveedorBuscar.UseVisualStyleBackColor = true;
            this.cmdProveedorBuscar.Click += new System.EventHandler(this.cmdProveedorBuscar_Click);
            // 
            // txtProveedorNombre
            // 
            this.txtProveedorNombre.Location = new System.Drawing.Point(644, 44);
            this.txtProveedorNombre.Name = "txtProveedorNombre";
            this.txtProveedorNombre.ReadOnly = true;
            this.txtProveedorNombre.Size = new System.Drawing.Size(414, 23);
            this.txtProveedorNombre.TabIndex = 21;
            // 
            // txtSerie
            // 
            this.txtSerie.Location = new System.Drawing.Point(99, 46);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(94, 23);
            this.txtSerie.TabIndex = 8;
            // 
            // spnPlazo
            // 
            this.spnPlazo.Location = new System.Drawing.Point(423, 46);
            this.spnPlazo.Name = "spnPlazo";
            this.spnPlazo.Size = new System.Drawing.Size(88, 23);
            this.spnPlazo.TabIndex = 12;
            // 
            // spnFolio
            // 
            this.spnFolio.Location = new System.Drawing.Point(284, 46);
            this.spnFolio.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.spnFolio.Name = "spnFolio";
            this.spnFolio.Size = new System.Drawing.Size(88, 23);
            this.spnFolio.TabIndex = 10;
            // 
            // txtTotal
            // 
            this.txtTotal.BeforeTouchSize = new System.Drawing.Size(150, 26);
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(949, 633);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ShowCalculator = false;
            this.txtTotal.Size = new System.Drawing.Size(150, 26);
            this.txtTotal.TabIndex = 28;
            // 
            // 
            // 
            this.txtTotal.TextBox.AccessibilityEnabled = true;
            this.txtTotal.TextBox.BeforeTouchSize = new System.Drawing.Size(107, 23);
            this.txtTotal.TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTotal.TextBox.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtTotal.TextBox.Location = new System.Drawing.Point(2, 4);
            this.txtTotal.TextBox.Name = "";
            this.txtTotal.TextBox.Size = new System.Drawing.Size(146, 18);
            this.txtTotal.TextBox.TabIndex = 0;
            this.txtTotal.TextBox.Text = "$0.00";
            this.txtTotal.TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotal.ThemeName = "WindowsXP";
            this.txtTotal.UseVisualStyle = true;
            // 
            // txtIVA
            // 
            this.txtIVA.BeforeTouchSize = new System.Drawing.Size(150, 26);
            this.txtIVA.Enabled = false;
            this.txtIVA.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIVA.Location = new System.Drawing.Point(949, 603);
            this.txtIVA.Name = "txtIVA";
            this.txtIVA.ShowCalculator = false;
            this.txtIVA.Size = new System.Drawing.Size(150, 26);
            this.txtIVA.TabIndex = 26;
            // 
            // 
            // 
            this.txtIVA.TextBox.AccessibilityEnabled = true;
            this.txtIVA.TextBox.BeforeTouchSize = new System.Drawing.Size(107, 23);
            this.txtIVA.TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIVA.TextBox.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtIVA.TextBox.Location = new System.Drawing.Point(2, 4);
            this.txtIVA.TextBox.Name = "";
            this.txtIVA.TextBox.Size = new System.Drawing.Size(146, 18);
            this.txtIVA.TextBox.TabIndex = 0;
            this.txtIVA.TextBox.Text = "$0.00";
            this.txtIVA.TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIVA.ThemeName = "WindowsXP";
            this.txtIVA.UseVisualStyle = true;
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.BeforeTouchSize = new System.Drawing.Size(150, 26);
            this.txtSubTotal.Enabled = false;
            this.txtSubTotal.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubTotal.Location = new System.Drawing.Point(949, 573);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.ShowCalculator = false;
            this.txtSubTotal.Size = new System.Drawing.Size(150, 26);
            this.txtSubTotal.TabIndex = 24;
            // 
            // 
            // 
            this.txtSubTotal.TextBox.AccessibilityEnabled = true;
            this.txtSubTotal.TextBox.BeforeTouchSize = new System.Drawing.Size(107, 23);
            this.txtSubTotal.TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSubTotal.TextBox.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtSubTotal.TextBox.Location = new System.Drawing.Point(2, 4);
            this.txtSubTotal.TextBox.Name = "";
            this.txtSubTotal.TextBox.Size = new System.Drawing.Size(146, 18);
            this.txtSubTotal.TextBox.TabIndex = 0;
            this.txtSubTotal.TextBox.Text = "$0.00";
            this.txtSubTotal.TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSubTotal.ThemeName = "WindowsXP";
            this.txtSubTotal.UseVisualStyle = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(897, 637);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 18);
            this.label9.TabIndex = 27;
            this.label9.Text = "Total";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(893, 607);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 18);
            this.label6.TabIndex = 25;
            this.label6.Text = "I.V.A.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(872, 577);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 18);
            this.label7.TabIndex = 23;
            this.label7.Text = "Subtotal";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(421, 112);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ReadOnly = true;
            this.txtDescripcion.Size = new System.Drawing.Size(266, 23);
            this.txtDescripcion.TabIndex = 29;
            // 
            // txtCantidad
            // 
            this.txtCantidad.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCantidad.Location = new System.Drawing.Point(339, 112);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(76, 23);
            this.txtCantidad.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtCantidad.TabIndex = 16;
            this.txtCantidad.Text = "1,00";
            this.txtCantidad.Value = 1D;
            // 
            // txtCosto
            // 
            this.txtCosto.AccessibilityEnabled = true;
            this.txtCosto.BeforeTouchSize = new System.Drawing.Size(107, 23);
            this.txtCosto.DecimalValue = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.txtCosto.Location = new System.Drawing.Point(693, 112);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(107, 23);
            this.txtCosto.TabIndex = 18;
            this.txtCosto.Text = "$0.00";
            // 
            // cmdAgregar
            // 
            this.cmdAgregar.Image = ((System.Drawing.Image)(resources.GetObject("cmdAgregar.Image")));
            this.cmdAgregar.Location = new System.Drawing.Point(810, 108);
            this.cmdAgregar.Name = "cmdAgregar";
            this.cmdAgregar.Size = new System.Drawing.Size(35, 31);
            this.cmdAgregar.TabIndex = 19;
            this.toolTip1.SetToolTip(this.cmdAgregar, "Agregar artículo a la compra");
            this.cmdAgregar.UseVisualStyleBackColor = true;
            this.cmdAgregar.Click += new System.EventHandler(this.cmdAgregar_Click);
            // 
            // cmdBorrar
            // 
            this.cmdBorrar.Image = ((System.Drawing.Image)(resources.GetObject("cmdBorrar.Image")));
            this.cmdBorrar.Location = new System.Drawing.Point(892, 108);
            this.cmdBorrar.Name = "cmdBorrar";
            this.cmdBorrar.Size = new System.Drawing.Size(35, 31);
            this.cmdBorrar.TabIndex = 21;
            this.toolTip1.SetToolTip(this.cmdBorrar, "Borrar artículo");
            this.cmdBorrar.UseVisualStyleBackColor = true;
            this.cmdBorrar.Click += new System.EventHandler(this.cmdBorrar_Click);
            // 
            // cmdModificar
            // 
            this.cmdModificar.Image = ((System.Drawing.Image)(resources.GetObject("cmdModificar.Image")));
            this.cmdModificar.Location = new System.Drawing.Point(851, 108);
            this.cmdModificar.Name = "cmdModificar";
            this.cmdModificar.Size = new System.Drawing.Size(35, 31);
            this.cmdModificar.TabIndex = 20;
            this.toolTip1.SetToolTip(this.cmdModificar, "Modificar artículo");
            this.cmdModificar.UseVisualStyleBackColor = true;
            this.cmdModificar.Click += new System.EventHandler(this.cmdModificar_Click);
            // 
            // cmdAgregarProveedor
            // 
            this.cmdAgregarProveedor.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.cmdAgregarProveedor.Location = new System.Drawing.Point(754, 13);
            this.cmdAgregarProveedor.Name = "cmdAgregarProveedor";
            this.cmdAgregarProveedor.Size = new System.Drawing.Size(38, 26);
            this.cmdAgregarProveedor.TabIndex = 6;
            this.cmdAgregarProveedor.Text = "+";
            this.cmdAgregarProveedor.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdAgregarProveedor.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.toolTip1.SetToolTip(this.cmdAgregarProveedor, "Agregar proveedor");
            this.cmdAgregarProveedor.UseVisualStyleBackColor = true;
            this.cmdAgregarProveedor.Click += new System.EventHandler(this.cmdAgregarProveedor_Click);
            // 
            // cmdGuardar
            // 
            this.cmdGuardar.Image = ((System.Drawing.Image)(resources.GetObject("cmdGuardar.Image")));
            this.cmdGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdGuardar.Location = new System.Drawing.Point(418, 577);
            this.cmdGuardar.Name = "cmdGuardar";
            this.cmdGuardar.Size = new System.Drawing.Size(110, 48);
            this.cmdGuardar.TabIndex = 22;
            this.cmdGuardar.Text = "&Guardar";
            this.cmdGuardar.UseVisualStyleBackColor = true;
            this.cmdGuardar.Click += new System.EventHandler(this.cmdGuardar_Click);
            // 
            // cmdSalir
            // 
            this.cmdSalir.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalir.Image")));
            this.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSalir.Location = new System.Drawing.Point(534, 577);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(110, 48);
            this.cmdSalir.TabIndex = 23;
            this.cmdSalir.Text = "&Salir";
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // cmdCFDiCargar
            // 
            this.cmdCFDiCargar.Image = ((System.Drawing.Image)(resources.GetObject("cmdCFDiCargar.Image")));
            this.cmdCFDiCargar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCFDiCargar.Location = new System.Drawing.Point(16, 584);
            this.cmdCFDiCargar.Name = "cmdCFDiCargar";
            this.cmdCFDiCargar.Size = new System.Drawing.Size(111, 34);
            this.cmdCFDiCargar.TabIndex = 24;
            this.cmdCFDiCargar.Text = "Cargar CFDi";
            this.cmdCFDiCargar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdCFDiCargar.UseVisualStyleBackColor = true;
            this.cmdCFDiCargar.Click += new System.EventHandler(this.cmdCFDiCargar_Click);
            // 
            // txtProveedorRFC
            // 
            this.txtProveedorRFC.Location = new System.Drawing.Point(798, 15);
            this.txtProveedorRFC.Name = "txtProveedorRFC";
            this.txtProveedorRFC.ReadOnly = true;
            this.txtProveedorRFC.Size = new System.Drawing.Size(182, 23);
            this.txtProveedorRFC.TabIndex = 31;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(319, 115);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 16);
            this.label10.TabIndex = 32;
            this.label10.Text = "x";
            // 
            // txtAlmacenNombre
            // 
            this.txtAlmacenNombre.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAlmacenNombre.Location = new System.Drawing.Point(16, 14);
            this.txtAlmacenNombre.Name = "txtAlmacenNombre";
            this.txtAlmacenNombre.ReadOnly = true;
            this.txtAlmacenNombre.Size = new System.Drawing.Size(377, 23);
            this.txtAlmacenNombre.TabIndex = 33;
            // 
            // lblConsumidos
            // 
            this.lblConsumidos.AutoSize = true;
            this.lblConsumidos.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsumidos.ForeColor = System.Drawing.Color.Red;
            this.lblConsumidos.Location = new System.Drawing.Point(16, 86);
            this.lblConsumidos.Name = "lblConsumidos";
            this.lblConsumidos.Size = new System.Drawing.Size(695, 16);
            this.lblConsumidos.TabIndex = 34;
            this.lblConsumidos.Text = "** LA COMPRA Y LOS ARTÍCULOS NO SE PUEDEN MODIFICAR PORQUE ALGUN(OS) HAN SIDO CON" +
    "SUMIDOS ***";
            this.lblConsumidos.Visible = false;
            // 
            // lblCancelada
            // 
            this.lblCancelada.AutoSize = true;
            this.lblCancelada.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCancelada.ForeColor = System.Drawing.Color.Red;
            this.lblCancelada.Location = new System.Drawing.Point(934, 86);
            this.lblCancelada.Name = "lblCancelada";
            this.lblCancelada.Size = new System.Drawing.Size(124, 16);
            this.lblCancelada.TabIndex = 35;
            this.lblCancelada.Text = "**CANCELADA***";
            this.lblCancelada.Visible = false;
            // 
            // cmdTempo
            // 
            this.cmdTempo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdTempo.Location = new System.Drawing.Point(660, 577);
            this.cmdTempo.Name = "cmdTempo";
            this.cmdTempo.Size = new System.Drawing.Size(110, 48);
            this.cmdTempo.TabIndex = 36;
            this.cmdTempo.Text = "&Tempo";
            this.cmdTempo.UseVisualStyleBackColor = true;
            this.cmdTempo.Click += new System.EventHandler(this.cmdTempo_Click);
            // 
            // lblGuardar
            // 
            this.lblGuardar.AutoSize = true;
            this.lblGuardar.Location = new System.Drawing.Point(210, 639);
            this.lblGuardar.Name = "lblGuardar";
            this.lblGuardar.Size = new System.Drawing.Size(81, 16);
            this.lblGuardar.TabIndex = 37;
            this.lblGuardar.Text = "Guardando...";
            this.lblGuardar.Visible = false;
            // 
            // pgGuardar
            // 
            this.pgGuardar.Location = new System.Drawing.Point(350, 636);
            this.pgGuardar.Name = "pgGuardar";
            this.pgGuardar.Size = new System.Drawing.Size(420, 23);
            this.pgGuardar.TabIndex = 38;
            this.pgGuardar.Visible = false;
            // 
            // ComprasAltasCambios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 671);
            this.Controls.Add(this.pgGuardar);
            this.Controls.Add(this.lblGuardar);
            this.Controls.Add(this.cmdTempo);
            this.Controls.Add(this.lblCancelada);
            this.Controls.Add(this.lblConsumidos);
            this.Controls.Add(this.txtAlmacenNombre);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmdAgregarProveedor);
            this.Controls.Add(this.txtProveedorRFC);
            this.Controls.Add(this.cmdAgregar);
            this.Controls.Add(this.txtCosto);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.txtIVA);
            this.Controls.Add(this.txtSubTotal);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmdGuardar);
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.cmdCFDiCargar);
            this.Controls.Add(this.spnFolio);
            this.Controls.Add(this.spnPlazo);
            this.Controls.Add(this.txtSerie);
            this.Controls.Add(this.txtProveedorNombre);
            this.Controls.Add(this.cmdProveedorBuscar);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.txtConcepto);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.cmdBorrar);
            this.Controls.Add(this.cmdModificar);
            this.Controls.Add(this.grdArticulos);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimizeBox = false;
            this.Name = "ComprasAltasCambios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compras";
            this.Load += new System.EventHandler(this.ComprasAltasCambios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdArticulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnPlazo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnFolio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIVA.TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIVA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubTotal.TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCosto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView grdArticulos;
        private System.Windows.Forms.TextBox txtConcepto;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button cmdBorrar;
        private System.Windows.Forms.Button cmdModificar;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button cmdProveedorBuscar;
        private System.Windows.Forms.TextBox txtProveedorNombre;
        private System.Windows.Forms.TextBox txtSerie;
        private System.Windows.Forms.NumericUpDown spnPlazo;
        private System.Windows.Forms.NumericUpDown spnFolio;
        private System.Windows.Forms.Button cmdCFDiCargar;
        private System.Windows.Forms.Button cmdGuardar;
        private System.Windows.Forms.Button cmdSalir;
        private Syncfusion.Windows.Forms.Tools.CurrencyEdit txtTotal;
        private Syncfusion.Windows.Forms.Tools.CurrencyEdit txtIVA;
        private Syncfusion.Windows.Forms.Tools.CurrencyEdit txtSubTotal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDescripcion;
        private Syncfusion.WinForms.Input.SfNumericTextBox txtCantidad;
        private Syncfusion.Windows.Forms.Tools.CurrencyTextBox txtCosto;
        private System.Windows.Forms.Button cmdAgregar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtProveedorRFC;
        private System.Windows.Forms.Button cmdAgregarProveedor;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtAlmacenNombre;
        private System.Windows.Forms.Label lblConsumidos;
        private System.Windows.Forms.Label lblCancelada;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClaveProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClave;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImporte;
        private System.Windows.Forms.Button cmdTempo;
        private System.Windows.Forms.Label lblGuardar;
        private System.Windows.Forms.ProgressBar pgGuardar;
    }
}