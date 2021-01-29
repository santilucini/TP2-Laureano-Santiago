using Business.Logic;
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
    public partial class Dictados : Form
    {
        #region Constructores
        public Dictados()
        {
            InitializeComponent();
        }
        public Dictados(Usuario usuario) : this()
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

        private void Listar()
        {
            DocenteCursoLogic docenteCursoLogic = new DocenteCursoLogic();
            dgvDictados.AutoGenerateColumns = false;
            dgvDictados.DataSource = docenteCursoLogic.GetAll();
        }

        private void Dictados_Load(object sender, EventArgs e)
        {
            Listar();
            /*
            try
            {
                UsuarioLogic usuarioLogic = new UsuarioLogic();
                ModuloUsuario moduloUsuario = usuarioLogic.GetModuloUsuario("Dictados", UsuarioActual.ID);
                if (moduloUsuario.IDUsuario != 0)
                {
                    tsbEditar.Enabled = moduloUsuario.PermiteModificacion;
                    tsbEliminar.Enabled = moduloUsuario.PermiteBaja;
                    tsbNuevo.Enabled = moduloUsuario.PermiteAlta;
                    dgvDictados.Enabled = moduloUsuario.PermiteConsulta;
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
            }*/
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            DictadosDesktop dictadosDesktop = new DictadosDesktop(ApplicationForm.ModoForm.Alta);
            dictadosDesktop.ShowDialog();
            Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.DocenteCurso)this.dgvDictados.SelectedRows[0].DataBoundItem).ID;            
            DictadosDesktop dictadosDesktop = new DictadosDesktop(ID, ApplicationForm.ModoForm.Modificacion);
            dictadosDesktop.ShowDialog();
            Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvDictados.Rows.Count > 1)
            {
                int ID = ((Business.Entities.DocenteCurso)this.dgvDictados.SelectedRows[0].DataBoundItem).ID;
                DictadosDesktop dictadosDesktop = new DictadosDesktop(ID, ApplicationForm.ModoForm.Baja);
                dictadosDesktop.ShowDialog();
                Listar();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
