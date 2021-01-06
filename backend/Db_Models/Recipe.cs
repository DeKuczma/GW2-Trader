using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BaseModels
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public int OutputItemId { get; set; }
        public Item OutputItem { get; set; }
        [Required]
        public int OutputItemCount { get; set; }
        [Required]
        public int TimeToCraftMs { get; set; }
        [Required]
        public List<string> Disciplines { get; set; }
        [Required]
        public int MinRating { get; set; }
        public List<string> Flags { get; set; }
        [Required]
        public List<Ingredient> Ingredients { get; set; }
        public List<Ingredient> GuildIngredients { get; set; }
        public int OutputUpgradeId { get; set; }
        [Required]
        public string ChatLink { get; set; }
    }
}
