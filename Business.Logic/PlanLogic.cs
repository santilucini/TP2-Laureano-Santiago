using Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class PlanLogic : BusinessLogic
    {
        public PlanLogic()
        {
            PlanData = new Data.Database.PlanAdapter();
        }

        private Data.Database.PlanAdapter _PlanData;
        public Data.Database.PlanAdapter PlanData
        {
            get { return _PlanData; }
            set { _PlanData = value; }
        }

        public List<Plan> GetAll()
        {
            return PlanData.GetAll();
        }

        public Business.Entities.Plan GetOne(int ID)
        {
            return PlanData.GetOne(ID);
        }

        public int GetOneByDesc(string descripcion)
        {
            return PlanData.GetOneByDesc(descripcion);
        }

        public void Delete(int ID)
        {
            PlanData.Delete(ID);
        }

        public void Save(Business.Entities.Plan plan)
        {
            PlanData.Save(plan);
        }
    }
}