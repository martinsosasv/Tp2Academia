using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Plan : Entidades
    {
        string _descripcion, _descripcionEspecialidad;
        Especialidad _especialidad;

        public string Descripcion
        {
            get
            {
                return _descripcion;
            }
            set
            {
                _descripcion = value;
            }
        }
        public Especialidad Especialidad
        {
            get
            {
                return _especialidad;
            }
            set
            {
                _especialidad = value;
            }
        }

        public string DescripcionEspecialidad
        {
            get { return Especialidad.Descripcion; }
        }
    }
}
