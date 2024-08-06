using SWAD_Team4_assignment_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAD_Assg2
{
    public class ICarAdmin : User
    {
        private string staffid;
        


        public ICarAdmin(string username, string password, string id, int phoneNumber, string email, string staffid) : base(username, password, id, phoneNumber, email)
        {
            this.staffid = staffid;

        }
        public string Staffid
        {
            get { return staffid; }
            set { staffid = value; }
        }

    }

}
