using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BitsandBytesCM.Models
{
    public class Cart
    {

        [Key]
        public int Id { get; set; }
        [Key]
        public string CartId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public DateTime ? DateCreated { get; set; }

        
        public virtual Product Product { get; set; }

    }
}