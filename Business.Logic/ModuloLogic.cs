using Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class ModuloLogic : BusinessLogic
    {
        private Data.Database.ModuloAdapter _ModuloData;
        public Data.Database.ModuloAdapter ModuloData
        {
            get { return _ModuloData; }
            set { _ModuloData = value; }
        }
        public ModuloLogic()
        {
            ModuloData = new Data.Database.ModuloAdapter();
        }

        public List<Modulo> GetAll()
        {
            return ModuloData.GetAll();
        }

        //public int GetOneByDesc(string descripcion)
        //{
        //    return MateriaData.GetOneByDesc(descripcion);
        //}

        public Business.Entities.Modulo GetOne(int ID)
        {
            return ModuloData.GetOne(ID);
        }

        public void Delete(int ID)
        {
            ModuloData.Delete(ID);
        }

        public void Save(Business.Entities.Modulo modulo)
        {
            ModuloData.Save(modulo);
        }
    }
}
