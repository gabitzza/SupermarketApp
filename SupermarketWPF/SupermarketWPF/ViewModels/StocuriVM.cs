using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using SupermarketWPF.Models;
using SupermarketWPF.Helpers;

namespace SupermarketWPF.ViewModels
{
    public class StocuriVM : BaseVM
    {
        private readonly SupermarketDBEntities _context;
        private int _produsId;
        private decimal _cantitate;
        private string _unitateDeMasura;
        private DateTime _dataAprovizionarii;
        private DateTime? _dataExpirarii;
        private decimal _pretAchizitie;
        private decimal _pretDeVanzare;

        public int ProdusId
        {
            get { return _produsId; }
            set { _produsId = value; OnPropertyChanged(nameof(ProdusId)); }
        }

        public decimal Cantitate
        {
            get { return _cantitate; }
            set { _cantitate = value; OnPropertyChanged(nameof(Cantitate)); }
        }

        public string UnitateDeMasura
        {
            get { return _unitateDeMasura; }
            set { _unitateDeMasura = value; OnPropertyChanged(nameof(UnitateDeMasura)); }
        }

        public DateTime DataAprovizionarii
        {
            get { return _dataAprovizionarii; }
            set { _dataAprovizionarii = value; OnPropertyChanged(nameof(DataAprovizionarii)); }
        }

        public DateTime? DataExpirarii
        {
            get { return _dataExpirarii; }
            set { _dataExpirarii = value; OnPropertyChanged(nameof(DataExpirarii)); }
        }

        public decimal PretAchizitie
        {
            get { return _pretAchizitie; }
            set
            {
                _pretAchizitie = value;
                OnPropertyChanged(nameof(PretAchizitie));
                CalculatePretDeVanzare();
            }
        }

        public decimal PretDeVanzare
        {
            get { return _pretDeVanzare; }
            set { _pretDeVanzare = value; OnPropertyChanged(nameof(PretDeVanzare)); }
        }

        public ObservableCollection<Stocuri> StocuriList { get; set; }

        public ICommand AddStocCommand { get; }

        public StocuriVM()
        {
            _context = new SupermarketDBEntities();
            StocuriList = new ObservableCollection<Stocuri>(_context.Stocuri.Where(s => (bool)s.IsActive).ToList());
            AddStocCommand = new RelayCommand(AddStoc);
        }

        private void AddStoc(object obj)
        {
            try
            {
                // Verificare dacă ProdusId există în tabelul Produse
                var produs = _context.Produse.FirstOrDefault(p => p.Id == ProdusId);
                if (produs == null)
                {
                    MessageBox.Show($"Produsul cu ID-ul {ProdusId} nu există.", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var stoc = new Stocuri
                {
                    ProdusId = ProdusId,
                    Cantitate = Cantitate,
                    UnitateDeMasura = UnitateDeMasura,
                    DataAprovizionarii = DataAprovizionarii,
                    DataExpirarii = DataExpirarii,
                    PretAchizitie = PretAchizitie,
                    PretDeVanzare = PretDeVanzare,
                    IsActive = true
                };

                _context.Stocuri.Add(stoc);
                _context.SaveChanges();
                StocuriList.Add(stoc);

                MessageBox.Show("Stoc adăugat: " + stoc.ProdusId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Stoc Error");
            }
        }

        private void CalculatePretDeVanzare()
        {
            var adaosComercial = GetAdaosComercial();
            PretDeVanzare = PretAchizitie + (PretAchizitie * adaosComercial / 100);
        }

        private decimal GetAdaosComercial()
        {
            var adaos = ConfigurationManager.AppSettings["AdaosComercial"];
            if (decimal.TryParse(adaos, out decimal adaosComercial))
            {
                return adaosComercial;
            }
            else
            {
                throw new Exception("Adaosul comercial nu este configurat corect.");
            }
        }
    }
}
