namespace ClinicaFB.PuntoDeVenta
{
    partial class NotasDeCreditoListado
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotasDeCreditoListado));
            this.grdNotas = new System.Windows.Forms.DataGridView();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colserie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTimbrada = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colCancelada = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cmdBuscar = new System.Windows.Forms.Button();
            this.dtpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdEliminar = new System.Windows.Forms.Button();
            this.cmdModificar = new System.Windows.Forms.Button();
            this.cmdAgregar = new System.Windows.Forms.Button();
            this.cmdArchivos = new System.Windows.Forms.Button();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.cboAlmacenes = new Syncfusion.WinForms.ListView.SfComboBox();
            this.lblAlmacen = new System.Windows.Forms.Label();
            this.cboEmisores = new Syncfusion.WinForms.ListView.SfComboBox();
            this.label21 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdNotas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAlmacenes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmisores)).BeginInit();
            this.SuspendLayout();
            // 
            // grdNotas
            // 
            this.grdNotas.AllowUserToAddRows = false;
            this.grdNotas.AllowUserToDeleteRows = false;
            this.grdNotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdNotas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFecha,
            this.colserie,
            this.colTipo,
            this.colImporte,
            this.colTimbrada,
            this.colCancelada});
            this.grdNotas.Location = new System.Drawing.Point(12, 146);
            this.grdNotas.Name = "grdNotas";
            this.grdNotas.ReadOnly = true;
            this.grdNotas.Size = new System.Drawing.Size(442, 455);
            this.grdNotas.TabIndex = 48;
            // 
            // colFecha
            // 
            this.colFecha.DataPropertyName = "Fecha";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colFecha.DefaultCellStyle = dataGridViewCellStyle3;
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            this.colFecha.Width = 80;
            // 
            // colserie
            // 
            this.colserie.DataPropertyName = "Serie";
            this.colserie.HeaderText = "Serie";
            this.colserie.Name = "colserie";
            this.colserie.ReadOnly = true;
            this.colserie.Width = 50;
            // 
            // colTipo
            // 
            this.colTipo.DataPropertyName = "Folio";
            this.colTipo.HeaderText = "Folio";
            this.colTipo.Name = "colTipo";
            this.colTipo.ReadOnly = true;
            this.colTipo.Width = 80;
            // 
            // colImporte
            // 
            this.colImporte.DataPropertyName = "Total";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C2";
            this.colImporte.DefaultCellStyle = dataGridViewCellStyle4;
            this.colImporte.HeaderText = "Importe";
            this.colImporte.Name = "colImporte";
            this.colImporte.ReadOnly = true;
            this.colImporte.Width = 80;
            // 
            // colTimbrada
            // 
            this.colTimbrada.DataPropertyName = "Timbrada";
            this.colTimbrada.HeaderText = "Tim.";
            this.colTimbrada.Name = "colTimbrada";
            this.colTimbrada.ReadOnly = true;
            this.colTimbrada.Width = 50;
            // 
            // colCancelada
            // 
            this.colCancelada.DataPropertyName = "Cancelada";
            this.colCancelada.HeaderText = "Can.";
            this.colCancelada.Name = "colCancelada";
            this.colCancelada.ReadOnly = true;
            this.colCancelada.Width = 50;
            // 
            // cmdBuscar
            // 
            this.cmdBuscar.Location = new System.Drawing.Point(199, 91);
            this.cmdBuscar.Name = "cmdBuscar";
            this.cmdBuscar.Size = new System.Drawing.Size(75, 34);
            this.cmdBuscar.TabIndex = 4;
            this.cmdBuscar.Text = "&Buscar";
            this.cmdBuscar.UseVisualStyleBackColor = true;
            this.cmdBuscar.Click += new System.EventHandler(this.cmdBuscar_Click);
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFinal.Location = new System.Drawing.Point(94, 115);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(99, 23);
            this.dtpFechaFinal.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha final";
            // 
            // dtpFechaInicial
            // 
            this.dtpFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicial.Location = new System.Drawing.Point(94, 86);
            this.dtpFechaInicial.Name = "dtpFechaInicial";
            this.dtpFechaInicial.Size = new System.Drawing.Size(99, 23);
            this.dtpFechaInicial.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha inicial";
            // 
            // cmdEliminar
            // 
            this.cmdEliminar.Image = ((System.Drawing.Image)(resources.GetObject("cmdEliminar.Image")));
            this.cmdEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdEliminar.Location = new System.Drawing.Point(460, 232);
            this.cmdEliminar.Name = "cmdEliminar";
            this.cmdEliminar.Size = new System.Drawing.Size(116, 40);
            this.cmdEliminar.TabIndex = 7;
            this.cmdEliminar.Text = "&Eliminar";
            this.cmdEliminar.UseVisualStyleBackColor = true;
            this.cmdEliminar.Click += new System.EventHandler(this.cmdEliminar_Click);
            // 
            // cmdModificar
            // 
            this.cmdModificar.Image = ((System.Drawing.Image)(resources.GetObject("cmdModificar.Image")));
            this.cmdModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdModificar.Location = new System.Drawing.Point(460, 188);
            this.cmdModificar.Name = "cmdModificar";
            this.cmdModificar.Size = new System.Drawing.Size(116, 40);
            this.cmdModificar.TabIndex = 6;
            this.cmdModificar.Text = "&Modificar";
            this.cmdModificar.UseVisualStyleBackColor = true;
            this.cmdModificar.Click += new System.EventHandler(this.cmdModificar_Click);
            // 
            // cmdAgregar
            // 
            this.cmdAgregar.Image = ((System.Drawing.Image)(resources.GetObject("cmdAgregar.Image")));
            this.cmdAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAgregar.Location = new System.Drawing.Point(460, 144);
            this.cmdAgregar.Name = "cmdAgregar";
            this.cmdAgregar.Size = new System.Drawing.Size(116, 40);
            this.cmdAgregar.TabIndex = 5;
            this.cmdAgregar.Text = "&Agregar";
            this.cmdAgregar.UseVisualStyleBackColor = true;
            this.cmdAgregar.Click += new System.EventHandler(this.cmdAgregar_Click);
            // 
            // cmdArchivos
            // 
            this.cmdArchivos.Image = ((System.Drawing.Image)(resources.GetObject("cmdArchivos.Image")));
            this.cmdArchivos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdArchivos.Location = new System.Drawing.Point(460, 278);
            this.cmdArchivos.Name = "cmdArchivos";
            this.cmdArchivos.Size = new System.Drawing.Size(116, 40);
            this.cmdArchivos.TabIndex = 9;
            this.cmdArchivos.Text = "&Archivos";
            this.cmdArchivos.UseVisualStyleBackColor = true;
            this.cmdArchivos.Click += new System.EventHandler(this.cmdArchivos_Click);
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.Image = global::ClinicaFB.Properties.Resources.Cancelar20;
            this.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancelar.Location = new System.Drawing.Point(460, 324);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(116, 40);
            this.cmdCancelar.TabIndex = 11;
            this.cmdCancelar.Text = "&Cancelar";
            this.cmdCancelar.UseVisualStyleBackColor = true;
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
            // 
            // cmdSalir
            // 
            this.cmdSalir.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalir.Image")));
            this.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSalir.Location = new System.Drawing.Point(460, 368);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(116, 40);
            this.cmdSalir.TabIndex = 12;
            this.cmdSalir.Text = "&Salir";
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // cboAlmacenes
            // 
            this.cboAlmacenes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboAlmacenes.AutoCompleteSuggestMode = Syncfusion.WinForms.ListView.Enums.AutoCompleteSuggestMode.Contains;
            this.cboAlmacenes.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.cboAlmacenes.DropDownStyle = Syncfusion.WinForms.ListView.Enums.DropDownStyle.DropDownList;
            this.cboAlmacenes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cboAlmacenes.Location = new System.Drawing.Point(76, 46);
            this.cboAlmacenes.Name = "cboAlmacenes";
            this.cboAlmacenes.Size = new System.Drawing.Size(317, 28);
            this.cboAlmacenes.Style.DropDownStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cboAlmacenes.Style.EditorStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cboAlmacenes.Style.ReadOnlyEditorStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cboAlmacenes.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboAlmacenes.Style.TokenStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cboAlmacenes.TabIndex = 50;
            // 
            // lblAlmacen
            // 
            this.lblAlmacen.AutoSize = true;
            this.lblAlmacen.Location = new System.Drawing.Point(14, 52);
            this.lblAlmacen.Name = "lblAlmacen";
            this.lblAlmacen.Size = new System.Drawing.Size(56, 16);
            this.lblAlmacen.TabIndex = 49;
            this.lblAlmacen.Text = "Almacen";
            // 
            // cboEmisores
            // 
            this.cboEmisores.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboEmisores.AutoCompleteSuggestMode = Syncfusion.WinForms.ListView.Enums.AutoCompleteSuggestMode.Contains;
            this.cboEmisores.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.cboEmisores.DropDownStyle = Syncfusion.WinForms.ListView.Enums.DropDownStyle.DropDownList;
            this.cboEmisores.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cboEmisores.Location = new System.Drawing.Point(76, 12);
            this.cboEmisores.Name = "cboEmisores";
            this.cboEmisores.Size = new System.Drawing.Size(317, 28);
            this.cboEmisores.Style.DropDownStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cboEmisores.Style.EditorStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cboEmisores.Style.ReadOnlyEditorStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cboEmisores.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboEmisores.Style.TokenStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cboEmisores.TabIndex = 117;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(24, 18);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(46, 16);
            this.label21.TabIndex = 116;
            this.label21.Text = "Emisor";
            // 
            // NotasDeCreditoListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 613);
            this.Controls.Add(this.cboEmisores);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.cboAlmacenes);
            this.Controls.Add(this.lblAlmacen);
            this.Controls.Add(this.cmdEliminar);
            this.Controls.Add(this.cmdModificar);
            this.Controls.Add(this.cmdAgregar);
            this.Controls.Add(this.cmdArchivos);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.grdNotas);
            this.Controls.Add(this.cmdBuscar);
            this.Controls.Add(this.dtpFechaFinal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpFechaInicial);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "NotasDeCreditoListado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notas de credito";
            this.Load += new System.EventHandler(this.NotasDeCreditoListado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdNotas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAlmacenes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmisores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cmdArchivos;
        private System.Windows.Forms.Button cmdCancelar;
        private System.Windows.Forms.Button cmdSalir;
        private System.Windows.Forms.DataGridView grdNotas;
        private System.Windows.Forms.Button cmdBuscar;
        private System.Windows.Forms.DateTimePicker dtpFechaFinal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFechaInicial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdAgregar;
        private System.Windows.Forms.Button cmdModificar;
        private System.Windows.Forms.Button cmdEliminar;
        private Syncfusion.WinForms.ListView.SfComboBox cboAlmacenes;
        private System.Windows.Forms.Label lblAlmacen;
        private Syncfusion.WinForms.ListView.SfComboBox cboEmisores;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colserie;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImporte;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colTimbrada;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCancelada;
    }
}