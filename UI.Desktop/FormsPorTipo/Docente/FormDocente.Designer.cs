namespace UI.Desktop.FormsPorTipo.Docente
{
    partial class FormDocente
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnReporteAlumnos = new System.Windows.Forms.Button();
            this.btnRegistroNotas = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNombreyApellido = new System.Windows.Forms.Label();
            this.lblLegajo = new System.Windows.Forms.Label();
            this.btnReportePlanes = new System.Windows.Forms.Button();
            this.btnReporteCursos = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Futura Md BT", 14F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(59, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 22);
            this.label1.TabIndex = 15;
            this.label1.Text = "Bienvenido Docente";
            // 
            // btnReporteAlumnos
            // 
            this.btnReporteAlumnos.BackColor = System.Drawing.SystemColors.Window;
            this.btnReporteAlumnos.Font = new System.Drawing.Font("Futura Md BT", 12F, System.Drawing.FontStyle.Bold);
            this.btnReporteAlumnos.Location = new System.Drawing.Point(37, 176);
            this.btnReporteAlumnos.Name = "btnReporteAlumnos";
            this.btnReporteAlumnos.Size = new System.Drawing.Size(237, 33);
            this.btnReporteAlumnos.TabIndex = 14;
            this.btnReporteAlumnos.Text = "Hacer Reporte de Alumnos";
            this.btnReporteAlumnos.UseVisualStyleBackColor = false;
            this.btnReporteAlumnos.Click += new System.EventHandler(this.btnReporteAlumnos_Click);
            // 
            // btnRegistroNotas
            // 
            this.btnRegistroNotas.BackColor = System.Drawing.SystemColors.Window;
            this.btnRegistroNotas.Font = new System.Drawing.Font("Futura Md BT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistroNotas.Location = new System.Drawing.Point(39, 105);
            this.btnRegistroNotas.Name = "btnRegistroNotas";
            this.btnRegistroNotas.Size = new System.Drawing.Size(237, 33);
            this.btnRegistroNotas.TabIndex = 13;
            this.btnRegistroNotas.Text = "Ver Registro de Notas";
            this.btnRegistroNotas.UseVisualStyleBackColor = false;
            this.btnRegistroNotas.Click += new System.EventHandler(this.btnRegistroNotas_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir.Font = new System.Drawing.Font("Futura Md BT", 12F, System.Drawing.FontStyle.Bold);
            this.btnSalir.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSalir.Location = new System.Drawing.Point(109, 319);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(95, 51);
            this.btnSalir.TabIndex = 12;
            this.btnSalir.Text = "Cerrar Sesion";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Desktop;
            this.panel1.Controls.Add(this.lblNombreyApellido);
            this.panel1.Controls.Add(this.lblLegajo);
            this.panel1.Location = new System.Drawing.Point(0, 392);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(303, 58);
            this.panel1.TabIndex = 11;
            // 
            // lblNombreyApellido
            // 
            this.lblNombreyApellido.AutoSize = true;
            this.lblNombreyApellido.Font = new System.Drawing.Font("Futura Md BT", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreyApellido.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblNombreyApellido.Location = new System.Drawing.Point(34, 22);
            this.lblNombreyApellido.Name = "lblNombreyApellido";
            this.lblNombreyApellido.Size = new System.Drawing.Size(111, 15);
            this.lblNombreyApellido.TabIndex = 3;
            this.lblNombreyApellido.Text = "nombreYApellido";
            // 
            // lblLegajo
            // 
            this.lblLegajo.AutoSize = true;
            this.lblLegajo.Font = new System.Drawing.Font("Futura Md BT", 9F, System.Drawing.FontStyle.Bold);
            this.lblLegajo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblLegajo.Location = new System.Drawing.Point(214, 23);
            this.lblLegajo.Name = "lblLegajo";
            this.lblLegajo.Size = new System.Drawing.Size(45, 15);
            this.lblLegajo.TabIndex = 4;
            this.lblLegajo.Text = "legajo";
            // 
            // btnReportePlanes
            // 
            this.btnReportePlanes.BackColor = System.Drawing.SystemColors.Window;
            this.btnReportePlanes.Font = new System.Drawing.Font("Futura Md BT", 12F, System.Drawing.FontStyle.Bold);
            this.btnReportePlanes.Location = new System.Drawing.Point(37, 269);
            this.btnReportePlanes.Name = "btnReportePlanes";
            this.btnReportePlanes.Size = new System.Drawing.Size(237, 33);
            this.btnReportePlanes.TabIndex = 16;
            this.btnReportePlanes.Text = "Hacer Reporte de Planes";
            this.btnReportePlanes.UseVisualStyleBackColor = false;
            this.btnReportePlanes.Click += new System.EventHandler(this.btnReportePlanes_Click_1);
            // 
            // btnReporteCursos
            // 
            this.btnReporteCursos.BackColor = System.Drawing.SystemColors.Window;
            this.btnReporteCursos.Font = new System.Drawing.Font("Futura Md BT", 12F, System.Drawing.FontStyle.Bold);
            this.btnReporteCursos.Location = new System.Drawing.Point(37, 222);
            this.btnReporteCursos.Name = "btnReporteCursos";
            this.btnReporteCursos.Size = new System.Drawing.Size(237, 33);
            this.btnReporteCursos.TabIndex = 17;
            this.btnReporteCursos.Text = "Hacer Reporte de Cursos";
            this.btnReporteCursos.UseVisualStyleBackColor = false;
            this.btnReporteCursos.Click += new System.EventHandler(this.btnReporteCursos_Click);
            // 
            // FormDocente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(303, 450);
            this.Controls.Add(this.btnReporteCursos);
            this.Controls.Add(this.btnReportePlanes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnReporteAlumnos);
            this.Controls.Add(this.btnRegistroNotas);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormDocente";
            this.Text = "Formulario de Docente";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReporteAlumnos;
        private System.Windows.Forms.Button btnRegistroNotas;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNombreyApellido;
        private System.Windows.Forms.Label lblLegajo;
        private System.Windows.Forms.Button btnReportePlanes;
        private System.Windows.Forms.Button btnReporteCursos;
    }
}