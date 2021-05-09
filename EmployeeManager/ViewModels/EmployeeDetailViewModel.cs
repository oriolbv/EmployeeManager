using EmployeeManager.Models;
using EmployeeManager.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EmployeeManager.ViewModels
{
    public class EmployeeDetailViewModel
    {
        private static ApiRestConsumer _api = new ApiRestConsumer();
        private EmployeeDetailView _view;
        private Employee _employee;
        private bool _isEditable;
        private bool _isAddingNewEmployee;
        private Visibility _saveVisibility;

        public List<string> Genders = new List<string>
        {
            "Male",
            "Female"
        };

        public List<string> Statuses = new List<string>
        {
            "Active",
            "Inactive"
        };


        public EmployeeDetailViewModel(EmployeeDetailView view, Employee employee, bool isEditable, bool isAddingNewEmployee)
        {
            _view = view;
            if (employee != null)
            {
                _employee = employee;
            }
            else
            {
                _employee = new Employee();
            }
            
            _isEditable = isEditable;
            if (!_isEditable)
            {
                _saveVisibility = Visibility.Collapsed;
            }
            _isAddingNewEmployee = isAddingNewEmployee;
        }

        public async void SaveEmployee(Employee new_employee)
        {
            if (_isAddingNewEmployee)
            {
                // Add a new employee.
                await AddNewEmployee(new_employee);
            }
            else
            {
                // Update an existing employee.
                _employee.Name = new_employee.Name;
                _employee.Email = new_employee.Email;
                _employee.Gender = new_employee.Gender;
                _employee.Status = new_employee.Status;

                await UpdateEmployee(_employee);
               
            }
            // Close window.
            _view.Close();

        }

        #region Tasks
        static async Task AddNewEmployee(Employee new_employee)
        {
            await _api.AddEmployeeAsync(new_employee);
        }

        static async Task UpdateEmployee(Employee employee)
        {
            await _api.UpdateEmployeeAsync(employee);
        }
        #endregion

        #region Properties
        public int Id
        {
            get
            {
                return _employee.Id;
            }
            set
            {
                _employee.Id = value;
            }
        }

        public string Name
        {
            get
            {
                return _employee.Name;

            }
            set
            {
                _employee.Name = value;
            }
        }

        public string Email
        {
            get
            {
                return _employee.Email;
            }
            set
            {
                _employee.Email = value;
            }
        }

        public string Gender
        {
            get
            {
                return _employee.Gender;
            }
            set
            {
                _employee.Gender = value;
            }
        }

        public string Status
        {
            get
            {
                return _employee.Status;
            }
            set
            {
                _employee.Status = value;
            }
        }

        public bool IsEditable
        {
            get
            {
                return _isEditable;
            }
        }

        public bool IsAddingNewEmployee
        {
            get
            {
                return _isAddingNewEmployee;
            }
        }

        public Visibility SaveVisibility
        {
            get
            {
                return _saveVisibility;
            }
            set
            {
                _saveVisibility = value;
            }
        }

        #endregion
    }
}
