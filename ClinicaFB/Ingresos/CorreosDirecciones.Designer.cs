namespace ClinicaFB.Ingresos
{
    partial class CorreosDirecciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CorreosDirecciones));
            this.cmdCerrar = new System.Windows.Forms.Button();
            this.cmdAceptar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDirecciones = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmdCerrar
            // 
            this.cmdCerrar.Image = ((System.Drawing.Image)(resources.GetObject("cmdCerrar.Image")));
            this.cmdCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCerrar.Location = new System.Drawing.Point(235, 232);
            this.cmdCerrar.Name = "cmdCerrar";
            this.cmdCerrar.Size = new System.Drawing.Size(111, 43);
            this.cmdCerrar.TabIndex = 13;
            this.cmdCerrar.Text = "C&errar";
            this.cmdCerrar.UseVisualStyleBackColor = true;
            this.cmdCerrar.Click += new System.EventHandler(this.cmdCerrar_Click);
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.Image = ((System.Drawing.Image)(resources.GetObject("cmdAceptar.Image")));
            this.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAceptar.Location = new System.Drawing.Point(118, 232);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Size = new System.Drawing.Size(111, 43);
            this.cmdAceptar.TabIndex = 14;
            this.cmdAceptar.Text = "&Aceptar";
            this.cmdAceptar.UseVisualStyleBackColor = true;
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(271, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "Indique las direcciones de correo (1 por línea)";
            // 
            // txtDirecciones
            // 
            this.txtDirecciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtDirecciones.Location = new System.Drawing.Point(15, 38);
            this.txtDirecciones.Multiline = true;
            this.txtDirecciones.Name = "txtDirecciones";
            this.txtDirecciones.Size = new System.Drawing.Size(496, 188);
            this.txtDirecciones.TabIndex = 16;
            // 
            // CorreosDirecciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 287);
            this.Controls.Add(this.txtDirecciones);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdAceptar);
            this.Controls.Add(this.cmdCerrar);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CorreosDirecciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Direcciones de correo";
            this.Load += new System.EventHandler(this.CorreosDirecciones_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCerrar;
        private System.Windows.Forms.Button cmdAceptar;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtDirecciones;
    }
}