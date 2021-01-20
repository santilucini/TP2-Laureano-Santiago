﻿using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using UI.Web.Basico;

namespace UI.Web.Alumno
{
    public partial class InscribirseCurso : ApplicationForm
    {
        private CursoLogic _curlogic;

        private CursoLogic CurLog
        {
            get
            {
                if (_curlogic == null)
                {
                    _curlogic = new CursoLogic();
                }
                return _curlogic;
            }
        }

        private AlumnoInscripcionLogic _inslogic;
        private AlumnoInscripcionLogic InsLog
        {
            get
            {
                if (_inslogic == null)
                {
                    _inslogic = new AlumnoInscripcionLogic();
                }
                return _inslogic;
            }
        }
        private Usuario Entity
        {
            get;
            set;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Entity = (Usuario)Session["usuario"];
            if (Entity.Persona.TipoPersona == Persona.TiposPersonas.Alumno)
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
            string operacion = Request.QueryString["op"].ToString();

            if (operacion == "VisualizarCursos")
            {
                this.GridViewInsc.Visible = false;
                this.btnInscribir.Visible = false;
                this.btnInscribir.Enabled = false;
                //Se necesita encontrar las inscripciones del alumno a esos cursos
                this.GridViewCurso.DataSource = InsLog.GetAll(Entity);
                this.GridViewCurso.DataBind();
            }
            else if (operacion == "InscripcionCurso")
            {
                this.GridViewCurso.Visible = false;
                //Se cargan todos los cursos posibles a inscribir
                this.GridViewInsc.DataSource = CurLog.GetAll();
                this.GridViewInsc.DataBind();
            }
        }

        protected void btnInscribir_Click(object sender, EventArgs e)
        {
            if (isEntititySelected)
            {
                AlumnoInscripcion insAlumno = new AlumnoInscripcion();
                //Se pasarian los objetos correspondientes a la inscripcion
                insAlumno.Alumno = Entity.Persona;
                insAlumno.Curso = (Curso)CurLog.GetOne(selectID);
                insAlumno.Condicion = "En Cursado";
                insAlumno.State = BusinessEntity.States.New;
                //En primera parte se valida que el usuario no este inscripto
                if (!InsLog.validarInscripcion(insAlumno))
                {
                    //Como segunda validacion que el curso al cual se quiera inscribir tenga cupo disponible
                    if (insAlumno.Curso.Cupo > 0)
                    {
                        CurLog.Update(insAlumno.Curso);
                        InsLog.Save(insAlumno);
                        MessageBox.Show("Inscripcion exitosa", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("El curso ingresado no tiene cupos", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("El alumno ya se encuentra inscripto en el curso", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No hay items seleccionados", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.LoadGrid();

        }

        protected void GridViewInsc_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectID = (int)GridViewInsc.SelectedValue;
        }
    }
}