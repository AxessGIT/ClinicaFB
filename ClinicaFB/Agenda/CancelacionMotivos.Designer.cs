
namespace ClinicaFB.Agenda
{
    partial class CancelacionMotivos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CancelacionMotivos));
            this.btnAgregarMotivo = new System.Windows.Forms.Button();
            this.cboMotivos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAgregarMotivo
            // 
            this.btnAgregarMotivo.Location = new System.Drawing.Point(353, 9);
            this.btnAgregarMotivo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAgregarMotivo.Name = "btnAgregarMotivo";
            this.btnAgregarMotivo.Size = new System.Drawing.Size(31, 28);
            this.btnAgregarMotivo.TabIndex = 29;
            this.btnAgregarMotivo.Text = "+";
            this.btnAgregarMotivo.UseVisualStyleBackColor = true;
            this.btnAgregarMotivo.Click += new System.EventHandler(this.btnAgregarMotivo_Click);
            // 
            // cboMotivos
            // 
            this.cboMotivos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMotivos.FormattingEnabled = true;
            this.cboMotivos.Location = new System.Drawing.Point(8, 46);
            this.cboMotivos.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.cboMotivos.Name = "cboMotivos";
            this.cboMotivos.Size = new System.Drawing.Size(376, 24);
            this.cboMotivos.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 16);
            this.label1.TabIndex = 27;
            this.label1.Text = "Motivo de la cancelación";
            // 
            // cmdSalir
            // 
            this.cmdSalir.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalir.Image")));
            this.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSalir.Location = new System.Drawing.Point(187, 80);
            this.cmdSalir.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(111, 49);
            this.cmdSalir.TabIndex = 26;
            this.cmdSalir.Text = "&Cerrar";
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancelar.Image")));
            this.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancelar.Location = new System.Drawing.Point(70, 80);
            this.cmdCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(111, 49);
            this.cmdCancelar.TabIndex = 25;
            this.cmdCancelar.Text = "&Cancelar";
            this.cmdCancelar.UseVisualStyleBackColor = true;
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
            // 
            // CancelacionMotivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 139);
            this.Controls.Add(this.btnAgregarMotivo);
            this.Controls.Add(this.cboMotivos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.cmdCancelar);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CancelacionMotivos";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Indique motivo de cancelación";
            this.Load += new System.EventHandler(this.CancelacionMotivos_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAgregarMotivo;
        private System.Windows.Forms.ComboBox cboMotivos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdSalir;
        private System.Windows.Forms.Button cmdCancelar;
    }
}