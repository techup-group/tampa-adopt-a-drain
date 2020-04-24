using System;
using System.Collections.Generic;

namespace AdoptADrain.DomainModels
{
    public partial class DrainStatus
    {
        public DrainStatus()
        {
            DrainStatusHistory = new HashSet<DrainStatusHistory>();
        }

        public int DrainStatusId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<DrainStatusHistory> DrainStatusHistory { get; set; }
    }
}
