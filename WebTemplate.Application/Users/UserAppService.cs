using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTemplate.Application.Applications;
using WebTemplate.Application.Dtos.Users;
using WebTemplate.Domain.Users;

namespace WebTemplate.Application.Users
{
    public class UserAppService :ApplicationService, IUserAppService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserAppService(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> CreateAsync(CreateUpdateUserDto input)
        {
            var user = _mapper.Map<User>(input);

            var userSave = await _userRepository.InsertAsync(user);
            return _mapper.Map<UserDto>(userSave);
        }

        public async Task<UserDto> GetUserAsync(string username)
        {
            var user = await _userRepository.GetAsync(u => u.Username == username);

            return _mapper.Map<UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }
    }
}
