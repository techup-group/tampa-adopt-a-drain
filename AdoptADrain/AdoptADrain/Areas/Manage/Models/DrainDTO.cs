using AdoptADrain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdoptADrain.Areas.Manage.Models
{
    public class DrainDTO
    {
        public int DrainId { get; set; }
        public string Name { get; set; }
        public int? FlowDirectionId { get; set; }
        public int? DrainTypeId { get; set; }
        public int? RoadTypeId { get; set; }
        public bool IsAdopted { get; set; }
        public string AdoptedUserId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public virtual DrainTypeDTO DrainType { get; set; }
        public virtual FlowDirectionDTO FlowDirection { get; set; }
        public virtual RoadTypeDTO RoadType { get; set; }
        public virtual List<DrainStatusHistoryDTO> DrainStatusHistory { get; set; }
    }
}
