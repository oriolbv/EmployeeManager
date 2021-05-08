using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Models
{
    class ApiRestConsumer
    {
        const string API_TOKEN = "fa114107311259f5f33e70a5d85de34a2499b4401da069af0b1d835cd5ec0d56";

        static private HttpClient _client;
        
        public ApiRestConsumer()
        {
            _client = new HttpClient();
            // Update port # in the following line.
            _client.BaseAddress = new Uri("https://gorest.co.in/public-api/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", API_TOKEN);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
        }

        public async Task<List<Employee>> GetEmployeesAsync(string search, int page)
        {
            List<Employee> employees = null;
            string path = "users";
            if (search != "")
            {
                path = path + "?name=" + search;
            }

            HttpResponseMessage response = await _client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                JObject jsonData = JsonConvert.DeserializeObject<JObject>(await response.Content.ReadAsStringAsync());
                employees = jsonData["data"].ToObject<List<Employee>>();
            }
            return employees;
        }

        public async Task<Uri> AddEmployeeAsync(Employee employee)
        {
            var json = JsonConvert.SerializeObject(employee, Formatting.Indented);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync(
                "users", stringContent);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            return response.Headers.Location;
        }


        public async Task<Employee> GetEmployee(int id)
        {
            Employee employee = null;
            HttpResponseMessage response = await _client.GetAsync($"users/{id}");
            if (response.IsSuccessStatusCode)
            {
                JObject jsonData = JsonConvert.DeserializeObject<JObject>(await response.Content.ReadAsStringAsync());
                employee = jsonData["data"].ToObject<Employee>();
            }
            return employee;
        }

        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            var json = JsonConvert.SerializeObject(employee, Formatting.Indented);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PutAsync($"users/{employee.Id}", stringContent);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated employee from the response body.
            JObject jsonData = JsonConvert.DeserializeObject<JObject>(await response.Content.ReadAsStringAsync());
            employee = jsonData["data"].ToObject<Employee>();

            return employee;
        }

        public async Task<HttpStatusCode> DeleteEmployee(int id)
        {
            HttpResponseMessage response = await _client.DeleteAsync($"users/{id}");
            return response.StatusCode;
        }
    }
}
