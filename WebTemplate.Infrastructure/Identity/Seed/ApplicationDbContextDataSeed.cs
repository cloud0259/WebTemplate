using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTemplate.Core.Constants;
using WebTemplate.Domain.Users;
using WebTemplate.Infrastructure.Identity.Models;

namespace WebTemplate.Infrastructure.Identity.Seed
{
    public class ApplicationDbContextDataSeed
    {

        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<Guid>> roleManager)
        {
            // Add roles supported
            await roleManager.CreateAsync(new IdentityRole<Guid>(ApplicationIdentityConstants.Roles.Administrator));
            await roleManager.CreateAsync(new IdentityRole<Guid>(ApplicationIdentityConstants.Roles.Member));

            // New admin user
            string adminUserName = "admin@webtemplate.com";
            var adminUser = new ApplicationUser
            {
                UserName = adminUserName,
                Email = adminUserName,
                IsEnabled = true,
                EmailConfirmed = true,
                FirstName = "admin",
                LastName = "Administrator"
            };

            // Add new user and their role
            await userManager.CreateAsync(adminUser, ApplicationIdentityConstants.DefaultPassword);
            adminUser = await userManager.FindByNameAsync(adminUserName);
            await userManager.AddToRoleAsync(adminUser, ApplicationIdentityConstants.Roles.Administrator);
        }
    }
}
