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

namespace UI.Desktop.FormsPorTipo.Alumno
{
    public partial class FormAlumno : Form
    {
        private Usuario _UsuarioActual;

        #region Propiedades
        public Usuario UsuarioActual
        {
            get { return _UsuarioActual; }
            set { _UsuarioActual = value; }
        }
        #endregion

        #region Constructor
        public FormAlumno(Usuario userActual)
        {
            InitializeComponent();
            UsuarioActual = userActual;
            lblNombreyApellido.Text = UsuarioActual.Persona.Apellido + ", " + UsuarioActual.Persona.Nombre;
            lblLegajo.Text = UsuarioActual.Persona.Legajo.ToString();
        }
        #endregion

        #region Eventos
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnVisualizarCursos_Click(object sender, EventArgs e)
        {
            //Aca se mostraria los cursos a los cuales se inscribio el alumno
            InscripcionAlumno formInscripcion = new InscripcionAlumno(UsuarioActual);
            formInscripcion.TipoOperacion = InscripcionAlumno.Operacion.VerCursos;
            formInscripcion.ShowDialog();
        }

        private void btnInscripcionCursos_Click(object sender, EventArgs e)
        {
            InscripcionAlumno formInscripcion = new InscripcionAlumno(UsuarioActual);
            formInscripcion.TipoOperacion = InscripcionAlumno.Operacion.InscribirCursos;
            formInscripcion.ShowDialog();
        }
        #endregion
    }
}
