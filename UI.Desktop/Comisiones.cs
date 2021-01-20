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
    public partial class Comisiones : Form
    {
        #region Constructores
        public Comisiones()
        {
            InitializeComponent();
        }

        public Comisiones(Usuario usuario) : this()
        {
            UsuarioActual = usuario;
        }

        #endregion

        private Usuario _usuarioActual;
        public Usuario UsuarioActual
        {
            get { return _usuarioActual; }
            set { _usuarioActual = value; }
        }

        public void Listar()
        {
            ComisionLogic com = new ComisionLogic();
            this.dgvComisiones.AutoGenerateColumns = false;
            this.dgvComisiones.DataSource = com.GetAll();
        }

        #region Eventos
        private void Comisiones_Load(object sender, EventArgs e)
        {
            try
            {
                UsuarioLogic usuarioLogic = new UsuarioLogic();
                ModuloUsuario moduloUsuario = usuarioLogic.GetModuloUsuario("Comisiones", UsuarioActual.ID);
                if (moduloUsuario.IDUsuario != 0)
                {
                    tsbEditar.Enabled = moduloUsuario.PermiteModificacion;
                    tsbEliminar.Enabled = moduloUsuario.PermiteBaja;
                    tsbNuevo.Enabled = moduloUsuario.PermiteAlta;
                    dgvComisiones.Enabled = moduloUsuario.PermiteConsulta;
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
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            ComisionDesktop formespecialidad = new ComisionDesktop(ApplicationForm.ModoForm.Alta);
            formespecialidad.ShowDialog();
            this.Listar();
        }
        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
            ComisionDesktop formesp = new ComisionDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            formesp.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.Comision)this.dgvComisiones.SelectedRows[0].DataBoundItem).ID;
            ComisionDesktop formesp = new ComisionDesktop(ID, ApplicationForm.ModoForm.Baja);
            formesp.ShowDialog();
            this.Listar();
        }
        #endregion


    }
}
