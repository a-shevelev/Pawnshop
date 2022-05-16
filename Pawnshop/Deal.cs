using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pawnshop
{
    class Deal
    {
        public string CustomerInfo { get; set; }
        public string Product { get; set; }
       
        public double Price {get;set;}
        public string Year { get; set; }
        public string DateOfDeal { get; set; }
        public string DateOfReturn { get; set; }
        
        public double InterestRate { get; set; }
        public double Comission { get; set; }
        public double SumOfRefund { get; set; }
    }
}
