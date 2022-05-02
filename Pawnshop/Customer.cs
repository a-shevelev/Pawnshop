using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Pawnshop
{
    public class Customer
    {
        private string secondName;
        private string firstName;
        private string patronymic;
        private string passport;
        private string phoneNumber;
        public Customer() { }
        public Customer(string secondName, string firstName, string patronymic, string passport, string phoneNumber)
        {
            this.secondName = secondName;
            this.firstName = firstName;
            this.patronymic = patronymic;
            this.passport = passport;
            this.phoneNumber = phoneNumber;
        }
        public int Id { get; set; }

        public string SecondName
        {
            get { return secondName; }
            set
            {
                secondName = value;
               
            }
        }
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                
            }
        }
        public string Patronymic
        {
            get { return patronymic; }
            set
            {
                patronymic = value;
                
            }
        }
        public string Passport
        {
            get { return passport; }
            set
            {
                passport = value;
                
            }
        }
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                phoneNumber = value;
                
            }
        }
        


      
    }
}
