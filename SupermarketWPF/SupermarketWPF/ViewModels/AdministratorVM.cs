using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using SupermarketWPF.Helpers;
using SupermarketWPF.Models;
using SupermarketWPF.View;

namespace SupermarketWPF.ViewModels
{
    public class AdministratorVM : BaseVM
    {
        private readonly SupermarketDBEntities _context;
        public ICommand OpenProducatoriViewCommand { get; }
        public ICommand OpenUtilizatoriViewCommand { get; }
        public ICommand OpenCategoriiViewCommand { get; }
        public ICommand OpenProduseViewCommand { get; }
        public ICommand OpenStocuriViewCommand { get; }

        public ObservableCollection<BonuriDeCasa> BonuriDeCasaList { get; set; }
        public ObservableCollection<Utilizatori> UtilizatoriList { get; set; }
        public ICommand VizualizeazaVenituriCommand { get; }
        public AdministratorVM(SupermarketDBEntities context)
        {
            OpenProducatoriViewCommand = new RelayCommand(OpenProducatoriView);
            OpenUtilizatoriViewCommand = new RelayCommand(OpenUtilizatoriView);
            OpenCategoriiViewCommand = new RelayCommand(OpenCategoriiView);
            OpenProduseViewCommand = new RelayCommand(OpenProduseView);
            OpenStocuriViewCommand = new RelayCommand(OpenStocuriView);
            UtilizatoriList = new ObservableCollection<Utilizatori>(_context.Utilizatori.Where(u => u.TipUtilizator == "Casier").ToList());
            VizualizeazaVenituriCommand = new RelayCommand(VizualizeazaVenituri);
            _context = context;
        }

        private void VizualizeazaVenituri(object obj)
        {
            var utilizator = obj as Utilizatori;
            if (utilizator != null)
            {
                BonuriDeCasaList = new ObservableCollection<BonuriDeCasa>(_context.BonuriDeCasa.Where(b => b.CasierId == utilizator.Id).ToList());
                OnPropertyChanged(nameof(BonuriDeCasaList));
                // Deschide fereastra de vizualizare a bonurilor și veniturilor
            }
        }

        private void OpenProducatoriView(object obj)
        {
            ProducatorView producatoriView = new ProducatorView();
            producatoriView.Show();
        }

        private void OpenUtilizatoriView(object obj)
        {
            UtilizatoriView utilizatoriView = new UtilizatoriView();
            utilizatoriView.Show();
        }

        private void OpenCategoriiView(object obj)
        {
            CategoriiView categoriiView = new CategoriiView();
            categoriiView.Show();
        }

        private void OpenProduseView(object obj)
        {
            ProduseView produseView = new ProduseView();
            produseView.Show();
        }

        private void OpenStocuriView(object obj)
        {
            StocuriView stocuriView = new StocuriView();
            stocuriView.Show();
        }
    }
}
