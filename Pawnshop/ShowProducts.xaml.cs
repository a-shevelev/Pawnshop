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
    public partial class ShowProducts : Window
    {

        public string[] productsInfo;

        string pathProducts = @"../products.txt";

        
        public ShowProducts()
        {
            InitializeComponent();
            List<Product> products = new List<Product>();
             using (StreamReader stream = new StreamReader(pathProducts, Encoding.GetEncoding(1251)))
             {
                 while (!stream.EndOfStream)
                 {
                     productsInfo = stream.ReadLine().Split('/');
                     products.Add(new Product() { Id = Convert.ToDouble(productsInfo[0]), Category = productsInfo[1], Producer = productsInfo[2], Model = productsInfo[3],  Year = productsInfo[4], Price = productsInfo[5] });

                 }

             }
                 
            Wares.ItemsSource = products;

        }
        private void ButtonClickReturnToMenu(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();

        }


    }

   
    
}