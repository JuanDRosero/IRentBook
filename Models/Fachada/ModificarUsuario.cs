using IRentBook.Models.Singleton;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRentBook.Models.Fachada
{
    public class ModificarUsuario
    {
        public void modificarUsuario(Usuario usuario)
        {
            //Intancia del singlenton
            var cadena = ConexionBD.Instance;
            string command = "UPDATE `pruebas`.`usuario` SET `CodLoginUsuario` = '" + usuario.codigo + "', `ContraUsuario` = '" + usuario.pass + "', `NombreUsuario` = '" + usuario.nombre + "', `DirecUsuario` = '" + usuario.direccion + "' WHERE (`idUsuario` = '" + usuario.id + "');";
            using (cadena.connection)
            {
                using (MySqlCommand mySqlCommand = new MySqlCommand(command))
                {
                    mySqlCommand.Connection = cadena.connection;
                    cadena.connection.Open();
                    mySqlCommand.ExecuteNonQuery();
                }
            }
        }
    }
}
