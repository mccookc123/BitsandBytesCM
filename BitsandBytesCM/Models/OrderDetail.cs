using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitsandBytesCM.Models
{
    public class OrderDetail
    {

        [Key]
        public int OrderDetailId { get; set; }

        [Key]
        public int OrderId { get; set; }

        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }


    }
}