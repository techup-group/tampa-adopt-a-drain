using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdoptADrain.Areas.Adopt.Models
{
    public class DrainSearchOptions
    {
        public int FlowDirectionId { get; set; }
        public int DrainTypeId { get; set; }
        public int RoadTypeId { get; set; }
        public string AdoptedUserId { get; set; }
        public bool excludeAdopted { get; set; }
    }
}
