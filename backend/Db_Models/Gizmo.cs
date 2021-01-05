using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Db_Models
{
    public class Gizmo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }

        public int GuildUpgradeId { get; set; }
        [Required]
        public IEnumerable<int> VendorIds { get; set; }
    }
}
