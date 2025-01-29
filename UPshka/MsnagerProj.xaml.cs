using PractAPI.ViewModel.Helpers;
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

namespace UPshka
{
    /// <summary>
    /// Логика взаимодействия для MsnagerProj.xaml
    /// </summary>
    public partial class MsnagerProj : Page
    {
        public MsnagerProj()
        {
            InitializeComponent();
            LoadActiveProjects();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            ManagerWinCreate mwc = new ManagerWinCreate();
            mwc.Show();
        }

        private void LoginButton_Click1(object sender, RoutedEventArgs e)
        {
            ManagerWinUpdate dfjkdf = new ManagerWinUpdate();
            dfjkdf.Show();
        }

        private void LoginButton_Click2(object sender, RoutedEventArgs e)
        {

        }

        private void LoginButton_Click3(object sender, RoutedEventArgs e)
        {
            ManagerWinCreateStage qwe = new ManagerWinCreateStage();
            qwe.Show();
        }

        private void LoginButton_Click4(object sender, RoutedEventArgs e)
        {

        }

        private void LoginButton_Clic7(object sender, RoutedEventArgs e)
        {
            ManagerWinUpdateStage qwe = new ManagerWinUpdateStage();
            qwe.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoginButton_Clickcreate(object sender, RoutedEventArgs e)
        {
            ManagerWinCreateZad qwe = new ManagerWinCreateZad();
            qwe.Show();
        }

        private void LoginButton_Clickupd(object sender, RoutedEventArgs e)
        {
            ManagerWinUpdateZad qwe = new ManagerWinUpdateZad();
            qwe.Show();
        }

        public async void LoadActiveProjects()
        {
            ApiHelper apiHelper = new ApiHelper("https://localhost:7007/api");

            var activeProjects = await apiHelper.GetActiveProjectsAsync();

            if (activeProjects != null && activeProjects.Any())
            {
                DataGridProjects.ItemsSource = activeProjects;
            }
            else
            {
                MessageBox.Show("Нет активных проектов для отображения.");
            }
        }
    }
}
