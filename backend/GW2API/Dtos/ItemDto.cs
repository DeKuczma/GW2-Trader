using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace GW2API.Dtos
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string ChatLink { get; set; }
        [Required]
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Rarity { get; set; }
        [Required]
        public int Level { get; set; }
        [Required]
        public int VendorValue { get; set; }
        [Required]
        public List<string> Flags { get; set; }
        [Required]
        public List<string> GameTypes { get; set; }
        [Required]
        public List<string> Restrictions { get; set; }
    }
}
