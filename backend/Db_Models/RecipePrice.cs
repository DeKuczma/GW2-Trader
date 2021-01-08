using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BaseModels
{
    public class RecipePrice
    {
        [Key]
        public int Id { get; set; }
        [Required, ForeignKey("ItemId")]
        public Item Item { get; set; }
        public int CreationPriceBuyNow { get; set; }
        public int CreationPriceBuyOrder { get; set; }
        [Required]
        public bool PossibleToBuy { get; set; }


    }
}
