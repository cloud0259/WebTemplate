using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTemplate.Application.Applications;
using WebTemplate.Application.Dtos.Users;
using WebTemplate.Core.Repositories;
using WebTemplate.Domain.Users;
using WebTemplate.Infrastructure.Identity.Models;
using WebTemplate.Infrastructure.Identity.Repositories;

namespace WebTemplate.Application.Users
{
    public class UserAppService :ApplicationService, IUserAppService
    {
        private readonly IIdentityUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserAppService(IIdentityUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> CreateAsync(CreateUpdateUserDto input)
        {
            var user = _mapper.Map<ApplicationUser>(input);
            await _userRepository.InsertAsync(user,input.Password);
            /*var user = _mapper.Map<User>(input);

            var userSave = await _userRepository.InsertAsync(user);
            return _mapper.Map<UserDto>(userSave);*/
            return null;
        }

        public async Task<UserDto> GetUserAsync(string email)
        {
            var user = await _userRepository.GetAsync(u => u.Email == email);

            return _mapper.Map<UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }
    }
}
