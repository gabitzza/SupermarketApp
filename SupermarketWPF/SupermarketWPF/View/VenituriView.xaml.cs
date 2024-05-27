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
using SupermarketWPF.Models;
using SupermarketWPF.ViewModels;
namespace SupermarketWPF.View
{
    /// <summary>
    /// Interaction logic for VenituriView.xaml
    /// </summary>
    public partial class VenituriView : Window
    {
        public VenituriView(SupermarketDBEntities context, int utilizatorId)
        {
            InitializeComponent();
            DataContext = new VenituriVM(context, utilizatorId);
        }
    }
}

