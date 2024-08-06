using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Kieran 
namespace SWAD_Team4_assignment_2
{
    public class Listing
    {
        private string id;
        private int price;
        private string address;
        private bool availability;


        public Listing(string id, int price, string address, bool availability)
        {
            this.id = id;
            this.price = price;
            this.address = address;
            this.availability = availability;

        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public int Price
        {
            get { return price; }
            set { price = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public bool Availability
        {
            get { return availability; }
            set { availability = value; }
        }
    }
}