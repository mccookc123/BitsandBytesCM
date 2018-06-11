// ***********************************************************************
// Assembly         : BitsandBytesCM
// Author           : Calum
// Created          : 06-11-2018
//
// Last Modified By : Calum
// Last Modified On : 05-04-2018
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
    /// Class ProductFormViewModel.
    /// </summary>
    public class ProductFormViewModel
    {

        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        /// <value>The product.</value>
        public Product Product { get; set; }
        /// <summary>
        /// Gets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title
        {
            get
            {
                if (Product != null && Product.ProductID != 0)
                    return "Edit Product";

                return "New Product";
            }
        }

    }
}