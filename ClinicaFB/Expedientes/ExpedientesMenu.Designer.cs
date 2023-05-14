
namespace ClinicaFB.Expedientes
{
    partial class ExpedientesMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExpedientesMenu));
            this.cmdPacientes = new System.Windows.Forms.Button();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdPacientes
            // 
            this.cmdPacientes.Image = ((System.Drawing.Image)(resources.GetObject("cmdPacientes.Image")));
            this.cmdPacientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdPacientes.Location = new System.Drawing.Point(12, 12);
            this.cmdPacientes.Name = "cmdPacientes";
            this.cmdPacientes.Size = new System.Drawing.Size(153, 47);
            this.cmdPacientes.TabIndex = 10;
            this.cmdPacientes.Text = "&Pacientes";
            this.cmdPacientes.UseVisualStyleBackColor = true;
            this.cmdPacientes.Click += new System.EventHandler(this.cmdPacientes_Click);
            // 
            // cmdSalir
            // 
            this.cmdSalir.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalir.Image")));
            this.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSalir.Location = new System.Drawing.Point(533, 12);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(105, 47);
            this.cmdSalir.TabIndex = 11;
            this.cmdSalir.Text = "&Salir";
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // ExpedientesMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 97);
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.cmdPacientes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExpedientesMenu";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Expedientes";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdPacientes;
        private System.Windows.Forms.Button cmdSalir;
    }
}