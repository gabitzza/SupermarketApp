using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SupermarketWPF.View
{
    /// <summary>
    /// Interaction logic for AdministratorView.xaml
    /// </summary>
    public partial class AdministratorView : Window
    {
        public AdministratorView()
        {
            InitializeComponent();
            DataContext = new ViewModels.AdministratorVM();
        }

        private void OpenProduseWindow_Click(object sender, RoutedEventArgs e)
        {
            ProduseView produseWindow = new ProduseView();
            produseWindow.Show();
        }

        private void OpenStocuriWindow_Click(object sender, RoutedEventArgs e)
        {
            StocuriView stocuriWindow = new StocuriView();
            stocuriWindow.Show();
        }
    }
}
