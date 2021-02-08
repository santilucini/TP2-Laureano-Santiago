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
    public partial class DictadosDesktop : ApplicationForm
    {
        #region Constructor

        public DictadosDesktop()
        {
            InitializeComponent();
        }

        public DictadosDesktop(ModoForm modo) : this()
        {
            this.ModoFormulario = modo;
        }

        public DictadosDesktop(int ID, ModoForm modo) : this()
        {
            this.ModoFormulario = modo;
            DocenteCursoLogic docenteCursoLogic = new DocenteCursoLogic();
            DictadoActual = docenteCursoLogic.GetOne(ID);
            MapearDeDatos();
        }

        #endregion

        #region Propiedades
        
        private DocenteCurso _docenteCurso;

        public DocenteCurso DictadoActual
        {
            get { return _docenteCurso; }
            set { _docenteCurso = value; }
        }

        #endregion

        #region Metodos

        

        public override void MapearDeDatos()
        {
            
            txtID.Text = DictadoActual.ID.ToString();
            cbxIdCurso.Text = DictadoActual.IDCurso.ToString();
            cbxIdDocente.Text = DictadoActual.IDDocente.ToString();
            cbxCargo.Text = ((int)DictadoActual.Cargo).ToString();
        }

        public override void MapearADatos()
        {

            switch (this.ModoFormulario)
            {
                case ModoForm.Alta:
                    DocenteCurso docenteCurso = new DocenteCurso();
                    DictadoActual = docenteCurso;
                    DictadoActual.IDCurso = Convert.ToInt32(cbxIdCurso.Text);
                    DictadoActual.Cargo = (DocenteCurso.TiposCargos)Convert.ToInt32(cbxCargo.Text);
                    DictadoActual.IDDocente = Convert.ToInt32(cbxIdDocente.Text);

                    DictadoActual.State = BusinessEntity.States.New;

                    break;
                case ModoForm.Modificacion:
                    DictadoActual.IDCurso = Convert.ToInt32(cbxIdCurso.Text);
                    DictadoActual.Cargo = (DocenteCurso.TiposCargos)Convert.ToInt32(cbxCargo.Text);
                    DictadoActual.IDDocente = Convert.ToInt32(cbxIdDocente.Text);

                    DictadoActual.State = BusinessEntity.States.Modified;

                    break;
                case ModoForm.Baja:
                    DictadoActual.State = BusinessEntity.States.Deleted;
                    break;
            }
        }
        public override void GuardarCambios()
        {
            MapearADatos();
            DocenteCursoLogic docenteCursoLogic = new DocenteCursoLogic();
            docenteCursoLogic.Save(DictadoActual);
        }
        public override bool Validar()
        {
            MapearADatos();
            string errores = "";

            if (cbxIdCurso.Text.Equals(""))
            {
                errores += "Id Curso |";
            }

            if (cbxIdDocente.Text.Equals(""))
            {
                errores += "Id Docente |";
            }

            if (cbxCargo.Text.Equals(""))
            {
                errores += "Cargo |";
            }

            if (IsValidString(errores))
            {
                Notificar("Datos Incorrectos", "Campos que no pueden quedar vacios :" + errores, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void DictadosDesktop_Load(object sender, EventArgs e)
        {   
            CursoLogic cursoLogic = new CursoLogic();
            List<Curso> cursos = cursoLogic.GetAll();
            foreach (var cr in cursos)
            {
                cbxIdCurso.Items.Add(cr.ID.ToString());
            }

            PersonasLogic personasLogic = new PersonasLogic();
            List<Persona> docentes = personasLogic.GetAllTipo(Persona.TiposPersonas.Docente);
            foreach(var dc in docentes)
            {
                cbxIdDocente.Items.Add(dc.ID.ToString());
            }

            for (int i = 0; i < 4; i++)
            {
                cbxCargo.Items.Add(i);
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
