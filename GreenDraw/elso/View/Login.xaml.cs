using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using GreenDraw.Model;
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


namespace GreenDraw.View
{
    //BEJELENTKEZÉS 
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        
        public Login()
        {
            InitializeComponent();
           
        }
        public static bool bejelentkezve = false;
        private void Registration_Button(object sender, RoutedEventArgs e)
        {
            Registration regWindow = new Registration();
            regWindow.Show();
            this.Close();

        }

        private void Guest_Button(object sender, RoutedEventArgs e)
        {

            Choose valasztasWindow = new Choose();
            valasztasWindow.Show();
            this.Close();
            
        }

        private void Login_Button(object sender, RoutedEventArgs e)
        {
            Choose sw = new Choose();
            sw.Show();
            this.Close();
        }
    }
}
