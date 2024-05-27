using SupermarketWPF.Helpers;
using SupermarketWPF.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace SupermarketWPF.ViewModels
{
    public class UtilizatoriVM : BaseVM
    {
        private readonly SupermarketDBEntities _context;
        private int _id;
        private string _numeUtilizator;
        private string _parola;
        private string _tipUtilizator;
        private Utilizatori _selectedUtilizator;

        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(nameof(Id)); }
        }

        public string NumeUtilizator
        {
            get { return _numeUtilizator; }
            set { _numeUtilizator = value; OnPropertyChanged(nameof(NumeUtilizator)); }
        }

        public string Parola
        {
            get { return _parola; }
            set { _parola = value; OnPropertyChanged(nameof(Parola)); }
        }

        public string TipUtilizator
        {
            get { return _tipUtilizator; }
            set { _tipUtilizator = value; OnPropertyChanged(nameof(TipUtilizator)); }
        }

        public Utilizatori SelectedUtilizator
        {
            get { return _selectedUtilizator; }
            set { _selectedUtilizator = value; OnPropertyChanged(nameof(SelectedUtilizator)); }
        }

        public ObservableCollection<Utilizatori> UtilizatoriList { get; set; }
        public ObservableCollection<string> TipuriUtilizatori { get; set; }
        public ICommand AddUtilizatorCommand { get; }
        public ICommand UpdateUtilizatorCommand { get; }
        public ICommand DeleteUtilizatorCommand { get; }

        public UtilizatoriVM()
        {
            _context = new SupermarketDBEntities();
            UtilizatoriList = new ObservableCollection<Utilizatori>(_context.Utilizatori.Where(u => u.IsActive == true).ToList());
            TipuriUtilizatori = new ObservableCollection<string> { "Administrator", "Casier" };
            AddUtilizatorCommand = new RelayCommand(AddUtilizator);
            UpdateUtilizatorCommand = new RelayCommand(UpdateUtilizator);
            DeleteUtilizatorCommand = new RelayCommand(DeleteUtilizator);
        }

        private void AddUtilizator(object obj)
        {
            try
            {
                // Validare câmpuri
                if (string.IsNullOrWhiteSpace(NumeUtilizator) || string.IsNullOrWhiteSpace(Parola) || string.IsNullOrWhiteSpace(TipUtilizator))
                {
                    MessageBox.Show("Toate câmpurile sunt obligatorii.", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var utilizator = new Utilizatori
                {
                    NumeUtilizator = NumeUtilizator,
                    Parola = Parola,
                    TipUtilizator = TipUtilizator,
                    IsActive = true
                };

                _context.Utilizatori.Add(utilizator);
                _context.SaveChanges();
                UtilizatoriList.Add(utilizator);

                // Resetarea câmpurilor după adăugare
                NumeUtilizator = string.Empty;
                Parola = string.Empty;
                TipUtilizator = string.Empty;

                OnPropertyChanged(nameof(NumeUtilizator));
                OnPropertyChanged(nameof(Parola));
                OnPropertyChanged(nameof(TipUtilizator));

                MessageBox.Show("Utilizator adăugat: " + utilizator.NumeUtilizator);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Utilizator Error");
            }
        }

        private void UpdateUtilizator(object obj)
        {
            try
            {
                // Validare câmpuri
                if (Id == 0 || string.IsNullOrWhiteSpace(NumeUtilizator) || string.IsNullOrWhiteSpace(Parola) || string.IsNullOrWhiteSpace(TipUtilizator))
                {
                    MessageBox.Show("Toate câmpurile sunt obligatorii.", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var utilizator = _context.Utilizatori.FirstOrDefault(u => u.Id == Id && u.IsActive == true);
                if (utilizator == null)
                {
                    MessageBox.Show($"Utilizatorul cu ID-ul {Id} nu există.", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                utilizator.NumeUtilizator = NumeUtilizator;
                utilizator.Parola = Parola;
                utilizator.TipUtilizator = TipUtilizator;
                _context.SaveChanges();

                MessageBox.Show("Utilizator actualizat: " + utilizator.NumeUtilizator);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Utilizator Error");
            }
        }

        private void DeleteUtilizator(object obj)
        {
            try
            {
                if (SelectedUtilizator == null)
                {
                    MessageBox.Show("Selectați un utilizator pentru a-l șterge.", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var utilizatorDeSters = SelectedUtilizator;
                utilizatorDeSters.IsActive = false;
                _context.SaveChanges();
                UtilizatoriList.Remove(utilizatorDeSters);
                SelectedUtilizator = null;
                OnPropertyChanged(nameof(SelectedUtilizator));

                MessageBox.Show("Utilizator șters: " + utilizatorDeSters.NumeUtilizator);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Utilizator Error");
            }
        }
    }
}
