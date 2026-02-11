namespace ClinicaFB.Ingresos
{
    partial class IngresosListado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IngresosListado));
            this.grdIngresos = new System.Windows.Forms.DataGridView();
            this.dtpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdExportar = new System.Windows.Forms.Button();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.cmdTicket = new System.Windows.Forms.Button();
            this.cmdFacturar = new System.Windows.Forms.Button();
            this.cmdVer = new System.Windows.Forms.Button();
            this.cmdBuscar = new System.Windows.Forms.Button();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.cmdBuscaRazonSocial = new System.Windows.Forms.Button();
            this.txtRFC = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdIngresos)).BeginInit();
            this.SuspendLayout();
            // 
            // grdIngresos
            // 
            this.grdIngresos.AllowUserToAddRows = false;
            this.grdIngresos.AllowUserToDeleteRows = false;
            this.grdIngresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdIngresos.Location = new System.Drawing.Point(11, 104);
            this.grdIngresos.Name = "grdIngresos";
            this.grdIngresos.ReadOnly = true;
            this.grdIngresos.Size = new System.Drawing.Size(833, 405);
            this.grdIngresos.TabIndex = 13;
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFinal.Location = new System.Drawing.Point(91, 41);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(109, 23);
            this.dtpFechaFinal.TabIndex = 3;
            // 
            // dtpFechaInicial
            // 
            this.dtpFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicial.Location = new System.Drawing.Point(91, 12);
            this.dtpFechaInicial.Name = "dtpFechaInicial";
            this.dtpFechaInicial.Size = new System.Drawing.Size(109, 23);
            this.dtpFechaInicial.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fecha final";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Fecha inicial";
            // 
            // cmdExportar
            // 
            this.cmdExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdExportar.Location = new System.Drawing.Point(850, 288);
            this.cmdExportar.Name = "cmdExportar";
            this.cmdExportar.Size = new System.Drawing.Size(116, 40);
            this.cmdExportar.TabIndex = 9;
            this.cmdExportar.Text = "&Exportar";
            this.cmdExportar.UseVisualStyleBackColor = true;
            this.cmdExportar.Click += new System.EventHandler(this.cmdExportar_Click);
            // 
            // cmdSalir
            // 
            this.cmdSalir.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalir.Image")));
            this.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSalir.Location = new System.Drawing.Point(850, 334);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(116, 40);
            this.cmdSalir.TabIndex = 10;
            this.cmdSalir.Text = "&Salir";
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.Image = global::ClinicaFB.Properties.Resources.Cancelar20;
            this.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancelar.Location = new System.Drawing.Point(850, 242);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(116, 40);
            this.cmdCancelar.TabIndex = 8;
            this.cmdCancelar.Text = "&Cancelar";
            this.cmdCancelar.UseVisualStyleBackColor = true;
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
            // 
            // cmdTicket
            // 
            this.cmdTicket.Image = ((System.Drawing.Image)(resources.GetObject("cmdTicket.Image")));
            this.cmdTicket.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdTicket.Location = new System.Drawing.Point(850, 150);
            this.cmdTicket.Name = "cmdTicket";
            this.cmdTicket.Size = new System.Drawing.Size(116, 40);
            this.cmdTicket.TabIndex = 6;
            this.cmdTicket.Text = "&Ticket";
            this.cmdTicket.UseVisualStyleBackColor = true;
            this.cmdTicket.Click += new System.EventHandler(this.cmdTicket_Click);
            // 
            // cmdFacturar
            // 
            this.cmdFacturar.Image = ((System.Drawing.Image)(resources.GetObject("cmdFacturar.Image")));
            this.cmdFacturar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdFacturar.Location = new System.Drawing.Point(850, 196);
            this.cmdFacturar.Name = "cmdFacturar";
            this.cmdFacturar.Size = new System.Drawing.Size(116, 40);
            this.cmdFacturar.TabIndex = 7;
            this.cmdFacturar.Text = "&Facturar";
            this.cmdFacturar.UseVisualStyleBackColor = true;
            this.cmdFacturar.Click += new System.EventHandler(this.cmdFacturar_Click);
            // 
            // cmdVer
            // 
            this.cmdVer.Image = ((System.Drawing.Image)(resources.GetObject("cmdVer.Image")));
            this.cmdVer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdVer.Location = new System.Drawing.Point(850, 104);
            this.cmdVer.Name = "cmdVer";
            this.cmdVer.Size = new System.Drawing.Size(116, 40);
            this.cmdVer.TabIndex = 5;
            this.cmdVer.Text = "&Ver";
            this.cmdVer.UseVisualStyleBackColor = true;
            this.cmdVer.Click += new System.EventHandler(this.cmdVer_Click);
            // 
            // cmdBuscar
            // 
            this.cmdBuscar.Image = ((System.Drawing.Image)(resources.GetObject("cmdBuscar.Image")));
            this.cmdBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdBuscar.Location = new System.Drawing.Point(206, 22);
            this.cmdBuscar.Name = "cmdBuscar";
            this.cmdBuscar.Size = new System.Drawing.Size(73, 29);
            this.cmdBuscar.TabIndex = 12;
            this.cmdBuscar.Text = "&Buscar";
            this.cmdBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdBuscar.UseVisualStyleBackColor = true;
            this.cmdBuscar.Click += new System.EventHandler(this.cmdBuscar_Click);
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocial.Location = new System.Drawing.Point(253, 70);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.ReadOnly = true;
            this.txtRazonSocial.Size = new System.Drawing.Size(340, 23);
            this.txtRazonSocial.TabIndex = 49;
            this.txtRazonSocial.Text = "PUBLICO EN GENERAL";
            // 
            // cmdBuscaRazonSocial
            // 
            this.cmdBuscaRazonSocial.Location = new System.Drawing.Point(599, 70);
            this.cmdBuscaRazonSocial.Name = "cmdBuscaRazonSocial";
            this.cmdBuscaRazonSocial.Size = new System.Drawing.Size(36, 23);
            this.cmdBuscaRazonSocial.TabIndex = 4;
            this.cmdBuscaRazonSocial.Text = "...";
            this.cmdBuscaRazonSocial.UseVisualStyleBackColor = true;
            this.cmdBuscaRazonSocial.Click += new System.EventHandler(this.cmdBuscaRazonSocial_Click);
            // 
            // txtRFC
            // 
            this.txtRFC.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRFC.Location = new System.Drawing.Point(91, 70);
            this.txtRFC.Name = "txtRFC";
            this.txtRFC.ReadOnly = true;
            this.txtRFC.Size = new System.Drawing.Size(156, 23);
            this.txtRFC.TabIndex = 48;
            this.txtRFC.Text = "XAXX010101000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 16);
            this.label4.TabIndex = 47;
            this.label4.Text = "Razón social";
            // 
            // IngresosListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 521);
            this.Controls.Add(this.txtRazonSocial);
            this.Controls.Add(this.cmdBuscaRazonSocial);
            this.Controls.Add(this.txtRFC);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.cmdExportar);
            this.Controls.Add(this.cmdTicket);
            this.Controls.Add(this.cmdFacturar);
            this.Controls.Add(this.cmdVer);
            this.Controls.Add(this.grdIngresos);
            this.Controls.Add(this.cmdBuscar);
            this.Controls.Add(this.dtpFechaFinal);
            this.Controls.Add(this.dtpFechaInicial);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "IngresosListado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingresos";
            this.Load += new System.EventHandler(this.IngresosListado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdIngresos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdIngresos;
        private System.Windows.Forms.Button cmdBuscar;
        private System.Windows.Forms.DateTimePicker dtpFechaFinal;
        private System.Windows.Forms.DateTimePicker dtpFechaInicial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdVer;
        private System.Windows.Forms.Button cmdFacturar;
        private System.Windows.Forms.Button cmdTicket;
        private System.Windows.Forms.Button cmdExportar;
        private System.Windows.Forms.Button cmdSalir;
        private System.Windows.Forms.Button cmdCancelar;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.Button cmdBuscaRazonSocial;
        private System.Windows.Forms.TextBox txtRFC;
        private System.Windows.Forms.Label label4;
    }
}