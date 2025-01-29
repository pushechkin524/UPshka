using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Text.Json;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PractAPI.ViewModel.Helpers;
using System.Data;
using Newtonsoft.Json;
using UPshka.Model;

namespace UPshka
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly HttpClient client = new HttpClient();

        public MainWindow()
        {

            InitializeComponent();

        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = EmailTextBox.Text;
            string password = PasswordBox.Password;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пожалуйста, введите логин и пароль.");
                return;
            }

            ApiHelper apiHelper = new ApiHelper("https://localhost:7007/api");


            try
            {
                var response = await apiHelper.AuthenticateAsync(login, password);

                if (response.Success)
                {
                    var employe = JsonConvert.DeserializeObject<Employe>(response.Data);

                    if (employe.Id == 1)
                    {
                        Window1 clientsWindow = new Window1();
                        clientsWindow.Show();
                        this.Close();
                    }
                    else if (employe.Id == 2)
                    {
                        WindowDesigner windes = new WindowDesigner();
                        windes.Show();
                        this.Close();
                    }
                    else if (employe.Id == 3)
                    {
                        WindowManager windes = new WindowManager();
                        windes.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("У вас нет доступа к этой странице.");
                    }
                }
                else
                {
                    MessageBox.Show("Неверные учетные данные.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }

        }
    }
}

