using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IRentBook.Models.Singleton
{
    public class ConexionBD
    {
        private static ConexionBD _instance = null;
        private static MySqlConnection sqlConnection;
        private ConexionBD()
        {
            sqlConnection = new MySqlConnection("user id=root;password=root;server=localhost;database=proyectopatrones");
        }

        public MySqlConnection connection
        {
            get
            {
                return sqlConnection;
            }
        }

        public static ConexionBD Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ConexionBD();
                }
                return _instance;
            }
        }
    }
}
