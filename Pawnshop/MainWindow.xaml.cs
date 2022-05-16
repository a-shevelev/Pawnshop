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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pawnshop
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonClickCreateDeal(object sender, RoutedEventArgs e)
        {
            DealWindow dealWindow = new DealWindow();
            dealWindow.Show();
            Close();
        }

        private void ButtonClickShowProducts(object sender, RoutedEventArgs e)
        {
           ShowProducts showProducts = new ShowProducts();
            showProducts.Show();
            Close();
        }
        private void ButtonClickShowDeals(object sender, RoutedEventArgs e)
        {
            ShowDeals showDeals = new ShowDeals();
            showDeals.Show();
            Close();
        }
    }
}
