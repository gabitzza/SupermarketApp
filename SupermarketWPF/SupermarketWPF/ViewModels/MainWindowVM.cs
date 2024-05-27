using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupermarketWPF.Helpers;
using SupermarketWPF.View;
using System.Windows;
using System.Windows.Input;

namespace SupermarketWPF.ViewModels
{
    class MainWindowVM
    {
        public ICommand OpenAdministratorViewCommand { get; }
        public ICommand OpenCasierViewCommand { get; }

        public MainWindowVM()
        {
            OpenAdministratorViewCommand = new RelayCommand(OpenAdministratorView);
            OpenCasierViewCommand = new RelayCommand(param => OpenCasierLoginView());
        }

        private void OpenAdministratorView(object obj)
        {
            try
            {
                var administratorView = new AdministratorView();
                administratorView.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to open AdministratorView: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OpenCasierLoginView()
        {
            try
            {
                var loginView = new LoginView();
                loginView.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to open CasierView: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
