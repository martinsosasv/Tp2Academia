using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario : Entidades
    {
        string _nombreUsuario;
        string _clave;
        string _nombre;
        string _apellido;
        string _email;
        bool _habilitado;
        
        public string NombreUsuario
        {
            get { return _nombreUsuario; }
            set { _nombreUsuario = value; }
        }

        public string Clave
        {
            get { return _clave; }
            set { _clave = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public bool Habilitado
        {
            get { return _habilitado; }
            set { _habilitado = value; }
        }
    }
}
