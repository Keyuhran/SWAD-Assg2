using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_Team4_assignment_2
{
    public class AvailabilitySchedule
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<DateTime> UnavailableDates { get; set; }

        public AvailabilitySchedule(DateTime startDate, DateTime endDate, List<DateTime> unavailableDates)
        {
            StartDate = startDate;
            EndDate = endDate;
            UnavailableDates = unavailableDates;
        }
    }
}
