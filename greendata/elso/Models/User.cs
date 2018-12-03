using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Configuration;
using System.IO;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace elso
{
    class User
    {

        private const string SERVER = "localhost";
        private const string DATABASE = "kepszerkeszto_db";
        private const string UID = "root";
        private const string PASSWORD = "";
        private static MySqlConnection dbConn = Database.DBConnection.GetdbConn();

        public static int Id
        {
            get;

            private set;
        }

        public string Username
        {
            get;

            private set;
        }

        public string Password
        {
            get;


            private set;
        }

        public string Email
        {
            get;

            private set;
        }

        public static string LoggedInUsername
        {
            get;


            private set;
        }

        public static string LoggedInUserID
        {
            get;

            private set;
        }

        public static bool Success
        {
            get;

            private set;
        }

        private User(int id, string u, string p, string email)
        {
            Id = id;
            Username = u;
            Password = p;
            Email = email;
        }

        // --------------------- check LOGIN ---------------------

        public static bool IsLoggedIn()
        {
            if (LoggedInUsername == null) return false;
            else return true;
        }


        // --------------------- find LOGGED IN USER_ID ---------------------


        public static string FindLoggedInUserID(string un, string pw)
        {


            string query = string.Format("select ID from users where username='" + un + "'and password='" + pw + "'");

            MySqlCommand cmd = new MySqlCommand(query,dbConn);

            string user_id = cmd.ExecuteScalar().ToString();

            dbConn.Close();

            return user_id;
        }


        // --------------------- LOGIN ---------------------


        public static bool UserLogin(string un, string pw)
        {
            Success = true;
            try
            {
                dbConn.Open();
            }
            catch (Exception)
            {
                Success = false;
            }
            if (Success)
            {
                MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString);
                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT count(*) FROM users WHERE username='" + un + "'AND password='" + pw + "'", conn);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    MessageBox.Show("Sikeres Bejelentkezés!");

                    LoggedInUsername = un;

                    LoggedInUserID = FindLoggedInUserID(un, pw);


                    return true;
                }
                else return false;
            }
            else
            {
                return false;
            }
        }

        // --------------------- LOGOUT ---------------------


        public static void UserLogout()
        {
            LoggedInUsername = null;
        }


        // --------------------- Image Save ---------------------

       


        public static void SaveImage(byte[] image)
        {
            dbConn.Open();

            string query = string.Format("INSERT INTO images(user_id, image) VALUES ('{0}', '{1}')", LoggedInUserID, image);

            MySqlCommand cmd = new MySqlCommand(query, dbConn);

            cmd.ExecuteNonQuery();

            dbConn.Close();

            MessageBox.Show("A Kép sikeresen hozzáadva!");

        }

      


        // --------------------- DB INSERT ---------------------


        public static User Insert(string u, string p, string email)
        {
            dbConn.Open();
            string query = string.Format("INSERT INTO users(username, password,  email) VALUES ('{0}', '{1}', '{2}');", u, p, email);

           MySqlCommand cmd = new MySqlCommand(query, dbConn);
           
            cmd.ExecuteNonQuery();

            int id = (int)cmd.LastInsertedId;

            User user = new User(id, u, p, email);

            dbConn.Close();


            return user;
        }


        // --------------------- DB UPDATE ---------------------


        public static void Update(string u, string p, string email)
        {
            dbConn.Open();

            string query = string.Format("UPDATE users SET username='{0}', password='{1}', email='{2}', WHERE ID={3}", u, p, email, Id);

            MySqlCommand cmd = new MySqlCommand(query, dbConn);

           

            cmd.ExecuteNonQuery();

            dbConn.Close();

        }



    }
}
