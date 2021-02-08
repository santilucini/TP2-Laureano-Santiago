using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
   public class AlumnoInscripcion : BusinessEntity
    {
        #region Atributos
        private int _Nota;
        private Persona _Alumno;
        private Curso _Curso;
        private string _Condicion;
        #endregion

        #region Constructores
        public AlumnoInscripcion()
        {
            Alumno = new Persona();
            Curso = new Curso();
        }
        #endregion

        #region Propiedades
        // AlumnoInscripcion
        public string Condicion
        {
            get { return _Condicion; }
            set { _Condicion = value; }
        }

        public int Nota
        {
            get { return _Nota; }
            set { _Nota = value; }
        }

        public Persona Alumno
        {
            get { return _Alumno; }
            set { _Alumno = value; }
        }

        public int IDAlumno
        {
            get { return Alumno.ID; }
            set { Alumno.ID = value; }
            
        }
      
        public string NombreAlumno
        {
            get { return Alumno.Apellido + ", " + Alumno.Nombre; }
            

        }

        public string ApellidoAlumno
        {
            get { return Alumno.Apellido; }
        }

        // Curso

        public Curso Curso
        {
            get { return _Curso; }
            set { _Curso = value; }
        }

        public int IDCurso
        {
            get { return Curso.ID; }
            set { Curso.ID = value; }
            
        }

        public string DescMateria
        {
            get { return Curso.DescMateria; }
            set { Curso.DescMateria = value; }
        }

        public string DescComision
        {
            get { return Curso.DescComision; }
        }

        #endregion
    }
}
