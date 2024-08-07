using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SWAD_Team4_assignment_2
{
    public class PaymentMethod
    {
        private string type;
        private decimal balance;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public decimal Balance
        {
            get { return Balance; }
            set { Balance = value; }
        }

        public PaymentMethod(string type, decimal balance)
        {   
            this.type = type;
            this.balance = balance;
        }

        public virtual bool MakePayment(decimal totalAmount)
        {
            return true;
        }
    }
}
