using SupermarketWPF.Models;
using SupermarketWPF.Helpers;
using System.Windows.Input;
using System.Linq;
using System.Windows;
using SupermarketWPF.View;

namespace SupermarketWPF.ViewModels
{
    public class LoginVM : BaseVM
    {
        private readonly SupermarketDBEntities _context;
        private string _username;
        private string _password;

        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged(nameof(Username)); }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(nameof(Password)); }
        }

        public ICommand LoginCommand { get; }
        public static Utilizatori UtilizatorConectat { get; private set; }
        public LoginVM()
        {
            _context = new SupermarketDBEntities();
            LoginCommand = new RelayCommand(Login);
        }

        private void Login(object obj)
        {
            var user = _context.Utilizatori.FirstOrDefault(u => u.NumeUtilizator == Username && u.Parola == Password && u.TipUtilizator == "Casier");
            if (user != null)
            {
                UtilizatorConectat = user;
                MessageBox.Show("Autentificare reușită!", "Succes", MessageBoxButton.OK, MessageBoxImage.Information);
                // Deschide fereastra pentru casier
                CasierView casierView = new CasierView();
                casierView.Show();
                // Închide fereastra de login
                Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive).Close();
            }
            else
            {
                MessageBox.Show("Credențiale invalide sau utilizatorul nu este casier.", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
