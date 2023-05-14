
namespace ClinicaFB.Agenda
{
    partial class CitasListado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CitasListado));
            this.grdCitas = new System.Windows.Forms.DataGridView();
            this.cmdCancelar = new System.Windows.Forms.Button();
            this.cmdSeleccionar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdCitas)).BeginInit();
            this.SuspendLayout();
            // 
            // grdCitas
            // 
            this.grdCitas.AllowUserToAddRows = false;
            this.grdCitas.AllowUserToDeleteRows = false;
            this.grdCitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCitas.Location = new System.Drawing.Point(12, 12);
            this.grdCitas.Name = "grdCitas";
            this.grdCitas.ReadOnly = true;
            this.grdCitas.RowHeadersWidth = 51;
            this.grdCitas.Size = new System.Drawing.Size(393, 183);
            this.grdCitas.TabIndex = 6;
            // 
            // cmdCancelar
            // 
            this.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancelar.Image = ((System.Drawing.Image)(resources.GetObject("cmdCancelar.Image")));
            this.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdCancelar.Location = new System.Drawing.Point(219, 201);
            this.cmdCancelar.Name = "cmdCancelar";
            this.cmdCancelar.Size = new System.Drawing.Size(135, 37);
            this.cmdCancelar.TabIndex = 5;
            this.cmdCancelar.Text = "&Cancelar";
            this.cmdCancelar.UseVisualStyleBackColor = true;
            this.cmdCancelar.Click += new System.EventHandler(this.cmdCancelar_Click);
            // 
            // cmdSeleccionar
            // 
            this.cmdSeleccionar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdSeleccionar.Image = ((System.Drawing.Image)(resources.GetObject("cmdSeleccionar.Image")));
            this.cmdSeleccionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSeleccionar.Location = new System.Drawing.Point(78, 201);
            this.cmdSeleccionar.Name = "cmdSeleccionar";
            this.cmdSeleccionar.Size = new System.Drawing.Size(135, 37);
            this.cmdSeleccionar.TabIndex = 4;
            this.cmdSeleccionar.Text = "&Seleccionar";
            this.cmdSeleccionar.UseVisualStyleBackColor = true;
            this.cmdSeleccionar.Click += new System.EventHandler(this.cmdSeleccionar_Click);
            // 
            // CitasListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 248);
            this.Controls.Add(this.grdCitas);
            this.Controls.Add(this.cmdCancelar);
            this.Controls.Add(this.cmdSeleccionar);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CitasListado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CitasListado";
            this.Load += new System.EventHandler(this.CitasListado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdCitas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdCitas;
        private System.Windows.Forms.Button cmdCancelar;
        private System.Windows.Forms.Button cmdSeleccionar;
    }
}