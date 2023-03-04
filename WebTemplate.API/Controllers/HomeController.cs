using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebTemplate.API.Mvc;
using WebTemplate.Application.Dtos.Users;
using WebTemplate.Application.Users;

namespace WebTemplate.API.Controllers {
    /// <summary>
    /// This is a simple controller
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IUserAppService _userAppService;

        public HomeController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [Authorize()]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetUser(string name)
        {
            Log.Information(name);
            var user = await _userAppService.GetUserAsync(name);
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
        public async Task<IActionResult> Create(CreateUpdateUserDto input)
        {
            await _userAppService.CreateAsync(input);
            
            return NoContent();
        }


    }
}
