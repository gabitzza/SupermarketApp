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
    /// Interaction logic for ProduseView.xaml
    /// </summary>
    public partial class ProduseView : Window
    {
        public ProduseView()
        {
            InitializeComponent();
            try
            {
                DataContext = new ViewModels.ProduseVM();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Eroare la inițializare", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
