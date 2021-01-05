using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Db_Models
{
    public class UpgradeComponent
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public IEnumerable<string> Flags { get; set; }
        public IEnumerable<string> InfusionUpgradeFlags { get; set; }
        public string Suffix { get; set; }
        public IEnumerable<string> Bnuses { get; set; }
    }
}
