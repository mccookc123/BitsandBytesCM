﻿using BitsandBytesCM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace BitsandBytesCM.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems { get; set; }

        public double CartTotal { get; set; }

    }
}