using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GW2API.Dtos
{
    public class CommandLogDto
    {
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
