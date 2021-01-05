using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Db_Models
{
    public class TPListing
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UnitPrice { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
