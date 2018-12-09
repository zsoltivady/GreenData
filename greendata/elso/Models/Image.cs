using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace elso
{
    class Picture
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
        public static int UserID
        {
            get;

            private set;
        }
        public static MySqlDbType Img
        {
            get;

            private set;
        }
        public static int LikeCount
        {
            get;

            private set;
        }
        public static DateTime CreatedAt
        {
            get;

            private set;
        }
        public static int Accepted
        {
            get;

            private set;
        }
        public static string CreatedBy
        {
            get;

            private set;
        }
        #endregion
        #region Private Constructor
        private Picture(int id, int userid, MySqlDbType img, int likecount, DateTime createdat, int accepted, string createdby)
        {
            Id = id;
            UserID = userid;
            Img = img;
            LikeCount = likecount;
            CreatedAt = createdat;
            Accepted = accepted;
            CreatedBy = createdby;
        }
        #endregion
        // --------------------- Save Image ---------------------
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
            paramUserId.Value = User.LoggedInUserID;

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
            if (User.Success)
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
                dbConn.Close();
                return images_list;
            }
            return null;

        }
        #endregion
        #region GetImageListValidate
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
            dbConn.Close();
            return images_list;
        }
        #endregion
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
            if (User.Success)
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
                if (bytes != null)
                {
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
                dbConn.Close();
                return null;
            }
            dbConn.Close();
            return null;
        }
        #endregion
        #region GetImageSourceValidate
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

            if (bytes != null)
            {
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
            dbConn.Close();
            return null;
        }
        #endregion
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
        // -------------------- ACCEPT IMAGE --------------------
        #region Update Validate Picture
        public static void UpdateValidatePicture()
        {
            if (User.IsLoggedIn())
            {
                dbConn.Open();
                string queryId = string.Format("select ID from users where username='{0}';", User.LoggedInUsername);
                MySqlCommand cmd = new MySqlCommand(queryId, dbConn);
                string user_id = cmd.ExecuteScalar().ToString();

                string query = string.Format("update images set accepted=1 where user_id={0};", user_id);
                MySqlCommand Update_cmd = new MySqlCommand(query, dbConn);
                Update_cmd.ExecuteNonQuery();
                dbConn.Close();
            }
        }
        #endregion
    }
}
