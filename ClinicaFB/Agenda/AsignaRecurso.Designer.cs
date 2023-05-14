
namespace ClinicaFB.Agenda
{
    partial class AsignaRecurso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AsignaRecurso));
            this.cboTipos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grdRecursos = new System.Windows.Forms.DataGridView();
            this.cmdAceptar = new System.Windows.Forms.Button();
            this.cmdQuitar = new System.Windows.Forms.Button();
            this.cmdSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdRecursos)).BeginInit();
            this.SuspendLayout();
            // 
            // cboTipos
            // 
            this.cboTipos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipos.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTipos.FormattingEnabled = true;
            this.cboTipos.Items.AddRange(new object[] {
            "Doctor",
            "Equipo",
            "Cuarto"});
            this.cboTipos.Location = new System.Drawing.Point(47, 14);
            this.cboTipos.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cboTipos.Name = "cboTipos";
            this.cboTipos.Size = new System.Drawing.Size(330, 24);
            this.cboTipos.TabIndex = 3;
            this.cboTipos.SelectedIndexChanged += new System.EventHandler(this.cboTipos_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tipo";
            // 
            // grdRecursos
            // 
            this.grdRecursos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdRecursos.Location = new System.Drawing.Point(11, 46);
            this.grdRecursos.Name = "grdRecursos";
            this.grdRecursos.Size = new System.Drawing.Size(366, 231);
            this.grdRecursos.TabIndex = 4;
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdAceptar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAceptar.Image = ((System.Drawing.Image)(resources.GetObject("cmdAceptar.Image")));
            this.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdAceptar.Location = new System.Drawing.Point(13, 284);
            this.cmdAceptar.Margin = new System.Windows.Forms.Padding(4);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Size = new System.Drawing.Size(116, 34);
            this.cmdAceptar.TabIndex = 32;
            this.cmdAceptar.Text = "&Aceptar";
            this.cmdAceptar.UseVisualStyleBackColor = true;
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
            // 
            // cmdQuitar
            // 
            this.cmdQuitar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdQuitar.Image = ((System.Drawing.Image)(resources.GetObject("cmdQuitar.Image")));
            this.cmdQuitar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdQuitar.Location = new System.Drawing.Point(137, 284);
            this.cmdQuitar.Margin = new System.Windows.Forms.Padding(4);
            this.cmdQuitar.Name = "cmdQuitar";
            this.cmdQuitar.Size = new System.Drawing.Size(116, 34);
            this.cmdQuitar.TabIndex = 33;
            this.cmdQuitar.Text = "&Quitar";
            this.cmdQuitar.UseVisualStyleBackColor = true;
            this.cmdQuitar.Visible = false;
            this.cmdQuitar.Click += new System.EventHandler(this.cmdQuitar_Click);
            // 
            // cmdSalir
            // 
            this.cmdSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdSalir.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSalir.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalir.Image")));
            this.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSalir.Location = new System.Drawing.Point(261, 284);
            this.cmdSalir.Margin = new System.Windows.Forms.Padding(4);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(116, 34);
            this.cmdSalir.TabIndex = 34;
            this.cmdSalir.Text = "&Salir";
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // AsignaRecurso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 339);
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.cmdQuitar);
            this.Controls.Add(this.cmdAceptar);
            this.Controls.Add(this.grdRecursos);
            this.Controls.Add(this.cboTipos);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AsignaRecurso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignar recurso";
            this.Load += new System.EventHandler(this.AsignaRecurso_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdRecursos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboTipos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grdRecursos;
        private System.Windows.Forms.Button cmdAceptar;
        private System.Windows.Forms.Button cmdQuitar;
        private System.Windows.Forms.Button cmdSalir;
    }
}