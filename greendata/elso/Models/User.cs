using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Configuration;
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

        private const String SERVER = "localhost";
        private const String DATABASE = "kepszerkeszto_db";
        private const String UID = "root";
        private const String PASSWORD = "";
        private static MySqlConnection dbConn = Database.DBConnection.GetdbConn();

        public static int Id
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

        public static String LoggedInUsername
        {
            get;


            private set;
        }

        public static String LoggedInUserID
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

        // --------------------- check LOGIN ---------------------

        public static bool IsLoggedIn()
        {
            if (LoggedInUsername == null) return false;
            else return true;
        }


        // --------------------- find LOGGED IN USER_ID ---------------------


        public static String FindLoggedInUserID(String un, String pw)
        {


            String query = String.Format("select ID from users where username='" + un + "'and password='" + pw + "'");

            MySqlCommand cmd = new MySqlCommand(query,dbConn);

            string user_id = cmd.ExecuteScalar().ToString();

            dbConn.Close();

            return user_id;
        }


        // --------------------- LOGIN ---------------------


        public static bool UserLogin(String un, String pw)
        {
            dbConn.Open();
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString);
            MySqlDataAdapter sda = new MySqlDataAdapter("SELECT count(*) FROM users WHERE username='" + un + "'AND password='" + pw + "'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                MessageBox.Show("Sikeres Bejelentkezés!");

                LoggedInUsername = un;

                LoggedInUserID =  FindLoggedInUserID(un, pw);


                return true;
            }
            else return false;
        }

        // --------------------- LOGOUT ---------------------


        public static void UserLogout()
        {
            LoggedInUsername = null;
        }


        // --------------------- Image Save ---------------------


        public static void SaveImage(object image)
        {
            String query = String.Format("INSERT INTO images(user_id, image) VALUES ('{0}', '{1}')", LoggedInUserID, image);

            MySqlCommand cmd = new MySqlCommand(query, dbConn);

            cmd.ExecuteNonQuery();

            dbConn.Close();

            MessageBox.Show("A Kép sikeresen hozzáadva!");

        }


        // --------------------- DB INSERT ---------------------


        public static User Insert(String u, String p, String email)
        {
            String query = String.Format("INSERT INTO users(username, password, email) VALUES ('{0}', '{1}', '{2}')", u, p, email);

            MySqlCommand cmd = new MySqlCommand(query, dbConn);


            cmd.ExecuteNonQuery();

            int id = (int)cmd.LastInsertedId;

            User user = new User(id, u, p, email);

            dbConn.Close();


            return user;
        }


        // --------------------- DB UPDATE ---------------------


        public static void Update(String u, String p, String email)
        {
            String query = String.Format("UPDATE users SET username='{0}', password='{1}', email='{2}', WHERE ID={3}", u, p, email, Id);

            MySqlCommand cmd = new MySqlCommand(query, dbConn);

            dbConn.Open();

            cmd.ExecuteNonQuery();

            dbConn.Close();

        }



    }
}
