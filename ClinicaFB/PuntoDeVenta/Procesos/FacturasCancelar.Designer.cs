namespace ClinicaFB.PuntoDeVenta.Procesos
{
    partial class FacturasCancelar
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmdIniciar = new System.Windows.Forms.Button();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(466, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Este proceso verifica que las facturas esten efectivamente canceladas en el SAT";
            // 
            // cmdIniciar
            // 
            this.cmdIniciar.Location = new System.Drawing.Point(178, 121);
            this.cmdIniciar.Name = "cmdIniciar";
            this.cmdIniciar.Size = new System.Drawing.Size(89, 34);
            this.cmdIniciar.TabIndex = 1;
            this.cmdIniciar.Text = "&Iniciar";
            this.cmdIniciar.UseVisualStyleBackColor = true;
            this.cmdIniciar.Click += new System.EventHandler(this.cmdIniciar_Click);
            // 
            // cmdSalir
            // 
            this.cmdSalir.Location = new System.Drawing.Point(273, 121);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(89, 34);
            this.cmdSalir.TabIndex = 2;
            this.cmdSalir.Text = "&Salir";
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // FacturasCancelar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 197);
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.cmdIniciar);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FacturasCancelar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Canelar facturas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdIniciar;
        private System.Windows.Forms.Button cmdSalir;
    }
}