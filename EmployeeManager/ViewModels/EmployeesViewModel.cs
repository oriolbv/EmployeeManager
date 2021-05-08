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

        private static int _actualPage;
        private static string _searchText;


        public EmployeesViewModel(EmployeesView view)
        {
            _view = view;
            _actualPage = 1;
            _searchText = "";
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
            _searchText = searchText;
            await GetEmployeesTask(_searchText, page);
        }

        public void ExportData()
        {
            // Open dialog to choose the path where the file will be saved.
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save a CSV File";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
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

                File.WriteAllText(saveFileDialog.FileName, csv.ToString());
            }
        }

        internal void LoadPreviousPage()
        {
            if (_actualPage > 1)
            {
                ActualPage -= 1;
                SearchEmployees(_searchText, _actualPage);
            }
        }

        internal void LoadNextPage()
        {
            ActualPage += 1;
            SearchEmployees(_searchText, _actualPage);
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
            await GetEmployeesTask(_searchText, _actualPage);
        }
        #endregion

        #region Private methods
        private static void PopulateList(List<Employee> employees)
        {
            _view.lbEmployees.ItemsSource = employees;
        }

        #endregion

        #region Properties
        public int ActualPage
        {
            get
            {
                return _actualPage;
            }
            set
            {
                _actualPage = value;
            }
        }

        public string SearchText
        {
            get
            {
                return _searchText;
            }
            set
            {
                _searchText = value;
            }
        }
        #endregion

    }
}
