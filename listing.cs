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
            get {return id; }
            set {id = value; }
        }
        public string Price;
        {
            get {return price; }
            set {price = value; }
        }
        public string Address
        {
            get {return address; }
            set {address = value; }
        }
        public string Availability
        {
            get {return availability; }
            set {availability = value; }
        }    }
}