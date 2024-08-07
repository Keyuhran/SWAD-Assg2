using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Kieran 
namespace SWAD_Team4_assignment_2
{
    public class Delivery
    {
        private string id;
        private DateTime date;
        private string address;


        public Delivery(string id, DateTime date, string address)
        {
            this.id = id;
            this.date = date;
            this.address = address;

        }
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

    }
}