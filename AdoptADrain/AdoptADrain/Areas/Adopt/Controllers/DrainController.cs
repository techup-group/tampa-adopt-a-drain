using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoptADrain.Areas.Adopt.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdoptADrain.Areas.Adopt.Controllers
{
 
    [Authorize]
    public class DrainController : Controller
    {
        public IActionResult Adopt()
        {
            return View();
        }

        public IActionResult Abandon(StormDrain drain)
        {
            return View();
        }
    }
}