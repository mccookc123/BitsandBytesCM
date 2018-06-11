// ***********************************************************************
// Assembly         : BitsandBytesCM
// Author           : Calum
// Created          : 06-11-2018
//
// Last Modified By : Calum
// Last Modified On : 06-11-2018
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
    /// Class EditQuantityViewModel.
    /// </summary>
    public class EditQuantityViewModel
    {

        /// <summary>
        /// Gets or sets the order details.
        /// </summary>
        /// <value>The order details.</value>
        public OrderDetail OrderDetails { get; set; }

        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        /// <value>The product.</value>
        public Product Product { get; set; }
    }
}