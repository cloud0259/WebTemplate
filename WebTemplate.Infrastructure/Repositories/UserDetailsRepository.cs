using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebTemplate.Domain.Users;
using WebTemplate.Infrastructure.EntityFrameworkCore;
using WebTemplate.Infrastructure.EntityFrameworkCore.SoftDeletes;

namespace WebTemplate.Infrastructure.Repositories
{
    public class UserDetailsRepository : Repository<UserDetails, Guid>, IUserDetailsRepository
    {
        public UserDetailsRepository(WebTemplateDbContext dbContext, IDataFilter dataFilter) 
            : base(dbContext, dataFilter)
        {
        }

        public Task<UserDetails> GetByUserIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
        public override Task<UserDetails> GetAsync(Expression<Func<UserDetails, bool>> expression, CancellationToken cancellationToken = default)
        {
            return base.GetAsync(expression, cancellationToken);
        }
        public override Task<UserDetails> InsertAsync(UserDetails entity, CancellationToken cancellationToken = default)
        {
            return base.InsertAsync(entity, cancellationToken);
        }      
    }
}
