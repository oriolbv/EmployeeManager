using EmployeeManager.Models;
using EmployeeManager.Views;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace EmployeeManager.ViewModels
{
    class EmployeesViewModel
    {
        private static ApiRestConsumer _api = new ApiRestConsumer();
        private static EmployeesView _view;
        private static List<Employee> _employees;


        public EmployeesViewModel(EmployeesView view)
        {
            _view = view;
        }

        #region Public methods
        public void ShowEmployeeDetails(Employee employee, bool isEditable, bool isAddingNewEmployee)
        {
            var window = new EmployeeDetailView(employee, isEditable, isAddingNewEmployee);
            window.ShowDialog();
        }

        public async void DeleteEmployee(Employee employee)
        {
            await DeleteEmployeeTask(employee.Id);
        }

        public async void SearchEmployees(string searchText, int page)
        {
            await GetEmployeesTask(searchText, 1);
        }

        public void ExportData()
        {
            // Open dialog to choose the path where the file will be saved.
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Save a CSV File";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                // Export data to CSV
                var csv = new StringBuilder();

                var header = string.Format("Id,Name,Email,Gender,Status");
                csv.AppendLine(header);


                foreach (Employee employee in _employees)
                {
                    var line = string.Format("{0},{1},{2},{3},{4}", employee.Id, employee.Name, employee.Email, employee.Gender, employee.Status);
                    csv.AppendLine(line);
                }

                File.WriteAllText(saveFileDialog1.FileName, csv.ToString());
            }
        }
        #endregion


        #region Tasks
        static async Task GetEmployeesTask(string searchText, int page)
        {
            _employees = await _api.GetEmployeesAsync(searchText, page);
            PopulateList(_employees);
        }

        static async Task DeleteEmployeeTask(int id)
        {
            var statusCode = await _api.DeleteEmployee(id);
            Console.WriteLine($"Employee {id} deleted correctly!");
            // Refresh page in order to give feedback of the deleted employee.
            await GetEmployeesTask("", 1);
        }
        #endregion

        #region Private methods
        private static void PopulateList(List<Employee> employees)
        {
            _view.lbEmployees.ItemsSource = employees;
        }

        #endregion

    }
}
