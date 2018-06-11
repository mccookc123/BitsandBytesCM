// ***********************************************************************
// Assembly         : BitsandBytesCM
// Author           : Calum
// Created          : 06-11-2018
//
// Last Modified By : Calum
// Last Modified On : 05-26-2018
// ***********************************************************************
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitsandBytesCM.Models
{
    /// <summary>
    /// Class Product.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>The product identifier.</value>
        public int ProductID { get; set; }

        /// <summary>
        /// Gets or sets the product description.
        /// </summary>
        /// <value>The product description.</value>
        public string ProductDescription { get; set; }

        /// <summary>
        /// Gets or sets the product colour.
        /// </summary>
        /// <value>The product colour.</value>
        public string ProductColour { get; set; }

        /// <summary>
        /// Gets or sets the product price.
        /// </summary>
        /// <value>The product price.</value>
        public double ProductPrice { get; set; }

        /// <summary>
        /// Gets or sets the current stock.
        /// </summary>
        /// <value>The current stock.</value>
        public int CurrentStock { get; set; }

        /// <summary>
        /// Gets or sets the lowest stock limit.
        /// </summary>
        /// <value>The lowest stock limit.</value>
        public int lowestStockLimit { get; set; }

        /// <summary>
        /// Gets or sets the supplier.
        /// </summary>
        /// <value>The supplier.</value>
        public Supplier Supplier { get; set; }


        /// <summary>
        /// Gets or sets the order details.
        /// </summary>
        /// <value>The order details.</value>
        public List<OrderDetail> OrderDetails { get; set; }
    }
}