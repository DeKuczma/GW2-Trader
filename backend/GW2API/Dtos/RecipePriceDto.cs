using BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GW2API.Dtos
{
    public class RecipePriceDto
    {
        public int ItemId { get; set; }
        public int CreationPriceBuyNow { get; set; }
        public int CreationPriceBuyOrder { get; set; }
    }
}
