// ***********************************************************************
// Assembly         : BitsandBytesCM
// Author           : Calum
// Created          : 06-11-2018
//
// Last Modified By : Calum
// Last Modified On : 06-08-2018
// ***********************************************************************
// <summary></summary>
// ***********************************************************************
using BitsandBytesCM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitsandBytesCM.ViewModels
{
    /// <summary>
    /// Class OrderDetailsViewModel.
    /// </summary>
    public class OrderDetailsViewModel
    {

        /// <summary>
        /// Gets or sets the order details.
        /// </summary>
        /// <value>The order details.</value>
        public List<OrderDetail> OrderDetails { get; set; }

        //public List<string> ProductDetails { get; set; }

    }
}