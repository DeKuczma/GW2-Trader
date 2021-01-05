using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Db_Models
{
    public class Listing
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Item")]
        public int ItemId { get; set; }
        [Required]
        public IEnumerable<int> BuyListing { get; set; }
        [Required]
        public IEnumerable<int> SellListing { get; set; }
    }
}
