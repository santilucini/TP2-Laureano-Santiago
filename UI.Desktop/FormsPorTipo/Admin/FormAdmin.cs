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

namespace UI.Desktop.FormsPorTipo.Admin
{
    public partial class FormAdmin : Form
    {
        private Usuario _UsuarioActual;

        public Usuario UsuarioActual
        {
            get { return _UsuarioActual; }
            set { _UsuarioActual = value; }
        }

        public FormAdmin(Usuario userActual)
        {
            InitializeComponent();
            UsuarioActual = userActual;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new Usuarios().ShowDialog();
        }

        private void especialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Especialidades().ShowDialog();
        }

        private void planesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Planes().ShowDialog();
        }

        private void materiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Materias().ShowDialog();
        }

        private void comisionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Comisiones().ShowDialog();
        }

        private void cursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Cursos().ShowDialog();
        }

        private void dictadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Dictados().ShowDialog();
        }

        private void inscripcionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Inscripciones().ShowDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            new UsuarioDesktop().ShowDialog();
        }

        private void especialidadesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new EspecialidadDesktop().ShowDialog();
        }

        private void planesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new PlanDesktop().ShowDialog();
        }

        private void materiasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new MateriaDesktop().ShowDialog();
        }

        private void comisionesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new ComisionDesktop().ShowDialog();
        }

        private void cursosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new CursosDesktop().ShowDialog();
        }

        private void dictadosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new DictadosDesktop().ShowDialog();
        }

        private void inscripcionesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new InscripcionesDesktop().ShowDialog();
        }
    }
}
