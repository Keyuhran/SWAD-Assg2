using System;
using System.Collections.Generic;

namespace SWAD_Assg2
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

        public DateTime GetStartDate()
        {
            return StartDate;
        }

        public void SetStartDate(DateTime startDate)
        {
            StartDate = startDate;
        }

        public DateTime GetEndDate()
        {
            return EndDate;
        }

        public void SetEndDate(DateTime endDate)
        {
            EndDate = endDate;
        }

        public List<DateTime> GetUnavailableDates()
        {
            return UnavailableDates;
        }

        public void SetUnavailableDates(List<DateTime> unavailableDates)
        {
            UnavailableDates = unavailableDates;
        }

        public void AddUnavailableDate(DateTime date)
        {
            if (!UnavailableDates.Contains(date))
            {
                UnavailableDates.Add(date);
            }
        }

        public void RemoveUnavailableDate(DateTime date)
        {
            if (UnavailableDates.Contains(date))
            {
                UnavailableDates.Remove(date);
            }
        }
    }
}
