using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Negocio;


namespace UI.Consola
{
    public class Usuarios
    {
        Negocio.UsuarioLogic _usuarioNegocio;
        public Negocio.UsuarioLogic UsuarioNegocio
        {
            get { return _usuarioNegocio; }
            set { _usuarioNegocio = value; }
        }
        
        public Usuarios()
        {
            this.UsuarioNegocio = new Negocio.UsuarioLogic();
        }

        public void Menu()
        {
            bool seguir = true;
            while(seguir == true)
            {
                Console.WriteLine("1– Listado General");
                Console.WriteLine("2– Consulta");
                Console.WriteLine("3– Agregar");
                Console.WriteLine("4- Modificar");
                Console.WriteLine("5- Eliminar");
                Console.WriteLine("6- Salir");
                Console.Write("Ingrese una opcion: ");
                string opcion = Console.ReadLine();
                switch(opcion)
                {
                    case "1": this.ListadoGeneral();
                              break;
                    case "2": this.Consulta();
                              break;
                    case "3": this.Agregar();
                              break;
                    case "4": this.Modificar();
                              break;
                    case "5": this.Eliminar();
                              break;
                    case "6":
                              {
                                  seguir = this.Salir();
                                  break;
                              }
                    default: Console.WriteLine("La opcion no es válida");
                              break;
                }
            }
        }

        private void ListadoGeneral()
        {
            Console.Clear();
            foreach (Usuario usr in UsuarioNegocio.GetAll())
            {
                MostrarDatos(usr);
            }
        }
        public void MostrarDatos(Usuario u)
        {
            Console.WriteLine("Usuario: {0} ",u.ID);
            Console.WriteLine("\t\tNombre: {0} ",u.Nombre);
            Console.WriteLine("\t\tApellido: {0} ", u.Apellido);
            Console.WriteLine("\t\tNombre de usuario: {0} ", u.NombreUsuario);
            Console.WriteLine("\t\tClave: {0} ", u.Clave);
            Console.WriteLine("\t\tEmail: {0} ", u.Email);
            Console.WriteLine("\t\tHabilitado: {0} ", u.Habilitado);
            Console.WriteLine("");
        }

        public void Consulta()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese el id del usuario a consultar: ");
                int ID = int.Parse(Console.ReadLine());
                this.MostrarDatos(UsuarioNegocio.GetOne(ID));
            }
            catch (FormatException fe)
            { 
                Console.WriteLine("Error: la ID ingresada debe ser un numero entero");
            }
            catch(Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
            }
        }

        public void Modificar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese el ID del usuario a modificar: ");
                int ID = int.Parse(Console.ReadLine());
                Usuario usuario = UsuarioNegocio.GetOne(ID);
                Console.Write("Ingrese nombre: ");
                usuario.Nombre = Console.ReadLine();
                Console.Write("Ingrese apellido: ");
                usuario.Apellido = Console.ReadLine();
                Console.Write("Ingrese nombre de usuario: ");
                usuario.NombreUsuario = Console.ReadLine();
                Console.Write("Ingrese clave: ");
                usuario.Clave = Console.ReadLine();
                Console.Write("Ingrese email: ");
                usuario.Email = Console.ReadLine();
                Console.Write("Ingrese habilitacion del usuario (1-SI/otro-NO): ");
                usuario.Habilitado = (Console.ReadLine() == "1");
                usuario.State = Entidades.Entidades.States.Modified;
            }
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un numero entero");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Ingrese una tecla para continuar");
                Console.ReadKey();
            }
        }

        public void Agregar()
        {
            Usuario usuario = new Usuario();

            Console.Clear();
            Console.Write("Ingrese nombre: ");
            usuario.Nombre = Console.ReadLine();
            Console.Write("Ingrese apellido: ");
            usuario.Apellido = Console.ReadLine();
            Console.Write("Ingrese nombre de usuario: ");
            usuario.NombreUsuario = Console.ReadLine();
            Console.Write("Ingrese clave: ");
            usuario.Clave = Console.ReadLine();
            Console.Write("Ingrese email: ");
            usuario.Email = Console.ReadLine();
            Console.Write("Ingrese hablilitacion del usuario (1-SI/otro-NO): ");
            usuario.Habilitado = (Console.ReadLine() == "1");
            usuario.State = Entidades.Usuario.States.New;
            UsuarioNegocio.Save(usuario);
            Console.WriteLine();
            Console.WriteLine("ID: {0}",usuario.ID);
        }

        public void Eliminar()
        {
            try
            {
                Console.Clear();
                Console.Write("Ingrese el ID del usuario a eliminar: ");
                int ID = int.Parse(Console.ReadLine());
                UsuarioNegocio.Delete(ID);
            }
            catch (FormatException fe)
            {
                Console.WriteLine();
                Console.WriteLine("La ID ingresada debe ser un numero entero");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
                
            }
        }

        public bool Salir()
        {
            return false;
        }
    

    }
}
