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
        private const string SERVER = "localhost";
        private const string DATABASE = "kepszerkeszto_db";
        private const string UID = "root";
        private const string PASSWORD = "";
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

            string connString = builder.ToString();

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
