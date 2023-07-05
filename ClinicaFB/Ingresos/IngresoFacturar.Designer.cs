namespace ClinicaFB.Ingresos
{
    partial class IngresoFacturar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IngresoFacturar));
            this.label1 = new System.Windows.Forms.Label();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.cmdBuscaRazonSocial = new System.Windows.Forms.Button();
            this.txtRFC = new System.Windows.Forms.TextBox();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.cmdFacturar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Razon social";
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRazonSocial.Location = new System.Drawing.Point(255, 44);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.ReadOnly = true;
            this.txtRazonSocial.Size = new System.Drawing.Size(340, 23);
            this.txtRazonSocial.TabIndex = 48;
            this.txtRazonSocial.Text = "PUBLICO EN GENERAL";
            // 
            // cmdBuscaRazonSocial
            // 
            this.cmdBuscaRazonSocial.Location = new System.Drawing.Point(601, 44);
            this.cmdBuscaRazonSocial.Name = "cmdBuscaRazonSocial";
            this.cmdBuscaRazonSocial.Size = new System.Drawing.Size(36, 23);
            this.cmdBuscaRazonSocial.TabIndex = 49;
            this.cmdBuscaRazonSocial.Text = "...";
            this.cmdBuscaRazonSocial.UseVisualStyleBackColor = true;
            this.cmdBuscaRazonSocial.Click += new System.EventHandler(this.cmdBuscaRazonSocial_Click);
            // 
            // txtRFC
            // 
            this.txtRFC.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRFC.Location = new System.Drawing.Point(93, 44);
            this.txtRFC.Name = "txtRFC";
            this.txtRFC.ReadOnly = true;
            this.txtRFC.Size = new System.Drawing.Size(156, 23);
            this.txtRFC.TabIndex = 47;
            this.txtRFC.Text = "XAXX010101000";
            // 
            // cmdSalir
            // 
            this.cmdSalir.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalir.Image")));
            this.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdSalir.Location = new System.Drawing.Point(298, 137);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(112, 58);
            this.cmdSalir.TabIndex = 52;
            this.cmdSalir.Text = "Salir";
            this.cmdSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // cmdFacturar
            // 
            this.cmdFacturar.Image = ((System.Drawing.Image)(resources.GetObject("cmdFacturar.Image")));
            this.cmdFacturar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdFacturar.Location = new System.Drawing.Point(180, 137);
            this.cmdFacturar.Name = "cmdFacturar";
            this.cmdFacturar.Size = new System.Drawing.Size(112, 58);
            this.cmdFacturar.TabIndex = 51;
            this.cmdFacturar.Text = "Facturar";
            this.cmdFacturar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdFacturar.UseVisualStyleBackColor = true;
            // 
            // IngresoFacturar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 207);
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.cmdFacturar);
            this.Controls.Add(this.txtRazonSocial);
            this.Controls.Add(this.cmdBuscaRazonSocial);
            this.Controls.Add(this.txtRFC);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "IngresoFacturar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facturar ingreso";
            this.Load += new System.EventHandler(this.IngresoFacturar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.Button cmdBuscaRazonSocial;
        private System.Windows.Forms.TextBox txtRFC;
        private System.Windows.Forms.Button cmdSalir;
        private System.Windows.Forms.Button cmdFacturar;
    }
}