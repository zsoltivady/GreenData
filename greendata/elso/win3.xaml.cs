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

namespace elso
{
    //KÉPSZERKESZTŐ/NAGY KÖZÖS
    /// <summary>
    /// Interaction logic for win3.xaml
    /// </summary>
    public partial class win3 : Window
    {
        public win3()
        {
            InitializeComponent();
            if (User.IsLoggedIn())
            {
                back_button.IsEnabled = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow sw = new MainWindow();
            sw.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            win4 sw = new win4();
            sw.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
           
            MainWindow sw = new MainWindow();
            sw.Show();
            this.Close();

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
