namespace ClinicaFB.PuntoDeVenta
{
    partial class FacturaGlobal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FacturaGlobal));
            this.grdVentas = new System.Windows.Forms.DataGridView();
            this.colFacturar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colserie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdBuscar = new System.Windows.Forms.Button();
            this.dtpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdGenerar = new System.Windows.Forms.Button();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.cboAlmacenes = new Syncfusion.WinForms.ListView.SfComboBox();
            this.lblAlmacen = new System.Windows.Forms.Label();
            this.cmdTodas = new System.Windows.Forms.Button();
            this.cmdNinguna = new System.Windows.Forms.Button();
            this.cmdInvertir = new System.Windows.Forms.Button();
            this.cboEmisores = new Syncfusion.WinForms.ListView.SfComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cmdVer = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbDetallada = new System.Windows.Forms.RadioButton();
            this.rbResumida = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdVentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAlmacenes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmisores)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdVentas
            // 
            this.grdVentas.AllowUserToAddRows = false;
            this.grdVentas.AllowUserToDeleteRows = false;
            this.grdVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFacturar,
            this.colFecha,
            this.colserie,
            this.colTipo,
            this.colImporte});
            this.grdVentas.Location = new System.Drawing.Point(20, 176);
            this.grdVentas.Name = "grdVentas";
            this.grdVentas.Size = new System.Drawing.Size(448, 363);
            this.grdVentas.TabIndex = 8;
            // 
            // colFacturar
            // 
            this.colFacturar.DataPropertyName = "Facturar";
            this.colFacturar.HeaderText = "Facturar";
            this.colFacturar.Name = "colFacturar";
            // 
            // colFecha
            // 
            this.colFecha.DataPropertyName = "Fecha";
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            this.colFecha.Width = 80;
            // 
            // colserie
            // 
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
            this.colImporte.DataPropertyName = "Tot";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "C2";
            this.colImporte.DefaultCellStyle = dataGridViewCellStyle1;
            this.colImporte.HeaderText = "Importe";
            this.colImporte.Name = "colImporte";
            this.colImporte.ReadOnly = true;
            this.colImporte.Width = 80;
            // 
            // cmdBuscar
            // 
            this.cmdBuscar.Location = new System.Drawing.Point(205, 79);
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
            this.dtpFechaFinal.Location = new System.Drawing.Point(100, 103);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(99, 23);
            this.dtpFechaFinal.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha final";
            // 
            // dtpFechaInicial
            // 
            this.dtpFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicial.Location = new System.Drawing.Point(100, 74);
            this.dtpFechaInicial.Name = "dtpFechaInicial";
            this.dtpFechaInicial.Size = new System.Drawing.Size(99, 23);
            this.dtpFechaInicial.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha inicial";
            // 
            // cmdGenerar
            // 
            this.cmdGenerar.Image = ((System.Drawing.Image)(resources.GetObject("cmdGenerar.Image")));
            this.cmdGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdGenerar.Location = new System.Drawing.Point(127, 545);
            this.cmdGenerar.Name = "cmdGenerar";
            this.cmdGenerar.Size = new System.Drawing.Size(116, 40);
            this.cmdGenerar.TabIndex = 9;
            this.cmdGenerar.Text = "&Generar";
            this.cmdGenerar.UseVisualStyleBackColor = true;
            this.cmdGenerar.Click += new System.EventHandler(this.cmdGenerar_Click);
            // 
            // cmdSalir
            // 
            this.cmdSalir.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalir.Image")));
            this.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSalir.Location = new System.Drawing.Point(249, 545);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(116, 40);
            this.cmdSalir.TabIndex = 10;
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
            this.cboAlmacenes.Location = new System.Drawing.Point(79, 40);
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
            this.lblAlmacen.Location = new System.Drawing.Point(18, 46);
            this.lblAlmacen.Name = "lblAlmacen";
            this.lblAlmacen.Size = new System.Drawing.Size(56, 16);
            this.lblAlmacen.TabIndex = 0;
            this.lblAlmacen.Text = "Almacen";
            // 
            // cmdTodas
            // 
            this.cmdTodas.Location = new System.Drawing.Point(19, 136);
            this.cmdTodas.Name = "cmdTodas";
            this.cmdTodas.Size = new System.Drawing.Size(75, 34);
            this.cmdTodas.TabIndex = 5;
            this.cmdTodas.Text = "&Todas";
            this.cmdTodas.UseVisualStyleBackColor = true;
            this.cmdTodas.Click += new System.EventHandler(this.cmdTodas_Click);
            // 
            // cmdNinguna
            // 
            this.cmdNinguna.Location = new System.Drawing.Point(100, 136);
            this.cmdNinguna.Name = "cmdNinguna";
            this.cmdNinguna.Size = new System.Drawing.Size(75, 34);
            this.cmdNinguna.TabIndex = 6;
            this.cmdNinguna.Text = "&Ninguna";
            this.cmdNinguna.UseVisualStyleBackColor = true;
            this.cmdNinguna.Click += new System.EventHandler(this.cmdNinguna_Click);
            // 
            // cmdInvertir
            // 
            this.cmdInvertir.Location = new System.Drawing.Point(181, 136);
            this.cmdInvertir.Name = "cmdInvertir";
            this.cmdInvertir.Size = new System.Drawing.Size(75, 34);
            this.cmdInvertir.TabIndex = 7;
            this.cmdInvertir.Text = "&Invertir";
            this.cmdInvertir.UseVisualStyleBackColor = true;
            this.cmdInvertir.Click += new System.EventHandler(this.cmdInvertir_Click);
            // 
            // cboEmisores
            // 
            this.cboEmisores.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboEmisores.AutoCompleteSuggestMode = Syncfusion.WinForms.ListView.Enums.AutoCompleteSuggestMode.Contains;
            this.cboEmisores.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.cboEmisores.DropDownStyle = Syncfusion.WinForms.ListView.Enums.DropDownStyle.DropDownList;
            this.cboEmisores.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cboEmisores.Location = new System.Drawing.Point(79, 6);
            this.cboEmisores.Name = "cboEmisores";
            this.cboEmisores.Size = new System.Drawing.Size(317, 28);
            this.cboEmisores.Style.DropDownStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cboEmisores.Style.EditorStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cboEmisores.Style.ReadOnlyEditorStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cboEmisores.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboEmisores.Style.TokenStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cboEmisores.TabIndex = 22;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(27, 12);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(46, 16);
            this.label21.TabIndex = 21;
            this.label21.Text = "Emisor";
            // 
            // cmdVer
            // 
            this.cmdVer.Location = new System.Drawing.Point(474, 176);
            this.cmdVer.Name = "cmdVer";
            this.cmdVer.Size = new System.Drawing.Size(70, 34);
            this.cmdVer.TabIndex = 23;
            this.cmdVer.Text = "&Ver";
            this.cmdVer.UseVisualStyleBackColor = true;
            this.cmdVer.Click += new System.EventHandler(this.cmdVer_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbResumida);
            this.groupBox1.Controls.Add(this.rbDetallada);
            this.groupBox1.Location = new System.Drawing.Point(308, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(160, 81);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de factura";
            // 
            // rbDetallada
            // 
            this.rbDetallada.AutoSize = true;
            this.rbDetallada.Checked = true;
            this.rbDetallada.Location = new System.Drawing.Point(7, 23);
            this.rbDetallada.Name = "rbDetallada";
            this.rbDetallada.Size = new System.Drawing.Size(147, 20);
            this.rbDetallada.TabIndex = 0;
            this.rbDetallada.TabStop = true;
            this.rbDetallada.Text = "Detallada por artículo";
            this.rbDetallada.UseVisualStyleBackColor = true;
            // 
            // rbResumida
            // 
            this.rbResumida.AutoSize = true;
            this.rbResumida.Location = new System.Drawing.Point(6, 49);
            this.rbResumida.Name = "rbResumida";
            this.rbResumida.Size = new System.Drawing.Size(148, 20);
            this.rbResumida.TabIndex = 1;
            this.rbResumida.Text = "Resumida solo tickets";
            this.rbResumida.UseVisualStyleBackColor = true;
            // 
            // FacturaGlobal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 597);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdVer);
            this.Controls.Add(this.cboEmisores);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.cmdInvertir);
            this.Controls.Add(this.cmdNinguna);
            this.Controls.Add(this.cmdTodas);
            this.Controls.Add(this.cboAlmacenes);
            this.Controls.Add(this.lblAlmacen);
            this.Controls.Add(this.cmdGenerar);
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.grdVentas);
            this.Controls.Add(this.cmdBuscar);
            this.Controls.Add(this.dtpFechaFinal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpFechaInicial);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FacturaGlobal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generar factura global";
            this.Load += new System.EventHandler(this.FacturaGlobal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdVentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAlmacenes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEmisores)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdVentas;
        private System.Windows.Forms.Button cmdBuscar;
        private System.Windows.Forms.DateTimePicker dtpFechaFinal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFechaInicial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdGenerar;
        private System.Windows.Forms.Button cmdSalir;
        private Syncfusion.WinForms.ListView.SfComboBox cboAlmacenes;
        private System.Windows.Forms.Label lblAlmacen;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colFacturar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colserie;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImporte;
        private System.Windows.Forms.Button cmdTodas;
        private System.Windows.Forms.Button cmdNinguna;
        private System.Windows.Forms.Button cmdInvertir;
        private Syncfusion.WinForms.ListView.SfComboBox cboEmisores;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button cmdVer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbResumida;
        private System.Windows.Forms.RadioButton rbDetallada;
    }
}