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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ColorPickerWPF;

namespace elso
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
            Rect bounds = VisualTreeHelper.GetDescendantBounds(rajz);
            double dpi = 96d;

            RenderTargetBitmap rtb = new RenderTargetBitmap((int)bounds.Width, (int)bounds.Height, dpi, dpi, System.Windows.Media.PixelFormats.Default);
            DrawingVisual dv = new DrawingVisual();
            using (DrawingContext dc = dv.RenderOpen())
            {
                VisualBrush vb = new VisualBrush(rajz);
                dc.DrawRectangle(vb, null, new Rect(new Point(), bounds.Size));
            }
            rtb.Render(dv);

            BitmapEncoder pngEncoder = new PngBitmapEncoder();
            pngEncoder.Frames.Add(BitmapFrame.Create(rtb));
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                pngEncoder.Save(ms);
                System.IO.File.WriteAllBytes(@"C:\Users\user\Documents\GitHub\GreenData\elso1.5\elso\Pictures\teszt.jpg", ms.ToArray());
            }
        }
    }
}
