using AdoptADrain.DomainModels;
using System;
using System.Collections.Generic;

namespace AdoptADrain.Areas.Manage.Models
{
    public partial class DrainStatusDTO
    {

        public int DrainStatusId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<DrainStatusHistoryDTO> DrainStatusHistory { get; set; }
    }
}
