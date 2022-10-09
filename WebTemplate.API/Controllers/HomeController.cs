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

        [HttpGet]
        public async Task<ActionResult<UserDto>> GetUser(string name)
        {
            var user = await _userAppService.GetUserAsync(name);
            return user;
        }

        [HttpGet("getall")]
        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var users = await _userAppService.GetUsersAsync();
            return users;
        }

        [HttpPost]
        public async Task<IActionResult> Create(string username, string name, string email)
        {
            //Using Log information with Serilog
            Log.Information(name);
            var voiture = await _voitureRepository.InsertAsync(new Voiture { Name = "test", Description = "teste" });
            await _userAppService.CreateAsync(new CreateUpdateUserDto{Username = username, Name = name, Email = email, VoitureId = voiture.Id});
            
            return NoContent();
        }


    }
}
