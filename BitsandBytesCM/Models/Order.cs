// ***********************************************************************
// Assembly         : BitsandBytesCM
// Author           : Calum
// Created          : 06-11-2018
//
// Last Modified By : Calum
// Last Modified On : 06-06-2018
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
    /// Class Order.
    /// </summary>
    public class Order
    {
        //Come back and think about other neccessary variables
        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>The order identifier.</value>
        [Key]
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the member identifier.
        /// </summary>
        /// <value>The member identifier.</value>
        [Key]
        public string MemberId { get; set; }

        /// <summary>
        /// Gets or sets the order date.
        /// </summary>
        /// <value>The order date.</value>
        public DateTime OrderDate { get; set; }
        /// <summary>
        /// Gets or sets the order total.
        /// </summary>
        /// <value>The order total.</value>
        public double OrderTotal { get; set; }
        /// <summary>
        /// Gets or sets the order details.
        /// </summary>
        /// <value>The order details.</value>
        public List<OrderDetail> OrderDetails { get; set; }

    }
}