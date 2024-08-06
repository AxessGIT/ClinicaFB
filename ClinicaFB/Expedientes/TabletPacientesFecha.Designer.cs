namespace ClinicaFB.Expedientes
{
    partial class TabletPacientesFecha
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabletPacientesFecha));
            this.grdPacientes = new System.Windows.Forms.DataGridView();
            this.cmdSeleccionar = new System.Windows.Forms.Button();
            this.cmdSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdPacientes)).BeginInit();
            this.SuspendLayout();
            // 
            // grdPacientes
            // 
            this.grdPacientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPacientes.Location = new System.Drawing.Point(12, 12);
            this.grdPacientes.Name = "grdPacientes";
            this.grdPacientes.Size = new System.Drawing.Size(399, 421);
            this.grdPacientes.TabIndex = 6;
            // 
            // cmdSeleccionar
            // 
            this.cmdSeleccionar.Image = ((System.Drawing.Image)(resources.GetObject("cmdSeleccionar.Image")));
            this.cmdSeleccionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSeleccionar.Location = new System.Drawing.Point(417, 12);
            this.cmdSeleccionar.Name = "cmdSeleccionar";
            this.cmdSeleccionar.Size = new System.Drawing.Size(147, 46);
            this.cmdSeleccionar.TabIndex = 71;
            this.cmdSeleccionar.Text = "Seleccionar";
            this.cmdSeleccionar.UseVisualStyleBackColor = true;
            this.cmdSeleccionar.Click += new System.EventHandler(this.cmdSeleccionar_Click);
            // 
            // cmdSalir
            // 
            this.cmdSalir.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalir.Image")));
            this.cmdSalir.Location = new System.Drawing.Point(417, 387);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(147, 46);
            this.cmdSalir.TabIndex = 72;
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // TabletPacientesFecha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 483);
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.cmdSeleccionar);
            this.Controls.Add(this.grdPacientes);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "TabletPacientesFecha";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pacientes del día";
            this.Load += new System.EventHandler(this.TabletPacientesFecha_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdPacientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdPacientes;
        private System.Windows.Forms.Button cmdSeleccionar;
        private System.Windows.Forms.Button cmdSalir;
    }
}