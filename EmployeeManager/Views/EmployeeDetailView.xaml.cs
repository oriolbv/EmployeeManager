﻿using EmployeeManager.Models;
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
        public EmployeeDetailView(Employee employee, bool isEditable)
        {
            InitializeComponent();
            _vm = new EmployeeDetailViewModel(this, employee);
            this.DataContext = _vm;
        }
    }
}