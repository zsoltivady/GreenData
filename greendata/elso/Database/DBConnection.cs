using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace elso.Database
{
   class DBConnection
    {
        private const String SERVER = "localhost";
        private const String DATABASE = "kepszerkeszto_db";
        private const String UID = "root";
        private const String PASSWORD = "";
        private static MySqlConnection dbConn;

        private DBConnection()
        {
           
        }

        public static void InitializeDB()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();

            builder.Server = SERVER;

            builder.UserID = UID;

            builder.Password = PASSWORD;

            builder.Database = DATABASE;

            String connString = builder.ToString();

            builder = null;

            Console.WriteLine(connString);

            dbConn = new MySqlConnection(connString);

            MySqlConnection conn = new MySqlConnection(connString);


        }

        public static MySqlConnection GetdbConn()
        {
            return dbConn;
        }


    }
}
