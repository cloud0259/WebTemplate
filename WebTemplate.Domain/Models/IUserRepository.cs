using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTemplate.Domain.Repositories;

namespace WebTemplate.Domain.Models
{
    public interface IUserRepository : IRepository<User, Guid>
    {

    }
}
