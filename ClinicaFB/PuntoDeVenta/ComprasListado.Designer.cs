namespace ClinicaFB.PuntoDeVenta
{
    partial class ComprasListado
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComprasListado));
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdBuscar = new System.Windows.Forms.Button();
            this.grdCompras = new System.Windows.Forms.DataGridView();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSerie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFolio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCancelada = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.cmdModificar = new System.Windows.Forms.Button();
            this.cmdAgregar = new System.Windows.Forms.Button();
            this.cboAlmacenes = new Syncfusion.WinForms.ListView.SfComboBox();
            this.lblAlmacen = new System.Windows.Forms.Label();
            this.txtProveedorNombre = new System.Windows.Forms.TextBox();
            this.cmdProveedorBuscar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProveedorRFC = new System.Windows.Forms.TextBox();
            this.cmdBorrarProveedor = new System.Windows.Forms.Button();
            this.cmdImprimir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdCompras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAlmacenes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fecha inicial";
            // 
            // dtpFechaInicial
            // 
            this.dtpFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicial.Location = new System.Drawing.Point(95, 48);
            this.dtpFechaInicial.Name = "dtpFechaInicial";
            this.dtpFechaInicial.Size = new System.Drawing.Size(99, 23);
            this.dtpFechaInicial.TabIndex = 3;
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFinal.Location = new System.Drawing.Point(95, 77);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(99, 23);
            this.dtpFechaFinal.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Fecha final";
            // 
            // cmdBuscar
            // 
            this.cmdBuscar.Location = new System.Drawing.Point(200, 53);
            this.cmdBuscar.Name = "cmdBuscar";
            this.cmdBuscar.Size = new System.Drawing.Size(75, 34);
            this.cmdBuscar.TabIndex = 6;
            this.cmdBuscar.Text = "&Buscar";
            this.cmdBuscar.UseVisualStyleBackColor = true;
            this.cmdBuscar.Click += new System.EventHandler(this.cmdBuscar_Click);
            // 
            // grdCompras
            // 
            this.grdCompras.AllowUserToAddRows = false;
            this.grdCompras.AllowUserToDeleteRows = false;
            this.grdCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCompras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFecha,
            this.colProveedor,
            this.colImporte,
            this.colSerie,
            this.colFolio,
            this.colCancelada});
            this.grdCompras.Location = new System.Drawing.Point(15, 120);
            this.grdCompras.Name = "grdCompras";
            this.grdCompras.ReadOnly = true;
            this.grdCompras.Size = new System.Drawing.Size(726, 481);
            this.grdCompras.TabIndex = 12;
            this.grdCompras.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdCompras_CellDoubleClick);
            // 
            // colFecha
            // 
            this.colFecha.DataPropertyName = "Fecha";
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            this.colFecha.Width = 80;
            // 
            // colProveedor
            // 
            this.colProveedor.DataPropertyName = "ProveedorNombre";
            this.colProveedor.HeaderText = "Proveedor";
            this.colProveedor.Name = "colProveedor";
            this.colProveedor.ReadOnly = true;
            this.colProveedor.Width = 250;
            // 
            // colImporte
            // 
            this.colImporte.DataPropertyName = "Total";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "C2";
            this.colImporte.DefaultCellStyle = dataGridViewCellStyle1;
            this.colImporte.HeaderText = "Importe";
            this.colImporte.Name = "colImporte";
            this.colImporte.ReadOnly = true;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.colFolio.DefaultCellStyle = dataGridViewCellStyle2;
            this.colFolio.HeaderText = "Folio";
            this.colFolio.Name = "colFolio";
            this.colFolio.ReadOnly = true;
            this.colFolio.Width = 85;
            // 
            // colCancelada
            // 
            this.colCancelada.DataPropertyName = "Cancelado";
            this.colCancelada.HeaderText = "Cancelada";
            this.colCancelada.Name = "colCancelada";
            this.colCancelada.ReadOnly = true;
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancelar.Image")));
            this.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancelar.Location = new System.Drawing.Point(747, 199);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(126, 35);
            this.cmdCancelar.TabIndex = 9;
            this.cmdCancelar.Text = "&Cancelar";
            this.cmdCancelar.UseVisualStyleBackColor = true;
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
            // 
            // cmdSalir
            // 
            this.cmdSalir.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalir.Image")));
            this.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSalir.Location = new System.Drawing.Point(747, 281);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(126, 35);
            this.cmdSalir.TabIndex = 11;
            this.cmdSalir.Text = "&Salir";
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // cmdModificar
            // 
            this.cmdModificar.Image = ((System.Drawing.Image)(resources.GetObject("cmdModificar.Image")));
            this.cmdModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdModificar.Location = new System.Drawing.Point(747, 158);
            this.cmdModificar.Name = "cmdModificar";
            this.cmdModificar.Size = new System.Drawing.Size(126, 35);
            this.cmdModificar.TabIndex = 8;
            this.cmdModificar.Text = "&Modificar";
            this.cmdModificar.UseVisualStyleBackColor = true;
            this.cmdModificar.Click += new System.EventHandler(this.cmdModificar_Click);
            // 
            // cmdAgregar
            // 
            this.cmdAgregar.Image = ((System.Drawing.Image)(resources.GetObject("cmdAgregar.Image")));
            this.cmdAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAgregar.Location = new System.Drawing.Point(747, 117);
            this.cmdAgregar.Name = "cmdAgregar";
            this.cmdAgregar.Size = new System.Drawing.Size(126, 35);
            this.cmdAgregar.TabIndex = 7;
            this.cmdAgregar.Text = "&Agregar";
            this.cmdAgregar.UseVisualStyleBackColor = true;
            this.cmdAgregar.Click += new System.EventHandler(this.cmdAgregar_Click);
            // 
            // cboAlmacenes
            // 
            this.cboAlmacenes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboAlmacenes.AutoCompleteSuggestMode = Syncfusion.WinForms.ListView.Enums.AutoCompleteSuggestMode.Contains;
            this.cboAlmacenes.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.cboAlmacenes.DropDownStyle = Syncfusion.WinForms.ListView.Enums.DropDownStyle.DropDownList;
            this.cboAlmacenes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cboAlmacenes.Location = new System.Drawing.Point(95, 12);
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
            this.lblAlmacen.Location = new System.Drawing.Point(33, 18);
            this.lblAlmacen.Name = "lblAlmacen";
            this.lblAlmacen.Size = new System.Drawing.Size(56, 16);
            this.lblAlmacen.TabIndex = 0;
            this.lblAlmacen.Text = "Almacen";
            // 
            // txtProveedorNombre
            // 
            this.txtProveedorNombre.Location = new System.Drawing.Point(298, 84);
            this.txtProveedorNombre.Name = "txtProveedorNombre";
            this.txtProveedorNombre.ReadOnly = true;
            this.txtProveedorNombre.Size = new System.Drawing.Size(414, 23);
            this.txtProveedorNombre.TabIndex = 17;
            // 
            // cmdProveedorBuscar
            // 
            this.cmdProveedorBuscar.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.cmdProveedorBuscar.Location = new System.Drawing.Point(364, 53);
            this.cmdProveedorBuscar.Name = "cmdProveedorBuscar";
            this.cmdProveedorBuscar.Size = new System.Drawing.Size(38, 26);
            this.cmdProveedorBuscar.TabIndex = 14;
            this.cmdProveedorBuscar.Text = "...";
            this.cmdProveedorBuscar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdProveedorBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.cmdProveedorBuscar.UseVisualStyleBackColor = true;
            this.cmdProveedorBuscar.Click += new System.EventHandler(this.cmdProveedorBuscar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(295, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Proveedor";
            // 
            // txtProveedorRFC
            // 
            this.txtProveedorRFC.Location = new System.Drawing.Point(452, 56);
            this.txtProveedorRFC.Name = "txtProveedorRFC";
            this.txtProveedorRFC.ReadOnly = true;
            this.txtProveedorRFC.Size = new System.Drawing.Size(182, 23);
            this.txtProveedorRFC.TabIndex = 16;
            // 
            // cmdBorrarProveedor
            // 
            this.cmdBorrarProveedor.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBorrarProveedor.ForeColor = System.Drawing.Color.Red;
            this.cmdBorrarProveedor.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.cmdBorrarProveedor.Location = new System.Drawing.Point(408, 53);
            this.cmdBorrarProveedor.Name = "cmdBorrarProveedor";
            this.cmdBorrarProveedor.Size = new System.Drawing.Size(38, 26);
            this.cmdBorrarProveedor.TabIndex = 15;
            this.cmdBorrarProveedor.Text = "X";
            this.cmdBorrarProveedor.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdBorrarProveedor.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.cmdBorrarProveedor.UseVisualStyleBackColor = true;
            this.cmdBorrarProveedor.Click += new System.EventHandler(this.cmdBorrarProveedor_Click);
            // 
            // cmdImprimir
            // 
            this.cmdImprimir.Image = ((System.Drawing.Image)(resources.GetObject("cmdImprimir.Image")));
            this.cmdImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdImprimir.Location = new System.Drawing.Point(747, 240);
            this.cmdImprimir.Name = "cmdImprimir";
            this.cmdImprimir.Size = new System.Drawing.Size(126, 35);
            this.cmdImprimir.TabIndex = 10;
            this.cmdImprimir.Text = "&Imprimir";
            this.cmdImprimir.UseVisualStyleBackColor = true;
            this.cmdImprimir.Click += new System.EventHandler(this.cmdImprimir_Click);
            // 
            // ComprasListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 609);
            this.Controls.Add(this.cmdImprimir);
            this.Controls.Add(this.cmdBorrarProveedor);
            this.Controls.Add(this.txtProveedorRFC);
            this.Controls.Add(this.txtProveedorNombre);
            this.Controls.Add(this.cmdProveedorBuscar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboAlmacenes);
            this.Controls.Add(this.lblAlmacen);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.cmdModificar);
            this.Controls.Add(this.cmdAgregar);
            this.Controls.Add(this.grdCompras);
            this.Controls.Add(this.cmdBuscar);
            this.Controls.Add(this.dtpFechaFinal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpFechaInicial);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ComprasListado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compras";
            this.Load += new System.EventHandler(this.ComprasListado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdCompras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAlmacenes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFechaInicial;
        private System.Windows.Forms.DateTimePicker dtpFechaFinal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdBuscar;
        private System.Windows.Forms.DataGridView grdCompras;
        private System.Windows.Forms.Button cmdCancelar;
        private System.Windows.Forms.Button cmdSalir;
        private System.Windows.Forms.Button cmdModificar;
        private System.Windows.Forms.Button cmdAgregar;
        private Syncfusion.WinForms.ListView.SfComboBox cboAlmacenes;
        private System.Windows.Forms.Label lblAlmacen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImporte;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSerie;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFolio;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCancelada;
        private System.Windows.Forms.TextBox txtProveedorNombre;
        private System.Windows.Forms.Button cmdProveedorBuscar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProveedorRFC;
        private System.Windows.Forms.Button cmdBorrarProveedor;
        private System.Windows.Forms.Button cmdImprimir;
    }
}