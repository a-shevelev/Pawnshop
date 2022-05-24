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
        bool CustomerEmpty = false;

        string pathCustomers = @"../users.txt";
        string pathDeals = @"../deals.txt";
        string pathProducts = @"../products.txt";
        string pathPawnShop = @"../pawnshop.txt";

        public DealWindow()
        {
            InitializeComponent();
            categories = new string[] { "Браслет", "Кольцо", "Кулон", "Серьги", "Часы", "Цепь"};
            producers = new string[][] {
                new string []{ "-","Cartier", "Chopard", "Harry Winston", "Pandora", "SOKOLOV","Tiffany & Co", "Van Cleef & Arpels" },
                new string []{ "-","Cartier", "Chopard", "Harry Winston", "Pandora", "SOKOLOV","Tiffany & Co", "Van Cleef & Arpels" },
                new string []{ "-","Cartier", "Chopard", "Harry Winston", "Pandora", "SOKOLOV","Tiffany & Co", "Van Cleef & Arpels" },
                new string []{ "-","Cartier", "Chopard", "Harry Winston", "Pandora", "SOKOLOV","Tiffany & Co", "Van Cleef & Arpels" },
                new string []{ "-",  "Cartier", "Casio","Rolex","Seiko","Ника"},
                new string []{ "-","Cartier", "Chopard", "Harry Winston", "Pandora", "SOKOLOV","Tiffany & Co", "Van Cleef & Arpels" },
                };
            models = new string[][][] {
                new string[][] {
                    new string[] { "-" },
                    new string[] { "-", "Ballerine", "d'Amour", "Maillon Panthère", "Trinity", "Trinity Ruban" },
                    new string[] { "-", "Ballerine", "d'Amour", "Maillon Panthère", "Trinity", "Trinity Ruban" },
                    new string[] { "-", "Ballerine", "d'Amour", "Maillon Panthère", "Trinity", "Trinity Ruban" },
                    new string[] { "-", "Angel", "Heart", "Love" },
                    new string[] { "-", "Золото 585", "Серебро 555" },
                    new string[] { "-", "Ballerine", "d'Amour", "Maillon Panthère", "Trinity", "Trinity Ruban" },
                    new string[] { "-", "Ballerine", "d'Amour", "Maillon Panthère", "Trinity", "Trinity Ruban" }
                },
                
                new string[][] {
                    new string[] { "-" },
                    new string[] { "-", "Ballerine", "d'Amour", "Maillon Panthère", "Trinity", "Trinity Ruban" },
                    new string[] { "-", "Ballerine", "d'Amour", "Maillon Panthère", "Trinity", "Trinity Ruban" },
                    new string[] { "-", "Ballerine", "d'Amour", "Maillon Panthère", "Trinity", "Trinity Ruban" },
                    new string[] { "-", "Angel", "Heart", "Love" },
                    new string[] { "-", "Золото 585", "Серебро 555" },
                    new string[] { "-", "Ballerine", "d'Amour", "Maillon Panthère", "Trinity", "Trinity Ruban" },
                    new string[] { "-", "Ballerine", "d'Amour", "Maillon Panthère", "Trinity", "Trinity Ruban" }
                },
                new string[][] {
                    new string[] { "-" },
                    new string[] { "-", "Ballerine", "d'Amour", "Maillon Panthère", "Trinity", "Trinity Ruban" },
                    new string[] { "-", "Ballerine", "d'Amour", "Maillon Panthère", "Trinity", "Trinity Ruban" },
                    new string[] { "-", "Ballerine", "d'Amour", "Maillon Panthère", "Trinity", "Trinity Ruban" },
                    new string[] { "-", "Angel", "Heart", "Love" },
                    new string[] { "-", "Золото 585", "Серебро 555" },
                    new string[] { "-", "Ballerine", "d'Amour", "Maillon Panthère", "Trinity", "Trinity Ruban" },
                    new string[] { "-", "Ballerine", "d'Amour", "Maillon Panthère", "Trinity", "Trinity Ruban" }
                },
                new string[][] {
                    new string[] { "-" },
                    new string[] { "-", "Ballerine", "d'Amour", "Maillon Panthère", "Trinity", "Trinity Ruban" },
                    new string[] { "-", "Ballerine", "d'Amour", "Maillon Panthère", "Trinity", "Trinity Ruban" },
                    new string[] { "-", "Ballerine", "d'Amour", "Maillon Panthère", "Trinity", "Trinity Ruban" },
                    new string[] { "-", "Angel", "Heart", "Love" },
                    new string[] { "-", "Золото 585", "Серебро 555" },
                    new string[] { "-", "Ballerine", "d'Amour", "Maillon Panthère", "Trinity", "Trinity Ruban" },
                    new string[] { "-", "Ballerine", "d'Amour", "Maillon Panthère", "Trinity", "Trinity Ruban" }
                },
                new string[][] {
                    new string[] { "-" },
                    new string[] { "-", "Ballon Bleu", "Crash", "Ronde Louis" , "Ronde Must","Ronde Solo" ,"Santos-Dumont" },
                    new string[] { "-", "BABY-G", "Edifice", "G-SHOCK" , "PROTREK", "Sheen" ,"Vintage" },
                    new string[] { "-", "Air-King", "Datejust", "Explorer", "Oyster Perpetual", "Sheen" ,"Vintage" },
                    new string[] { "-", "Alpinist", "Astron", "Lord Marvel", "Tuna" },
                    new string[] { "-", "Celebrity", "EGO", "Gentleman" }
                },
                new string[][] {
                    new string[] { "-" },
                    new string[] { "-", "Ballerine", "d'Amour", "Maillon Panthère", "Trinity", "Trinity Ruban" },
                    new string[] { "-", "Ballerine", "d'Amour", "Maillon Panthère", "Trinity", "Trinity Ruban" },
                    new string[] { "-", "Ballerine", "d'Amour", "Maillon Panthère", "Trinity", "Trinity Ruban" },
                    new string[] { "-", "Angel", "Heart", "Love" },
                    new string[] { "-", "Золото 585", "Серебро 555" },
                    new string[] { "-", "Ballerine", "d'Amour", "Maillon Panthère", "Trinity", "Trinity Ruban" },
                    new string[] { "-", "Ballerine", "d'Amour", "Maillon Panthère", "Trinity", "Trinity Ruban" }
                }

            };

            using (StreamReader stream = new StreamReader(pathCustomers, Encoding.GetEncoding(1251))){
                string dataUsers = stream.ReadToEnd();
                if (!string.IsNullOrEmpty(dataUsers))
                {
                    users = dataUsers.Split('/');
                }
                else
                {
                    CustomerEmpty = true;
                }
                
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
            if (newCustomer.ShowDialog() == true)
            {
                Close();
            }
 
            
        }
        private void ButtonClickEditCustomer(object sender, RoutedEventArgs e)
        {
            
            
            if (CheckSelectedItem(ComboBoxCustomer.SelectedItem, ComboBoxCustomer))
            {
                EditCustomer editCustomer = new EditCustomer();
                
                string[] customer = ComboBoxCustomer.SelectedItem.ToString().Split(' ');
                    editCustomer.previousCustomer.FirstName = editCustomer.TextBoxFirstName.Text = customer[0];
                editCustomer.previousCustomer.SecondName = editCustomer.TextBoxSecondName.Text = customer[1];
                editCustomer.previousCustomer.Patronymic = editCustomer.TextBoxPatronymic.Text = customer[2];
                editCustomer.previousCustomer.Passport = editCustomer.TextBoxPassport.Text = customer[3];
                editCustomer.previousCustomer.PhoneNumber = editCustomer.TextBoxPhoneNumber.Text = customer[4];

                if (editCustomer.ShowDialog() == true)
                {
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Выберите клиента для редактирования");
            }


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
            }
            return result;
        }

        private void ButtonClickMakeNewDeal(object sender, RoutedEventArgs e)
        {
            bool Valid = CheckSelectedItem(ComboBoxCustomer.SelectedItem, ComboBoxCustomer) & CheckSelectedItem(ComboBoxCategory.SelectedItem, ComboBoxCategory) & CheckSelectedItem(ComboBoxProducer.SelectedItem, ComboBoxProducer) & CheckSelectedItem(ComboBoxModel.SelectedItem, ComboBoxModel) & CheckTextBox(PriceProduct.Text, 1, PriceProduct) & CheckSelectedItem(DateReturn.SelectedDate, DateReturn) & CheckYear(YearOfProduction.Text, 1, YearOfProduction);

            if (Valid == true && CheckCashRegister(PriceProduct.Text))
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
                double Comission = Math.Round(Math.Ceiling((DateOfReturn - DateOfDeal).TotalDays)*InterestRate*Price/100.0,2);
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
                    ReCountCashRegister(Price.ToString());
                    using (StreamWriter stream = new StreamWriter(pathProducts, true, Encoding.GetEncoding(1251)))
                    {
                        stream.WriteLine($"{numberProduct}/{Category}/{Producer}/{Model}/{Year}/{Price}");
                    }
                    using (StreamWriter stream = new StreamWriter(pathDeals, true, Encoding.GetEncoding(1251)))
                    {
                        MessageBox.Show($"Сделка заключена.\nКлиент: {CustomerInfo}\nТовар: {Category} {Producer} {Model} {Year} года\nДата сделки: {DateOfDeal.ToString("d")}\nДата возврата: {DateOfReturn.ToString("d")}\nПроцент: {InterestRate} %\nКомиссия: {Comission} руб.\nСумма возврата: {SumOfRefund} руб.");
                        stream.WriteLine($"{CustomerInfo}/{Category} {Producer} {Model}/{Year}/{DateOfDeal.ToString("d")}/{DateOfReturn.ToString("d")}/{Price}/{InterestRate}/{Comission}/{SumOfRefund}");
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
        private void CustomerOnDropDownOpened(object sender, EventArgs e)
        {
            if (ComboBoxCustomer.IsDropDownOpen == true && CustomerEmpty)
            {
                MessageBox.Show("Нет данных о клиентах. Добавьте нового клиента.");
            }
        }
        private bool CheckCashRegister(string price)
        {
            bool result=true;
            double cashRegister;
            using (StreamReader stream = new StreamReader(pathPawnShop, Encoding.GetEncoding(1251)))
            {
                cashRegister = Convert.ToDouble(stream.ReadLine());


            }
            if (Convert.ToDouble(price) > Convert.ToDouble(cashRegister))
            {
                result = false;
                MessageBox.Show($"К сожалению сделка невозможна. Текущее состояние кассы: {cashRegister} руб.");
            }       
            return result;
        }
        private void ReCountCashRegister(string price)
        {
            double cashRegister;
            string data;
            using (StreamReader stream = new StreamReader(pathPawnShop, Encoding.GetEncoding(1251)))
            {

                cashRegister = Convert.ToDouble(stream.ReadLine());
                data = stream.ReadToEnd();


            }
            cashRegister = cashRegister - Convert.ToDouble(price);
            using (StreamWriter stream = new StreamWriter(pathPawnShop, false, Encoding.GetEncoding(1251)))
            {

                stream.WriteLine(cashRegister);
                stream.Write(data);

            }
        }
    }
}
