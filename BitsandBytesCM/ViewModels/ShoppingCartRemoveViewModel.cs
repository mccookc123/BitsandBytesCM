// ***********************************************************************
// Assembly         : BitsandBytesCM
// Author           : Calum
// Created          : 06-11-2018
//
// Last Modified By : Calum
// Last Modified On : 05-15-2018
// ***********************************************************************
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitsandBytesCM.ViewModels
{
    /// <summary>
    /// Class ShoppingCartRemoveViewModel.
    /// </summary>
    public class ShoppingCartRemoveViewModel
    {
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; set; }
        /// <summary>
        /// Gets or sets the cart total.
        /// </summary>
        /// <value>The cart total.</value>
        public double CartTotal { get; set; }
        /// <summary>
        /// Gets or sets the cart count.
        /// </summary>
        /// <value>The cart count.</value>
        public int CartCount { get; set; }
        /// <summary>
        /// Gets or sets the item count.
        /// </summary>
        /// <value>The item count.</value>
        public int ItemCount { get; set; }
        /// <summary>
        /// Gets or sets the delete identifier.
        /// </summary>
        /// <value>The delete identifier.</value>
        public int DeleteId { get; set; }
    }
}