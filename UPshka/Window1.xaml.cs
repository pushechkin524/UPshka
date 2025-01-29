using PractAPI.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Media.TextFormatting;
using System.Windows.Shapes;
using UPshka.Model;

namespace UPshka
{
    public partial class Window1 : Window
    {

        
        public Window1()
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
            DGframe.Navigate(new Uri("CopiriterHome.xaml", UriKind.Relative));

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DGframe.Navigate(new Uri("CopiriterProj.xaml", UriKind.Relative));
        }

        private void DGframe_FragmentNavigation(object sender, System.Windows.Navigation.FragmentNavigationEventArgs e)
        {

        }

        private void Button_Click_out(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mv = new MainWindow();
            mv.Show();

        }
    }
}