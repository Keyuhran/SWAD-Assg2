using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Kieran 
namespace SWAD_Team4_assignment_2
{
    public class ICarStation
    {
       
        private string id;
        private string address;


        public ICarStation(string id, string address)
        {
            this.id = id;
            this.address = address;

        }
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }


    }
}