using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Kieran

namespace SWAD_Team4_assignment_2
{
    public class User
    {
        private string username;
        private string password;
        private string id;
        private int phoneNumber;
        private string email;


        public User(string username, string password, string id, int phoneNumber,string email)
        {
            this.username = username;
            this.password = password;
            this.id = id;
            this.phoneNumber = phoneNumber;
            this.email = email;
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        public string Password  
        {
            get { return password; }
            set { password = value; }
        }
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public int PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
       
    }

}