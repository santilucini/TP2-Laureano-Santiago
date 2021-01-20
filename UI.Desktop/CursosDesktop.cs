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
    public partial class CursosDesktop : ApplicationForm
    {        
        #region Constructor
        public CursosDesktop()
        {
            InitializeComponent();            
            MateriaLogic materiaLogic = new MateriaLogic();
            List<Materia> materias = materiaLogic.GetAll();
            foreach(var mt in materias)
            {
                cbxMateria.Items.Add(mt.ID);
            }
            ComisionLogic comisionLogic = new ComisionLogic();
            List<Comision> comisiones = comisionLogic.GetAll();
            foreach (var cm in comisiones)
            {
                cbxComision.Items.Add(cm.ID);
            }
        }

        public CursosDesktop(ModoForm modo) : this()
        {
            this.ModoFormulario = modo;
        }

        public CursosDesktop(ModoForm modo, int ID ) : this()
        {
            this.ModoFormulario = modo;
            CursoLogic cursoLogic = new CursoLogic();
            CursoActual = cursoLogic.GetOne(ID);
            MapearDeDatos();
        }

        #endregion

        #region Propiedades

        private Curso _cursoActual;
        public Curso CursoActual
        {
            get { return _cursoActual; }
            set { _cursoActual = value; }
        }

        #endregion

        #region Metodos
        public override void MapearDeDatos()
        {
            PlanLogic plan = new PlanLogic();
            txtID.Text = this.CursoActual.ID.ToString();
            cbxComision.Text = this.CursoActual.IDMateria.ToString();
            cbxMateria.Text = CursoActual.IDMateria.ToString();
            txtAnioCalendario.Text = CursoActual.AnioCalendario.ToString();
            txtCupo.Text = CursoActual.Cupo.ToString();

        }

        public override void MapearADatos()
        {            
            switch (this.ModoFormulario)
            {
                case ModoForm.Alta:

                    Curso cur = new Curso();
                    CursoActual = cur;

                    CursoActual.IDMateria = Convert.ToInt32(cbxMateria.Text);
                    CursoActual.IDComision = Convert.ToInt32(cbxComision.Text);
                    CursoActual.Cupo = Convert.ToInt32(txtCupo.Text);
                    CursoActual.AnioCalendario = Convert.ToInt32(txtAnioCalendario.Text);

                    CursoActual.State = BusinessEntity.States.New;

                    break;
                case ModoForm.Modificacion:

                    CursoActual.IDMateria = Convert.ToInt32(cbxMateria.Text);
                    CursoActual.IDComision = Convert.ToInt32(cbxComision.Text);
                    CursoActual.Cupo = Convert.ToInt32(txtCupo.Text);
                    CursoActual.AnioCalendario = Convert.ToInt32(txtAnioCalendario.Text);

                    CursoActual.State = BusinessEntity.States.Modified;

                    break;
                case ModoForm.Baja:
                    CursoActual.State = BusinessEntity.States.Deleted;
                    break;
            }
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            CursoLogic cursoLogic = new CursoLogic();
            cursoLogic.Save(CursoActual);
        }

        public override bool Validar()
        {
            //Metodo sin correcta implementacion
            MapearADatos();
            string errores = "";            


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

        #region Eventos
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            GuardarCambios();
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CursosDesktop_Load(object sender, EventArgs e)
        {
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

        #endregion        
    }
}
