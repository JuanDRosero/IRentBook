using IRentBook.Models.Singleton;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IRentBook.Models;
using IRentBook.Models.Proxy.ProxyGenero;


namespace IRentBook.Models.Proxy.ProxyLibros
{
    public class ControlLibros : AccionesLibro
    {
        public override void agregarLibro(Libro libro)
        {
            //Intancia del singlenton
            MetodosGenero mg = new MetodosGenero();
            List<Genero> listaGeneros = mg.leerGenero();
            var cadena = ConexionBD.Instance;
            string command = "INSERT INTO `proyectopatrones`.`libro` (`id_GeneroL`, `NombreLibro`, `NumPaginas`, `Autor`) VALUES ('" + listaGeneros.Where(e=>e.nombre == libro.genero).FirstOrDefault().id + "', '" + libro.nombre + "', '" + libro.paginas + "', '" + libro.autores + "');";
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
            MetodosGenero mg = new MetodosGenero();
            List<Genero> listaGeneros = mg.leerGenero();
            var cadena = ConexionBD.Instance;
            string command = "UPDATE `proyectopatrones`.`libro` SET `id_GeneroL` = '" + listaGeneros.Where(e => e.nombre == libro.genero).FirstOrDefault().id + "', `NombreLibro` = '" + libro.nombre + "', `NumPaginas` = '" + libro.paginas + "', `Autor` = '" + libro.autores + "' WHERE (`idLibro` = '" + libro.id + "');";
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
            string command = "DELETE FROM `proyectopatrones`.`libro` WHERE (`idLibro` = '" + libro.id + "');";
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
            string command = "SELECT * FROM proyectopatrones.libro;";
            List<Libro> listaLibros = new List<Libro>();
            var conexion = cadena.connection;
            try
            {
                conexion.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(command, conexion);
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                MetodosGenero metodosGenero = new MetodosGenero();
                while (mySqlDataReader.Read())
                {
                    listaLibros.Add(new Libro
                    {
                        id = Int32.Parse(mySqlDataReader[0].ToString()),
                        genero = mySqlDataReader[1].ToString(),
                        nombre = mySqlDataReader[2].ToString(),
                        paginas = Int32.Parse(mySqlDataReader[3].ToString()),
                        autores = mySqlDataReader[4].ToString()
                        
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
            return listaLibros;
        }
    }
}
