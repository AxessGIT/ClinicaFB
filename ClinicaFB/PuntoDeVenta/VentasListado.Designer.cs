namespace ClinicaFB.PuntoDeVenta
{
    partial class VentasListado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentasListado));
            this.grdVentas = new System.Windows.Forms.DataGridView();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colserie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTimbrada = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colSerieFac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFolioFac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCancelada = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cmdBuscar = new System.Windows.Forms.Button();
            this.dtpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.cmdTicket = new System.Windows.Forms.Button();
            this.cmdFacturar = new System.Windows.Forms.Button();
            this.cmdVer = new System.Windows.Forms.Button();
            this.cmdMandarCorreo = new System.Windows.Forms.Button();
            this.cmdArchivos = new System.Windows.Forms.Button();
            this.cmdReportes = new System.Windows.Forms.Button();
            this.cboAlmacenes = new Syncfusion.WinForms.ListView.SfComboBox();
            this.lblAlmacen = new System.Windows.Forms.Label();
            this.cmdModificar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdVentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAlmacenes)).BeginInit();
            this.SuspendLayout();
            // 
            // grdVentas
            // 
            this.grdVentas.AllowUserToAddRows = false;
            this.grdVentas.AllowUserToDeleteRows = false;
            this.grdVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFecha,
            this.colserie,
            this.colTipo,
            this.colProveedor,
            this.colImporte,
            this.colTimbrada,
            this.colSerieFac,
            this.colFolioFac,
            this.colCancelada});
            this.grdVentas.Location = new System.Drawing.Point(12, 113);
            this.grdVentas.Name = "grdVentas";
            this.grdVentas.ReadOnly = true;
            this.grdVentas.Size = new System.Drawing.Size(798, 506);
            this.grdVentas.TabIndex = 15;
            this.grdVentas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdVentas_CellDoubleClick);
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
            // colProveedor
            // 
            this.colProveedor.DataPropertyName = "ClienteNom";
            this.colProveedor.HeaderText = "Cliente";
            this.colProveedor.Name = "colProveedor";
            this.colProveedor.ReadOnly = true;
            this.colProveedor.Width = 200;
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
            // colTimbrada
            // 
            this.colTimbrada.DataPropertyName = "Timbrada";
            this.colTimbrada.HeaderText = "Tim.";
            this.colTimbrada.Name = "colTimbrada";
            this.colTimbrada.ReadOnly = true;
            this.colTimbrada.Width = 50;
            // 
            // colSerieFac
            // 
            this.colSerieFac.DataPropertyName = "SerieFac";
            this.colSerieFac.HeaderText = "Serie Fac.";
            this.colSerieFac.Name = "colSerieFac";
            this.colSerieFac.ReadOnly = true;
            this.colSerieFac.Width = 80;
            // 
            // colFolioFac
            // 
            this.colFolioFac.DataPropertyName = "FolioFac";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "######";
            this.colFolioFac.DefaultCellStyle = dataGridViewCellStyle2;
            this.colFolioFac.HeaderText = "Folio Fac.";
            this.colFolioFac.Name = "colFolioFac";
            this.colFolioFac.ReadOnly = true;
            this.colFolioFac.Width = 80;
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
            this.cmdBuscar.Location = new System.Drawing.Point(197, 53);
            this.cmdBuscar.Name = "cmdBuscar";
            this.cmdBuscar.Size = new System.Drawing.Size(75, 34);
            this.cmdBuscar.TabIndex = 6;
            this.cmdBuscar.Text = "&Buscar";
            this.cmdBuscar.UseVisualStyleBackColor = true;
            this.cmdBuscar.Click += new System.EventHandler(this.cmdBuscar_Click);
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFinal.Location = new System.Drawing.Point(92, 77);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(99, 23);
            this.dtpFechaFinal.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Fecha final";
            // 
            // dtpFechaInicial
            // 
            this.dtpFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicial.Location = new System.Drawing.Point(92, 48);
            this.dtpFechaInicial.Name = "dtpFechaInicial";
            this.dtpFechaInicial.Size = new System.Drawing.Size(99, 23);
            this.dtpFechaInicial.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fecha inicial";
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.Image = global::ClinicaFB.Properties.Resources.Cancelar20;
            this.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancelar.Location = new System.Drawing.Point(816, 379);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(116, 40);
            this.cmdCancelar.TabIndex = 12;
            this.cmdCancelar.Text = "&Cancelar";
            this.cmdCancelar.UseVisualStyleBackColor = true;
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
            // 
            // cmdSalir
            // 
            this.cmdSalir.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalir.Image")));
            this.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSalir.Location = new System.Drawing.Point(816, 423);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(116, 40);
            this.cmdSalir.TabIndex = 13;
            this.cmdSalir.Text = "&Salir";
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // cmdTicket
            // 
            this.cmdTicket.Image = ((System.Drawing.Image)(resources.GetObject("cmdTicket.Image")));
            this.cmdTicket.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdTicket.Location = new System.Drawing.Point(816, 291);
            this.cmdTicket.Name = "cmdTicket";
            this.cmdTicket.Size = new System.Drawing.Size(116, 40);
            this.cmdTicket.TabIndex = 10;
            this.cmdTicket.Text = "&Ticket";
            this.cmdTicket.UseVisualStyleBackColor = true;
            this.cmdTicket.Click += new System.EventHandler(this.cmdTicket_Click);
            // 
            // cmdFacturar
            // 
            this.cmdFacturar.Image = ((System.Drawing.Image)(resources.GetObject("cmdFacturar.Image")));
            this.cmdFacturar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdFacturar.Location = new System.Drawing.Point(816, 335);
            this.cmdFacturar.Name = "cmdFacturar";
            this.cmdFacturar.Size = new System.Drawing.Size(116, 40);
            this.cmdFacturar.TabIndex = 11;
            this.cmdFacturar.Text = "&Facturar";
            this.cmdFacturar.UseVisualStyleBackColor = true;
            this.cmdFacturar.Click += new System.EventHandler(this.cmdFacturar_Click);
            // 
            // cmdVer
            // 
            this.cmdVer.Image = ((System.Drawing.Image)(resources.GetObject("cmdVer.Image")));
            this.cmdVer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdVer.Location = new System.Drawing.Point(816, 159);
            this.cmdVer.Name = "cmdVer";
            this.cmdVer.Size = new System.Drawing.Size(116, 40);
            this.cmdVer.TabIndex = 7;
            this.cmdVer.Text = "&Ver";
            this.cmdVer.UseVisualStyleBackColor = true;
            this.cmdVer.Click += new System.EventHandler(this.cmdVer_Click);
            // 
            // cmdMandarCorreo
            // 
            this.cmdMandarCorreo.Image = ((System.Drawing.Image)(resources.GetObject("cmdMandarCorreo.Image")));
            this.cmdMandarCorreo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdMandarCorreo.Location = new System.Drawing.Point(816, 247);
            this.cmdMandarCorreo.Name = "cmdMandarCorreo";
            this.cmdMandarCorreo.Size = new System.Drawing.Size(116, 40);
            this.cmdMandarCorreo.TabIndex = 9;
            this.cmdMandarCorreo.Text = "&Enviar";
            this.cmdMandarCorreo.UseVisualStyleBackColor = true;
            this.cmdMandarCorreo.Click += new System.EventHandler(this.cmdMandarCorreo_Click);
            // 
            // cmdArchivos
            // 
            this.cmdArchivos.Image = ((System.Drawing.Image)(resources.GetObject("cmdArchivos.Image")));
            this.cmdArchivos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdArchivos.Location = new System.Drawing.Point(816, 203);
            this.cmdArchivos.Name = "cmdArchivos";
            this.cmdArchivos.Size = new System.Drawing.Size(116, 40);
            this.cmdArchivos.TabIndex = 8;
            this.cmdArchivos.Text = "&Archivos";
            this.cmdArchivos.UseVisualStyleBackColor = true;
            this.cmdArchivos.Click += new System.EventHandler(this.cmdArchivos_Click);
            // 
            // cmdReportes
            // 
            this.cmdReportes.Location = new System.Drawing.Point(667, 66);
            this.cmdReportes.Name = "cmdReportes";
            this.cmdReportes.Size = new System.Drawing.Size(143, 34);
            this.cmdReportes.TabIndex = 14;
            this.cmdReportes.Text = "&Reportes del corte";
            this.cmdReportes.UseVisualStyleBackColor = true;
            this.cmdReportes.Click += new System.EventHandler(this.cmdReportes_Click);
            // 
            // cboAlmacenes
            // 
            this.cboAlmacenes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboAlmacenes.AutoCompleteSuggestMode = Syncfusion.WinForms.ListView.Enums.AutoCompleteSuggestMode.Contains;
            this.cboAlmacenes.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.cboAlmacenes.DropDownStyle = Syncfusion.WinForms.ListView.Enums.DropDownStyle.DropDownList;
            this.cboAlmacenes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.cboAlmacenes.Location = new System.Drawing.Point(71, 12);
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
            this.lblAlmacen.Location = new System.Drawing.Point(9, 18);
            this.lblAlmacen.Name = "lblAlmacen";
            this.lblAlmacen.Size = new System.Drawing.Size(56, 16);
            this.lblAlmacen.TabIndex = 0;
            this.lblAlmacen.Text = "Almacen";
            // 
            // cmdModificar
            // 
            this.cmdModificar.Image = ((System.Drawing.Image)(resources.GetObject("cmdModificar.Image")));
            this.cmdModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdModificar.Location = new System.Drawing.Point(816, 113);
            this.cmdModificar.Name = "cmdModificar";
            this.cmdModificar.Size = new System.Drawing.Size(116, 40);
            this.cmdModificar.TabIndex = 16;
            this.cmdModificar.Text = "&Modificar";
            this.cmdModificar.UseVisualStyleBackColor = true;
            this.cmdModificar.Click += new System.EventHandler(this.cmdModificar_Click);
            // 
            // VentasListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 631);
            this.Controls.Add(this.cmdModificar);
            this.Controls.Add(this.cboAlmacenes);
            this.Controls.Add(this.lblAlmacen);
            this.Controls.Add(this.cmdReportes);
            this.Controls.Add(this.cmdMandarCorreo);
            this.Controls.Add(this.cmdArchivos);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.cmdTicket);
            this.Controls.Add(this.cmdFacturar);
            this.Controls.Add(this.cmdVer);
            this.Controls.Add(this.grdVentas);
            this.Controls.Add(this.cmdBuscar);
            this.Controls.Add(this.dtpFechaFinal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpFechaInicial);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "VentasListado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ventas";
            this.Load += new System.EventHandler(this.VentasListado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdVentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboAlmacenes)).EndInit();
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
        private System.Windows.Forms.Button cmdCancelar;
        private System.Windows.Forms.Button cmdSalir;
        private System.Windows.Forms.Button cmdTicket;
        private System.Windows.Forms.Button cmdFacturar;
        private System.Windows.Forms.Button cmdVer;
        private System.Windows.Forms.Button cmdMandarCorreo;
        private System.Windows.Forms.Button cmdArchivos;
        private System.Windows.Forms.Button cmdReportes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colserie;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImporte;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colTimbrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSerieFac;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFolioFac;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCancelada;
        private Syncfusion.WinForms.ListView.SfComboBox cboAlmacenes;
        private System.Windows.Forms.Label lblAlmacen;
        private System.Windows.Forms.Button cmdModificar;
    }
}