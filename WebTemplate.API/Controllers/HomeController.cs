using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebTemplate.API.Mvc;
using WebTemplate.Application.Cars;
using WebTemplate.Application.Dtos.Users;
using WebTemplate.Application.Users;
using WebTemplate.Domain;
using WebTemplate.Domain.Users;

namespace WebTemplate.API.Controllers {
    /// <summary>
    /// This is a simple controller
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IUserAppService _userAppService;
        private readonly ICarAppService _carAppService;

        public HomeController(IUserAppService userAppService, ICarAppService carAppService)
        {
            _userAppService = userAppService;
            _carAppService = carAppService;
        }

        [Authorize()]
        [HttpGet]
        public async Task<ActionResult<UserDetailsWithIdentityUserDto>> GetUser(Guid id)
        {
            Log.Information(id.ToString());
            var user = await _userAppService.GetUserAsync(id);
            return user;
        }
        
        [HttpGet("getall")]
        [ProducesResponseType(Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
        [ProducesResponseType(Microsoft.AspNetCore.Http.StatusCodes.Status401Unauthorized)]
        [ApiConventionMethod(typeof(WebTemplateApiConventions), nameof(WebTemplateApiConventions.Get))]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
        {
            var users = await _userAppService.GetUsersAsync();
            return Ok(users);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<UserDto>> Create(CreateUpdateUserDto input)
        {
            var user = await _userAppService.CreateAsync(input);
            
            return user;
        }

        [HttpPost("CreateCar")]

        public async Task<ActionResult<Voiture>> CreateCar(string name)
        {
            return await _carAppService.CreateCar(name);
        }

        [HttpPut("UpdateCar")]

        public async Task<ActionResult<Voiture>> UpdateCar(Guid id,  string name)
        {
            return await _carAppService.UpdateCar(id,name);
        }

        [HttpDelete("DeleteCar")]
        public async Task<IActionResult> DeleteCar(Guid id)
        {
            await _carAppService.DeleteCar(id);
            return Ok();
        }

        [HttpDelete("HardDeleteCar")]
        public async Task<IActionResult> HardDeleteCar(Guid id)
        {
            await _carAppService.HardDeleteAsync(id);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("GetAllCars")]
        public async Task<ActionResult<IEnumerable<Voiture>>> GetAllCars()
        {
            return Ok(await _carAppService.GetAllCar());
        }



        [HttpPost]
        public async Task<ActionResult<UserDetails>> InsertUserDetails(CreateUpdateUserDetailsDto input)
        {
            return await  _userAppService.AddDetailsToUser(input);
        }


    }
}
