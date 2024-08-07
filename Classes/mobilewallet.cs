using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_Team4_assignment_2
{
    public class MobileWallet:PaymentMethod
    {
        private string name;
        private string transactionId;

        public MobileWallet(string id, string type, string name, string transactionId) : base(id,type)
        {
            this.name = name;
            this.transactionId = transactionId;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string TranscationId
        {
            get { return transactionId; }
            set { transactionId = value; }
        }
    }
}
