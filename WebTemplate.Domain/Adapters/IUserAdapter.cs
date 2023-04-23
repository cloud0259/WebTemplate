using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTemplate.Domain.Users;

namespace WebTemplate.Domain.Adapters
{
    public interface IUserAdapter
    {
        public Task<UserDetailsWithIdentityUser> GetUserDetailsById(Guid id);
    }
}
