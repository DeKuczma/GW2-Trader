﻿using System;
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
        [Required, ForeignKey("ItemId")]
        public Item Item { get; set; }
        [Required]
        public List<TPListing> BuyListing { get; set; }
        [Required]
        public List<TPListing> SellListing { get; set; }
    }
}
