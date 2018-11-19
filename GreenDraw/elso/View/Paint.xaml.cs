using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ColorPickerWPF;
using Microsoft.Win32;

namespace GreenDraw.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Paint : Window
    {
        public bool ok;
        public Color colors;
        public byte piros = 0;
        public byte zold = 0;
        public byte kek = 0;
        public Paint()
        {
            InitializeComponent();
            rajz.UseCustomCursor = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }


        private void red_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            piros = (byte)red.Value;
            colorbox.Fill = new SolidColorBrush(Color.FromRgb(piros, zold, kek));
            ok = false;
        }

        private void green_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            zold = (byte)green.Value;
            colorbox.Fill = new SolidColorBrush(Color.FromRgb(piros, zold, kek));
            ok = false;
        }

        private void blue_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            kek = (byte)blue.Value;
            colorbox.Fill = new SolidColorBrush(Color.FromRgb(piros, zold, kek));
            ok = false;
        }

        private void rajz_MouseEnter(object sender, MouseEventArgs e)
        {
            if (ok)
            {
                rajz.DefaultDrawingAttributes.Color = colors;
            }
            else
            {
                rajz.DefaultDrawingAttributes.Color = Color.FromRgb(piros, zold, kek);
            }
        }
        private void select_Click(object sender, RoutedEventArgs e)
        {
            rajz.EditingMode = InkCanvasEditingMode.Select;
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            rajz.EditingMode = InkCanvasEditingMode.Ink;
        }

        private void colorbox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ok = ColorPickerWindow.ShowDialog(out colors);
            colorbox.Fill = new SolidColorBrush(colors);
            red.Value = colors.R;
            green.Value = colors.G;
            blue.Value = colors.B;
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = "*"; // Default file name
            dlg.DefaultExt = ".bmp"; // Default file extension
            dlg.Filter = "bmp fájl (.bmp)|*.bmp"; // Filter files by extension
            bool? result = dlg.ShowDialog();

            if (result == true)
            {
                // Save document
                string filename = dlg.FileName;
                //get the dimensions of the ink control
                int margin = (int)rajz.Margin.Left;
                int width = (int)rajz.ActualWidth - margin-1;
                int height = (int)rajz.ActualHeight - margin-1;
                //render ink to bitmap
                RenderTargetBitmap rtb = new RenderTargetBitmap(width, height, 96d, 96d, PixelFormats.Default);
                rtb.Render(rajz);
                using (FileStream fs = new FileStream(filename,FileMode.Create))
                {
                    BmpBitmapEncoder encoder = new BmpBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(rtb));
                    encoder.Save(fs);
                }
            }
        }
        private void open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                Image i = new Image();
                i.Source = new BitmapImage(new Uri(ofd.FileName));
                rajz.Children.Add(i);
            }
        }
    }
}
