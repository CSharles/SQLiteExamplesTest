using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace SqliteTest01
{
    class Program
    {
        static void Main(string[] args)
        {
            Usuario usuarioActivo = null;
            string opcionTexto;
            int opcion;

            do
            {
               usuarioActivo= LogIn();
            } while (usuarioActivo==null);

            do
            {
                Console.Clear();
                Console.WriteLine("Administrador de Clientes");
                Console.WriteLine("Menú de opciones\n\r"+
                                    "1- Agregar Usuario\n\r"+
                                    "2- Agregar Cliente\n\r"+
                                    "3- Ver lista de clientes\n\r"+
                                    "5- Salir");
                opcionTexto = Console.ReadLine();
                int.TryParse(opcionTexto, out opcion);
                switch (opcion)
                {
                    case 1:
                        AgregarUsuario();
                        break;
                    case 2: AgregarClientes();
                        break;
                    case 3: LeerClientes();
                        break;
                    case 5:
                        Console.WriteLine("\n\rHa salido correctamente \n\rPresione una tecla para finalizar");
                        Console.ReadKey(true);
                        break;
                    default:
                        Console.WriteLine("\n\rOpción incorrecta\n\rIntentelo nuevamente");
                        Console.ReadKey(true);
                        break;
                } 
            } while (opcion!=5);
        }

        static void AgregarClientes()
        {
            int clienteAgregado, edad;
            string edadTexto;
            Cliente cliente=new Cliente();
            var clientes = new RepositorioClientes();
            Console.Clear();
            Console.WriteLine("Ingrese el nombre del cliente:");
            cliente.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el Apellido del cliente:");
            cliente.Apellido = Console.ReadLine();
            Console.WriteLine("Ingrese la Edad del cliente:");
            edadTexto = Console.ReadLine();
            int.TryParse(edadTexto, out edad);
            cliente.Edad = edad;
            clienteAgregado = clientes.AgregarCliente(cliente);
            Console.WriteLine("Clientes agregados: " + clienteAgregado+
                "\n\rPresione una tecla para ver el menu.");
            Console.ReadKey(true);
        }

        static void AgregarUsuario()
        {
            int UsuarioAgregado;
            
            Usuario usuario = new Usuario();
            var usuarios = new RepositorioUsuarios();
            Console.Clear();
            Console.WriteLine("Ingrese el nombre del Usuario:");
            usuario.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el Usuario:");
            usuario.nombreUsuario = Console.ReadLine();
            Console.WriteLine("Ingrese la contraseña:");
            usuario.Conntra = Console.ReadLine();
            UsuarioAgregado = usuarios.AgregarUsuario(usuario);
            Console.WriteLine("Usuarios agregados: " + UsuarioAgregado);
            Console.WriteLine("\n\rPresione una tecla para ver el menu.");
            Console.ReadKey(true);
        }

        static void LeerClientes()
        {
            var clientes = new RepositorioClientes();
            var listaClientes = clientes.LeerClientes();
            Console.Clear();
            foreach (var cliente in listaClientes)
            {
                Console.WriteLine(cliente);
            }
           Console.WriteLine("\n\rPresione una tecla para ver el menu.");
            Console.ReadKey();
        }

        static Usuario LogIn()
        {
            string usuario, contra;
            var usuarios = new RepositorioUsuarios();
            Console.Clear();
            Console.WriteLine("Ingrese su usuario:");
            usuario = Console.ReadLine();
            Console.WriteLine("Ingrese su contraseña:");
            contra = Console.ReadLine();

            Usuario usuarioActivo = usuarios.ConsultarUsuario(usuario, contra);
            if (usuarioActivo!=null)
            {
                Console.Clear();
                Console.WriteLine("Bienvenido "+ usuarioActivo.Nombre+
                    "\n\n\rPresione una tecla para ver el menu");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\n\rUsuario y contraseña inconrrectos\n\rPresione una tecla para continuar");
            }
            Console.ReadKey(true);
            return usuarioActivo;
        }
    }
}
