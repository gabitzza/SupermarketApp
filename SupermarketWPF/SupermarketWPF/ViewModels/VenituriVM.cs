using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using SupermarketWPF.Models;
using SupermarketWPF.Helpers;

namespace SupermarketWPF.ViewModels
{
    public class VenituriVM : BaseVM
    {
        private readonly SupermarketDBEntities _context;
        private int _casierId;
        private DateTime _lunaSelectata;

        public DateTime LunaSelectata
        {
            get { return _lunaSelectata; }
            set { _lunaSelectata = value; OnPropertyChanged(nameof(LunaSelectata)); }
        }

        public ObservableCollection<VenitPeZi> VenituriPeZiList { get; set; }
        public ICommand VizualizeazaVenituriCommand { get; }

        public VenituriVM(SupermarketDBEntities context, int casierId)
        {
            _context = context;
            _casierId = casierId;
            VenituriPeZiList = new ObservableCollection<VenitPeZi>();

            VizualizeazaVenituriCommand = new RelayCommand(VizualizeazaVenituri);
        }

        private void VizualizeazaVenituri(object obj)
        {
            var venituriPeZi = _context.BonuriDeCasa
                .Where(b => b.CasierId == _casierId && b.DataEliberarii.Month == LunaSelectata.Month && b.DataEliberarii.Year == LunaSelectata.Year)
                .GroupBy(b => b.DataEliberarii.Day)
                .Select(g => new VenitPeZi
                {
                    Ziua = g.Key,
                    SumaIncasata = g.Sum(b => b.SumaIncasata)
                })
                .ToList();

            VenituriPeZiList.Clear();
            foreach (var venit in venituriPeZi)
            {
                VenituriPeZiList.Add(venit);
            }
        }
    }

    public class VenitPeZi
    {
        public int Ziua { get; set; }
        public decimal SumaIncasata { get; set; }
    }
}
