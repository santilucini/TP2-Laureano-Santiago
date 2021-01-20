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
    public partial class Materias : Form
    {
        private Materia _materiActual;
        public Materia MateriaActual
        {
            get { return _materiActual; }
            set { _materiActual = value; }
        }


        #region Constructores
        public Materias()
        {
            InitializeComponent();
            dgvMaterias.AutoGenerateColumns = false;
        }
        public void Listar()
        {
            MateriaLogic ml = new MateriaLogic();
            try
            {
                dgvMaterias.DataSource = ml.GetAll();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private bool itemSeleccionado()
        {
            return (dgvMaterias.SelectedRows.Count > 0);
        }

        public Materias(Usuario usuario):this()
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

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Materias_Load(object sender, EventArgs e)
        {
            Listar();
        }
        private void tsNuevo_Click(object sender, EventArgs e)
        {
            MateriaDesktop formMaterias = new MateriaDesktop();
            formMaterias.ModoFormulario = ApplicationForm.ModoForm.Alta;
            formMaterias.ShowDialog();
            this.Listar();
        }

        private void tsEditar_Click(object sender, EventArgs e)
        {
            if (itemSeleccionado())
            {
                MateriaDesktop formMaterias = new MateriaDesktop();
                formMaterias.ModoFormulario = ApplicationForm.ModoForm.Modificacion;
                formMaterias.MateriaActual = ((Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem);
                formMaterias.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("No hay materias seleccionadas", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            if (itemSeleccionado())
            {
                MateriaDesktop formMaterias = new MateriaDesktop();
                formMaterias.ModoFormulario = ApplicationForm.ModoForm.Baja;
                formMaterias.MateriaActual = ((Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem);
                formMaterias.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("No hay materias seleccionadas", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /* Viejo
        public void Listar()
        {
            MateriaLogic ml = new MateriaLogic();
            this.dgvMaterias.AutoGenerateColumns = false;
            this.dgvMaterias.DataSource = ml.GetAll();
        }
        */
        /*
        private void Materias_Load(object sender, EventArgs e)
        {
            try
            {
                UsuarioLogic usuarioLogic = new UsuarioLogic();
                ModuloUsuario moduloUsuario = usuarioLogic.GetModuloUsuario("Materias", UsuarioActual.ID);
                if (moduloUsuario.IDUsuario != 0)
                {
                    tsbEditar.Enabled = moduloUsuario.PermiteModificacion;
                    tsbEliminar.Enabled = moduloUsuario.PermiteBaja;
                    tsbNuevo.Enabled = moduloUsuario.PermiteAlta;
                    dgvMaterias.Enabled = moduloUsuario.PermiteConsulta;
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
            catch(Exception ex)
            {
                Exception ExcepcionManejada =
                    new Exception("Erro al recuperar Modulo", ex);

                throw ExcepcionManejada;
            }            
        }
        */
        /* Viejo
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }*/

            /* viejo
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        */
        /*
        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            MateriaDesktop formmateria = new MateriaDesktop(ApplicationForm.ModoForm.Alta);
            formmateria.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
            MateriaDesktop formmateria = new MateriaDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formmateria.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvMaterias.Rows.Count > 0)
            {
                int ID = ((Business.Entities.Materia)this.dgvMaterias.SelectedRows[0].DataBoundItem).ID;
                MateriaDesktop formmateria = new MateriaDesktop(ID, ApplicationForm.ModoForm.Baja);
                formmateria.ShowDialog();
                this.Listar();
            }
        }
        */
    }
}
