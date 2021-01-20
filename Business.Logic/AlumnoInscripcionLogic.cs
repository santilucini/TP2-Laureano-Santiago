using Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class AlumnoInscripcionLogic : BusinessLogic
    {
        private Data.Database.AlumnoInscripcionAdapter _InscripcionData;
        public Data.Database.AlumnoInscripcionAdapter InscripcionData
        {
            get { return _InscripcionData; }
            set { _InscripcionData = value; }
        }
        public AlumnoInscripcionLogic()
        {
            InscripcionData = new Data.Database.AlumnoInscripcionAdapter();
        }

        public List<AlumnoInscripcion> GetAll()
        {
            return InscripcionData.GetAll();
        }

        public List<AlumnoInscripcion> GetAll(Usuario usuario)
        {
            try
            {   //Se devuelven las inscripciones dependiendo el tipo persona
                switch (usuario.Persona.TipoPersona)
                {
                    case Persona.TiposPersonas.Alumno:
                        return InscripcionData.GetInscripcionesAlumno(usuario);

                    case Persona.TiposPersonas.Docente:
                        return InscripcionData.GetInscripcionesDocente(usuario);

                    default: return null;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

        }

        //public int GetOneByDesc(string descripcion)
        //{
        //    return InscripcionData.GetOneByDesc(descripcion);
        //}

        public Business.Entities.AlumnoInscripcion GetOne(int ID)
        {
            return InscripcionData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            InscripcionData.Delete(ID);
        }
        public void Delete(AlumnoInscripcion InscripAlumno)
        {
            InscripcionData.Delete(InscripAlumno);
        }

        public void Save(Business.Entities.AlumnoInscripcion inscripcion)
        {
            if (inscripcion.Curso.Cupo > 0)
            {
                InscripcionData.Save(inscripcion);
            }
            else
            {
                throw new Exception();
            }
            
        }
        /// Metodo que valida que el alumno no este inscripto en ese curso

        public bool validarInscripcion(AlumnoInscripcion InscripAlumno)
        {
            return InscripcionData.GetOne(InscripAlumno);
        }
    }
}

