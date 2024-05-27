using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using SupermarketWPF.Models;
using SupermarketWPF.Helpers;

namespace SupermarketWPF.ViewModels
{
    public class ProduseVM : BaseVM
    {
        private readonly SupermarketDBEntities _context;
        private int _id;
        private string _numeProdus;
        private string _codDeBare;
        private string _categoria;
        private int _producatorId;
        private Produse _selectedProdus;
        public int Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(nameof(Id)); }
        }

        public string NumeProdus
        {
            get { return _numeProdus; }
            set { _numeProdus = value; OnPropertyChanged(nameof(NumeProdus)); }
        }

        public string CodDeBare
        {
            get { return _codDeBare; }
            set { _codDeBare = value; OnPropertyChanged(nameof(CodDeBare)); }
        }

        public string Categoria
        {
            get { return _categoria; }
            set { _categoria = value; OnPropertyChanged(nameof(Categoria)); }
        }

        public int ProducatorId
        {
            get { return _producatorId; }
            set { _producatorId = value; OnPropertyChanged(nameof(ProducatorId)); }
        }
        public Produse SelectedProdus
        {
            get { return _selectedProdus; }
            set { _selectedProdus = value; OnPropertyChanged(nameof(SelectedProdus)); }
        }
        public ObservableCollection<Produse> ProduseList { get; set; }
        public ObservableCollection<Producatori> ProducatoriList { get; set; }
        public ObservableCollection<Categorii> CategoriiList { get; set; }
        public ICommand AddProdusCommand { get; }
        public ICommand UpdateProdusCommand { get; }
        public ICommand DeleteProdusCommand { get; }

        public ProduseVM()
        {
            _context = new SupermarketDBEntities();
            ProduseList = new ObservableCollection<Produse>(_context.Produse.Where(p => p.IsActive == true).ToList());
            ProducatoriList = new ObservableCollection<Producatori>(_context.Producatori.Where(p => p.IsActive == true).ToList());
            CategoriiList = new ObservableCollection<Categorii>(_context.Categorii.ToList());
            AddProdusCommand = new RelayCommand(AddProdus);
            UpdateProdusCommand = new RelayCommand(UpdateProdus);
            DeleteProdusCommand = new RelayCommand(DeleteProdus);
        }

        private void AddProdus(object obj)
        {
            try
            {
                // Validare câmpuri
                if (string.IsNullOrWhiteSpace(NumeProdus) || string.IsNullOrWhiteSpace(CodDeBare) || string.IsNullOrWhiteSpace(Categoria) || ProducatorId == 0)
                {
                    MessageBox.Show("Toate câmpurile sunt obligatorii.", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Verificare existență produs cu același nume sau cod de bare
                if (_context.Produse.Any(p => p.NumeProdus == NumeProdus))
                {
                    MessageBox.Show("Există deja un produs cu acest nume.", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (_context.Produse.Any(p => p.CodDeBare == CodDeBare))
                {
                    MessageBox.Show("Există deja un produs cu acest cod de bare.", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var produs = new Produse
                {
                    NumeProdus = NumeProdus,
                    CodDeBare = CodDeBare,
                    Categoria = Categoria,
                    ProducatorId = ProducatorId,
                    IsActive = true
                };

                _context.Produse.Add(produs);
                _context.SaveChanges();
                ProduseList.Add(produs);

                // Resetarea câmpurilor după adăugare
                NumeProdus = string.Empty;
                CodDeBare = string.Empty;
                Categoria = string.Empty;
                ProducatorId = 0;

                OnPropertyChanged(nameof(NumeProdus));
                OnPropertyChanged(nameof(CodDeBare));
                OnPropertyChanged(nameof(Categoria));
                OnPropertyChanged(nameof(ProducatorId));

                MessageBox.Show("Produs adăugat: " + produs.NumeProdus);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Produs Error");
            }
        }

        private void UpdateProdus(object obj)
        {
            try
            {
                // Validare câmpuri
                if (Id == 0 || string.IsNullOrWhiteSpace(NumeProdus) || string.IsNullOrWhiteSpace(CodDeBare) || string.IsNullOrWhiteSpace(Categoria) || ProducatorId == 0)
                {
                    MessageBox.Show("Toate câmpurile sunt obligatorii.", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var produs = _context.Produse.FirstOrDefault(p => p.Id == Id && p.IsActive == true);
                if (produs == null)
                {
                    MessageBox.Show($"Produsul cu ID-ul {Id} nu există.", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                produs.NumeProdus = NumeProdus;
                produs.CodDeBare = CodDeBare;
                produs.Categoria = Categoria;
                produs.ProducatorId = ProducatorId;
                _context.SaveChanges();

                MessageBox.Show("Produs actualizat: " + produs.NumeProdus);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update Produs Error");
            }
        }

        private void DeleteProdus(object obj)
        {
            try
            {
                if (SelectedProdus == null)
                {
                    MessageBox.Show("Selectați un produs pentru a-l șterge.", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var produsDeSters = SelectedProdus;

                produsDeSters.IsActive = false;
                _context.SaveChanges();
 
                ProduseList.Remove(produsDeSters);
                SelectedProdus = null;
                OnPropertyChanged(nameof(SelectedProdus));

                MessageBox.Show("Produs șters: " + produsDeSters.NumeProdus);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete Produs Error");
            }
        }
    }
}

