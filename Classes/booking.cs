using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    private string location;


    public Booking(string id, DateTime startDate, DateTime endDate, string status, bool confirmedStatus, string location)
    {
        this.id = id;
        this.startDateTime = startDate;
        this.endDateTime = endDate;
        this.status = status;
        this.confirmedStatus = confirmedStatus;
    }

    public string Id
    {
        get { return id; }
        set { id = value; }
    }

    public DateTime StartDateTime
    {
        get { return startDateTime; }
        set { startDateTime = value; }
    }
    public DateTime EndDateTime
    {
        get { return endDateTime; }
        set { endDateTime = value; }
    }
    public string Status
    {
        get { return status; }
        set { status = value; }
    }
    public bool ConfirmedStatus
    {
        get { return confirmedStatus; }
        set { confirmedStatus = value; }
    }
    public string Location
    {
        get { return location; }
        set { location = value; }
    }

}
}