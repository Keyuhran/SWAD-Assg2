using SWAD_Team4_assignment_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_Team4_assignment_2
{
    public class CarRenter : User
    {
        private int monthlyFee;
        private DateTime dob;
        private bool isPrime;
        private string licenseid;
        private bool isVerified;
        

        public CarRenter(string username, string password, string id, int phoneNumber, string email, int monthlyFee, DateTime dob, bool isPrime, string licenseid, bool isVerified ) : base(username, password, id, phoneNumber, email)
        {
            this.monthlyFee = monthlyFee;
            this.dob = dob;
            this.isPrime = isPrime;
            this.licenseid = licenseid;
            this.isVerified = isVerified;
            this.Bookings = new List<Booking>();

        }
        public int MonthlyFee
        {
            get { return monthlyFee; }
            set { monthlyFee = value; }
        }
        public DateTime Dob
        {
            get { return dob; }
            set { dob = value; }
        }
        public bool IsPrime
        {
            get { return isPrime; }
            set { isPrime = value; }
        }
        public string Licenseid
        {
            get { return licenseid; }
            set { licenseid = value; }
        }
        public bool IsVerified
        {
            get { return isVerified; }
            set { isVerified = value; }
        }



        public List<Booking> Bookings { get; set; }


    }

}
