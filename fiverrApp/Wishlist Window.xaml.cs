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

namespace fiverrApp
{
    /// <summary>
    /// Interaction logic for Wishlist_Window.xaml
    /// </summary>
    public partial class Wishlist_Window : Window
    {
        public Wishlist_Window(string username)
        {
            InitializeComponent();
            Application.Current.MainWindow.Close();
        }
    }
}
