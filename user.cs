using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Daryl

namespace SWAD_Team4_assignment_2
{
    class User
    {
        private string name;
        private string email;
        private string phoneNumber;
        private string dob;
        private string licenseId;


        public User(string name, string email, string phoneNumber, string dob, string licenseId)
        {
            this.name = name;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.dob = dob;
            this.licenseId = licenseId;
        }

    }
 }