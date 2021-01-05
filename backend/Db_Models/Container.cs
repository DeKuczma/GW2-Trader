using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaseModels
{
    public class Container
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
    }
}
