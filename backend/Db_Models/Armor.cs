using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Db_Models
{
    public class Armor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string WeightClass { get; set; }
        [Required]
        public int Defense { get; set; }
        public IEnumerable<int> StatChoice { get; set; }
    }
}
