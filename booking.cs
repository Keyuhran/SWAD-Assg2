// Kieran 
namespace SWAD_Team4_assignment_2
{
    public class Booking
    {
        public string Id {get; set;}
        public datetime StartDate {get; set;}
        public datetime EndDate {get; set;}
        public string Status {get; set;}
        public bool ConfirmedStatus {get; set;}
        


        public Booking() {}

        public Booking(string id, datetime startDate, datetime endDate, string status, bool confirmedStatus)
        {
            Id = id;
            startDate = StartDate;
            EndDate = endDate;
            Status = status;
            ConfirmedStatus = confirmedStatus;
        
        }

    }
}