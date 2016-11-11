using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class ApplicationForm : Form  //Formulario básico del cual heredan todos los formularios que usemos para ABM
    {
        public enum ModoForm
        {
            Alta, Baja, Modificacion, Consulta
        }

        private ModoForm _modo;
        public ModoForm Modo
        {
            get { return _modo; }
            set { _modo = value; }
        }
        public ApplicationForm()
        {
            InitializeComponent();
        }

        public virtual void MapearDeDatos()
        {

        }
        public virtual void MapearADatos() 
        { 

        }
        public virtual void GuardarCambios()
        { 

        }
        public virtual bool Validar() 
        { 
            return false; 
        }

        public virtual void Notificar(string titulo, string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }

        public virtual void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }
    }
}
