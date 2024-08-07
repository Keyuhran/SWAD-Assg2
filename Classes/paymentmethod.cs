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
        private string id;
        private string type;

        public PaymentMethod(string id, string type)
        {
            this.id = id;
            this.type = type;
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }


    }
}
