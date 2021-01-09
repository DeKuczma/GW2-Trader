using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BaseModels
{
    public class Listing
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ItemId { get; set; }
        public Item Item { get; set; }
        [Required]
        public List<TPListing> Buys { get; set; }
        [Required]
        public List<TPListing> Sells { get; set; }
    }
}
