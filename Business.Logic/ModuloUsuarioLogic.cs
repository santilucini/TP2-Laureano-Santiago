using Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
   public class ModuloUsuarioLogic : BusinessLogic
    {
        private Data.Database.ModuloUsuarioAdapter _ModuloUsuarioData;
        public Data.Database.ModuloUsuarioAdapter ModuloUsuarioData
        {
            get { return _ModuloUsuarioData; }
            set { _ModuloUsuarioData = value; }
        }
        public ModuloUsuarioLogic()
        {
            ModuloUsuarioData = new Data.Database.ModuloUsuarioAdapter();
        }

        public List<ModuloUsuario> GetAll()
        {
            return ModuloUsuarioData.GetAll();
        }

        //public int GetOneByDesc(string descripcion)
        //{
        //    return MateriaData.GetOneByDesc(descripcion);
        //}

        public Business.Entities.ModuloUsuario GetOne(int ID)
        {
            return ModuloUsuarioData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            ModuloUsuarioData.Delete(ID);
        }

        public void Save(Business.Entities.ModuloUsuario modulousuario)
        {
            ModuloUsuarioData.Save(modulousuario);
        }
    }
}
