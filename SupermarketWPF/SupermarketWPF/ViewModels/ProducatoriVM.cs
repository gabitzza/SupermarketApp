using SupermarketWPF.Helpers;
using SupermarketWPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace SupermarketWPF.ViewModels
{
    public class ProducatoriVM : BaseVM
    {
        private readonly SupermarketDBEntities _context;
        private int _id;
        private string _numeProducator;
        private string _taraOrigine;
        private bool _isActive;

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

        public ObservableCollection<Producatori> ProducatoriList { get; set; }
        public ICommand AddProducatorCommand { get; }
        public ICommand UpdateProducatorCommand { get; }
        public ICommand DeleteProducatorCommand { get; }

        public ProducatoriVM()
        {
            _context = new SupermarketDBEntities();
            ProducatoriList = new ObservableCollection<Producatori>(_context.Producatori.Where(p => (bool)p.IsActive).ToList());
            AddProducatorCommand = new RelayCommand(AddProducator);
            UpdateProducatorCommand = new RelayCommand(UpdateProducator);
            DeleteProducatorCommand = new RelayCommand(DeleteProducator);
        }

        private void AddProducator(object obj)
        {
            try
            {
                // Validare câmpuri
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
                // Validare câmpuri
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
                // Validare câmpuri
                if (Id <= 0)
                {
                    MessageBox.Show("ID-ul producătorului este obligatoriu.", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var producator = _context.Producatori.FirstOrDefault(p => p.Id == Id && (bool)p.IsActive);
                if (producator == null)
                {
                    MessageBox.Show($"Producătorul cu ID-ul {Id} nu există.", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                producator.IsActive = false;
                _context.SaveChanges();
                ProducatoriList.Remove(producator);

                MessageBox.Show("Producător șters: " + producator.NumeProducator);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Producator Error");
            }
        }
    }
}
