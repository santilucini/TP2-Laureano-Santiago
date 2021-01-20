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

namespace UI.Desktop.FormsPorTipo.Docente
{
    public partial class FormIngresoNota : Form
    {
        private AlumnoInscripcion _Inscripcion;

        public AlumnoInscripcion InsActual
        {
            get { return _Inscripcion; }
            set { _Inscripcion = value; }
        }

        public FormIngresoNota(AlumnoInscripcion inscripcion)
        {
            InitializeComponent();
            InsActual = inscripcion;
        }

        public void cargoFormulario()
        {
            txtAlumno.Text = InsActual.ApellidoAlumno + ", " + InsActual.NombreAlumno;
            txtCondicion.Text = InsActual.Condicion;
        }

        public bool validarNota()
        {
            if (Int32.TryParse(txtNota.Text, out int valor))
            {
                return true;
            }
            else
            {
                MessageBox.Show("El valor ingresado no es valido", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validarNota())
            {
                InsActual.Nota = Int32.Parse(txtNota.Text);
                InsActual.Condicion = "Corregido";
                InsActual.State = BusinessEntity.States.Modified;
                new AlumnoInscripcionLogic().Save(InsActual);
                MessageBox.Show("Nota ingresada con exito", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Close();
        }

        private void formIngresoNota_Shown(object sender, EventArgs e)
        {
            cargoFormulario();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
