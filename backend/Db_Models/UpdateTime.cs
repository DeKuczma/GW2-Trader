using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaseModels
{
    public class UpdateTime
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime LastUpdate { get; set; }
    }
}
