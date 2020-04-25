using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoptADrain.Areas.Adopt.Models;
using AdoptADrain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AdoptADrain.Areas.Adopt.Controllers
{
 
    [Authorize]
    public class DrainController : Controller
    {
        private readonly IDrainService _drainService;
        private readonly ILogger<DrainController> _logger;

        public DrainController(ILogger<DrainController> logger, IDrainService drainService)
        {
            _logger = logger
            _drainService = drainService;
        }

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