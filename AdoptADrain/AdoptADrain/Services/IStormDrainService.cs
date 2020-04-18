using AdoptADrain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdoptADrain.Services
{
    public interface IStormDrainService
    {
        Task SaveStormDrain(StormDrain drain);
    }
}
