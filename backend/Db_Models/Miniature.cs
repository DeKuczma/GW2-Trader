using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Db_Models
{
    public class Miniature
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int MinipetId { get; set; }
    }
}
