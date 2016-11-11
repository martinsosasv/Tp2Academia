using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DD = Data.Database;


namespace Negocio
{
    public class ComisionLogic : Negocio
    {
        public ComisionLogic()
        {
            this.ComisionData = new DD.ComisionAdapter();

        }

        DD.ComisionAdapter _comisionData;
        public DD.ComisionAdapter ComisionData
        {
            get { return _comisionData; }
            set { _comisionData = value; }
        }

        public List<Comision> GetAll()
        {
            return this.ComisionData.GetAll();
        }

        public Comision GetOne(int id)
        {
            return this.ComisionData.GetOne(id);
        }

        public void Delete(int id)
        {
            this.ComisionData.Delete(id);
        }

        public void Save(Comision comision)
        {
            this.ComisionData.Save(comision);
        }

    }
}
