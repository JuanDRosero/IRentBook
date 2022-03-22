using IRentBook.Models.Proxy.ProxyGenero;
using IRentBook.Models.Singleton;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRentBook.Models.Proxy.ProxyPelicula
{
    public class ControlPeliculas: AccionesPeliculas
    {
        public override void agregarPelicula(Pelicula pelicula)
        {
            //Intancia del singlenton
            MetodosGenero mg = new MetodosGenero();
            List<Genero> listaGeneros = mg.leerGenero();
            var cadena = ConexionBD.Instance;
            string command = "INSERT INTO `proyectopatrones`.`pelicula` (`id_GeneroP`, `NombrePelicula`, `Duracion`, `Director`) VALUES ('" + listaGeneros.Where(e => e.nombre == pelicula.genero).FirstOrDefault().id + "', '" + pelicula.nombre + "', '" + pelicula.duracion + "', '" + pelicula.director + "');";
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

        public override void editarPelicula(Pelicula pelicula)
        {
            //Intancia del singlenton
            MetodosGenero mg = new MetodosGenero();
            List<Genero> listaGeneros = mg.leerGenero();
            var cadena = ConexionBD.Instance;
            string command = "UPDATE `proyectopatrones`.`pelicula` SET `id_GeneroP` = '" + listaGeneros.Where(e => e.nombre == pelicula.genero).FirstOrDefault().id + "', `NombrePelicula` = '" + pelicula.nombre + "', `Duracion` = '" + pelicula.duracion + "', `Director` = '" + pelicula.director + "' WHERE (`idPelicula` = '" + pelicula.id + "');";
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

        public override void eliminarPelicula(Pelicula pelicula)
        {
            //Intancia del singlenton
            MetodosGenero mg = new MetodosGenero();
            List<Genero> listaGeneros = mg.leerGenero();
            var cadena = ConexionBD.Instance;
            string command = "DELETE FROM `proyectopatrones`.`pelicula` WHERE (`idPelicula` = '" + listaGeneros.Where(e => e.nombre == pelicula.genero).FirstOrDefault().id + "');";
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

        public override List<Pelicula> leerPeliculas()
        {
            //Intancia del singlenton
            var cadena = ConexionBD.Instance;
            string command = "SELECT * FROM proyectopatrones.pelicula;";
            List<Pelicula> listaPelicula = new List<Pelicula>();
            var conexion = cadena.connection;
            try
            {
                conexion.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(command, conexion);
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    listaPelicula.Add(new Pelicula
                    {
                        id = Int32.Parse(mySqlDataReader[0].ToString()),
                        genero = mySqlDataReader[1].ToString(),
                        nombre = mySqlDataReader[2].ToString(),
                        duracion = Int32.Parse(mySqlDataReader[3].ToString()),
                        director = mySqlDataReader[4].ToString(),
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
            return listaPelicula;
        }
    }
}
