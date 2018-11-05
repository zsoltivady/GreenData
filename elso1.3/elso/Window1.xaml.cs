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

namespace elso
{
    //REGISZTRÁCIÓS FÜL
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            
        }
        


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow sw = new MainWindow();
            sw.Show();
            this.Close();
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!this.tbox1.Text.Contains('@') || !this.tbox1.Text.Contains('.'))
            {
                tbox1.Text = "Hibás e-mail.";
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string felhasznalo = "Ide írhatod a felhasználónevedet, a késöbbiekben ezzel a névvel, fogsz tudni bejelentkezni.";
            felhasznalo = felhasznalo.Replace(",", "," + System.Environment.NewLine);
            label1.Content = felhasznalo;
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            string jelszo = "A jelszavad, a késöbbiekben ezzel a jelszóval, fogsz tudni bejelentkezni.";
            jelszo = jelszo.Replace(",", "," + System.Environment.NewLine);
            label1.Content = jelszo;
        }

        private void tbox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            string email = "Az email címed add meg itt.";
            email = email.Replace(",", "," + System.Environment.NewLine);
            label1.Content = email;
        }
    }
}
