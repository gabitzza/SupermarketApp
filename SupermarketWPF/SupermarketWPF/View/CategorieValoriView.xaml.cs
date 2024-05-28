using SupermarketWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SupermarketWPF.View
{
    /// <summary>
    /// Interaction logic for CategorieValoriView.xaml
    /// </summary>
    public partial class CategorieValoriView : Window
    {
        public CategorieValoriView(CategorieValoriVM viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}