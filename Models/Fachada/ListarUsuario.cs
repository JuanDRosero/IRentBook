using IRentBook.Models.Singleton;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRentBook.Models.Fachada
{
    public class ListarUsuario
    {

        public List<Usuario> listar()
        {
            //Intancia del singlenton
            var cadena = ConexionBD.Instance;
            string command = "SELECT * FROM pruebas.usuario;";
            List<Usuario> listaUsuarios = new List<Usuario>();
            var conexion = cadena.connection;
            try
            {
                conexion.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(command, conexion);
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    listaUsuarios.Add(new Usuario
                    {
                        id = Int32.Parse(mySqlDataReader[0].ToString()),
                        codigo = Int32.Parse(mySqlDataReader[1].ToString()),
                        pass = mySqlDataReader[2].ToString(),
                        nombre = mySqlDataReader[3].ToString(),
                        direccion = mySqlDataReader[4].ToString()
                    });
                    //Console.WriteLine(mySqlDataReader[0] + "--" + mySqlDataReader[1]);
                }
                mySqlDataReader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conexion.Close();
            return listaUsuarios;
        }


    }
}
