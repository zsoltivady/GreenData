using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace GreenDraw.View
{
    //REGISZTRÁCIÓS FÜL
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Registration : Window
    {
        

        public Registration()
        {
            InitializeComponent(); 
            
        }

        private void Back_Button(object sender, RoutedEventArgs e)
        {
            Login back = new Login();
            back.Show();
            this.Close();
        }

        private void TextBox_Username(object sender, TextChangedEventArgs e)
        {
            string felhasznalo = "Ide írhatod a felhasználónevedet, a késöbbiekben ezzel a névvel, fogsz tudni bejelentkezni.";
            felhasznalo = felhasznalo.Replace(",", "," + System.Environment.NewLine);
            
        }

        private void PasswordBox_Password(object sender, RoutedEventArgs e)
        {
            string jelszo = "A jelszavad, a késöbbiekben ezzel a jelszóval, fogsz tudni bejelentkezni.";
            jelszo = jelszo.Replace(",", "," + System.Environment.NewLine);
           
        }


        private void TextBox_Email(object sender, TextChangedEventArgs e)
        {
            string email = "Az email címed add meg itt.";
            email = email.Replace(",", "," + System.Environment.NewLine);
            
        }

        private void Registration_User_Button(object sender, RoutedEventArgs e)
        {
            if (!this.email.Text.Contains('@') || !this.email.Text.Contains('.'))
            {
                email.Text = "Nem megfelelő emailcím!";
            }

            String user_name = username.Text;

            String psw = password.Password;
            String psw2 = password2.Password;

            String email_test = email.Text;

            MessageBox.Show("Sikeres Regisztráció!");
        }
    }
}
