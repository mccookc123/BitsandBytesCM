using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitsandBytesCM.Models
{
    public class Member:User
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int HouseNumber { get; set; }
        public string Street { get; set; }
        public string Town { get; set; }
        public string Postcode { get; set; }
        public int TelephNo { get; set; }

    }
}