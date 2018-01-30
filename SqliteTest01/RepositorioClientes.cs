using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace SqliteTest01
{
    class RepositorioClientes
    {
        private string conString = ConfigurationManager.ConnectionStrings["SqliteConnection"].ConnectionString;
        public int AgregarCliente(Cliente cliente)
        {
            int clienteAgregado=0;
            using (var conn = new SQLiteConnection(conString))
            {
                string sql = "INSERT INTO Clientes (Nombre, Apellido, Edad) VALUES (@nombre, @Apellido, @Edad)";
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.Add(new SQLiteParameter("Nombre", cliente.Nombre));
                    cmd.Parameters.Add(new SQLiteParameter("Apellido", cliente.Apellido));
                    cmd.Parameters.Add(new SQLiteParameter("Edad", cliente.Edad));
                    clienteAgregado = cmd.ExecuteNonQuery();
                    
                }
            }
            return clienteAgregado;
        }
        public List<Cliente> LeerClientes()
        {
            var listaClientes = new List<Cliente>();
            using (var conn = new SQLiteConnection(conString))
            {
                string sql = "SELECT * FROM Clientes ORDER BY ClienteId";
                conn.Open();
                using (var command = conn.CreateCommand())
                {
                    command.CommandText = sql;
                    SQLiteDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Cliente cliente = new Cliente();
                        cliente.Id = reader.GetInt32(0);
                        cliente.Nombre = reader.GetString(1);
                        cliente.Apellido = reader.GetString(2);
                        cliente.Edad = reader.GetInt32(3);
                        listaClientes.Add(cliente);
                    }
                }
            }
            return listaClientes;
        }
    }
}
