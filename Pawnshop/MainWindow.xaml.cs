using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.IO;
namespace Pawnshop
{

    public partial class MainWindow : Window
    {
        string pathCustomers = @"../users.txt";
        string pathDeals = @"../deals.txt";
        string pathProducts = @"../products.txt";
        string pathPawnShop = @"../pawnshop.txt";

        public MainWindow()
        {
            InitializeComponent();

            CreateFile(pathDeals);
            CreateFile(pathProducts);
            CreateFile(pathPawnShop);
            CreateFile(pathCustomers);
        }

        private void ButtonClickCreateDeal(object sender, RoutedEventArgs e)
        {
            DealWindow dealWindow = new DealWindow();
            dealWindow.Show();
            Close();
        }

        private void ButtonClickShowProducts(object sender, RoutedEventArgs e)
        {
            if (!fileEmpty(pathProducts))
            {

                ShowProducts showProducts = new ShowProducts();
                showProducts.Show();
                Close();
                
            }
            else
            {
                MessageBox.Show("Нет информации о товарах");
            }

            
        }
        private void ButtonClickShowDeals(object sender, RoutedEventArgs e)
        {
            if (!fileEmpty(pathDeals))
            {
                ShowDeals showDeals = new ShowDeals();

                showDeals.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Нет информации о договорах");
            }
        }
        private bool fileEmpty(string path)
        {
            bool fileEmpty = false;
            using (StreamReader stream = new StreamReader(path, Encoding.GetEncoding(1251)))
            {

                string dataUsers = stream.ReadToEnd();
                if (string.IsNullOrEmpty(dataUsers))
                {
                    fileEmpty = true;
                }

            }
            return fileEmpty;
        }
        private void CreateFile(string path)
        {
            if (!File.Exists(path))
            {
                FileStream fs = new FileStream(path, FileMode.Create);
                if (path == @"../pawnshop.txt")
                {
                    byte[] input = Encoding.Default.GetBytes("200000");
                    fs.Write(input, 0, input.Length);
                }
                fs.Close();
                
            }
            
        }
    }
}
