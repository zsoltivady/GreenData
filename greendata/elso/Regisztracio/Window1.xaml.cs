using System;
using System.Drawing;
using System.Collections;
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
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace elso
{
    //REGISZTRÁCIÓS FÜL
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window, INotifyDataErrorInfo, INotifyPropertyChanged, IDataErrorInfo
    {
        

        public Window1()
        {
            DataContext = this;
            InitializeComponent();
            Database.DBConnection.InitializeDB();
        }
       

        #region Interfaces
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged = delegate { };
        public event PropertyChangedEventHandler PropertyChanged;
        public bool HasErrors => false;

        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        public IEnumerable GetErrors(string propertyName)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region ValidationProperties
        private string username;
        public string UserName { get { return username; }  set{ username = value; INotifyPropertyChanged("UserName"); } }

        private string email;
        public string Email { get { return email; } set { email = value; INotifyPropertyChanged("Email"); } }

        
        public string Password { get { return passwd.Password.ToString(); } }

        private void INotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        string IDataErrorInfo.Error
        {
            get => null;
        }

        string IDataErrorInfo.this[string propertyName]
        {
            get
            {
                return GetValidationError(propertyName);
            }
        }

        #endregion

        public void OnErrorsChanged(string propertyName)
        {
            if (ErrorsChanged != null)
                ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }

        #region Validation
        static readonly string[] ValidatedProperties =
        {
            "UserName","Email","Password"
        };
        

        public bool IsValid
        {
            get
            {
                foreach (string property in ValidatedProperties)
                {
                    if (GetValidationError(property) != null)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        string GetValidationError(string propertyName)
        {
            string error = null;

            switch (propertyName)
            {
                case "UserName":
                    error = ValidateUserName();
                    break;
                case "Email":
                    error = ValidateEmail();
                    break;
                case "Password":
                    error = ValidatePassword();
                    break;

            }

            return error;
        }

        private string ValidateUserName()
        {
            if (String.IsNullOrWhiteSpace(UserName))
            {
                return "A felhasználónév megadása kötelező! Legalább 3 karakter hosszúnak kell lennie!";
            }
            return null;
        }

        private bool ValidateUsernameBool()
        {
            if (String.IsNullOrWhiteSpace(UserName))
            {
                return false;
            }
            else if(UserName.Length < 3)
            {
                return false;
            }
            return true;
        }

        private string ValidateEmail()
        {
            if (String.IsNullOrWhiteSpace(Email))
            {
                return "Az email cím megadása kötelező!";
            }
            else if(!Email.Contains('@') || !Email.Contains('.'))
            {
                return "Az email címnek tartalmaznia kell @ -t és pontot!";
            }
           
            return null;
        }

        public bool ValidateEmailBool()
        {
            if (String.IsNullOrWhiteSpace(Email))
            {
                return false;
            }
            else if (!Email.Contains('@') || !Email.Contains('.'))
            {
                return false;
            }
            return true;

        }

        private string ValidatePassword()
        {
            if (String.IsNullOrWhiteSpace(Password))
            {
                return "A jelszó megadása kötelező!";
            }
            return null;
        }

        private bool ValidatePasswordBool()
        {
            if (String.IsNullOrWhiteSpace(passwd.Password))
            {
                return false;
            }
            else if(passwd.Password.Length < 3)
            {
                return false;
            }
            return true;
        }
        #endregion


        #region Information_Textbox
        private void Information_TextBox_Username(object sender, TextChangedEventArgs e)
        {
            string felhasznalo = "Ide írhatod a felhasználónevedet, a késöbbiekben ezzel a névvel, fogsz tudni bejelentkezni.";
            felhasznalo = felhasznalo.Replace(",", "," + System.Environment.NewLine);
            information_label.Content = felhasznalo;
        }

        private void Information_TextBox_Email(object sender, TextChangedEventArgs e)
        {
            string email = "Az email címed add meg itt.";
            email = email.Replace(",", "," + System.Environment.NewLine);
            information_label.Content = email;
        }
        #endregion

        #region Buttons
        private void Back_Button(object sender, RoutedEventArgs e)
        {
            Login.MainWindow sw = new Login.MainWindow();
            sw.Show();
            this.Close();
        }

      string PasswordMD5Crypt(string input)
        {
            MD5 md5 = MD5.Create();

            byte[] inputBytes = Encoding.ASCII.GetBytes(input);

            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)

            {

                builder.Append(hash[i].ToString("x2"));

            }
            return builder.ToString();
        }


        private void Registration_Button(object sender, RoutedEventArgs e)
        {

            if (ValidateEmailBool() && ValidateUsernameBool() && ValidatePasswordBool())
            {
                try
                {
                    User.Insert(username, PasswordMD5Crypt(Password), email);
                    MessageBox.Show("Sikeres Regisztráció!");
                }
                catch (Exception error)
                {

                    MessageBox.Show(error.Message);
                }
            }
            else
            {
                MessageBox.Show("Nem megfelelő adatok.");
            }   
        }
        #endregion
    }
}
