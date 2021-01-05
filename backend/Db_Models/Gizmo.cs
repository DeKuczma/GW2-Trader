using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaseModels
{
    public class Gizmo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }

        public int GuildUpgradeId { get; set; }
        [Required]
        public List<int> VendorIds { get; set; }
    }
}
