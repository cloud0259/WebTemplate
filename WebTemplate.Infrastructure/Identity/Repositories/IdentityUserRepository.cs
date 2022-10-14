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

        public Task DeleteAsync(ApplicationUser entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> FindAsync(string id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> FindAsync(Expression<Func<ApplicationUser, bool>> expression, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllAsync(bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            return await _userManager.Users.ToListAsync();
        }

        public Task<IEnumerable<ApplicationUser>> GetAllAsync(Expression<Func<ApplicationUser, bool>> expression, bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<ApplicationUser> GetAsync(Expression<Func<ApplicationUser, bool>> expression, CancellationToken cancellationToken = default)
        {
            return await _userManager.Users.FirstOrDefaultAsync(expression);
        }

        public Task<ApplicationUser> GetAsync(string id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ApplicationUser>> GetPagedList(int skipCount, int maxResultCount, string sorting, bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<ApplicationUser> InsertAsync(ApplicationUser entity, string password, CancellationToken cancellationToken = default)
        {
            entity.IsEnabled = true;
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

            throw new Exception("Erreur d'enregistrement du user");
        }

        public Task UpdateAsync(ApplicationUser entity, bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
