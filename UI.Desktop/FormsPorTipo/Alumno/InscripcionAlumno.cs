using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop.FormsPorTipo.Alumno
{
    public partial class InscripcionAlumno : Form
    {
        private Usuario _Usuario;
        private Operacion _Operacion;
        private AlumnoInscripcionLogic _AlumInsLogic;

        public enum Operacion
        {
            VerCursos,
            InscribirCursos
        }
        #region Propidades
        public Usuario UsuarioActual
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }

        public AlumnoInscripcionLogic AlumInsLogic
        {
            get { return _AlumInsLogic; }
            set { _AlumInsLogic = value; }
        }

        public Operacion TipoOperacion
        {
            get { return _Operacion; }
            set { _Operacion = value; }
        }
        #endregion

        #region Constructor
        public InscripcionAlumno(Usuario usuario)
        {
            UsuarioActual = usuario;
            AlumInsLogic = new AlumnoInscripcionLogic();
            InitializeComponent();
            this.dgvInscripcionAlumno.AutoGenerateColumns = false;
        }
        #endregion

        #region Metodos
        public void Listar()
        {
            try
            {
                switch (this.TipoOperacion)
                {
                    case InscripcionAlumno.Operacion.InscribirCursos:
                        this.Nota.Visible = false;
                        this.Condicion.Visible = false;
                        //Se cargan todos los cursos
                        CursoLogic curLogic = new CursoLogic();
                        dgvInscripcionAlumno.DataSource = curLogic.GetAll();
                        break;
                    case InscripcionAlumno.Operacion.VerCursos:
                        this.btnSeleccionar.Visible = false;
                        dgvInscripcionAlumno.DataSource = AlumInsLogic.GetAll(UsuarioActual);
                        break;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private bool itemSeleccionado()
        {
            return (this.dgvInscripcionAlumno.SelectedRows.Count > 0);
        }
        #endregion

        #region EventosFormulario
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (itemSeleccionado())
            {
                AlumnoInscripcion insAlumno = new AlumnoInscripcion();
                //Se pasarian los objetos correspondientes a la inscripcion
                insAlumno.Alumno = UsuarioActual.Persona;
                insAlumno.Curso = ((Curso)this.dgvInscripcionAlumno.SelectedRows[0].DataBoundItem);
                insAlumno.Condicion = "En Cursado";
                insAlumno.State = BusinessEntity.States.New;
                //En primera parte se valida que el usuario no este inscripto

                if (!AlumInsLogic.validarInscripcion(insAlumno))
                {
                    //Como segunda validacion que el curso al cual se quiera inscribir tenga cupo disponible
                    try
                    {
                        new CursoLogic().Update(insAlumno.Curso);
                        AlumInsLogic.Save(insAlumno);
                        MessageBox.Show("Inscripcion exitosa", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception Ex)
                    {                     
                        throw new Exception("El curso ingresado no tiene cupos");
                    }
                    
                    /*
                    if (insAlumno.Curso.Cupo > 0)
                    {
                        new CursoLogic().Update(insAlumno.Curso);
                        AlumInsLogic.Save(insAlumno);
                        MessageBox.Show("Inscripcion exitosa", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("El curso ingresado no tiene cupos", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }*/
                }
                else
                {
                    MessageBox.Show("El alumno ya se encuentra inscripto en el curso", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No hay items seleccionados", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void InscripcionAlumno_Shown(object sender, EventArgs e)
        {
            Listar();
        }
        #endregion
    }
}
