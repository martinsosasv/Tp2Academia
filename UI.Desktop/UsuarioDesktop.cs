using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Entidades;


namespace UI.Desktop
{
    public partial class UsuarioDesktop : ApplicationForm
    {
        private Entidades.Usuario _usuarioActual;
        public Entidades.Usuario UsuarioActual
        {
            get { return _usuarioActual; }
            set { _usuarioActual = value; }
        }

        public UsuarioDesktop()
        {
            InitializeComponent();
        }

        public UsuarioDesktop(ModoForm modo)  //Este constructor sirve para las altas
        {
            InitializeComponent();
            this.Modo = modo;
            this.Text = "Nuevo Usuario";
            this.btnAceptar.Text = "Guardar";
            
        }

        public UsuarioDesktop(int id, ModoForm modo)
        {
            InitializeComponent();
            this.Modo = modo;
            UsuarioLogic ul = new UsuarioLogic();
            this.UsuarioActual = ul.GetOne(id);
            this.MapearDeDatos();  //Ver si está bien implementado. LAB 4-Parte 2-Inciso 12.
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            this.txtApellido.Text = this.UsuarioActual.Apellido;
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
            this.txtEmail.Text = this.UsuarioActual.Email;
            this.txtClave.Text = this.UsuarioActual.Clave;
            this.txtConfirmarClave.Text = this.UsuarioActual.Clave;

            switch(this.Modo)
            {
                case (UsuarioDesktop.ModoForm.Alta): this.btnAceptar.Text = "Guardar";
                    break;
                case (UsuarioDesktop.ModoForm.Baja): this.btnAceptar.Text = "Eliminar";
                    break;
                case (UsuarioDesktop.ModoForm.Consulta): this.btnAceptar.Text = "Aceptar";
                    break;
                case (UsuarioDesktop.ModoForm.Modificacion): this.btnAceptar.Text = "Guardar";
                    break;
                default: break;
            }
        }



        public override void MapearADatos()
        {
            if (this.Modo == UsuarioDesktop.ModoForm.Alta || this.Modo == UsuarioDesktop.ModoForm.Modificacion) //Alta o Modif. se copian los datos de los controles al usuario actual.
            {
                if (this.Modo == UsuarioDesktop.ModoForm.Alta)            //Si es un alta se crea un nuevo usuario.
                {
                    this.UsuarioActual = new Entidades.Usuario();
                }

                this.UsuarioActual.Nombre = this.txtNombre.Text;
                this.UsuarioActual.Apellido = this.txtApellido.Text;
                this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                this.UsuarioActual.NombreUsuario = this.txtUsuario.Text;
                this.UsuarioActual.Email = this.txtEmail.Text;
                this.UsuarioActual.Clave = this.txtClave.Text;

                if (this.Modo == ModoForm.Modificacion) //Si es modif. el ID se mantiene, no así para un alta que se autoincrementa (supongo)
                {
                    this.UsuarioActual.ID = int.Parse(this.txtID.Text); 
                }
             }

            switch(this.Modo)
            {
                case ModoForm.Alta: this.UsuarioActual.State = Entidades.Entidades.States.New;
                    break;
                case ModoForm.Baja: this.UsuarioActual.State = Entidades.Entidades.States.Deleted;
                    break;
                case ModoForm.Consulta: this.UsuarioActual.State = Entidades.Entidades.States.Unmodified;
                    break;
                case ModoForm.Modificacion: this.UsuarioActual.State = Entidades.Entidades.States.Modified;
                    break;
                default: break;
            }
        }


        public override void GuardarCambios()
        {
            this.MapearADatos();
            UsuarioLogic ul = new UsuarioLogic();
            ul.Save(this.UsuarioActual);

        }


        public override bool Validar()
        {
            if (string.IsNullOrEmpty(this.txtApellido.Text) || string.IsNullOrEmpty(this.txtClave.Text) || string.IsNullOrEmpty(this.txtConfirmarClave.Text)
                || string.IsNullOrEmpty(this.txtEmail.Text) || string.IsNullOrEmpty(this.txtNombre.Text) || string.IsNullOrEmpty(this.txtUsuario.Text))

            {
                this.Notificar("Campos vacíos", "Algun campo quedo incompleto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (this.txtClave.Text != this.txtConfirmarClave.Text || this.txtClave.Text.Length < 8)
            {
                this.Notificar("Contraseña", "Asegurese de que las contraseñas coincidan y tengan al menos 8 caracteres", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else if (!(this.txtEmail.Text.Contains('@') && this.txtEmail.Text.Contains(".com")))
            {
                this.Notificar("Email", "El email ingresado es incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else return true;
        }



        public override void Notificar(string titulo, string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }



        /*public void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }*/



        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                this.GuardarCambios();
                this.Close();
            }
            
                this.Close();
        }



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
