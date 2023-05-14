
namespace ClinicaFB.Configuracion.Conexion
{
    partial class ConexionDatos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConexionDatos));
            this.label1 = new System.Windows.Forms.Label();
            this.txtServidor = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.cmdGuardar = new System.Windows.Forms.Button();
            this.txtCarpeta = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPuerto = new Syncfusion.Windows.Forms.Tools.IntegerTextBox();
            this.cmdProbar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txtPuerto)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Servidor";
            // 
            // txtServidor
            // 
            this.txtServidor.Location = new System.Drawing.Point(121, 10);
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Size = new System.Drawing.Size(310, 23);
            this.txtServidor.TabIndex = 1;
            this.txtServidor.Text = "localhost";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(121, 39);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(310, 23);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.Text = "masterkey";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Contraseña";
            // 
            // cmdSalir
            // 
            this.cmdSalir.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalir.Image")));
            this.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSalir.Location = new System.Drawing.Point(223, 132);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(105, 47);
            this.cmdSalir.TabIndex = 9;
            this.cmdSalir.Text = "&Salir";
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // cmdGuardar
            // 
            this.cmdGuardar.Image = ((System.Drawing.Image)(resources.GetObject("cmdGuardar.Image")));
            this.cmdGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdGuardar.Location = new System.Drawing.Point(112, 132);
            this.cmdGuardar.Name = "cmdGuardar";
            this.cmdGuardar.Size = new System.Drawing.Size(105, 47);
            this.cmdGuardar.TabIndex = 8;
            this.cmdGuardar.Text = "&Guardar";
            this.cmdGuardar.UseVisualStyleBackColor = true;
            this.cmdGuardar.Click += new System.EventHandler(this.cmdGuardar_Click);
            // 
            // txtCarpeta
            // 
            this.txtCarpeta.Location = new System.Drawing.Point(121, 68);
            this.txtCarpeta.Name = "txtCarpeta";
            this.txtCarpeta.Size = new System.Drawing.Size(310, 23);
            this.txtCarpeta.TabIndex = 5;
            this.txtCarpeta.Text = "C:\\ClinicaFB Datos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Carpeta de datos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Puerto";
            // 
            // txtPuerto
            // 
            this.txtPuerto.BeforeTouchSize = new System.Drawing.Size(100, 23);
            this.txtPuerto.IntegerValue = ((long)(3050));
            this.txtPuerto.Location = new System.Drawing.Point(121, 97);
            this.txtPuerto.Name = "txtPuerto";
            this.txtPuerto.NumberGroupSeparator = "";
            this.txtPuerto.Size = new System.Drawing.Size(100, 23);
            this.txtPuerto.TabIndex = 7;
            this.txtPuerto.Text = "3050";
            // 
            // cmdProbar
            // 
            this.cmdProbar.Image = ((System.Drawing.Image)(resources.GetObject("cmdProbar.Image")));
            this.cmdProbar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdProbar.Location = new System.Drawing.Point(403, 142);
            this.cmdProbar.Name = "cmdProbar";
            this.cmdProbar.Size = new System.Drawing.Size(28, 27);
            this.cmdProbar.TabIndex = 10;
            this.cmdProbar.UseVisualStyleBackColor = true;
            this.cmdProbar.Click += new System.EventHandler(this.cmdProbar_Click);
            // 
            // ConexionDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 200);
            this.Controls.Add(this.cmdProbar);
            this.Controls.Add(this.txtPuerto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCarpeta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.cmdGuardar);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtServidor);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConexionDatos";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conexión al servidor";
            this.Load += new System.EventHandler(this.ConexionDatos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtPuerto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtServidor;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdSalir;
        private System.Windows.Forms.Button cmdGuardar;
        private System.Windows.Forms.TextBox txtCarpeta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private Syncfusion.Windows.Forms.Tools.IntegerTextBox txtPuerto;
        private System.Windows.Forms.Button cmdProbar;
    }
}