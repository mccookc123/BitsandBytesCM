using BitsandBytesCM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BitsandBytesCM.ViewModels
{
    public class ProductFormViewModel
    {

        public Product Product { get; set; }
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