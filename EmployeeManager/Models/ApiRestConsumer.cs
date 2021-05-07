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
        static private HttpClient _client;
        public ApiRestConsumer()
        {
            _client = new HttpClient();
            // Update port # in the following line.
            _client.BaseAddress = new Uri("https://gorest.co.in/public-api/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
        }

        public async Task<List<Employee>> GetEmployeesAsync(string path)
        {
            List<Employee> employees = null;
            HttpResponseMessage response = await _client.GetAsync("users");
            if (response.IsSuccessStatusCode)
            {
                JObject jsonData = JsonConvert.DeserializeObject<JObject>(await response.Content.ReadAsStringAsync());
                employees = jsonData["data"].ToObject<List<Employee>>();
            }
            return employees;
        }

        public string GetEmployees(int page)
        {
            return null;
        }

        public string GetEmployee(int id)
        {
            return null;
        }

        public string SetEmployee(int id)
        {
            return null;
        }

        public string DeleteEmployee(int id)
        {
            return null;
        }
    }
}
