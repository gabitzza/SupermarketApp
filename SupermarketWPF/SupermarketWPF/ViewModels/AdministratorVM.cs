using System.Windows.Input;
using SupermarketWPF.Helpers;
using SupermarketWPF.View;

namespace SupermarketWPF.ViewModels
{
    public class AdministratorVM : BaseVM
    {
        public ICommand OpenProducatoriViewCommand { get; }
        public ICommand OpenUtilizatoriViewCommand { get; }
        public ICommand OpenCategoriiViewCommand { get; }
        public ICommand OpenProduseViewCommand { get; }
        public ICommand OpenStocuriViewCommand { get; }

        public AdministratorVM()
        {
            OpenProducatoriViewCommand = new RelayCommand(OpenProducatoriView);
            OpenUtilizatoriViewCommand = new RelayCommand(OpenUtilizatoriView);
            OpenCategoriiViewCommand = new RelayCommand(OpenCategoriiView);
            OpenProduseViewCommand = new RelayCommand(OpenProduseView);
            OpenStocuriViewCommand = new RelayCommand(OpenStocuriView);
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
