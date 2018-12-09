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
    /// <summary>
    /// Interaction logic for ValidPicture.xaml
    /// </summary>
    public partial class ValidPicture : Window
    {
        public ValidPicture()
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

            List<Image> ImageIndex = new List<Image>();
            switch (Picture.GetImageListValidate().Count)
            {
                case 6:
                    ImageIndex.Add(Image1);
                    ImageIndex.Add(Image2);
                    ImageIndex.Add(Image3);
                    ImageIndex.Add(Image4);
                    ImageIndex.Add(Image5);
                    ImageIndex.Add(Image6);
                    CBox1.Visibility = Visibility.Visible;
                    CBox2.Visibility = Visibility.Visible;
                    CBox3.Visibility = Visibility.Visible;
                    CBox4.Visibility = Visibility.Visible;
                    CBox5.Visibility = Visibility.Visible;
                    CBox6.Visibility = Visibility.Visible;
                    break;
                case 5:
                    ImageIndex.Add(Image1);
                    ImageIndex.Add(Image2);
                    ImageIndex.Add(Image3);
                    ImageIndex.Add(Image4);
                    ImageIndex.Add(Image5);
                    CBox1.Visibility = Visibility.Visible;
                    CBox2.Visibility = Visibility.Visible;
                    CBox3.Visibility = Visibility.Visible;
                    CBox4.Visibility = Visibility.Visible;
                    CBox5.Visibility = Visibility.Visible;
                    CBox6.Visibility = Visibility.Hidden;
                    break;
                case 4:
                    ImageIndex.Add(Image1);
                    ImageIndex.Add(Image2);
                    ImageIndex.Add(Image3);
                    ImageIndex.Add(Image4);
                    CBox1.Visibility = Visibility.Visible;
                    CBox2.Visibility = Visibility.Visible;
                    CBox3.Visibility = Visibility.Visible;
                    CBox4.Visibility = Visibility.Visible;
                    CBox5.Visibility = Visibility.Hidden;
                    CBox6.Visibility = Visibility.Hidden;
                    break;
                case 3:
                    ImageIndex.Add(Image1);
                    ImageIndex.Add(Image2);
                    ImageIndex.Add(Image3);
                    CBox1.Visibility = Visibility.Visible;
                    CBox2.Visibility = Visibility.Visible;
                    CBox3.Visibility = Visibility.Visible;
                    CBox4.Visibility = Visibility.Hidden;
                    CBox5.Visibility = Visibility.Hidden;
                    CBox6.Visibility = Visibility.Hidden;
                    break;
                case 2:
                    ImageIndex.Add(Image1);
                    ImageIndex.Add(Image2);
                    CBox1.Visibility = Visibility.Visible;
                    CBox2.Visibility = Visibility.Visible;
                    CBox3.Visibility = Visibility.Hidden;
                    CBox4.Visibility = Visibility.Hidden;
                    CBox5.Visibility = Visibility.Hidden;
                    CBox6.Visibility = Visibility.Hidden;
                    break;
                case 1:
                    ImageIndex.Add(Image1);
                    CBox1.Visibility = Visibility.Visible;
                    CBox2.Visibility = Visibility.Hidden;
                    CBox3.Visibility = Visibility.Hidden;
                    CBox4.Visibility = Visibility.Hidden;
                    CBox5.Visibility = Visibility.Hidden;
                    CBox6.Visibility = Visibility.Hidden;
                    break;
                case 0:
                    CBox1.Visibility = Visibility.Hidden;
                    CBox2.Visibility = Visibility.Hidden;
                    CBox3.Visibility = Visibility.Hidden;
                    CBox4.Visibility = Visibility.Hidden;
                    CBox5.Visibility = Visibility.Hidden;
                    CBox6.Visibility = Visibility.Hidden;
                    break;
                default:
                    ImageIndex.Add(Image1);
                    ImageIndex.Add(Image2);
                    ImageIndex.Add(Image3);
                    ImageIndex.Add(Image4);
                    ImageIndex.Add(Image5);
                    ImageIndex.Add(Image6);
                    CBox1.Visibility = Visibility.Visible;
                    CBox2.Visibility = Visibility.Visible;
                    CBox3.Visibility = Visibility.Visible;
                    CBox4.Visibility = Visibility.Visible;
                    CBox5.Visibility = Visibility.Visible;
                    CBox6.Visibility = Visibility.Visible;
                    break;
            }
            for (int i = ImageIndex.Count - 1; i >= 0 ; i--)
            {
                ImageIndex[i].Source = Picture.GetImageSourceValidate();
            }

        }

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
            /*
            for (int i = 0; i < length; i++)
            {
                for (int i = 0; i < length; i++)
                {

                }
            }
            */

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {

            }
        }
        private void ckilep(object sender, RoutedEventArgs e)
        {
            Close();
        }
        kepkeres sw = new kepkeres();
        private void ckepkeres(object sender, RoutedEventArgs e)
        {

            if (sw.IsClosed)
            {
                sw = new kepkeres();
                sw.Show();
            }
            if (!sw.IsLoaded)
            {
                sw.Show();
            }
            else
            {
                sw.Focus();
            }
        }
        private void cbejelentkez(object sender, RoutedEventArgs e)
        {
            Login.MainWindow sw = new Login.MainWindow();
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

            Login.MainWindow sw = new Login.MainWindow();

            Close();

            sw.Show();

        }
        private void FelhasznaloKereses(object sender, RoutedEventArgs e)
        {
  
           FelhasznaloKereses userSearch = new FelhasznaloKereses();
           Close();
           userSearch.Show();
  
        }


        private void ElfogadasraVaroKepek(object sender, RoutedEventArgs e)
        {
            if (User.IsLoggedIn())
            {
                ValidPicture validatepic = new ValidPicture();
                validatepic.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Nincs hozzá jogosultságod!");
            }
        }


        private void Elfogad(object sender, RoutedEventArgs e)
        {
            try
            {
                Picture.UpdateValidatePicture();
                MessageBox.Show("Sikeresen elfogadtad a képeket.");
            }
            catch (Exception error)
            {
                
                MessageBox.Show(error.ToString());
            }
           
        }

        private void Torol(object sender, RoutedEventArgs e)
        {
            if (CBox1.IsChecked == true)
            {
                Picture.RefuseValidatePicture(Picture.GetImageId(0));
            }
            if (CBox2.IsChecked == true)
            {
                Picture.RefuseValidatePicture(Picture.GetImageId(1));
            }
            if (CBox3.IsChecked == true)
            {
                Picture.RefuseValidatePicture(Picture.GetImageId(2));
            }
            if (CBox4.IsChecked == true)
            {
                Picture.RefuseValidatePicture(Picture.GetImageId(3));
            }
            if (CBox5.IsChecked == true)
            {
                Picture.RefuseValidatePicture(Picture.GetImageId(4));
            }
            if (CBox6.IsChecked == true)
            {
                Picture.RefuseValidatePicture(Picture.GetImageId(5));
            }
        }

        private void kozos(object sender, RoutedEventArgs e)
        {
            win4 win4 = new win4();
            win4.Show();
            Close();
        }
    }
}
