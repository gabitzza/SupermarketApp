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
            OpenAdministratorViewCommand = new RelayCommand(param => OpenAdministratorView());
            OpenCasierViewCommand = new RelayCommand(param => OpenCasierView());
        }

        private void OpenAdministratorView()
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

        private void OpenCasierView()
        {
            try
            {
                var casierView = new CasierView();
                casierView.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to open CasierView: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
