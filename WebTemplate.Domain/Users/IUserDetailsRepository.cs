using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTemplate.Core.Repositories;

namespace WebTemplate.Domain.Users
{
    public interface IUserDetailsRepository : IRepository<UserDetails,Guid>
    {
        public Task<UserDetails> GetByUserIdAsync(Guid id);
    }
}
