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
    public interface IUserAppService:IApplicationService
    {
        public Task<UserDetailsWithIdentityUserDto> GetUserAsync(Guid id);
        public Task<IEnumerable<UserDto>> GetUsersAsync();
        public Task<UserDto> CreateAsync(CreateUpdateUserDto input);
        public Task<UserDetails> AddDetailsToUser(CreateUpdateUserDetailsDto input);
    }
}
