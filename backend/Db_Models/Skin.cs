using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaseModels
{
    public class Skin
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public List<string> Flags { get; set; }
        [Required]
        public List<string> Restrictions { get; set; }
        [Required]
        public string Icon { get; set; }
        [Required]
        public string Rarity { get; set; }
        public string Description { get; set; }
    }
}
