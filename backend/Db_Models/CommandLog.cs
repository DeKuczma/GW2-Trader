using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaseModels
{
    public class CommandLog
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime LastUpdate { get; set; }
        [Required]
        public int Deleted { get; set; }
        [Required]
        public int Inserted { get; set; }
        [Required]
        public string CommandExecuted { get; set; }

    }
}
