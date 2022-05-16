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
using System.Globalization;
using System.IO;
namespace Pawnshop
{
    /// <summary>
    /// Логика взаимодействия для NewCustomer.xaml
    /// </summary>
    public partial class NewCustomer : Window
    {
        //public Customer customer { get; set; }
        
        string pathCustomers = @"../users.txt";
        int countDefis = 0;
        public NewCustomer()
        {
            InitializeComponent();
        }
        
        private void ClickAddNewCustomer(object sender, RoutedEventArgs e)
        {
            
            Customer customer = new Customer();
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            bool Valid;
            bool firstCustomer = false;
            bool CustomExist = true;
            customer.FirstName = textInfo.ToTitleCase(TextBoxFirstName.Text.ToLower());
            customer.SecondName = textInfo.ToTitleCase(TextBoxSecondName.Text.ToLower());
            customer.Patronymic = textInfo.ToTitleCase(TextBoxPatronymic.Text.ToLower());
            customer.Passport = TextBoxPassport.Text;
            customer.PhoneNumber = TextBoxPhoneNumber.Text;
            Valid = CheckTextBox(customer.FirstName, 2, TextBoxFirstName) & CheckTextBox(customer.SecondName, 2, TextBoxSecondName) & CheckTextBox(customer.Patronymic, 2, TextBoxPatronymic) & CheckTextBox(customer.Passport, 10, TextBoxPassport) & CheckTextBox(customer.PhoneNumber, 12, TextBoxPhoneNumber);

            if (Valid == true) {            
               using (StreamReader reader= new StreamReader(pathCustomers, Encoding.GetEncoding(1251)))
                    {
                    string[] users;
                        string dataUsers = reader.ReadToEnd();
                    if (string.IsNullOrEmpty(dataUsers))
                    {
                        firstCustomer = true;
                    }
                        users = dataUsers.Split('/');
                    for (int i = 0; i < users.Length; i++)
                    {
                        if (users[i] == $"{customer.FirstName} {customer.SecondName} {customer.Patronymic} {customer.Passport} {customer.PhoneNumber}")
                        {
                            MessageBox.Show("Такой клиент уже существует");
                            CustomExist = true;

                            break;
                        }
                        else
                        {
                            CustomExist = false;
                        }
                    }
               }
                if (!CustomExist)
                {
                    using (StreamWriter stream = new StreamWriter(pathCustomers, true, Encoding.GetEncoding(1251)))
                    {
                        if (firstCustomer)
                        {
                            stream.Write($"{customer.FirstName} {customer.SecondName} {customer.Patronymic} {customer.Passport} {customer.PhoneNumber}");
                        }
                        else
                        {
                            stream.Write($"/{customer.FirstName} {customer.SecondName} {customer.Patronymic} {customer.Passport} {customer.PhoneNumber}");
                        }
                        MessageBox.Show("Клиент успешно добавлен");
                    }
                }
               // MessageBox.Show($"{customer.FirstName}\n{customer.SecondName}\n{customer.Patronymic}");
                DealWindow dealWindow = new DealWindow();
                dealWindow.Show();
                this.DialogResult = true;
            }
            
        }
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !e.Text.All(IsRussianSymbols);
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
        private void TextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            MarkValid(sender as TextBox);
        }

        bool IsRussianSymbols(char c)
        {
            if (c >= 'А' && c <= 'Я')
                return true;
            if (c >= 'а' && c <= 'я')
                return true;
            if (c == '-' && countDefis == 0)
            {
                countDefis++;
                return true;
            }
            return false;
        }
        private void MarkInvalid(Control control)
        {
            control.BorderBrush = Brushes.Red;
            DialogResult = null;
        }
        private void MarkValid(Control control)
        {
            control.BorderBrush = Brushes.Gray;
            //DialogResult = null;
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
        
    }
}
