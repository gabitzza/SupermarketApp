using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SupermarketWPF.Helpers;
using SupermarketWPF.Models;
namespace SupermarketWPF.ViewModels
{
    public class IncasariVM : BaseVM
    {
        private readonly Utilizatori _selectedUser;
        private readonly SupermarketDBEntities _context;
        public ObservableCollection<string> Months { get; }
        public ObservableCollection<BonuriDeCasa> VenituriList { get; set; }
        public ICommand SelecteazaLunaCommand { get; }

        public IncasariVM(Utilizatori selectedUser, SupermarketDBEntities context)
        {
            _selectedUser = selectedUser;
            _context = context;
            Months = new ObservableCollection<string>(System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.MonthNames.Take(12));
            SelecteazaLunaCommand = new RelayCommand(SelecteazaLuna);
        }

        private void SelecteazaLuna(object obj)
        {
            var selectedMonth = obj as string;
            if (!string.IsNullOrEmpty(selectedMonth))
            {
                int month = Array.IndexOf(System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.MonthNames, selectedMonth) + 1;
                VenituriList = new ObservableCollection<BonuriDeCasa>(
                    _context.BonuriDeCasa.Where(b => b.CasierId == _selectedUser.Id && b.Data.Month == month).ToList());
                OnPropertyChanged(nameof(VenituriList));
            }
        }
    }
}
