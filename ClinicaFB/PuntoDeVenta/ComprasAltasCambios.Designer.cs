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
            this.label20 = new System.Windows.Forms.Label();
            this.txtConcepto = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cmdBorrar = new System.Windows.Forms.Button();
            this.cmdModificar = new System.Windows.Forms.Button();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.cmdProveedorBuscar = new System.Windows.Forms.Button();
            this.txtProveedorNombre = new System.Windows.Forms.TextBox();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.spnPlazo = new System.Windows.Forms.NumericUpDown();
            this.spnFolio = new System.Windows.Forms.NumericUpDown();
            this.cmdCFDiCargar = new System.Windows.Forms.Button();
            this.cmdGuardar = new System.Windows.Forms.Button();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.txtTotal = new Syncfusion.Windows.Forms.Tools.CurrencyEdit();
            this.txtIVA = new Syncfusion.Windows.Forms.Tools.CurrencyEdit();
            this.txtSubTotal = new Syncfusion.Windows.Forms.Tools.CurrencyEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtCantidad = new Syncfusion.WinForms.Input.SfNumericTextBox();
            this.txtCosto = new Syncfusion.Windows.Forms.Tools.CurrencyTextBox();
            this.cmdAgregar = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
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
            this.label1.Location = new System.Drawing.Point(16, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Proveedor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(379, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Plazo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Serie factura";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(203, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 16);
            this.label5.TabIndex = 6;
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
            this.grdArticulos.Location = new System.Drawing.Point(11, 92);
            this.grdArticulos.Name = "grdArticulos";
            this.grdArticulos.ReadOnly = true;
            this.grdArticulos.Size = new System.Drawing.Size(857, 282);
            this.grdArticulos.TabIndex = 30;
            // 
            // colClaveProveedor
            // 
            this.colClaveProveedor.DataPropertyName = "ClaveProve";
            this.colClaveProveedor.HeaderText = "Clave Prove.";
            this.colClaveProveedor.Name = "colClaveProveedor";
            this.colClaveProveedor.ReadOnly = true;
            // 
            // colClave
            // 
            this.colClave.DataPropertyName = "Clave";
            this.colClave.HeaderText = "Clave";
            this.colClave.Name = "colClave";
            this.colClave.ReadOnly = true;
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
            this.colPrecio.HeaderText = "Costo";
            this.colPrecio.Name = "colPrecio";
            this.colPrecio.ReadOnly = true;
            // 
            // colImporte
            // 
            this.colImporte.DataPropertyName = "Importe";
            this.colImporte.HeaderText = "Importe";
            this.colImporte.Name = "colImporte";
            this.colImporte.ReadOnly = true;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(4, 421);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(57, 16);
            this.label20.TabIndex = 12;
            this.label20.Text = "Cantidad";
            // 
            // txtConcepto
            // 
            this.txtConcepto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtConcepto.Location = new System.Drawing.Point(144, 385);
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(169, 23);
            this.txtConcepto.TabIndex = 11;
            this.txtConcepto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtConcepto_KeyDown);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(4, 388);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(125, 16);
            this.label19.TabIndex = 10;
            this.label19.Text = "Artículo (F5=Buscar)";
            // 
            // cmdBorrar
            // 
            this.cmdBorrar.Image = ((System.Drawing.Image)(resources.GetObject("cmdBorrar.Image")));
            this.cmdBorrar.Location = new System.Drawing.Point(401, 414);
            this.cmdBorrar.Name = "cmdBorrar";
            this.cmdBorrar.Size = new System.Drawing.Size(35, 31);
            this.cmdBorrar.TabIndex = 18;
            this.toolTip1.SetToolTip(this.cmdBorrar, "Borrar artículo");
            this.cmdBorrar.UseVisualStyleBackColor = true;
            this.cmdBorrar.Click += new System.EventHandler(this.cmdBorrar_Click);
            // 
            // cmdModificar
            // 
            this.cmdModificar.Image = ((System.Drawing.Image)(resources.GetObject("cmdModificar.Image")));
            this.cmdModificar.Location = new System.Drawing.Point(360, 414);
            this.cmdModificar.Name = "cmdModificar";
            this.cmdModificar.Size = new System.Drawing.Size(35, 31);
            this.cmdModificar.TabIndex = 17;
            this.toolTip1.SetToolTip(this.cmdModificar, "Modificar artículo");
            this.cmdModificar.UseVisualStyleBackColor = true;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(102, 9);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(110, 23);
            this.dtpFecha.TabIndex = 1;
            // 
            // cmdProveedorBuscar
            // 
            this.cmdProveedorBuscar.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.cmdProveedorBuscar.Location = new System.Drawing.Point(287, 7);
            this.cmdProveedorBuscar.Name = "cmdProveedorBuscar";
            this.cmdProveedorBuscar.Size = new System.Drawing.Size(38, 26);
            this.cmdProveedorBuscar.TabIndex = 3;
            this.cmdProveedorBuscar.Text = "...";
            this.cmdProveedorBuscar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdProveedorBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.cmdProveedorBuscar.UseVisualStyleBackColor = true;
            // 
            // txtProveedorNombre
            // 
            this.txtProveedorNombre.Location = new System.Drawing.Point(332, 9);
            this.txtProveedorNombre.Name = "txtProveedorNombre";
            this.txtProveedorNombre.ReadOnly = true;
            this.txtProveedorNombre.Size = new System.Drawing.Size(359, 23);
            this.txtProveedorNombre.TabIndex = 21;
            // 
            // txtSerie
            // 
            this.txtSerie.Location = new System.Drawing.Point(102, 46);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(94, 23);
            this.txtSerie.TabIndex = 5;
            // 
            // spnPlazo
            // 
            this.spnPlazo.Location = new System.Drawing.Point(426, 46);
            this.spnPlazo.Name = "spnPlazo";
            this.spnPlazo.Size = new System.Drawing.Size(88, 23);
            this.spnPlazo.TabIndex = 9;
            // 
            // spnFolio
            // 
            this.spnFolio.Location = new System.Drawing.Point(287, 46);
            this.spnFolio.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.spnFolio.Name = "spnFolio";
            this.spnFolio.Size = new System.Drawing.Size(88, 23);
            this.spnFolio.TabIndex = 7;
            // 
            // cmdCFDiCargar
            // 
            this.cmdCFDiCargar.Image = ((System.Drawing.Image)(resources.GetObject("cmdCFDiCargar.Image")));
            this.cmdCFDiCargar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCFDiCargar.Location = new System.Drawing.Point(527, 37);
            this.cmdCFDiCargar.Name = "cmdCFDiCargar";
            this.cmdCFDiCargar.Size = new System.Drawing.Size(111, 41);
            this.cmdCFDiCargar.TabIndex = 22;
            this.cmdCFDiCargar.Text = "Cargar CFDi";
            this.cmdCFDiCargar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdCFDiCargar.UseVisualStyleBackColor = true;
            // 
            // cmdGuardar
            // 
            this.cmdGuardar.Image = ((System.Drawing.Image)(resources.GetObject("cmdGuardar.Image")));
            this.cmdGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdGuardar.Location = new System.Drawing.Point(298, 480);
            this.cmdGuardar.Name = "cmdGuardar";
            this.cmdGuardar.Size = new System.Drawing.Size(110, 48);
            this.cmdGuardar.TabIndex = 19;
            this.cmdGuardar.Text = "&Guardar";
            this.cmdGuardar.UseVisualStyleBackColor = true;
            // 
            // cmdSalir
            // 
            this.cmdSalir.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalir.Image")));
            this.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSalir.Location = new System.Drawing.Point(414, 480);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(110, 48);
            this.cmdSalir.TabIndex = 20;
            this.cmdSalir.Text = "&Salir";
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.BeforeTouchSize = new System.Drawing.Size(92, 26);
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(776, 440);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ShowCalculator = false;
            this.txtTotal.Size = new System.Drawing.Size(92, 26);
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
            this.txtTotal.TextBox.Size = new System.Drawing.Size(88, 18);
            this.txtTotal.TextBox.TabIndex = 0;
            this.txtTotal.TextBox.Text = "$0.00";
            this.txtTotal.TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotal.ThemeName = "WindowsXP";
            this.txtTotal.UseVisualStyle = true;
            // 
            // txtIVA
            // 
            this.txtIVA.BeforeTouchSize = new System.Drawing.Size(92, 26);
            this.txtIVA.Enabled = false;
            this.txtIVA.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIVA.Location = new System.Drawing.Point(776, 410);
            this.txtIVA.Name = "txtIVA";
            this.txtIVA.ShowCalculator = false;
            this.txtIVA.Size = new System.Drawing.Size(92, 26);
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
            this.txtIVA.TextBox.Size = new System.Drawing.Size(88, 18);
            this.txtIVA.TextBox.TabIndex = 0;
            this.txtIVA.TextBox.Text = "$0.00";
            this.txtIVA.TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIVA.ThemeName = "WindowsXP";
            this.txtIVA.UseVisualStyle = true;
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.BeforeTouchSize = new System.Drawing.Size(92, 26);
            this.txtSubTotal.Enabled = false;
            this.txtSubTotal.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubTotal.Location = new System.Drawing.Point(776, 380);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.ShowCalculator = false;
            this.txtSubTotal.Size = new System.Drawing.Size(92, 26);
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
            this.txtSubTotal.TextBox.Size = new System.Drawing.Size(88, 18);
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
            this.label9.Location = new System.Drawing.Point(724, 444);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 18);
            this.label9.TabIndex = 27;
            this.label9.Text = "Total";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(720, 414);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 18);
            this.label6.TabIndex = 25;
            this.label6.Text = "I.V.A.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(699, 384);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 18);
            this.label7.TabIndex = 23;
            this.label7.Text = "Subtotal";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(149, 421);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 16);
            this.label8.TabIndex = 14;
            this.label8.Text = "Costo";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(319, 385);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ReadOnly = true;
            this.txtDescripcion.Size = new System.Drawing.Size(359, 23);
            this.txtDescripcion.TabIndex = 29;
            // 
            // txtCantidad
            // 
            this.txtCantidad.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCantidad.Location = new System.Drawing.Point(67, 418);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(76, 23);
            this.txtCantidad.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtCantidad.TabIndex = 13;
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
            this.txtCosto.Location = new System.Drawing.Point(206, 418);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(107, 23);
            this.txtCosto.TabIndex = 15;
            this.txtCosto.Text = "$0.00";
            // 
            // cmdAgregar
            // 
            this.cmdAgregar.Image = ((System.Drawing.Image)(resources.GetObject("cmdAgregar.Image")));
            this.cmdAgregar.Location = new System.Drawing.Point(319, 414);
            this.cmdAgregar.Name = "cmdAgregar";
            this.cmdAgregar.Size = new System.Drawing.Size(35, 31);
            this.cmdAgregar.TabIndex = 16;
            this.toolTip1.SetToolTip(this.cmdAgregar, "Agregar artículo a la compra");
            this.cmdAgregar.UseVisualStyleBackColor = true;
            this.cmdAgregar.Click += new System.EventHandler(this.cmdAgregar_Click);
            // 
            // ComprasAltasCambios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 539);
            this.Controls.Add(this.cmdAgregar);
            this.Controls.Add(this.txtCosto);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label8);
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
            this.Controls.Add(this.label20);
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
        private System.Windows.Forms.Label label20;
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
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClaveProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClave;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImporte;
        private System.Windows.Forms.TextBox txtDescripcion;
        private Syncfusion.WinForms.Input.SfNumericTextBox txtCantidad;
        private Syncfusion.Windows.Forms.Tools.CurrencyTextBox txtCosto;
        private System.Windows.Forms.Button cmdAgregar;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}