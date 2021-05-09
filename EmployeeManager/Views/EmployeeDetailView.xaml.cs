using EmployeeManager.Models;
using EmployeeManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EmployeeManager.Views
{
    /// <summary>
    /// Lógica de interacción para EmployeeDetailView.xaml
    /// </summary>
    public partial class EmployeeDetailView : Window
    {
        private EmployeeDetailViewModel _vm;
        public EmployeeDetailView(Employee employee, bool isEditable, bool isAddingNewEmployee)
        {
            InitializeComponent();
            _vm = new EmployeeDetailViewModel(this, employee, isEditable, isAddingNewEmployee);
            this.DataContext = _vm;
            // Fill comboboxes data after loading the view.
            cbGender.ItemsSource = _vm.Genders;
            cbGender.SelectedIndex = 1;
            cbStatus.ItemsSource = _vm.Statuses;
            cbStatus.SelectedIndex = 1;

        }

        private void OnSave(object sender, RoutedEventArgs e)
        {
            Employee new_employee = new Employee(tbName.Text, tbEmail.Text, cbGender.Text, cbStatus.Text);
            _vm.SaveEmployee(new_employee);
        }

        private void OnCancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
