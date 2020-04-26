using AdoptADrain.Areas.Adopt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdoptADrain.Areas.Adopt.ViewModels
{
    public class UserAdoptedDrainsVM
    {
        public List<DrainDTO> AdoptedDrains { get; set; }
        public List<DrainDTO> AvailableDrains { get; set; }
    }
}
