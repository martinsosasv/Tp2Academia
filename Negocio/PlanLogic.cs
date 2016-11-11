using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DD = Data.Database;


namespace Negocio
{
    public class PlanLogic : Negocio
    {
        public PlanLogic()
        {
            this.PlanData = new DD.PlanAdapter();

        }

        DD.PlanAdapter _planData;
        public DD.PlanAdapter PlanData
        {
            get { return _planData; }
            set { _planData = value; }
        }

        public List<Plan> GetAll()
        {
            return this.PlanData.GetAll();
        }

        public Plan GetOne(int id)
        {
            return this.PlanData.GetOne(id);
        }

        public void Delete(Plan plan)
        {
            this.PlanData.Delete(plan);
        }

        /*public void Save(Plan plan)
        {
            this.PlanData.Save(plan);
        }*/

        public void Insert(Plan plan)
        {
            this.PlanData.Insert(plan);
        }

        public void Update(Plan plan)
        {
            this.PlanData.Update(plan);
        }

    }
}