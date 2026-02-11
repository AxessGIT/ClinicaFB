namespace ClinicaFB.PuntoDeVenta.Procesos
{
    partial class CostosGenerar
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
            this.txtArchivoCSV = new System.Windows.Forms.TextBox();
            this.cmdExaminar = new System.Windows.Forms.Button();
            this.cmdGenerar = new System.Windows.Forms.Button();
            this.cmdCerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Archivo de costos";
            // 
            // txtArchivoCSV
            // 
            this.txtArchivoCSV.Location = new System.Drawing.Point(137, 41);
            this.txtArchivoCSV.Name = "txtArchivoCSV";
            this.txtArchivoCSV.Size = new System.Drawing.Size(433, 23);
            this.txtArchivoCSV.TabIndex = 1;
            // 
            // cmdExaminar
            // 
            this.cmdExaminar.Location = new System.Drawing.Point(576, 42);
            this.cmdExaminar.Name = "cmdExaminar";
            this.cmdExaminar.Size = new System.Drawing.Size(42, 24);
            this.cmdExaminar.TabIndex = 2;
            this.cmdExaminar.Text = "...";
            this.cmdExaminar.UseVisualStyleBackColor = true;
            this.cmdExaminar.Click += new System.EventHandler(this.cmdExaminar_Click);
            // 
            // cmdGenerar
            // 
            this.cmdGenerar.Location = new System.Drawing.Point(228, 105);
            this.cmdGenerar.Name = "cmdGenerar";
            this.cmdGenerar.Size = new System.Drawing.Size(75, 44);
            this.cmdGenerar.TabIndex = 3;
            this.cmdGenerar.Text = "&Generar";
            this.cmdGenerar.UseVisualStyleBackColor = true;
            this.cmdGenerar.Click += new System.EventHandler(this.cmdGenerar_Click);
            // 
            // cmdCerrar
            // 
            this.cmdCerrar.Location = new System.Drawing.Point(309, 105);
            this.cmdCerrar.Name = "cmdCerrar";
            this.cmdCerrar.Size = new System.Drawing.Size(75, 44);
            this.cmdCerrar.TabIndex = 4;
            this.cmdCerrar.Text = "&Cerrar";
            this.cmdCerrar.UseVisualStyleBackColor = true;
            this.cmdCerrar.Click += new System.EventHandler(this.cmdCerrar_Click);
            // 
            // CostosGenerar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 258);
            this.Controls.Add(this.cmdCerrar);
            this.Controls.Add(this.cmdGenerar);
            this.Controls.Add(this.cmdExaminar);
            this.Controls.Add(this.txtArchivoCSV);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "CostosGenerar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Generar costos";
            this.Load += new System.EventHandler(this.CostosGenerar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtArchivoCSV;
        private System.Windows.Forms.Button cmdExaminar;
        private System.Windows.Forms.Button cmdGenerar;
        private System.Windows.Forms.Button cmdCerrar;
    }
}