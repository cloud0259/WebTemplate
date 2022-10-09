using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTemplate.Application.Applications;
using WebTemplate.Application.Dtos.Users;

namespace WebTemplate.Application.Users
{
    public interface IUserAppService:IApplicationService
    {
        public Task<UserDto> GetUserAsync(string username);
        public Task<IEnumerable<UserDto>> GetUsersAsync();
        public Task<UserDto> CreateAsync(CreateUpdateUserDto input);
    }
}
