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
using System.Globalization;
using System.IO;

namespace Pawnshop
{
    /// <summary>
    /// Логика взаимодействия для EditCustomer.xaml
    /// </summary>
    public partial class EditCustomer : Window
    {
        string pathCustomers = @"../users.txt";
        int countDefis = 0;
        public Customer previousCustomer = new Customer();
        public EditCustomer()
        {
            
            InitializeComponent();
        }
        private void ClickSaveChanges(object sender, RoutedEventArgs e) {
            Customer newCustomer = new Customer();
            
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            bool Valid;
            //bool firstCustomer = false;
            bool CustomExist = true;
            newCustomer.FirstName = textInfo.ToTitleCase(TextBoxFirstName.Text.ToLower());
            newCustomer.SecondName = textInfo.ToTitleCase(TextBoxSecondName.Text.ToLower());
            newCustomer.Patronymic = textInfo.ToTitleCase(TextBoxPatronymic.Text.ToLower());
            newCustomer.Passport = TextBoxPassport.Text;
            newCustomer.PhoneNumber = TextBoxPhoneNumber.Text;
            Valid = CheckTextBox(newCustomer.FirstName, 2, TextBoxFirstName) & CheckTextBox(newCustomer.SecondName, 2, TextBoxSecondName) & CheckTextBox(newCustomer.Patronymic, 2, TextBoxPatronymic) & CheckTextBox(newCustomer.Passport, 10, TextBoxPassport) & CheckTextBox(newCustomer.PhoneNumber, 12, TextBoxPhoneNumber);

            if (Valid == true)
            {
                
                string[] users;
                using (StreamReader reader = new StreamReader(pathCustomers, Encoding.GetEncoding(1251)))
                {
                    
                    string dataUsers = reader.ReadToEnd();
                    
                    users = dataUsers.Split('/');
                    for (int i = 0; i < users.Length; i++)
                    {
                        if (($"{newCustomer.FirstName} {newCustomer.SecondName} {newCustomer.Patronymic} {newCustomer.Passport} {newCustomer.PhoneNumber}" != $"{previousCustomer.FirstName} {previousCustomer.SecondName} {previousCustomer.Patronymic} {previousCustomer.Passport} {previousCustomer.PhoneNumber}") && (users[i] == $"{newCustomer.FirstName} {newCustomer.SecondName} {newCustomer.Patronymic} {newCustomer.Passport} {newCustomer.PhoneNumber}"))
                        {
                            MessageBox.Show("Такой клиент уже существует");
                            CustomExist = true;

                            break;
                        }
                        else if($"{newCustomer.FirstName} {newCustomer.SecondName} {newCustomer.Patronymic} {newCustomer.Passport} {newCustomer.PhoneNumber}" == $"{previousCustomer.FirstName} {previousCustomer.SecondName} {previousCustomer.Patronymic} {previousCustomer.Passport} {previousCustomer.PhoneNumber}")
                        {
                            CustomExist = true;
                            Close();
                            
                        }
                        else
                        {
                            CustomExist = false;
                            
                        }
                    }
                    for(int i = 0; i < users.Length; i++)
                    {
                        if (users[i] == $"{previousCustomer.FirstName} {previousCustomer.SecondName} {previousCustomer.Patronymic} {previousCustomer.Passport} {previousCustomer.PhoneNumber}")
                        {
                            users[i] = $"{newCustomer.FirstName} {newCustomer.SecondName} {newCustomer.Patronymic} {newCustomer.Passport} {newCustomer.PhoneNumber}";
                            break;
                        }
                    }
                }
                if (!CustomExist)
                {
                    bool firstCustomer = true;
                    using (StreamWriter stream = new StreamWriter(pathCustomers, false, Encoding.GetEncoding(1251)))
                    {
                        for (int i = 0; i < users.Length; i++)
                        {
                            if (firstCustomer)
                            {
                                stream.Write($"{users[i]}");
                                firstCustomer = false;
                            }
                            else
                            {
                                stream.Write($"/{users[i]}");
                            }
                        }
                        MessageBox.Show("Данные клиент успешно изменены");
                        
                        
                        stream.Close();
                    }
                    DealWindow dealWindow = new DealWindow();
                    dealWindow.Show();
                    DialogResult = true;

                }
                
                
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
