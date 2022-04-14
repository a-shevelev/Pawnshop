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
namespace Pawnshop
{
    /// <summary>
    /// Логика взаимодействия для NewCustomer.xaml
    /// </summary>
    public partial class NewCustomer : Window
    {
        public Customer Customer { get; set; }
        public NewCustomer(Customer custom)
        {
            InitializeComponent();
            Customer = custom;
            Customer.FirstName = TextBoxFirstName.Text;
            Customer.SecondName = TextBoxSecondName.Text;
            Customer.Patronymic  = TextBoxPatronymic.Text;
            Customer.Passport = TextBoxPassport.Text;
            Customer.PhoneNumber = TextBoxPhoneNumber.Text;
            
        }
        
        private void ClickAddNewCustomer(object sender, RoutedEventArgs e)
        {
            
            this.DialogResult = true;
        }
    }
}
