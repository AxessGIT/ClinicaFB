namespace ClinicaFB.PuntoDeVenta.Procesos
{
    partial class CargarDetalle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CargarDetalle));
            this.cmdGuardar = new System.Windows.Forms.Button();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.txtArchivoXML = new System.Windows.Forms.TextBox();
            this.txtFolio = new System.Windows.Forms.TextBox();
            this.cmdSeleccionarArchivo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdGuardar
            // 
            this.cmdGuardar.Image = ((System.Drawing.Image)(resources.GetObject("cmdGuardar.Image")));
            this.cmdGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdGuardar.Location = new System.Drawing.Point(300, 192);
            this.cmdGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.cmdGuardar.Name = "cmdGuardar";
            this.cmdGuardar.Size = new System.Drawing.Size(114, 71);
            this.cmdGuardar.TabIndex = 113;
            this.cmdGuardar.Text = "Cargar";
            this.cmdGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdGuardar.UseVisualStyleBackColor = true;
            this.cmdGuardar.Click += new System.EventHandler(this.cmdGuardar_Click);
            // 
            // cmdSalir
            // 
            this.cmdSalir.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalir.Image")));
            this.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdSalir.Location = new System.Drawing.Point(421, 192);
            this.cmdSalir.Margin = new System.Windows.Forms.Padding(4);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(114, 71);
            this.cmdSalir.TabIndex = 112;
            this.cmdSalir.Text = "Salir";
            this.cmdSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 122);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 16);
            this.label1.TabIndex = 114;
            this.label1.Text = "Seleccione archivo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 51);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 115;
            this.label2.Text = "Serie venta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 80);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 116;
            this.label3.Text = "Folio venta";
            // 
            // txtSerie
            // 
            this.txtSerie.Location = new System.Drawing.Point(168, 48);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(100, 23);
            this.txtSerie.TabIndex = 117;
            // 
            // txtArchivoXML
            // 
            this.txtArchivoXML.Location = new System.Drawing.Point(168, 119);
            this.txtArchivoXML.Name = "txtArchivoXML";
            this.txtArchivoXML.Size = new System.Drawing.Size(486, 23);
            this.txtArchivoXML.TabIndex = 118;
            // 
            // txtFolio
            // 
            this.txtFolio.Location = new System.Drawing.Point(168, 77);
            this.txtFolio.Name = "txtFolio";
            this.txtFolio.Size = new System.Drawing.Size(100, 23);
            this.txtFolio.TabIndex = 119;
            // 
            // cmdSeleccionarArchivo
            // 
            this.cmdSeleccionarArchivo.Location = new System.Drawing.Point(660, 119);
            this.cmdSeleccionarArchivo.Name = "cmdSeleccionarArchivo";
            this.cmdSeleccionarArchivo.Size = new System.Drawing.Size(75, 23);
            this.cmdSeleccionarArchivo.TabIndex = 120;
            this.cmdSeleccionarArchivo.Text = "...";
            this.cmdSeleccionarArchivo.UseVisualStyleBackColor = true;
            this.cmdSeleccionarArchivo.Click += new System.EventHandler(this.cmdSeleccionarArchivo_Click);
            // 
            // CargarDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 307);
            this.Controls.Add(this.cmdSeleccionarArchivo);
            this.Controls.Add(this.txtFolio);
            this.Controls.Add(this.txtArchivoXML);
            this.Controls.Add(this.txtSerie);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdGuardar);
            this.Controls.Add(this.cmdSalir);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CargarDetalle";
            this.Text = "CargarDetalle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdGuardar;
        private System.Windows.Forms.Button cmdSalir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSerie;
        private System.Windows.Forms.TextBox txtArchivoXML;
        private System.Windows.Forms.TextBox txtFolio;
        private System.Windows.Forms.Button cmdSeleccionarArchivo;
    }
}