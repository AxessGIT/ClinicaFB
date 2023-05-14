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
            this.picImagen = new System.Windows.Forms.PictureBox();
            this.cboDiagnosticos = new Syncfusion.WinForms.ListView.SfComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPalabrasClave = new System.Windows.Forms.TextBox();
            this.cmdCargar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picImagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDiagnosticos)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdCerrar
            // 
            this.cmdCerrar.Image = ((System.Drawing.Image)(resources.GetObject("cmdCerrar.Image")));
            this.cmdCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCerrar.Location = new System.Drawing.Point(264, 342);
            this.cmdCerrar.Margin = new System.Windows.Forms.Padding(5);
            this.cmdCerrar.Name = "cmdCerrar";
            this.cmdCerrar.Size = new System.Drawing.Size(121, 52);
            this.cmdCerrar.TabIndex = 38;
            this.cmdCerrar.Text = "&Cerrar";
            this.cmdCerrar.UseVisualStyleBackColor = true;
            this.cmdCerrar.Click += new System.EventHandler(this.cmdCerrar_Click);
            // 
            // cmdGuardar
            // 
            this.cmdGuardar.Image = ((System.Drawing.Image)(resources.GetObject("cmdGuardar.Image")));
            this.cmdGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdGuardar.Location = new System.Drawing.Point(133, 342);
            this.cmdGuardar.Margin = new System.Windows.Forms.Padding(5);
            this.cmdGuardar.Name = "cmdGuardar";
            this.cmdGuardar.Size = new System.Drawing.Size(121, 52);
            this.cmdGuardar.TabIndex = 36;
            this.cmdGuardar.Text = "&Guardar";
            this.cmdGuardar.UseVisualStyleBackColor = true;
            this.cmdGuardar.Click += new System.EventHandler(this.cmdGuardar_Click);
            // 
            // picImagen
            // 
            this.picImagen.Location = new System.Drawing.Point(9, 13);
            this.picImagen.Margin = new System.Windows.Forms.Padding(4);
            this.picImagen.Name = "picImagen";
            this.picImagen.Size = new System.Drawing.Size(259, 156);
            this.picImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImagen.TabIndex = 39;
            this.picImagen.TabStop = false;
            // 
            // cboDiagnosticos
            // 
            this.cboDiagnosticos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboDiagnosticos.AutoCompleteSuggestMode = Syncfusion.WinForms.ListView.Enums.AutoCompleteSuggestMode.Contains;
            this.cboDiagnosticos.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.cboDiagnosticos.Location = new System.Drawing.Point(112, 226);
            this.cboDiagnosticos.Margin = new System.Windows.Forms.Padding(4);
            this.cboDiagnosticos.Name = "cboDiagnosticos";
            this.cboDiagnosticos.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.cboDiagnosticos.Size = new System.Drawing.Size(273, 34);
            this.cboDiagnosticos.Style.DropDownStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cboDiagnosticos.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cboDiagnosticos.TabIndex = 41;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(16, 235);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(72, 16);
            this.label26.TabIndex = 40;
            this.label26.Text = "Diagnóstico";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 191);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 42;
            this.label1.Text = "Fecha";
            // 
            // txtFecha
            // 
            this.txtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFecha.Location = new System.Drawing.Point(112, 188);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(119, 23);
            this.txtFecha.TabIndex = 43;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 278);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 16);
            this.label2.TabIndex = 44;
            this.label2.Text = "Palabras clave";
            // 
            // txtPalabrasClave
            // 
            this.txtPalabrasClave.Location = new System.Drawing.Point(112, 275);
            this.txtPalabrasClave.Name = "txtPalabrasClave";
            this.txtPalabrasClave.Size = new System.Drawing.Size(420, 23);
            this.txtPalabrasClave.TabIndex = 45;
            // 
            // cmdCargar
            // 
            this.cmdCargar.Image = ((System.Drawing.Image)(resources.GetObject("cmdCargar.Image")));
            this.cmdCargar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCargar.Location = new System.Drawing.Point(288, 47);
            this.cmdCargar.Margin = new System.Windows.Forms.Padding(5);
            this.cmdCargar.Name = "cmdCargar";
            this.cmdCargar.Size = new System.Drawing.Size(121, 52);
            this.cmdCargar.TabIndex = 46;
            this.cmdCargar.Text = "&Cargar...";
            this.cmdCargar.UseVisualStyleBackColor = true;
            this.cmdCargar.Click += new System.EventHandler(this.cmdCargar_Click);
            // 
            // ImagenAltasCambios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 421);
            this.Controls.Add(this.cmdCargar);
            this.Controls.Add(this.txtPalabrasClave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboDiagnosticos);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.picImagen);
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
            this.Load += new System.EventHandler(this.ImagenAltasCambios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picImagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDiagnosticos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cmdCerrar;
        private System.Windows.Forms.Button cmdGuardar;
        private System.Windows.Forms.PictureBox picImagen;
        private Syncfusion.WinForms.ListView.SfComboBox cboDiagnosticos;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker txtFecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPalabrasClave;
        private System.Windows.Forms.Button cmdCargar;
    }
}