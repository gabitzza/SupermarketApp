using SupermarketWPF.Helpers;
using SupermarketWPF.Models;
using SupermarketWPF.View;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace SupermarketWPF.ViewModels
{
    public class ProducatoriVM : BaseVM
    {
        private readonly SupermarketDBEntities _context;
        private int _id;
        private string _numeProducator;
        private string _taraOrigine;
        private bool _isActive;
        private Producatori _selectedProducator;

        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(nameof(Id)); }
        }

        public string NumeProducator
        {
            get { return _numeProducator; }
            set { _numeProducator = value; OnPropertyChanged(nameof(NumeProducator)); }
        }

        public string TaraOrigine
        {
            get { return _taraOrigine; }
            set { _taraOrigine = value; OnPropertyChanged(nameof(TaraOrigine)); }
        }

        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; OnPropertyChanged(nameof(IsActive)); }
        }

        public Producatori SelectedProducator
        {
            get { return _selectedProducator; }
            set { _selectedProducator = value; OnPropertyChanged(nameof(SelectedProducator)); }
        }

        public ObservableCollection<Producatori> ProducatoriList { get; set; }
        public ObservableCollection<Produse> ProduseList { get; set; } // Adăugați această linie

        public ICommand AddProducatorCommand { get; }
        public ICommand UpdateProducatorCommand { get; }
        public ICommand DeleteProducatorCommand { get; }
        public ICommand ViewProduseByProducatorCommand { get; }

        public ProducatoriVM()
        {
            _context = new SupermarketDBEntities();
            ProducatoriList = new ObservableCollection<Producatori>(_context.Producatori.Where(p => (bool)p.IsActive).ToList());
            ProduseList = new ObservableCollection<Produse>(); // Inițializați lista de produse
            AddProducatorCommand = new RelayCommand(AddProducator);
            UpdateProducatorCommand = new RelayCommand(UpdateProducator);
            DeleteProducatorCommand = new RelayCommand(DeleteProducator);
            ViewProduseByProducatorCommand = new RelayCommand(ViewProduseByProducator);
        }

        private void AddProducator(object obj)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(NumeProducator) || string.IsNullOrWhiteSpace(TaraOrigine))
                {
                    MessageBox.Show("Toate câmpurile sunt obligatorii.", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (_context.Producatori.Any(p => p.Id == Id))
                {
                    MessageBox.Show("Există deja un producător cu acest ID.", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                var producator = new Producatori
                {
                    Id = Id,
                    NumeProducator = NumeProducator,
                    TaraOrigine = TaraOrigine,
                    IsActive = true
                };

                _context.Producatori.Add(producator);
                _context.SaveChanges();
                ProducatoriList.Add(producator);

                MessageBox.Show("Producător adăugat: " + producator.NumeProducator);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Producator Error");
            }
        }

        private void UpdateProducator(object obj)
        {
            try
            {
                if (Id <= 0 || string.IsNullOrWhiteSpace(NumeProducator) || string.IsNullOrWhiteSpace(TaraOrigine))
                {
                    MessageBox.Show("Toate câmpurile sunt obligatorii.", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var producator = _context.Producatori.FirstOrDefault(p => !(p.Id != Id || !(bool)p.IsActive));
                if (producator == null)
                {
                    MessageBox.Show($"Producătorul cu ID-ul {Id} nu există.", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                producator.NumeProducator = NumeProducator;
                producator.TaraOrigine = TaraOrigine;
                _context.SaveChanges();

                MessageBox.Show("Producător actualizat: " + producator.NumeProducator);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Producator Error");
            }
        }

        private void DeleteProducator(object obj)
        {
            try
            {
                if (SelectedProducator == null)
                {
                    MessageBox.Show("Selectați un producător pentru a-l șterge.", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var producatorDeSters = SelectedProducator;
                producatorDeSters.IsActive = false;
                _context.SaveChanges();

                ProducatoriList.Remove(producatorDeSters);
                SelectedProducator = null;
                OnPropertyChanged(nameof(SelectedProducator));

                MessageBox.Show("Producător șters: " + producatorDeSters.NumeProducator);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Producator Error");
            }
        }

        private void ViewProduseByProducator(object obj)
        {
            try
            {
                if (SelectedProducator == null)
                {
                    MessageBox.Show("Selectați un producător.", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var produse = _context.Produse.Where(p => p.ProducatorId == SelectedProducator.Id && p.IsActive == true)
                                              .OrderBy(p => p.Categoria)
                                              .ToList();

                if (produse.Count == 0)
                {
                    MessageBox.Show("Acest producător nu are produse în magazin.", "Informație", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                ProduseList.Clear();
                foreach (var produs in produse)
                {
                    ProduseList.Add(produs);
                }

                // Deschide fereastra pentru afișarea produselor
                ProduseByProducatorView view = new ProduseByProducatorView();
                view.DataContext = this;
                view.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "View Produse By Producator Error");
            }
        }
    }
}
