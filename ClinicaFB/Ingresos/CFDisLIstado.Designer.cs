namespace ClinicaFB.Ingresos
{
    partial class CFDisLIstado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFDisLIstado));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboEmisores = new System.Windows.Forms.ComboBox();
            this.dtpFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.cmdBuscar = new System.Windows.Forms.Button();
            this.grdCfdis = new System.Windows.Forms.DataGridView();
            this.colEmisor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSerie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFolio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaciente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRazonSocial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImporte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCancelado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cmdVer = new System.Windows.Forms.Button();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.cmdArchivos = new System.Windows.Forms.Button();
            this.cmdCerrar = new System.Windows.Forms.Button();
            this.cmdReporte = new System.Windows.Forms.Button();
            this.cmdMandarCorreo = new System.Windows.Forms.Button();
            this.cmdImprimir = new System.Windows.Forms.Button();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.cmdBuscaRazonSocial = new System.Windows.Forms.Button();
            this.txtRFC = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdCfdis)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Emisor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(368, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha inicial";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(578, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha final";
            // 
            // cboEmisores
            // 
            this.cboEmisores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmisores.FormattingEnabled = true;
            this.cboEmisores.Location = new System.Drawing.Point(64, 13);
            this.cboEmisores.Name = "cboEmisores";
            this.cboEmisores.Size = new System.Drawing.Size(298, 24);
            this.cboEmisores.TabIndex = 1;
            // 
            // dtpFechaInicial
            // 
            this.dtpFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicial.Location = new System.Drawing.Point(451, 14);
            this.dtpFechaInicial.Name = "dtpFechaInicial";
            this.dtpFechaInicial.Size = new System.Drawing.Size(121, 23);
            this.dtpFechaInicial.TabIndex = 3;
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFinal.Location = new System.Drawing.Point(653, 14);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(121, 23);
            this.dtpFechaFinal.TabIndex = 5;
            // 
            // cmdBuscar
            // 
            this.cmdBuscar.Location = new System.Drawing.Point(780, 10);
            this.cmdBuscar.Name = "cmdBuscar";
            this.cmdBuscar.Size = new System.Drawing.Size(80, 29);
            this.cmdBuscar.TabIndex = 6;
            this.cmdBuscar.Text = "&Buscar";
            this.cmdBuscar.UseVisualStyleBackColor = true;
            this.cmdBuscar.Click += new System.EventHandler(this.cmdBuscar_Click);
            // 
            // grdCfdis
            // 
            this.grdCfdis.AllowUserToAddRows = false;
            this.grdCfdis.AllowUserToDeleteRows = false;
            this.grdCfdis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCfdis.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEmisor,
            this.colFecha,
            this.colSerie,
            this.colFolio,
            this.colPaciente,
            this.colRazonSocial,
            this.colImporte,
            this.colCancelado});
            this.grdCfdis.Location = new System.Drawing.Point(15, 72);
            this.grdCfdis.Name = "grdCfdis";
            this.grdCfdis.ReadOnly = true;
            this.grdCfdis.Size = new System.Drawing.Size(998, 448);
            this.grdCfdis.TabIndex = 14;
            // 
            // colEmisor
            // 
            this.colEmisor.HeaderText = "Emisor";
            this.colEmisor.Name = "colEmisor";
            this.colEmisor.ReadOnly = true;
            // 
            // colFecha
            // 
            this.colFecha.HeaderText = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            // 
            // colSerie
            // 
            this.colSerie.HeaderText = "Serie";
            this.colSerie.Name = "colSerie";
            this.colSerie.ReadOnly = true;
            // 
            // colFolio
            // 
            this.colFolio.HeaderText = "Folio";
            this.colFolio.Name = "colFolio";
            this.colFolio.ReadOnly = true;
            // 
            // colPaciente
            // 
            this.colPaciente.HeaderText = "Paciente";
            this.colPaciente.Name = "colPaciente";
            this.colPaciente.ReadOnly = true;
            // 
            // colRazonSocial
            // 
            this.colRazonSocial.HeaderText = "Razon Social";
            this.colRazonSocial.Name = "colRazonSocial";
            this.colRazonSocial.ReadOnly = true;
            // 
            // colImporte
            // 
            this.colImporte.HeaderText = "Importe";
            this.colImporte.Name = "colImporte";
            this.colImporte.ReadOnly = true;
            // 
            // colCancelado
            // 
            this.colCancelado.HeaderText = "Cancelada";
            this.colCancelado.Name = "colCancelado";
            this.colCancelado.ReadOnly = true;
            // 
            // cmdVer
            // 
            this.cmdVer.Image = ((System.Drawing.Image)(resources.GetObject("cmdVer.Image")));
            this.cmdVer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdVer.Location = new System.Drawing.Point(1019, 71);
            this.cmdVer.Name = "cmdVer";
            this.cmdVer.Size = new System.Drawing.Size(132, 43);
            this.cmdVer.TabIndex = 7;
            this.cmdVer.Text = "&Ver";
            this.cmdVer.UseVisualStyleBackColor = true;
            this.cmdVer.Click += new System.EventHandler(this.cmdVer_Click);
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancelar.Image")));
            this.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancelar.Location = new System.Drawing.Point(1019, 316);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(132, 43);
            this.cmdCancelar.TabIndex = 12;
            this.cmdCancelar.Text = "&Cancelar";
            this.cmdCancelar.UseVisualStyleBackColor = true;
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
            // 
            // cmdArchivos
            // 
            this.cmdArchivos.Image = ((System.Drawing.Image)(resources.GetObject("cmdArchivos.Image")));
            this.cmdArchivos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdArchivos.Location = new System.Drawing.Point(1019, 120);
            this.cmdArchivos.Name = "cmdArchivos";
            this.cmdArchivos.Size = new System.Drawing.Size(132, 43);
            this.cmdArchivos.TabIndex = 8;
            this.cmdArchivos.Text = "&Archivos";
            this.cmdArchivos.UseVisualStyleBackColor = true;
            this.cmdArchivos.Click += new System.EventHandler(this.cmdArchivos_Click);
            // 
            // cmdCerrar
            // 
            this.cmdCerrar.Image = ((System.Drawing.Image)(resources.GetObject("cmdCerrar.Image")));
            this.cmdCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCerrar.Location = new System.Drawing.Point(1019, 365);
            this.cmdCerrar.Name = "cmdCerrar";
            this.cmdCerrar.Size = new System.Drawing.Size(132, 43);
            this.cmdCerrar.TabIndex = 15;
            this.cmdCerrar.Text = "C&errar";
            this.cmdCerrar.UseVisualStyleBackColor = true;
            this.cmdCerrar.Click += new System.EventHandler(this.cmdCerrar_Click);
            // 
            // cmdReporte
            // 
            this.cmdReporte.Image = ((System.Drawing.Image)(resources.GetObject("cmdReporte.Image")));
            this.cmdReporte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdReporte.Location = new System.Drawing.Point(1019, 267);
            this.cmdReporte.Name = "cmdReporte";
            this.cmdReporte.Size = new System.Drawing.Size(132, 43);
            this.cmdReporte.TabIndex = 11;
            this.cmdReporte.Text = "&Reporte";
            this.cmdReporte.UseVisualStyleBackColor = true;
            this.cmdReporte.Click += new System.EventHandler(this.cmdReeporte_Click);
            // 
            // cmdMandarCorreo
            // 
            this.cmdMandarCorreo.Image = ((System.Drawing.Image)(resources.GetObject("cmdMandarCorreo.Image")));
            this.cmdMandarCorreo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdMandarCorreo.Location = new System.Drawing.Point(1019, 218);
            this.cmdMandarCorreo.Name = "cmdMandarCorreo";
            this.cmdMandarCorreo.Size = new System.Drawing.Size(132, 43);
            this.cmdMandarCorreo.TabIndex = 10;
            this.cmdMandarCorreo.Text = "&Enviar";
            this.cmdMandarCorreo.UseVisualStyleBackColor = true;
            this.cmdMandarCorreo.Click += new System.EventHandler(this.cmdMandarCorreo_Click);
            // 
            // cmdImprimir
            // 
            this.cmdImprimir.Image = ((System.Drawing.Image)(resources.GetObject("cmdImprimir.Image")));
            this.cmdImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdImprimir.Location = new System.Drawing.Point(1019, 169);
            this.cmdImprimir.Name = "cmdImprimir";
            this.cmdImprimir.Size = new System.Drawing.Size(132, 43);
            this.cmdImprimir.TabIndex = 9;
            this.cmdImprimir.Text = "&Imprimir";
            this.cmdImprimir.UseVisualStyleBackColor = true;
            this.cmdImprimir.Click += new System.EventHandler(this.cmdImprimir_Click);
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocial.Location = new System.Drawing.Point(269, 43);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.ReadOnly = true;
            this.txtRazonSocial.Size = new System.Drawing.Size(340, 23);
            this.txtRazonSocial.TabIndex = 53;
            this.txtRazonSocial.Text = "PUBLICO EN GENERAL";
            // 
            // cmdBuscaRazonSocial
            // 
            this.cmdBuscaRazonSocial.Location = new System.Drawing.Point(615, 43);
            this.cmdBuscaRazonSocial.Name = "cmdBuscaRazonSocial";
            this.cmdBuscaRazonSocial.Size = new System.Drawing.Size(36, 23);
            this.cmdBuscaRazonSocial.TabIndex = 50;
            this.cmdBuscaRazonSocial.Text = "...";
            this.cmdBuscaRazonSocial.UseVisualStyleBackColor = true;
            this.cmdBuscaRazonSocial.Click += new System.EventHandler(this.cmdBuscaRazonSocial_Click);
            // 
            // txtRFC
            // 
            this.txtRFC.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRFC.Location = new System.Drawing.Point(107, 43);
            this.txtRFC.Name = "txtRFC";
            this.txtRFC.ReadOnly = true;
            this.txtRFC.Size = new System.Drawing.Size(156, 23);
            this.txtRFC.TabIndex = 52;
            this.txtRFC.Text = "XAXX010101000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 16);
            this.label4.TabIndex = 51;
            this.label4.Text = "Razón social";
            // 
            // CFDisLIstado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1160, 532);
            this.Controls.Add(this.txtRazonSocial);
            this.Controls.Add(this.cmdBuscaRazonSocial);
            this.Controls.Add(this.txtRFC);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmdImprimir);
            this.Controls.Add(this.cmdMandarCorreo);
            this.Controls.Add(this.cmdReporte);
            this.Controls.Add(this.cmdVer);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdArchivos);
            this.Controls.Add(this.cmdCerrar);
            this.Controls.Add(this.grdCfdis);
            this.Controls.Add(this.cmdBuscar);
            this.Controls.Add(this.dtpFechaFinal);
            this.Controls.Add(this.dtpFechaInicial);
            this.Controls.Add(this.cboEmisores);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "CFDisLIstado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado de facturas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CFDisLIstado_FormClosing);
            this.Load += new System.EventHandler(this.CFDisLIstado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdCfdis)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboEmisores;
        private System.Windows.Forms.DateTimePicker dtpFechaInicial;
        private System.Windows.Forms.DateTimePicker dtpFechaFinal;
        private System.Windows.Forms.Button cmdBuscar;
        private System.Windows.Forms.DataGridView grdCfdis;
        private System.Windows.Forms.Button cmdCerrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmisor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSerie;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFolio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaciente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRazonSocial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImporte;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCancelado;
        private System.Windows.Forms.Button cmdArchivos;
        private System.Windows.Forms.Button cmdCancelar;
        private System.Windows.Forms.Button cmdVer;
        private System.Windows.Forms.Button cmdReporte;
        private System.Windows.Forms.Button cmdMandarCorreo;
        private System.Windows.Forms.Button cmdImprimir;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.Button cmdBuscaRazonSocial;
        private System.Windows.Forms.TextBox txtRFC;
        private System.Windows.Forms.Label label4;
    }
}