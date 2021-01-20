using Business.Entities;
using Business.Logic;
using System;
using UI.Web.Basico;
using Util;

namespace UI.Web.Docente
{
    public partial class CargarNotas : ApplicationForm
    {
        private AlumnoInscripcionLogic _logic;
        private Usuario _docente;

        public AlumnoInscripcionLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    this._logic = new AlumnoInscripcionLogic();
                }
                return _logic;
            }
        }

        private Usuario EntityDoc
        {
            get => _docente;
            set => _docente = value;
        }

        private AlumnoInscripcion EntityIns
        {
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            EntityDoc = (Usuario)Session["usuario"];
            if (EntityDoc.Persona.TipoPersona == Persona.TiposPersonas.Docente)
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
            this.ClearForm();
            selectID = (int)GridView.SelectedValue;
            LoadForm(this.selectID);
        }

        public void LoadEntity(AlumnoInscripcion inscripcion)
        {
            inscripcion.Alumno = EntityIns.Alumno;
            inscripcion.Curso = EntityIns.Curso;
            inscripcion.Condicion = "Corregido";
            inscripcion.Nota = Int32.Parse(txtNota.Text);
        }

        public void LoadForm(int id)
        {
            EntityIns = this.Logic.GetOne(id);
            txtNombre.Text = EntityIns.NombreAlumno;
            txtApellido.Text = EntityIns.ApellidoAlumno;
        }

        private void EnableForm(bool enable)
        {
            txtNombre.Enabled = enable;
            txtApellido.Enabled = enable;
            txtNota.Enabled = enable;
        }

        public void SaveEntity(AlumnoInscripcion inscripcion)
        {
            Logic.Save(inscripcion);
        }

        public void HabilitoValidaciones(bool enable)
        {
            reqNota.Enabled = enable;
        }
        private void DeleteEntity(AlumnoInscripcion inscripcion)
        {
            Logic.Delete(inscripcion);
        }
        private void ClearForm()
        {
            txtNombre.Text = String.Empty;
            txtApellido.Text = String.Empty;
            txtNota.Text = String.Empty;
        }

        protected void ValidoDatos()
        {
            reqNota.IsValid = Validaciones.EsNumerico(txtNota.Text);
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            HabilitoValidaciones(true);
            this.ValidoDatos();
            if (Page.IsValid)
            {
                switch (this.FormMode)
                {
                    case FormModes.Baja:
                        DeleteEntity(EntityIns);
                        LoadGrid();
                        break;
                    case FormModes.Modificacion:
                        EntityIns = new AlumnoInscripcionLogic().GetOne(selectID);
                        EntityIns.State = BusinessEntity.States.Modified;
                        LoadEntity(EntityIns);
                        SaveEntity(EntityIns);
                        LoadGrid();
                        break;
                    case FormModes.Alta:
                        EntityIns = new AlumnoInscripcionLogic().GetOne(selectID);
                        LoadEntity(EntityIns);
                        SaveEntity(EntityIns);
                        LoadGrid();
                        break;
                    default:
                        break;
                }
                Response.Redirect("~/Docente/CargarNotas.aspx");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            ClearForm();
            EnableForm(false);
            formPanel.Visible = false;
            LoadGrid();
        }

        protected void btnCorregir_Click(object sender, EventArgs e)
        {
            if (isEntititySelected)
            {
                formPanel.Visible = true;
                gridPanelFormCorregir.Visible = true;
                LoadForm(selectID);
                this.FormMode = FormModes.Modificacion;
            }
        }
    }
}