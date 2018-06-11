using BitsandBytesCM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitsandBytesCM.ViewModels
{
    public class EditQuantityViewModel
    {

        public OrderDetail OrderDetails { get; set; }

        public Product Product { get; set; }
    }
}