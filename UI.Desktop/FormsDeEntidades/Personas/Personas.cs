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
    public partial class Personas : Form
    {
        #region Constructores
        public Personas()
        {
            InitializeComponent();
        }

        public Personas(Usuario usuario) : this()
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
            PersonasLogic personasLogic = new PersonasLogic();
            this.dgvPersonas.AutoGenerateColumns = false;
            this.dgvPersonas.DataSource = personasLogic.GetAll();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            PersonaDesktop personaDesktop = new PersonaDesktop(ApplicationForm.ModoForm.Alta);
            personaDesktop.ShowDialog();
            Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID;
            PersonaDesktop formusper = new PersonaDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formusper.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvPersonas.Rows.Count > 1)
            {
                int ID = ((Business.Entities.Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID;
                PersonaDesktop formusuario = new PersonaDesktop(ID, ApplicationForm.ModoForm.Baja);
                formusuario.ShowDialog();
                this.Listar();
            }
        }

        private void Personas_Load(object sender, EventArgs e)
        {
            try
            {
                UsuarioLogic usuarioLogic = new UsuarioLogic();
                ModuloUsuario moduloUsuario = usuarioLogic.GetModuloUsuario("Personas", UsuarioActual.ID);
                if (moduloUsuario.IDUsuario != 0)
                {
                    tsbEditar.Enabled = moduloUsuario.PermiteModificacion;
                    tsbEliminar.Enabled = moduloUsuario.PermiteBaja;
                    tsbNuevo.Enabled = moduloUsuario.PermiteAlta;
                    dgvPersonas.Enabled = moduloUsuario.PermiteConsulta;
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
    }
}
