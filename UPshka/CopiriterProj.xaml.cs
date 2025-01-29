using Newtonsoft.Json;
using PractAPI.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
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
using UPshka.Model;

namespace UPshka
{
    /// <summary>
    /// Логика взаимодействия для CopiriterProj.xaml
    /// </summary>
    public partial class CopiriterProj : Page
    {

        public CopiriterProj()
        {
            InitializeComponent();
            LoadActiveProjects();
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


