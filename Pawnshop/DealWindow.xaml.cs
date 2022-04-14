using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Pawnshop
{
    
    public class Category
    {
        private string category;

        public int Id { get; set; }

        public string NameCategory
        {
            get { return category; }
            set
            {
                category = value;
                
            }
        }



        
    }
    public class Producer
    {
        private string producer;

        public int Id { get; set; }

        public string NameProducer
        {
            get { return producer; }
            set
            {
                producer = value;
                
            }
        }
        
    }
    public class Model
    {
        private string model;

        public int Id { get; set; }

        public string NameModel
        {
            get { return model; }
            set
            {
                model = value;
                
            }
        }

    }

    public partial class DealWindow : Window
    {
        //public string[] namesOfProductsCategory { get; set; }
        //public string[] namesOfProducer { get; set; }
        //public string[] namesOfModel { get; set; }

        ApplicationContext db;
        public DealWindow()
        {
            InitializeComponent();


            db = new ApplicationContext();
            db.Categories.Load();
            ComboBoxCategory.ItemsSource = db.Categories.Local.ToBindingList();
            ComboBoxCategory.DisplayMemberPath = "NameCategory";
            db.Producers.Load();
            ComboBoxProducer.ItemsSource = db.Producers.Local.ToBindingList();
            ComboBoxProducer.DisplayMemberPath = "NameProducer";
            db.Models.Load();
            ComboBoxModel.ItemsSource = db.Models.Local.ToBindingList();
            ComboBoxModel.DisplayMemberPath = "NameModel";
            db.Customers.Load();
            ComboBoxCustomer.ItemsSource = db.Customers.Local.ToBindingList();
            ComboBoxCustomer.DisplayMemberPath = "FirstName";

            DataContext = this;
            //namesOfProductsCategory = new string[] { "Часы", "Кольца", "Серьги" };
            //namesOfProducer = new string[] { "Rolex", "Casio", "GIOGIO Armani", "Cartier", "SOKOLOV" };
            //namesOfModel = new string[] { "5W-40", "5W-30", "OW-20", "Air King", "Explorer", "Золото 585", "Серебро 925" };
        }
        private void ButtonClickAddNewCustomer(object sender, RoutedEventArgs e)
        {
            NewCustomer newCustomer = new NewCustomer(new Customer());
            //newCustomer.Show();
            if (newCustomer.ShowDialog() == true)
            {
                //Customer customer = newCustomer.Customer;
                db.Customers.Add(newCustomer.Customer);
                db.SaveChanges();
                MessageBox.Show("OK");
            }
        }

    }
}
