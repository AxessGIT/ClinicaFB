namespace ClinicaFB.PuntoDeVenta
{
    partial class SalidasAltasCambios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalidasAltasCambios));
            this.label2 = new System.Windows.Forms.Label();
            this.cboAlmacenes = new Syncfusion.WinForms.ListView.SfComboBox();
            this.lblAlmacen = new System.Windows.Forms.Label();
            this.cmdModificar = new System.Windows.Forms.Button();
            this.cmdBorrar = new System.Windows.Forms.Button();
            this.grdArticulos = new System.Windows.Forms.DataGridView();
            this.colClave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExistencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spnCantidad = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.txtConcepto = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cmdGuardar = new System.Windows.Forms.Button();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTipos = new System.Windows.Forms.ComboBox();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cboAlmacenes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdArticulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 16);
            this.label2.TabIndex = 25;
            this.label2.Text = "Tipo de salida";
            // 
            // cboAlmacenes
            // 
            this.cboAlmacenes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboAlmacenes.AutoCompleteSuggestMode = Syncfusion.WinForms.ListView.Enums.AutoCompleteSuggestMode.Contains;
            this.cboAlmacenes.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.cboAlmacenes.DropDownStyle = Syncfusion.WinForms.ListView.Enums.DropDownStyle.DropDownList;
            this.cboAlmacenes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cboAlmacenes.Location = new System.Drawing.Point(118, 12);
            this.cboAlmacenes.Name = "cboAlmacenes";
            this.cboAlmacenes.Size = new System.Drawing.Size(317, 28);
            this.cboAlmacenes.Style.DropDownStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cboAlmacenes.Style.EditorStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cboAlmacenes.Style.ReadOnlyEditorStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cboAlmacenes.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboAlmacenes.Style.TokenStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cboAlmacenes.TabIndex = 24;
            // 
            // lblAlmacen
            // 
            this.lblAlmacen.AutoSize = true;
            this.lblAlmacen.Location = new System.Drawing.Point(25, 18);
            this.lblAlmacen.Name = "lblAlmacen";
            this.lblAlmacen.Size = new System.Drawing.Size(56, 16);
            this.lblAlmacen.TabIndex = 23;
            this.lblAlmacen.Text = "Almacen";
            // 
            // cmdModificar
            // 
            this.cmdModificar.Image = ((System.Drawing.Image)(resources.GetObject("cmdModificar.Image")));
            this.cmdModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdModificar.Location = new System.Drawing.Point(568, 119);
            this.cmdModificar.Name = "cmdModificar";
            this.cmdModificar.Size = new System.Drawing.Size(98, 35);
            this.cmdModificar.TabIndex = 19;
            this.cmdModificar.Text = "&Modificar";
            this.cmdModificar.UseVisualStyleBackColor = true;
            this.cmdModificar.Click += new System.EventHandler(this.cmdModificar_Click);
            // 
            // cmdBorrar
            // 
            this.cmdBorrar.Image = ((System.Drawing.Image)(resources.GetObject("cmdBorrar.Image")));
            this.cmdBorrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdBorrar.Location = new System.Drawing.Point(568, 160);
            this.cmdBorrar.Name = "cmdBorrar";
            this.cmdBorrar.Size = new System.Drawing.Size(98, 35);
            this.cmdBorrar.TabIndex = 20;
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
            this.colExistencia});
            this.grdArticulos.Location = new System.Drawing.Point(28, 119);
            this.grdArticulos.Name = "grdArticulos";
            this.grdArticulos.ReadOnly = true;
            this.grdArticulos.Size = new System.Drawing.Size(534, 379);
            this.grdArticulos.TabIndex = 29;
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
            // spnCantidad
            // 
            this.spnCantidad.DecimalPlaces = 4;
            this.spnCantidad.Location = new System.Drawing.Point(409, 89);
            this.spnCantidad.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.spnCantidad.Name = "spnCantidad";
            this.spnCantidad.Size = new System.Drawing.Size(80, 23);
            this.spnCantidad.TabIndex = 18;
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
            this.label20.Location = new System.Drawing.Point(390, 92);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(14, 16);
            this.label20.TabIndex = 17;
            this.label20.Text = "x";
            // 
            // txtConcepto
            // 
            this.txtConcepto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtConcepto.Location = new System.Drawing.Point(165, 89);
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(219, 23);
            this.txtConcepto.TabIndex = 16;
            this.txtConcepto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtConcepto_KeyDown);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(25, 92);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(125, 16);
            this.label19.TabIndex = 15;
            this.label19.Text = "Artículo (F5=Buscar)";
            // 
            // cmdGuardar
            // 
            this.cmdGuardar.Image = ((System.Drawing.Image)(resources.GetObject("cmdGuardar.Image")));
            this.cmdGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdGuardar.Location = new System.Drawing.Point(178, 602);
            this.cmdGuardar.Name = "cmdGuardar";
            this.cmdGuardar.Size = new System.Drawing.Size(110, 48);
            this.cmdGuardar.TabIndex = 21;
            this.cmdGuardar.Text = "&Guardar";
            this.cmdGuardar.UseVisualStyleBackColor = true;
            this.cmdGuardar.Click += new System.EventHandler(this.cmdGuardar_Click);
            // 
            // cmdSalir
            // 
            this.cmdSalir.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalir.Image")));
            this.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSalir.Location = new System.Drawing.Point(294, 602);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(110, 48);
            this.cmdSalir.TabIndex = 22;
            this.cmdSalir.Text = "&Salir";
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(526, 15);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(110, 23);
            this.dtpFecha.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(479, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 27;
            this.label1.Text = "Fecha";
            // 
            // cboTipos
            // 
            this.cboTipos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipos.FormattingEnabled = true;
            this.cboTipos.Items.AddRange(new object[] {
            "Caducidad",
            "Devolución a proveedor",
            "Ajuste de inventario",
            "Devolución  a paciente"});
            this.cboTipos.Location = new System.Drawing.Point(118, 48);
            this.cboTipos.Name = "cboTipos";
            this.cboTipos.Size = new System.Drawing.Size(255, 24);
            this.cboTipos.TabIndex = 30;
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtObservaciones.Location = new System.Drawing.Point(123, 507);
            this.txtObservaciones.MaxLength = 300;
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(397, 89);
            this.txtObservaciones.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 507);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 16);
            this.label3.TabIndex = 31;
            this.label3.Text = "Observaciones";
            // 
            // SalidasAltasCambios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 659);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboTipos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboAlmacenes);
            this.Controls.Add(this.lblAlmacen);
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
            this.Name = "SalidasAltasCambios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SalidasAltasCambios";
            this.Load += new System.EventHandler(this.SalidasAltasCambios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboAlmacenes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdArticulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnCantidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private Syncfusion.WinForms.ListView.SfComboBox cboAlmacenes;
        private System.Windows.Forms.Label lblAlmacen;
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
        private System.Windows.Forms.ComboBox cboTipos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClave;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExistencia;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label label3;
    }
}