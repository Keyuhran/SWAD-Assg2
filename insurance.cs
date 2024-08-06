using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Kieran 
namespace SWAD_Team4_assignment_2
{
    public class Insurance
    {
        private string id;
        private DateTime expiryDate;
        private int coverageLimit;
        private string name;
        private string policyStatus;



        public Insurance(string id, DateTime expiryDate, int coverageLimit, string name, string policyStatus)
        {
            this.id = id;
            this.expiryDate = expiryDate;
            this.coverageLimit = coverageLimit;
            this.name = name;
            this.policyStatus = policyStatus;

        }
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public string ExpiryDate;
        {
            get { return expiryDate; }
            set { expiryDate = value; }
        }
        public string CoverageLimit
        {
            get { return coverageLimit; }
            set { coverageLimit = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string PolicyStatus
        {
            get { return policyStatus; }
            set { policyStatus = value; }
        }

    }
}