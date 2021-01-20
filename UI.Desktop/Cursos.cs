using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class Cursos : Form
    {
        #region Constructores
        public Cursos()
        {
            InitializeComponent();
        }

        public Cursos(Usuario usuario) : this()
        {
            UsuarioActual = usuario;
        }

        #endregion

        #region Propiedades

        private Usuario _usuarioActual;
        public Usuario UsuarioActual
        {
            get { return _usuarioActual; }
            set { _usuarioActual = value; }
        }

        #endregion
        public void Listar()
        {
            CursoLogic cl = new CursoLogic();
            this.dgvCursos.AutoGenerateColumns = false;
            this.dgvCursos.DataSource = cl.GetAll();
        }

        private void Cursos_Load(object sender, EventArgs e)
        {
            try
                
            {
                UsuarioLogic usuarioLogic = new UsuarioLogic();
                ModuloUsuario moduloUsuario = usuarioLogic.GetModuloUsuario("Cursos", UsuarioActual.ID);
                if (moduloUsuario.IDUsuario != 0)
                {
                    tsbEditar.Enabled = moduloUsuario.PermiteModificacion;
                    tsbEliminar.Enabled = moduloUsuario.PermiteBaja;
                    tsbNuevo.Enabled = moduloUsuario.PermiteAlta;
                    dgvCursos.Enabled = moduloUsuario.PermiteConsulta;
                    btnActualizar.Enabled = moduloUsuario.PermiteConsulta;
                    if (moduloUsuario.PermiteConsulta)
                    {
                        Listar();
                    }
                }
                else
                {
                    MessageBox.Show("Tu Usuario no tiene los permisos necesarios", "Academia");
                    Close();
                }
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Erro al recuperar Modulo", ex);

                throw ExcepcionManejada;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            CursosDesktop cursosDesktop = new CursosDesktop(ApplicationForm.ModoForm.Alta);
            cursosDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;
            CursosDesktop cursosDesktop = new CursosDesktop(ApplicationForm.ModoForm.Modificacion,ID);
            cursosDesktop.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvCursos.Rows.Count > 0)
            {
                int ID = ((Business.Entities.Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;
                CursosDesktop cursosDesktop = new CursosDesktop(ApplicationForm.ModoForm.Baja, ID);
                cursosDesktop.ShowDialog();
                this.Listar();
            }
        }
    }
}
