using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager.Models
{
    public class Employee
    {
        public Employee()
        {

        }

        public Employee(string name, string email, string gender, string status)
        {
            Name = name;
            Email = email;
            Gender = gender;
            Status = status;
        }

        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("gender")]
        public string Gender { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
