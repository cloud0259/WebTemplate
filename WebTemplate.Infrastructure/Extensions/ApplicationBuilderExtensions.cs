using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTemplate.Domain.Users;
using WebTemplate.Infrastructure.Identity.Models;
using WebTemplate.Infrastructure.Identity.Seed;

namespace WebTemplate.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static async Task SeedIdentityDataAsync(this IApplicationBuilder builder)
        {
            using (var serviceScope = builder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

                await ApplicationDbContextDataSeed.SeedAsync(userManager, roleManager);
            }
        }
    }
}