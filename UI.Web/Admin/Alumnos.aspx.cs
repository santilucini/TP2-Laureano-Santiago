using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class Alumnos : System.Web.UI.Page
    {
        #region Atributos

        private Persona Entity;

        #endregion

        #region Propiedades

        PersonasLogic _logic;

        private PersonasLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new PersonasLogic();
                }
                return _logic;
            }
        }
        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }

        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }
        private int SelectedID
        {
            get
            {
                if (this.ViewState["SelectedID"] != null)
                {
                    return (int)this.ViewState["SelectedID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                this.ViewState["SelectedID"] = value;
            }
        }

        private bool IsEntitySelected
        {
            get
            {
                return (this.SelectedID != 0);
            }
        }

        #endregion

        #region Metodos

        private void LoadGrid()
        {
            this.gridView.DataSource = Logic.GetAllTipo(Persona.TiposPersonas.Alumno);
            this.gridView.DataBind();
        }

        private void LoadForm(int id)
        {
            Entity = Logic.GetOne(id);
            idTextBox.Text = Entity.ID.ToString();
            nombreTextBox.Text = Entity.Nombre;
            apellidoTextBox.Text = Entity.Apellido;
            direccionTextBox.Text = Entity.Direccion;
            emailTextBox.Text = Entity.Email;
            telefonoTextBox.Text = Entity.Telefono;
            fechaNacimientoTextBox.Text = Entity.FechaNacimiento.ToString();
            legajoTextBox.Text = Entity.Legajo.ToString();
            tipoPersonaTextBox.Text = ((int)Entity.TipoPersona).ToString();
            idPlanDropDownList.Text = Entity.IDPlan.ToString();
        }

        private void LoadEntity(Business.Entities.Persona persona)
        {
            persona.Nombre = nombreTextBox.Text;
            persona.Apellido = apellidoTextBox.Text;
            persona.Direccion = direccionTextBox.Text;
            persona.Email = emailTextBox.Text;
            persona.FechaNacimiento = Convert.ToDateTime(fechaNacimientoTextBox.Text);
            persona.IDPlan = Convert.ToInt32(idPlanDropDownList.Text);
            persona.Legajo = Convert.ToInt32(legajoTextBox.Text);
            persona.TipoPersona = Persona.TiposPersonas.Alumno;
            persona.Telefono = telefonoTextBox.Text;
        }

        private void EnableForm(bool enable)
        {
            idTextBox.Enabled = enable;
            nombreTextBox.Enabled = enable;
            apellidoTextBox.Enabled = enable;
            direccionTextBox.Enabled = enable;
            emailTextBox.Enabled = enable;
            fechaNacimientoTextBox.Enabled = enable;
            legajoTextBox.Enabled = enable;
            tipoPersonaTextBox.Enabled = enable;
            idPlanDropDownList.Enabled = enable;

        }

        private void ClearForm()
        {
            idTextBox.Text = string.Empty;
            nombreTextBox.Text = string.Empty;
            apellidoTextBox.Text = string.Empty;
            direccionTextBox.Text = string.Empty;
            emailTextBox.Text = string.Empty;
            fechaNacimientoTextBox.Text = string.Empty;
            legajoTextBox.Text = string.Empty;
        }

        private void DeleteEntity(int id)
        {
            Logic.Delete(id);
        }

        private void SaveEntity(Persona persona)
        {
            Logic.Save(persona);
        }
        #endregion

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {   
                tipoPersonaTextBox.Text = "1";

                PlanLogic plan = new PlanLogic();
                List<Plan> planes = plan.GetAll();
                foreach (var pl in planes)
                {
                    idPlanDropDownList.Items.Add(pl.ID.ToString());
                }

                Usuario usuario = (Usuario)Session["UsuarioActual"];
                UsuarioLogic usuarioLogic = new UsuarioLogic();
                try
                {

                    ModuloUsuario moduloUsuario = usuarioLogic.GetModuloUsuario("Personas", usuario.ID);
                    if (moduloUsuario.IDModulo != 0)
                    {
                        editarLinkButton.Enabled = moduloUsuario.PermiteModificacion;
                        eliminarLinkButton.Enabled = moduloUsuario.PermiteBaja;
                        nuevoLinkButton.Enabled = moduloUsuario.PermiteAlta;
                        gridView.Enabled = moduloUsuario.PermiteConsulta;
                        if (moduloUsuario.PermiteConsulta)
                        {
                            LoadGrid();
                        }
                    }
                    else
                    {
                        gridPanel.Visible = false;
                        formPanel.Visible = false;
                        gridActionsPanel.Visible = false;
                        Page.Response.Write("Usuario sin permisos");
                    }
                }
                catch (Exception ex)
                {
                    Exception ExcepcionManejada = new Exception("Error al recuperar Modulo", ex);

                    throw ExcepcionManejada;
                }
            }
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Alta:
                    this.Entity = new Persona();
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    this.LoadGrid();
                    break;
                case FormModes.Modificacion:
                    this.Entity = new Persona();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                default:
                    break;
            }
            this.formPanel.Visible = false;
            gridActionsPanel.Visible = true;
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            formPanel.Visible = false;
            gridActionsPanel.Visible = true;
            LoadGrid();
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                gridActionsPanel.Visible = false;
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
            }
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                gridActionsPanel.Visible = false;
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
            }
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            gridActionsPanel.Visible = false;
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
        }

        #endregion 
    }
}