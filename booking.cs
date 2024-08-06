// Kieran 
namespace SWAD_Team4_assignment_2
{
    public class Booking
    {
        private string id;
        private DateTime startDateTime;
        private DateTime endDateTime;
        private string status;
        private bool confirmedStatus;
        

        public Booking(string id, datetime startDate, datetime endDate, string status, bool confirmedStatus)
        {
            this.id = id;
            this.startDateTime = startDate;
            this.endDateTime = endDate;
            this.status = status;
            this.confirmedStatus = confirmedStatus;
        }

        public string Id
        {
            get {return id; }
            set {id = value; }
        }

        public DateTime StartDateTime
        {
            get { return startDateTime; }
            set { startDateTime = value; }
        }
        public DateTime EndDateTime
        {
            get { return endDateTime; }
            set { endDateTime = value;}
        }
        public string Status
        {
            get { return status}
            set {status = value;}
        }
        public bool ConfirmedStatus
        {
            get { return confirmedStatus; }
            set { confirmedStatus = value; }
        }


    }
}