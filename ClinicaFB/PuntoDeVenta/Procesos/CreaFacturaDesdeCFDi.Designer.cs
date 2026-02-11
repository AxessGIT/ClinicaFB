namespace ClinicaFB.PuntoDeVenta.Procesos
{
    partial class CreaFacturaDesdeCFDi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreaFacturaDesdeCFDi));
            this.cmdSalir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtArchivoCFDi = new System.Windows.Forms.TextBox();
            this.cmdBuscarCFDi = new System.Windows.Forms.Button();
            this.cmdCrearFactura = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdSalir
            // 
            this.cmdSalir.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalir.Image")));
            this.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdSalir.Location = new System.Drawing.Point(297, 113);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(98, 58);
            this.cmdSalir.TabIndex = 26;
            this.cmdSalir.Text = "Salir";
            this.cmdSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "CFDi a cargar";
            // 
            // txtArchivoCFDi
            // 
            this.txtArchivoCFDi.Location = new System.Drawing.Point(90, 43);
            this.txtArchivoCFDi.Name = "txtArchivoCFDi";
            this.txtArchivoCFDi.Size = new System.Drawing.Size(450, 20);
            this.txtArchivoCFDi.TabIndex = 28;
            // 
            // cmdBuscarCFDi
            // 
            this.cmdBuscarCFDi.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdBuscarCFDi.Location = new System.Drawing.Point(546, 38);
            this.cmdBuscarCFDi.Name = "cmdBuscarCFDi";
            this.cmdBuscarCFDi.Size = new System.Drawing.Size(38, 25);
            this.cmdBuscarCFDi.TabIndex = 29;
            this.cmdBuscarCFDi.Text = "...";
            this.cmdBuscarCFDi.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdBuscarCFDi.UseVisualStyleBackColor = true;
            this.cmdBuscarCFDi.Click += new System.EventHandler(this.cmdBuscarCFDi_Click);
            // 
            // cmdCrearFactura
            // 
            this.cmdCrearFactura.Image = ((System.Drawing.Image)(resources.GetObject("cmdCrearFactura.Image")));
            this.cmdCrearFactura.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdCrearFactura.Location = new System.Drawing.Point(193, 113);
            this.cmdCrearFactura.Name = "cmdCrearFactura";
            this.cmdCrearFactura.Size = new System.Drawing.Size(98, 58);
            this.cmdCrearFactura.TabIndex = 30;
            this.cmdCrearFactura.Text = "Crear";
            this.cmdCrearFactura.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdCrearFactura.UseVisualStyleBackColor = true;
            this.cmdCrearFactura.Click += new System.EventHandler(this.cmdCrearFactura_Click);
            // 
            // CreaFacturaDesdeCFDi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 220);
            this.Controls.Add(this.cmdCrearFactura);
            this.Controls.Add(this.cmdBuscarCFDi);
            this.Controls.Add(this.txtArchivoCFDi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdSalir);
            this.Name = "CreaFacturaDesdeCFDi";
            this.Text = "CreFacturaDesdeXML";
            this.Load += new System.EventHandler(this.CreaFacturaDesdeCFDi_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdSalir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtArchivoCFDi;
        private System.Windows.Forms.Button cmdBuscarCFDi;
        private System.Windows.Forms.Button cmdCrearFactura;
    }
}