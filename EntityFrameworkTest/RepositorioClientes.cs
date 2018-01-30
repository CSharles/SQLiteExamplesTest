using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;


namespace EntityFrameworkTest
{
    class RepositorioClientes
    {
        public int AgregarCliente(Cliente cliente)
        {
            int clienteAgregado=0;
            using (var db = new sqliteDbTest01Entities())
            {
                db.Clientes.Add(cliente);
                clienteAgregado=db.SaveChanges();

            }
            return clienteAgregado;
        }
        public List<Cliente> LeerClientes()
        {
            var listaClientes = new List<Cliente>();
            using (var db = new sqliteDbTest01Entities())
            {
               listaClientes= db.Clientes.ToList();
            }
            return listaClientes;
        }
    }
}
