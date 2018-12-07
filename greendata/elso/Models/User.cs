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
using System.ComponentModel;

namespace elso
{
    class User
    {
        #region Sql Server Connection
        private const string SERVER = "localhost";
        private const string DATABASE = "kepszerkeszto_db";
        private const string UID = "root";
        private const string PASSWORD = "";
        private static MySqlConnection dbConn = Database.DBConnection.GetdbConn();
        #endregion

        #region Properties
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
        #endregion

        #region Private User Constructor
        private User(int id, string u, string p, string email)
        {
            Id = id;
            Username = u;
            Password = p;
            Email = email;
        }

        #endregion
        // --------------------- Check LOGIN ---------------------
        #region Check Login
        public static bool IsLoggedIn()
        {
            if (LoggedInUsername == null) return false;
            else return true;
        }
        #endregion


        // --------------------- Find LOGGED IN USER_ID ---------------------
        #region Find Logged in User_ID
        public static string FindLoggedInUserID(string un, string pw)
        {


            string query = string.Format("select ID from users where username='" + un + "'and password='" + pw + "'");

            MySqlCommand cmd = new MySqlCommand(query, dbConn);

            string user_id = cmd.ExecuteScalar().ToString();

            dbConn.Close();

            return user_id;
        }
        #endregion

        // --------------------- LOGIN ---------------------
        #region User Login
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
                dbConn.Close();
                return false;
            }
        }
        #endregion

        // --------------------- LOGOUT ---------------------
        #region LOGOUT
        public static void UserLogout()
        {
            LoggedInUsername = null;
        }
        #endregion

        // --------------------- Image Save ---------------------
        #region Image Save
        public static void SaveImage(byte[] image)
        {

            var userImage = image;

            dbConn.Open();

            var command = new MySqlCommand("", dbConn);

            command.CommandText = "INSERT INTO images(user_id, image) VALUES(@user_id, @image);";

            var paramUserImage = new MySqlParameter("@image", MySqlDbType.Blob, userImage.Length);
            var paramUserId = new MySqlParameter("@user_id", MySqlDbType.VarChar, 250);

            paramUserImage.Value = userImage;
            paramUserId.Value = LoggedInUserID;

            command.Parameters.Add(paramUserImage);
            command.Parameters.Add(paramUserId);

            command.ExecuteNonQuery();

            dbConn.Close();

        }
        #endregion

        // --------------------- Load Image ---------------------
        #region Load Image

        #region GetImageList
        public static List<byte[]> GetImageList()
        {

            dbConn.Open();

            //ha az accepted=1 akkor megjelenik a közösben.
            string query = string.Format("SELECT image from images where accepted=1 ORDER BY created_at DESC ");

            MySqlCommand cmd = new MySqlCommand(query, dbConn);

            MySqlDataReader test;
            
                        test = cmd.ExecuteReader();

            byte[] bytes = null;


            List<byte[]> images_list = new List<byte[]>();


            while (test.Read())
            {

                for (int i = 0; i < test.FieldCount; i++)
                {
                    bytes = (byte[])test[i];
                }


                images_list.Add(bytes);


            }



            return images_list;
        }
        #endregion

        public static List<byte[]> GetImageListValidate()
        {

            dbConn.Open();


            string query = string.Format("SELECT image from images where accepted=0 ORDER BY created_at DESC ");

            MySqlCommand cmd = new MySqlCommand(query, dbConn);

            MySqlDataReader test;

            test = cmd.ExecuteReader();

            byte[] bytes = null;


            List<byte[]> images_list = new List<byte[]>();


            while (test.Read())
            {

                for (int i = 0; i < test.FieldCount; i++)
                {
                    bytes = (byte[])test[i];
                }
               
                images_list.Add(bytes);


            }



            return images_list;
        }
        #region GetImageListOBLike
        public static List<byte[]> GetImageListOBLike()
        {

            dbConn.Open();


            string query = string.Format("SELECT image from images ORDER BY like_count DESC");

            MySqlCommand cmd = new MySqlCommand(query, dbConn);

            MySqlDataReader test;


            test = cmd.ExecuteReader();

            byte[] bytes = null;


            List<byte[]> images_list = new List<byte[]>();


            while (test.Read())
            {

                for (int i = 0; i < test.FieldCount; i++)
                {
                    bytes = (byte[])test[i];
                }


                images_list.Add(bytes);


            }



            return images_list;
        }
        #endregion

        #region GetImageSource
        public static int imageCounter = 0;
        public static BitmapImage GetImageSource()
        {

            BitmapImage image = null;
            List<byte[]> images_list = GetImageList();
            if (imageCounter == images_list.Count)
            {
                imageCounter = 0;
            }

            byte[] bytes = null;

            for (int i = 0; i < images_list.Count; i++)
            {
                bytes = images_list[imageCounter];
            }

            MemoryStream stream = new MemoryStream(bytes);
            stream.Seek(0, SeekOrigin.Begin);

            System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
            image = new BitmapImage();
            image.BeginInit();
            MemoryStream ms = new MemoryStream();
            ms.Seek(0, SeekOrigin.Begin);
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            image.StreamSource = ms;
            image.StreamSource.Seek(0, SeekOrigin.Begin);
            image.EndInit();

            stream.Close();
            stream.Dispose();

            dbConn.Close();

            imageCounter++;

            return image;
        }
        #endregion

        public static int imageCounter2 = 0;
        public static BitmapImage GetImageSourceValidate()
        {

            BitmapImage image = null;
            List<byte[]> images_list = GetImageListValidate();
            if (imageCounter2 == images_list.Count)
            {
                imageCounter2 = 0;
            }

            byte[] bytes = null;
           
            
            for (int i = 0; i < images_list.Count; i++)
            {
                bytes = images_list[imageCounter2];
            }

            //ha nincs mit validálni, errort dob, ugyanis NULL értékű a puffer
            MemoryStream stream = new MemoryStream(bytes);
            stream.Seek(0, SeekOrigin.Begin);

            System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
            image = new BitmapImage();
            image.BeginInit();
            MemoryStream ms = new MemoryStream();
            ms.Seek(0, SeekOrigin.Begin);
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            image.StreamSource = ms;
            image.StreamSource.Seek(0, SeekOrigin.Begin);
            image.EndInit();

            stream.Close();
            stream.Dispose();

            dbConn.Close();

            imageCounter2++;

            return image;
        }

        #region GetImageSourceOBLike
        public static BitmapImage GetImageSourceOBLike()
        {

            BitmapImage image = null;


            List<byte[]> images_list = GetImageList();


            if (imageCounter == images_list.Count)
            {
                imageCounter = 0;
            }



            byte[] bytes = null;


            for (int i = 0; i < images_list.Count; i++)
            {
                bytes = images_list[imageCounter];
            }


            MemoryStream stream = new MemoryStream(bytes);
            stream.Seek(0, SeekOrigin.Begin);

            System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
            image = new BitmapImage();
            image.BeginInit();
            MemoryStream ms = new MemoryStream();
            ms.Seek(0, SeekOrigin.Begin);
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            image.StreamSource = ms;
            image.StreamSource.Seek(0, SeekOrigin.Begin);
            image.EndInit();

            stream.Close();
            stream.Dispose();

            dbConn.Close();

            imageCounter++;

            return image;
        }
        #endregion
        #endregion

        // --------------------- DB CLOSE ---------------------
        #region DB CLOSE
            public static void CloseDB()
            {
                dbConn.Close();
            }
        #endregion

        // --------------------- DB INSERT ---------------------
        #region DB INSERT

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
        #endregion

        // --------------------- DB UPDATE ---------------------
        #region DB UPDATE
        public static void Update(string u, string p, string email)
        {
            dbConn.Open();

            string query = string.Format("UPDATE users SET username='{0}', password='{1}', email='{2}', WHERE ID={3}", u, p, email, Id);

            MySqlCommand cmd = new MySqlCommand(query, dbConn);



            cmd.ExecuteNonQuery();

            dbConn.Close();

        }
        #endregion

        //update images set accepted=1 where accepted=2;

        // --------------------- Picture Accept UPDATE ---------------------
        public static void UpdateValidatePicture()
        {
            if (IsLoggedIn())
            {
                dbConn.Open();
                string queryId = string.Format("select ID from users where username='{0}';",LoggedInUsername);
                MySqlCommand cmd = new MySqlCommand(queryId, dbConn);
                string user_id = cmd.ExecuteScalar().ToString();

                string query = string.Format("update images set accepted=1 where user_id={0};",user_id);
                MySqlCommand Update_cmd = new MySqlCommand(query, dbConn);
                Update_cmd.ExecuteNonQuery();
                dbConn.Close();
            }
           
          
           

        }

        // --------------------- SEARCH USER NAME ---------------------
        #region Search User Name
        public static string SearchUserName(string felhasznaloNeve)
        {
            dbConn.Open();
            string query = string.Format("select username from users where username='{0}';", felhasznaloNeve);

            MySqlCommand cmd = new MySqlCommand(query, dbConn);
            var SavedString = (string)cmd.ExecuteScalar();
            dbConn.Close();
            return SavedString;
        }
        #endregion

        // --------------------- SEARCH USER EMAIL---------------------
        #region Search User Email
        public static string SearchUserEmail(string felhasznaloNeve)
        {
            dbConn.Open();
            string query = string.Format("select email from users where username='{0}';", felhasznaloNeve);

            MySqlCommand cmd = new MySqlCommand(query, dbConn);
            var SavedString = (string)cmd.ExecuteScalar();
            dbConn.Close();
            return SavedString;
        }
        #endregion

    }
}

