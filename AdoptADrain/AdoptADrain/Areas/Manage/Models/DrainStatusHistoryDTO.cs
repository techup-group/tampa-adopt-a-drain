using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AdoptADrain.Areas.Manage.Models
{
    public partial class DrainStatusHistoryDTO
    {
        public int DrainStatusHistoryId { get; set; }
        public int DrainStatusId { get; set; }
        public int DrainId { get; set; }
        public DateTime StatusCreateDttm { get; set; }

        //public DrainDTO Drain { get; set; }
        [JsonIgnore]
        public DrainStatusDTO DrainStatus { get; set; }
    }
}
