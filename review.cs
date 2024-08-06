// Kieran 
namespace SWAD_Team4_assignment_2
{
    public class Review
    {
        public string Id {get; set;}
        public int Stars {get; set;}
        public string Description {get; set;}
       public DateTime Date { get; set; }

        
        public Review() {}

        public Review(string id, int stars, string description, datetime date)
        {
            Id = id;
            Stars = stars;
            Description = description;
            Date = date;
        
        }

    }
}