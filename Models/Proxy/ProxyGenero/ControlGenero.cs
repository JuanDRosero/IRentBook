using IRentBook.Models.Singleton;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRentBook.Models.Proxy.ProxyGenero
{
    public class ControlGenero : AccionesGenero
    {
        public override void agregarGenero(Genero genero)
        {
            //Intancia del singlenton
            var cadena = ConexionBD.Instance;
            string command = "INSERT INTO `pruebas`.`genero` (`NombreGenero`, `Descripcion`) VALUES ('" + genero.nombre + "', '" + genero.descripcion + "');";
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

        public override void editarGenero(Genero genero)
        {
            //Intancia del singlenton
            var cadena = ConexionBD.Instance;
            string command = "UPDATE `pruebas`.`genero` SET `NombreGenero` = '" + genero.nombre + "', `Descripcion` = '" + genero.descripcion + "' WHERE (`idGenero` = '" + genero.id + "');";
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

        public override void eliminarGenero(Genero genero)
        {
            //Intancia del singlenton
            var cadena = ConexionBD.Instance;
            string command = "DELETE FROM `pruebas`.`genero` WHERE (`idGenero` = '" + genero.id + "');";
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

        public override List<Genero> leerGenero()
        {
            //Intancia del singlenton
            var cadena = ConexionBD.Instance;
            string command = "SELECT * FROM pruebas.genero;";
            List<Genero> listaGenero = new List<Genero>();
            var conexion = cadena.connection;
            try
            {
                conexion.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(command, conexion);
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    listaGenero.Add(new Genero
                    {
                        id = Int32.Parse(mySqlDataReader[0].ToString()),
                        nombre = mySqlDataReader[1].ToString(),
                        descripcion = mySqlDataReader[2].ToString()
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
            return listaGenero;
        }
    }
}
