namespace ClinicaFB.Configuracion.PuntoDeVenta
{
    partial class FormapagoAltasCambios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormapagoAltasCambios));
            this.cmdSalir = new System.Windows.Forms.Button();
            this.cmdGuardar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.cmdBuscarCveFOP = new System.Windows.Forms.Button();
            this.txtDescripcionFOP = new System.Windows.Forms.TextBox();
            this.txtCveFOP = new System.Windows.Forms.TextBox();
            this.spnClave = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.spnClave)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdSalir
            // 
            this.cmdSalir.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalir.Image")));
            this.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSalir.Location = new System.Drawing.Point(319, 137);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(112, 50);
            this.cmdSalir.TabIndex = 8;
            this.cmdSalir.Text = "&Salir";
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // cmdGuardar
            // 
            this.cmdGuardar.Image = ((System.Drawing.Image)(resources.GetObject("cmdGuardar.Image")));
            this.cmdGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdGuardar.Location = new System.Drawing.Point(201, 137);
            this.cmdGuardar.Name = "cmdGuardar";
            this.cmdGuardar.Size = new System.Drawing.Size(112, 50);
            this.cmdGuardar.TabIndex = 7;
            this.cmdGuardar.Text = "&Guardar";
            this.cmdGuardar.UseVisualStyleBackColor = true;
            this.cmdGuardar.Click += new System.EventHandler(this.cmdGuardar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Clave";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Clave SAT";
            // 
            // txtNombre
            // 
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Location = new System.Drawing.Point(93, 48);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(380, 23);
            this.txtNombre.TabIndex = 3;
            // 
            // cmdBuscarCveFOP
            // 
            this.cmdBuscarCveFOP.Location = new System.Drawing.Point(243, 80);
            this.cmdBuscarCveFOP.Name = "cmdBuscarCveFOP";
            this.cmdBuscarCveFOP.Size = new System.Drawing.Size(32, 23);
            this.cmdBuscarCveFOP.TabIndex = 6;
            this.cmdBuscarCveFOP.Text = "...";
            this.cmdBuscarCveFOP.UseVisualStyleBackColor = true;
            this.cmdBuscarCveFOP.Click += new System.EventHandler(this.cmdBuscarCveFOP_Click);
            // 
            // txtDescripcionFOP
            // 
            this.txtDescripcionFOP.Location = new System.Drawing.Point(279, 80);
            this.txtDescripcionFOP.Name = "txtDescripcionFOP";
            this.txtDescripcionFOP.ReadOnly = true;
            this.txtDescripcionFOP.Size = new System.Drawing.Size(307, 23);
            this.txtDescripcionFOP.TabIndex = 27;
            // 
            // txtCveFOP
            // 
            this.txtCveFOP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCveFOP.Location = new System.Drawing.Point(93, 80);
            this.txtCveFOP.Name = "txtCveFOP";
            this.txtCveFOP.Size = new System.Drawing.Size(144, 23);
            this.txtCveFOP.TabIndex = 5;
            this.txtCveFOP.Validated += new System.EventHandler(this.txtCveFOP_Validated);
            // 
            // spnClave
            // 
            this.spnClave.Location = new System.Drawing.Point(93, 17);
            this.spnClave.Name = "spnClave";
            this.spnClave.Size = new System.Drawing.Size(76, 23);
            this.spnClave.TabIndex = 1;
            // 
            // FormapagoAltasCambios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 213);
            this.Controls.Add(this.spnClave);
            this.Controls.Add(this.cmdBuscarCveFOP);
            this.Controls.Add(this.txtDescripcionFOP);
            this.Controls.Add(this.txtCveFOP);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.cmdGuardar);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormapagoAltasCambios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormapagoAltasCambios";
            this.Load += new System.EventHandler(this.FormapagoAltasCambios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spnClave)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdSalir;
        private System.Windows.Forms.Button cmdGuardar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button cmdBuscarCveFOP;
        private System.Windows.Forms.TextBox txtDescripcionFOP;
        private System.Windows.Forms.TextBox txtCveFOP;
        private System.Windows.Forms.NumericUpDown spnClave;
    }
}