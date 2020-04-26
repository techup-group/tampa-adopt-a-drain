using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoptADrain.Areas.Adopt.Models;
using AdoptADrain.DomainModels;
using AdoptADrain.Services;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public DrainController(ILogger<DrainController> logger, IMapper mapper, IDrainService drainService)
        {
            _logger = logger;
            _drainService = drainService;
            _mapper = mapper;
        }

        public IActionResult Adopt()
        {
            
            return View();
        }

        public IActionResult Abandon()
        {
            return View();
        }

        public async Task<IActionResult> FlowDirection()
        {
            List<FlowDirectionDTO> flowDirectionList = await _drainService.GetFlowDirectionAll();
            return View(flowDirectionList);
        }

        public async Task<IActionResult> CreateFlowDirection(FlowDirectionDTO flowDirection)
        {
            FlowDirection newFlowDirection = _mapper.Map<FlowDirection>(flowDirection);

            await _drainService.CreateFlowDirection(newFlowDirection);

            return Ok();
        }
    }
}