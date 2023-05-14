
namespace ClinicaFB.Agenda
{
    partial class CeldasBloquear
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CeldasBloquear));
            this.cmdSalir = new System.Windows.Forms.Button();
            this.cmdBloquear = new System.Windows.Forms.Button();
            this.btnAgregarMotivoBloqueo = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.grdMotivos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdMotivos)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdSalir
            // 
            this.cmdSalir.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalir.Image")));
            this.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSalir.Location = new System.Drawing.Point(298, 118);
            this.cmdSalir.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(122, 60);
            this.cmdSalir.TabIndex = 24;
            this.cmdSalir.Text = "&Cerrar";
            this.cmdSalir.UseVisualStyleBackColor = true;
            // 
            // cmdBloquear
            // 
            this.cmdBloquear.Image = ((System.Drawing.Image)(resources.GetObject("cmdBloquear.Image")));
            this.cmdBloquear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdBloquear.Location = new System.Drawing.Point(298, 48);
            this.cmdBloquear.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.cmdBloquear.Name = "cmdBloquear";
            this.cmdBloquear.Size = new System.Drawing.Size(122, 60);
            this.cmdBloquear.TabIndex = 23;
            this.cmdBloquear.Text = "&Bloquear";
            this.cmdBloquear.UseVisualStyleBackColor = true;
            this.cmdBloquear.Click += new System.EventHandler(this.cmdBloquear_Click);
            // 
            // btnAgregarMotivoBloqueo
            // 
            this.btnAgregarMotivoBloqueo.Location = new System.Drawing.Point(134, 15);
            this.btnAgregarMotivoBloqueo.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnAgregarMotivoBloqueo.Name = "btnAgregarMotivoBloqueo";
            this.btnAgregarMotivoBloqueo.Size = new System.Drawing.Size(31, 23);
            this.btnAgregarMotivoBloqueo.TabIndex = 22;
            this.btnAgregarMotivoBloqueo.Text = "+";
            this.btnAgregarMotivoBloqueo.UseVisualStyleBackColor = true;
            this.btnAgregarMotivoBloqueo.Click += new System.EventHandler(this.btnAgregarMotivoBloqueo_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 20);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Razón del bloqueo";
            // 
            // grdMotivos
            // 
            this.grdMotivos.AllowUserToAddRows = false;
            this.grdMotivos.AllowUserToDeleteRows = false;
            this.grdMotivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdMotivos.Location = new System.Drawing.Point(14, 48);
            this.grdMotivos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdMotivos.Name = "grdMotivos";
            this.grdMotivos.ReadOnly = true;
            this.grdMotivos.RowHeadersWidth = 51;
            this.grdMotivos.RowTemplate.Height = 24;
            this.grdMotivos.Size = new System.Drawing.Size(276, 238);
            this.grdMotivos.TabIndex = 21;
            // 
            // CeldasBloquear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 314);
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.cmdBloquear);
            this.Controls.Add(this.btnAgregarMotivoBloqueo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.grdMotivos);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CeldasBloquear";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CeldasBloquear";
            this.Load += new System.EventHandler(this.CeldasBloquear_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdMotivos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdSalir;
        private System.Windows.Forms.Button cmdBloquear;
        private System.Windows.Forms.Button btnAgregarMotivoBloqueo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView grdMotivos;
    }
}