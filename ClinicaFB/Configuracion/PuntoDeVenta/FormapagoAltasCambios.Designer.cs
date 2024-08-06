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
            this.cboTipos = new System.Windows.Forms.ComboBox();
            this.chkTodos = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cmdSalir
            // 
            this.cmdSalir.Image = ((System.Drawing.Image)(resources.GetObject("cmdSalir.Image")));
            this.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdSalir.Location = new System.Drawing.Point(306, 156);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(112, 50);
            this.cmdSalir.TabIndex = 7;
            this.cmdSalir.Text = "&Salir";
            this.cmdSalir.UseVisualStyleBackColor = true;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // cmdGuardar
            // 
            this.cmdGuardar.Image = ((System.Drawing.Image)(resources.GetObject("cmdGuardar.Image")));
            this.cmdGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdGuardar.Location = new System.Drawing.Point(188, 156);
            this.cmdGuardar.Name = "cmdGuardar";
            this.cmdGuardar.Size = new System.Drawing.Size(112, 50);
            this.cmdGuardar.TabIndex = 6;
            this.cmdGuardar.Text = "&Guardar";
            this.cmdGuardar.UseVisualStyleBackColor = true;
            this.cmdGuardar.Click += new System.EventHandler(this.cmdGuardar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Clave SAT";
            // 
            // txtNombre
            // 
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Location = new System.Drawing.Point(93, 49);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(380, 23);
            this.txtNombre.TabIndex = 1;
            // 
            // cmdBuscarCveFOP
            // 
            this.cmdBuscarCveFOP.Location = new System.Drawing.Point(243, 80);
            this.cmdBuscarCveFOP.Name = "cmdBuscarCveFOP";
            this.cmdBuscarCveFOP.Size = new System.Drawing.Size(32, 23);
            this.cmdBuscarCveFOP.TabIndex = 4;
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
            this.txtDescripcionFOP.TabIndex = 7;
            // 
            // txtCveFOP
            // 
            this.txtCveFOP.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCveFOP.Location = new System.Drawing.Point(93, 79);
            this.txtCveFOP.Name = "txtCveFOP";
            this.txtCveFOP.Size = new System.Drawing.Size(144, 23);
            this.txtCveFOP.TabIndex = 3;
            this.txtCveFOP.Validated += new System.EventHandler(this.txtCveFOP_Validated);
            // 
            // cboTipos
            // 
            this.cboTipos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipos.FormattingEnabled = true;
            this.cboTipos.Items.AddRange(new object[] {
            "Efectivo",
            "Tarjeta",
            "Transferencia",
            "Cheque"});
            this.cboTipos.Location = new System.Drawing.Point(93, 18);
            this.cboTipos.Name = "cboTipos";
            this.cboTipos.Size = new System.Drawing.Size(159, 24);
            this.cboTipos.TabIndex = 1;
            // 
            // chkTodos
            // 
            this.chkTodos.AutoSize = true;
            this.chkTodos.Checked = true;
            this.chkTodos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTodos.Location = new System.Drawing.Point(93, 119);
            this.chkTodos.Name = "chkTodos";
            this.chkTodos.Size = new System.Drawing.Size(190, 20);
            this.chkTodos.TabIndex = 5;
            this.chkTodos.Text = "Incluir en todos los emisores";
            this.chkTodos.UseVisualStyleBackColor = true;
            // 
            // FormapagoAltasCambios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 212);
            this.Controls.Add(this.chkTodos);
            this.Controls.Add(this.cboTipos);
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
        private System.Windows.Forms.ComboBox cboTipos;
        private System.Windows.Forms.CheckBox chkTodos;
    }
}