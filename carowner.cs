using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Kieran

namespace SWAD_Team4_assignment_2
{

    class CarOwner : User
    {
        private double earnings;

        public CarOwner(string username, string password, string id, int phoneNumber, string email, double earnings) : base(username, password, id, phoneNumber, email)
        {
            this.earnings = earnings;
            this.Cars = new List<Car>();

        }
        public double Earnings
        {
            get { return earnings; }
            set { earnings = value; }
        }

        public List<Car> Cars { get; set; }
    }

    
}