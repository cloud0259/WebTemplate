using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebTemplate.Core.Constants;
using WebTemplate.Core.Repositories;
using WebTemplate.Domain.Users;
using WebTemplate.Infrastructure.EntityFrameworkCore;
using WebTemplate.Infrastructure.Exceptions;
using WebTemplate.Infrastructure.Extensions;
using WebTemplate.Infrastructure.Identity.Models;

namespace WebTemplate.Infrastructure.Identity.Repositories
{
    public class IdentityRepository : IIdentityUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IdentityRepository( UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task DeleteAsync(ApplicationUser entity, CancellationToken cancellationToken = default)
        {
            var result = await _userManager.DeleteAsync(entity);

            if (!result.Succeeded)
            {
                throw new UserDeletedException(entity.UserName);
            }
        }

        public async Task DeleteAsync(string id, CancellationToken cancellationToken = default)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == id);

            if(user == null)
            {
                throw new UserNotFoundException(id);
            }
            await DeleteAsync(user, cancellationToken);
        }

        public Task<ApplicationUser> FindAsync(string id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> FindAsync(Expression<Func<ApplicationUser, bool>> expression, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllAsync( CancellationToken cancellationToken = default)
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllAsync(Expression<Func<ApplicationUser, bool>> expression, CancellationToken cancellationToken = default)
        {
            return await _userManager.Users.Where(expression).ToListAsync();
        }

        public async Task<ApplicationUser> GetAsync(Expression<Func<ApplicationUser, bool>> expression, CancellationToken cancellationToken = default)
        {
            var user =  await _userManager.Users.FirstOrDefaultAsync(expression);

            if(user == null)
            { 
                throw new UserNotFoundException($"Impossible de trouver un utilisateur avec l'expression {expression}", null);
            }
            return user;
        }

        public async Task<ApplicationUser> GetAsync(string id, CancellationToken cancellationToken = default)
        {
            return await GetAsync(x=>x.Id == id,cancellationToken);

        }

        public async Task<(int,IEnumerable<ApplicationUser>)> GetPagedList(string filter, int skipCount, int maxResultCount, string sorting, CancellationToken cancellationToken = default)
        {
            var query = _userManager.Users.AsQueryable();
            query = query.WhereIf(filter is not null, x=>x.Email.Contains(filter));
            query = query.Skip(skipCount);
            query = query.Take(maxResultCount);
            //query = query.WhereIf(sorting is not null, query.OrderBy(x => x.NormalizedEmail));
            var count = await query.CountAsync();

            return (count, await query.ToListAsync());
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

        public async Task UpdateAsync(ApplicationUser entity, CancellationToken cancellationToken = default)
        {
            var result = await _userManager.UpdateAsync(entity);

            if (!result.Succeeded)
            {
                throw new UserUpdateException(entity.UserName);
            }
        }
    }
}
