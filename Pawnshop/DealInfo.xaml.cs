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
using System.Data.Entity;
using System.IO;
namespace Pawnshop
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class DealInfo : Window
    {
        public DealInfo()
        {
         
            
            InitializeComponent();
            /* void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                text.Customerr = ComboBoxCustomer.SelectedItem.ToString();
            }*/
           
        }
        private void ButtonClickEditDeal(object sender, RoutedEventArgs e)
        {

            Close();

        }
        private void ButtonClickConfirmDeal(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            DialogResult = true;

        }
    }
}
