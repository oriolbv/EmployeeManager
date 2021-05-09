using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeManager.ViewModels;
using System;
using EmployeeManager.Views;
using EmployeeManager.Models;

namespace EmployeeManagerTests
{
    [TestClass]
    public class EmployeesViewModelTests
    {

        [TestMethod]
        public void GetEmployees()
        {
            EmployeesViewModel employeesViewModel = new EmployeesViewModel(null);

            employeesViewModel.SearchEmployees("", 1);

            // Wait until the async API call is finished.
            System.Threading.Thread.Sleep(2000);

            // Check if the system has recieved some employees information.
            Assert.IsTrue(employeesViewModel.Employees.Count > 0);
        }

        [TestMethod]
        public void DeleteEmployee()
        {
            EmployeesViewModel employeesViewModel = new EmployeesViewModel(null);

            employeesViewModel.SearchEmployees("", 1);
            System.Threading.Thread.Sleep(2000);

            Random random = new Random();
            int random_idx = random.Next(0, employeesViewModel.Employees.Count - 1);

            Employee deletedEmployee = employeesViewModel.Employees[random_idx];

            employeesViewModel.DeleteEmployee(deletedEmployee);
            System.Threading.Thread.Sleep(3000);

            Employee newEmployee = employeesViewModel.Employees[random_idx];

            Assert.AreNotEqual(deletedEmployee.Id, newEmployee.Id);

        }

        [TestMethod]
        public void LoadNextPage()
        {
            EmployeesViewModel employeesViewModel = new EmployeesViewModel(null);

            employeesViewModel.SearchEmployees("", 1);
            System.Threading.Thread.Sleep(2000);

            Random random = new Random();
            int random_idx = random.Next(0, employeesViewModel.Employees.Count - 1);

            Employee oldEmployee = employeesViewModel.Employees[random_idx];

            employeesViewModel.LoadNextPage();
            System.Threading.Thread.Sleep(2000);

            Employee newEmployee = employeesViewModel.Employees[random_idx];

            Assert.AreNotEqual(oldEmployee.Id, newEmployee.Id);

        }

        [TestMethod]
        public void LoadPreviousPage()
        {
            EmployeesViewModel employeesViewModel = new EmployeesViewModel(null);

            employeesViewModel.SearchEmployees("", 1);
            System.Threading.Thread.Sleep(2000);

            Random random = new Random();
            int random_idx = random.Next(0, employeesViewModel.Employees.Count - 1);

            Employee oldEmployee = employeesViewModel.Employees[random_idx];

            employeesViewModel.LoadNextPage();
            System.Threading.Thread.Sleep(2000);

            employeesViewModel.LoadPreviousPage();
            System.Threading.Thread.Sleep(2000);

            Employee newEmployee = employeesViewModel.Employees[random_idx];

            Assert.AreEqual(oldEmployee.Id, newEmployee.Id);

        }
    }
}
