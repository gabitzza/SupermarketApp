using SupermarketWPF.Helpers;
using SupermarketWPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SupermarketWPF.ViewModels
{
    internal class ProduseVM : BaseVM
    {
        private readonly SupermarketDBEntities _context;
        private Produse _selectedProdus;

        public ObservableCollection<Produse> Produse { get; set; }
        public Produse SelectedProdus
        {
            get { return _selectedProdus; }
            set
            {
                _selectedProdus = value;
                OnPropertyChanged(nameof(SelectedProdus));
            }
        }

        public ICommand AddCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }

        public ProduseVM()
        {
            _context = new SupermarketDBEntities();
            Produse = new ObservableCollection<Produse>(_context.Produse.Where(p => (bool)p.IsActive).ToList());

            AddCommand = new RelayCommand(AddProdus);
            UpdateCommand = new RelayCommand(UpdateProdus);
            DeleteCommand = new RelayCommand(DeleteProdus);
        }

        private void AddProdus(string numeProdus, string codDeBare, string categoria, int? producatorId, bool isActive)
        {
            var produs = new Produse
            {
                NumeProdus = numeProdus,
                CodDeBare = codDeBare,
                Categoria = categoria,
                ProducatorId = producatorId,
                IsActive = isActive
            };
            _context.Produse.Add(produs);
            _context.SaveChanges();
            Produse.Add(produs);
        }

        private void UpdateProdus(object obj)
        {
            if (SelectedProdus != null)
            {
                _context.SaveChanges();
            }
        }

        private void DeleteProdus(object obj)
        {
            if (SelectedProdus != null)
            {
                SelectedProdus.IsActive = false;
                _context.SaveChanges();
                Produse.Remove(SelectedProdus);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected new virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
