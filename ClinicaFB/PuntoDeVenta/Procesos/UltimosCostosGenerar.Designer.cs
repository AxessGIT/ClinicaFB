namespace ClinicaFB.PuntoDeVenta.Procesos
{
    partial class UltimosCostosGenerar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UltimosCostosGenerar));
            this.cmdCerrar = new System.Windows.Forms.Button();
            this.cmdGenerar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdCerrar
            // 
            this.cmdCerrar.Image = ((System.Drawing.Image)(resources.GetObject("cmdCerrar.Image")));
            this.cmdCerrar.Location = new System.Drawing.Point(205, 101);
            this.cmdCerrar.Name = "cmdCerrar";
            this.cmdCerrar.Size = new System.Drawing.Size(99, 71);
            this.cmdCerrar.TabIndex = 6;
            this.cmdCerrar.Text = "&Cerrar";
            this.cmdCerrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdCerrar.UseVisualStyleBackColor = true;
            this.cmdCerrar.Click += new System.EventHandler(this.cmdCerrar_Click);
            // 
            // cmdGenerar
            // 
            this.cmdGenerar.Image = ((System.Drawing.Image)(resources.GetObject("cmdGenerar.Image")));
            this.cmdGenerar.Location = new System.Drawing.Point(100, 101);
            this.cmdGenerar.Name = "cmdGenerar";
            this.cmdGenerar.Size = new System.Drawing.Size(99, 71);
            this.cmdGenerar.TabIndex = 5;
            this.cmdGenerar.Text = "&Generar";
            this.cmdGenerar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdGenerar.UseVisualStyleBackColor = true;
            this.cmdGenerar.Click += new System.EventHandler(this.cmdGenerar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(336, 32);
            this.label1.TabIndex = 7;
            this.label1.Text = "Este proceso recorre la tabla de movimientos de artículos\r\ny genera el último cos" +
    "to de cada movimiento";
            // 
            // UltimosCostosGenerar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 209);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdCerrar);
            this.Controls.Add(this.cmdGenerar);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UltimosCostosGenerar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generar útimos costos";
            this.Load += new System.EventHandler(this.UtimosCostosGenerar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCerrar;
        private System.Windows.Forms.Button cmdGenerar;
        private System.Windows.Forms.Label label1;
    }
}