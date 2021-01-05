using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaseModels
{
    public class UpgradeComponent
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public List<string> Flags { get; set; }
        public List<string> InfusionUpgradeFlags { get; set; }
        public string Suffix { get; set; }
        public List<string> Bonuses { get; set; }
    }
}
