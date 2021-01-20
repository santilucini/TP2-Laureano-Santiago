using Business.Logic;
using Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class ModulosUsuarios : System.Web.UI.Page
    {

        #region Propiedades

        ModuloUsuarioLogic _logic;
        private ModuloUsuarioLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new ModuloUsuarioLogic();
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

        #endregion

        private ModuloUsuario Entity
        {
            get;
            set;
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

        #region Metodos - Funciones
        private void LoadGrid()
        {
            this.gridView.DataSource = this.Logic.GetAll();
            this.gridView.DataBind();
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

            Usuario usuario = (Usuario)Session["UsuarioActual"];
            UsuarioLogic usuarioLogic = new UsuarioLogic();
            try
            {

                ModuloUsuario moduloUsuario = usuarioLogic.GetModuloUsuario("ModulosUsuarios", usuario.ID);
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

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }

        private void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            idTextBox.Text = Entity.ID.ToString();
            idModuloDropDownList.Text = Entity.IDModulo.ToString();
            idUsuarioDropDownList.Text = Entity.IDUsuario.ToString();
            altaCheckBox.Checked = Entity.PermiteAlta;
            bajaCheckbox.Checked = Entity.PermiteBaja;
            consultaCheckbox.Checked = Entity.PermiteConsulta;
            modificacionCheckbox.Checked = Entity.PermiteModificacion;
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {            
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
            }
        }

        public void LoadEntity(ModuloUsuario moduloUsuario)
        {
            moduloUsuario.IDModulo = Convert.ToInt32(idModuloDropDownList.Text);
            moduloUsuario.IDUsuario = Convert.ToInt32(idUsuarioDropDownList.Text);
            moduloUsuario.PermiteAlta = altaCheckBox.Checked;
            moduloUsuario.PermiteBaja = bajaCheckbox.Checked;
            moduloUsuario.PermiteConsulta = consultaCheckbox.Checked;
            moduloUsuario.PermiteModificacion = modificacionCheckbox.Checked;
        }

        private void SaveEntity(ModuloUsuario moduloUsuario) 
        {
            this.Logic.Save(moduloUsuario);
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Alta:
                    this.Entity = new ModuloUsuario();
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    this.LoadGrid();
                    break;
                case FormModes.Modificacion:
                    this.Entity = new ModuloUsuario();
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
        }

        private void EnableForm(bool enable)
        {
            idTextBox.Enabled = enable;
            idModuloDropDownList.Enabled = enable;
            idUsuarioDropDownList.Enabled = enable;
            altaCheckBox.Enabled = enable;
            bajaCheckbox.Enabled = enable;
            consultaCheckbox.Enabled = enable;
            modificacionCheckbox.Enabled = enable;
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
            }
        }

        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
        }

        private void ClearForm()
        {
            idTextBox.Text = string.Empty;
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }
    }
}