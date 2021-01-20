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
    public partial class CargarNotas : System.Web.UI.Page
    {
        #region Atributos

        private AlumnoInscripcion Entity;

        #endregion

        #region Propiedades

        AlumnoInscripcionLogic _logic;

        private AlumnoInscripcionLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new AlumnoInscripcionLogic();
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
            this.gridView.DataSource = this.Logic.GetAll();
            this.gridView.DataBind();
        }

        private void LoadForm(int id)
        {
            Entity = Logic.GetOne(id);
            idTextBox.Text = Entity.ID.ToString();
            notaTextBox.Text = Entity.Nota.ToString();
            idCursoTextBox.Text = Entity.IDCurso.ToString();
            condicionTextBox.Text = Entity.Condicion;
            idAlumnoTextBox.Text = Entity.IDAlumno.ToString();
        }

        private void LoadEntity(AlumnoInscripcion alumnoInscripcion)
        {
            alumnoInscripcion.IDAlumno = Convert.ToInt32(idAlumnoTextBox.Text);
            alumnoInscripcion.IDCurso = Convert.ToInt32(idCursoTextBox.Text);
            if (notaTextBox.Text.Equals(""))
            {

            }
            else
            {
                alumnoInscripcion.Nota = Convert.ToInt32(notaTextBox.Text);
            }

            alumnoInscripcion.Condicion = condicionTextBox.Text;
        }        

        private void ClearForm()
        {
            notaTextBox.Text = string.Empty;
            idTextBox.Text = string.Empty;
            condicionTextBox.Text = string.Empty;
        }

        private void DeleteEntity(int id)
        {
            Logic.Delete(id);
        }

        private void SaveEntity(AlumnoInscripcion alumnoInscripcion)
        {
            Logic.Save(alumnoInscripcion);
        }
        #endregion

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                LoadGrid();
                idAlumnoTextBox.Enabled = false;
                idTextBox.Enabled = false;
                condicionTextBox.Enabled = false;
                idCursoTextBox.Enabled = false;
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
                    this.Entity = new AlumnoInscripcion();
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    this.LoadGrid();
                    break;
                case FormModes.Modificacion:
                    this.Entity = new AlumnoInscripcion();
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


        #endregion
    }
}