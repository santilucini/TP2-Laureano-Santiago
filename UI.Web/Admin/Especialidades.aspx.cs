using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UI.Web.Basico;
using Util;

namespace UI.Web.Admin
{
    public partial class Especialidades : ApplicationForm
    {
        private EspecialidadLogic _logic;

        public EspecialidadLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    this._logic = new EspecialidadLogic();
                }
                return _logic;
            }
        }
        private Especialidad Entity
        {
            get;
            set;
        }
        public Usuario UsuarioActual
        {
            get;
            set;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioActual = (Usuario)Session["usuario"];
            if (UsuarioActual.Persona.TipoPersona == Persona.TiposPersonas.Admin)
            {
                if (!Page.IsPostBack)
                {
                    LoadGrid();
                    Master.MuestroMenu();
                }
            }
        }
        private void LoadGrid()
        {
            this.GridView.DataSource = Logic.GetAll();
            this.GridView.DataBind();
        }
        protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectID = (int)GridView.SelectedValue;
        }

        public void LoadEntity(Especialidad especialidad)
        {
            especialidad.Descripcion = txtDescripcion.Text;
        }

        public void LoadForm(int id)
        {
            Entity = this.Logic.GetOne(id);
            txtDescripcion.Text = Entity.Descripcion;
        }

        private void EnableForm(bool enable)
        {
            txtDescripcion.Enabled = enable;
        }

        public void SaveEntity(Especialidad especialidad)
        {
            Logic.Save(especialidad);
        }
        private void DeleteEntity(int ID)
        {
            Logic.Delete(ID);
        }

        private void ClearForm()
        {
            txtDescripcion.Text = String.Empty;
        }
        protected void ValidoDatos()
        {

            reqDescripcion.IsValid = Validaciones.EsCadenaValida(txtDescripcion.Text);
        }


        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (isEntititySelected)
            {
                formPanel.Visible = true;
                FormMode = FormModes.Baja;
                EnableForm(false);
                LoadForm(selectID);
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {

            formPanel.Visible = true;
            FormMode = FormModes.Alta;
            ClearForm();
            EnableForm(true);
        }



        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if (isEntititySelected)
            {
                ClearForm();
                EnableForm(true);
                formPanel.Visible = true;
                FormMode = FormModes.Modificacion;
                LoadForm(this.selectID);
            }
        }
        public void HabilitoValidaciones(bool enable)
        {
            //reqDescripcion.Enabled = enable;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            HabilitoValidaciones(true);
            this.ValidoDatos();
            switch (this.FormMode)
            {
                case FormModes.Alta:
                    if (Page.IsValid)
                    {
                        Entity = new Especialidad();
                        Entity.State = BusinessEntity.States.New;
                        LoadEntity(Entity);
                        SaveEntity(Entity);
                        LoadGrid();
                        Response.Redirect("~/Admin/Especialidades.aspx");
                    }
                    break;
                case FormModes.Modificacion:
                    if (Page.IsValid)
                    {
                        Entity = new EspecialidadLogic().GetOne(selectID);
                        Entity.State = BusinessEntity.States.Modified;
                        LoadEntity(Entity);
                        SaveEntity(Entity);
                        LoadGrid();
                        Response.Redirect("~/Admin/Especialidades.aspx");
                    }
                    break;
                case FormModes.Baja:
                    DeleteEntity(selectID);
                    LoadGrid();
                    Response.Redirect("~/Admin/Especialidades.aspx");
                    break;
                default:
                    break;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            ClearForm();
            EnableForm(false);
            formPanel.Visible = false;
            LoadGrid();
        }
    }
}