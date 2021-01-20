using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;
using System.ComponentModel.Design;

namespace UI.Desktop
{
    public partial class InscripcionesDesktop : ApplicationForm
    {
        #region Constructor

        public InscripcionesDesktop()
        {
            InitializeComponent();
        }

        public InscripcionesDesktop(ModoForm modo) : this()
        {
            this.ModoFormulario = modo;
        }

        public InscripcionesDesktop(int ID, ModoForm modo) : this()
        {
            this.ModoFormulario = modo;
            AlumnoInscripcionLogic alumnoInscripcionLogic = new AlumnoInscripcionLogic();
            InscripcionActual = alumnoInscripcionLogic.GetOne(ID);
            MapearDeDatos();
        }

        #endregion

        #region Propiedades

        private AlumnoInscripcion _alumnoInscripcion;
        public AlumnoInscripcion InscripcionActual
        {
            get { return _alumnoInscripcion; }
            set { _alumnoInscripcion = value; }
        }

        #endregion

        #region Metodos

        public override void MapearDeDatos()
        {
            txtID.Text = InscripcionActual.ID.ToString();
            txtCondicion.Text = InscripcionActual.Condicion;
            txtNota.Text = InscripcionActual.Nota.ToString();
            cbxIdCurso.Text = InscripcionActual.IDCurso.ToString();
            cbxIDAlumno.Text = InscripcionActual.IDAlumno.ToString();
        }

        public override void MapearADatos()
        {

            switch (this.ModoFormulario)
            {
                case ModoForm.Alta:
                    AlumnoInscripcion alumnoInscripcion = new AlumnoInscripcion();
                    InscripcionActual = alumnoInscripcion;
                    InscripcionActual.IDAlumno = Convert.ToInt32(cbxIDAlumno.Text);
                    InscripcionActual.IDCurso = Convert.ToInt32(cbxIdCurso.Text);
                    if (!txtNota.Text.Equals(""))
                    {
                        InscripcionActual.Nota = Convert.ToInt32(txtNota.Text);
                    }
                    InscripcionActual.Condicion = txtCondicion.Text;                    

                    InscripcionActual.State = BusinessEntity.States.New;

                    break;
                case ModoForm.Modificacion:
                    InscripcionActual.IDAlumno = Convert.ToInt32(cbxIDAlumno.Text);
                    InscripcionActual.IDCurso = Convert.ToInt32(cbxIdCurso.Text);
                    InscripcionActual.Nota = Convert.ToInt32(txtNota.Text);
                    InscripcionActual.Condicion = txtCondicion.Text;

                    InscripcionActual.State = BusinessEntity.States.Modified;

                    break;
                case ModoForm.Baja:
                    InscripcionActual.State = BusinessEntity.States.Deleted;
                    break;
            }
        }
        public override void GuardarCambios()
        {
            MapearADatos();
            AlumnoInscripcionLogic alumnoInscripcionLogic = new AlumnoInscripcionLogic();
            alumnoInscripcionLogic.Save(InscripcionActual);
        }
        public override bool Validar()
        {
            MapearADatos();
            string errores = "";

            if (IsValidString(InscripcionActual.Condicion))
            { }
            else
            {
                errores += "Condicion |";
            }

            if (IsValidString(errores))
            {
                Notificar("Datos Incorrectos", "Los datos incorrectos son :" + errores, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                Notificar("Datos Correctos", "Registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }

        }

        #region ValidarCampos

        bool IsValidString(string str)
        {
            try
            {
                if (String.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }



        #endregion

        #endregion

        private void InscripcionesDesktop_Load(object sender, EventArgs e)
        {
            
            PersonasLogic personasLogic = new PersonasLogic();
            List<Persona> personas = personasLogic.GetAllTipo(Persona.TiposPersonas.Alumno);
            foreach (var al in personas)
            {
                cbxIDAlumno.Items.Add(al.ID.ToString());
            }

            CursoLogic cursoLogic = new CursoLogic();
            List<Curso> cursos = cursoLogic.GetAll();
            foreach(var cr in cursos)
            {
                cbxIdCurso.Items.Add(cr.ID.ToString());
            }


            switch (this.ModoFormulario)
            {
                case ModoForm.Alta:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    break;
                case ModoForm.Modificacion:
                    this.btnAceptar.Text = "Guardar";
                    break;
                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    break;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
