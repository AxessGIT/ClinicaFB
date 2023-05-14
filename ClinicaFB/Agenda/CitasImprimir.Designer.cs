
namespace ClinicaFB.Agenda
{
    partial class CitasImprimir
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CitasImprimir));
            this.chkImprimirTodos = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.cmdImprimir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cboRecursos = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTipos = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // chkImprimirTodos
            // 
            this.chkImprimirTodos.AutoSize = true;
            this.chkImprimirTodos.Location = new System.Drawing.Point(123, 144);
            this.chkImprimirTodos.Name = "chkImprimirTodos";
            this.chkImprimirTodos.Size = new System.Drawing.Size(226, 20);
            this.chkImprimirTodos.TabIndex = 30;
            this.chkImprimirTodos.Text = "Imprimir todos los recursos del dia";
            this.chkImprimirTodos.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 16);
            this.label3.TabIndex = 29;
            this.label3.Text = "Fecha";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(123, 105);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(285, 23);
            this.dtpFecha.TabIndex = 28;
            // 
            // cmdSalir
            // 
            this.cmdSalir.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalir.Image")));
            this.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSalir.Location = new System.Drawing.Point(213, 185);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(122, 40);
            this.cmdSalir.TabIndex = 27;
            this.cmdSalir.Text = "&Cerrar";
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // cmdImprimir
            // 
            this.cmdImprimir.Image = ((System.Drawing.Image)(resources.GetObject("cmdImprimir.Image")));
            this.cmdImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdImprimir.Location = new System.Drawing.Point(85, 185);
            this.cmdImprimir.Name = "cmdImprimir";
            this.cmdImprimir.Size = new System.Drawing.Size(122, 40);
            this.cmdImprimir.TabIndex = 26;
            this.cmdImprimir.Text = "&Imprimir";
            this.cmdImprimir.UseVisualStyleBackColor = true;
            this.cmdImprimir.Click += new System.EventHandler(this.cmdImprimir_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 24;
            this.label2.Text = "Recurso";
            // 
            // cboRecursos
            // 
            this.cboRecursos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRecursos.FormattingEnabled = true;
            this.cboRecursos.Location = new System.Drawing.Point(123, 65);
            this.cboRecursos.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cboRecursos.Name = "cboRecursos";
            this.cboRecursos.Size = new System.Drawing.Size(285, 24);
            this.cboRecursos.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 16);
            this.label1.TabIndex = 22;
            this.label1.Text = "Tipo de recurso";
            // 
            // cboTipos
            // 
            this.cboTipos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipos.FormattingEnabled = true;
            this.cboTipos.Items.AddRange(new object[] {
            "Doctor",
            "Equipo",
            "Cuarto"});
            this.cboTipos.Location = new System.Drawing.Point(123, 25);
            this.cboTipos.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cboTipos.Name = "cboTipos";
            this.cboTipos.Size = new System.Drawing.Size(285, 24);
            this.cboTipos.TabIndex = 23;
            this.cboTipos.SelectedIndexChanged += new System.EventHandler(this.cboTipos_SelectedIndexChanged);
            // 
            // CitasImprimir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 260);
            this.Controls.Add(this.chkImprimirTodos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.cmdImprimir);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboRecursos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboTipos);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CitasImprimir";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imprimir citas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CitasImprimir_FormClosing);
            this.Load += new System.EventHandler(this.CitasImprimir_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkImprimirTodos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button cmdSalir;
        private System.Windows.Forms.Button cmdImprimir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboRecursos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTipos;
    }
}