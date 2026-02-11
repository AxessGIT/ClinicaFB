namespace ClinicaFB.PuntoDeVenta
{
    partial class FacturaBuscar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FacturaBuscar));
            this.spnFolio = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdAceptar = new System.Windows.Forms.Button();
            this.cmdSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.spnFolio)).BeginInit();
            this.SuspendLayout();
            // 
            // spnFolio
            // 
            this.spnFolio.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spnFolio.Location = new System.Drawing.Point(67, 50);
            this.spnFolio.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.spnFolio.Name = "spnFolio";
            this.spnFolio.Size = new System.Drawing.Size(110, 23);
            this.spnFolio.TabIndex = 9;
            this.spnFolio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.spnFolio.Enter += new System.EventHandler(this.spnFolio_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 52);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Folio";
            // 
            // txtSerie
            // 
            this.txtSerie.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSerie.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerie.Location = new System.Drawing.Point(67, 20);
            this.txtSerie.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(64, 23);
            this.txtSerie.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Serie";
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.Image = ((System.Drawing.Image)(resources.GetObject("cmdAceptar.Image")));
            this.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdAceptar.Location = new System.Drawing.Point(27, 92);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Size = new System.Drawing.Size(89, 60);
            this.cmdAceptar.TabIndex = 10;
            this.cmdAceptar.Text = "Aceptar";
            this.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdAceptar.UseVisualStyleBackColor = true;
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
            // 
            // cmdSalir
            // 
            this.cmdSalir.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalir.Image")));
            this.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdSalir.Location = new System.Drawing.Point(125, 92);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(89, 60);
            this.cmdSalir.TabIndex = 11;
            this.cmdSalir.Text = "Salir";
            this.cmdSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // FacturaBuscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 166);
            this.Controls.Add(this.spnFolio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSerie);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdAceptar);
            this.Controls.Add(this.cmdSalir);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FacturaBuscar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscar factura";
            this.Load += new System.EventHandler(this.FacturaBuscar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spnFolio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.NumericUpDown spnFolio;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtSerie;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdAceptar;
        private System.Windows.Forms.Button cmdSalir;
    }
}