using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ModuloUsuario : Entidades
    {
        int _idUsuario;
        int _idModulo;
        bool _permiteAlta;
        bool _permiteBaja;
        bool _permiteModificacion;
        bool _permiteConsulta;

        public int IdUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }

        public int IdModulo
        {
            get { return _idModulo; }
            set { _idModulo = value; }
        }

        public bool PermiteAlta
        {
            get { return _permiteAlta; }
            set { _permiteAlta = value; }
        }

        public bool PermiteBaja
        {
            get { return _permiteBaja; }
            set { _permiteBaja = value; }
        }

        public bool PermiteModificacion
        {
            get { return _permiteModificacion; }
            set { _permiteModificacion = value; }
        }

        public bool PermiteConsulta
        {
            get { return _permiteConsulta; }
            set { _permiteConsulta = value; }
        }

    }
}

