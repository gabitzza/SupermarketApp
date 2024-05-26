using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SupermarketWPF.Helpers;
using SupermarketWPF.View;

namespace SupermarketWPF.ViewModels
{
    internal class AdministratorVM:BaseVM
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        public ICommand NavigateCommand { get; }

        public AdministratorVM()
        {
            NavigateCommand = new RelayCommand(Navigate);
        }

        private void Navigate(object parameter)
        {
            switch (parameter as string)
            {
                case "Producatori":
                    CurrentView = new ProducatorView();
                    break;

                //case "Utilizatori":
                //    CurrentView = new UtilizatoriView();
                //    break;
                //case "Categorii":
                //    CurrentView = new CategoriiView();
                //    break;
                case "Produse":
                    CurrentView = new ProduseView();
                    break;
                case "Stocuri":
                    CurrentView = new StocuriView();
                    break;
                default:
                    break;
            }
        }
    }
}
