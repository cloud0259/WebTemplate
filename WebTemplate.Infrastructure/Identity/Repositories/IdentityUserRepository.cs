using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;
using WebTemplate.Core.Constants;
using WebTemplate.Core.Repositories;
using WebTemplate.Infrastructure.Exceptions;
using WebTemplate.Infrastructure.Extensions;
using WebTemplate.Infrastructure.Identity.Models;

namespace WebTemplate.Infrastructure.Identity.Repositories
{
    public class IdentityRepository : IIdentityUserRepository, IRepository<ApplicationUser, Guid>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IdentityRepository( UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public virtual async Task DeleteAsync(ApplicationUser entity, CancellationToken cancellationToken = default)
        {
            var result = await _userManager.DeleteAsync(entity);

            if (!result.Succeeded)
            {
                throw new UserDeletedException(entity.UserName);
            }
        }

        public virtual async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id,cancellationToken);

            if(user == null)
            {
                throw new UserNotFoundException(id.ToString());
            }
            await DeleteAsync(user, cancellationToken);
        }

        public virtual Task<ApplicationUser> FindAsync(string id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> FindAsync(Expression<Func<ApplicationUser, bool>> expression, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllAsync( CancellationToken cancellationToken = default)
        {
            return await _userManager.Users.ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllAsync(Expression<Func<ApplicationUser, bool>> expression, CancellationToken cancellationToken = default)
        {
            return await _userManager.Users.Where(expression).ToListAsync(cancellationToken);
        }

        public Task<IEnumerable<ApplicationUser>> GetAllAsync(bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ApplicationUser>> GetAllAsync(Expression<Func<ApplicationUser, bool>> expression, bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<ApplicationUser> GetAsync(Expression<Func<ApplicationUser, bool>> expression, CancellationToken cancellationToken = default)
        {
            var user =  await _userManager.Users.FirstOrDefaultAsync(expression,cancellationToken);

            if(user == null)
            { 
                throw new UserNotFoundException($"Impossible de trouver un utilisateur avec l'expression {expression}", null);
            }
            return user;
        }

        public async Task<ApplicationUser> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await GetAsync(x=>x.Id == id,cancellationToken);

        }

        public async Task<(int,IEnumerable<ApplicationUser>)> GetPagedList(string filter, int skipCount, int maxResultCount, string sorting, CancellationToken cancellationToken = default)
        {
            var query = _userManager.Users.AsQueryable();
            query = query.WhereIf(filter is not null, x=>x.Email.Contains(filter));
            query = query.Skip(skipCount);
            query = query.Take(maxResultCount);
            query = string.IsNullOrEmpty(sorting) ? query.OrderBy("desc", nameof(ApplicationUser.Email)) : query.OrderBy(sorting, nameof(ApplicationUser.Email));
            var count = query.CountAsync();
            return (await count, await query.ToListAsync());
        }

        public Task<(int, IEnumerable<ApplicationUser>)> GetPagedList(int skipCount, int maxResultCount, string sorting, bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<ApplicationUser> InsertAsync(ApplicationUser entity, string password, CancellationToken cancellationToken = default)
        {
            entity.IsEnabled = true;
            entity.EmailConfirmed = true;
            var status = await _userManager.CreateAsync(entity, password);

            if (status.Succeeded)
            {
                var userSave = await _userManager.FindByEmailAsync(entity.Email);
                await _userManager.AddToRoleAsync(userSave, ApplicationIdentityConstants.Roles.Member);
                if (userSave != null)
                {
                    return userSave;
                }
            }

            StringBuilder errorBuilder = new StringBuilder();
            foreach (var item in status.Errors)
            {
                errorBuilder.AppendLine($"{item.Description}");
            }

            throw new UserCreateException(errorBuilder.ToString());
        }

        public Task<ApplicationUser> InsertAsync(ApplicationUser entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task InsertManyAsync(IEnumerable<ApplicationUser> entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(ApplicationUser entity, CancellationToken cancellationToken = default)
        {
            var result = await _userManager.UpdateAsync(entity);

            if (!result.Succeeded)
            {
                throw new UserUpdateException(entity.UserName);
            }
        }

        public Task UpdateAsync(ApplicationUser entity, bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateManyAsync(IEnumerable<ApplicationUser> entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
