using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GW2API.Dtos
{
    public class ExecuteCommandReadDto
    {
        [Required]
        public string Command { get; set; }
    }
}
