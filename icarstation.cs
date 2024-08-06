// Kieran 
namespace SWAD_Team4_assignment_2
{
    public class ICarStation
    {
        public string Id {get; set;}
        public string Address {get; set;}

        public ICarStation() {}

        public ICarStation(string id, string address)
        {
            Id = id;
            Address = address;
          
        }

    }
}