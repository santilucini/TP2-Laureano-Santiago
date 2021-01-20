namespace UI.Desktop.FormsPorTipo.Alumno
{
    partial class FormAlumno
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNombreyApellido = new System.Windows.Forms.Label();
            this.lblLegajo = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnVisualizarCursos = new System.Windows.Forms.Button();
            this.btnInscripcionCursos = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Desktop;
            this.panel1.Controls.Add(this.lblNombreyApellido);
            this.panel1.Controls.Add(this.lblLegajo);
            this.panel1.Location = new System.Drawing.Point(0, 392);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(303, 58);
            this.panel1.TabIndex = 6;
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
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.Control;
            this.btnSalir.Font = new System.Drawing.Font("Futura Md BT", 12F, System.Drawing.FontStyle.Bold);
            this.btnSalir.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSalir.Location = new System.Drawing.Point(109, 319);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(95, 51);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "Cerrar Sesion";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnVisualizarCursos
            // 
            this.btnVisualizarCursos.BackColor = System.Drawing.SystemColors.Window;
            this.btnVisualizarCursos.Font = new System.Drawing.Font("Futura Md BT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVisualizarCursos.Location = new System.Drawing.Point(39, 105);
            this.btnVisualizarCursos.Name = "btnVisualizarCursos";
            this.btnVisualizarCursos.Size = new System.Drawing.Size(237, 33);
            this.btnVisualizarCursos.TabIndex = 8;
            this.btnVisualizarCursos.Text = "Ver Cursos Inscriptos";
            this.btnVisualizarCursos.UseVisualStyleBackColor = false;
            this.btnVisualizarCursos.Click += new System.EventHandler(this.btnVisualizarCursos_Click);
            // 
            // btnInscripcionCursos
            // 
            this.btnInscripcionCursos.BackColor = System.Drawing.SystemColors.Window;
            this.btnInscripcionCursos.Font = new System.Drawing.Font("Futura Md BT", 12F, System.Drawing.FontStyle.Bold);
            this.btnInscripcionCursos.Location = new System.Drawing.Point(39, 195);
            this.btnInscripcionCursos.Name = "btnInscripcionCursos";
            this.btnInscripcionCursos.Size = new System.Drawing.Size(237, 33);
            this.btnInscripcionCursos.TabIndex = 9;
            this.btnInscripcionCursos.Text = "Inscribirse a Cursos";
            this.btnInscripcionCursos.UseVisualStyleBackColor = false;
            this.btnInscripcionCursos.Click += new System.EventHandler(this.btnInscripcionCursos_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Futura Md BT", 14F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(59, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 22);
            this.label1.TabIndex = 10;
            this.label1.Text = "Bienvenido Alumno";
            // 
            // FormAlumno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(302, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnInscripcionCursos);
            this.Controls.Add(this.btnVisualizarCursos);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.panel1);
            this.Name = "FormAlumno";
            this.Text = "FormAlumno";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNombreyApellido;
        private System.Windows.Forms.Label lblLegajo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnVisualizarCursos;
        private System.Windows.Forms.Button btnInscripcionCursos;
        private System.Windows.Forms.Label label1;
    }
}