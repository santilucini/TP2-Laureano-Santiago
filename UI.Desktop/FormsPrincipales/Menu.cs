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

namespace UI.Desktop
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        public Menu(Usuario usuario):this()
        {
            UsuarioActual = usuario;
        }

        private Usuario _usuarioActual;

        public Usuario UsuarioActual
        {
            get { return _usuarioActual; }
            set { _usuarioActual = value; }
        }

        private void btnMaterias_Click(object sender, EventArgs e)
        {
            Materias materias = new Materias(UsuarioActual);
            materias.ShowDialog();
        }

        private void btnCursos_Click(object sender, EventArgs e)
        {
            Cursos cursos = new Cursos(UsuarioActual);
            cursos.ShowDialog();
        }

        private void btnPersonas2_Click(object sender, EventArgs e)
        {
            Personas personas = new Personas(UsuarioActual);
            personas.ShowDialog();
        }

        private void btnInscripciones_Click(object sender, EventArgs e)
        {
            Inscripciones inscripciones = new Inscripciones(UsuarioActual);
            inscripciones.ShowDialog();
        }

        private void btnDictados_Click(object sender, EventArgs e)
        {
            Dictados dictados = new Dictados(UsuarioActual);
            dictados.ShowDialog();
        }

        private void btnComisiones_Click(object sender, EventArgs e)
        {           
            Comisiones comisiones = new Comisiones(UsuarioActual);
            comisiones.ShowDialog();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            Usuarios usuarios = new Usuarios(UsuarioActual);
            usuarios.ShowDialog();
        }

        private void btnPersonas_Click(object sender, EventArgs e)
        {
            Especialidades especialidades = new Especialidades(UsuarioActual);
            especialidades.ShowDialog();
        }

        private void btnPlanes_Click(object sender, EventArgs e)
        {
            Planes planes = new Planes(UsuarioActual);
            planes.ShowDialog();
        }
    }
}
