using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;

namespace Business.Logic
{
    public class UsuarioLogic : BusinessLogic
    {     

        public UsuarioLogic()
        {
            UsuarioData = new Data.Database.UsuarioAdapter();
        }

        private Data.Database.UsuarioAdapter _UsuarioData;
        public Data.Database.UsuarioAdapter UsuarioData
        {
            get { return _UsuarioData; }
            set { _UsuarioData = value; }
        }

        public bool ValidarUser(string nomuser, string clave)
        {
            return UsuarioData.ValidarUser(nomuser,clave);
        }

        public List<Usuario> GetAll()
        {
            return UsuarioData.GetAll();
        }

        public Business.Entities.Usuario GetOne(int ID)
        {
            return UsuarioData.GetOne(ID);
        }

        public Usuario GetOne(string nombUser, string claveUser)
        {
            return UsuarioData.GetOne(nombUser, claveUser);
        }

        public Business.Entities.Usuario GetOneByNombreUsuario(string nombreUsuario)
        {
            return UsuarioData.GetOneByNombreUsuario(nombreUsuario);
        }

        public void Delete(int ID)
        {
            UsuarioData.Delete(ID);
        }

        public void Save( Business.Entities.Usuario usuario)
        {
            UsuarioData.Save(usuario);
        }

        public ModuloUsuario GetModuloUsuario(string descripcion, int ID)
        {
            return UsuarioData.GetModuloUsuario(descripcion, ID);
        }

        public bool verificoLogin(string nombUsu, string claveUsu)
        {
            //Si se encontro un usuario, va atener un nombre distinto del nulo, no pense en otra forma de como verificar
            if (UsuarioData.GetOne(nombUsu, claveUsu).NombreUsuario != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
