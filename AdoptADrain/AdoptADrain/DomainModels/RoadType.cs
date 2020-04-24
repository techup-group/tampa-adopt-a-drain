using System;
using System.Collections.Generic;

namespace AdoptADrain.DomainModels
{
    public partial class RoadType
    {
        public RoadType()
        {
            Drain = new HashSet<Drain>();
        }

        public int RoadTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Drain> Drain { get; set; }
    }
}
