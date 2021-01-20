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
    public partial class Planes : Form
    {
        #region Constructores
        public Planes()
        {
            InitializeComponent();
            dgvPlanes.AutoGenerateColumns = false;
        }
        public Planes(Usuario usuario) : this()
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
            PlanLogic pl = new PlanLogic();
            try
            {
                dgvPlanes.DataSource = pl.GetAll();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
            /*
            PlanLogic pl = new PlanLogic();
            this.dgvPlanes.AutoGenerateColumns = false;
            this.dgvPlanes.DataSource = pl.GetAll();
            */
        }
        private bool itemSeleccionado()
        {
            return (dgvPlanes.SelectedRows.Count > 0);
        }
        private void Planes_Load(object sender, EventArgs e)
        {
            this.Listar();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            PlanDesktop formPlanes = new PlanDesktop();
            formPlanes.ModoFormulario = ApplicationForm.ModoForm.Alta;
            formPlanes.ShowDialog();
            this.Listar();
            /* Viejo
            PlanDesktop formplan = new PlanDesktop(ApplicationForm.ModoForm.Alta);
            formplan.ShowDialog();
            this.Listar();
            */
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (itemSeleccionado())
            {
                PlanDesktop formUsuario = new PlanDesktop();
                formUsuario.ModoFormulario = ApplicationForm.ModoForm.Modificacion;
                formUsuario.PlanActual = ((Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem);
                formUsuario.ShowDialog();
                Listar();
            }
            else
            {
                MessageBox.Show("No hay planes seleccionados", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            /* Viejo
            int ID = ((Business.Entities.Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;
            PlanDesktop formplan = new PlanDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formplan.ShowDialog();
            this.Listar();
            */
        }

        private void tsdEliminar_Click(object sender, EventArgs e)
        {
            if (itemSeleccionado())
            {
                PlanDesktop formUsuario = new PlanDesktop();
                formUsuario.ModoFormulario = ApplicationForm.ModoForm.Baja;
                formUsuario.PlanActual = ((Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem);
                formUsuario.ShowDialog();
                Listar();
            }
            else
            {
                MessageBox.Show("No hay planes seleccionados", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            /* Viejo
            if (this.dgvPlanes.Rows.Count > 1)
            {
                int ID = ((Business.Entities.Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;
                PlanDesktop formplan = new PlanDesktop(ID, ApplicationForm.ModoForm.Baja);
                formplan.ShowDialog();
                this.Listar();
            }
            */
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        /* Viejo
        private void Planes_Load(object sender, EventArgs e)
        {
            try
            {
                UsuarioLogic usuarioLogic = new UsuarioLogic();
                ModuloUsuario moduloUsuario = usuarioLogic.GetModuloUsuario("Planes", UsuarioActual.ID);
                if (moduloUsuario.IDUsuario != 0)
                {
                    tsbEditar.Enabled = moduloUsuario.PermiteModificacion;
                    tsdEliminar.Enabled = moduloUsuario.PermiteBaja;
                    tsbNuevo.Enabled = moduloUsuario.PermiteAlta;
                    dgvPlanes.Enabled = moduloUsuario.PermiteConsulta;
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
        }*/
    }
}