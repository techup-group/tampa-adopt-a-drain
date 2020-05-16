using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AdoptADrain.Models;
using AdoptADrain.Services;
using Microsoft.AspNetCore.Authorization;
using AdoptADrain.Areas.Manage.Models;

namespace AdoptADrain.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDrainService _drainService;

        public HomeController(ILogger<HomeController> logger, IDrainService drainService)
        {
            _logger = logger;
            _drainService = drainService;
        }

        public async Task<IActionResult> Index()
        {
            List<DrainDTO> drainList = await _drainService.GetDrainAll();
            return View(new HomeViewModel { Drains = drainList });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
