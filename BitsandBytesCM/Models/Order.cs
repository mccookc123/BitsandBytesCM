using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitsandBytesCM.Models
{
    public class Order
    {
        //Come back and think about other neccessary variables
        [Key]
        public int OrderId { get; set; }

        [Key]
        public string MemberId { get; set; }

        public DateTime OrderDate { get; set; }
        public double OrderTotal { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

    }
}