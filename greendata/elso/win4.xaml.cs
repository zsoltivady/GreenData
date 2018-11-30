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
using Microsoft.Win32;
using System.IO;

namespace elso
{
    //NAGY KÖZÖS
    /// <summary>
    /// Interaction logic for win4.xaml
    /// </summary>
    public partial class win4 : Window
    {
        public win4()
        {
            InitializeComponent();
            if (User.IsLoggedIn()) // BEJELENTKEZETT FELHASZNÁLÓNÁL
            {
                bejelentkez.IsEnabled = false;
                regisztal.IsEnabled = false;
                fiokbeall.IsEnabled = true;
                kijelent.IsEnabled = true;

                    
            }
            else // VENDÉG FELHASZNÁLÓNÁL 
            {
                bejelentkez.IsEnabled = true;
                regisztal.IsEnabled = true;
                fiokbeall.IsEnabled = false;
                kijelent.IsEnabled = false;
                elfogadasravarokepek.IsEnabled = false;
                megnyit.IsEnabled = false;
            }
            
        }

        /*  win3 sw = new win3();
            sw.Show();
            this.Close();
        */
        private void cvissza(object sender, RoutedEventArgs e)
        {
            win3 sw = new win3();
            sw.Show();
            Close();
        }
        private void cmegnyit(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg";
            bool? result = dlg.ShowDialog();
        }
        private void cmentes(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {

            }
        }
        private void ckilep(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void ckepkeres(object sender, RoutedEventArgs e)
        {
            kepkeres sw = new kepkeres();
            sw.Show();
        }
        private void cbejelentkez(object sender, RoutedEventArgs e)
        {
            MainWindow sw = new MainWindow();
            sw.Show();
            Close();
        }
        private void cregisztal(object sender, RoutedEventArgs e)
        {
            Window1 sw = new Window1();
            sw.Show();
            Close();
        }
        private void cfiokbeall(object sender, RoutedEventArgs e)
        {

        }
        private void ckijelent(object sender, RoutedEventArgs e)
        {
            User.UserLogout();

            MessageBox.Show("Sikeres Kijelentkezés!");

            MainWindow sw = new MainWindow();

            Close();

            sw.Show();

        }
        private void celfogadasravarokepek(object sender, RoutedEventArgs e)
        {

        }
        private void cfelhasznaloker(object sender, RoutedEventArgs e)
        {

        }
    }
}
