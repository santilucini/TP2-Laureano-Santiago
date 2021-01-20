namespace UI.Desktop.FormsPorTipo.Docente
{
    partial class FormIngresoNota
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
            this.tblFormIngresoNota = new System.Windows.Forms.TableLayoutPanel();
            this.lblAlumno = new System.Windows.Forms.Label();
            this.lblCondicion = new System.Windows.Forms.Label();
            this.txtAlumno = new System.Windows.Forms.TextBox();
            this.txtCondicion = new System.Windows.Forms.TextBox();
            this.lblNota = new System.Windows.Forms.Label();
            this.txtNota = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tblFormIngresoNota.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblFormIngresoNota
            // 
            this.tblFormIngresoNota.BackColor = System.Drawing.SystemColors.Highlight;
            this.tblFormIngresoNota.ColumnCount = 3;
            this.tblFormIngresoNota.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.6548F));
            this.tblFormIngresoNota.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.3452F));
            this.tblFormIngresoNota.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tblFormIngresoNota.Controls.Add(this.lblAlumno, 0, 0);
            this.tblFormIngresoNota.Controls.Add(this.lblCondicion, 0, 1);
            this.tblFormIngresoNota.Controls.Add(this.txtAlumno, 1, 0);
            this.tblFormIngresoNota.Controls.Add(this.txtCondicion, 1, 1);
            this.tblFormIngresoNota.Controls.Add(this.lblNota, 0, 2);
            this.tblFormIngresoNota.Controls.Add(this.txtNota, 1, 2);
            this.tblFormIngresoNota.Controls.Add(this.btnCancelar, 2, 3);
            this.tblFormIngresoNota.Controls.Add(this.btnGuardar, 1, 3);
            this.tblFormIngresoNota.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblFormIngresoNota.Location = new System.Drawing.Point(0, 0);
            this.tblFormIngresoNota.Name = "tblFormIngresoNota";
            this.tblFormIngresoNota.RowCount = 4;
            this.tblFormIngresoNota.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.30291F));
            this.tblFormIngresoNota.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.69709F));
            this.tblFormIngresoNota.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tblFormIngresoNota.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tblFormIngresoNota.Size = new System.Drawing.Size(336, 192);
            this.tblFormIngresoNota.TabIndex = 1;
            // 
            // lblAlumno
            // 
            this.lblAlumno.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAlumno.AutoSize = true;
            this.lblAlumno.Font = new System.Drawing.Font("Futura Md BT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlumno.Location = new System.Drawing.Point(12, 14);
            this.lblAlumno.Name = "lblAlumno";
            this.lblAlumno.Size = new System.Drawing.Size(71, 19);
            this.lblAlumno.TabIndex = 0;
            this.lblAlumno.Text = "Alumno";
            // 
            // lblCondicion
            // 
            this.lblCondicion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCondicion.AutoSize = true;
            this.lblCondicion.Font = new System.Drawing.Font("Futura Md BT", 12F, System.Drawing.FontStyle.Bold);
            this.lblCondicion.Location = new System.Drawing.Point(4, 65);
            this.lblCondicion.Name = "lblCondicion";
            this.lblCondicion.Size = new System.Drawing.Size(87, 19);
            this.lblCondicion.TabIndex = 1;
            this.lblCondicion.Text = "Condicion";
            // 
            // txtAlumno
            // 
            this.txtAlumno.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtAlumno.Location = new System.Drawing.Point(99, 14);
            this.txtAlumno.Name = "txtAlumno";
            this.txtAlumno.ReadOnly = true;
            this.txtAlumno.Size = new System.Drawing.Size(156, 20);
            this.txtAlumno.TabIndex = 2;
            this.txtAlumno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCondicion
            // 
            this.txtCondicion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCondicion.Location = new System.Drawing.Point(113, 64);
            this.txtCondicion.Name = "txtCondicion";
            this.txtCondicion.ReadOnly = true;
            this.txtCondicion.Size = new System.Drawing.Size(127, 20);
            this.txtCondicion.TabIndex = 3;
            this.txtCondicion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblNota
            // 
            this.lblNota.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNota.AutoSize = true;
            this.lblNota.Font = new System.Drawing.Font("Futura Md BT", 12F, System.Drawing.FontStyle.Bold);
            this.lblNota.Location = new System.Drawing.Point(22, 118);
            this.lblNota.Name = "lblNota";
            this.lblNota.Size = new System.Drawing.Size(50, 19);
            this.lblNota.TabIndex = 4;
            this.lblNota.Text = "Nota";
            // 
            // txtNota
            // 
            this.txtNota.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNota.Location = new System.Drawing.Point(127, 117);
            this.txtNota.Name = "txtNota";
            this.txtNota.Size = new System.Drawing.Size(100, 20);
            this.txtNota.TabIndex = 5;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnGuardar.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnGuardar.Font = new System.Drawing.Font("Futura Md BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Location = new System.Drawing.Point(139, 161);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCancelar.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btnCancelar.Font = new System.Drawing.Font("Futura Md BT", 9.75F);
            this.btnCancelar.Location = new System.Drawing.Point(262, 161);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(71, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FormIngresoNota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 192);
            this.Controls.Add(this.tblFormIngresoNota);
            this.Name = "FormIngresoNota";
            this.Text = "FormIngresoNota";
            this.Shown += new System.EventHandler(this.formIngresoNota_Shown);
            this.tblFormIngresoNota.ResumeLayout(false);
            this.tblFormIngresoNota.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblFormIngresoNota;
        private System.Windows.Forms.Label lblAlumno;
        private System.Windows.Forms.Label lblCondicion;
        private System.Windows.Forms.TextBox txtAlumno;
        private System.Windows.Forms.TextBox txtCondicion;
        private System.Windows.Forms.Label lblNota;
        private System.Windows.Forms.TextBox txtNota;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}