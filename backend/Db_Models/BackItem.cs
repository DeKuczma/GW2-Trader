using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BaseModels
{
    public class BackItem
    {
        [Key]
        public int Id { get; set; }
        public List<int> StatChoices { get; set; }
    }
}
