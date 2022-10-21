using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebTemplate.Core.Repositories;
using WebTemplate.Domain.Users;
using WebTemplate.Infrastructure.Identity.Models;

namespace WebTemplate.Infrastructure.Identity.Repositories
{
    public interface IIdentityUserRepository
    {
        Task<ApplicationUser> GetAsync(string id, CancellationToken cancellationToken = default);
        Task<ApplicationUser> GetAsync(Expression<Func<ApplicationUser, bool>> expression, CancellationToken cancellationToken = default);
        Task<IEnumerable<ApplicationUser>> GetAllAsync(CancellationToken cancellationToken = default);
        Task UpdateAsync(ApplicationUser entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(string id, CancellationToken cancellationToken = default);
        Task DeleteAsync(ApplicationUser entity, CancellationToken cancellationToken = default);
        Task<(int,IEnumerable<ApplicationUser>)> GetPagedList(
            string filter,
            int skipCount,
            int maxResultCount,
            string sorting,
            CancellationToken cancellationToken = default);
        public Task<ApplicationUser> InsertAsync(ApplicationUser entity, string password, CancellationToken cancellationToken = default);
        Task<ApplicationUser> FindAsync(string id, CancellationToken cancellationToken = default);
        Task<ApplicationUser> FindAsync(Expression<Func<ApplicationUser, bool>> expression, CancellationToken cancellationToken = default);
    }
}
