using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaseModels
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
