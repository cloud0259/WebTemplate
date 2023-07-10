using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTemplate.Infrastructure.Identity.Models;

namespace WebTemplate.Infrastructure.Identity.Managers
{
    public class WebTemplateUserManager : UserManager<ApplicationUser>
    {
        public WebTemplateUserManager(
            IUserStore<ApplicationUser> store,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<ApplicationUser> passwordHasher,
            IEnumerable<IUserValidator<ApplicationUser>> userValidators,
            IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators,
            ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors,
            IServiceProvider services,
            ILogger<UserManager<ApplicationUser>> logger)
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
        }

        public override async Task<IdentityResult> CreateAsync(ApplicationUser user, string password)
        {
            var userExist = await FindByNameAsync(user.UserName);
            if (userExist != null) 
            {
                throw new Exception($"Un utilisateur avec le username {user.UserName} existe déjà!");
            }

            return await base.CreateAsync(user, password);
        }
    }
}
