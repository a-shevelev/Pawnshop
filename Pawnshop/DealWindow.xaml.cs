using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.IO;
using System.Globalization;
using System.Windows.Controls;

namespace Pawnshop
{
    

    public partial class DealWindow : Window
    {

        public string[] categories;
        public string[][] producers;
        public string[][][] models;
        public string[] users;
        int index = 0;

        string pathCustomers = @"../users.txt";
        string pathDeals = @"../deals.txt";
        string pathProducts = @"../products.txt";

        public DealWindow()
        {
            InitializeComponent();
            categories = new string[] { "Часы", "Кольца", "Серьги" };
            producers = new string[][] {
                new string []{ "Rolex", "Casio", "GIOGIO Armani" },
                new string[] { "Cartier", "SOKOLOV" },
                new string[] { "Klava Coca Collection"} };
            models = new string[][][] {
                new string[][] {
                    new string[] { "Air King", "Explorer" },
                    new string[] { "G-SHOCK", "EDIFICE" },
                     new string[] { "AR11272", "AR11274" },
                },
                new string[][] {
                    new string[] { "Золото 585", "Серебро 925" },
                    new string[] { "Золото 777", "Серебро 555" }
                },
                new string[][] { new string [] { "Краш", "Зая" }
                }
            };

            using (StreamReader stream = new StreamReader(pathCustomers, Encoding.GetEncoding(1251))){
                string dataUsers = stream.ReadToEnd();
                users = dataUsers.Split('/');
                
            }
            
            ComboBoxCategory.ItemsSource = categories;
            ComboBoxCustomer.ItemsSource = users;
            DataContext = this;
            Date1.SelectedDate = DateTime.Now;
            Date1.BlackoutDates.AddDatesInPast();
            DateReturn.BlackoutDates.AddDatesInPast();
            DateReturn.BlackoutDates.Add(new CalendarDateRange(DateTime.Now));
            DateReturn.BlackoutDates.Add(new CalendarDateRange(DateTime.Now.AddYears(1), DateTime.Now.AddYears(1000)));
            DateReturn.DisplayDate = DateTime.Now.AddDays(1);
            
        }
        private void ButtonClickAddNewCustomer(object sender, RoutedEventArgs e)
        {
            NewCustomer newCustomer = new NewCustomer();
            //newCustomer.Show();
            if (newCustomer.ShowDialog() == true)
            {
                Close();
            }
 
            
        }
        //допилю номкр договора
        private string findNumberOfDeal(object sender, RoutedEventArgs e)
        {
            string result = "dxfjkn";
            using (StreamReader stream = new StreamReader(pathDeals, Encoding.GetEncoding(1251)))
            {

                string dataUsers = stream.ReadToEnd();
                users = dataUsers.Split('/');
                
            }
            return result;
        }
        private double findNumberOfProduct()
        {
            double result = 1;
            string productInfo = "dxfjkn";
            using (StreamReader stream = new StreamReader(pathProducts, Encoding.GetEncoding(1251)))
            {
                while (!stream.EndOfStream)
                {
                    productInfo = stream.ReadLine();
                    result++;
                }
               // string dataProducts= stream.ReadToEnd();
               // string [] productInfo = dataProducts.Split('/');

            }
            return result;
        }

        private void ButtonClickMakeNewDeal(object sender, RoutedEventArgs e)
        {
            bool Valid = CheckSelectedItem(ComboBoxCustomer.SelectedItem, ComboBoxCustomer) & CheckSelectedItem(ComboBoxCategory.SelectedItem, ComboBoxCategory) & CheckSelectedItem(ComboBoxProducer.SelectedItem, ComboBoxProducer) & CheckSelectedItem(ComboBoxModel.SelectedItem, ComboBoxModel) & CheckTextBox(PriceProduct.Text, 1, PriceProduct) & CheckSelectedItem(DateReturn.SelectedDate, DateReturn) & CheckYear(YearOfProduction.Text, 1, YearOfProduction);

            if (Valid == true)
            {
                string CustomerInfo = ComboBoxCustomer.SelectedItem.ToString();
                string Category = ComboBoxCategory.SelectedItem.ToString();
                string Producer = ComboBoxProducer.SelectedItem.ToString();
                string Model = ComboBoxModel.SelectedItem.ToString();
                double Price = Convert.ToDouble(PriceProduct.Text);
                var DateOfDeal = DateTime.Now;
                var DateOfReturn = DateReturn.SelectedDate.Value.Date;
                string Year = YearOfProduction.Text.ToString();
                double InterestRate = CalculateInterestRate(Price);
                double Comission = Math.Round(Convert.ToDouble((DateOfReturn - DateOfDeal).Days)*InterestRate*Price/100.0,2);
                double SumOfRefund = Price + Comission;
          
                DealInfo newDealInfo = new DealInfo();
                newDealInfo.CustomerInfo.Text = CustomerInfo;
                newDealInfo.ProductInfo.Text = Category + ' ' + Producer + "  "+  Model + "  " + Year + " года";
                newDealInfo.dateOfDeal.Text = DateOfDeal.ToString();
                newDealInfo.dateOfReturn.Text = DateOfReturn.ToString("d");
                newDealInfo.SumOfLoan.Text = Price.ToString();
                newDealInfo.InterestRate.Text = InterestRate.ToString()+" %";
                newDealInfo.Comission.Text = Comission.ToString();
                newDealInfo.SumOfRefund.Text = SumOfRefund.ToString();

                if (newDealInfo.ShowDialog() == true)
                {
                    Close();
                    double numberProduct = findNumberOfProduct();
                    using (StreamWriter stream = new StreamWriter(pathProducts, true, Encoding.GetEncoding(1251)))
                    {
                        stream.WriteLine($"{numberProduct}/{Category}/{Producer}/{Model}/{Year}/{Price}");
                    }
                    using (StreamWriter stream = new StreamWriter(pathDeals, true, Encoding.GetEncoding(1251)))
                    {
                        //MessageBox.Show(ComboBoxCustomer.SelectedItem.ToString());



                        // MessageBox.Show(ComboBoxCustomer.SelectedItem);
                       // stream.WriteLine($"{CustomerInfo} {Category} {Producer} {Model} {Year} {DateOfDeal} {DateOfReturn} {Price} {InterestRate} {Comission} {SumOfRefund}");
                    }
                    
                }
            }
            
        }
        private void ComboBoxCategorySelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            ComboBoxProducer.ItemsSource = producers[ComboBoxCategory.SelectedIndex];
            index = ComboBoxCategory.SelectedIndex;
            ComboBoxModel.ItemsSource = null;
            MarkValid(ComboBoxCategory);
        }
        private void ComboBoxProducerSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           try
            {
                ComboBoxModel.ItemsSource = models[index][ComboBoxProducer.SelectedIndex];
            }
            catch(IndexOutOfRangeException)
            {
                
            }
            MarkValid(ComboBoxProducer);


        }
        private void ComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MarkValid(sender as ComboBox);
        }
        private void DateSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MarkValid(DateReturn);
        }
        
        private void TextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            MarkValid(sender as TextBox);
        }
        private void ButtonClickReturnToMenu(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();

        }
        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
        private void TextBoxPreviewDigitInput(object sender, TextCompositionEventArgs e)
        {
            int val;
            e.Handled = !Int32.TryParse(e.Text, out val);
        }
        private void MarkInvalid(Control control)
        {
            control.BorderBrush = Brushes.Red;
        }
        private void MarkValid(Control control)
        {
            control.BorderBrush = Brushes.Gray;

        }
        private bool CheckTextBox(string text, int count, Control control)
        {

            if (text.Length < count)
            {
                MarkInvalid(control);
                return false;
            }
            else
            {
                MarkValid(control);
                return true;
            }
        }
        private bool CheckYear(string text, int count, Control control)
        {
            if ((text.Length < count) || (Convert.ToInt32(text) > DateTime.Now.Year))
            {
                MarkInvalid(control);
                return false;
            }
            else
            {
                MarkValid(control);
                return true;
            }
        }
        private bool CheckSelectedItem(object item, Control control)
        {
            if (item == null)
            {
                MarkInvalid(control);
                return false;
            }
            else
            {
                MarkValid(control);
                return true;
            }
        }
        private double CalculateInterestRate(double sum)
        {

            double interestRate;
            if (sum > 75000)
            {
                interestRate = 0.25;
            }
            else
            {
                interestRate = 0.4;
            }

            return interestRate;
        }
    }
}
