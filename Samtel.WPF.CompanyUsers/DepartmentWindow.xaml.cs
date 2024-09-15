using Samtel.WPF.CompanyUsers.DAL;
using Samtel.WPF.CompanyUsers.Models;
using System;
using System.Collections.Generic;
using System.Windows;


namespace Samtel.WPF.CompanyUsers
{
    public partial class DepartmentWindow : Window
    {
        private UserRepository _userRepository;
        private DepartmentRepository _departmentRepository;
        public DepartmentWindow()
        {
            InitializeComponent();
            _userRepository = new UserRepository();
            _departmentRepository = new DepartmentRepository();
            LoadUsersAndDepartments();
        }

        private void LoadUsersAndDepartments()
        {
            List<User> users = _userRepository.GetUsers();
            cbUsers.ItemsSource = users;
            cbUsers.DisplayMemberPath = "FirstName";
            List<Department> departments = _departmentRepository.GetDepartments();
            cbDepartments.ItemsSource = departments;
            cbDepartments.DisplayMemberPath = "DepartmentName";
        }

        private void btnAssignDepartment_Click(object sender, RoutedEventArgs e) 
        {
            try
            {
                if (cbUsers.SelectedItem != null && cbDepartments.SelectedItem != null)
                {
                    User selectedUser = (User)cbUsers.SelectedItem;
                    Department selectedDepartment = (Department)cbDepartments.SelectedItem;

                    _departmentRepository.AssignUserToDepartment(selectedUser.UserId, selectedDepartment.DepartmentId);
                    MessageBox.Show("Usuario asignado al área correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un usuario y un área antes de asignar.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al asignar usuario al área: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
