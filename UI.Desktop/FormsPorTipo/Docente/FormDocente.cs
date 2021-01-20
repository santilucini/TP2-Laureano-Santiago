using Business.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop.FormsPorTipo.Docente
{
    public partial class FormDocente : Form
    {
        private Usuario _UsuarioActual;
        public Usuario UsuarioActual
        {
            get { return _UsuarioActual; }
            set { _UsuarioActual = value; }
        }
        public FormDocente(Usuario userActual)
        {
            InitializeComponent();
            UsuarioActual = userActual;
            lblNombreyApellido.Text = UsuarioActual.Persona.Apellido + ", " + UsuarioActual.Persona.Nombre;
            lblLegajo.Text = UsuarioActual.Persona.Legajo.ToString();
        }
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistroNotas_Click(object sender, EventArgs e)
        {
            FormCursosDocente formInscripcion = new FormCursosDocente(UsuarioActual);
            formInscripcion.TipoOperacion = FormCursosDocente.Operacion.RegistroNotas;
            formInscripcion.ShowDialog();
        }

        private void btnReportePlanes_Click(object sender, EventArgs e)
        {
            new ReportePlanes().ShowDialog();
        }

        private void btnReporteAlumnos_Click(object sender, EventArgs e)
        {
            new ReporteAlumnos(UsuarioActual).ShowDialog();
        }

        private void btnReporteCursos_Click(object sender, EventArgs e)
        {
            new ReporteCursos().ShowDialog();
        }

        private void btnReportePlanes_Click_1(object sender, EventArgs e)
        {
            new ReportePlanes().ShowDialog();
        }
        //private void btnReportePlanes_Click(object sender, EventArgs e)
        //{
        //    new ReportePlanesForm().ShowDialog();
        //}

        //private void btnReporteCursos_Click(object sender, EventArgs e)
        //{
        //    new ReporteAlumnoForm(UsuarioActual).ShowDialog();
        //}
    }
}
