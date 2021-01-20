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
    public partial class Especialidades : Form
    {
        #region Constructores
        public Especialidades()
        {
            InitializeComponent();
            dgvEspecialidades.AutoGenerateColumns = false;
        }
        public Especialidades(Usuario usuario) : this()
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
            /* Viejo
            EspecialidadLogic el = new EspecialidadLogic();
            this.dgvEspecialidades.AutoGenerateColumns = false;
            this.dgvEspecialidades.DataSource = el.GetAll();
            */
            EspecialidadLogic el = new EspecialidadLogic();
            try
            {
                dgvEspecialidades.DataSource = el.GetAll();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private bool itemSeleccionado()
        {
            return (dgvEspecialidades.SelectedRows.Count > 0);
        }

        public void Especialidades_Load(object sender, EventArgs e)
        {
            Listar();
            /* Viejo
            try
            {
                UsuarioLogic usuarioLogic = new UsuarioLogic();
                ModuloUsuario moduloUsuario = usuarioLogic.GetModuloUsuario("Especialidades", UsuarioActual.ID);
                if (moduloUsuario.IDUsuario != 0)
                {
                    tsbEditar.Enabled = moduloUsuario.PermiteModificacion;
                    tsdEliminar.Enabled = moduloUsuario.PermiteBaja;
                    tsbNuevo.Enabled = moduloUsuario.PermiteAlta;
                    dgvEspecialidades.Enabled = moduloUsuario.PermiteConsulta;
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
            */
        }

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
            EspecialidadDesktop formEspecialidad = new EspecialidadDesktop();
            formEspecialidad.ModoFormulario = ApplicationForm.ModoForm.Alta;
            formEspecialidad.ShowDialog();
            this.Listar();
            /*
            EspecialidadDesktop formespecialidad = new EspecialidadDesktop(ApplicationForm.ModoForm.Alta);
            formespecialidad.ShowDialog();
            this.Listar();
            */
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (itemSeleccionado())
            {
                EspecialidadDesktop formEspecialidad = new EspecialidadDesktop();
                formEspecialidad.ModoFormulario = ApplicationForm.ModoForm.Modificacion;
                formEspecialidad.EspecialidadActual = ((Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem);
                formEspecialidad.ShowDialog();
                Listar();
            }
            else
            {
                MessageBox.Show("No hay especialidades seleccionadas", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            /* Viejo
            int ID = ((Business.Entities.Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
            EspecialidadDesktop formesp = new EspecialidadDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formesp.ShowDialog();
            this.Listar();
            */
        }

        private void tsdEliminar_Click(object sender, EventArgs e)
        {
            if (itemSeleccionado())
            {
                EspecialidadDesktop formEspecialidad = new EspecialidadDesktop();
                formEspecialidad.ModoFormulario = ApplicationForm.ModoForm.Baja;
                formEspecialidad.EspecialidadActual = ((Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem);
                formEspecialidad.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("No hay especialidades seleccionadas", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            /* Viejo
            if(this.dgvEspecialidades.Rows.Count > 1)
            {
                int ID = ((Business.Entities.Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
                EspecialidadDesktop formesp = new EspecialidadDesktop(ID, ApplicationForm.ModoForm.Baja);
                formesp.ShowDialog();
                this.Listar();
            }*/
        }
    }
}
