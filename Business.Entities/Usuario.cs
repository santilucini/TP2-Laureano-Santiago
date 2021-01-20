using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Usuario : BusinessEntity
    {
        #region Atributos 
        private string _NombreUsuario;
        private string _Clave;
        private bool _Habilitado;
        private Persona _Persona;
        #endregion

        #region Constructores
        public Usuario()
        {
            Persona = new Persona();
        }
        #endregion

        #region Propiedades

        public string NombreUsuario
        {
            get { return _NombreUsuario; }
            set { _NombreUsuario = value; }
        }

        public string Clave
        {
            get { return _Clave; }
            set { _Clave = value; }
        }

        public bool Habilitado
        {
            get { return _Habilitado; }
            set { _Habilitado = value; }
        }

        // Persona
        public Persona Persona
        {
            get { return _Persona; }
            set { _Persona = value; }
        }

        public string Nombre
        {
            get { return Persona.Nombre; }
            set { Persona.Nombre = value; }
        }

        public string Apellido
        {
            get { return Persona.Apellido; }
            set { Persona.Apellido = value; }
        }

        public string Email
        {
            get { return Persona.Email; }
            set { Persona.Email = value; }
        }

        public int Legajo
        {
            get { return Persona.Legajo; }
            set { Persona.Legajo = value; }
        }

        #endregion


    }
}
