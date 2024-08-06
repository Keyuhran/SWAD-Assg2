// Kieran 
namespace SWAD_Team4_assignment_2
{
    public class Insurance
    {
        public string Id {get; set;}
        public datetime ExpiryDate {get; set;}
        public int CoverageLimit {get; set;}
        public string Name {get; set;}
        public string PolicyStatus {get; set;}
      
        


        public Insurance() {}

        public Insurance(string id, datetime expiryDate, int coverageLimit, string name, string policyStatus)
        {
            Id = id;
            ExpiryDate = expiryDate;
            CoverageLimit = coverageLimit;
            Name = name;
            PolicyStatus = policyStatus;
        
        }

    }
}