using AdoptADrain.Areas.Manage.Models;
using AdoptADrain.DomainModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdoptADrain.MappingProfiles
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<DrainStatus, DrainStatusDTO>().ReverseMap();
            CreateMap<RoadType, RoadTypeDTO>().ReverseMap();
            CreateMap<FlowDirection, FlowDirectionDTO>().ReverseMap();
            CreateMap<DrainStatus, DrainStatusDTO>().ReverseMap();
            CreateMap<Drain, DrainDTO>().ReverseMap();
            CreateMap<DrainType, DrainTypeDTO>().ReverseMap();
        }
    }
}
