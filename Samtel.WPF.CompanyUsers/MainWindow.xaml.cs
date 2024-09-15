using Samtel.WPF.CompanyUsers.DAL;
using Samtel.WPF.CompanyUsers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace Samtel.WPF.CompanyUsers
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserRepository _userRepository;
        public MainWindow()
        {
            InitializeComponent();
            _userRepository = new UserRepository();
            LoadUsers();
        }

        private void LoadUsers()
        {
            List<User> users = _userRepository.GetUsers();
            dgUser.ItemsSource = users;
        }

        private void btnSaveUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!ValidateFields(sender, e))
                {
                    return;
                }
                _userRepository.CreateUser(txtFirsName.Text, txtLastName.Text, txtEmail.Text, txtPhone.Text);
                MessageBox.Show("Usuario guardado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el usuario: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnEditUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgUser.SelectedItem != null)
                {
                    User selectedUser = (User)dgUser.SelectedItem;
                    _userRepository.UpdateUser(selectedUser);
                    LoadUsers();
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un usuario para editar.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el usuario: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void dgUsers_SelectionChanged(object sender, SelectionChangedEventArgs e) 
        {
            if(dgUser.SelectedItem != null)
            {
                User selectedUser = (User)dgUser.SelectedItem;
                txtFirsName.Text = selectedUser.FirstName;
                txtLastName.Text = selectedUser.LastName;
                txtEmail.Text = selectedUser.Email;
                txtPhone.Text = selectedUser.Phone;
            }
        }

        private void btnOpenDepartmentWindow_Click(object sender, RoutedEventArgs e)
        {
            DepartmentWindow departmentWindow = new DepartmentWindow();
            departmentWindow.Show(); 
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidPhone(string phone)
        {
            return phone.All(char.IsDigit) && phone.Length >= 7 && phone.Length <= 15;
        }

        private bool ValidateFields(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirsName.Text))
            {
                MessageBox.Show("El nombre es obligatorio.", "Validación", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("El apellido es obligatorio.", "Validación", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("El correo electrónico es obligatorio.", "Validación", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("El teléfono es obligatorio.", "Validación", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("El correo electrónico no es válido.", "Validación", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if (!IsValidPhone(txtPhone.Text))
            {
                MessageBox.Show("El número de teléfono no es válido.", "Validación", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }
    }
}
