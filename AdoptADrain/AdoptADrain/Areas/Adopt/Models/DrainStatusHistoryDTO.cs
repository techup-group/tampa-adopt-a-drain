using System;
using System.Collections.Generic;

namespace AdoptADrain.Areas.Adopt.Models
{
    public partial class DrainStatusHistoryDTO
    {
        public int DrainStatusHistoryId { get; set; }
        public int? DrainStatusId { get; set; }
        public int DrainId { get; set; }

        public virtual DrainDTO Drain { get; set; }
        public virtual DrainStatusDTO DrainStatus { get; set; }
    }
}
