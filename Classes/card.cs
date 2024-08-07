using SWAD_Assg2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_Team4_assignment_2
{
    public class Card : PaymentMethod
    {
        private string cardNo;
        private DateTime expiryDate;
        private string holderName;

        public string CardNo
        {
            get { return cardNo; }
            set { cardNo = value; }
        }

        public DateTime ExpiryDate
        {
            get { return expiryDate; }
            set { expiryDate = value; }
        }

        public string HolderName
        {
            get { return holderName; }
            set { holderName = value; }
        }

        public Card( string type, decimal balance, string cardNo, DateTime expiryDate, string holderName) : base(type, balance)
        {
            this.cardNo = cardNo;
            this.expiryDate = expiryDate;
            this.holderName = holderName;
        }
    }
}