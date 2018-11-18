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


namespace GreenDraw.View
{
    //KÉPSZERKESZTŐ/NAGY KÖZÖS
    /// <summary>
    /// Interaction logic for win3.xaml
    /// </summary>
    public partial class Choose : Window
    {
        public Choose()
        {
            InitializeComponent();
            
        }
      
        private void Back_Button(object sender, RoutedEventArgs e)
        {
            Login back = new Login();
            back.Show();
            this.Close();
        }

        private void Paint_Button(object sender, RoutedEventArgs e)
        {
            Paint p = new Paint();
            p.Show();
            this.Close();
        }
    }
}
