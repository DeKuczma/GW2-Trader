using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GW2API.Models
{
    public class ExecuteCommandResult
    {
        public int Deleted { get; set; }
        public int Updateed { get; set; }
        public DateTime ExecutionTime { get; set; }
    }
}
