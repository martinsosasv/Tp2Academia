using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Entidades
    {
        public Entidades()
        {
            this.State = States.New;
        }

        public enum States
        {
            New, Deleted, Modified, Unmodified
        }

        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private States _state;
        public States State
        {
            get { return _state; }
            set { _state = value; }
        }
    }
}
