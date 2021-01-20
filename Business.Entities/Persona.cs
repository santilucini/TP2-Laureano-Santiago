using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
   public class Persona : BusinessEntity
    {
        #region Atributos
        private string _Apellido;
        private string _Direccion;
        private string _Email;
        private DateTime _FechaNacimiento;
        private int _Legajo;
        private string _Nombre;
        private string _Telefono;
        private TiposPersonas _TipoPersona;
        private Plan _Plan;
        #endregion

        #region Constructores

        public Persona()
        {
            Plan = new Plan();
        }

        #endregion

        #region Propiedades
        public string Apellido
        {
            get { return _Apellido; }
            set { _Apellido = value; }
        }

        public string Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public DateTime FechaNacimiento
        {
            get { return _FechaNacimiento; }
            set { _FechaNacimiento = value; }
        }

        public int Legajo
        {
            get { return _Legajo; }
            set { _Legajo = value; }
        }

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }

        public enum TiposPersonas
        {
            Admin,
            Docente,
            Alumno
        }

        public TiposPersonas TipoPersona
        {
            get { return _TipoPersona; }
            set { _TipoPersona = value; }
        }

        // Plan
        public Plan Plan
        {
            get { return _Plan; }
            set { _Plan = value; }
        }

        public int IDPlan
        {
            get { return Plan.ID; }
            set { Plan.ID = value; }
        }

        public static List<TiposPersonas> GetAllTipos()
        {
            List<TiposPersonas> tiposPersonas = new List<TiposPersonas>();
            tiposPersonas.Add(TiposPersonas.Admin);
            tiposPersonas.Add(TiposPersonas.Alumno);
            tiposPersonas.Add(TiposPersonas.Docente);
            return tiposPersonas;
        }

        #endregion
    }
}
