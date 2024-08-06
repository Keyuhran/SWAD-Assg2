// Kieran 
namespace SWAD_Team4_assignment_2
{
    public class Delivery
    {
        public string Id {get; set;}
        public datetime Date {get; set;}
        public string address {get; set;}

        
        public Delivery() {}

        public Delivery(string id, datetime date, string address)
        {
            Id = id;
            Date = date;
            Address = address;
        
        }

    }
}