namespace ClinicaFB.PuntoDeVenta
{
    partial class EntradasSalidasAltasCambios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntradasSalidasAltasCambios));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboConceptos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdModificar = new System.Windows.Forms.Button();
            this.cmdBorrar = new System.Windows.Forms.Button();
            this.grdArticulos = new System.Windows.Forms.DataGridView();
            this.colClave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExistencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spnCantidad = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.txtConcepto = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cmdGuardar = new System.Windows.Forms.Button();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFolio = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTotal = new Syncfusion.Windows.Forms.Tools.CurrencyEdit();
            this.txtIVA = new Syncfusion.Windows.Forms.Tools.CurrencyEdit();
            this.txtSubTotal = new Syncfusion.Windows.Forms.Tools.CurrencyEdit();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmdImportar = new System.Windows.Forms.Button();
            this.lblConsumidos = new System.Windows.Forms.Label();
            this.sfToolTip1 = new Syncfusion.Windows.Forms.SfToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grdArticulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIVA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIVA.TextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubTotal.TextBox)).BeginInit();
            this.SuspendLayout();
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObservaciones.Location = new System.Drawing.Point(110, 580);
            this.txtObservaciones.MaxLength = 300;
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(357, 43);
            this.txtObservaciones.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 580);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Observaciones";
            // 
            // cboConceptos
            // 
            this.cboConceptos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboConceptos.FormattingEnabled = true;
            this.cboConceptos.Items.AddRange(new object[] {
            "Caducidad",
            "Devolución a proveedor",
            "Ajuste de inventario",
            "Devolución  a paciente"});
            this.cboConceptos.Location = new System.Drawing.Point(139, 19);
            this.cboConceptos.Name = "cboConceptos";
            this.cboConceptos.Size = new System.Drawing.Size(255, 24);
            this.cboConceptos.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Concepto";
            // 
            // cmdModificar
            // 
            this.cmdModificar.Image = ((System.Drawing.Image)(resources.GetObject("cmdModificar.Image")));
            this.cmdModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdModificar.Location = new System.Drawing.Point(767, 113);
            this.cmdModificar.Name = "cmdModificar";
            this.cmdModificar.Size = new System.Drawing.Size(107, 35);
            this.cmdModificar.TabIndex = 4;
            this.cmdModificar.Text = "&Modificar";
            this.cmdModificar.UseVisualStyleBackColor = true;
            this.cmdModificar.Click += new System.EventHandler(this.cmdModificar_Click);
            // 
            // cmdBorrar
            // 
            this.cmdBorrar.Image = ((System.Drawing.Image)(resources.GetObject("cmdBorrar.Image")));
            this.cmdBorrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdBorrar.Location = new System.Drawing.Point(767, 154);
            this.cmdBorrar.Name = "cmdBorrar";
            this.cmdBorrar.Size = new System.Drawing.Size(107, 35);
            this.cmdBorrar.TabIndex = 5;
            this.cmdBorrar.Text = "&Borrar";
            this.cmdBorrar.UseVisualStyleBackColor = true;
            this.cmdBorrar.Click += new System.EventHandler(this.cmdBorrar_Click);
            // 
            // grdArticulos
            // 
            this.grdArticulos.AllowUserToAddRows = false;
            this.grdArticulos.AllowUserToDeleteRows = false;
            this.grdArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdArticulos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colClave,
            this.colDescripcion,
            this.colExistencia,
            this.colPrecio,
            this.colImporte});
            this.grdArticulos.Location = new System.Drawing.Point(17, 112);
            this.grdArticulos.Name = "grdArticulos";
            this.grdArticulos.ReadOnly = true;
            this.grdArticulos.Size = new System.Drawing.Size(744, 393);
            this.grdArticulos.TabIndex = 44;
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
            this.colDescripcion.HeaderText = "Artículo";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.ReadOnly = true;
            this.colDescripcion.Width = 250;
            // 
            // colExistencia
            // 
            this.colExistencia.DataPropertyName = "Cantidad";
            this.colExistencia.HeaderText = "Cantidad";
            this.colExistencia.Name = "colExistencia";
            this.colExistencia.ReadOnly = true;
            // 
            // colPrecio
            // 
            this.colPrecio.DataPropertyName = "Precio";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.colPrecio.DefaultCellStyle = dataGridViewCellStyle3;
            this.colPrecio.HeaderText = "Valor uni.";
            this.colPrecio.Name = "colPrecio";
            this.colPrecio.ReadOnly = true;
            this.colPrecio.Width = 120;
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
            this.colImporte.Width = 120;
            // 
            // spnCantidad
            // 
            this.spnCantidad.DecimalPlaces = 4;
            this.spnCantidad.Location = new System.Drawing.Point(441, 48);
            this.spnCantidad.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.spnCantidad.Name = "spnCantidad";
            this.spnCantidad.Size = new System.Drawing.Size(80, 23);
            this.spnCantidad.TabIndex = 3;
            this.spnCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.spnCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spnCantidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.spnCantidad_KeyDown);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(416, 51);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(14, 16);
            this.label20.TabIndex = 2;
            this.label20.Text = "x";
            // 
            // txtConcepto
            // 
            this.txtConcepto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtConcepto.Location = new System.Drawing.Point(139, 48);
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(271, 23);
            this.txtConcepto.TabIndex = 1;
            this.txtConcepto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtConcepto_KeyDown);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(9, 51);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(125, 16);
            this.label19.TabIndex = 0;
            this.label19.Text = "Artículo (F5=Buscar)";
            // 
            // cmdGuardar
            // 
            this.cmdGuardar.Image = ((System.Drawing.Image)(resources.GetObject("cmdGuardar.Image")));
            this.cmdGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdGuardar.Location = new System.Drawing.Point(270, 511);
            this.cmdGuardar.Name = "cmdGuardar";
            this.cmdGuardar.Size = new System.Drawing.Size(110, 48);
            this.cmdGuardar.TabIndex = 8;
            this.cmdGuardar.Text = "&Guardar";
            this.cmdGuardar.UseVisualStyleBackColor = true;
            this.cmdGuardar.Click += new System.EventHandler(this.cmdGuardar_Click);
            // 
            // cmdSalir
            // 
            this.cmdSalir.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalir.Image")));
            this.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSalir.Location = new System.Drawing.Point(386, 511);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(110, 48);
            this.cmdSalir.TabIndex = 9;
            this.cmdSalir.Text = "&Salir";
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(441, 19);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(110, 23);
            this.dtpFecha.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(394, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Fecha";
            // 
            // txtSerie
            // 
            this.txtSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSerie.Location = new System.Drawing.Point(637, 19);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.ReadOnly = true;
            this.txtSerie.Size = new System.Drawing.Size(124, 23);
            this.txtSerie.TabIndex = 46;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(594, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 16);
            this.label4.TabIndex = 45;
            this.label4.Text = "Serie";
            // 
            // txtFolio
            // 
            this.txtFolio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFolio.Location = new System.Drawing.Point(637, 48);
            this.txtFolio.Name = "txtFolio";
            this.txtFolio.ReadOnly = true;
            this.txtFolio.Size = new System.Drawing.Size(124, 23);
            this.txtFolio.TabIndex = 48;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(594, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 16);
            this.label5.TabIndex = 47;
            this.label5.Text = "Folio";
            // 
            // txtTotal
            // 
            this.txtTotal.BeforeTouchSize = new System.Drawing.Size(125, 26);
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(636, 570);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ShowCalculator = false;
            this.txtTotal.Size = new System.Drawing.Size(125, 26);
            this.txtTotal.TabIndex = 54;
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
            this.txtTotal.TextBox.Size = new System.Drawing.Size(121, 18);
            this.txtTotal.TextBox.TabIndex = 0;
            this.txtTotal.TextBox.Text = "$0.00";
            this.txtTotal.TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotal.ThemeName = "WindowsXP";
            this.txtTotal.UseVisualStyle = true;
            // 
            // txtIVA
            // 
            this.txtIVA.BeforeTouchSize = new System.Drawing.Size(125, 26);
            this.txtIVA.Enabled = false;
            this.txtIVA.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIVA.Location = new System.Drawing.Point(636, 540);
            this.txtIVA.Name = "txtIVA";
            this.txtIVA.ShowCalculator = false;
            this.txtIVA.Size = new System.Drawing.Size(125, 26);
            this.txtIVA.TabIndex = 52;
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
            this.txtIVA.TextBox.Size = new System.Drawing.Size(121, 18);
            this.txtIVA.TextBox.TabIndex = 0;
            this.txtIVA.TextBox.Text = "$0.00";
            this.txtIVA.TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIVA.ThemeName = "WindowsXP";
            this.txtIVA.UseVisualStyle = true;
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.BeforeTouchSize = new System.Drawing.Size(125, 26);
            this.txtSubTotal.Enabled = false;
            this.txtSubTotal.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubTotal.Location = new System.Drawing.Point(636, 510);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.ShowCalculator = false;
            this.txtSubTotal.Size = new System.Drawing.Size(125, 26);
            this.txtSubTotal.TabIndex = 50;
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
            this.txtSubTotal.TextBox.Size = new System.Drawing.Size(121, 18);
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
            this.label9.Location = new System.Drawing.Point(584, 574);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 18);
            this.label9.TabIndex = 53;
            this.label9.Text = "Total";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(580, 544);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 18);
            this.label6.TabIndex = 51;
            this.label6.Text = "I.V.A.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(559, 514);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 18);
            this.label7.TabIndex = 49;
            this.label7.Text = "Subtotal";
            // 
            // cmdImportar
            // 
            this.cmdImportar.Image = ((System.Drawing.Image)(resources.GetObject("cmdImportar.Image")));
            this.cmdImportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdImportar.Location = new System.Drawing.Point(767, 195);
            this.cmdImportar.Name = "cmdImportar";
            this.cmdImportar.Size = new System.Drawing.Size(107, 35);
            this.cmdImportar.TabIndex = 55;
            this.cmdImportar.Text = "&Importar";
            this.cmdImportar.UseVisualStyleBackColor = true;
            this.cmdImportar.Click += new System.EventHandler(this.cmdImportar_Click);
            // 
            // lblConsumidos
            // 
            this.lblConsumidos.AutoSize = true;
            this.lblConsumidos.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsumidos.ForeColor = System.Drawing.Color.Red;
            this.lblConsumidos.Location = new System.Drawing.Point(14, 83);
            this.lblConsumidos.Name = "lblConsumidos";
            this.lblConsumidos.Size = new System.Drawing.Size(713, 16);
            this.lblConsumidos.TabIndex = 56;
            this.lblConsumidos.Text = "** EL DOCUMENTO Y LOS ARTÍCULOS NO SE PUEDEN MODIFICAR PORQUE ALGUN(OS) HAN SIDO " +
    "CONSUMIDOS ***";
            this.lblConsumidos.Visible = false;
            // 
            // EntradasSalidasAltasCambios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 643);
            this.Controls.Add(this.lblConsumidos);
            this.Controls.Add(this.cmdImportar);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.txtIVA);
            this.Controls.Add(this.txtSubTotal);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtFolio);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSerie);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboConceptos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdModificar);
            this.Controls.Add(this.cmdBorrar);
            this.Controls.Add(this.grdArticulos);
            this.Controls.Add(this.spnCantidad);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.txtConcepto);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.cmdGuardar);
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "EntradasSalidasAltasCambios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EntradasSalidasAltasCambios";
            this.Load += new System.EventHandler(this.EntradasSalidasAltasCambios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdArticulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIVA.TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIVA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubTotal.TextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubTotal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboConceptos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdModificar;
        private System.Windows.Forms.Button cmdBorrar;
        private System.Windows.Forms.DataGridView grdArticulos;
        private System.Windows.Forms.NumericUpDown spnCantidad;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtConcepto;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button cmdGuardar;
        private System.Windows.Forms.Button cmdSalir;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClave;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExistencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImporte;
        private System.Windows.Forms.TextBox txtSerie;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFolio;
        private System.Windows.Forms.Label label5;
        private Syncfusion.Windows.Forms.Tools.CurrencyEdit txtTotal;
        private Syncfusion.Windows.Forms.Tools.CurrencyEdit txtIVA;
        private Syncfusion.Windows.Forms.Tools.CurrencyEdit txtSubTotal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button cmdImportar;
        private System.Windows.Forms.Label lblConsumidos;
        private Syncfusion.Windows.Forms.SfToolTip sfToolTip1;
    }
}