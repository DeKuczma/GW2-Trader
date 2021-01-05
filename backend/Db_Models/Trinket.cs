using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaseModels
{
    public class Trinket
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        public int SuffixItemId { get; set; }
        public string SecondarySuffixItemId { get; set; }
        public List<int> StatChoices { get; set; }
    }
}
