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

namespace elso
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Paint : Window
    {
        public bool ok;
        public Color colors;
        public byte piros, zold, kek = 0;
        public Paint()
        {
            InitializeComponent();
            rajz.UseCustomCursor = true;
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
            rajz.DefaultDrawingAttributes.Color = ok ? colors : Color.FromRgb(piros, zold, kek);
        }

        private void select_Click(object sender, RoutedEventArgs e)
        {
            rajz.EditingMode = InkCanvasEditingMode.Select;
            rajz.Cursor = Cursors.Cross;
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            rajz.EditingMode = InkCanvasEditingMode.Ink;
            rajz.Cursor = Cursors.Pen;
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
            dlg.Filter = "jpg fájl (.jpg)|*.jpg |png fájl (.png) |*.png |GreenData fájl (.gdf) |*.gdf"; // Filter files by extension
            dlg.InitialDirectory = Environment.CurrentDirectory + @"\Pictures";
            bool? result = dlg.ShowDialog();
            if (result == true)
            {
                // Save document
                string filename = dlg.FileName;
                //get the dimensions of the ink control
                int width = (int)rajz.ActualWidth;
                int height = (int)rajz.ActualHeight - 20;
                //render ink to bitmap
                RenderTargetBitmap rtb = new RenderTargetBitmap(width, height, 96d, 96d, PixelFormats.Default);
                rtb.Render(rajz);
                if (dlg.FileName.EndsWith(".gdf"))
                {
                    using (FileStream fs = new FileStream(filename, FileMode.Create))
                    {
                        rajz.Strokes.Save(fs);
                        fs.Close();
                    }
                }
                else
                {
                    using (FileStream fs = new FileStream(filename, FileMode.Create))
                    {
                        JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                        //encoder.ColorContexts()
                        encoder.Frames.Add(BitmapFrame.Create(rtb));
                        encoder.Save(fs);
                    }
                }
            }
        }
        private void open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Environment.CurrentDirectory + @"\Pictures";
            if (ofd.ShowDialog() == true)
            {
                if (ofd.FileName.EndsWith(".gdf"))
                {
                    FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                    StrokeCollection strokes = new StrokeCollection(fs);
                    rajz.Strokes = strokes;
                }
                else
                {
                    MessageBox.Show("Nem nyitható meg a fájl");
                }
            }
        }

        private void brush_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            rajz.DefaultDrawingAttributes.Height = brush.Value;
            rajz.DefaultDrawingAttributes.Width = brush.Value;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            rajz.Strokes.Clear();
        }
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            rajz.Height = paint.Height - 139;
            rajz.Width = paint.Width - 16;
        }
    }
}
