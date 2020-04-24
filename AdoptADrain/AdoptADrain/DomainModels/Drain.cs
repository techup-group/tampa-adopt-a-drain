using System;
using System.Collections.Generic;

namespace AdoptADrain.DomainModels
{
    public partial class Drain
    {
        public Drain()
        {
            DrainStatusHistory = new HashSet<DrainStatusHistory>();
        }
        public int DrainId { get; set; }
        public string Name { get; set; }
        public int? FlowDirectionId { get; set; }
        public int? DrainTypeId { get; set; }
        public int? RoadTypeId { get; set; }
        public bool IsAdopted { get; set; }
        public string CreateUser { get; set; }
        public DateTime? CreateDttm { get; set; }
        public string ChangeUser { get; set; }
        public DateTime? ChangeDttm { get; set; }
        public int? AdoptedUserId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public virtual DrainType DrainType { get; set; }
        public virtual FlowDirection FlowDirection { get; set; }
        public virtual RoadType RoadType { get; set; }
        public virtual ICollection<DrainStatusHistory> DrainStatusHistory { get; set; }

    }
}
