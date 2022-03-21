using IRentBook.Models.Singleton;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRentBook.Models.Proxy.ProxyLibros
{
    public class ControlLibros : AccionesLibro
    {
        public override void agregarLibro(Libro libro)
        {
            //Intancia del singlenton
            var cadena = ConexionBD.Instance;
            string command = "INSERT INTO `pruebas`.`libro` (`id_GeneroL`, `NombreLibro`, `NumPaginas`, `Autor`) VALUES ('" + libro.genero + "', '" + libro.nombre + "', '" + libro.paginas + "', '" + libro.autores + "');";
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

        public override void editarLibro(Libro libro)
        {
            //Intancia del singlenton
            var cadena = ConexionBD.Instance;
            string command = "UPDATE `pruebas`.`libro` SET `id_GeneroL` = '" + libro.genero + "', `NombreLibro` = '" + libro.nombre + "', `NumPaginas` = '" + libro.paginas + "', `Autor` = '" + libro.autores + "' WHERE (`idLibro` = '" + libro.id + "');";
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

        public override void eliminarLibro(Libro libro)
        {
            //Intancia del singlenton
            var cadena = ConexionBD.Instance;
            string command = "DELETE FROM `pruebas`.`libro` WHERE (`idLibro` = '" + libro.id + "');";
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

        public override List<Libro> leerLibros()
        {
            //Intancia del singlenton
            var cadena = ConexionBD.Instance;
            string command = "SELECT * FROM pruebas.libro;";
            List<Libro> listaUsuarios = new List<Libro>();
            var conexion = cadena.connection;
            try
            {
                conexion.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(command, conexion);
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    listaUsuarios.Add(new Libro
                    {
                        id = Int32.Parse(mySqlDataReader[0].ToString()),
                        nombre = mySqlDataReader[1].ToString(),
                        paginas = Int32.Parse(mySqlDataReader[2].ToString()),
                        autores = mySqlDataReader[3].ToString(),
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
