using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_Team4_assignment_2
{
    public class MobileWallet : PaymentMethod
    {
        private string name;
        private string phoneNo;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string PhoneNo
        {
            get { return phoneNo; }
            set { phoneNo = value; }
        }

        public MobileWallet(string type, decimal balance, string name, string phoneNo) : base(type, balance)
        {
            this.name = name;
            this.phoneNo = phoneNo;
        }

        public override bool MakePayment(decimal totalAmount)
        {
            if (totalAmount <= Balance)
            {
                Balance -= totalAmount;
                return true;
            }
            else
            {
                Console.WriteLine("Payment failure. Insufficient funds. Try Again.");
                return false;
            }
        }
    }
}
