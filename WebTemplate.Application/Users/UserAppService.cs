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
using WebTemplate.Domain.Adapters;
using WebTemplate.Domain.Users;
using WebTemplate.Infrastructure.Adapters;
using WebTemplate.Infrastructure.DependencyInjection;
using WebTemplate.Infrastructure.Identity.Models;
using WebTemplate.Infrastructure.Identity.Repositories;

namespace WebTemplate.Application.Users
{
    public class UserAppService :ApplicationService, IUserAppService
    {
        private readonly IIdentityUserRepository _userRepository;
        private readonly IUserDetailsRepository _userDetailsRepository;
        private readonly IUserAdapter _userAdapter;
        public UserAppService(
            IIdentityUserRepository userRepository,
            IUserDetailsRepository userDetailsRepository,
            IUserAdapter userAdapter)
        {
            _userRepository = userRepository;
            _userDetailsRepository = userDetailsRepository;
            _userAdapter = userAdapter;
        }

        public async Task<UserDto> CreateAsync(CreateUpdateUserDto input)
        {
            var user = Mapper.Map<ApplicationUser>(input);

            var result = await _userRepository.InsertAsync(user, input.Password);
            if(result != null)
            {
                return Mapper.Map<UserDto>(result);
            }

            //await _userRepository.InsertAsync(user,input.Password);
            throw new Exception("Erreur lors de la création de l'utilisateur");
        }

        public async Task<UserDetails> AddDetailsToUser(CreateUpdateUserDetailsDto input)
        {
            var userDetails = Mapper.Map<UserDetails>(input);
            userDetails.UserId = CurrentUser.UserId;
            var userDetailsSave = await _userDetailsRepository.InsertAsync(userDetails);

            return userDetailsSave;
        }

        public async Task<UserDetailsWithIdentityUserDto> GetUserAsync(Guid id)
        {
            Logger.LogDebug(CurrentUser.UserId.ToString());
            Logger.LogInformation("Demande d'utilisateur");
            var userDetails = await _userAdapter.GetUserDetailsById(id);
            Logger.LogInformation($"Reception de l'utilisateur {userDetails.UserName}");
            return Mapper.Map<UserDetailsWithIdentityUserDto>(userDetails);
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            
            return Mapper.Map<IEnumerable<UserDto>>(users);
        }
    }
}
