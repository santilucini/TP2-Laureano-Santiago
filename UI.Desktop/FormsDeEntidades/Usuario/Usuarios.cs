using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;


namespace UI.Desktop
{
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
            dgvUsuarios.AutoGenerateColumns = false;
        }

        public Usuarios(Usuario usuario) : this()
        {
            UsuarioActual = usuario;
        }

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
            UsuarioLogic ul = new UsuarioLogic();
            try
            {
                dgvUsuarios.DataSource = ul.GetAll();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
            
            this.dgvUsuarios.DataSource = ul.GetAll();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            Listar();
        }

        /* METODO VIEJO
        private void Usuarios_Load(object sender, EventArgs e)
        {
            try
            {
                UsuarioLogic usuarioLogic = new UsuarioLogic();
                ModuloUsuario moduloUsuario = usuarioLogic.GetModuloUsuario("Usuarios", UsuarioActual.ID);
                if (moduloUsuario.IDUsuario != 0)
                {
                    tsbEditar.Enabled = moduloUsuario.PermiteModificacion;
                    tsdEliminar.Enabled = moduloUsuario.PermiteBaja;
                    tsbNuevo.Enabled = moduloUsuario.PermiteAlta;
                    dgvUsuarios.Enabled = moduloUsuario.PermiteConsulta;
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
        */
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            UsuarioDesktop formusuario = new UsuarioDesktop(ApplicationForm.ModoForm.Alta);
            formusuario.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (itemSeleccionado())
            {
                int ID = ((Business.Entities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                UsuarioDesktop formusuario = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formusuario.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("No hay Usuarios seleccionados EDITAR", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void tsdEliminar_Click(object sender, EventArgs e)
        {
            if (itemSeleccionado())
            {
                int ID = ((Business.Entities.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                UsuarioDesktop formusuario = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Baja);
                formusuario.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("No hay Usuarios seleccionados ELIMINAR", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private bool itemSeleccionado()
        {
            return (dgvUsuarios.SelectedRows.Count > 0);
        }
    }
}
