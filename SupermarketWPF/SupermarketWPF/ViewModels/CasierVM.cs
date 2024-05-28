using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using SupermarketWPF.Helpers;
using SupermarketWPF.Models;

namespace SupermarketWPF.ViewModels
{
    public class CasierVM : BaseVM
    {
        private readonly SupermarketDBEntities _context;
        private int _utilizatorId;
        private string _searchTerm;
        private string _searchBy;
        private Produse _selectedProdus;
        private decimal _totalSum;

        public ObservableCollection<Produse> ProduseList { get; set; }
        public ObservableCollection<Produse> FilteredProduseList { get; set; }
        public ObservableCollection<BonItem> BonList { get; set; }

        public Produse SelectedProdus
        {
            get { return _selectedProdus; }
            set { _selectedProdus = value; OnPropertyChanged(nameof(SelectedProdus)); }
        }

        public string SearchTerm
        {
            get { return _searchTerm; }
            set { _searchTerm = value; OnPropertyChanged(nameof(SearchTerm)); PerformSearch(); }
        }

        public string SearchBy
        {
            get { return _searchBy; }
            set { _searchBy = value; OnPropertyChanged(nameof(SearchBy)); PerformSearch(); }
        }

        public ObservableCollection<string> SearchCriteria { get; }

        public decimal TotalSum
        {
            get { return _totalSum; }
            set { _totalSum = value; OnPropertyChanged(nameof(TotalSum)); }
        }

        public ICommand SearchCommand { get; }
        public ICommand AddToBonCommand { get; }
        public ICommand EmitBonCommand { get; }

        public CasierVM(int utilizatorId)
        {
            _context = new SupermarketDBEntities();
            _utilizatorId = utilizatorId;
            ProduseList = new ObservableCollection<Produse>(_context.Produse.Where(p => p.IsActive == true).ToList());
            FilteredProduseList = new ObservableCollection<Produse>(ProduseList);
            BonList = new ObservableCollection<BonItem>();
            SearchCriteria = new ObservableCollection<string> { "Nume", "Categorie", "Cod De Bare", "Producator" };
            SearchBy = SearchCriteria.First();
            SearchCommand = new RelayCommand(Search);
            AddToBonCommand = new RelayCommand(AddToBon);
            EmitBonCommand = new RelayCommand(EmitBon);
        }

        private void PerformSearch()
        {
            if (string.IsNullOrWhiteSpace(SearchTerm))
            {
                FilteredProduseList = new ObservableCollection<Produse>(ProduseList);
            }
            else
            {
                switch (SearchBy)
                {
                    case "Nume":
                        FilteredProduseList = new ObservableCollection<Produse>(ProduseList.Where(p => p.NumeProdus.IndexOf(SearchTerm, StringComparison.InvariantCultureIgnoreCase) >= 0));
                        break;
                    case "Cod De Bare":
                        FilteredProduseList = new ObservableCollection<Produse>(ProduseList.Where(p => p.CodDeBare.Contains(SearchTerm)));
                        break;
                    case "Categorie":
                        FilteredProduseList = new ObservableCollection<Produse>(ProduseList.Where(p => p.Categoria.IndexOf(SearchTerm, StringComparison.InvariantCultureIgnoreCase) >= 0));
                        break;
                    case "Producator":
                        FilteredProduseList = new ObservableCollection<Produse>(ProduseList.Where(p => p.Producatori.NumeProducator.IndexOf(SearchTerm, StringComparison.InvariantCultureIgnoreCase) >= 0));
                        break;
                    default:
                        FilteredProduseList = new ObservableCollection<Produse>(ProduseList);
                        break;
                }
            }
            OnPropertyChanged(nameof(FilteredProduseList));
        }

        private void Search(object obj)
        {
            PerformSearch();
        }

        private void AddToBon(object parameter)
        {
            var produs = parameter as Produse;
            if (produs == null)
            {
                MessageBox.Show("Produsul nu a fost selectat corect.");
                return;
            }

            var stoc = _context.Stocuri.FirstOrDefault(s => s.ProdusId == produs.Id && s.IsActive == true);
            if (stoc != null)
            {
                var bonItem = BonList.FirstOrDefault(b => b.Produs.Id == produs.Id);
                if (bonItem == null)
                {
                    BonList.Add(new BonItem
                    {
                        Produs = produs,
                        Cantitate = 1,
                        Pret = stoc.PretDeVanzare,
                        Subtotal = stoc.PretDeVanzare
                    });
                }
                else
                {
                    bonItem.Cantitate++;
                    bonItem.Subtotal = bonItem.Cantitate * bonItem.Pret;
                }

                UpdateTotalSum();
                OnPropertyChanged(nameof(BonList));
            }
            else
            {
                MessageBox.Show("Nu există stoc disponibil pentru acest produs.");
            }
        }

        private void UpdateTotalSum()
        {
            TotalSum = BonList.Sum(b => b.Subtotal);
        }

        private void EmitBon(object obj)
        {
            if (BonList.Count == 0)
            {
                MessageBox.Show("Bonul este gol. Adăugați produse înainte de a emite bonul.");
                return;
            }

            var bon = new BonuriDeCasa
            {
                DataEliberarii = DateTime.Now,
                CasierId = _utilizatorId,
                SumaIncasata = TotalSum,
                IsActive = true
            };

            _context.BonuriDeCasa.Add(bon);
            _context.SaveChanges();

            foreach (var item in BonList)
            {
                var bonItem = new BonuriDeCasa_Produse
                {
                    BonId = bon.Id,
                    ProdusId = item.Produs.Id,
                    Cantitate = item.Cantitate,
                    Subtotal = item.Subtotal,
                    IsActive = true
                };

                var stoc = _context.Stocuri.FirstOrDefault(s => s.ProdusId == item.Produs.Id && s.IsActive == true);
                if (stoc != null)
                {
                    stoc.Cantitate -= item.Cantitate;
                    if (stoc.Cantitate <= 0)
                    {
                        stoc.IsActive = false;
                    }
                }

                _context.BonuriDeCasa_Produse.Add(bonItem);
            }

            _context.SaveChanges();

            MessageBox.Show("Bon emis cu succes!", "Succes", MessageBoxButton.OK, MessageBoxImage.Information);
            BonList.Clear();
            UpdateTotalSum();
            OnPropertyChanged(nameof(BonList));
        }
    }

    public class BonItem
    {
        public Produse Produs { get; set; }
        public int Cantitate { get; set; }
        public decimal Pret { get; set; }
        public decimal Subtotal { get; set; }
    }
}
