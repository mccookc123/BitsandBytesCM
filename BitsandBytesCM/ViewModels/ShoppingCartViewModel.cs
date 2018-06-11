// ***********************************************************************
// Assembly         : BitsandBytesCM
// Author           : Calum
// Created          : 06-11-2018
//
// Last Modified By : Calum
// Last Modified On : 05-29-2018
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
    /// Class ShoppingCartViewModel.
    /// </summary>
    public class ShoppingCartViewModel
    {
        /// <summary>
        /// Gets or sets the cart items.
        /// </summary>
        /// <value>The cart items.</value>
        public List<Cart> CartItems { get; set; }

        /// <summary>
        /// Gets or sets the cart total.
        /// </summary>
        /// <value>The cart total.</value>
        public double CartTotal { get; set; }

    }
}