namespace ClinicaFB.Expedientes
{
    partial class PacienteFotoTomar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PacienteFotoTomar));
            this.label63 = new System.Windows.Forms.Label();
            this.cboDispositivos = new System.Windows.Forms.ComboBox();
            this.cmdVideo = new System.Windows.Forms.Button();
            this.picFoto = new System.Windows.Forms.PictureBox();
            this.cmdGuardar = new System.Windows.Forms.Button();
            this.cmdSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(14, 21);
            this.label63.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(190, 16);
            this.label63.TabIndex = 54;
            this.label63.Text = "Dispositivos de captura de vídeo";
            // 
            // cboDispositivos
            // 
            this.cboDispositivos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDispositivos.FormattingEnabled = true;
            this.cboDispositivos.Location = new System.Drawing.Point(14, 41);
            this.cboDispositivos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboDispositivos.Name = "cboDispositivos";
            this.cboDispositivos.Size = new System.Drawing.Size(242, 24);
            this.cboDispositivos.TabIndex = 53;
            // 
            // cmdVideo
            // 
            this.cmdVideo.Image = ((System.Drawing.Image)(resources.GetObject("cmdVideo.Image")));
            this.cmdVideo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdVideo.Location = new System.Drawing.Point(14, 321);
            this.cmdVideo.Margin = new System.Windows.Forms.Padding(5);
            this.cmdVideo.Name = "cmdVideo";
            this.cmdVideo.Size = new System.Drawing.Size(340, 36);
            this.cmdVideo.TabIndex = 55;
            this.cmdVideo.Text = "&Iniciar vídeo";
            this.cmdVideo.UseVisualStyleBackColor = true;
            this.cmdVideo.Click += new System.EventHandler(this.cmdVideo_Click);
            // 
            // picFoto
            // 
            this.picFoto.Location = new System.Drawing.Point(14, 73);
            this.picFoto.Margin = new System.Windows.Forms.Padding(4);
            this.picFoto.Name = "picFoto";
            this.picFoto.Size = new System.Drawing.Size(340, 239);
            this.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFoto.TabIndex = 0;
            this.picFoto.TabStop = false;
            // 
            // cmdGuardar
            // 
            this.cmdGuardar.Image = ((System.Drawing.Image)(resources.GetObject("cmdGuardar.Image")));
            this.cmdGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdGuardar.Location = new System.Drawing.Point(363, 73);
            this.cmdGuardar.Margin = new System.Windows.Forms.Padding(5);
            this.cmdGuardar.Name = "cmdGuardar";
            this.cmdGuardar.Size = new System.Drawing.Size(178, 36);
            this.cmdGuardar.TabIndex = 56;
            this.cmdGuardar.Text = "&Guardar";
            this.cmdGuardar.UseVisualStyleBackColor = true;
            this.cmdGuardar.Click += new System.EventHandler(this.cmdGuardar_Click);
            // 
            // cmdSalir
            // 
            this.cmdSalir.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalir.Image")));
            this.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSalir.Location = new System.Drawing.Point(363, 119);
            this.cmdSalir.Margin = new System.Windows.Forms.Padding(5);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(178, 36);
            this.cmdSalir.TabIndex = 57;
            this.cmdSalir.Text = "&Salir";
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // PacienteFotoTomar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 379);
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.cmdGuardar);
            this.Controls.Add(this.cmdVideo);
            this.Controls.Add(this.label63);
            this.Controls.Add(this.cboDispositivos);
            this.Controls.Add(this.picFoto);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "PacienteFotoTomar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tomar foto al paciente";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PacienteFotoTomar_FormClosing);
            this.Load += new System.EventHandler(this.PacienteFotoTomar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picFoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picFoto;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.ComboBox cboDispositivos;
        private System.Windows.Forms.Button cmdVideo;
        private System.Windows.Forms.Button cmdGuardar;
        private System.Windows.Forms.Button cmdSalir;
    }
}