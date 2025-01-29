using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using UPshka.Model;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UPshka.Model;

namespace PractAPI.ViewModel.Helpers
{

    public class ApiResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Data { get; set; }

        public ApiResponse()
        {
            Success = true;
            Message = string.Empty;
            Data = string.Empty;
        }

        public ApiResponse(bool success, string message, string data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }

    public class ApiHelper
    {
        private readonly HttpClient _client;
        private readonly string _baseUrl;

        public ApiHelper(string baseUrl)
        {
            _baseUrl = baseUrl;
            _client = new HttpClient(); 
        }

        public async Task<ApiResponse> AuthenticateAsync(string em, string pass)
        {
            if (string.IsNullOrEmpty(em) || string.IsNullOrEmpty(pass))
            {
                return new ApiResponse(false, "Email и пароль не могут быть пустыми.", null);
            }

            var loginData = new { email = em, password = pass };
            var json = JsonConvert.SerializeObject(loginData);
            var response = await PostAsync("Auth/authenticate", json);

            return response.Success
                ? new ApiResponse(true, "Аутентификация успешна", response.Data)
                : new ApiResponse(false, "Ошибка аутентификации: " + response.Message, null);
        }

        private async Task<ApiResponse> PostAsync(string endpoint, string jsonContent)
        {

            try
            {
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await _client.PostAsync($"{_baseUrl}/{endpoint}", content);
                var data = await response.Content.ReadAsStringAsync();

                return new ApiResponse
                {
                    Success = response.IsSuccessStatusCode,
                    Message = response.IsSuccessStatusCode ? null : data,
                    Data = data
                };

            }
            catch (Exception ex)
            {
                return new ApiResponse { Success = false, Message = $"Ошибка: {ex.Message}" };
            }
        }

        public async Task<List<Project>> GetProjectsAsync()
        {
            try
            {
                var response = await _client.GetAsync($"{_baseUrl}/Projects");

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Ошибка: {response.ReasonPhrase}");
                }

                var jsonData = await response.Content.ReadAsStringAsync();
                var projects = JsonConvert.DeserializeObject<List<Project>>(jsonData);

                return projects ?? new List<Project>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка получения данных: {ex.Message}");
            }
        }

        public async Task<List<Project>> GetActiveProjectsAsync()
        {
            try
            {
                var response = await _client.GetAsync($"{_baseUrl}/Projects/GetActiveProjects");

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Ошибка: {response.ReasonPhrase}");
                }

                var jsonData = await response.Content.ReadAsStringAsync();
                var projects = JsonConvert.DeserializeObject<List<Project>>(jsonData);

                return projects ?? new List<Project>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка получения данных: {ex.Message}");
            }
        }

        public async Task<List<Project>> GetDicactiveProjectsAsync()
        {
            try
            {
                var response = await _client.GetAsync($"{_baseUrl}/Projects/GetDicactiveProjects");

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Ошибка: {response.ReasonPhrase}");
                }

                var jsonData = await response.Content.ReadAsStringAsync();
                var projects = JsonConvert.DeserializeObject<List<Project>>(jsonData);

                return projects ?? new List<Project>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка получения данных: {ex.Message}");
            }
        }

        public async Task<List<TaskModel>> GetTasksByProjectAsync(int projectId)
        {
            try
            {
                // Выполняем GET-запрос с передачей projectId
                var response = await _client.GetAsync($"{_baseUrl}/Tasks/GetTasksByProject/{projectId}");

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Ошибка: {response.ReasonPhrase}");
                }

                // Читаем JSON-ответ
                var jsonData = await response.Content.ReadAsStringAsync();

                // Десериализуем JSON в список TaskModel
                var tasks = JsonConvert.DeserializeObject<List<TaskModel>>(jsonData);

                return tasks ?? new List<TaskModel>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при получении задач для проекта: {ex.Message}");
            }
        }



    }


}