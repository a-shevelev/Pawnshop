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
using System.IO;

namespace Pawnshop
{
    /// <summary>
    /// Логика взаимодействия для ShowDeals.xaml
    /// </summary>
    public partial class ShowDeals : Window
    {
        string pathDeals = @"../deals.txt";
        public string[] dealsInfo;
        public ShowDeals()
        {
            InitializeComponent();
            List<Deal> deals = new List<Deal>();
            using (StreamReader stream = new StreamReader(pathDeals, Encoding.GetEncoding(1251)))
            {
                while (!stream.EndOfStream)
                {
                    dealsInfo = stream.ReadLine().Split('/');
                    dealsInfo[0] = dealsInfo[0].Substring(0, dealsInfo[0].LastIndexOf(' '));
                    dealsInfo[0] = dealsInfo[0].Substring(0, dealsInfo[0].LastIndexOf(' '));
                    deals.Add(new Deal() { CustomerInfo = dealsInfo[0], Product = dealsInfo[1], Year = dealsInfo[2], DateOfDeal = dealsInfo[3], DateOfReturn = dealsInfo[4], Price = Convert.ToDouble(dealsInfo[5]), InterestRate = Convert.ToDouble(dealsInfo[6]), Comission = Convert.ToDouble(dealsInfo[7]), SumOfRefund = Convert.ToDouble(dealsInfo[8]) });

                }

            }

            Wares.ItemsSource = deals;
        }
        private void ButtonClickReturnToMenu(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();

        }
    }
}
