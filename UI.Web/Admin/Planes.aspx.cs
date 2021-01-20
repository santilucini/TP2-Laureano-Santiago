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
    public partial class Planes : ApplicationForm
    {
        private PlanLogic _logic;

        public PlanLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    this._logic = new PlanLogic();
                }
                return _logic;
            }
        }
        private Plan Entity
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

        public void cargoDropDownList()
        {
            dwEspecialidades.DataSource = new EspecialidadLogic().GetAll();
            dwEspecialidades.DataValueField = "ID";
            dwEspecialidades.DataTextField = "Descripcion";
            dwEspecialidades.DataBind();
        }

        protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectID = (int)GridView.SelectedValue;
        }

        public void LoadEntity(Plan plan)
        {
            plan.Descripcion = txtDescripcion.Text;
            plan.Especialidad = new EspecialidadLogic().GetOne(Int32.Parse(dwEspecialidades.SelectedValue));
        }

        public void LoadForm(int id)
        {
            Entity = this.Logic.GetOne(id);
            txtDescripcion.Text = Entity.Descripcion;
            cargoDropDownList();
            dwEspecialidades.SelectedValue = Entity.IDEspecialidad.ToString();
        }
        private void EnableForm(bool enable)
        {
            txtDescripcion.Enabled = enable;
            dwEspecialidades.Enabled = enable;
        }

        public void SaveEntity(Plan plan)
        {
            Logic.Save(plan);
        }
        public void HabilitoValidaciones(bool enable)
        {
            reqDescripcion.Enabled = enable;
        }

        private void DeleteEntity(int id)
        {
            Logic.Delete(id);
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
            cargoDropDownList();
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

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            ClearForm();
            EnableForm(false);
            formPanel.Visible = false;
            LoadGrid();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            HabilitoValidaciones(true);
            this.ValidoDatos();
            switch (this.FormMode)
            {
                case FormModes.Modificacion:
                    if (Page.IsValid)
                    {
                        Entity = new Plan();
                        Entity.ID = selectID;
                        Entity.State = BusinessEntity.States.Modified;
                        LoadEntity(Entity);
                        SaveEntity(Entity);
                        LoadGrid();
                        Response.Redirect("~/Admin/Planes.aspx");
                    }
                    break;
                case FormModes.Alta:
                    if (Page.IsValid)
                    {
                        Entity = new Plan();
                        LoadEntity(Entity);
                        SaveEntity(Entity);
                        LoadGrid();
                        Response.Redirect("~/Admin/Planes.aspx");
                    }
                    break;
                case FormModes.Baja:
                    HabilitoValidaciones(false);
                    DeleteEntity(selectID);
                    LoadGrid();
                    Response.Redirect("~/Admin/Planes.aspx");
                    break;
                default:
                    break;
            }

        }
    }
}