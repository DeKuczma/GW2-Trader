using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Db_Models
{
    public class Trinket
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        public int SuffixItemId { get; set; }
        public string SecondarySuffixItemId { get; set; }
        public IEnumerable<int> StatChoices { get; set; }
    }
}
