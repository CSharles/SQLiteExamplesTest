using System;
using System.Configuration;
using System.Data.SQLite;

namespace SqliteTest01
{
    class RepositorioUsuarios
    {
        private string conString = ConfigurationManager.ConnectionStrings["SqliteConnection"].ConnectionString;

        public int AgregarUsuario(Usuario nuevoUsr)
        {
            int filas = 0;
            using (var conn = new SQLiteConnection(conString))
            {
                string sql = "INSERT INTO Usuarios (Nombre, Usuario, Contra) VALUES (@nombre, @usuario, @contra);";
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.Add(new SQLiteParameter("nombre", nuevoUsr.Nombre));
                    cmd.Parameters.Add(new SQLiteParameter("usuario", nuevoUsr.nombreUsuario));
                    cmd.Parameters.Add(new SQLiteParameter("contra", nuevoUsr.Conntra));
                    filas = cmd.ExecuteNonQuery();
                }
            }
            return filas;
        }
        public Usuario ConsultarUsuario(string nombre, string contra)
        {
            Usuario usuarioExistente = null;
            int usuarioId = 0;
            DateTime? fechaLog = null;

            using (var conn = new SQLiteConnection(conString))
            {
                string sql = "SELECT * FROM Usuarios WHERE Usuario= @usuario AND Contra= @contra;";
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.Add(new SQLiteParameter("usuario", nombre));
                    cmd.Parameters.Add(new SQLiteParameter("contra", contra));

                    using (var resultado = cmd.ExecuteReader())
                    {
                        if (resultado.HasRows)
                        {
                            resultado.Read();
                            usuarioId = Convert.ToInt32(resultado["ID"]);

                            if (!DBNull.Value.Equals(resultado["PrimerLog"]))
                            {
                                fechaLog = Convert.ToDateTime(resultado["PrimerLog"].ToString());
                            }
                            usuarioExistente = new Usuario(usuarioId, fechaLog);

                            usuarioExistente.Nombre = resultado["Nombre"].ToString();
                            usuarioExistente.nombreUsuario = resultado["Usuario"].ToString();
                            usuarioExistente.Conntra = resultado["Contra"].ToString();
                            usuarioExistente.UltimoLog = DateTime.Today;
                        }
                    }

                    if (usuarioExistente!=null)
                    {
                        sql = "UPDATE Usuarios SET UltimoLog = date('now') WHERE ID= @id";
                        cmd.CommandText = sql;
                        cmd.Parameters.Add(new SQLiteParameter("id", usuarioId));
                        cmd.ExecuteNonQuery();

                        if (fechaLog == null)
                        {
                            sql = "UPDATE Usuarios SET PrimerLog = date('now') WHERE ID= @id";
                            cmd.CommandText = sql;
                            cmd.Parameters.Add(new SQLiteParameter("id", usuarioId));
                            cmd.ExecuteNonQuery();
                        } 
                    }
                }
            }
            return usuarioExistente;
        }
    }
}
