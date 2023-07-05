namespace ClinicaFB.Expedientes
{
    partial class ImagenAltasCambios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImagenAltasCambios));
            this.cmdCerrar = new System.Windows.Forms.Button();
            this.cmdGuardar = new System.Windows.Forms.Button();
            this.cboDiagnosticos = new Syncfusion.WinForms.ListView.SfComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPalabrasClave = new System.Windows.Forms.TextBox();
            this.cmdCargar = new System.Windows.Forms.Button();
            this.cmdVideo = new System.Windows.Forms.Button();
            this.cboDispositivos = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.picVideo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.cboDiagnosticos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVideo)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdCerrar
            // 
            this.cmdCerrar.Image = ((System.Drawing.Image)(resources.GetObject("cmdCerrar.Image")));
            this.cmdCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCerrar.Location = new System.Drawing.Point(306, 305);
            this.cmdCerrar.Margin = new System.Windows.Forms.Padding(5);
            this.cmdCerrar.Name = "cmdCerrar";
            this.cmdCerrar.Size = new System.Drawing.Size(121, 52);
            this.cmdCerrar.TabIndex = 11;
            this.cmdCerrar.Text = "&Cerrar";
            this.cmdCerrar.UseVisualStyleBackColor = true;
            this.cmdCerrar.Click += new System.EventHandler(this.cmdCerrar_Click);
            // 
            // cmdGuardar
            // 
            this.cmdGuardar.Image = ((System.Drawing.Image)(resources.GetObject("cmdGuardar.Image")));
            this.cmdGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdGuardar.Location = new System.Drawing.Point(175, 305);
            this.cmdGuardar.Margin = new System.Windows.Forms.Padding(5);
            this.cmdGuardar.Name = "cmdGuardar";
            this.cmdGuardar.Size = new System.Drawing.Size(121, 52);
            this.cmdGuardar.TabIndex = 10;
            this.cmdGuardar.Text = "&Guardar";
            this.cmdGuardar.UseVisualStyleBackColor = true;
            this.cmdGuardar.Click += new System.EventHandler(this.cmdGuardar_Click);
            // 
            // cboDiagnosticos
            // 
            this.cboDiagnosticos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboDiagnosticos.AutoCompleteSuggestMode = Syncfusion.WinForms.ListView.Enums.AutoCompleteSuggestMode.Contains;
            this.cboDiagnosticos.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.cboDiagnosticos.Location = new System.Drawing.Point(119, 225);
            this.cboDiagnosticos.Margin = new System.Windows.Forms.Padding(4);
            this.cboDiagnosticos.Name = "cboDiagnosticos";
            this.cboDiagnosticos.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.cboDiagnosticos.Size = new System.Drawing.Size(273, 34);
            this.cboDiagnosticos.Style.DropDownStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cboDiagnosticos.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboDiagnosticos.TabIndex = 7;
            this.cboDiagnosticos.TabStop = false;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(23, 234);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(72, 16);
            this.label26.TabIndex = 6;
            this.label26.Text = "Diagnóstico";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 190);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Fecha";
            // 
            // txtFecha
            // 
            this.txtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFecha.Location = new System.Drawing.Point(119, 187);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(119, 23);
            this.txtFecha.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 277);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Palabras clave";
            // 
            // txtPalabrasClave
            // 
            this.txtPalabrasClave.Location = new System.Drawing.Point(119, 274);
            this.txtPalabrasClave.Name = "txtPalabrasClave";
            this.txtPalabrasClave.Size = new System.Drawing.Size(420, 23);
            this.txtPalabrasClave.TabIndex = 9;
            // 
            // cmdCargar
            // 
            this.cmdCargar.Image = ((System.Drawing.Image)(resources.GetObject("cmdCargar.Image")));
            this.cmdCargar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCargar.Location = new System.Drawing.Point(283, 111);
            this.cmdCargar.Margin = new System.Windows.Forms.Padding(5);
            this.cmdCargar.Name = "cmdCargar";
            this.cmdCargar.Size = new System.Drawing.Size(208, 36);
            this.cmdCargar.TabIndex = 3;
            this.cmdCargar.Text = "&Cargar imagen desde arch.";
            this.cmdCargar.UseVisualStyleBackColor = true;
            this.cmdCargar.Click += new System.EventHandler(this.cmdCargar_Click);
            // 
            // cmdVideo
            // 
            this.cmdVideo.Image = ((System.Drawing.Image)(resources.GetObject("cmdVideo.Image")));
            this.cmdVideo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdVideo.Location = new System.Drawing.Point(283, 65);
            this.cmdVideo.Margin = new System.Windows.Forms.Padding(5);
            this.cmdVideo.Name = "cmdVideo";
            this.cmdVideo.Size = new System.Drawing.Size(208, 36);
            this.cmdVideo.TabIndex = 2;
            this.cmdVideo.Text = "&Iniciar vídeo";
            this.cmdVideo.UseVisualStyleBackColor = true;
            this.cmdVideo.Click += new System.EventHandler(this.cmdVideo_Click);
            // 
            // cboDispositivos
            // 
            this.cboDispositivos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDispositivos.FormattingEnabled = true;
            this.cboDispositivos.Location = new System.Drawing.Point(283, 33);
            this.cboDispositivos.Name = "cboDispositivos";
            this.cboDispositivos.Size = new System.Drawing.Size(208, 24);
            this.cboDispositivos.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(284, 14);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Dispositivos de captura de vídeo";
            // 
            // picVideo
            // 
            this.picVideo.Location = new System.Drawing.Point(17, 13);
            this.picVideo.Margin = new System.Windows.Forms.Padding(4);
            this.picVideo.Name = "picVideo";
            this.picVideo.Size = new System.Drawing.Size(259, 156);
            this.picVideo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picVideo.TabIndex = 51;
            this.picVideo.TabStop = false;
            // 
            // ImagenAltasCambios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 404);
            this.Controls.Add(this.picVideo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboDispositivos);
            this.Controls.Add(this.cmdVideo);
            this.Controls.Add(this.cmdCargar);
            this.Controls.Add(this.txtPalabrasClave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboDiagnosticos);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.cmdCerrar);
            this.Controls.Add(this.cmdGuardar);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImagenAltasCambios";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imagen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImagenAltasCambios_FormClosing);
            this.Load += new System.EventHandler(this.ImagenAltasCambios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboDiagnosticos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVideo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cmdCerrar;
        private System.Windows.Forms.Button cmdGuardar;
        private Syncfusion.WinForms.ListView.SfComboBox cboDiagnosticos;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker txtFecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPalabrasClave;
        private System.Windows.Forms.Button cmdCargar;
        private System.Windows.Forms.Button cmdVideo;
        private System.Windows.Forms.ComboBox cboDispositivos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox picVideo;
    }
}