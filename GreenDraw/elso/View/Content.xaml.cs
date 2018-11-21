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

namespace GreenDraw.View
{
    //NAGY KÖZÖS
    /// <summary>
    /// Interaction logic for win4.xaml
    /// </summary>
    public partial class Content : Window
    {
        public Content()
        {
            InitializeComponent();
            if (Login.bejelentkezve == true)
            {
                bejelentkez.IsEnabled = false;
                regisztal.IsEnabled = false;
                fiokbeall.IsEnabled = true;
                kijelent.IsEnabled = true;
                    
            }
            else
            {
                bejelentkez.IsEnabled = true;
                regisztal.IsEnabled = true;
                fiokbeall.IsEnabled = false;
                kijelent.IsEnabled = false;
                elfogadasravarokepek.IsEnabled = false;
                megnyit.IsEnabled = false;
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Content sw = new Content();
            sw.Show();
            this.Close();
            
        }
        private void cmegnyit(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg";
            Nullable<bool> result = dlg.ShowDialog();
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
            PictureSearch sw = new PictureSearch();
            sw.Show();
        }
        private void cbejelentkez(object sender, RoutedEventArgs e)
        {
            Login sw = new Login();
            sw.Show();
            this.Close();
        }
        private void cregisztal(object sender, RoutedEventArgs e)
        {
            Registration sw = new Registration();
            sw.Show();
            this.Close();
        }
        private void cfiokbeall(object sender, RoutedEventArgs e)
        {

        }
        private void ckijelent(object sender, RoutedEventArgs e)
        {

        }
        private void celfogadasravarokepek(object sender, RoutedEventArgs e)
        {

        }
        private void cfelhasznaloker(object sender, RoutedEventArgs e)
        {

        }
    }
}
