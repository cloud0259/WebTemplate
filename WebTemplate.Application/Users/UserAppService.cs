using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTemplate.Application.Applications;
using WebTemplate.Application.Dtos.Users;
using WebTemplate.Core.Repositories;
using WebTemplate.Domain.Users;
using WebTemplate.Infrastructure.DependencyInjection;
using WebTemplate.Infrastructure.Identity.Models;
using WebTemplate.Infrastructure.Identity.Repositories;

namespace WebTemplate.Application.Users
{
    public class UserAppService :ApplicationService, IUserAppService
    {
        private readonly IIdentityUserRepository _userRepository;
        private readonly UserManager<ApplicationUser> _userManager; 
        public UserAppService(
            IIdentityUserRepository userRepository,
            UserManager<ApplicationUser> userManager)
        {
            _userRepository = userRepository;          
            _userManager = userManager;
        }

        public async Task<UserDto> CreateAsync(CreateUpdateUserDto input)
        {
            var user = Mapper.Map<ApplicationUser>(input);

            var result = await _userManager.CreateAsync(user, input.Password);
            if(result.Succeeded)
            {
                return Mapper.Map<UserDto>(result);
            }

            //await _userRepository.InsertAsync(user,input.Password);
            throw new Exception("Erreur lors de la création de l'utilisateur");
        }

        public async Task<UserDto> GetUserAsync(string email)
        {
            Logger.LogDebug(CurrentUser.UserId);
            Logger.LogInformation("Demande d'utilisateur");
            var user = await _userRepository.GetAsync(u => u.Email == email);
            Logger.LogInformation($"Reception de l'utilisateur {user.UserName}");
            return Mapper.Map<UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            
            return Mapper.Map<IEnumerable<UserDto>>(users);
        }
    }
}
