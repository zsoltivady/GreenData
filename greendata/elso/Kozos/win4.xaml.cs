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

            List<Image> ImageIndex = new List<Image>();
            switch (Picture.GetImageList().Count)
            {
                case 6:
                    ImageIndex.Add(Image1);
                    ImageIndex.Add(Image2);
                    ImageIndex.Add(Image3);
                    ImageIndex.Add(Image4);
                    ImageIndex.Add(Image5);
                    ImageIndex.Add(Image6);
                    break;
                case 5:
                    ImageIndex.Add(Image1);
                    ImageIndex.Add(Image2);
                    ImageIndex.Add(Image3);
                    ImageIndex.Add(Image4);
                    ImageIndex.Add(Image5);
                    break;
                case 4:
                    ImageIndex.Add(Image1);
                    ImageIndex.Add(Image2);
                    ImageIndex.Add(Image3);
                    ImageIndex.Add(Image4);
                    break;
                case 3:
                    ImageIndex.Add(Image1);
                    ImageIndex.Add(Image2);
                    ImageIndex.Add(Image3);
                    break;
                case 2:
                    ImageIndex.Add(Image1);
                    ImageIndex.Add(Image2);
                    break;
                case 1:
                    ImageIndex.Add(Image1);
                    break;
                default:
                    ImageIndex.Add(Image1);
                    ImageIndex.Add(Image2);
                    ImageIndex.Add(Image3);
                    ImageIndex.Add(Image4);
                    ImageIndex.Add(Image5);
                    ImageIndex.Add(Image6);
                    break;
            }
            Image1.MouseLeftButtonUp += Image1_MouseLeftButtonUp;
            Image2.MouseLeftButtonUp += Image2_MouseLeftButtonUp;
            Image3.MouseLeftButtonUp += Image3_MouseLeftButtonUp;
            Image4.MouseLeftButtonUp += Image4_MouseLeftButtonUp;
            Image5.MouseLeftButtonUp += Image5_MouseLeftButtonUp;
            Image6.MouseLeftButtonUp += Image6_MouseLeftButtonUp;

            for (int i = 0; i < ImageIndex.Count; i++)
            {
                ImageIndex[i].Source = Picture.GetImageSource();
            }

        }

        private void Image1_MouseLeftButtonUp(object sender, MouseEventArgs e)
        {
            PictureViewer pv = new PictureViewer();
            pv.kep.Width = Image1.Width;
            pv.kep.Height = Image1.Height;
            pv.Show();
            pv.kep.Source = Image1.Source;
        }
        private void Image2_MouseLeftButtonUp(object sender, MouseEventArgs e)
        {
            PictureViewer pv = new PictureViewer();
            pv.kep.Width = Image2.Width;
            pv.kep.Height = Image2.Height;
            pv.Show();
            pv.kep.Source = Image2.Source;
        }
        private void Image3_MouseLeftButtonUp(object sender, MouseEventArgs e)
        {
            PictureViewer pv = new PictureViewer();
            pv.Show();
            pv.kep.Width = Image3.Width;
            pv.kep.Height = Image3.Height;
            pv.kep.Source = Image3.Source;
        }
        private void Image4_MouseLeftButtonUp(object sender, MouseEventArgs e)
        {
            PictureViewer pv = new PictureViewer();
            pv.Show();
            pv.kep.Width = Image4.Width;
            pv.kep.Height = Image4.Height;
            pv.kep.Source = Image4.Source;
        }
        private void Image5_MouseLeftButtonUp(object sender, MouseEventArgs e)
        {
            PictureViewer pv = new PictureViewer();
            pv.Show();
            pv.kep.Width = Image5.Width;
            pv.kep.Height = Image5.Height;
            pv.kep.Source = Image5.Source;
        }
        private void Image6_MouseLeftButtonUp(object sender, MouseEventArgs e)
        {
            PictureViewer pv = new PictureViewer();
            pv.Show();
            pv.kep.Width = Image6.Width;
            pv.kep.Height = Image6.Height;
            pv.kep.Source = Image6.Source;
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
            if (User.IsLoggedIn() && User.Permission == "Admin")
            {
                ValidPicture vpic = new ValidPicture();
                vpic.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Nincs hozzá jogosultságod!");
            }
        }

        private void cMentesBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
