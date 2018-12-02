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
        public bool IsSaved;
        public bool ok;
        public Color colors;
        public byte piros, zold, kek = 0;
        public Paint()
        {
            InitializeComponent();
            rajz.UseCustomCursor = true;
            Database.DBConnection.InitializeDB();
            
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
            if (piros != 255 && zold != 255 && kek != 255)
            {
                rajz.DefaultDrawingAttributes.Color = ok ? colors : Color.FromRgb(piros, zold, kek);
            }
            
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
            MenuItem menu;
            menu = sender as MenuItem;
            if (menu.Header.ToString() == "Kép mentése")
            {
                Save("jpg fájl (.jpg)|*.jpg |png fájl (.png) |*.png", @"\Save\Pictures");
            }
            else if (menu.Header.ToString() == "Projekt mentése")
            {
                Save("GreenData fájl (.gdf) |*.gdf", @"\Save\Projekts");
            }
            
        }

        private void Save(string filter, string path)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = filter; // Filter files by extension
            dlg.InitialDirectory = Environment.CurrentDirectory + path;
            bool? result = dlg.ShowDialog();
            if (result == true)
            {
                // Save document
                string filename = dlg.FileName;
                //get the dimensions of the ink control
                int width = (int)rajz.ActualWidth;
                int height = (int)rajz.ActualHeight;

                //render ink to bitmap



                RenderTargetBitmap rtb = new RenderTargetBitmap(width, height, 96d, 96d, PixelFormats.Default);
                rtb.Render(rajz);
                if (dlg.FileName.EndsWith(".gdf"))
                {
                    if (filename.StartsWith(Environment.CurrentDirectory + @"\Save\Projekts"))
                    {
                        using (FileStream fs = new FileStream(filename, FileMode.Create))
                        {
                            rajz.Strokes.Save(fs);
                            fs.Close();
                            if (User.IsLoggedIn()) // DATABASE SAVE
                            {
                                MemoryStream ms = new MemoryStream();
                                rajz.Strokes.Save(ms);
                                byte[] bytes = ms.ToArray();
                                rajz.Strokes.Clear();
                                ms.Dispose();
                                User.SaveImage(bytes);
                            }
                            IsSaved = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nem mentheted ide a fájlt!");
                    }
                }
                else
                {
                    if (filename.StartsWith(Environment.CurrentDirectory + @"\Save\Pictures"))
                    {
                        using (FileStream fs = new FileStream(filename, FileMode.Create))
                        {
                            if (User.IsLoggedIn()) // DATABASE SAVE
                            {
                                MemoryStream ms = new MemoryStream();
                                rajz.Strokes.Save(ms);
                                byte[] bytes = ms.ToArray();
                                rajz.Strokes.Clear();
                                ms.Dispose();

                                User.SaveImage(bytes);
                            }
                            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                            encoder.Frames.Add(BitmapFrame.Create(rtb));
                            encoder.Save(fs);
                            IsSaved = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nem mentheted ide a fájlt!");
                    }
                }
            }
        }

        private void open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Environment.CurrentDirectory + @"\Save\Pictures";
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

        private void kilep_Click(object sender, RoutedEventArgs e)
        {
            win3 win3 = new win3();
            win3.Show();
            Close();
        }

        private void paint_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (rajz.Strokes.Count > 0 && IsSaved == false)
            {
                win3 win3 = new win3();
                MessageBoxButton btnMessageBox = MessageBoxButton.YesNoCancel;
                MessageBoxImage icnMessageBox = MessageBoxImage.Warning;
                MessageBoxResult rsltMessageBox = MessageBox.Show("Szeretné menteni kilépés elött?", "GreenData (PAINT)", btnMessageBox, icnMessageBox);
                switch (rsltMessageBox)
                {
                    case MessageBoxResult.Yes:
                        Save("jpg fájl (.jpg)|*.jpg |png fájl (.png) |*.png |GreenData fájl (.gdf) |*.gdf", @"\Save");
                        win3.Show();
                        break;
                    case MessageBoxResult.No:
                        win3.Show();
                        break;
                    case MessageBoxResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }

        private void undo_Click(object sender, RoutedEventArgs e)
        {
            if (rajz.Strokes.Count != 0)
            {
                rajz.Strokes.RemoveAt(rajz.Strokes.Count - 1);
                IsSaved = false;
            }
        }
        Ellipse ell = new Ellipse();
        private void rajz_MouseMove(object sender, MouseEventArgs e)
        {
            rajz.Children.Remove(ell);
            ell.Width = brush.Value;
            ell.Height = brush.Value;
            ell.Stroke = new SolidColorBrush(Color.FromRgb(piros, zold, kek));
            ell.StrokeThickness = 1;
            Point sensorPoint = Mouse.GetPosition(rajz);
            ell.SetValue(InkCanvas.LeftProperty, sensorPoint.X - brush.Value / 2);
            ell.SetValue(InkCanvas.TopProperty, sensorPoint.Y - brush.Value / 2);
            rajz.Children.Add(ell);
            if (e.RightButton == MouseButtonState.Pressed)
            {
                rajz.EditingMode = InkCanvasEditingMode.EraseByPoint;
            }
            else if (e.LeftButton == MouseButtonState.Pressed)
            {
                IsSaved = false;
            }
            else
            {
                rajz.EditingMode = InkCanvasEditingMode.Ink;
            }
        }

        private void erase_Click(object sender, RoutedEventArgs e)
        {
            rajz.EditingMode = InkCanvasEditingMode.EraseByPoint;
        }

        private void rajz_MouseLeave(object sender, MouseEventArgs e)
        {
            rajz.Children.Remove(ell);
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
