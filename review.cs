// Kieran 
namespace SWAD_Team4_assignment_2
{
    public class Review
    {

       private string id;
       private int stars;
       private string description;
       private DateTime date;

        public Review(string id, int stars, string description, datetime date)
        {
           this.id = id;
           this.stars = stars;
           this.description = description;
           this.date = date;
        
        }
         public string Id
        {
            get {return id; }
            set {id = value; }
        }
         public string Stars
        {
            get {return stars; }
            set {stars = value; }
        }
         public string Description
        {
            get {return description; }
            set {description = value; }
        }
         public string Date
        {
            get {return date; }
            set {date = value; }
        }

    }
}