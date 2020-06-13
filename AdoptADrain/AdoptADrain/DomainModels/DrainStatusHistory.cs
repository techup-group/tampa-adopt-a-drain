using System;
using System.Collections.Generic;

namespace AdoptADrain.DomainModels
{
    public partial class DrainStatusHistory
    {
        public int DrainStatusHistoryId { get; set; }
        public int DrainStatusId { get; set; }
        public string StatusChangeUser { get; set; }
        public DateTime? StatusCreateDttm { get; set; }
        public int DrainId { get; set; }

        public virtual Drain Drain { get; set; }
        public virtual DrainStatus DrainStatus { get; set; }
    }
}
