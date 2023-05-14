namespace ClinicaFB.Configuracion
{
    partial class ClavesSATActualiza
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClavesSATActualiza));
            this.cmdSalir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdActualizar = new System.Windows.Forms.Button();
            this.txtArchivoExcel = new System.Windows.Forms.TextBox();
            this.cmdSeleccionarArchivo = new System.Windows.Forms.Button();
            this.lblLeyenda = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdSalir
            // 
            this.cmdSalir.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalir.Image")));
            this.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSalir.Location = new System.Drawing.Point(310, 125);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(105, 47);
            this.cmdSalir.TabIndex = 9;
            this.cmdSalir.Text = "&Salir";
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Archivo origen de EXCEL";
            // 
            // cmdActualizar
            // 
            this.cmdActualizar.Image = ((System.Drawing.Image)(resources.GetObject("cmdActualizar.Image")));
            this.cmdActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdActualizar.Location = new System.Drawing.Point(199, 125);
            this.cmdActualizar.Name = "cmdActualizar";
            this.cmdActualizar.Size = new System.Drawing.Size(105, 47);
            this.cmdActualizar.TabIndex = 11;
            this.cmdActualizar.Text = "&Actualizar";
            this.cmdActualizar.UseVisualStyleBackColor = true;
            this.cmdActualizar.Click += new System.EventHandler(this.cmdActualizar_Click);
            // 
            // txtArchivoExcel
            // 
            this.txtArchivoExcel.Location = new System.Drawing.Point(15, 43);
            this.txtArchivoExcel.Name = "txtArchivoExcel";
            this.txtArchivoExcel.ReadOnly = true;
            this.txtArchivoExcel.Size = new System.Drawing.Size(582, 23);
            this.txtArchivoExcel.TabIndex = 12;
            // 
            // cmdSeleccionarArchivo
            // 
            this.cmdSeleccionarArchivo.Location = new System.Drawing.Point(603, 43);
            this.cmdSeleccionarArchivo.Name = "cmdSeleccionarArchivo";
            this.cmdSeleccionarArchivo.Size = new System.Drawing.Size(41, 23);
            this.cmdSeleccionarArchivo.TabIndex = 13;
            this.cmdSeleccionarArchivo.Text = "...";
            this.cmdSeleccionarArchivo.UseVisualStyleBackColor = true;
            this.cmdSeleccionarArchivo.Click += new System.EventHandler(this.cmdSeleccionarArchivo_Click);
            // 
            // lblLeyenda
            // 
            this.lblLeyenda.AutoSize = true;
            this.lblLeyenda.Location = new System.Drawing.Point(34, 94);
            this.lblLeyenda.Name = "lblLeyenda";
            this.lblLeyenda.Size = new System.Drawing.Size(91, 16);
            this.lblLeyenda.TabIndex = 14;
            this.lblLeyenda.Text = "Actualizando...";
            this.lblLeyenda.Visible = false;
            // 
            // ClavesSATActualiza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 184);
            this.Controls.Add(this.lblLeyenda);
            this.Controls.Add(this.cmdSeleccionarArchivo);
            this.Controls.Add(this.txtArchivoExcel);
            this.Controls.Add(this.cmdActualizar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdSalir);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "ClavesSATActualiza";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Actualizar claves del SAT";
            this.Load += new System.EventHandler(this.ClavesSATActualiza_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdSalir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdActualizar;
        private System.Windows.Forms.TextBox txtArchivoExcel;
        private System.Windows.Forms.Button cmdSeleccionarArchivo;
        private System.Windows.Forms.Label lblLeyenda;
    }
}