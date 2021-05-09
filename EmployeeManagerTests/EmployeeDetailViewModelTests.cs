using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeManager.ViewModels;
using System;
using EmployeeManager.Views;
using EmployeeManager.Models;

namespace EmployeeManagerTests
{
    [TestClass]
    public class EmployeeDetailViewModelTests
    {

        [TestMethod]
        public void EditEmployee()
        {
            EmployeesViewModel employeesViewModel = new EmployeesViewModel(null);

            employeesViewModel.SearchEmployees("", 1);
            System.Threading.Thread.Sleep(2000);

            Random random = new Random();
            int random_idx = random.Next(0, employeesViewModel.Employees.Count - 1);

            Employee oldEmployee = employeesViewModel.Employees[random_idx];


            EmployeeDetailViewModel employeeDetailViewModel = new EmployeeDetailViewModel(null, oldEmployee, true, false);

            oldEmployee.Name = oldEmployee.Name + "z";

            employeeDetailViewModel.SaveEmployee(oldEmployee);
            System.Threading.Thread.Sleep(2000);

            employeesViewModel.SearchEmployees("", 1);
            System.Threading.Thread.Sleep(2000);

            Employee editedEmployee = employeesViewModel.Employees[random_idx];

            Assert.AreEqual(oldEmployee.Name, editedEmployee.Name);

        }

       
    }
}
