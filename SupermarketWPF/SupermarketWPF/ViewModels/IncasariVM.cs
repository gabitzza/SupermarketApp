using SupermarketWPF.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Data.Entity;
using SupermarketWPF.Helpers;

namespace SupermarketWPF.ViewModels
{
    public class IncasariVM : BaseVM
    {
        private readonly SupermarketDBEntities _context;
        private int _utilizatorId;
        private string _lunaSelectata;

        public ObservableCollection<Venit> VenituriList { get; set; }
        public ObservableCollection<string> Luni { get; set; }
        public string LunaSelectata
        {
            get { return _lunaSelectata; }
            set { _lunaSelectata = value; OnPropertyChanged(nameof(LunaSelectata)); }
        }

        public ICommand VizualizeazaVenituriCommand { get; }

        public IncasariVM(int utilizatorId)
        {
            _context = new SupermarketDBEntities();
            _utilizatorId = utilizatorId;
            VenituriList = new ObservableCollection<Venit>();
            Luni = new ObservableCollection<string>(Enumerable.Range(1, 12).Select(i => new DateTime(1, i, 1).ToString("MMMM")));
            VizualizeazaVenituriCommand = new RelayCommand(VizualizeazaVenituri);
        }

        private void VizualizeazaVenituri(object obj)
        {
            try
            {
                if (string.IsNullOrEmpty(LunaSelectata))
                {
                    MessageBox.Show("Selectați o lună.", "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var culture = new System.Globalization.CultureInfo("ro-RO");
                var dateTime = DateTime.ParseExact(LunaSelectata, "MMMM", culture);
                int luna = dateTime.Month;

                var venituri = _context.BonuriDeCasa
                    .Where(b => b.CasierId == _utilizatorId && b.IsActive == true && DbFunctions.TruncateTime(b.DataEliberarii).Value.Month == luna)
                    .GroupBy(b => DbFunctions.TruncateTime(b.DataEliberarii))
                    .Select(g => new Venit
                    {
                        Data = g.Key.Value,
                        SumaTotala = g.Sum(b => b.SumaIncasata)
                    })
                    .ToList();

                VenituriList.Clear();
                foreach (var venit in venituri)
                {
                    VenituriList.Add(venit);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la vizualizarea veniturilor: " + ex.Message, "Eroare", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

    public class Venit
    {
        public DateTime Data { get; set; }
        public decimal SumaTotala { get; set; }
    }
}
