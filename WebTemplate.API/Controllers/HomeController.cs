using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebTemplate.Domain.Users;
using WebTemplate.Core.Repositories;
using WebTemplate.Domain;
using WebTemplate.Application.Users;
using WebTemplate.Application.Dtos.Users;
using Microsoft.AspNetCore.Authorization;
using WebTemplate.API.Mvc;
using WebTemplate.Infrastructure.Identity.Models;

namespace WebTemplate.API.Controllers
{
    /// <summary>
    /// This is a simple controller
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly IUserAppService _userAppService;
        private readonly IRepository<Voiture, Guid> _voitureRepository;

        public HomeController(IUserAppService userAppService, IRepository<Voiture, Guid> voitureRepository)
        {
            _userAppService = userAppService;
            _voitureRepository = voitureRepository;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetUser(string name)
        {
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
            //Using Log information with Serilog
            Log.Information(input.Email);
            await _userAppService.CreateAsync(input);
            
            return NoContent();
        }


    }
}
