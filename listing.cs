// Kieran 
namespace SWAD_Team4_assignment_2
{
    public class Listing
    {
        public string Id {get; set;}
        public int Price {get; set;}
        public string Address {get; set;}
        public bool Availability {get; set;}
        


        public Listing() {}

        public Listing(string id, int price, string address, bool availability)
        {
            Id = id;
            Price = price;
            Address = address;
            Availability = availability;
        
        }

    }
}