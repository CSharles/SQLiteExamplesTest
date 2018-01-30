using System;
using System.Configuration;
using System.Data.SQLite.EF6;
using System.Linq;

namespace EntityFrameworkTest
{
    public class RepositorioUsuarios
    {


        public int AgregarUsuario(Usuario nuevoUsr)
        {
            int usuarioAgregado = 0;
            using (var db = new sqliteDbTest01Entities())
            {
                db.Usuarios.Add(nuevoUsr);
                usuarioAgregado = db.SaveChanges();
            }
            return usuarioAgregado;
        }


        public Usuario ConsultarUsuario(string nombre, string contra)
        {

            Usuario usuarioExistente = null;

            using (var db = new sqliteDbTest01Entities())
            {
                usuarioExistente = db.Usuarios.Where(usuario => usuario.NombreUsuario == nombre && usuario.Contra==contra).FirstOrDefault();
                if (usuarioExistente != null)
                {
                    if (usuarioExistente.PrimerLog == null)
                    {
                        usuarioExistente.PrimerLog = DateTime.Today.ToString();
                    }
                    usuarioExistente.UltimoLog = DateTime.Today.ToString();
                    db.SaveChanges();
                }
                return usuarioExistente;
            }
        }
    }
}
