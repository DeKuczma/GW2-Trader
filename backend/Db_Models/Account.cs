using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaseModels
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string APIKey { get; set; }
    }
}
