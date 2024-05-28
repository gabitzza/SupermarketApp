using SupermarketWPF.Helpers;
using SupermarketWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SupermarketWPF.ViewModels
{
    public class CategorieValoriVM : BaseVM
    {
        private readonly SupermarketDBEntities _context;
        private Categorii _selectedCategorie;
        private decimal _valoareTotala;

        public Categorii SelectedCategorie
        {
            get { return _selectedCategorie; }
            set { _selectedCategorie = value; OnPropertyChanged(nameof(SelectedCategorie)); }
        }

        public decimal ValoareTotala
        {
            get { return _valoareTotala; }
            set { _valoareTotala = value; OnPropertyChanged(nameof(ValoareTotala)); }
        }

        public CategorieValoriVM(Categorii selectedCategorie)
        {
            _context = new SupermarketDBEntities();
            SelectedCategorie = selectedCategorie;
            CalculareValoareTotala();
        }

        private void CalculareValoareTotala()
        {
            try
            {
                var produseInCategorie = _context.Produse.Where(p => p.Categoria == SelectedCategorie.NumeCategorie && p.IsActive == true).ToList();
                decimal valoareTotala = 0;

                foreach (var produs in produseInCategorie)
                {
                    var stocuriProdus = _context.Stocuri.Where(s => s.ProdusId == produs.Id && s.IsActive == true).ToList();
                    foreach (var stoc in stocuriProdus)
                    {
                        valoareTotala += stoc.Cantitate * stoc.PretDeVanzare;
                    }
                }

                ValoareTotala = valoareTotala;
            }
            catch (Exception ex)
            {
                MessageBox.Show("A apărut o eroare la calcularea valorii totale: " + ex.Message, "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}