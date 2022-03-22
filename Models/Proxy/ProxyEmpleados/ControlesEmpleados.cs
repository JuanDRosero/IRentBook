using IRentBook.Models.Singleton;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRentBook.Models.Proxy.ProxyEmpleados
{
    public class ControlesEmpleados : AccionesEmpleados
    {
        public override void agregarEmpleado(Persona persona)
        {
            //Intancia del singlenton
            var cadena = ConexionBD.Instance;
            string command = "INSERT INTO `proyectopatrones`.`empleado` (`CodLoginEmpleado`, `ContraEmpleado`, `NombreEmpleado`) VALUES ('" + persona.codigo + "', '" + persona.pass + "', '" + persona.nombre + "');";
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

        public override void editarEmpleado(Persona persona)
        {
            //Intancia del singlenton
            var cadena = ConexionBD.Instance;
            string command = "UPDATE `proyectopatrones`.`empleado` SET `CodLoginEmpleado` = '" + persona.codigo + "', `ContraEmpleado` = '" + persona.pass + "', `NombreEmpleado` = '" + persona.nombre + "' WHERE (`idEmpleado` = '" + persona.id + "');";
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

        public override void eliminarEmpleado(Persona persona)
        {
            //Intancia del singlenton
            var cadena = ConexionBD.Instance;
            string command = "DELETE FROM `proyectopatrones`.`empleado` WHERE (`idEmpleado` = '" + persona.id + "');";
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

        public override List<Persona> leerEmpleados()
        {
            //Intancia del singlenton
            var cadena = ConexionBD.Instance;
            string command = "SELECT * FROM proyectopatrones.empleado;";
            List<Persona> listaEmpleados = new List<Persona>();
            var conexion = cadena.connection;
            try
            {
                conexion.Open();
                MySqlCommand mySqlCommand = new MySqlCommand(command, conexion);
                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    listaEmpleados.Add(new Persona
                    {
                        id = Int32.Parse(mySqlDataReader[0].ToString()),
                        codigo = Int32.Parse(mySqlDataReader[1].ToString()),
                        pass = mySqlDataReader[2].ToString(),
                        nombre = mySqlDataReader[3].ToString(),
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
            return listaEmpleados;
        }
    }
}
