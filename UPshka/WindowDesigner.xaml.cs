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

namespace UPshka
{
    public partial class WindowDesigner : Window
    {
        public WindowDesigner()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            MainWindow secondWindow = new MainWindow();
            secondWindow.Show();

            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WERT.Navigate(new Uri("CopiriterHome.xaml", UriKind.Relative));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WERT.Navigate(new Uri("CopiriterProj.xaml", UriKind.Relative));
        }

        private void Button_Click_out(object sender, RoutedEventArgs e)
        {
            MainWindow df = new MainWindow();
            df.Show();
            this.Close();
        }
    }
}
