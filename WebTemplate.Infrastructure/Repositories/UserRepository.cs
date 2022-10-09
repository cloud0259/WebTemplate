using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebTemplate.Domain.Entities;
using WebTemplate.Domain.Models;
using WebTemplate.Infrastructure.EntityFrameworkCore;

namespace WebTemplate.Infrastructure.Repositories
{
    public class UserRepository : Repository<User,Guid>, IUserRepository
    {
        private readonly WebTemplateDbContext _dbcontext;

        public UserRepository(WebTemplateDbContext dbcontext)
            :base(dbcontext) 
        {
            _dbcontext = dbcontext;             
        }

    }
}
