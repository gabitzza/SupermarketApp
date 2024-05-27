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
    public class CasierVM : BaseVM
    {
        private readonly SupermarketDBEntities _context;

        public ObservableCollection<BonuriDeCasa> BonuriDeCasaList { get; set; }
        public ICommand EmiteBonCommand { get; }

        public CasierVM()
        {
            _context = new SupermarketDBEntities();
            BonuriDeCasaList = new ObservableCollection<BonuriDeCasa>(_context.BonuriDeCasa.Where(b => b.CasierId == LoginVM.UtilizatorConectat.Id).ToList());
            EmiteBonCommand = new RelayCommand(EmiteBon);
        }

        private void EmiteBon(object obj)
        {
            try
            {
                var bon = new BonuriDeCasa
                {
                    DataEliberarii = DateTime.Now,
                    CasierId = LoginVM.UtilizatorConectat.Id,
                    SumaIncasata = 0 // Adaugă suma corespunzătoare
                };

                _context.BonuriDeCasa.Add(bon);
                _context.SaveChanges();
                BonuriDeCasaList.Add(bon);

                MessageBox.Show("Bon emis!", "Succes", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Emite Bon Error");
            }
        }
    }

}
