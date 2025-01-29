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
    /// <summary>
    /// Логика взаимодействия для WindowManager.xaml
    /// </summary>
    public partial class WindowManager : Window
    {
        public WindowManager()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DGframe.Navigate(new Uri("CopiriterHome.xaml", UriKind.Relative));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DGframe.Navigate(new Uri("MsnagerProj.xaml", UriKind.Relative));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DGframe.Navigate(new Uri("ManagerClient.xaml", UriKind.Relative));
        }

        private void svLine(object sender, RoutedEventArgs e)
        {
            dssd.LineUp();
        }

        private void Button_Click_out(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mv = new MainWindow();
            mv.Show();
        }
    }
}
