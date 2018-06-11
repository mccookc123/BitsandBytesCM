using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitsandBytesCM.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        public string ProductDescription { get; set; }

        public string ProductColour { get; set; }

        public double ProductPrice { get; set; }

        public int CurrentStock { get; set; }

        public int lowestStockLimit { get; set; }

        public Supplier Supplier { get; set; }


        public List<OrderDetail> OrderDetails { get; set; }
    }
}