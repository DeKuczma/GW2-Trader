using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GW2API.Dtos
{
    public class ExecuteCommandResultDto
    {
        public int Deleted { get; set; }
        public int Inserted { get; set; }
        public DateTime ExecutionTime { get; set; }
    }
}
