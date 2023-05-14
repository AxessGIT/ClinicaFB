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
            this.cmdBuscar = new System.Windows.Forms.Button();
            this.dtpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdVer = new System.Windows.Forms.Button();
            this.cmdFacturar = new System.Windows.Forms.Button();
            this.cmdTicket = new System.Windows.Forms.Button();
            this.cmdImprimir = new System.Windows.Forms.Button();
            this.cmdExportar = new System.Windows.Forms.Button();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.cmdCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdIngresos)).BeginInit();
            this.SuspendLayout();
            // 
            // grdIngresos
            // 
            this.grdIngresos.AllowUserToAddRows = false;
            this.grdIngresos.AllowUserToDeleteRows = false;
            this.grdIngresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdIngresos.Location = new System.Drawing.Point(11, 86);
            this.grdIngresos.Name = "grdIngresos";
            this.grdIngresos.ReadOnly = true;
            this.grdIngresos.Size = new System.Drawing.Size(833, 423);
            this.grdIngresos.TabIndex = 13;
            // 
            // cmdBuscar
            // 
            this.cmdBuscar.Location = new System.Drawing.Point(206, 31);
            this.cmdBuscar.Name = "cmdBuscar";
            this.cmdBuscar.Size = new System.Drawing.Size(70, 29);
            this.cmdBuscar.TabIndex = 12;
            this.cmdBuscar.Text = "&Buscar";
            this.cmdBuscar.UseVisualStyleBackColor = true;
            this.cmdBuscar.Click += new System.EventHandler(this.cmdBuscar_Click);
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFinal.Location = new System.Drawing.Point(91, 41);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(109, 23);
            this.dtpFechaFinal.TabIndex = 11;
            // 
            // dtpFechaInicial
            // 
            this.dtpFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicial.Location = new System.Drawing.Point(91, 12);
            this.dtpFechaInicial.Name = "dtpFechaInicial";
            this.dtpFechaInicial.Size = new System.Drawing.Size(109, 23);
            this.dtpFechaInicial.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Fecha final";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Fecha inicial";
            // 
            // cmdVer
            // 
            this.cmdVer.Location = new System.Drawing.Point(850, 83);
            this.cmdVer.Name = "cmdVer";
            this.cmdVer.Size = new System.Drawing.Size(94, 29);
            this.cmdVer.TabIndex = 14;
            this.cmdVer.Text = "&Ver";
            this.cmdVer.UseVisualStyleBackColor = true;
            // 
            // cmdFacturar
            // 
            this.cmdFacturar.Location = new System.Drawing.Point(850, 151);
            this.cmdFacturar.Name = "cmdFacturar";
            this.cmdFacturar.Size = new System.Drawing.Size(94, 29);
            this.cmdFacturar.TabIndex = 15;
            this.cmdFacturar.Text = "&Facturar";
            this.cmdFacturar.UseVisualStyleBackColor = true;
            // 
            // cmdTicket
            // 
            this.cmdTicket.Location = new System.Drawing.Point(850, 117);
            this.cmdTicket.Name = "cmdTicket";
            this.cmdTicket.Size = new System.Drawing.Size(94, 29);
            this.cmdTicket.TabIndex = 16;
            this.cmdTicket.Text = "&Ticket";
            this.cmdTicket.UseVisualStyleBackColor = true;
            // 
            // cmdImprimir
            // 
            this.cmdImprimir.Location = new System.Drawing.Point(850, 185);
            this.cmdImprimir.Name = "cmdImprimir";
            this.cmdImprimir.Size = new System.Drawing.Size(94, 29);
            this.cmdImprimir.TabIndex = 18;
            this.cmdImprimir.Text = "&Imprimir";
            this.cmdImprimir.UseVisualStyleBackColor = true;
            // 
            // cmdExportar
            // 
            this.cmdExportar.Location = new System.Drawing.Point(850, 219);
            this.cmdExportar.Name = "cmdExportar";
            this.cmdExportar.Size = new System.Drawing.Size(94, 29);
            this.cmdExportar.TabIndex = 19;
            this.cmdExportar.Text = "&Exportar";
            this.cmdExportar.UseVisualStyleBackColor = true;
            // 
            // cmdSalir
            // 
            this.cmdSalir.Location = new System.Drawing.Point(850, 289);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(94, 29);
            this.cmdSalir.TabIndex = 20;
            this.cmdSalir.Text = "&Salir";
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.Location = new System.Drawing.Point(850, 254);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(94, 29);
            this.cmdCancelar.TabIndex = 21;
            this.cmdCancelar.Text = "&Cancelar";
            this.cmdCancelar.UseVisualStyleBackColor = true;
            // 
            // IngresosListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 521);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.cmdExportar);
            this.Controls.Add(this.cmdImprimir);
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
        private System.Windows.Forms.Button cmdImprimir;
        private System.Windows.Forms.Button cmdExportar;
        private System.Windows.Forms.Button cmdSalir;
        private System.Windows.Forms.Button cmdCancelar;
    }
}