using System;
using System.Collections.Generic;

namespace AdoptADrain.DomainModels
{
    public partial class DrainType
    {
        public DrainType()
        {
            Drain = new HashSet<Drain>();
        }

        public int DrainTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Drain> Drain { get; set; }
    }
}
