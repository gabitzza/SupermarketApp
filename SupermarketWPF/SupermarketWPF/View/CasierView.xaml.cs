using System.Windows.Controls;
using System.Linq;
using System.Windows;
using SupermarketWPF.Models;
using SupermarketWPF.ViewModels;

namespace SupermarketWPF.View
{
    public partial class CasierView : Window
    {
        public CasierView(int utilizatorId)
        {
            InitializeComponent();
            DataContext = new CasierVM(utilizatorId);
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var dataGrid = sender as DataGrid;
            var selectedProduct = dataGrid.SelectedItem as Produse;

            if (selectedProduct != null)
            {
                var viewModel = DataContext as CasierVM;
                viewModel.AddToBonCommand.Execute(selectedProduct);
            }
        }
    }
}
