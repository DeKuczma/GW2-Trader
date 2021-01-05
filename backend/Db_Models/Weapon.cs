using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Db_Models
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
        public IEnumerable<int> StatChoices { get; set; }
    }
}
