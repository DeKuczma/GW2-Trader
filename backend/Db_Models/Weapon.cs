using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaseModels
{
    public class Weapon
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string DamageType { get; set; }
        [Required]
        public int MinPower { get; set; }
        [Required]
        public int MaxPower { get; set; }
        [Required]
        public int Defense { get; set; }
        public List<int> StatChoices { get; set; }
    }
}
