using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdoptADrain.Areas.Manage.Models;
using AdoptADrain.Areas.Manage.ViewModels;
using AdoptADrain.DomainModels;
using AdoptADrain.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AdoptADrain.Areas.Manage.Controllers
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

        public async Task<IActionResult> Adopted()
        {
            //Get drains for user
            string userObjectId = User.Claims.FirstOrDefault(x => x.Type == "http://schemas.microsoft.com/identity/claims/objectidentifier")?.Value;

            //User Drains
            List<DrainDTO> userDrains = await _drainService.GetDrainAll(new DrainSearchOptions { AdoptedUserId = userObjectId });

            //Available Drains
            List<DrainDTO> availableDrains = await _drainService.GetDrainAll(new DrainSearchOptions { excludeAdopted = true });

            return View(new UserAdoptedDrainsVM { AdoptedDrains = userDrains, AvailableDrains = availableDrains });
        }

        public async Task<IActionResult> Adopt()
        {
            return View();
        }

        public async Task<IActionResult> Register()
        {
            return View();
        }

        public IActionResult Abandon()
        {
            return View();
        }

        #region HttpMethods
        [HttpPost]
        public async Task<IActionResult> CreateDrain(DrainDTO registerDrain)
        {
            try
            {
                if(String.IsNullOrEmpty(registerDrain.Latitude) || String.IsNullOrEmpty(registerDrain.Longitude))
                {
                    return BadRequest("Invalid Coordinate Parameters");
                }
                else
                {
                    Drain drain = _mapper.Map<Drain>(registerDrain);
                    int drainId = await _drainService.CreateDrain(drain);
                    return Ok(drainId);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AssignDrainToUser(int drainId)
        {
            try
            {
                if(drainId < 1)
                {
                    return BadRequest("Invalid Drain Parameter");
                }
                else
                {
                    Drain drain = await _drainService.GetDrain(drainId);
                    drain.AdoptedUserId = User.Claims.FirstOrDefault(x => x.Type == "http://schemas.microsoft.com/identity/claims/objectidentifier")?.Value;
                    drain.IsAdopted = true;
                    int updatedDrainId = await _drainService.UpdateDrain(drain);
                }
               
                return Ok(drainId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion
    }
}