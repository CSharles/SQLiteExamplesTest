using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntityFrameworkTest;

namespace SQLiteUnitTest
{
    [TestClass]
    public class RepositorioUsuariosTest
    {
        [TestMethod]
        public void User_With_InvalidData_Return_Null()
        {
            // arrange  
            string usr = "Usuario002";
            string pwrd = "sysadmin2000";
            Usuario usuarioEsperado = null; //lo que esperamos que nos devuelva el repositorio

            // act  
            RepositorioUsuarios usuarios = new RepositorioUsuarios();
            Usuario usuarioResultado = usuarios.ConsultarUsuario(usr, pwrd);

            // assert  
            Assert.AreEqual(usuarioEsperado, usuarioResultado);
        }

        [TestMethod]
        public void User_With_ValidData_Return_Correct_User()
        {
            // arrange  
            string usr = "Usuario001";
            string pwrd = "sysadmin2020";
            //lo que esperamos que nos devuelva el repositorio
            Usuario usuarioEsperado = new   Usuario();
            usuarioEsperado.Nombre = "Juan Perez";

            // act  
            RepositorioUsuarios usuarios = new RepositorioUsuarios();
            Usuario usuarioResultado = usuarios.ConsultarUsuario(usr, pwrd);
    
            // assert  
            Assert.AreEqual(usuarioEsperado.Nombre, usuarioResultado.Nombre);
        }

    }
}
