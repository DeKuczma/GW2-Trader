using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Db_Models
{
    [ComplexType]
    public class UpgradeItem
    {
        public string Upgrade { get; set; }
        public int ItemId { get; set; }
    }
}
