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

namespace elso.Login
{
    //BEJELENTKEZÉS 
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Database.DBConnection.InitializeDB();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 sw = new Window1();
            sw.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            win3 sw = new win3();
            sw.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string un = textb1.Text;
            string pw = textb3.Password.ToString();

            if (string.IsNullOrEmpty(un) || string.IsNullOrEmpty(pw))
            {
                MessageBox.Show("Minden mező kitöltése kötelező!");
                textb1.Clear();
                textb3.Clear();
            }
            else
            {

                if (User.UserLogin(un, pw))
                {
                    win3 w3 = new win3();

                    w3.Show();

                    this.Close();
                }
                else if (!User.Success)
                {
                    MessageBox.Show("Nem lehet csatlakozni a szerverhez!");
                }
                else
                {
                    MessageBox.Show("Hibásan megadott adatok!");

                    textb1.Clear();
                    textb3.Clear();
                }

            }



        }
    }
}
