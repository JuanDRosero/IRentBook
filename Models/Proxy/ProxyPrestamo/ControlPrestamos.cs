using IRentBook.Models.Singleton;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRentBook.Models.Proxy.ProxyPrestamo
{
    public class ControlPrestamos : AccionesPrestamos
    {
        public override void agregarPrestamo(Prestamo prestamo)
        {
            //Intancia del singlenton
            var cadena = ConexionBD.Instance;
            string command = "INSERT INTO `pruebas`.`prestamo` (`idLibroP`, `idPeliculaP`, `NombreLibro`, `NombreUsuario`, `DirecEmpleado`) VALUES ('" + prestamo.idLibroP + "', '" + prestamo.idPeliculaP + "', '" + prestamo.nombreProducto + "', '" + prestamo.nombreUsuario + "', '" + prestamo.direccionUsuario + "');";
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

        public override void editarPrestamo(Prestamo prestamo)
        {
            //Intancia del singlenton
            var cadena = ConexionBD.Instance;
            string command = "UPDATE `pruebas`.`prestamo` SET `idLibroP` = '" + prestamo.idLibroP + "', `idPeliculaP` = '" + prestamo.idPeliculaP + "', `NombreLibro` = '" + prestamo.nombreProducto + "', `NombreUsuario` = '" + prestamo.nombreUsuario + "', `DirecEmpleado` = '" + prestamo.direccionUsuario + "' WHERE (`idPrestamo` = '" + prestamo.idPrestamo + "');";
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

        public override void eliminarPrestamo(Prestamo prestamo)
        {
            //Intancia del singlenton
            var cadena = ConexionBD.Instance;
            string command = "DELETE FROM `pruebas`.`prestamo` WHERE (`idPrestamo` = '" + prestamo.idPrestamo + "');";
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

        public override List<Prestamo> leerPrestamo()
        {
            //Intancia del singlenton
            var cadena = ConexionBD.Instance;
            string command = "SELECT * FROM pruebas.prestamo;";
            List<Prestamo> listaUsuarios = new List<Prestamo>();
            var conexion = cadena.connection;
            try
            {
                conexion.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(command, conexion);
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    listaUsuarios.Add(new Prestamo
                    {
                        idPrestamo = Int32.Parse(mySqlDataReader[0].ToString()),
                        idLibroP = Int32.Parse(mySqlDataReader[1].ToString()),
                        idPeliculaP = Int32.Parse(mySqlDataReader[2].ToString()),
                        nombreProducto = mySqlDataReader[3].ToString(),
                        nombreUsuario = mySqlDataReader[4].ToString(),
                        direccionUsuario = mySqlDataReader[5].ToString()
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
