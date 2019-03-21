using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Race_boat_app.Models
{
    public class User
    {
        
        public string Id;


        public string FirstName { get; set; }


        public string LastName { get; set; }


        public string DOB { get; set; }


        public string Points { get; set; }


        public string Posistion { get; set; }
        //private Boat boat;


        public string Address { get; set; }


        public string PostCode { get; set; }


        public string City { get; set; }


        public string Email { get; set; }


        public string Password { get; set; }


        public string PhoneNumber { get; set; }

        public string MobilePhoneNumber { get; set; }

        public string Team { get; set; }

        
    }
}
