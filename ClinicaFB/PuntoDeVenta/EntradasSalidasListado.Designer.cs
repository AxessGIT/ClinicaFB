namespace ClinicaFB.PuntoDeVenta
{
    partial class EntradasSalidasListado
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntradasSalidasListado));
            this.grdDocumentos = new System.Windows.Forms.DataGridView();
            this.colSerie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFolio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConcepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCancelado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dtpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cboAlmacenes = new Syncfusion.WinForms.ListView.SfComboBox();
            this.lblAlmacen = new System.Windows.Forms.Label();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.cmdModificar = new System.Windows.Forms.Button();
            this.cmdAgregar = new System.Windows.Forms.Button();
            this.cmdBuscar = new System.Windows.Forms.Button();
            this.cmdArchivoPDF = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdDocumentos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAlmacenes)).BeginInit();
            this.SuspendLayout();
            // 
            // grdDocumentos
            // 
            this.grdDocumentos.AllowUserToAddRows = false;
            this.grdDocumentos.AllowUserToDeleteRows = false;
            this.grdDocumentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDocumentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSerie,
            this.colFolio,
            this.colFecha,
            this.colConcepto,
            this.colCancelado});
            this.grdDocumentos.Location = new System.Drawing.Point(34, 116);
            this.grdDocumentos.Margin = new System.Windows.Forms.Padding(4);
            this.grdDocumentos.Name = "grdDocumentos";
            this.grdDocumentos.ReadOnly = true;
            this.grdDocumentos.Size = new System.Drawing.Size(630, 423);
            this.grdDocumentos.TabIndex = 43;
            this.grdDocumentos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdDocumentos_CellDoubleClick);
            // 
            // colSerie
            // 
            this.colSerie.DataPropertyName = "Serie";
            this.colSerie.HeaderText = "Serie";
            this.colSerie.Name = "colSerie";
            this.colSerie.ReadOnly = true;
            this.colSerie.Width = 50;
            // 
            // colFolio
            // 
            this.colFolio.DataPropertyName = "Folio";
            this.colFolio.HeaderText = "Folio";
            this.colFolio.Name = "colFolio";
            this.colFolio.ReadOnly = true;
            this.colFolio.Width = 80;
            // 
            // colFecha
            // 
            this.colFecha.DataPropertyName = "Fecha";
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            // 
            // colConcepto
            // 
            this.colConcepto.DataPropertyName = "ConceptoNombre";
            dataGridViewCellStyle1.Format = "C2";
            this.colConcepto.DefaultCellStyle = dataGridViewCellStyle1;
            this.colConcepto.HeaderText = "Tipo";
            this.colConcepto.Name = "colConcepto";
            this.colConcepto.ReadOnly = true;
            this.colConcepto.Width = 250;
            // 
            // colCancelado
            // 
            this.colCancelado.DataPropertyName = "Cancelado";
            this.colCancelado.HeaderText = "Cancelado";
            this.colCancelado.Name = "colCancelado";
            this.colCancelado.ReadOnly = true;
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFinal.Location = new System.Drawing.Point(128, 78);
            this.dtpFechaFinal.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(115, 23);
            this.dtpFechaFinal.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 81);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Fecha final";
            // 
            // dtpFechaInicial
            // 
            this.dtpFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicial.Location = new System.Drawing.Point(128, 47);
            this.dtpFechaInicial.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFechaInicial.Name = "dtpFechaInicial";
            this.dtpFechaInicial.Size = new System.Drawing.Size(115, 23);
            this.dtpFechaInicial.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fecha inicial";
            // 
            // cboAlmacenes
            // 
            this.cboAlmacenes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboAlmacenes.AutoCompleteSuggestMode = Syncfusion.WinForms.ListView.Enums.AutoCompleteSuggestMode.Contains;
            this.cboAlmacenes.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.cboAlmacenes.DropDownStyle = Syncfusion.WinForms.ListView.Enums.DropDownStyle.DropDownList;
            this.cboAlmacenes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cboAlmacenes.Location = new System.Drawing.Point(128, 12);
            this.cboAlmacenes.Name = "cboAlmacenes";
            this.cboAlmacenes.Size = new System.Drawing.Size(317, 28);
            this.cboAlmacenes.Style.DropDownStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cboAlmacenes.Style.EditorStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cboAlmacenes.Style.ReadOnlyEditorStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cboAlmacenes.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboAlmacenes.Style.TokenStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cboAlmacenes.TabIndex = 1;
            // 
            // lblAlmacen
            // 
            this.lblAlmacen.AutoSize = true;
            this.lblAlmacen.Location = new System.Drawing.Point(66, 18);
            this.lblAlmacen.Name = "lblAlmacen";
            this.lblAlmacen.Size = new System.Drawing.Size(56, 16);
            this.lblAlmacen.TabIndex = 0;
            this.lblAlmacen.Text = "Almacen";
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancelar.Image")));
            this.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancelar.Location = new System.Drawing.Point(672, 262);
            this.cmdCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(147, 43);
            this.cmdCancelar.TabIndex = 9;
            this.cmdCancelar.Text = "&Borrar";
            this.cmdCancelar.UseVisualStyleBackColor = true;
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
            // 
            // cmdSalir
            // 
            this.cmdSalir.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalir.Image")));
            this.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSalir.Location = new System.Drawing.Point(672, 311);
            this.cmdSalir.Margin = new System.Windows.Forms.Padding(4);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(147, 43);
            this.cmdSalir.TabIndex = 10;
            this.cmdSalir.Text = "&Salir";
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // cmdModificar
            // 
            this.cmdModificar.Image = ((System.Drawing.Image)(resources.GetObject("cmdModificar.Image")));
            this.cmdModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdModificar.Location = new System.Drawing.Point(672, 167);
            this.cmdModificar.Margin = new System.Windows.Forms.Padding(4);
            this.cmdModificar.Name = "cmdModificar";
            this.cmdModificar.Size = new System.Drawing.Size(147, 43);
            this.cmdModificar.TabIndex = 8;
            this.cmdModificar.Text = "&Modificar";
            this.cmdModificar.UseVisualStyleBackColor = true;
            this.cmdModificar.Click += new System.EventHandler(this.cmdModificar_Click);
            // 
            // cmdAgregar
            // 
            this.cmdAgregar.Image = ((System.Drawing.Image)(resources.GetObject("cmdAgregar.Image")));
            this.cmdAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAgregar.Location = new System.Drawing.Point(672, 118);
            this.cmdAgregar.Margin = new System.Windows.Forms.Padding(4);
            this.cmdAgregar.Name = "cmdAgregar";
            this.cmdAgregar.Size = new System.Drawing.Size(147, 43);
            this.cmdAgregar.TabIndex = 7;
            this.cmdAgregar.Text = "&Agregar";
            this.cmdAgregar.UseVisualStyleBackColor = true;
            this.cmdAgregar.Click += new System.EventHandler(this.cmdAgregar_Click);
            // 
            // cmdBuscar
            // 
            this.cmdBuscar.Image = global::ClinicaFB.Properties.Resources.Buscar201;
            this.cmdBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdBuscar.Location = new System.Drawing.Point(254, 54);
            this.cmdBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.cmdBuscar.Name = "cmdBuscar";
            this.cmdBuscar.Size = new System.Drawing.Size(71, 34);
            this.cmdBuscar.TabIndex = 6;
            this.cmdBuscar.Text = "&Buscar";
            this.cmdBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdBuscar.UseVisualStyleBackColor = true;
            this.cmdBuscar.Click += new System.EventHandler(this.cmdBuscar_Click);
            // 
            // cmdArchivoPDF
            // 
            this.cmdArchivoPDF.Image = ((System.Drawing.Image)(resources.GetObject("cmdArchivoPDF.Image")));
            this.cmdArchivoPDF.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdArchivoPDF.Location = new System.Drawing.Point(672, 216);
            this.cmdArchivoPDF.Name = "cmdArchivoPDF";
            this.cmdArchivoPDF.Size = new System.Drawing.Size(147, 40);
            this.cmdArchivoPDF.TabIndex = 44;
            this.cmdArchivoPDF.Text = "&Archivo PDF";
            this.cmdArchivoPDF.UseVisualStyleBackColor = true;
            this.cmdArchivoPDF.Click += new System.EventHandler(this.cmdArchivoPDF_Click);
            // 
            // EntradasSalidasListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 551);
            this.Controls.Add(this.cmdArchivoPDF);
            this.Controls.Add(this.cboAlmacenes);
            this.Controls.Add(this.lblAlmacen);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.cmdModificar);
            this.Controls.Add(this.cmdAgregar);
            this.Controls.Add(this.grdDocumentos);
            this.Controls.Add(this.cmdBuscar);
            this.Controls.Add(this.dtpFechaFinal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpFechaInicial);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "EntradasSalidasListado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EntradasSalidasListado";
            this.Load += new System.EventHandler(this.EntradasSalidasListado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDocumentos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAlmacenes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCancelar;
        private System.Windows.Forms.Button cmdSalir;
        private System.Windows.Forms.Button cmdModificar;
        private System.Windows.Forms.Button cmdAgregar;
        private System.Windows.Forms.DataGridView grdDocumentos;
        private System.Windows.Forms.Button cmdBuscar;
        private System.Windows.Forms.DateTimePicker dtpFechaFinal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFechaInicial;
        private System.Windows.Forms.Label label1;
        private Syncfusion.WinForms.ListView.SfComboBox cboAlmacenes;
        private System.Windows.Forms.Label lblAlmacen;
        private System.Windows.Forms.Button cmdArchivoPDF;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSerie;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFolio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConcepto;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCancelado;
    }
}