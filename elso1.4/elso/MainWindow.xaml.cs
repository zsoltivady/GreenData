﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace elso
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
        }
        public static int bejelentkezve = 0;
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
            string connectionstring = "SERVER=localhost;DATABASE=dtbuser;UID=root;PASSWORD=root;";
            MySqlConnection connection = new MySqlConnection(connectionstring);
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("", connection);
            connection.Close();
        }
    }
}
