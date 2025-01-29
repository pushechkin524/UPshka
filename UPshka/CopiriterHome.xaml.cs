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
using System.Windows.Navigation;
using System.Windows.Shapes;
using UPshka.Model;

namespace UPshka
{
    /// <summary>
    /// Логика взаимодействия для ImpStr.xaml
    /// </summary>
    public partial class CopiriterHome : Page
    {
        private readonly ApiHelper _apiHelper;
        public ObservableCollection<Project> Projects { get; set; }
        public CopiriterHome()
        {
            InitializeComponent(); 
            _apiHelper = new ApiHelper("https://localhost:7007/api");
            Projects = new ObservableCollection<Project>();
            DataGridProjects.ItemsSource = Projects; // Привязка источника данных
            LoadProjects();
            LoadDicactiveProjects();
        }

        private async void LoadProjects()
        {
            try
            {
                var projects = await _apiHelper.GetProjectsAsync();
                Projects.Clear();

                foreach (var project in projects)
                {
                    Projects.Add(project);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
            }
        }

        public async void LoadDicactiveProjects()
        {
            ApiHelper apiHelper = new ApiHelper("https://localhost:7007/api");

            var activeProjects = await apiHelper.GetDicactiveProjectsAsync();

            if (activeProjects != null && activeProjects.Any())
            {
                DataGridEnded.ItemsSource = activeProjects;
            }
            else
            {
                MessageBox.Show("Нет активных проектов для отображения.");
            }
        }
    }
}
