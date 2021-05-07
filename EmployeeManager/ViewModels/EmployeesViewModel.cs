using EmployeeManager.Models;
using EmployeeManager.Views;
using System;
using System.Collections.Generic;
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

        public EmployeesViewModel(EmployeesView view)
        {
            _view = view;
        }


        public static void populateList(List<Employee> employees)
        {
            _view.lbEmployees.ItemsSource = employees;
        }

        public void ShowEmployeeDetails(Employee employee, bool isEditable)
        {
            var window = new EmployeeDetailView(employee, isEditable);
            window.ShowDialog();
        }

        #region Commands
        public async void OnSearch(string searchText, int page)
        {
            await GetEmployees(searchText, 1);

        }

        public void OnAddEmployee()
        {
            // Open Detail employee form
        }

        public void OnExport()
        {
            // Export data to CSV
        }

        #endregion


        #region Tasks
        static async Task GetEmployees(string searchText, int page)
        {
            List<Employee> e = await _api.GetEmployeesAsync("");
            Console.WriteLine(e);
            populateList(e);
        }

        #endregion
    }


}
