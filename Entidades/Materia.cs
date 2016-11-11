using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Materia : Entidades
    {
        string _descripcion;
        int _HSSemanales;
        int _HSTotales;
        Plan _plan;
        

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        public int HSSemanales
        {
            get { return _HSSemanales; }
            set { _HSSemanales = value; }
        }

        public int HSTotales
        {
            get { return _HSTotales; }
            set { _HSTotales = value; }
        }

        public Plan Plan
        {
            get { return _plan; }
            set { _plan = value; }
        }
        
        public string DescripcionPlan
        {
            get { return _plan.Descripcion; }
            
        }

        public string DescripcionEspecPlan
        {
            get { return this.Plan.DescripcionEspecialidad; }
            
        }

    }
}
