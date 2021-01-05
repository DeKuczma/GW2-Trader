using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Db_Models
{
    public class BackItem
    {
        [Key]
        public int Id { get; set; }
        public IEnumerable<int> StatChoices { get; set; }
    }
}
