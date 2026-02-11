namespace ClinicaFB.PuntoDeVenta.Procesos
{
    partial class ArticulosImportar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArticulosImportar));
            this.cmdProcesos = new System.Windows.Forms.Button();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCatalogo = new System.Windows.Forms.TextBox();
            this.cmdBuscarCatalogo = new System.Windows.Forms.Button();
            this.cmdBuscarExistenciasFD = new System.Windows.Forms.Button();
            this.txtExistenciasFD = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdBuscarClavesEImpuestos = new System.Windows.Forms.Button();
            this.txtClavesEImpuestos = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdBuscarExistenciasAM = new System.Windows.Forms.Button();
            this.txtExistenciasAM = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdProcesos
            // 
            this.cmdProcesos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmdProcesos.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdProcesos.Image = ((System.Drawing.Image)(resources.GetObject("cmdProcesos.Image")));
            this.cmdProcesos.Location = new System.Drawing.Point(283, 220);
            this.cmdProcesos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdProcesos.Name = "cmdProcesos";
            this.cmdProcesos.Size = new System.Drawing.Size(104, 69);
            this.cmdProcesos.TabIndex = 13;
            this.cmdProcesos.Text = "Importar";
            this.cmdProcesos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdProcesos.UseVisualStyleBackColor = false;
            this.cmdProcesos.Click += new System.EventHandler(this.cmdProcesos_Click);
            // 
            // cmdSalir
            // 
            this.cmdSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmdSalir.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSalir.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalir.Image")));
            this.cmdSalir.Location = new System.Drawing.Point(393, 220);
            this.cmdSalir.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(104, 69);
            this.cmdSalir.TabIndex = 14;
            this.cmdSalir.Text = "Salir";
            this.cmdSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.cmdSalir.UseVisualStyleBackColor = false;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Catálogo con precios";
            // 
            // txtCatalogo
            // 
            this.txtCatalogo.AcceptsReturn = true;
            this.txtCatalogo.Location = new System.Drawing.Point(215, 64);
            this.txtCatalogo.Name = "txtCatalogo";
            this.txtCatalogo.Size = new System.Drawing.Size(439, 23);
            this.txtCatalogo.TabIndex = 2;
            // 
            // cmdBuscarCatalogo
            // 
            this.cmdBuscarCatalogo.Location = new System.Drawing.Point(660, 64);
            this.cmdBuscarCatalogo.Name = "cmdBuscarCatalogo";
            this.cmdBuscarCatalogo.Size = new System.Drawing.Size(44, 23);
            this.cmdBuscarCatalogo.TabIndex = 3;
            this.cmdBuscarCatalogo.Text = "...";
            this.cmdBuscarCatalogo.UseVisualStyleBackColor = true;
            this.cmdBuscarCatalogo.Click += new System.EventHandler(this.cmdBuscarCatalogo_Click);
            // 
            // cmdBuscarExistenciasFD
            // 
            this.cmdBuscarExistenciasFD.Location = new System.Drawing.Point(660, 138);
            this.cmdBuscarExistenciasFD.Name = "cmdBuscarExistenciasFD";
            this.cmdBuscarExistenciasFD.Size = new System.Drawing.Size(44, 23);
            this.cmdBuscarExistenciasFD.TabIndex = 9;
            this.cmdBuscarExistenciasFD.Text = "...";
            this.cmdBuscarExistenciasFD.UseVisualStyleBackColor = true;
            this.cmdBuscarExistenciasFD.Click += new System.EventHandler(this.cmdBuscarExistenciasFD_Click);
            // 
            // txtExistenciasFD
            // 
            this.txtExistenciasFD.Location = new System.Drawing.Point(215, 138);
            this.txtExistenciasFD.Name = "txtExistenciasFD";
            this.txtExistenciasFD.Size = new System.Drawing.Size(439, 23);
            this.txtExistenciasFD.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Existencias FARMA DERMA";
            // 
            // cmdBuscarClavesEImpuestos
            // 
            this.cmdBuscarClavesEImpuestos.Location = new System.Drawing.Point(660, 101);
            this.cmdBuscarClavesEImpuestos.Name = "cmdBuscarClavesEImpuestos";
            this.cmdBuscarClavesEImpuestos.Size = new System.Drawing.Size(44, 23);
            this.cmdBuscarClavesEImpuestos.TabIndex = 6;
            this.cmdBuscarClavesEImpuestos.Text = "...";
            this.cmdBuscarClavesEImpuestos.UseVisualStyleBackColor = true;
            this.cmdBuscarClavesEImpuestos.Click += new System.EventHandler(this.cmdBuscarClavesEImpuestos_Click);
            // 
            // txtClavesEImpuestos
            // 
            this.txtClavesEImpuestos.Location = new System.Drawing.Point(215, 101);
            this.txtClavesEImpuestos.Name = "txtClavesEImpuestos";
            this.txtClavesEImpuestos.Size = new System.Drawing.Size(439, 23);
            this.txtClavesEImpuestos.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Claves e impuestos";
            // 
            // cmdBuscarExistenciasAM
            // 
            this.cmdBuscarExistenciasAM.Location = new System.Drawing.Point(660, 175);
            this.cmdBuscarExistenciasAM.Name = "cmdBuscarExistenciasAM";
            this.cmdBuscarExistenciasAM.Size = new System.Drawing.Size(44, 23);
            this.cmdBuscarExistenciasAM.TabIndex = 12;
            this.cmdBuscarExistenciasAM.Text = "...";
            this.cmdBuscarExistenciasAM.UseVisualStyleBackColor = true;
            // 
            // txtExistenciasAM
            // 
            this.txtExistenciasAM.Location = new System.Drawing.Point(215, 175);
            this.txtExistenciasAM.Name = "txtExistenciasAM";
            this.txtExistenciasAM.Size = new System.Drawing.Size(439, 23);
            this.txtExistenciasAM.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Existencias AMAZON";
            // 
            // ArticulosImportar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 302);
            this.Controls.Add(this.cmdBuscarExistenciasAM);
            this.Controls.Add(this.txtExistenciasAM);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmdBuscarClavesEImpuestos);
            this.Controls.Add(this.txtClavesEImpuestos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmdBuscarExistenciasFD);
            this.Controls.Add(this.txtExistenciasFD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdBuscarCatalogo);
            this.Controls.Add(this.txtCatalogo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdProcesos);
            this.Controls.Add(this.cmdSalir);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ArticulosImportar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importar artículos";
            this.Load += new System.EventHandler(this.ArticulosImportar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdProcesos;
        private System.Windows.Forms.Button cmdSalir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCatalogo;
        private System.Windows.Forms.Button cmdBuscarCatalogo;
        private System.Windows.Forms.Button cmdBuscarExistenciasFD;
        private System.Windows.Forms.TextBox txtExistenciasFD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdBuscarClavesEImpuestos;
        private System.Windows.Forms.TextBox txtClavesEImpuestos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdBuscarExistenciasAM;
        private System.Windows.Forms.TextBox txtExistenciasAM;
        private System.Windows.Forms.Label label4;
    }
}