using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Kieran 
namespace SWAD_Team4_assignment_2
{
    public class Review
    {

        private string id;
        private int stars;
        private string description;
        private DateTime date;

        public Review(string id, int stars, string description, DateTime date)
        {
            this.id = id;
            this.stars = stars;
            this.description = description;
            this.date = date;

        }
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public int Stars
        {
            get { return stars; }
            set { stars = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

    }
}