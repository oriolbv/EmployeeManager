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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EmployeeManager.Views
{
    /// <summary>
    /// Interaction logic for EmployeesView.xaml
    /// </summary>
    public partial class EmployeesView : UserControl
    {
        private EmployeesViewModel _vm;

        public EmployeesView()
        {
            InitializeComponent();
            _vm = new EmployeesViewModel(this);
            this.DataContext = _vm;
        }

        private void OnSearchClick(object sender, RoutedEventArgs e)
        {
            _vm.SearchEmployees(tbSearch.Text, 1);
        }

        private void OnEditUser(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            _vm.ShowEmployeeDetails((Employee)btn.DataContext, true, false);
        }

        private void OnDeleteUser(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            _vm.DeleteEmployee((Employee)btn.DataContext);
        }

        private void OnExportData(object sender, RoutedEventArgs e)
        {
            _vm.ExportData();
        }

        private void OnAddUser(object sender, RoutedEventArgs e)
        {
            _vm.ShowEmployeeDetails(null, true, true);
        }

        private void OnEmployeeDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (lbEmployees.SelectedItem != null)
            {
                _vm.ShowEmployeeDetails((Employee) lbEmployees.SelectedItem, false, false);
            }
        }


    }

}
