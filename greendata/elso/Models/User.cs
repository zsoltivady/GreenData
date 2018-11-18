using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace elso
{
    class User
    {

        private const String SERVER = "localhost";
        private const String DATABASE = "kepszerkeszto_db";
        private const String UID = "root";
        private const String PASSWORD = "";
        private static MySqlConnection dbConn = Database.DBConnection.GetdbConn();

        public int Id
        {
            get;

            private set;
        }

        public String Username
        {
            get;

            private set;
        }

        public String Password
        {
            get;


            private set;
        }

        public String Email
        {
            get;

            private set;
        }

        private User(int id, String u, String p, String email)
        {
            Id = id;
            Username = u;
            Password = p;
            Email = email;
        }

        public static User Insert(String u, String p, String email)
        {
            String query = String.Format("INSERT INTO users(username, password, email) VALUES ('{0}', '{1}', '{2}')", u, p, email);

            MySqlCommand cmd = new MySqlCommand(query, dbConn);

            dbConn.Open();

            cmd.ExecuteNonQuery();

            int id = (int)cmd.LastInsertedId;

            User user = new User(id, u, p, email);

            dbConn.Close();

            return user;
        }

        public void Update(String u, String p, String email)
        {
            String query = string.Format("UPDATE users SET username='{0}', password='{1}', email='{2}', WHERE ID={3}", u, p, email, Id);

            MySqlCommand cmd = new MySqlCommand(query, dbConn);

            dbConn.Open();

            cmd.ExecuteNonQuery();

            dbConn.Close();

        }



    }
}
