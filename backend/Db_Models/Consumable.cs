using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaseModels
{
    public class Consumable
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        public string Description { get; set; }
        public int DurationMs { get; set; }
        public string UnlockType { get; set; }
        public int ColorId { get; set; }
        public int RecipeId { get; set; }
        public List<int> ExtraRecipeIds { get; set; }
        public int GuildUpgradeIds { get; set; }
        public int ApplyCount { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public List<int> Skins { get; set; }
    }
}
